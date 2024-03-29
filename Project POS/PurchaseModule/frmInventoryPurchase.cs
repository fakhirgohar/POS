using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using Project_POS.Classes;
using Project_POS.InventoryModule;
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
    public partial class frmInventoryPurchase : Form
    {
        DataTable dtDetail = new DataTable();
        DataTable dtSupp, dtStore, dtPayMode = null;
        string Supp, Store, PayMode = string.Empty;
        SqlTransaction tran = null;
        SqlConnection con = null;
        public frmInventoryPurchase()
        {
            InitializeComponent();
            AddGridCountColumn();
            MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.Load);
            SetCbo();
        }
        #region functions

        private void GenerateSerials()
        {
            //dtDetail.Rows.Clear();
            string itemCode = cboItems.SelectedValue.ToString();
            string lastTwoWords = GetLastTwoCharacters(itemCode);
            string lastTwoYearDigits = DateTime.Now.ToString("yy");
            string lastTwoMonthDigits = DateTime.Now.ToString("MM");
            Random random = new Random();
            for (int i = 1; i <= txtQty.Value; i++)
            {
                string randomNumbers = GenerateRandomNumbers(7, random);
                string serial = $"{lastTwoWords}-{lastTwoYearDigits}{lastTwoMonthDigits}-{GenerateRandomNumbers(7, random)}";
                DataRow row = dtDetail.NewRow();
                row["Sno"] = "";
                row["ItemCode"] = cboItems.SelectedValue;
                row["ItemName"] = txtItemName.Text;
                row["SerialNo"] = serial;
                row["StoreID"] = txtStoreName.Text;
                row["StoreName"] = txtStoreName.Text;
                row["Qty"] = "1";
                row["PPrice"] = txtPPrice.Value;
                dtDetail.Rows.Add(row);
            }
            dgvDetail.DataSource = null;
            dgvDetail.DataSource = dtDetail;
            dgvDetail.ReadOnly = true;
            SetdgvColumn();
            UpdateRowCount();
        }

        private void SetdgvColumn()
        {
            dgvDetail.Columns["Sno"].Visible = false;
            dgvDetail.Columns["StoreName"].Visible = false;
           // dgvDetail.Columns["TotalPayableAmount"].Visible = false;
            dgvDetail.Columns["ItemCode"].Width = 120;
            dgvDetail.Columns["ItemName"].Width = 120;
            dgvDetail.Columns["SerialNo"].Width = 150;
            dgvDetail.Columns["StoreID"].Width = 120;
            dgvDetail.Columns["PPrice"].Width = 120;
        }

        private string GetLastTwoCharacters(string itemCode)
        {
            if (itemCode.Length >= 2)
            {
                string lastTwoCharacters = itemCode.Substring(itemCode.Length - 2);
                return lastTwoCharacters;
            }
            return itemCode;
        }

        private string GenerateRandomNumbers(int length, Random random)
        {
            const string numbers = "0123456789";
            StringBuilder sb = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                int index = random.Next(numbers.Length);
                sb.Append(numbers[index]);
            }
            return sb.ToString();
        }

        private void Insert()
        {
            if (InsertUpdateValidate())
            {
                txtBillNo.Text = SqlQuery.GetNewTransNo();
                using (con = new SqlConnection(Global.ConnectionString))
                {
                    con.Open();
                    SqlTransaction tran = con.BeginTransaction();
                    try
                    {
                        Decimal TotalPayble = txtSummary.Value;
                        if(PayMode == "Cash")
                        {
                            TotalPayble = 0;
                            SqlQuery.Insert(con, tran, "Inventory_SuppliersPayment", Global.ConnectionString, new Dictionary<string, object> { { "ReceiptNo", txtReceiptNo.Text + SqlQuery.GetNewTransNo() }, { "ReceiptDate", dtpBillDate.Value }, { "PBillNo", txtBillNo.Text }, { "SuppCode", Supp }, { "PaidAmount", txtSummary.Value }, { "Remarks", txtRemarks.Text }, { "PayMode", PayMode }, { "TransDate", DateTime.Now}, { "TransTime", DateTime.Now.ToShortTimeString() }, { "UserId", "001" } });
                            SqlQuery.Insert(con, tran, "TransactionLog", Global.ConnectionString, new Dictionary<string, object> { { "PkeyValue", txtBillNo.Text }, { "PTable", "Inventory_SuppliersPayment" }, { "Status", "New" }, { "UserId", "001" }, { "PkeyDate", dtpBillDate.Value }, { "Remarks", txtRemarks.Text }, { "TransTime", DateTime.Now.ToShortTimeString() }, { "TransDate", DateTime.Now } });
                        }
                        int Sno = 1;
                        SqlQuery.Insert(con, tran, "Inventory_Purchase", Global.ConnectionString, new Dictionary<string, object> { { "BillNo", txtBillNo.Text }, { "ReceiptNo", txtReceiptNo.Text }, { "SuppCode", Supp }, { "Purchaser", txtPurchaser.Text }, { "PayMode", PayMode }, { "BillDate", dtpBillDate.Value.Date }, { "ReceiveDate", dtpReceiveDate.Value.Date }, { "Remarks", txtRemarks.Text }, { "TotalPayableAmount", TotalPayble }, { "BillTransDate", DateTime.Now.Date }, { "BillTransTime", DateTime.Now.TimeOfDay } });

                        foreach (DataRow Row in dtDetail.Rows)
                        {
                            Dictionary<string, object> dicValue = new Dictionary<string, object>();
                            dicValue.Add("BillNO", txtBillNo.Text);
                            dicValue.Add("Sno", Sno);
                            dicValue.Add("ItemCode", Row["ItemCode"]);
                            dicValue.Add("Qty", Row["Qty"]);
                            dicValue.Add("PPrice", Row["PPrice"]);
                            dicValue.Add("SerialNo", Row["SerialNo"]);
                            dicValue.Add("StoreID", Row["StoreID"]);
                            SqlQuery.Insert(con, tran, "Inventory_PurchaseDetail", Global.ConnectionString, dicValue);
                            SqlQuery.Insert(con, tran, "Inventory_ItemsDetail", Global.ConnectionString, new Dictionary<string, object> { { "Sno", Row["Sno"] }, { "ItemCode", Row["ItemCode"] }, { "ItemName", Row["ItemName"] }, { "SerialNo", Row["SerialNo"] }, { "Qty", Row["Qty"] }, { "StoreID", Row["StoreID"] }, });
                            Sno++;
                        }
                        UpdateItems(dtDetail, con, tran);
                        tran.Commit();
                        con.Dispose();
                        MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.Save);
                        MessageBox.Show(this, "Saved Successfully !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
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
        private new void Update()
        {
            if (InsertUpdateValidate())
            {
                using (con = new SqlConnection(Global.ConnectionString))
                {
                    Decimal TotalPayble = txtSummary.Value;
                    if (PayMode == "Cash")
                    {
                        TotalPayble = 0;
                        SqlQuery.Delete(con, tran, Global.ConnectionString, "Inventory_SuppliersPayment", $"PBillNo='{txtBillNo.Text}' AND ReceiptNo = '{txtReceiptNo.Text}'");
                        SqlQuery.Insert(con, tran, "Inventory_SuppliersPayment", Global.ConnectionString, new Dictionary<string, object> { { "ReceiptNo", txtReceiptNo.Text + SqlQuery.GetNewTransNo() }, { "ReceiptDate", dtpBillDate.Value }, { "PBillNo", txtBillNo.Text }, { "SuppCode", Supp }, { "PaidAmount", txtSummary.Value }, { "Remarks", txtRemarks.Text }, { "PayMode", PayMode }, { "TransDate", DateTime.Now }, { "TransTime", DateTime.Now.ToShortTimeString() }, { "UserId", "001" } });
                        SqlQuery.Insert(con, tran, "TransactionLog", Global.ConnectionString, new Dictionary<string, object> { { "PkeyValue", txtBillNo.Text }, { "PTable", "Inventory_SuppliersPayment" }, { "Status", "Edit" }, { "UserId", "001" }, { "PkeyDate", dtpBillDate.Value }, { "Remarks", txtRemarks.Text }, { "TransTime", DateTime.Now.ToShortTimeString() }, { "TransDate", DateTime.Now } });

                    }
                    con.Open();
                    tran = con.BeginTransaction();
                    try
                    {
                        SqlQuery.Update(con, tran, Global.ConnectionString, "Inventory_Purchase", $"WHERE BillNo = '{txtBillNo.Text}' ", new Dictionary<string, object> { { "ReceiptNo", txtReceiptNo.Text }, { "TotalPayableAmount", TotalPayble }, { "SuppCode", Supp }, { "Purchaser", txtPurchaser.Text }, { "PayMode", PayMode }, { "BillDate", dtpBillDate.Value.Date }, { "ReceiveDate", dtpReceiveDate.Value.Date }, { "Remarks", txtRemarks.Text }, { "BillTransDate", DateTime.Now.Date }, { "BillTransTime", DateTime.Now.TimeOfDay } });
                        SqlQuery.Delete(con, tran, Global.ConnectionString, "Inventory_PurchaseDetail", $"BillNo='{txtBillNo.Text}'");

                        foreach (DataRow Row in dtDetail.Rows)
                        {
                            Dictionary<string, object> dicValue = new Dictionary<string, object>();
                            dicValue.Add("Sno", Row["Sno"]);
                            dicValue.Add("BillNo", Row["BillNo"]);
                            dicValue.Add("ItemCode", Row["ItemCode"]);
                            dicValue.Add("Qty", Row["Qty"]);
                            dicValue.Add("PPrice", Row["PPrice"]);
                            dicValue.Add("SerialNo", Row["SerialNo"]);
                            dicValue.Add("StoreID", Row["StoreID"]);
                            SqlQuery.Delete(con, tran, Global.ConnectionString, "Inventory_PurchaseDetail", $"ItemCode='{Row["ItemCode"]}' AND SerialNo='{Row["SerialNo"]}' AND StoreID='{Row["StoreID"]}'");
                            SqlQuery.Insert(con, tran, "Inventory_PurchaseDetail", Global.ConnectionString, dicValue);
                            SqlQuery.Insert(con, tran, "Inventory_ItemsDetail", Global.ConnectionString, new Dictionary<string, object> { { "Sno", Row["Sno"] }, { "ItemCode", Row["ItemCode"] }, { "ItemName", Row["ItemName"] }, { "SerialNo", Row["SerialNo"] }, { "Qty", Row["Qty"] }, { "StoreID", Row["StoreID"] }, });
                        }

                        UpdateItems(dtDetail, con, tran);
                        tran.Commit();
                        con.Dispose();
                        IsEnable(false);
                        MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.Save);
                        MessageBox.Show(this, "Update Successfully !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw new Exception(ex.Message);
                    }
                    finally { if (con.State == ConnectionState.Open) { con.Close(); } }
                }
            }
        }
        private void Delete()
        {
            if (string.IsNullOrEmpty(txtBillNo.Text.Trim())) { MessageBox.Show(this, "No Record to Delete !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); return; }
            DialogResult result = MessageBox.Show("Are you sure you want to Delete ?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                using (con = new SqlConnection(Global.ConnectionString))
                {
                    try
                    {
                        con.Open();
                        tran = con.BeginTransaction();
                        foreach (DataRow Row in dtDetail.Rows)
                        {
                            if (SqlQuery.IsFound(con, tran, Global.ConnectionString, "Inventory_SaleDetail", $"ItemCode = '{Row["ItemCode"]}' AND SerialNo = '{Row["SerialNo"]}' AND StoreID = '{Row["StoreID"]}' "))
                            {
                                MessageBox.Show(this, "Cannot Delete \nThere is Sale Against this Purchase !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); return;
                            }
                        }
                        if(SqlQuery.IsFound(con, tran, Global.ConnectionString, "Inventory_SuppliersPayment", $"PBillNo = '{txtBillNo.Text}' AND PayMode != 'Cash'"))
                        {
                            MessageBox.Show(this, "Cannot Delete \nThis is Credit Purchase and found a Payment !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); return;

                        }
                        SqlQuery.Delete(con, tran, Global.ConnectionString, "Inventory_Purchase", $" BillNo = '{txtBillNo.Text}'");
                        SqlQuery.Delete(con, tran, Global.ConnectionString, "Inventory_SuppliersPayment", $"PBillNo='{txtBillNo.Text}'");
                        SqlQuery.ExecuteNonQuery(con, tran, Global.ConnectionString, $"DELETE FROM Inventory_ItemsDetail WHERE SerialNo IN (SELECT SerialNo FROM Inventory_PurchaseDetail WITH(NOLOCK) WHERE BillNo = '{txtBillNo.Text}')");
                        DeleteItemsDetail(dtDetail, con, tran);
                        UpdateItems(dtDetail, con, tran);
                        tran.Commit();
                        con.Dispose();
                        ClearControls();
                        IsEnable(false);
                        MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.Cancel);
                        MessageBox.Show(this, "Deleted Successfully !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw new Exception(ex.Message);
                    }
                    finally { if (con.State == ConnectionState.Open) { con.Close(); } }
                }
            }
        }
        private void Edit()
        {
            if (string.IsNullOrEmpty(txtBillNo.Text.Trim()))
            {
                MessageBox.Show(this, "No Record to Edit !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }
            MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.Edit);
            IsEnable(true);
            txtPayMode.Enabled = txtPayMode.Text == "Credit" ? false : true;

        }
        private void Cancel()
        {
            DialogResult result = MessageBox.Show("Are you sure you want to Cancel this Transaction?", "Confirm Cancellation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                ClearControls();
                MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.Cancel);
                IsEnable(false);
            }
        }
        private void Search()
        {
            SqlConnection con = new SqlConnection(Global.ConnectionString);
            frmLOV frm = new frmLOV();
            frm.SetData(con, Global.ConnectionString, "SELECT * FROM Inventory_Purchase WITH(NOLOCK)", "BillNo");
            frm.FormClosing += (o, a) =>
            {
                con.Open();
                var frmKey = o as frmLOV;
                string code = frmKey.Code;
                if (string.IsNullOrEmpty(code))
                {
                    return;
                }


                DataTable dtMaster = SqlQuery.Read(con, tran, Global.ConnectionString, $"SELECT * FROM Inventory_Purchase WITH(NOLOCK) WHERE BillNo = '{code}'");
                if (dtMaster.Rows.Count > 0)
                {
                    DataRow row = dtMaster.Rows[0];
                    dtpReceiveDate.Value = Convert.ToDateTime(row["ReceiveDate"]);
                    dtpBillDate.Value = Convert.ToDateTime(row["BillDate"]);
                    txtBillNo.Text = row["BillNo"].ToString();
                    txtReceiptNo.Text = row["ReceiptNo"].ToString();
                    txtPurchaser.Text = row["Purchaser"].ToString();
                    txtPayMode.Text = PayMode = row["PayMode"].ToString();
                    txtSuppName.Text = Supp = row["SuppCode"].ToString();
                   
                    txtRemarks.Text = row["Remarks"].ToString();
                }

                dtDetail.Rows.Clear();
                StringBuilder StrB = new StringBuilder();
                StrB.AppendLine("SELECT IPD.Sno, IPD.ItemCode, II.ItemName, IPD.SerialNo, IPD.Qty, IPD.StoreID, ISS.Name AS StoreName, IPD.PPrice FROM Inventory_PurchaseDetail IPD WITH(NOLOCK)");
                StrB.AppendLine("LEFT JOIN Inventory_Items II WITH(NOLOCK) ON II.ItemCode = IPD.ItemCode ");
                StrB.AppendLine("LEFT JOIN Inventory_Store ISS WITH(NOLOCK) ON ISS.StoreID = IPD.StoreID");
                StrB.AppendLine($"WHERE IPD.BillNo = '{txtBillNo.Text}'");
                dtDetail = SqlQuery.Read(con, tran, Global.ConnectionString, StrB.ToString());
                if (dtDetail.Rows.Count > 0)
                {
                    dtDetail.AcceptChanges();
                    dgvDetail.DataSource = dtDetail;
                    txtSummary.Value = ComputeSummary(dtDetail);
                }
                UpdateRowCount();
                MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.Load);
                IsEnable(false);
            };
            frm.ShowDialog();
        }

        private decimal ComputeSummary(DataTable dt)
        {
            decimal sum = 0;
            foreach (DataRow row in dt.Rows)
            {
                string pPriceString = row["PPrice"].ToString();
                if (!string.IsNullOrEmpty(pPriceString))
                {
                    decimal pPriceNumeric = decimal.Parse(pPriceString);
                    sum += pPriceNumeric;
                }
            }
            return sum;
        }

        private void UpdateItems(DataTable DT, SqlConnection con, SqlTransaction tran)
        {
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

        private void New()
        {
            MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.New);
            ClearControls();
            IsEnable(true);
        }
        private void ClearControls()
        {
            txtBillNo.Text = string.Empty;
            txtPurchaser.Text = string.Empty;
            txtPurchaser.Text = string.Empty;
            txtRemarks.Text = string.Empty;
            txtReceiptNo.Text = string.Empty;
            txtStoreName.Text = Store = string.Empty;
            txtSuppName.Text = Supp = string.Empty;
            txtItemName.Text = string.Empty;
            txtSummary.ResetText();
            ClearDetailTextBox();
            txtPayMode.Text  = PayMode = string.Empty;
            cboItems.Text = string.Empty;
            dtpBillDate.Value = DateTime.Now;
            dtpReceiveDate.Value = DateTime.Now;
            dgvDetail.DataSource = null;
            txtSummary.Focus();
        }

        private void SetCbo()
        {
            DataTable dtItems = SqlQuery.Read(con, tran, Global.ConnectionString, "SELECT ItemCode, ItemName FROM Inventory_Items WITH(NOLOCK)");
            cboItems.DisplayMember = "ItemCode";
            cboItems.ValueMember = "ItemCode";
            cboItems.DataSource = dtItems;
        }

        private void CreatDtDetailColumns()
        {
            dtDetail.Columns.Add("Sno", typeof(string));
            dtDetail.Columns.Add("ItemCode", typeof(string));
            dtDetail.Columns.Add("ItemName", typeof(string));
            dtDetail.Columns.Add("SerialNo", typeof(string));
            dtDetail.Columns.Add("Qty", typeof(string));
            dtDetail.Columns.Add("StoreID", typeof(string));
            dtDetail.Columns.Add("StoreName", typeof(string));
            dtDetail.Columns.Add("PPrice", typeof(string));
            dtDetail.Columns.Add("TotalPayableAmount", typeof(string));
        }

        private void IsEnable(bool cond)
        {
            grpMain.Enabled = cond;
            grpDetail.Enabled = cond;
        }

        private bool InsertUpdateValidate()
        {
            if (string.IsNullOrEmpty(txtReceiptNo.Text)) { MessageBox.Show(this, "Enter Receipt No !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); return false; }
            if (string.IsNullOrEmpty(PayMode)) { MessageBox.Show(this, "Select Payment Mode !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); return false; }
            if (string.IsNullOrEmpty(Supp)) { MessageBox.Show(this, "Select Supplier !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); return false; }
            if (string.IsNullOrEmpty(txtPurchaser.Text)) { MessageBox.Show(this, "Enter Purchaser Name !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); return false; }
            if (dtDetail.Rows.Count == 0) { MessageBox.Show(this, "No Record to save !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); return false; }

            if (dtpReceiveDate.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show(this, "Invalid Recieve Date \nRecive Date Should be Equal or Greater than Current Date !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); return false;
            }
            return true;
        }

        private void ClearDetailTextBox()
        {
            txtQty.Value = 0;
            txtPPrice.Value = 0;
            txtQtyTotal.Value = 0;
            txtQty.ResetText();
            txtPPrice.ResetText();
            txtQtyTotal.ResetText();

        }
        private void RemoveDtRow(string SerialNo)
        {
            for (int i = 0; i < dtDetail.Rows.Count; i++)
            {
                DataRow row = dtDetail.Rows[i];

                if (row["SerialNo"].ToString() == SerialNo)
                {
                    dtDetail.Rows.RemoveAt(i);
                }
            }
            dgvDetail.DataSource = null;
            dgvDetail.DataSource = dtDetail;
            UpdateRowCount();
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
        #endregion
        private void frmInventoryPurchase_Load(object sender, EventArgs e)
        {
            SetCbo();
            MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.Load);
            ClearControls();
            IsEnable(false);
            CreatDtDetailColumns();
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
            if (string.IsNullOrEmpty(txtBillNo.Text))
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cboItems.Text == "")
            {
                MessageBox.Show(this, $"Invalid ItemCode \nSelect an ItemCode !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); return;
            }
            if (string.IsNullOrEmpty(Store))
            {
                MessageBox.Show(this, $"Invalid Store \nSelect a Store !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); return;

            }
            DataTable dtCheck = SqlQuery.Read(con, tran, Global.ConnectionString, $"SELECT CanPurchase FROM Inventory_Items WITH(NOLOCK) WHERE ItemCode = '{cboItems.SelectedValue}'");
            if (Convert.ToBoolean(dtCheck.Rows[0]["CanPurchase"]))
            {
                
                foreach (DataRow Row in dtDetail.Rows)
                {
                    if (Row["ItemCode"] == cboItems.SelectedValue)
                    {
                        if (Convert.ToDecimal(Row["PPrice"]) != txtPPrice.Value)
                        {
                            MessageBox.Show(this, $"Invalid PPrice \nPPrice is Same Against ItemCode '{cboItems.SelectedValue}'\nExact PPrice is '{Row["PPrice"]}'", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); return;
                        }
                    }
                }
                GenerateSerials();


                //bool cond = true;
                //foreach (DataRow Row in dtDetail.Rows)
                //{
                //    if (cboItems.SelectedValue.ToString() == Row["ItemCode"].ToString())
                //    {
                //        if (txtPPrice.Value != Convert.ToDecimal(Row["PPrice"]))
                //        {
                //            txtPPrice.ResetText(); txtQtyTotal.ResetText();
                //            MessageBox.Show(this, $"Invalid PPrice \nExact PPrice is '{Row["PPrice"]}' !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); return;
                //        }
                //        Row["BalQty"] = Convert.ToDecimal(Row["BalQty"]) + txtQty.Value;
                //        Row["Total"] = Convert.ToDecimal(Row["BalQty"]) * Convert.ToDecimal(Row["PPrice"]);
                //        cond = false;
                //    }
                //}
                //if (cond)
                //{
                //    DataRow Row = dtDetail.NewRow();
                //    Row["Sno"] = "0";
                //    Row["ItemCode"] = cboItems.SelectedValue;
                //    Row["ItemName"] = txtItemName.Text;
                //    Row["Qty"] = txtQty.Value.ToString();
                //    Row["PPrice"] = txtPPrice.Value.ToString();
                //    Row["Total"] = txtQtyTotal.Value.ToString();
                //    dtDetail.Rows.Add(Row);
                //}
                //dtDetail.AcceptChanges();
                //dgvDetail.DataSource = dtDetail;
            }
            else
            {
                MessageBox.Show(this, $"The Item '{cboItems.Text}' Cannot Purchase \nCanPurchase Conditon is False !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
            if (dtDetail.Rows.Count > 0) { txtSummary.Value = ComputeSummary(dtDetail); }
            ClearDetailTextBox();
        }

        private void txtQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                txtPPrice.Focus();
            }
            if (e.KeyCode == Keys.Left)
            {
                cboItems.Focus();
            }
            if (e.KeyCode == Keys.Enter)
            {
                txtPPrice.Focus();
                txtQtyTotal.Value = txtQty.Value * txtPPrice.Value;
            }
        }

        private void txtPPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAdd.Focus();
                txtQtyTotal.Value = txtQty.Value * txtPPrice.Value;
            }
            if (e.KeyCode == Keys.Right)
            {
                btnAdd.Focus();
                txtQtyTotal.Value = txtQty.Value * txtPPrice.Value; 
            }
            if (e.KeyCode == Keys.Left)
            {
                txtQty.Focus();
                txtQtyTotal.Value = txtQty.Value * txtPPrice.Value;
            }
        }

        private void txtQty_Leave(object sender, EventArgs e)
        {
            txtQtyTotal.Value = txtQty.Value * txtPPrice.Value;
        }

        private void cboItems_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                txtQty.Focus();
            }
        }

        private void cboItems_SelectedValueChanged(object sender, EventArgs e)
        {
            txtItemName.Text = SqlQuery.GetSingleValue(con, tran, Global.ConnectionString, $"SELECT ItemName FROM Inventory_Items WITH(NOLOCK) WHERE ItemCode = '{cboItems.SelectedValue}'");
        }

        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (dgvDetail.Columns[e.ColumnIndex] == dgvDetail.Columns["btnEd"])
            //{
            //    cboItems.SelectedValue = dgvDetail.Rows[e.RowIndex].Cells["ItemCode"].Value;
            //    txtItemName.Text = dgvDetail.Rows[e.RowIndex].Cells["ItemName"].Value.ToString();
            //    // cboStore.SelectedValue = dgvDetail.Rows[e.RowIndex].Cells["StoreId"].Value;
            //    txtQty.Value = Convert.ToDecimal(dgvDetail.Rows[e.RowIndex].Cells["BalQty"].Value);
            //    txtPPrice.Value = Convert.ToDecimal(dgvDetail.Rows[e.RowIndex].Cells["PPrice"].Value);
            //    txtQtyTotal.Value = Convert.ToDecimal(dgvDetail.Rows[e.RowIndex].Cells["Total"].Value);
            //    RemoveDtRow(dgvDetail.Rows[e.RowIndex].Cells["ItemCode"].Value.ToString());
            //    dgvDetail.DataSource = null;
            //    dgvDetail.DataSource = dtDetail;
            //}
            if (dgvDetail.Columns[e.ColumnIndex] == dgvDetail.Columns["btnDel"])
            {
                RemoveDtRow(dgvDetail.Rows[e.RowIndex].Cells["SerialNo"].Value.ToString());
            }
        }

        private void txtPPrice_Leave(object sender, EventArgs e)
        {
            txtQtyTotal.Value = txtQty.Value * txtPPrice.Value;
        }

        private void txtPayMode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                DataTable dt = SqlQuery.Read(con, tran, Global.ConnectionString, $"SELECT 'Cash' AS TransNo UNION SELECT 'Credit' AS TransNo");
                frmFilter frm = new frmFilter(dt, dtPayMode, true);
                frm.FormClosed += (Obj, key) =>
                {
                    var filter = Obj as frmFilter;
                    dtPayMode = filter.DtFilterdRows.Copy();
                    if (dtPayMode.Rows.Count > 0)
                    {
                        StringBuilder CatCodeBuilder = new StringBuilder();
                        foreach (DataRow row in dtPayMode.Rows)
                        {
                            string transNo = row["TransNo"].ToString();
                            txtPayMode.Text = transNo;
                            PayMode = txtPayMode.Text;
                        }
                    }
                    else
                    {
                        PayMode = txtPayMode.Text = string.Empty;
                    }
                };
                frm.ShowDialog();
            }
        }

        private void txtSuppName_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Down)
            {
                DataTable dt = SqlQuery.Read(con, tran, Global.ConnectionString, $"SELECT SuppCode AS TransNo, SuppName AS Name FROM Inventory_Suppliers WITH(NOLOCK)");
                frmFilter frm = new frmFilter(dt, dtSupp, true);
                frm.FormClosed += (Obj, key) =>
                {
                    var filter = Obj as frmFilter;
                    dtSupp = filter.DtFilterdRows.Copy();
                    if (dtSupp.Rows.Count > 0)
                    {
                        StringBuilder CatCodeBuilder = new StringBuilder();
                        foreach (DataRow row in dtSupp.Rows)
                        {
                            string transNo = row["TransNo"].ToString();
                            txtSuppName.Text = transNo;
                            Supp = txtSuppName.Text;
                        }
                       
                    }
                    else
                    {
                        Supp = txtSuppName.Text = string.Empty;
                    }
                };
                frm.ShowDialog();
            }
        }

        private void txtStoreName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                DataTable dt = SqlQuery.Read(con, tran, Global.ConnectionString, $"SELECT StoreID AS TransNo, Name AS Name FROM Inventory_Store WITH(NOLOCK)");
                frmFilter frm = new frmFilter(dt, dtStore, true);
                frm.FormClosed += (Obj, key) =>
                {
                    var filter = Obj as frmFilter;
                    dtStore = filter.DtFilterdRows.Copy();
                    if (dtStore.Rows.Count > 0)
                    {
                        StringBuilder CatCodeBuilder = new StringBuilder();
                        foreach (DataRow row in dtStore.Rows)
                        {
                            string transNo = row["TransNo"].ToString();
                            txtStoreName.Text = transNo;
                            Store = txtStoreName.Text;
                        }

                    }
                    else
                    {
                        Store = txtStoreName.Text = string.Empty;
                    }
                };
                frm.ShowDialog();
            }
        }
    }
}
