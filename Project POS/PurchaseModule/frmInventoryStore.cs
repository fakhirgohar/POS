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

namespace Project_POS.PurchaseModule
{
    public partial class frmInventoryStore : Form
    {
        SqlConnection con; SqlTransaction tran;
        public frmInventoryStore()
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
                    if (string.IsNullOrEmpty(txtStoreName.Text)) { MessageBox.Show(this, "Enter Store Name !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1); return; }
                    txtStoreID.Text = Convert.ToString(SqlQuery.GetNewTransNo());
                    SqlQuery.Insert(con, tran, "Inventory_Store", Global.ConnectionString, new Dictionary<string, object> { { "StoreID", txtStoreID.Text }, { "Name", txtStoreName.Text }, { "TypeID", cboType.SelectedValue }, { "Address", txtAddress.Text }, { "Active", chkActive.Checked } });
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
                        if (string.IsNullOrEmpty(txtStoreName.Text)) { MessageBox.Show(this, "Enter Store Name !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1); return; }
                        SqlQuery.Update(con, tran, Global.ConnectionString, "Inventory_Store", $"WHERE StoreID = {txtStoreID.Text} ", new Dictionary<string, object> { { "Name", txtStoreName.Text }, { "TypeID", cboType.SelectedValue }, { "Address", txtAddress.Text }, { "Active", chkActive.Checked } });
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
            if (string.IsNullOrEmpty(txtStoreID.Text.Trim())) { MessageBox.Show(this, "No Record to Delete !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1); return; }
            else if (SqlQuery.IsFound(con, tran, Global.ConnectionString, "Inventory_PurchaseDetail", $"StoreID = {txtStoreID.Text}"))
            {
                MessageBox.Show(this, "Cannot Delete \nStore Used in Product !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1); return;
            }
            else
            {
                DialogResult result = MessageBox.Show("Are you sure you want to Delete ?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (BeforeUpdateDelete())
                    {
                        using (con = new SqlConnection(Global.ConnectionString))
                        {
                            con.Open();
                            tran = con.BeginTransaction();
                            try
                            {
                                SqlQuery.Delete(con, tran, Global.ConnectionString, "Inventory_Store", $" StoreID = '{txtStoreID.Text}'");
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
        }
        private void Edit()
        {
            if (string.IsNullOrEmpty(txtStoreID.Text.Trim()))
            {
                MessageBox.Show(this, "No Record to Edit !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            if (BeforeUpdateDelete())
            {
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
            if (SqlQuery.IsFound(Global.Con, Global.tran, Global.ConnectionString, "Inventory_PurchaseDetail", $"StoreID = {txtStoreID.Text}"))
            {
                MessageBox.Show(this, "Store Used in Transactions !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1); return false;
            }
            if (SqlQuery.IsFound(Global.Con, Global.tran, Global.ConnectionString, "Inventory_PurchaseReturnDetail", $"StoreID = {txtStoreID.Text}"))
            {
                MessageBox.Show(this, "Store Used in Transactions !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1); return false;
            }
            return true;
        }

        private void Search()
        {
            SqlConnection con = new SqlConnection(Global.ConnectionString);
            frmLOV frm = new frmLOV();
            frm.SetData(con, Global.ConnectionString, "SELECT * FROM Inventory_Store WITH(NOLOCK)", "StoreID");
            frm.FormClosing += (o, a) =>
            {
                con.Open();
                var frmKey = o as frmLOV;
                string code = frmKey.Code;
                if (string.IsNullOrEmpty(code))
                {
                    return;
                }
                string query = "SELECT * FROM Inventory_Store WITH(NOLOCK) WHERE StoreID = @Code";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Code", code);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                con.Close();

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    txtStoreID.Text = row["StoreID"].ToString();
                    txtStoreName.Text = row["Name"].ToString();
                    txtAddress.Text = row["Address"].ToString();
                    cboType.Text = row["TypeID"].ToString();
                    chkActive.Checked = Convert.ToBoolean(row["Active"].ToString());
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
            txtStoreID.Text = string.Empty;
            txtStoreName.Text = string.Empty;
            cboType.Text = string.Empty;
            chkActive.Checked = false;
            txtAddress.Text = string.Empty;
        }
        private void IsEnable(bool cond)
        {
            grpMain.Enabled = cond;
        }
        #endregion
        private void frmInventoryStore_Load(object sender, EventArgs e)
        {
            MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.Load);
            SetCbo();
            ClearControls();
            IsEnable(false);
        }

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
            if (string.IsNullOrEmpty(txtStoreID.Text.Trim()))
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
        private void SetCbo()
        {
            DataTable dt = SqlQuery.Read(con, tran, Global.ConnectionString, "SELECT * FROM Inventory_StoreType WITH(NOLOCK)");
            cboType.DisplayMember = "Name";
            cboType.ValueMember = "TypeID";
            cboType.DataSource = dt;
        }
    }
}
