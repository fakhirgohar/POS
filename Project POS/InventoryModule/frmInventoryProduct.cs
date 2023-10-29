using Project_POS.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_POS.InventoryModule
{
    public partial class frmInventoryProduct : Form
    {
        SqlConnection con; SqlTransaction tran;
        public frmInventoryProduct()
        {
            InitializeComponent();
        }
        #region functions

        private void Insert()
        {
            using (con = new SqlConnection(Global.ConnectionString))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {

                    txtProdCode.Text = Convert.ToString(SqlQuery.GetTransNo(con, tran, Global.ConnectionString, "Inventory_Products", "ProdCode"));
                    SqlQuery.Insert(con, tran, "Inventory_Products", Global.ConnectionString, new Dictionary<string, object> { { "ProdCode", txtProdCode.Text }, { "ProdName", txtProdName.Text }, { "CatID", cboCat.SelectedValue } });
                    MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.Save);
                    MessageBox.Show(this, "Saved Successfully !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    IsEnable(false);
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw new Exception(ex.Message);
                }
                finally
                {
                    if (con.State == ConnectionState.Open) { con.Close(); }
                }
            }
        }
        private new void Update()
        {
            if (InsertUpdate())
            {
                if (BeforeUpdateDelete())
                {
                    using (con = new SqlConnection(Global.ConnectionString))
                    {
                        con.Open();
                        tran = con.BeginTransaction();
                        try
                        {
                            if (string.IsNullOrEmpty(txtProdName.Text)) { MessageBox.Show("Enter Product Name !"); return; }
                            SqlQuery.Update(con, tran, Global.ConnectionString, "Inventory_Products", $"WHERE ProdCode = {txtProdCode.Text} ", new Dictionary<string, object> { { "ProdName", txtProdName.Text } });
                            tran.Commit();
                            con.Dispose();
                            MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.Save);
                            MessageBox.Show(this, "Update Successfully !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                            IsEnable(false);
                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();
                            throw new Exception(ex.Message);
                        }
                        finally
                        {
                            if (con.State == ConnectionState.Open) { con.Close(); }
                        }
                    }
                }
            }
        }
        private bool InsertUpdate()
        {
            if (string.IsNullOrEmpty(txtProdName.Text.Trim())) { MessageBox.Show(this, "Enter Product Name !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1); return false; }
            return true;
        }

        private bool BeforeUpdateDelete()
        {
            if (SqlQuery.IsFound(con, tran, Global.ConnectionString, "Inventory_Items", $"ProdCode = {txtProdCode.Text}"))
            {
                MessageBox.Show(this, "Product Used in Items !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1); return false;
            }
            return true;
        }
        private void Delete()
        {
            if (string.IsNullOrEmpty(txtProdCode.Text.Trim())) { MessageBox.Show("No Record to Delete !"); return; }

            if (BeforeUpdateDelete())
            {
                DialogResult result = MessageBox.Show("Are you sure you want to Delete ?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    using (con = new SqlConnection(Global.ConnectionString))
                    {
                        con.Open();
                        tran = con.BeginTransaction();
                        try
                        {
                            SqlQuery.Delete(con, tran, Global.ConnectionString, "Inventory_Products", $" ProdCode = '{txtProdCode.Text}'");
                            tran.Commit();
                            con.Dispose();
                            MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.Cancel);
                            ClearControls();
                            IsEnable(false);
                            MessageBox.Show(this, "Delete Successfully !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();
                            throw new Exception(ex.Message);
                        }
                        finally
                        {
                            if (con.State == ConnectionState.Open) { con.Close(); }
                        }
                    }
                }
            }

        }
        private void Edit()
        {
            if (string.IsNullOrEmpty(txtProdCode.Text.Trim()))
            {
                MessageBox.Show(this, "No Record to Edit !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.Edit);
            IsEnable(true);
            cboCat.Enabled = false;
            txtProdName.Focus();
        }
        private void Cancel()
        {
            DialogResult result = MessageBox.Show("Are you sure you want to Cancel this Transaction?", "Confirm Cancellation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                ClearControls();
                IsEnable(false);
                MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.Cancel);
            }
        }
        private void Search()
        {
            SqlConnection con = new SqlConnection(Global.ConnectionString);
            frmLOV frm = new frmLOV();
            frm.SetData(con, Global.ConnectionString, "SELECT * FROM Inventory_Products WITH(NOLOCK)", "ProdCode");
            frm.FormClosing += (o, a) =>
            {

                con.Open();
                var frmKey = o as frmLOV;
                string code = frmKey.Code;
                if (string.IsNullOrEmpty(code))
                {
                    return;
                }
                string query = "SELECT * FROM Inventory_Products WITH(NOLOCK) WHERE ProdCode = @Code";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Code", code);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                con.Close();

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    txtProdCode.Text = row["ProdCode"].ToString();
                    txtProdName.Text = row["ProdName"].ToString();
                    DataTable NDT = SqlQuery.Read(con, tran, Global.ConnectionString, $"SELECT * FROM Inventory_Category WITH(NOLOCK) WHERE CatID = '{row["CatID"]}'");
                    cboCat.DisplayMember = "CatName";
                    cboCat.ValueMember = "CatID";
                    cboCat.DataSource = NDT;
                }
                MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.Load);
            };
            frm.ShowDialog();
        }
        private void New()
        {
            MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.New);
            ClearControls();
            IsEnable(true);
        }
        private void ClearControls()
        {
            cboCat.Text = string.Empty;
            txtProdCode.Text = string.Empty;
            txtProdName.Text = string.Empty;
        }
        private void IsEnable(bool cond)
        {
            grpMain.Enabled = cond;
        }
        #endregion
        private void btnNew_Click(object sender, EventArgs e)
        {
            New();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Edit();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProdCode.Text.Trim()))
            {
                Insert();
            }
            else
            {
                Update();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {

        }

        private void frmInventoryProduct_Load(object sender, EventArgs e)
        {
            DataTable dtCat = SqlQuery.Read(con, tran, Global.ConnectionString, "select * from Inventory_Category with(nolock)");
            cboCat.DisplayMember = "CatName";
            cboCat.ValueMember = "CatID";
            cboCat.DataSource = dtCat;
            grpMain.Enabled = false;
            MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.Load);
            ClearControls();
            IsEnable(false);
        }
    }
}
