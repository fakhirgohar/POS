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
    public partial class frmInventoryStoreType : Form
    {
        public frmInventoryStoreType()
        {
            InitializeComponent();
            MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.Load);
        }
        SqlConnection con; SqlTransaction tran;
        #region functions

        private void Insert()
        {
            using (con = new SqlConnection(Global.ConnectionString))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    if (string.IsNullOrEmpty(txtTypeName.Text)) { MessageBox.Show(this, "Enter Type Name !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1); return; }
                    txtTypeID.Text = Convert.ToString(SqlQuery.GetTransNo(con, tran, Global.ConnectionString, "Inventory_StoreType", "TypeID"));
                    SqlQuery.Insert(con, tran, "Inventory_StoreType", Global.ConnectionString, new Dictionary<string, object> { { "TypeID", txtTypeID.Text }, { "Name", txtTypeName.Text } });
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
                        if (string.IsNullOrEmpty(txtTypeName.Text)) { MessageBox.Show(this, "Enter Category Name !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1); return; }
                        SqlQuery.Update(con, tran, Global.ConnectionString, "Inventory_StoreType", $"WHERE TypeID = {txtTypeID.Text} ", new Dictionary<string, object> { { "Name", txtTypeName.Text } });
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
            if (string.IsNullOrEmpty(txtTypeID.Text.Trim())) { MessageBox.Show(this, "No Record to Delete !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1); return; }
            else if (SqlQuery.IsFound(con, tran, Global.ConnectionString, "Inventory_Store", $"TypeID = {txtTypeID.Text}"))
            {
                MessageBox.Show(this, "Cannot Delete \nStore Type Used in Product !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1); return;
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
                                SqlQuery.Delete(con, tran, Global.ConnectionString, "Inventory_StoreType", $" TypeID = '{txtTypeID.Text}'");
                                tran.Commit();
                                con.Dispose();
                                MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.Cancel);
                                ClearControl();
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
            if (string.IsNullOrEmpty(txtTypeID.Text.Trim()))
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
                ClearControl();
                IsEnable(false);
                MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.Cancel);
            }
        }

        private bool BeforeUpdateDelete()
        {
            if (SqlQuery.IsFound(Global.Con, Global.tran, Global.ConnectionString, "Inventory_Store", $"TypeID = {txtTypeID.Text}"))
            {
                MessageBox.Show(this, "Store Type Used in Stores !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1); return false;
            }
            return true;
        }

        private void Search()
        {
            SqlConnection con = new SqlConnection(Global.ConnectionString);
            frmLOV frm = new frmLOV();
            frm.SetData(con, Global.ConnectionString, "SELECT * FROM Inventory_StoreType WITH(NOLOCK)", "TypeID");
            frm.FormClosing += (o, a) =>
            {
                con.Open();
                var frmKey = o as frmLOV;
                string code = frmKey.Code;
                if (string.IsNullOrEmpty(code))
                {
                    return;
                }
                string query = "SELECT * FROM Inventory_StoreType WITH(NOLOCK) WHERE TypeID = @Code";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Code", code);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                con.Close();

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    txtTypeID.Text = row["TypeID"].ToString();
                    txtTypeName.Text = row["Name"].ToString();
                }
                MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.Load);
            };
            frm.ShowDialog();
        }
        private void New()
        {
            MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.New);
            ClearControl();
        }
        private void ClearControl()
        {
            txtTypeID.Text = string.Empty;
            txtTypeName.Text = string.Empty;
        }
        private void IsEnable(bool cond)
        {
            grpMain.Enabled = cond;
        }
        #endregion

        private void frmInventoryStoreType_Load(object sender, EventArgs e)
        {
            MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.Load);
            ClearControl();
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
            if (string.IsNullOrEmpty(txtTypeID.Text.Trim()))
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
    }
}
