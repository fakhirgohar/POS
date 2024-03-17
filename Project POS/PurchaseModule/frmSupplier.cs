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
    public partial class frmSupplier : Form
    {
        public frmSupplier()
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
                    if (string.IsNullOrEmpty(txtSuppName.Text)) { MessageBox.Show(this, "Enter Supplier Name !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1); return; }
                    txtSuppCode.Text = Convert.ToString(SqlQuery.GetNewTransNo());
                    SqlQuery.Insert(con, tran, "Inventory_Suppliers", Global.ConnectionString, new Dictionary<string, object> { { "SuppCode", txtSuppCode.Text }, { "SuppName", txtSuppName.Text }, { "NIC", txtNIC.Text }, { "Address", txtAddress.Text }, { "PhoneNo", txtPhoneNo.Text }, { "Active", chkActive.Checked } });
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
                        if (string.IsNullOrEmpty(txtSuppName.Text)) { MessageBox.Show(this, "Enter Supplier Name !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1); return; }
                        SqlQuery.Update(con, tran, Global.ConnectionString, "Inventory_Suppliers", $"WHERE SuppCode = {txtSuppCode.Text} ", new Dictionary<string, object> { { "SuppName", txtSuppName.Text }, { "NIC", txtNIC.Text }, { "Address", txtAddress.Text }, { "PhoneNo", txtPhoneNo.Text }, { "Active", chkActive.Checked } });
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

        private bool BeforeUpdateDelete()
        {
            if (SqlQuery.IsFound(Global.Con, Global.tran, Global.ConnectionString, "Inventory_Purchase", $"SuppCode = {txtSuppCode.Text}"))
            {
                MessageBox.Show(this, "Supplier Used in Transactions !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1); return false;
            }
            if (SqlQuery.IsFound(Global.Con, Global.tran, Global.ConnectionString, "Inventory_PurchaseReturn", $"SuppCode = {txtSuppCode.Text}"))
            {
                MessageBox.Show(this, "Supplier Used in Transactions !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1); return false;
            }
            return true;
        }

        private void Delete()
        {
            if (string.IsNullOrEmpty(txtSuppCode.Text.Trim())) { MessageBox.Show(this, "No Record to Delete !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1); return; }


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
                            SqlQuery.Delete(con, tran, Global.ConnectionString, "Inventory_Suppliers", $" SuppCode = '{txtSuppCode.Text}'");
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
        private void Edit()
        {

            if (string.IsNullOrEmpty(txtSuppCode.Text.Trim()))
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
        private void Search()
        {
            SqlConnection con = new SqlConnection(Global.ConnectionString);
            frmLOV frm = new frmLOV();
            frm.SetData(con, Global.ConnectionString, "SELECT * FROM Inventory_Suppliers WITH(NOLOCK)", "SuppCode");
            frm.FormClosing += (o, a) =>
            {
                con.Open();
                var frmKey = o as frmLOV;
                string code = frmKey.Code;
                if (string.IsNullOrEmpty(code))
                {
                    return;
                }
                string query = "SELECT * FROM Inventory_Suppliers WITH(NOLOCK) WHERE SuppCode = @Code";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Code", code);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                con.Close();

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    txtSuppCode.Text = row["SuppCode"].ToString();
                    txtSuppName.Text = row["SuppName"].ToString();
                    txtNIC.Text = row["NIC"].ToString();
                    txtPhoneNo.Text = row["PhoneNo"].ToString();
                    txtAddress.Text = row["Address"].ToString();
                    chkActive.Checked = Convert.ToBoolean(row["Active"].ToString());
                }
                MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.Load);
            };
            frm.ShowDialog();
        }
        private void New()
        {
            MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.New);
            ClearControl();
            IsEnable(true);
        }
        private void ClearControl()
        {
            txtSuppCode.Text = string.Empty;
            txtSuppName.Text = string.Empty;
            chkActive.Checked = false;
            txtNIC.Text = string.Empty;
            txtPhoneNo.Text = string.Empty;
            txtAddress.Text = string.Empty;
        }
        private void IsEnable(bool cond)
        {
            grpMain.Enabled = cond;
        }
        #endregion

        private void frmSupplier_Load(object sender, EventArgs e)
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
            if (string.IsNullOrEmpty(txtSuppCode.Text.Trim()))
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
