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
    public partial class frmInventoryCompany : Form
    {
        SqlConnection con; SqlTransaction tran;
        public frmInventoryCompany()
        {
            InitializeComponent();
            MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.Load);
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
                    InsertUpdateCheck();
                    txtCompCode.Text = Convert.ToString(SqlQuery.GetTransNo(con, tran, Global.ConnectionString, "Inventory_Company", "CompCode"));
                    SqlQuery.Insert(con, tran, "Inventory_Company", Global.ConnectionString, new Dictionary<string, object> { { "CompCode", txtCompCode.Text }, { "CompName", txtCompName.Text } });
                    tran.Commit();
                    con.Dispose();
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
            if (BeforeUpdateDelete())
            {
                using (con = new SqlConnection(Global.ConnectionString))
                {
                    con.Open();
                    tran = con.BeginTransaction();
                    try
                    {
                        InsertUpdateCheck();
                        SqlQuery.Update(con, tran, Global.ConnectionString, "Inventory_Company", $"WHERE CompCode = {txtCompCode.Text} ", new Dictionary<string, object> { { "CompName", txtCompName.Text } });
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
        private void Delete()
        {
            if (string.IsNullOrEmpty(txtCompCode.Text.Trim()))
            {
                MessageBox.Show(this, "No Record to Delete !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1); return;
            }

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
                            SqlQuery.Delete(con, tran, Global.ConnectionString, "Inventory_Company", $" CompCode = '{txtCompCode.Text}'");
                            tran.Commit();
                            con.Dispose();
                            MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.Cancel);
                            ClearControls();
                            MessageBox.Show(this, "Deleted Successfully !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
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
        private void InsertUpdateCheck()
        {
            if (string.IsNullOrEmpty(txtCompName.Text))
            {
                MessageBox.Show(this, "Enter Company Name !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1); return;
            }
        }
        private void Edit()
        {
            if (BeforeUpdateDelete())
            {
                if (string.IsNullOrEmpty(txtCompCode.Text.Trim()))
                {
                    MessageBox.Show(this, "No Record to Edit !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
                MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.Edit);
                IsEnable(true);
            }
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

        private bool BeforeUpdateDelete()
        {
            if (SqlQuery.IsFound(con, tran, Global.ConnectionString, "Inventory_Items", $"CompCode = {txtCompCode.Text}"))
            {
                MessageBox.Show(this, "Company Used in Item !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1); return false;
            }
            return true;
        }
        private void Search()
        {
            SqlConnection con = new SqlConnection(Global.ConnectionString);
            frmLOV frm = new frmLOV();
            frm.SetData(con, Global.ConnectionString, "SELECT * FROM Inventory_Company WITH(NOLOCK)", "CompCode");
            frm.FormClosing += (o, a) =>
            {

                con.Open();
                var frmKey = o as frmLOV;
                string code = frmKey.Code;
                if (string.IsNullOrEmpty(code))
                {
                    return;
                }
                string query = "SELECT * FROM Inventory_Company WITH(NOLOCK) WHERE CompCode = @Code";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Code", code);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                con.Close();

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    txtCompCode.Text = row["CompCode"].ToString();
                    txtCompName.Text = row["CompName"].ToString();
                }
                MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.Load);
            };
            frm.ShowDialog();
        }
        private void New()
        {
            MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.New);
            ClearControls();
        }
        private void ClearControls()
        {
            txtCompCode.Text = string.Empty;
            txtCompName.Text = string.Empty;
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
            //if (string.IsNullOrEmpty(txtCompCode.Text.Trim()))
            //{
            //    Insert();
            //}
            //else
            //{
            //    Update();
            //}
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

        private void frmInventoryCompany_Load(object sender, EventArgs e)
        {
            MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.Load);
            ClearControls();
            IsEnable(false);
        }
    }
}
