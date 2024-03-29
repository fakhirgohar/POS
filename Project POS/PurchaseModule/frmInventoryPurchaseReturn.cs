using Project_POS.Classes;
using Project_POS.InventoryModule;
using Project_POS.SaleModule;
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
    public partial class frmInventoryPurchaseReturn : Form
    {
        DataTable dtDetail = new DataTable();
        SqlConnection CON; SqlTransaction TRAN;
        DataTable dtSupp, dtPayMode = null; string Supp, PayMode = string.Empty;
        public frmInventoryPurchaseReturn()
        {
            InitializeComponent();
            AddGridCountColumn();
        }
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

                        txtBillNo.Text = SqlQuery.GetNewTransNo();
                        string ReceiptNo = string.IsNullOrEmpty(txtReceiptNo.Text.Trim()) ? txtBillNo.Text : txtReceiptNo.Text;
                        SqlQuery.Insert(con, tran, "Inventory_PurchaseReturn", Global.ConnectionString, new Dictionary<string, object> { { "BillNo", txtBillNo.Text }, { "BillDate", dtpBillDate.Value.ToShortDateString() }, { "ReceiptNo", ReceiptNo }, { "ReceiptDate", dtpReceiptDate.Value.ToShortDateString() }, { "SuppCode", Supp }, { "Remarks", txtRemarks.Text }, { "TransDate", DateTime.Now.ToShortDateString() }, { "TransTime", DateTime.Now.ToLongTimeString() } });
                        int Sno = 1;
                        foreach (DataRow Row in dtDetail.Rows)
                        {
                            decimal Qty = Convert.ToDecimal(SqlQuery.GetSingleValue(con, tran, Global.ConnectionString, $"SELECT BalQty FROM Inventory_Items WITH(NOLOCK) WHERE ItemCode = '{Row["ItemCode"]}'"));

                            if (Qty <= 0)
                            {
                                MessageBox.Show(this, "ItemCode does not exist in Stock!", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                                return;
                            }

                            Dictionary<string, object> dicValue = new Dictionary<string, object>();
                            dicValue.Add("BillNO", txtBillNo.Text);
                            dicValue.Add("Sno", Sno);
                            dicValue.Add("ItemCode", Row["ItemCode"]);
                            dicValue.Add("SerialNo", Row["SerialNo"]);
                            dicValue.Add("Qty", Row["Qty"]);
                            dicValue.Add("PPrice", Row["PPrice"]);
                            dicValue.Add("StoreID", Row["StoreID"]);
                            SqlQuery.Insert(con, tran, "Inventory_PurchaseReturnDetail", Global.ConnectionString, dicValue);

                            Sno++;
                        }
                        DeleteItemsDetail(dtDetail, con, tran);
                        UpdateItems(dtDetail, con, tran);
                        tran.Commit();
                        con.Dispose();
                        MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.Save);
                        IsEnable(false);
                        MessageBox.Show(this, "Saved Successfully!", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
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
            using (CON = new SqlConnection(Global.ConnectionString))
            {
                CON.Open();
                TRAN = CON.BeginTransaction();
                try
                {
                    if (InsertUpdateValidate(dtDetail))
                    {
                        string ReceiptNo = string.IsNullOrEmpty(txtReceiptNo.Text.Trim()) ? txtBillNo.Text : txtReceiptNo.Text;
                        SqlQuery.Update(CON, TRAN, Global.ConnectionString, "Inventory_PurchaseReturn", $"WHERE BillNo = '{txtBillNo.Text}' ", new Dictionary<string, object> { { "BillDate", dtpBillDate.Value.ToShortDateString() }, { "ReceiptNo", ReceiptNo }, { "ReceiptDate", dtpReceiptDate.Value.ToShortDateString() }, { "SuppCode", Supp }, { "Remarks", txtRemarks.Text }, { "TransDate", DateTime.Now.ToShortDateString() }, { "TransTime", DateTime.Now.ToLongTimeString() } });
                        SqlQuery.Delete(CON, TRAN, Global.ConnectionString, "Inventory_PurchaseReturnDetail", $"BillNo='{txtBillNo.Text}'");
                        InsertItemDetail(dtDetail, CON, TRAN);

                        foreach (DataRow Row in dtDetail.Rows)
                        {
                            decimal Qty = Convert.ToDecimal(SqlQuery.GetSingleValue(CON, TRAN, Global.ConnectionString, $"SELECT BalQty FROM Inventory_Items WITH(NOLOCK) WHERE ItemCode = '{Row["ItemCode"]}'"));

                            if (Qty <= 0)
                            {
                                MessageBox.Show(this, "ItemCode does not exist in Stock!", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                                return;
                            }

                            Dictionary<string, object> dicValue = new Dictionary<string, object>();
                            dicValue.Add("BillNO", txtBillNo.Text);
                            dicValue.Add("Sno", Row["Sno"]);
                            dicValue.Add("ItemCode", Row["ItemCode"]);
                            dicValue.Add("SerialNo", Row["SerialNo"]);
                            dicValue.Add("Qty", Row["Qty"]);
                            dicValue.Add("PPrice", Row["PPrice"]);
                            dicValue.Add("StoreID", Row["StoreID"]);
                            SqlQuery.Insert(CON, TRAN, "Inventory_PurchaseReturnDetail", Global.ConnectionString, dicValue);
                        }
                        DeleteItemsDetail(dtDetail, CON, TRAN);
                        UpdateItems(dtDetail, CON, TRAN);
                        TRAN.Commit();
                        CON.Dispose();
                        MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.Save);
                        MessageBox.Show(this, "Update Successfully !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        IsEnable(false);
                    }
                }
                catch (Exception ex)
                {
                    TRAN.Rollback();
                    throw new Exception(ex.Message);
                }
                finally
                {
                    CON.Close();
                }
            }


        }
        private void Delete()
        {
            if (string.IsNullOrEmpty(txtBillNo.Text.Trim())) { MessageBox.Show(this, "No Record to Delete !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); return; }

            DialogResult result = MessageBox.Show("Are you sure you want to Delete ?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                using (CON = new SqlConnection(Global.ConnectionString))
                {
                    CON.Open();
                    TRAN = CON.BeginTransaction();
                    try
                    {
                        DataTable DT = SqlQuery.Read(CON, TRAN, Global.ConnectionString, $"SELECT IPRD.Sno, IPRD.ItemCode, II.ItemName, IPRD.SerialNo, IPRD.Qty, IPRD.PPrice, IPRD.StoreId FROM Inventory_PurchaseReturnDetail IPRD WITH(NOLOCK) LEFT JOIN Inventory_Items II WITH(NOLOCK) ON II.ItemCode = IPRD.ItemCode  WHERE IPRD.BillNo = '{txtBillNo.Text}'");

                        //using (SqlCommand cmd = new SqlCommand())
                        //{
                        //    cmd.Connection = CON;
                        //    cmd.Transaction = CON;
                        //    cmd.CommandText = $"DELETE FROM Inventory_Sale WHERE BillNo = '{txtBillNo.Text}'";
                        //    cmd.ExecuteNonQuery();
                        //}

                        SqlQuery.Delete(CON, TRAN, Global.ConnectionString, "Inventory_PurchaseReturn", $"BillNo = '{txtBillNo.Text}'");
                        InsertItemDetail(DT, CON, TRAN);
                        TRAN.Commit();
                        MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.Cancel);
                        ClearControls();
                        MessageBox.Show(this, "Deleted Successfully !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        IsEnable(false);
                    }
                    catch (Exception ex)
                    {
                        TRAN.Rollback();
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        CON.Close();
                    }
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
            CON = new SqlConnection(Global.ConnectionString);
            frmLOV frm = new frmLOV();
            frm.SetData(CON, Global.ConnectionString, "Inventory_PurchaseReturn", "BillNo", new List<string> { "BillNo", "BillDate", "ReceiptNo", "Remarks" });
            frm.FormClosing += (o, a) =>
            {
                CON.Open();
                var frmkey = o as frmLOV;
                string code = frmkey.Code;
                if (string.IsNullOrEmpty(code))
                {
                    return;
                }
                dtDetail.Rows.Clear();
                DataTable dtMaster = SqlQuery.Read(CON, TRAN, Global.ConnectionString, $"SELECT * FROM Inventory_PurchaseReturn WITH(NOLOCK) WHERE BillNo = '{code}'");
                dtDetail = SqlQuery.Read(CON, TRAN, Global.ConnectionString, $"SELECT IPRD.Sno, IPRD.ItemCode, II.ItemName, IPRD.SerialNo, IPRD.Qty, IPRD.PPrice, IPRD.StoreId FROM Inventory_PurchaseReturnDetail IPRD WITH(NOLOCK) LEFT JOIN Inventory_Items II WITH(NOLOCK) ON II.ItemCode = IPRD.ItemCode  WHERE IPRD.BillNo = '{code}'");

                if (dtMaster.Rows.Count > 0)
                {
                    DataRow row = dtMaster.Rows[0];
                    dtpBillDate.Value = Convert.ToDateTime(row["BillDate"]);
                    dtpReceiptDate.Value = Convert.ToDateTime(row["ReceiptDate"]);
                    txtBillNo.Text = row["BillNo"].ToString();
                    txtReceiptNo.Text = row["ReceiptNo"].ToString();
                    txtRemarks.Text = row["Remarks"].ToString();
                    txtPayMode.Text = PayMode = row["PayMode"].ToString();
                    txtSuppName.Text = Supp = row["SuppCode"].ToString();
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
            IsEnable(true);
        }
        private void ClearControls()
        {
            txtBillNo.Text = string.Empty;
            txtReceiptNo.Text = string.Empty;
            txtSuppName.Text = Supp = string.Empty;
            txtPayMode.Text = PayMode = string.Empty;
            txtReceiptNo.Text = string.Empty;
            txtRemarks.Text = string.Empty;
            dtpBillDate.Value = DateTime.Now;
            dtpReceiptDate.Value = DateTime.Now;
            ClearDetailControlS();
        }

        private void ClearDetailControlS()
        {
            cboItemCode.Text = string.Empty;
            txtItemName.Text = string.Empty;
            txtPPrice.Text = string.Empty;
            txtQty.Text = string.Empty;
            txtSerialNo.Text = string.Empty;
            dgvDetail.DataSource = null;
            dtDetail.Rows.Clear();
        }

        private void SetCbo()
        {


            DataTable dtItemCode = SqlQuery.Read(Global.Con, Global.tran, Global.ConnectionString, "SELECT Distinct ItemCode FROM Inventory_ItemsDetail WITH(NOLOCK)");
            cboItemCode.DisplayMember = "ItemCode";
            cboItemCode.ValueMember = "ItemCode";
            cboItemCode.DataSource = dtItemCode;

        }

        private void IsEnable(bool cond)
        {
            grpMain.Enabled = cond;
            grpDetail.Enabled = cond;

        }

        private bool InsertUpdateValidate(DataTable dt)
        {
            if (string.IsNullOrEmpty(Supp)) { MessageBox.Show(this, "Select Supplier !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); return false; }

            if (string.IsNullOrEmpty(PayMode)) { MessageBox.Show(this, "Cannot Post Purchase Return !\nSelect a Payment Mode first !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); return false; }

            if (dt.Rows.Count == 0) { MessageBox.Show(this, "Cannot Post Purchase Return !\nNo Detail Record Against Transaction", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); return false; }
           
            foreach (DataRow Row in dt.Rows)
            {
                string Query = $"SELECT IP.ReceiveDate, IP.BillDate FROM Inventory_Purchase IP WITH(NOLOCK) LEFT JOIN Inventory_PurchaseDetail IPD WITH(NOLOCK) ON IP.BillNo = IPD.BillNo WHERE IPD.SerialNo = '{Row["SerialNo"]}' AND ItemCode = '{Row["ItemCode"]}'";
                DataTable DtTemp = SqlQuery.Read(Global.Con, Global.tran, Global.ConnectionString, Query);
                if (dtpBillDate.Value < Convert.ToDateTime(DtTemp.Rows[0]["ReceiveDate"].ToString()))
                {
                    MessageBox.Show(this, "Invalid Bill Date !\nBill Date should be Greater than Receive Date", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); return false;
                }
                if (dtpBillDate.Value < Convert.ToDateTime(DtTemp.Rows[0]["BillDate"].ToString()))
                {
                    MessageBox.Show(this, "Invalid Bill Date !\nBill Date should be Greater than Purchase Bill Date", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); return false;
                }
            }
            return true;
        }

        private void ResetDgvColumnSize()
        {
            dgvDetail.Columns["Sno"].Visible = false;
            dgvDetail.Columns["ItemCode"].Width = 230;
            dgvDetail.Columns["ItemName"].Width = 250;
            dgvDetail.Columns["SerialNo"].Width = 250;
            dgvDetail.Columns["Qty"].Width = 80;
            dgvDetail.Columns["StoreID"].Width = 80;
            // dgvDetail.Columns["SPrice"].Width = 140;
            dgvDetail.Columns["PPrice"].Width = 150;
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
            //decimal sum = 0;
            //foreach (DataGridViewRow row in dgvDetail.Rows)
            //{
            //    if (row.Cells["SPrice"].Value != null && decimal.TryParse(row.Cells["SPrice"].Value.ToString(), out decimal salePrice))
            //    {
            //        sum += salePrice;
            //    }
            //}
            //txtSummary.Value = sum;
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

        private void UpdateTxtQty(DataTable Dt)
        {
            decimal Qty = Convert.ToDecimal(txtQty.Text.ToString());
            foreach (DataRow row in Dt.Rows)
            {
                Qty = Qty - 1;
            }
            txtQty.Text = Qty.ToString();
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
            ResetDgvColumnSize();
        }
        #endregion
        private void frmInventoryPurchaseReturn_Load(object sender, EventArgs e)
        {
            MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.Cancel);
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cboItemCode.SelectedValue.ToString()))
            {
                MessageBox.Show(this, "Select Item First !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); return;
            }
            if (string.IsNullOrEmpty(txtQty.Text.Trim()) || txtQty.Text == "" || txtQty.Text == "0")
            {
                MessageBox.Show(this, "Enter Valid Quantity !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); return;
            }

            StringBuilder STRB = new StringBuilder();
            STRB.AppendLine("SELECT ITD.Sno, ITD.ItemCode, ITD.ItemName, ITD.SerialNo, ITD.Qty, ITD.StoreID, IPD.PPrice");
            STRB.AppendLine("FROM Inventory_ItemsDetail ITD WITH(NOLOCK) ");
            STRB.AppendLine($"LEFT JOIN Inventory_PurchaseDetail IPD WITH(NOLOCK) ON ITD.SerialNo = IPD.SerialNo ");
            STRB.AppendLine($"WHERE ITD.ItemCode = '{cboItemCode.SelectedValue}'");
            DataTable dtTemp = SqlQuery.Read(Global.Con, Global.tran, Global.ConnectionString, STRB.ToString());

            if (dtDetail.Rows.Count == 0 || dtDetail == null)
            {
                dtDetail = dtTemp.Clone();
            }

            for (int i = dtTemp.Rows.Count - 1; i >= 0; i--)
            {
                DataRow tempRow = dtTemp.Rows[i];
                foreach (DataRow ChkInvRow in dtDetail.Rows)
                {
                    if (tempRow["ItemCode"].ToString() == ChkInvRow["ItemCode"].ToString() && tempRow["SerialNo"].ToString() == ChkInvRow["SerialNo"].ToString())
                    {
                        dtTemp.Rows.RemoveAt(i);
                        break; // Exit the inner loop after removing the row
                    }
                }
            }

            if (dtTemp.Rows.Count > 0)
            {
                if (Convert.ToDecimal(txtQty.Text) > dtTemp.Rows.Count)
                {
                    MessageBox.Show(this, "The Quantity you provided is not Available against Selected Item !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); return;
                }
                int LimitQty = 1;
                foreach (DataRow TempRow in dtTemp.Rows)
                {
                    if (LimitQty <= Convert.ToDecimal(txtQty.Text))
                    {
                        DataRow newRow = dtDetail.NewRow();
                        newRow["Sno"] = TempRow["Sno"];
                        newRow["ItemCode"] = TempRow["ItemCode"];
                        newRow["ItemName"] = TempRow["ItemName"];
                        newRow["SerialNo"] = TempRow["SerialNo"];
                        newRow["Qty"] = TempRow["Qty"];
                        newRow["PPrice"] = TempRow["PPrice"];
                        newRow["StoreId"] = TempRow["StoreId"];
                        dtDetail.Rows.Add(newRow);
                        LimitQty++;
                    }
                }
            }
            else
            {
                MessageBox.Show(this, "The ItemCode and SerialNo is Already Exist in Table !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); return;
            }

            dgvDetail.DataSource = dtDetail;
            ResetDgvColumnSize();
            cboItemCode.Focus();
            UpdateSum();
            UpdateTxtQty(dtTemp);
        }

        private void cboItemCode_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboItemCode.Text != string.Empty && cboItemCode.Text != null && cboItemCode.Text != "")
            {
                DataTable dt = SqlQuery.Read(Global.Con, Global.tran, Global.ConnectionString, $"SELECT * FROM Inventory_Items WITH(NOLOCK) WHERE ItemCode = '{cboItemCode.SelectedValue}'");
                txtItemName.Text = dt.Rows[0]["ItemName"].ToString();
                txtQty.Text = dt.Rows[0]["BalQty"].ToString();
            }
        }

        private void txtSerialNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                frmAddSerial frm = new frmAddSerial(ItemCode: cboItemCode.SelectedValue.ToString(), dtDetail, "", true);
                frm.ShowDialog();


                if (frm.dtTemp.Rows.Count > 0)
                {
                    dtDetail.Clear();
                    dtDetail = frm.dtFinalResult.Copy();
                    dtDetail.Columns.Remove("SPrice");
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

        private void txtPayMode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                DataTable dt = SqlQuery.Read(CON, TRAN, Global.ConnectionString, $"SELECT 'Cash' AS TransNo UNION SELECT 'Credit' AS TransNo");
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

        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetail.Columns[e.ColumnIndex] == dgvDetail.Columns["btnDel"])
            {
                RemoveDtRow(dgvDetail.Rows[e.RowIndex].Cells["SerialNo"].Value.ToString());
            }
        }

        private void txtSuppName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                DataTable dt = SqlQuery.Read(CON, TRAN, Global.ConnectionString, $"SELECT SuppCode as TransNo, SuppName as Name FROM Inventory_Suppliers WITH(NOLOCK)");
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
    }
}
