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
    public partial class frmInventorySale : Form
    {
        public frmInventorySale()
        {
            InitializeComponent();
            MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.Load);
            AddGridCountColumn();
        }
        DataTable dtDetail = new DataTable();
        SqlConnection con; SqlTransaction tran;
        bool IsEdit = false;
        #region functions

        private void Insert()
        {
            using (SqlConnection con = new SqlConnection(Global.ConnectionString))
            {
                con.Open();
                SqlTransaction tran = con.BeginTransaction();

                try
                {
                    if (InsertUpdateValidate(dtDetail))
                    {
                        decimal TotalRecievAble = txtSummary.Value;
                        if(cboPayMode.SelectedValue.ToString() == "Cash")
                        {
                            TotalRecievAble = 0;

                        }
                        txtBillNo.Text = SqlQuery.GetNewTransNo();
                        string CustCode = string.IsNullOrEmpty(cboCustomer.Text) ? "1" : cboCustomer.Text;
                        string ReceiptNo = string.IsNullOrEmpty(txtReceiptNo.Text.Trim()) ? txtBillNo.Text : txtReceiptNo.Text;
                        SqlQuery.Insert(con, tran, "Inventory_Sale", Global.ConnectionString, new Dictionary<string, object> { { "BillNo", txtBillNo.Text }, { "BillDate", dtpBillDate.Value.ToShortDateString() }, { "ReceiptNo", ReceiptNo }, { "PayMode", cboPayMode.SelectedValue.ToString() }, { "CustCode", CustCode }, { "Advance", "" }, { "TotalReceiveAble", TotalRecievAble }, { "Remarks", txtRemarks.Text }, { "TransDate", DateTime.Now.ToShortDateString() }, { "TransTime", DateTime.Now.TimeOfDay } });
                        int Sno = 1;
                        foreach (DataRow Row in dtDetail.Rows)
                        {
                            decimal Qty = Convert.ToDecimal(SqlQuery.GetSingleValue(con, tran, Global.ConnectionString, $"SELECT BalQty FROM Inventory_Items WITH(NOLOCK) WHERE ItemCode = '{Row["ItemCode"]}'"));

                            if (Qty <= 0)
                            {
                                MessageBox.Show(this, "ItemCode does not exist in Stock!", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                                return;
                            }

                            Dictionary<string, object> dicValue = new Dictionary<string, object>();
                            dicValue.Add("BillNO", txtBillNo.Text);
                            dicValue.Add("Sno", Sno);
                            dicValue.Add("ItemCode", Row["ItemCode"]);
                            dicValue.Add("SerialNo", Row["SerialNo"]);
                            dicValue.Add("Qty", Row["Qty"]);
                            dicValue.Add("SPrice", Row["SPrice"]);
                            dicValue.Add("PPrice", Row["PPrice"]);
                            dicValue.Add("StoreID", Row["StoreID"]);
                            SqlQuery.Insert(con, tran, "Inventory_SaleDetail", Global.ConnectionString, dicValue);

                            Sno++;
                        }
                        DeleteItemsDetail(dtDetail, con, tran);
                        UpdateItems(dtDetail, con, tran);
                        tran.Commit();
                        con.Dispose();
                        MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.Save);
                        IsEnable(false);
                        MessageBox.Show(this, "Saved Successfully!", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
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
        private new void Update()
        {
            using (con = new SqlConnection(Global.ConnectionString))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    if (InsertUpdateValidate(dtDetail))
                    {
                        decimal TotalRecievAble = txtSummary.Value;
                        if (cboPayMode.SelectedValue.ToString() == "Cash")
                        {
                            TotalRecievAble = 0;

                        }
                        string ReceiptNo = string.IsNullOrEmpty(txtReceiptNo.Text.Trim()) ? txtBillNo.Text : txtReceiptNo.Text;
                        SqlQuery.Update(con, tran, Global.ConnectionString, "Inventory_Sale", $"WHERE BillNo = '{txtBillNo.Text}' ", new Dictionary<string, object> { { "BillDate", dtpBillDate.Value.ToShortDateString() }, { "ReceiptNo", ReceiptNo }, { "PayMode", cboPayMode.SelectedValue.ToString() }, { "CustCode", "" }, { "Advance", "" }, { "TotalReceiveAble", TotalRecievAble }, { "Remarks", txtRemarks.Text }, { "TransDate", DateTime.Now.ToShortDateString() }, { "TransTime", DateTime.Now.TimeOfDay } });

                        SqlQuery.Delete(con, tran, Global.ConnectionString, "Inventory_SaleDetail", $"BillNo='{txtBillNo.Text}'");
                        InsertItemDetail(dtDetail, con, tran);


                        foreach (DataRow Row in dtDetail.Rows)
                        {
                            decimal Qty = Convert.ToDecimal(SqlQuery.GetSingleValue(con, tran, Global.ConnectionString, $"SELECT BalQty FROM Inventory_Items WITH(NOLOCK) WHERE ItemCode = '{Row["ItemCode"]}'"));

                            if (Qty <= 0)
                            {
                                MessageBox.Show(this, "ItemCode does not exist in Stock!", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                                return;
                            }

                            Dictionary<string, object> dicValue = new Dictionary<string, object>();
                            dicValue.Add("BillNO", txtBillNo.Text);
                            dicValue.Add("Sno", Row["Sno"]);
                            dicValue.Add("ItemCode", Row["ItemCode"]);
                            dicValue.Add("SerialNo", Row["SerialNo"]);
                            dicValue.Add("Qty", Row["Qty"]);
                            dicValue.Add("SPrice", Row["SPrice"]);
                            dicValue.Add("PPrice", Row["PPrice"]);
                            dicValue.Add("StoreID", Row["StoreID"]);
                            SqlQuery.Insert(con, tran, "Inventory_SaleDetail", Global.ConnectionString, dicValue);
                        }
                        DeleteItemsDetail(dtDetail, con, tran);
                        UpdateItems(dtDetail, con, tran);
                        tran.Commit();
                        con.Dispose();
                        MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.Save);
                        MessageBox.Show(this, "Update Successfully !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        IsEnable(false);
                    }
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw new Exception(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }


        }
        private void Delete()
        {
            if (string.IsNullOrEmpty(txtBillNo.Text.Trim())) { MessageBox.Show(this, "No Record to Delete !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1); return; }
            else if (SqlQuery.IsFound(con, tran, Global.ConnectionString, "Inventory_SaleReturn", $"BillNo = '{txtBillNo.Text}'"))
            {
                MessageBox.Show(this, $"Cannot Delete \nSale Return Posted Against this BillNo = '{txtBillNo.Text}' !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1); return;
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
                        DataTable DT = SqlQuery.Read(con, tran, Global.ConnectionString, $"SELECT Sno, ISD.ItemCode, II.ItemName, SerialNo, Qty, StoreId FROM Inventory_SaleDetail ISD WITH(NOLOCK) LEFT JOIN Inventory_Items II WITH(NOLOCK) ON II.ItemCode = ISD.ItemCode WHERE BillNo = '{txtBillNo.Text}'");
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.Connection = con;
                            cmd.Transaction = tran;
                            cmd.CommandText = $"DELETE FROM Inventory_Sale WHERE BillNo = '{txtBillNo.Text}'";
                            cmd.ExecuteNonQuery();
                        }
                        InsertItemDetail(DT, con, tran);
                        tran.Commit();
                        MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.Cancel);
                        ClearControls();
                        ClearDetailTextBox();
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
                        con.Close();
                    }
                }
            }
        }



        private void Edit()
        {
            if (string.IsNullOrEmpty(txtBillNo.Text.Trim()))
            {
                MessageBox.Show(this, "No Record to Edit !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            IsEdit = true;
            MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.Edit);
            IsEnable(true);
        }
        private void Cancel()
        {
            DialogResult result = MessageBox.Show("Are you sure you want to Cancel this Transaction?", "Confirm Cancellation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                ClearControls();
                ClearDetailTextBox();
                MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.Cancel);
                IsEnable(false);
            }
        }
        private void Search()
        {
            SqlConnection con = new SqlConnection(Global.ConnectionString);
            frmLOV frm = new frmLOV();
            frm.SetData(con, Global.ConnectionString, "Inventory_Sale", "BillNo", new List<string> { "BillNo", "BillDate", "ReceiptNo", "Remarks" });
            frm.FormClosing += (o, a) =>
            {
                con.Open();
                var frmkey = o as frmLOV;
                string code = frmkey.Code;
                if (string.IsNullOrEmpty(code))
                {
                    return;
                }
                dtDetail.Rows.Clear();
                DataTable dtMaster = SqlQuery.Read(con, tran, Global.ConnectionString, $"SELECT * FROM Inventory_Sale WITH(NOLOCK) WHERE BillNo = '{code}'");
                dtDetail = SqlQuery.Read(con, tran, Global.ConnectionString, $"SELECT ISD.Sno, ISD.ItemCode, II.ItemName, ISD.SerialNo, ISD.Qty, ISD.Sprice, ISD.PPrice, ISD.StoreId FROM Inventory_SaleDetail ISD WITH(NOLOCK) LEFT JOIN Inventory_Items II WITH(NOLOCK) ON II.ItemCode = ISD.ItemCode  WHERE ISD.BillNo = '{code}'");

                if (dtMaster.Rows.Count > 0)
                {
                    DataRow row = dtMaster.Rows[0];
                    dtpBillDate.Value = Convert.ToDateTime(row["BillDate"]);
                    txtBillNo.Text = row["BillNo"].ToString();
                    txtReceiptNo.Text = row["ReceiptNo"].ToString();
                    cboPayMode.Text = row["PayMode"].ToString();
                    txtRemarks.Text = row["Remarks"].ToString();
                    cboCustomer.SelectedValue = row["CustCode"].ToString();
                }

                if (dtDetail.Rows.Count > 0)
                {
                    dtDetail.AcceptChanges();
                    dgvDetail.DataSource = dtDetail;
                    ResetDgvColumnSize();
                    UpdateRowCount();
                }
                UpdateRowCount();
                MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.Load);
                IsEnable(false);
            };
            frm.ShowDialog();
        }
        private void New()
        {
            MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.New);
            ClearControls();
            ClearDetailTextBox();
            IsEnable(true);
            IsEdit = false;
        }
        private void ClearControls()
        {
            txtBillNo.Text = string.Empty;
            txtCustName.Text = string.Empty;
            txtCustName.Text = string.Empty;
            txtRemarks.Text = string.Empty;
            txtReceiptNo.Text = string.Empty;
            txtItemName.Text = string.Empty;

            cboCustomer.Text = string.Empty;
            cboPayMode.Text = string.Empty;
            cboItems.Text = string.Empty;

            dtpBillDate.Value = DateTime.Now;


            dtDetail.Rows.Clear();
            dgvDetail.DataSource = dtDetail;

            txtSummary.Focus();
        }

        private void SetCbo()
        {
            DataTable dtItems = SqlQuery.Read(con, tran, Global.ConnectionString, "SELECT DISTINCT ItemCode FROM Inventory_ItemsDetail WITH(NOLOCK)");
            cboItems.DisplayMember = "ItemCode";
            cboItems.ValueMember = "ItemCode";
            cboItems.DataSource = dtItems;

            DataTable dtCustomer = SqlQuery.Read(con, tran, Global.ConnectionString, "SELECT CustCode FROM Inventory_Customer WITH(NOLOCK)");
            cboCustomer.DisplayMember = "CustCode";
            cboCustomer.ValueMember = "CustCode";
            cboCustomer.DataSource = dtCustomer;
        }

        private void IsEnable(bool cond)
        {
            grpMain.Enabled = cond;
            grpDetail.Enabled = cond;

        }

        private bool InsertUpdateValidate(DataTable dt)
        {
            //if (string.IsNullOrEmpty(txtReceiptNo.Text)) { MessageBox.Show(this, "Enter Receipt No !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1); return false; }
            if (string.IsNullOrEmpty(txtCustName.Text)) { MessageBox.Show(this, "Select Customer !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1); return false; }
            foreach (DataRow Row in dt.Rows)
            {
                string Query = $"SELECT IP.ReceiveDate, IP.BillDate FROM Inventory_Purchase IP WITH(NOLOCK) LEFT JOIN Inventory_PurchaseDetail IPD WITH(NOLOCK) ON IP.BillNo = IPD.BillNo WHERE IPD.SerialNo = '{Row["SerialNo"]}' AND ItemCode = '{Row["ItemCode"]}'";
                DataTable DtTemp = SqlQuery.Read(con, tran, Global.ConnectionString, Query);
                if (dtpBillDate.Value < Convert.ToDateTime(DtTemp.Rows[0]["ReceiveDate"].ToString()))
                {
                    MessageBox.Show(this, "Invalid Bill Date !\nBill Date should be Greater than Receive Date", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1); return false;
                }
                if (dtpBillDate.Value < Convert.ToDateTime(DtTemp.Rows[0]["BillDate"].ToString()))
                {
                    MessageBox.Show(this, "Invalid Bill Date !\nBill Date should be Greater than Purchase Bill Date", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1); return false;
                }
            }
            return true;
        }

        private void ResetDgvColumnSize()
        {
            dgvDetail.Columns["Sno"].Visible = false;
            dgvDetail.Columns["ItemCode"].Width = 150;
            dgvDetail.Columns["ItemName"].Width = 200;
            dgvDetail.Columns["SerialNo"].Width = 200;
            dgvDetail.Columns["Qty"].Width = 50;
            dgvDetail.Columns["StoreID"].Width = 50;
            dgvDetail.Columns["SPrice"].Width = 100;
            dgvDetail.Columns["PPrice"].Width = 100;
        }


        private void UpdateItems(DataTable DT, SqlConnection con, SqlTransaction tran)
        {
            if (con.State == ConnectionState.Closed) { con = new SqlConnection(Global.ConnectionString); con.Open(); }
            DataTable distinctTable = DT.DefaultView.ToTable(true, "ItemCode");
            if (distinctTable.Rows.Count > 0)
            {
                foreach (DataRow Row in distinctTable.Rows)
                {
                    string BalQty = SqlQuery.GetSingleValue(con, tran, Global.ConnectionString, $"SELECT COUNT(*) AS BalQty FROM (Select * from Inventory_ItemsDetail with(nolock) where ItemCode = '{Row["ItemCode"]}') AS subquery;");
                    SqlQuery.Update(con, tran, Global.ConnectionString, "Inventory_Items", $"Where ItemCode = '{Row["ItemCode"]}'", new Dictionary<string, object> { { "BalQty", BalQty } });
                }
            }
        }
        private void InsertItemDetail(DataTable DTItemDetail, SqlConnection con, SqlTransaction tran)
        {
            foreach (DataRow Row in DTItemDetail.Rows)
            {
                Dictionary<string, object> dicValue = new Dictionary<string, object>();
                dicValue.Add("Sno", Row["Sno"]);
                dicValue.Add("ItemCode", Row["ItemCode"]);
                dicValue.Add("ItemName", Row["ItemName"]);
                dicValue.Add("Qty", Row["Qty"]);
                dicValue.Add("SerialNo", Row["SerialNo"]);
                dicValue.Add("StoreID", Row["StoreID"]);
                SqlQuery.Insert(con, tran, "Inventory_ItemsDetail", Global.ConnectionString, dicValue);
            }
            UpdateItems(DTItemDetail, con, tran);
        }

        private void DeleteItemsDetail(DataTable DT, SqlConnection con, SqlTransaction tran)
        {

            if (con.State == ConnectionState.Closed) { con = new SqlConnection(Global.ConnectionString); con.Open(); }
            List<string> deleteConditions = new List<string>();
            foreach (DataRow Row in DT.Rows)
            {
                string condition = $"ItemCode = '{Row["ItemCode"]}' AND SerialNo = '{Row["SerialNo"]}' AND StoreID = '{Row["StoreID"]}'";
                deleteConditions.Add(condition);
            }
            try
            {
                foreach (string condition in deleteConditions)
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.Transaction = tran;
                        cmd.CommandText = $"DELETE FROM Inventory_ItemsDetail WHERE {condition}";
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        private void UpdateSum()
        {
            decimal sum = 0;
            foreach (DataGridViewRow row in dgvDetail.Rows)
            {
                if (row.Cells["SPrice"].Value != null && decimal.TryParse(row.Cells["SPrice"].Value.ToString(), out decimal salePrice))
                {
                    sum += salePrice;
                }
            }
            txtSummary.Value = sum;
        }

        private void AddGridCountColumn()
        {
            var countColumn = new DataGridViewTextBoxColumn();
            countColumn.HeaderText = "#";
            countColumn.ReadOnly = true;
            countColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgvDetail.Columns.Insert(0, countColumn);
        }
        private void UpdateRowCount()
        {
            if (dgvDetail.Rows.Count > 0)
            {
                for (int i = 0; i < dgvDetail.Rows.Count; i++)
                {
                    dgvDetail.Rows[i].Cells[0].Value = (i + 1).ToString();
                }
            }
        }
        private void ClearDetailTextBox()
        {
            txtQty.Value = 0;
            txtSummary.Value = 0;
            txtQty.ResetText();
            txtSummary.ResetText();
            cboItems.Text = string.Empty;
            txtItemName.Text = string.Empty;
        }
        private void RemoveDtRow(string ItemCode)
        {
            for (int i = 0; i < dtDetail.Rows.Count; i++)
            {
                DataRow row = dtDetail.Rows[i];

                if (row["ItemCode"].ToString() == ItemCode)
                {
                    dtDetail.Rows.RemoveAt(i);
                }
            }
            dgvDetail.DataSource = null;
            dgvDetail.DataSource = dtDetail;
        }
        #endregion
        private void frmInventorySale_Load(object sender, EventArgs e)
        {
            MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.Load);
            IsEnable(false);
            SetCbo();
            ClearControls();
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
            if (string.IsNullOrEmpty(txtBillNo.Text.Trim()))
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

        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetail.Columns[e.ColumnIndex] == dgvDetail.Columns["btnEd"])
            {
                cboItems.SelectedValue = dgvDetail.Rows[e.RowIndex].Cells["ItemCode"].Value;
                txtItemName.Text = dgvDetail.Rows[e.RowIndex].Cells["ItemName"].Value.ToString();
                txtQty.Value = Convert.ToDecimal(dgvDetail.Rows[e.RowIndex].Cells["SPrice"].Value);
                RemoveDtRow(dgvDetail.Rows[e.RowIndex].Cells["ItemCode"].Value.ToString());
                dgvDetail.DataSource = null;
                dgvDetail.DataSource = dtDetail;
            }
            if (dgvDetail.Columns[e.ColumnIndex] == dgvDetail.Columns["btnDel"])
            {
                if (!IsEdit)
                {
                    RemoveDtRow(dgvDetail.Rows[e.RowIndex].Cells["ItemCode"].Value.ToString());
                }
            }
        }

        private void txtSerial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                frmAddSerial frm = new frmAddSerial(ItemCode: cboItems.SelectedValue.ToString(), dtDetail);
                frm.ShowDialog();


                if (frm.dtTemp.Rows.Count > 0)
                {
                    dtDetail.Clear();
                    dtDetail = frm.dtFinalResult.Copy();
                }
                if (dtDetail.Rows.Count > 0)
                {
                    dgvDetail.DataSource = null;
                    dgvDetail.DataSource = dtDetail;
                    UpdateSum();
                    ResetDgvColumnSize();
                }
                UpdateRowCount();
            }
        }

        private void cboCustomer_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboCustomer.SelectedValue != null)
            {
                txtCustName.Text = SqlQuery.GetSingleValue(con, tran, Global.ConnectionString, $"SELECT CustName FROM Inventory_Customer WITH(NOLOCK) WHERE CustCode = '{cboCustomer.SelectedValue.ToString()}'");
            }
        }

        private void cboItems_SelectedValueChanged(object sender, EventArgs e)
        {
             if(cboItems.SelectedValue != null)
            {
                DataTable dt = SqlQuery.Read(con, tran, Global.ConnectionString, $"SELECT ItemName, BalQty FROM Inventory_Items WITH(NOLOCK) WHERE ItemCode = '{cboItems.SelectedValue.ToString()}'");
                txtItemName.Text = dt.Rows[0]["ItemName"].ToString();
                txtQty.Value = Convert.ToDecimal(dt.Rows[0]["BalQty"].ToString());
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
    }
}
