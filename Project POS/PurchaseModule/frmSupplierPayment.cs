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
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Project_POS.PurchaseModule
{
    public partial class frmSupplierPayment : Form
    {
        DataTable dtDetail = new DataTable();
        SqlConnection con; SqlTransaction tran;
        bool state = false;
        public frmSupplierPayment()
        {
            InitializeComponent();
            txtPayment.Controls.RemoveAt(0);
            MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.Load);
            state = false;
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
            if (string.IsNullOrEmpty(txtReceiptNo.Text.Trim()))
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


        #region functions

        private void GenerateSerials()
        {
            //dtDetail.Rows.Clear();
            //string itemCode = cboItems.SelectedValue.ToString();
            //string lastTwoWords = GetLastTwoCharacters(itemCode);
            //string lastTwoYearDigits = DateTime.Now.ToString("yy");
            //string lastTwoMonthDigits = DateTime.Now.ToString("MM");
            //Random random = new Random();
            //for (int i = 1; i <= txtQty.Value; i++)
            //{
            //    string randomNumbers = GenerateRandomNumbers(7, random);
            //    string serial = $"{lastTwoWords}-{lastTwoYearDigits}{lastTwoMonthDigits}-{GenerateRandomNumbers(7, random)}";
            //    DataRow row = dtDetail.NewRow();
            //    row["Sno"] = "";
            //    row["ItemCode"] = cboItems.SelectedValue;
            //    row["ItemName"] = txtItemName.Text;
            //    row["SerialNo"] = serial;
            //    row["StoreID"] = cboStore.SelectedValue;
            //    row["StoreName"] = txtStoreName.Text;
            //    row["Qty"] = "1";
            //    row["PPrice"] = txtPPrice.Value;
            //    dtDetail.Rows.Add(row);
            //}
            //dgvDetail.DataSource = null;
            //dgvDetail.DataSource = dtDetail;
            //dgvDetail.ReadOnly = true;
            //SetdgvColumn();
            //UpdateRowCount();
        }

        private void SetdgvColumn()
        {
            dgvDetail.Columns["Sno"].Visible = false;
            dgvDetail.Columns["StoreName"].Visible = false;
            dgvDetail.Columns["TotalPayableAmount"].Visible = false;
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
                using (con = new SqlConnection(Global.ConnectionString))
                {
                    con.Open();
                    SqlTransaction tran = con.BeginTransaction();
                    try
                    {
                        txtReceiptNo.Text = SqlQuery.GetNewTransNo();
                        SqlQuery.Insert(con, tran, "Inventory_SuppliersPayment", Global.ConnectionString, new Dictionary<string, object> { { "ReceiptNo", txtReceiptNo.Text }, { "ReceiptDate", dtpReceiptDate.Value }, { "PaidAmount", txtPayment.Value.ToString() }, { "PayMode", txtPayMode.Text }, { "PBillNo", txtPBillNo.Text }, { "Remarks", txtRemarks.Text }, { "SuppCode", cboSupp.SelectedValue.ToString() }, { "TransDate", DateTime.Now }, { "TransTime", DateTime.Now.ToShortTimeString() }, { "UserId", "001" }});
                        SqlQuery.Insert(con, tran, "TransactionLog", Global.ConnectionString, new Dictionary<string, object> { { "PkeyValue", txtReceiptNo.Text }, { "PTable", "Inventory_SuppliersPayment" }, { "Status", "New" }, { "UserId", "001" }, { "PkeyDate", dtpReceiptDate.Value.Date }, { "Remarks", txtRemarks.Text }, { "TransTime", DateTime.Now.ToShortTimeString() }, { "TransDate", DateTime.Now } });

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
            if (string.IsNullOrEmpty(txtReceiptNo.Text)) { MessageBox.Show(this, "Enter Receipt No !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); return;  }
            if (InsertUpdateValidate())
            {
                using (con = new SqlConnection(Global.ConnectionString))
                {
                    con.Open();
                    tran = con.BeginTransaction();
                    try
                    {
                        SqlQuery.Update(con, tran, Global.ConnectionString, "Inventory_SuppliersPayment", $"WHERE ReceiptNo = '{txtReceiptNo.Text}' ", new Dictionary<string, object> { { "ReceiptNo", txtReceiptNo.Text }, { "ReceiptDate", dtpReceiptDate.Value }, { "PaidAmount", txtPayment.Value.ToString() }, { "PayMode", txtPayMode.Text }, { "PBillNo", txtPBillNo.Text }, { "Remarks", txtRemarks.Text }, { "SuppCode", cboSupp.SelectedValue.ToString() }, { "TransDate", DateTime.Now }, { "TransTime", DateTime.Now.ToShortTimeString() }, { "UserId", "001" } });
                        SqlQuery.Insert(con, tran, "TransactionLog", Global.ConnectionString, new Dictionary<string, object> { { "PkeyValue", txtReceiptNo.Text }, { "PTable", "Inventory_SuppliersPayment" }, { "Status", "Edit" }, { "UserId", "001" }, { "PkeyDate", dtpReceiptDate.Value.Date }, { "Remarks", txtRemarks.Text }, { "TransTime", DateTime.Now.ToShortTimeString() }, { "TransDate", DateTime.Now } });
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
            if (string.IsNullOrEmpty(txtReceiptNo.Text.Trim())) { MessageBox.Show(this, "No Record to Delete !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); return; }
            DialogResult result = MessageBox.Show("Are you sure you want to Delete ?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                using (con = new SqlConnection(Global.ConnectionString))
                {
                    try
                    {
                        con.Open();
                        tran = con.BeginTransaction();
                        SqlQuery.Delete(con, tran, Global.ConnectionString, "Inventory_SuppliersPayment", $" ReceiptNo = '{txtReceiptNo.Text}'");
                        SqlQuery.Insert(con, tran, "TransactionLog", Global.ConnectionString, new Dictionary<string, object> { { "PkeyValue", txtReceiptNo.Text }, { "PTable", "Inventory_SuppliersPayment" }, { "Status", "Delete" }, { "UserId", "001" }, { "PkeyDate", dtpReceiptDate.Value.Date }, { "Remarks", txtRemarks.Text }, { "TransTime", DateTime.Now.ToShortTimeString() }, { "TransDate", DateTime.Now } });
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
            if (string.IsNullOrEmpty(txtReceiptNo.Text.Trim()))
            {
                MessageBox.Show(this, "No Record to Edit !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
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
                MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.Cancel);
                IsEnable(false);
            }
        }
        private void Search()
        {
            SqlConnection con = new SqlConnection(Global.ConnectionString);
            frmLOV frm = new frmLOV();
            frm.SetData(con, Global.ConnectionString, "SELECT * FROM Inventory_SuppliersPayment WITH(NOLOCK)", "ReceiptNo");
            frm.FormClosing += (o, a) =>
            {
                con.Open();
                var frmKey = o as frmLOV;
                string code = frmKey.Code;
                if (string.IsNullOrEmpty(code))
                {
                    return;
                }
                DataTable dtMaster = SqlQuery.Read(con, tran, Global.ConnectionString, $"SELECT * FROM Inventory_SuppliersPayment WITH(NOLOCK) WHERE ReceiptNo = '{code}'");
                if (dtMaster.Rows.Count > 0)
                {
                    DataRow row = dtMaster.Rows[0];
                    txtReceiptNo.Text = row["ReceiptNo"].ToString();
                    dtpReceiptDate.Value = Convert.ToDateTime(row["ReceiptDate"].ToString());
                    cboSupp.SelectedValue = row["SuppCode"];
                    cboPBillNo.SelectedValue = row["PBillNo"];
                    txtRemarks.Text = row["Remarks"].ToString();
                    LoadData(cboPBillNo.SelectedValue.ToString());
                }
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
            txtReceiptNo.Text = string.Empty;
            txtPayment.Text = string.Empty;
            txtPayMode.Text = string.Empty;
            txtPBillNo.Text = string.Empty;
            txtpending.Text = string.Empty;
            txtRemarks.Text = string.Empty;
            txtSupp.Text = string.Empty;
            txtTotalPaid.Text = string.Empty;
            cboPBillNo.SelectedValue = "";
            cboSupp.SelectedValue = "";
            dgvDetail.DataSource = null;
        }

        private void SetCbo()
        {
            DataTable dtSupplier = SqlQuery.Read(con, tran, Global.ConnectionString, "SELECT SuppCode FROM Inventory_Suppliers WITH(NOLOCK)");
            cboSupp.DisplayMember = "SuppCode";
            cboSupp.ValueMember = "SuppCode";
            cboSupp.DataSource = dtSupplier;
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
            txtTotalPaid.Enabled = cond;
            txtSupp.Enabled = cond;
            txtRemarks.Enabled = cond;
            txtPayment.Enabled = cond;
            txtPayMode.Enabled = cond;
            txtPBillNo.Enabled = cond;
            txtpending.Enabled = cond;
            txtReceiptNo.Enabled = cond;
            cboPBillNo.Enabled = cond;
            cboSupp.Enabled = cond;
        }

        private bool InsertUpdateValidate()
        {
            if(dtDetail.Rows.Count == 0)
            {
                MessageBox.Show(this, "Invalid Purchase Data No\nNo Record to Save!", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); return false;
            }

            if (string.IsNullOrEmpty(txtPBillNo.Text))
            {
                MessageBox.Show(this, "Invalid Purchase Bill No\nBill No Could Not be Empty!", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); return false;
            }

            if (dtpBillDate.Value.Date > dtpReceiptDate.Value.Date)
            {
                MessageBox.Show(this, "Invalid Receipt Date \nReceipt Date Should be Equal or smaller than Bill Date !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); return false;
            }
            if(txtPayment.Value > Convert.ToDecimal(txtpending.Text))
            {
                MessageBox.Show(this, "Invalid Payment \nPayment is Not Greater the Pending Amount !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); return false;
            }
            return true;
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

        private void cboSupp_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cboSupp.Text.Trim()))
            {
                txtSupp.Text = SqlQuery.GetSingleValue(con, tran, Global.ConnectionString, $"SELECT SuppName FROM Inventory_Suppliers WITH(NOLOCK) WHERE SuppCode = '{cboSupp.SelectedValue.ToString()}'");
                DataTable dtPurchase = SqlQuery.Read(con, tran, Global.ConnectionString, $"SELECT BillNo FROM Inventory_Purchase WITH(NOLOCK) WHERE SuppCode = '{cboSupp.SelectedValue.ToString()}'");
                cboPBillNo.DisplayMember = "BillNo";
                cboPBillNo.ValueMember = "BillNo";
                cboPBillNo.DataSource = dtPurchase;
                cboPBillNo.Text = string.Empty;
                txtPBillNo.Text = string.Empty;
                txtpending.Text = string.Empty;
                txtTotalPaid.Text = string.Empty;
                txtPayMode.Text = string.Empty;
                dtpBillDate.Value = DateTime.Now;
                dtpReceiptDate.Value = DateTime.Now;
                dgvDetail.DataSource = null;
            }
        }

        private void cboPBillNo_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cboPBillNo.Text.Trim()))
            {
                txtPBillNo.Text = cboPBillNo.SelectedValue.ToString();
                LoadData(txtPBillNo.Text);
            }
        }

        private void LoadData(string BillNo)
        {

            string query = $@"
                        DECLARE @TotalPayableAmount NUMERIC, @PaidAmount NUMERIC, @Pending NUMERIC, @PayMode Varchar(50), @BillDate DateTime;
                        SELECT @TotalPayableAmount = IP.TotalPayableAmount, @PayMode = IP.PaymentTerm, @BillDate = IP.BillDate 
                        FROM Inventory_Purchase IP WITH(NOLOCK) 
                        WHERE BillNo = '{BillNo}';

                        SELECT @PaidAmount = ISNULL(SUM(CONVERT(decimal(18,2), PaidAmount)), 0) 
                        FROM Inventory_SuppliersPayment WITH(NOLOCK) 
                        WHERE PBillNo = '{BillNo}';

                        SET @Pending = @TotalPayableAmount - @PaidAmount;

                        SELECT @PayMode as PayMode, @Pending AS Pending, @PaidAmount AS PaidAmount, @TotalPayableAmount AS TotalPayableAmount, @BillDate as BillDate;
                    ";

            DataTable dtMaster = SqlQuery.Read(con, tran, Global.ConnectionString, query);
            foreach (DataRow dr in dtMaster.Rows)
            {
                txtpending.Text = dr["Pending"].ToString();
                txtTotalPaid.Text = dr["PaidAmount"].ToString();
                txtPayMode.Text = dr["PayMode"].ToString();
                dtpBillDate.Value = Convert.ToDateTime(dr["BillDate"].ToString());
            }
            dtDetail.Rows.Clear();
            dtDetail = SqlQuery.Read(con, tran, Global.ConnectionString, $"SELECT Sno, BillNo, ItemCode, SerialNo, StoreID, PPrice, Qty FROM Inventory_PurchaseDetail WITH(NOLOCK) WHERE BillNo = '{BillNo}'");
            dgvDetail.DataSource = dtDetail;
            ResetDgvColumns();
        }
        private void ResetDgvColumns()
        {
            dgvDetail.Columns["Sno"].Width = 40;
            dgvDetail.Columns["BillNo"].Width = 150;
            dgvDetail.Columns["ItemCode"].Width = 120;
            dgvDetail.Columns["SerialNo"].Width = 160;
            dgvDetail.Columns["StoreID"].Width = 50;
            dgvDetail.Columns["PPrice"].Width = 80;
            dgvDetail.Columns["Qty"].Width = 50;
        }
        private void cboPBillNo_ValueMemberChanged(object sender, EventArgs e)
        {

        }

        

    }
}
