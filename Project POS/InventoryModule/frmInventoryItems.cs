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
    public partial class frmInventoryItems : Form
    {
        public frmInventoryItems()
        {
            InitializeComponent();
        }
        SqlConnection con; SqlTransaction tran;
        DataTable DtItemDetail = new DataTable();
        string ItemCode = string.Empty;
        bool isInsert = false;
        bool isUpdate = false;

        #region functions

        private void Insert()
        {
            using (con = new SqlConnection(Global.ConnectionString))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    if (InsertUpdateValidation())
                    {



                        SqlQuery.Insert(con, tran, "Inventory_Items", Global.ConnectionString, new Dictionary<string, object> { { "ItemCode", txtItemCode.Text }, { "ItemName", txtItemName.Text }, { "CompCode", cboBrand.SelectedValue }, { "CatID", cboCat.SelectedValue }, { "ProdCode", cboSubCat.SelectedValue }, { "BalQty", txtQty.Text }, { "MinLevel", txtMinLev.Text }, { "MaxLevel", txtMaxLev.Text }, { "ReOrderLevel", txtReOrdLev.Text }, { "Active", chkActive.Checked }, { "CanSale", chkCanSale.Checked }, { "CanPurchase", chkCanPurchase.Checked } });
                        tran.Commit();
                        con.Dispose();
                        MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.Save);
                        IsEnable(false);
                        MessageBox.Show(this, "Saved Successfully !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
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
            if (SqlQuery.IsFound(Global.Con, Global.tran, Global.ConnectionString, "Inventory_PurchaseDetail", $"ItemCode = '{ItemCode}'"))
            {
                MessageBox.Show(this, "The ItemCode is Used in other Transaction !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return false;
            }
            if (SqlQuery.IsFound(Global.Con, Global.tran, Global.ConnectionString, "Inventory_PurchaseReturnDetail", $"ItemCode = '{ItemCode}'"))
            {
                MessageBox.Show(this, "The ItemCode is Used in other Transaction !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return false;
            }
            if (SqlQuery.IsFound(Global.Con, Global.tran, Global.ConnectionString, "Inventory_ItemsDetail", $"ItemCode = '{ItemCode}'"))
            {
                MessageBox.Show(this, "The ItemCode is Used in other Transaction !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return false;
            }
            if (SqlQuery.IsFound(Global.Con, Global.tran, Global.ConnectionString, "Inventory_SaleDetail", $"ItemCode = '{ItemCode}'"))
            {
                MessageBox.Show(this, "The ItemCode is Used in other Transaction !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return false;
            }
            if (SqlQuery.IsFound(Global.Con, Global.tran, Global.ConnectionString, "Inventory_SaleReturnDetail", $"ItemCode = '{ItemCode}'"))
            {
                MessageBox.Show(this, "The ItemCode is Used in other Transaction !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return false;
            }
            return true;
        }

        private new void Update()
        {
            using (con = new SqlConnection(Global.ConnectionString))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    if (InsertUpdateValidation())
                    {
                        if (BeforeUpdateDelete())
                        {
                            SqlQuery.Update(con, tran, Global.ConnectionString, "Inventory_Items", $"Where ItemCode = '{txtItemCode.Text}'", new Dictionary<string, object> { { "ItemCode", txtItemCode.Text }, { "ItemName", txtItemName.Text }, { "CompCode", cboBrand.SelectedValue }, { "CatID", cboCat.SelectedValue }, { "ProdCode", cboSubCat.SelectedValue }, { "BalQty", txtQty.Text }, { "MinLevel", txtMinLev.Text }, { "MaxLevel", txtMaxLev.Text }, { "ReOrderLevel", txtReOrdLev.Text }, { "Active", chkActive.Checked }, { "CanSale", chkCanSale.Checked }, { "CanPurchase", chkCanPurchase.Checked } });
                            tran.Commit();
                            con.Dispose();
                            MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.Save);
                            IsEnable(false);
                            MessageBox.Show(this, "Update Successfully !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        }
                    }
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



            using (con = new SqlConnection(Global.ConnectionString))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {

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
            if (string.IsNullOrEmpty(txtItemCode.Text.Trim())) { MessageBox.Show(this, "No Record to Delete !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1); return; }

            else
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
                            if (BeforeUpdateDelete())
                            {
                                SqlQuery.Delete(con, tran, Global.ConnectionString, "Inventory_Items", $" ItemCode = '{txtItemCode.Text}'");
                                tran.Commit();
                                con.Dispose();
                                MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.Cancel);
                                ClearControls();
                                IsEnable(false);
                                isUpdate = false; isInsert = false;
                                MessageBox.Show(this, "Delete Successfully !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                            }
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
            if (string.IsNullOrEmpty(txtItemCode.Text.Trim()))
            {
                MessageBox.Show(this, "No Record To Edit !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            isUpdate = true; isInsert = false;
            MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.Edit);
            IsEnable(true);
        }
        private void Cancel()
        {
            DialogResult result = MessageBox.Show("Are you sure you want to Cancel this Transaction?", "Confirm Cancellation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                isInsert = false; isUpdate = false;
                ClearControls();
                MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.Cancel);
                IsEnable(false);
            }
        }


        private void Search()
        {
            SqlConnection con = new SqlConnection(Global.ConnectionString);
            frmLOV frm = new frmLOV();
            frm.SetData(con, Global.ConnectionString, "SELECT * FROM Inventory_Items WITH(NOLOCK)", "ItemCode");
            frm.FormClosing += (o, a) =>
            {

                con.Open();
                var frmKey = o as frmLOV;
                string code = frmKey.Code;
                if (string.IsNullOrEmpty(code))
                {
                    return;
                }
                string query = "SELECT * FROM Inventory_Items WITH(NOLOCK) WHERE ItemCode = @Code";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Code", code);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                con.Close();

                if (dt.Rows.Count > 0)
                {
                    ItemCode = string.Empty;
                    DataRow row = dt.Rows[0];
                    txtItemCode.Text = row["ItemCode"].ToString();
                    ItemCode = row["ItemCode"].ToString();
                    txtItemName.Text = row["ItemName"].ToString();
                    cboBrand.Text = row["CompCode"].ToString();
                    cboCat.Text = row["CatID"].ToString();
                    cboSubCat.Text = row["ProdCode"].ToString();
                    txtQty.Text = row["BalQty"].ToString();
                    txtMaxLev.Text = row["MaxLevel"].ToString();
                    txtMinLev.Text = row["MinLevel"].ToString();
                    txtReOrdLev.Text = row["ReOrderLevel"].ToString();
                    chkActive.Checked = Convert.ToBoolean(row["Active"].ToString());
                    chkCanPurchase.Checked = Convert.ToBoolean(row["CanPurchase"].ToString());
                    chkCanSale.Checked = Convert.ToBoolean(row["CanSale"].ToString());
                }
                dgvItemDetail.DataSource = null;
                dgvItemDetail.DataSource = SqlQuery.Read(con, tran, Global.ConnectionString, $"SELECT * FROM Inventory_ItemsDetail WITH(NOLOCK) WHERE ItemCode = '{txtItemCode.Text}'");
                dgvItemDetail.Columns["Sno"].Width = 50;
                dgvItemDetail.Columns["ItemCode"].Width = 100;
                dgvItemDetail.Columns["ItemName"].Width = 150;
                dgvItemDetail.Columns["SerialNo"].Width = 150;
                dgvItemDetail.Columns["Qty"].Width = 50;
                dgvItemDetail.Columns["StoreID"].Width = 82;
                MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.Load);
                IsEnable(false);
                dgvItemDetail.Enabled = true;
            };
            frm.ShowDialog();
        }
        private void New()
        {
            isInsert = true; isUpdate = false;
            MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.New);
            ClearControls();
            IsEnable(true);
        }
        private void ClearControls()
        {
            txtItemCode.Text = string.Empty;
            txtItemName.Text = string.Empty;
            txtMaxLev.Text = string.Empty;
            txtMinLev.Text = string.Empty;
            txtReOrdLev.Text = string.Empty;
            txtQty.Text = string.Empty;
            cboBrand.Text = string.Empty;
            cboCat.Text = string.Empty;
            cboSubCat.Text = string.Empty;
            cboSubCat.DataSource = null;
            chkActive.Checked = false;
            chkCanPurchase.Checked = false;
            chkCanSale.Checked = false;
            dgvItemDetail.DataSource = null;
        }
        private void IsEnable(bool cond)
        {
            grpMain.Enabled = cond;
            dgvItemDetail.Enabled = cond;
            // grpDetail.Enabled = cond;
        }

        private void SetCboValues()
        {
            DataTable dtCat = SqlQuery.Read(con, tran, Global.ConnectionString, "select * from Inventory_Category with(nolock)");
            cboCat.DisplayMember = "CatName";
            cboCat.ValueMember = "CatID";
            cboCat.DataSource = dtCat;

            DataTable dtComp = SqlQuery.Read(con, tran, Global.ConnectionString, "select * from Inventory_Company with(nolock)");
            cboBrand.DisplayMember = "CompName";
            cboBrand.ValueMember = "CompCode";
            cboBrand.DataSource = dtComp;
        }

        private bool InsertUpdateValidation()
        {
            if (string.IsNullOrEmpty(txtItemCode.Text.Trim())) { MessageBox.Show(this, "Enter Item Code !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1); return false; }
            if (string.IsNullOrEmpty(txtItemName.Text.Trim())) { MessageBox.Show(this, "Enter Item Name !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1); return false; }
            return true;
        }

        private void CreateDtCol()
        {
            DtItemDetail.Columns.Add("ItemCode", typeof(string));
            DtItemDetail.Columns.Add("ItemName", typeof(string));
            DtItemDetail.Columns.Add("SerialNo", typeof(string));
            DtItemDetail.Columns.Add("CanSale", typeof(bool));
            DtItemDetail.Columns.Add("CanPurchase", typeof(bool));
            DtItemDetail.Columns.Add("Active", typeof(bool));
        }

        #endregion

        private void frmInventoryItems_Load(object sender, EventArgs e)
        {
            SetCboValues();
            MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.Load);
            ClearControls();
            IsEnable(false);
            CreateDtCol();
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
            if (isInsert) { Insert(); }
            if (isUpdate) { Update(); }
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
