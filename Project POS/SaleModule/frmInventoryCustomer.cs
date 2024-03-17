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

namespace Project_POS.SaleModule
{
    public partial class frmInventoryCustomer : Form
    {
        public frmInventoryCustomer()
        {
            InitializeComponent();
            MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.Load);
        }
        SqlConnection con; SqlTransaction tran;
        #region functions

        private void Insert()
        {

            using (con = new SqlConnection(Global.ConnectionString))
            using (con = new SqlConnection(Global.ConnectionString))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    if (string.IsNullOrEmpty(txtCustName.Text)) { MessageBox.Show(this, "Enter Customer Name !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1); return; }
                    txtCustCode.Text = Convert.ToString(SqlQuery.GetNewTransNo());
                    SqlQuery.Insert(con, tran, "Inventory_Customer", Global.ConnectionString, new Dictionary<string, object> { { "CustCode", txtCustCode.Text }, { "CustName", txtCustName.Text }, { "NIC", txtNIC.Text }, { "Address", txtAddress.Text }, { "PhoneNo", txtPhoneNo.Text }, { "Active", chkActive.Checked } });
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

        private bool BeforeUpdateDelete()
        {
            if (SqlQuery.IsFound(con, tran, Global.ConnectionString, "Inventory_Sale", $"CustCode = '{txtCustCode.Text}'"))
            {
                return false;
            }
            if (SqlQuery.IsFound(con, tran, Global.ConnectionString, "Inventory_SaleReturn", $"CustCode = '{txtCustCode.Text}'"))
            {
                return false;
            }
            return true;
        }
        private new void Update()
        {
            if (!BeforeUpdateDelete())
            {
                MessageBox.Show(this, "Can't Update ! \nThe Customer is Used in Transaction", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1); return;
            }
            using (con = new SqlConnection(Global.ConnectionString))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    if (string.IsNullOrEmpty(txtCustName.Text)) { MessageBox.Show(this, "Enter Customer Name !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1); return; }
                    SqlQuery.Update(con, tran, Global.ConnectionString, "Inventory_Customer", $"WHERE CustCode = '{txtCustCode.Text}' ", new Dictionary<string, object> { { "CustName", txtCustName.Text }, { "NIC", txtNIC.Text }, { "Address", txtAddress.Text }, { "PhoneNo", txtPhoneNo.Text }, { "Active", chkActive.Checked } });
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
        private void Delete()
        {
            if (string.IsNullOrEmpty(txtCustCode.Text.Trim())) { MessageBox.Show(this, "No Record to Delete !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1); return; }
            //else if (SqlQuery.IsFound(Global.Connection, Global.Transaction, Global.ConnectionString, "Inventory_Products", $"CatID = {txtCatID.Text}"))
            //{
            //    MessageBox.Show(this, "Cannot Delete \nCategory Used in Product !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1); return;
            //}
            //else if (SqlQuery.IsFound(Global.Connection, Global.Transaction, Global.ConnectionString, "Inventory_Items", $"CatID = {txtCatID.Text}"))
            //{
            //    MessageBox.Show(this, "Cannot Delete \nCategory Used in Items !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1); return;
            //}

            if (!BeforeUpdateDelete())
            {
                MessageBox.Show(this, "Can't Delete ! \nThe Customer is Used in Transaction", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1); return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to Delete ?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {

                using (con = new SqlConnection(Global.ConnectionString))
                {
                    con.Open();
                    tran = con.BeginTransaction();
                    try
                    {
                        SqlQuery.Delete(con, tran, Global.ConnectionString, "Inventory_Customer", $" CustCode = '{txtCustCode.Text}'");
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
        private void Edit()
        {
            if (string.IsNullOrEmpty(txtCustCode.Text.Trim()))
            {
                MessageBox.Show(this, "No Record to Edit !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }

            if (!BeforeUpdateDelete())
            {
                MessageBox.Show(this, "Can't Edit ! \nThe Customer is Used in Transaction", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1); return;
            }
            MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.Edit);
            IsEnable(true);

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
            frm.SetData(con, Global.ConnectionString, "SELECT * FROM Inventory_Customer WITH(NOLOCK)", "CustCode");
            frm.FormClosing += (o, a) =>
            {
                con.Open();
                var frmkey = o as frmLOV;
                string code = frmkey.Code;
                if (string.IsNullOrEmpty(code))
                {
                    return;
                }
                string query = "SELECT * FROM Inventory_Customer WITH(NOLOCK) WHERE CustCode = @Code";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Code", code);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                con.Close();

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    txtCustCode.Text = row["CustCode"].ToString();
                    txtCustName.Text = row["CustName"].ToString();
                    txtNIC.Text = row["NIC"].ToString();
                    txtPhoneNo.Text = row["PhoneNo"].ToString();
                    txtAddress.Text = row["Address"].ToString();
                    chkActive.Checked = Convert.ToBoolean(row["Active"].ToString());
                }
                MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.Load);
                IsEnable(false);
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
            txtCustCode.Text = string.Empty;
            txtCustName.Text = string.Empty;
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
            if (string.IsNullOrEmpty(txtCustCode.Text.Trim()))
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

        private void frmInventoryCustomer_Load(object sender, EventArgs e)
        {
            MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.Load);
            IsEnable(false);
        }
    }
}
