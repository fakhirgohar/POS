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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Project_POS.SaleModule
{
    public partial class frmInventorySaleReturn : Form
    {
        SqlConnection con; SqlTransaction tran;
        DataTable DtDetail = new DataTable(); bool loadQty = false;
        public frmInventorySaleReturn()
        {
            InitializeComponent();
            MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.Load);
            createDtDetialColumns();
            //AddGridCountColumn();
        }

        private void frmInventorySaleReturn_Load(object sender, EventArgs e)
        {
            MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.Load);
            IsEnable(false);
            ClearMasterControls();
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
            if (string.IsNullOrEmpty(txtRBillNo.Text.Trim()))
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

        private void txtBillNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                loadQty = false;
                frmLOV frm = new frmLOV();
                frm.SetData(con, Global.ConnectionString, "Inventory_Sale", "BillNo", new List<string> { "BillNo", "BillDate", "ReceiptNo", "Remarks" });
                frm.FormClosing += (o, a) =>
                {
                    var frmKey = o as frmLOV;
                    string code = frmKey.Code;
                    if (string.IsNullOrEmpty(code)) { return; }
                    txtBillNo.Text = code;
                    dtpBillDate.Value = Convert.ToDateTime(SqlQuery.GetSingleValue(con, tran, Global.ConnectionString, $"select BillDate from Inventory_Sale with(nolock) where BillNo = '{code}'"));
                    DataTable Dt = SqlQuery.Read(con, tran, Global.ConnectionString, $"select Distinct ItemCode from Inventory_SaleDetail with(nolock) where BillNo = '{code}'");
                    cboItemCode.DisplayMember = "ItemCode";
                    cboItemCode.ValueMember = "ItemCode";
                    cboItemCode.DataSource = Dt;

                    DataTable dt1 = SqlQuery.Read(con, tran, Global.ConnectionString, $"select ISL.CustCode,ICR.CustName,ISL.ReceiptNo from Inventory_Sale ISL with(nolock)  left join Inventory_Customer ICR with(nolock) ON ICR.CustCode = ISL.CustCode where BillNo = '{code}'");
                    txtReceiptNo.Text = dt1.Rows[0]["ReceiptNo"].ToString();
                    txtCustCode.Text = dt1.Rows[0]["CustCode"].ToString();
                    txtCustName.Text = dt1.Rows[0]["CustName"].ToString();
                    grpDetail.Enabled = true;

                    txtPayMode.Text = SqlQuery.GetSingleValue(con, tran, Global.ConnectionString, $"SELECT PayMode FROM Inventory_Sale WITH(NOLOCK) WHERE BillNo = '{code}'");

                    ClearDetailControls();
                };
                frm.ShowDialog();
            }
        }

        private void cboItemCode_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboItemCode.Text != string.Empty && cboItemCode.Text != null && cboItemCode.Text != "")
            {
                txtItemName.Text = SqlQuery.GetSingleValue(con, tran, Global.ConnectionString, $"SELECT ItemName FROM Inventory_Items WITH(NOLOCK) WHERE ItemCode = '{cboItemCode.SelectedValue}'");
                if (loadQty)
                {
                    StringBuilder STRB = new StringBuilder();
                    STRB.AppendLine("SELECT ISNULL(SUM(CAST(Qty AS INT)),0) AS QTY FROM Inventory_SaleDetail ISD WITH(NOLOCK)");
                    STRB.AppendLine("LEFT JOIN Inventory_Items II WITH(NOLOCK) ON II.ItemCode = ISD.ItemCode");
                    STRB.AppendLine($"WHERE BillNo = '{txtBillNo.Text}' AND ISD.ItemCode = '{cboItemCode.SelectedValue}' AND SerialNo NOT IN (SELECT ISRD.SerialNo FROM Inventory_SaleReturnDetail ISRD WITH(NOLOCK)");
                    STRB.AppendLine($"LEFT JOIN Inventory_SaleReturn ISR WITH(NOLOCK) ON ISR.RBillNo = ISRD.RBillNo WHERE ISR.BillNo = '{txtBillNo.Text}' AND ISRD.ItemCode = '{cboItemCode.SelectedValue}')");
                    int itemCount = DtDetail.AsEnumerable().Where(row => row["ItemCode"].ToString() == cboItemCode.SelectedValue.ToString()).Count();
                    string Qty = SqlQuery.GetSingleValue(con, tran, Global.ConnectionString, STRB.ToString());
                    txtQty.Text = Convert.ToString(Convert.ToDecimal(Qty) - itemCount);
                }
            }
        }

        private void txtSerial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                StringBuilder STRB = new StringBuilder();
                STRB.AppendLine("SELECT ISD.Sno, ISD.ItemCode, II.ItemName, ISD.SerialNo, ISD.Qty, ISD.Sprice, ISD.PPrice, ISD.StoreId FROM Inventory_SaleDetail ISD WITH(NOLOCK)");
                STRB.AppendLine("LEFT JOIN Inventory_Items II WITH(NOLOCK) ON II.ItemCode = ISD.ItemCode");
                STRB.AppendLine($"WHERE BillNo = '{txtBillNo.Text}' AND ISD.ItemCode = '{cboItemCode.SelectedValue}' AND SerialNo NOT IN (SELECT ISRD.SerialNo FROM Inventory_SaleReturnDetail ISRD WITH(NOLOCK)");
                STRB.AppendLine($"LEFT JOIN Inventory_SaleReturn ISR WITH(NOLOCK) ON ISR.RBillNo = ISRD.RBillNo WHERE ISR.BillNo = '{txtBillNo.Text}' AND ISRD.ItemCode = '{cboItemCode.SelectedValue}')");
                frmAddSerial frm = new frmAddSerial(cboItemCode.SelectedValue.ToString(), DtDetail, STRB.ToString(), true);
                frm.ShowDialog();


                if (frm.dtFinalResult.Rows.Count > 0)
                {
                    if (DtDetail.Rows.Count == 0 || DtDetail == null)
                    {
                        DtDetail = frm.dtFinalResult.Clone();
                    }

                    foreach (DataRow row in frm.dtFinalResult.Rows)
                    {
                        DataRow newRow = DtDetail.NewRow();
                        newRow.ItemArray = row.ItemArray;
                        DtDetail.Rows.Add(newRow);
                    }

                }
                if (DtDetail.Rows.Count > 0)
                {
                    dgvDetail.DataSource = null;
                    dgvDetail.DataSource = DtDetail;
                    UpdateSum();
                    ResetDgvColumnSize();
                }
                UpdateTxtQty(frm.dtFinalResult);
                //UpdateRowCount();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cboItemCode.SelectedValue.ToString()))
            {
                MessageBox.Show(this, "Select Item First !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1); return;
            }
            if (string.IsNullOrEmpty(txtQty.Text.Trim()) || txtQty.Text == "" || txtQty.Text == "0")
            {
                MessageBox.Show(this, "Enter Valid Quantity !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1); return;
            }

            StringBuilder STRB = new StringBuilder();
            STRB.AppendLine("SELECT ISD.Sno, ISD.ItemCode, II.ItemName, ISD.SerialNo, ISD.Qty, ISD.Sprice, ISD.PPrice, ISD.StoreId FROM Inventory_SaleDetail ISD WITH(NOLOCK)");
            STRB.AppendLine("LEFT JOIN Inventory_Items II WITH(NOLOCK) ON II.ItemCode = ISD.ItemCode");
            STRB.AppendLine($"WHERE BillNo = '{txtBillNo.Text}' AND ISD.ItemCode = '{cboItemCode.SelectedValue}' AND SerialNo NOT IN (SELECT ISRD.SerialNo FROM Inventory_SaleReturnDetail ISRD WITH(NOLOCK)");
            STRB.AppendLine($"LEFT JOIN Inventory_SaleReturn ISR WITH(NOLOCK) ON ISR.RBillNo = ISRD.RBillNo WHERE ISR.BillNo = '{txtBillNo.Text}' AND ISRD.ItemCode = '{cboItemCode.SelectedValue}')");
            DataTable dtTemp = SqlQuery.Read(con, tran, Global.ConnectionString, STRB.ToString());

            if (DtDetail.Rows.Count == 0 || DtDetail == null)
            {
                DtDetail = dtTemp.Clone();
            }

            for (int i = dtTemp.Rows.Count - 1; i >= 0; i--)
            {
                DataRow tempRow = dtTemp.Rows[i];
                foreach (DataRow ChkInvRow in DtDetail.Rows)
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
                    MessageBox.Show(this, "The Quantity you provided is not Available against Selected Item !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1); return;
                }
                int LimitQty = 1;
                foreach (DataRow TempRow in dtTemp.Rows)
                {
                    if (LimitQty <= Convert.ToDecimal(txtQty.Text))
                    {
                        DataRow newRow = DtDetail.NewRow();
                        newRow["Sno"] = TempRow["Sno"];
                        newRow["ItemCode"] = TempRow["ItemCode"];
                        newRow["ItemName"] = TempRow["ItemName"];
                        newRow["SerialNo"] = TempRow["SerialNo"];
                        newRow["Qty"] = TempRow["Qty"];
                        newRow["Sprice"] = TempRow["Sprice"];
                        newRow["PPrice"] = TempRow["PPrice"];
                        newRow["StoreId"] = TempRow["StoreId"];
                        DtDetail.Rows.Add(newRow);
                        LimitQty++;
                    }
                }
            }
            else
            {
                MessageBox.Show(this, "SerialNo is Already Exist Or Serial is Not Found !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1); return;
            }

            AddNumberToGrid();
            dgvDetail.DataSource = DtDetail;
            ResetDgvColumnSize();
            txtSerial.Text = string.Empty;
            txtSPrice.Text = string.Empty;
            txtPPrice.Text = string.Empty;
            txtStore.Text = string.Empty;
            cboItemCode.Focus();
            UpdateSum();
            UpdateTxtQty(dtTemp);
        }
        #region functions
        private void RemoveDtRow(string SerialNo)
        {
            for (int i = 0; i < DtDetail.Rows.Count; i++)
            {
                DataRow row = DtDetail.Rows[i];

                if (row["SerialNo"].ToString() == SerialNo)
                {
                    DtDetail.Rows.RemoveAt(i);
                }
            }
            AddNumberToGrid();            
            dgvDetail.DataSource = DtDetail;
            //UpdateRowCount();
            ResetDgvColumnSize();
        }
        private void createDtDetialColumns()
        {
            DtDetail.Columns.Add("ItemCode", typeof(string));
            DtDetail.Columns.Add("ItemName", typeof(string));
            DtDetail.Columns.Add("SerialNo", typeof(string));
            DtDetail.Columns.Add("SPrice", typeof(string));
            DtDetail.Columns.Add("PPrice", typeof(string));
            DtDetail.Columns.Add("StoreID", typeof(string));
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
        private void Insert()
        {
            if (InsertUpdateValidate(DtDetail))
            {
                using (con = new SqlConnection(Global.ConnectionString))
                {
                    con.Open();
                    SqlTransaction tran = con.BeginTransaction();
                    try
                    {
                        int Sno = 1;
                        txtRBillNo.Text = SqlQuery.GetNewTransNo();
                        SqlQuery.Insert(con, tran, "Inventory_SaleReturn", Global.ConnectionString, new Dictionary<string, object> { { "RBillNo", txtRBillNo.Text }, { "RBillDate", dtpRBillDate.Value.ToShortDateString() }, { "RReceiptNo", txtReceiptNo.Text }, { "BillNo", txtBillNo.Text }, { "BillDate", dtpBillDate.Value.ToShortDateString() }, { "CustCode", txtCustCode.Text }, { "PayMode", txtPayMode.Text }, { "Remarks", txtRemarks.Text }, { "TotalQty", txtTotalQty.Text }, { "TotalAmount", txtSummary.Text }, { "BillTransDate", DateTime.Now.ToShortDateString() }, { "BillTransTime", DateTime.Now.ToLongTimeString() } });

                        foreach (DataRow Row in DtDetail.Rows)
                        {
                            Dictionary<string, object> dicValue = new Dictionary<string, object>();
                            dicValue.Add("RBillNo", txtRBillNo.Text);
                            dicValue.Add("Sno", Sno);
                            dicValue.Add("ItemCode", Row["ItemCode"]);
                            dicValue.Add("SerialNo", Row["SerialNo"]);
                            dicValue.Add("Qty", Row["Qty"]);
                            dicValue.Add("PPrice", Row["PPrice"]);
                            dicValue.Add("PurchaseDate", SqlQuery.GetSingleValue(con, tran, Global.ConnectionString, $"SELECT IP.BillDate FROM Inventory_Purchase IP WITH(NOLOCK) LEFT JOIN Inventory_PurchaseDetail IPD WITH(NOLOCK) ON IP.BillNo = IPD.BillNo WHERE IPD.SerialNo = '{Row["SerialNo"]}'"));
                            dicValue.Add("SPrice", Row["SPrice"]);
                            dicValue.Add("SaleDate", dtpBillDate.Value.ToShortDateString());
                            dicValue.Add("Depreciation", "");
                            dicValue.Add("RPrice", "");
                            dicValue.Add("StoreID", Row["StoreID"]);
                            SqlQuery.Insert(con, tran, "Inventory_SaleReturnDetail", Global.ConnectionString, dicValue);
                            SqlQuery.Insert(con, tran, "Inventory_ItemsDetail", Global.ConnectionString, new Dictionary<string, object> { { "Sno", Row["Sno"] }, { "ItemCode", Row["ItemCode"] }, { "ItemName", Row["ItemName"] }, { "SerialNo", Row["SerialNo"] }, { "Qty", Row["Qty"] }, { "StoreID", Row["StoreID"] }, });
                            Sno++;
                        }
                        UpdateItems(DtDetail, con, tran);
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
        }
        private bool BeforeUpdate()
        {
            DataTable dtSR = SqlQuery.Read(con, tran, Global.ConnectionString, $"SELECT * FROM Inventory_SaleReturnDetail WITH(NOLOCK) WHERE RBillNo = '{txtRBillNo.Text}'");
            foreach (DataRow Row in dtSR.Rows)
            {
                if (SqlQuery.IsFound(con, tran, Global.ConnectionString, "Inventory_ItemsDetail", $"ItemCode = '{Row["ItemCode"]}' AND SerialNo = '{Row["SerialNo"]}'"))
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        private new void Update()
        {
            if (!BeforeUpdate())
            {
                MessageBox.Show(this, "Can't Update ! \nThe Item is Out of Stock", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1); return;
            }
            using (con = new SqlConnection(Global.ConnectionString))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    if (InsertUpdateValidate(DtDetail))
                    {
                        SqlQuery.Update(con, tran, Global.ConnectionString, "Inventory_SaleReturn", $"WHERE RBillNo = '{txtRBillNo.Text}' ", new Dictionary<string, object> { { "RBillNo", txtRBillNo.Text }, { "RBillDate", dtpRBillDate.Value.ToShortDateString() }, { "RReceiptNo", txtReceiptNo.Text }, { "BillNo", txtBillNo.Text }, { "BillDate", dtpBillDate.Value.ToShortDateString() }, { "CustCode", txtCustCode.Text }, { "PayMode", txtPayMode.Text }, { "Remarks", txtRemarks.Text }, { "TotalQty", txtTotalQty.Text }, { "TotalAmount", txtSummary.Text }, { "BillTransDate", DateTime.Now.ToShortDateString() }, { "BillTransTime", DateTime.Now.ToLongTimeString() } });
                        SqlQuery.Delete(con, tran, Global.ConnectionString, "Inventory_SaleReturnDetail", $"RBillNo='{txtRBillNo.Text}'");
                        DeleteItemsDetail(DtDetail, con, tran);

                        int Sno = 1;
                        foreach (DataRow Row in DtDetail.Rows)
                        {
                            Dictionary<string, object> dicValue = new Dictionary<string, object>();
                            dicValue.Add("RBillNo", txtRBillNo.Text);
                            dicValue.Add("Sno", Sno);
                            dicValue.Add("ItemCode", Row["ItemCode"]);
                            dicValue.Add("SerialNo", Row["SerialNo"]);
                            dicValue.Add("Qty", Row["Qty"]);
                            dicValue.Add("PPrice", Row["PPrice"]);
                            dicValue.Add("PurchaseDate", SqlQuery.GetSingleValue(con, tran, Global.ConnectionString, $"SELECT IP.BillDate FROM Inventory_Purchase IP WITH(NOLOCK) LEFT JOIN Inventory_PurchaseDetail IPD WITH(NOLOCK) ON IP.BillNo = IPD.BillNo WHERE IPD.SerialNo = '{Row["SerialNo"]}'"));
                            dicValue.Add("SPrice", Row["SPrice"]);
                            dicValue.Add("SaleDate", dtpBillDate.Value.ToShortDateString());
                            dicValue.Add("Depreciation", "");
                            dicValue.Add("RPrice", "");
                            dicValue.Add("StoreID", Row["StoreID"]);
                            SqlQuery.Insert(con, tran, "Inventory_SaleReturnDetail", Global.ConnectionString, dicValue);
                            SqlQuery.Insert(con, tran, "Inventory_ItemsDetail", Global.ConnectionString, new Dictionary<string, object> { { "Sno", Row["Sno"] }, { "ItemCode", Row["ItemCode"] }, { "ItemName", Row["ItemName"] }, { "SerialNo", Row["SerialNo"] }, { "Qty", Row["Qty"] }, { "StoreID", Row["StoreID"] }, });
                            Sno++;
                        }
                        UpdateItems(DtDetail, con, tran);
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
            //else if (SqlQuery.IsFound(con, tran, Global.ConnectionString, "Inventory_Sale", $"BillNo = {txtBillNo.Text}"))
            //{
            //    MessageBox.Show(this, $"Cannot Delete \nSale Return Posted Against this BillNo = {txtBillNo.Text} !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1); return;
            //}
            if (!BeforeUpdate())
            {
                MessageBox.Show(this, "Can't Delete ! \nThe Item is Out of Stock", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1); return;
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
                        DataTable DT = SqlQuery.Read(con, tran, Global.ConnectionString, $"SELECT Sno, ISD.ItemCode, II.ItemName, SerialNo, Qty, StoreId FROM Inventory_SaleReturnDetail ISD WITH(NOLOCK) LEFT JOIN Inventory_Items II WITH(NOLOCK) ON II.ItemCode = ISD.ItemCode WHERE RBillNo = '{txtRBillNo.Text}'");
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.Connection = con;
                            cmd.Transaction = tran;
                            cmd.CommandText = $"DELETE FROM Inventory_SaleReturn WHERE RBillNo = '{txtRBillNo.Text}'";
                            cmd.ExecuteNonQuery();
                        }
                        DeleteItemsDetail(DtDetail, con, tran);
                        UpdateItems(DtDetail, con, tran);
                        tran.Commit();
                        MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.Cancel);
                        ClearMasterControls();
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


        private bool BeforeEdit()
        {
            foreach (DataRow Row in DtDetail.Rows)
            {
                if (SqlQuery.IsFound(con, tran, Global.ConnectionString, "Inventory_ItemsDetail", $"ItemCode = '{Row["ItemCode"]}' AND SerialNo = '{Row["SerialNo"]}'"))
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        private void Edit()
        {
            if (string.IsNullOrEmpty(txtBillNo.Text.Trim()))
            {
                MessageBox.Show(this, "No Record to Edit !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            if (!BeforeEdit())
            {
                MessageBox.Show(this, "Can't Edit ! \nThe Item is Out of Stock", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            BeforeEdit();
            MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.Edit);
            IsEnable(true);
        }
        private void Cancel()
        {
            DialogResult result = MessageBox.Show("Are you sure you want to Cancel this Transaction?", "Confirm Cancellation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                ClearMasterControls();
                MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.Cancel);
                IsEnable(false);
            }
        }
        private void Search()
        {
            SqlConnection con = new SqlConnection(Global.ConnectionString);
            frmLOV frm = new frmLOV();
            //frm.SetData(con, Global.ConnectionString, "SELECT * FROM Inventory_Purchase WITH(NOLOCK)", "BillNo");
            frm.SetData(con, Global.ConnectionString, "Inventory_SaleReturn", "RBillNo", new List<string> { "RBillNo", "RBillDate", "RReceiptNo", "Remarks" });
            frm.FormClosing += (o, a) =>
            {
                con.Open();
                var frmkey = o as frmLOV;
                string code = frmkey.Code;
                if (string.IsNullOrEmpty(code))
                {
                    return;
                }
                DtDetail.Rows.Clear();
                DataTable dtMaster = SqlQuery.Read(con, tran, Global.ConnectionString, $"SELECT * FROM Inventory_SaleReturn WITH(NOLOCK) WHERE RBillNo = '{code}'");
                DtDetail = SqlQuery.Read(con, tran, Global.ConnectionString, $"SELECT RBillNo, Sno, ISRD.ItemCode, II.ItemName, SerialNo,Qty, PPrice, SPrice, StoreID FROM Inventory_SaleReturnDetail ISRD WITH(NOLOCK) LEFT JOIN Inventory_Items II WITH(NOLOCK) ON II.ItemCode = ISRD.ItemCode  WHERE ISRD.RBillNo = '{code}'");

                if (dtMaster.Rows.Count > 0)
                {
                    txtRBillNo.Text = dtMaster.Rows[0]["RBillNo"].ToString();
                    txtBillNo.Text = dtMaster.Rows[0]["BillNo"].ToString();
                    txtReceiptNo.Text = dtMaster.Rows[0]["RReceiptNo"].ToString();
                    txtRemarks.Text = dtMaster.Rows[0]["Remarks"].ToString();
                    txtCustCode.Text = dtMaster.Rows[0]["CustCode"].ToString();
                    txtCustName.Text = SqlQuery.GetSingleValue(con, tran, Global.ConnectionString, $"select CustName from Inventory_Customer with(nolock) where CustCode = '{dtMaster.Rows[0]["CustCode"].ToString()}'");
                    dtpBillDate.Value = Convert.ToDateTime(dtMaster.Rows[0]["BillDate"].ToString());
                    dtpRBillDate.Value = Convert.ToDateTime(dtMaster.Rows[0]["RBillDate"].ToString());
                }

                if (DtDetail.Rows.Count > 0)
                {
                    DtDetail.AcceptChanges();
                    AddNumberToGrid();
                    dgvDetail.DataSource = DtDetail;
                    ResetDgvColumnSize();
                    //UpdateRowCount();
                    UpdateSum();
                }
                //UpdateRowCount();
                MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.Load);
                IsEnable(false);
            };
            frm.ShowDialog();
        }
        private void New()
        {
            MyControls.UpdateButtonStates(btnNew, btnEdit, btnDelete, btnPrint, btnSearch, btnSave, btnCancel, MyControls.Event.New);
            ClearMasterControls();
            IsEnable(true);
            grpDetail.Enabled = false;
        }
        private void ClearMasterControls()
        {
            txtRBillNo.Text = string.Empty;
            txtBillNo.Text = string.Empty;
            txtRemarks.Text = string.Empty;
            txtReceiptNo.Text = string.Empty;
            txtCustCode.Text = string.Empty;
            txtCustName.Text = string.Empty;

            dtpBillDate.Value = DateTime.Now;
            dtpRBillDate.Value = DateTime.Now;
            ClearDetailControls();
        }

        private void ClearDetailControls()
        {

            txtItemName.Text = string.Empty;
            txtPPrice.Text = string.Empty;
            txtSerial.Text = string.Empty;
            txtSPrice.Text = string.Empty;
            txtStore.Text = string.Empty;
            txtQty.Text = string.Empty;
            txtTotalQty.Text = string.Empty;
            txtSummary.Text = string.Empty;

            cboItemCode.Text = string.Empty;
            DtDetail.Rows.Clear();
            dgvDetail.DataSource = null;

        }

        private void SetCbo()
        {
            //DataTable dtItems = SqlQuery.Read(con, tran, Global.ConnectionString, "SELECT DISTINCT ItemCode FROM Inventory_ItemsDetail WITH(NOLOCK)");
            //cboItems.DisplayMember = "ItemCode";
            //cboItems.ValueMember = "ItemCode";
            //cboItems.DataSource = dtItems;

            //DataTable dtCustomer = SqlQuery.Read(con, tran, Global.ConnectionString, "SELECT * FROM Inventory_Customer WITH(NOLOCK)");
            //cboCustomer.DisplayMember = "SuppName";
            //cboCustomer.ValueMember = "SuppCode";
            //cboCustomer.DataSource = dtCustomer;


        }

        private void IsEnable(bool cond)
        {
            grpMain.Enabled = cond;
            grpDetail.Enabled = cond;

        }

        private bool InsertUpdateValidate(DataTable dt)
        {
            if (dt.Rows.Count == 0 || dt == null)
            {
                MessageBox.Show(this, "There is No Detail Record !\nPlease Select An Item To Return.", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1); return false;
            }
            if (string.IsNullOrEmpty(txtBillNo.Text)) { MessageBox.Show(this, "Enter Receipt No !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1); return false; }
            if (dtpRBillDate.Value < dtpBillDate.Value) { MessageBox.Show(this, "Invalid Return Date ! \nPlease Select Date Equal or Greater Then BillDate.", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1); return false; }
            // if (string.IsNullOrEmpty(txtCustName.Text)) { MessageBox.Show(this, "Enter Purchaser Name !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1); return false; }
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
            dgvDetail.Columns["#"].Width = 40;
            dgvDetail.Columns["ItemCode"].Width = 130;
            dgvDetail.Columns["ItemName"].Width = 180;
            dgvDetail.Columns["SerialNo"].Width = 150;
            dgvDetail.Columns["SPrice"].Width = 150;
            dgvDetail.Columns["PPrice"].Width = 140;
            dgvDetail.Columns["StoreID"].Width = 145;
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
            decimal Qty = 0;
            decimal TotalAmount = 0;
            foreach (DataGridViewRow row in dgvDetail.Rows)
            {
                if (row.Cells["Qty"].Value != null && decimal.TryParse(row.Cells["Qty"].Value.ToString(), out decimal DetailQty))
                {
                    Qty += DetailQty;
                }
                if (row.Cells["SPrice"].Value != null && decimal.TryParse(row.Cells["SPrice"].Value.ToString(), out decimal DetailSPrice))
                {
                    TotalAmount += DetailSPrice;
                }
            }
            txtTotalQty.Text = Qty.ToString();
            txtSummary.Text = TotalAmount.ToString();
        }

        //private void AddGridCountColumn()
        //{
        //    var countColumn = new DataGridViewTextBoxColumn();
        //    countColumn.HeaderText = "#";
        //    countColumn.ReadOnly = true;
        //    countColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
        //    dgvDetail.Columns.Insert(0, countColumn);


        //}
        //private void UpdateRowCount()
        //{
        //    if (dgvDetail.Rows.Count > 0)
        //    {
        //        for (int i = 0; i < dgvDetail.Rows.Count; i++)
        //        {
        //            dgvDetail.Rows[i].Cells[0].Value = (i + 1).ToString();
        //        }
        //    }
        //}


        private void AddNumberToGrid()
        {
            DataColumn rownoColumn = new DataColumn("#", typeof(int));
            if (!DtDetail.Columns.Contains("#"))
            {
                DtDetail.Columns.Add(rownoColumn);
            }
            DtDetail.Columns["#"].SetOrdinal(0);
            for (int i = 0; i < DtDetail.Rows.Count; i++)
            {
                DtDetail.Rows[i]["#"] = i + 1;
            }

        }

        #endregion

        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetail.Columns[e.ColumnIndex] == dgvDetail.Columns["btnDel"])
            {
                RemoveDtRow(dgvDetail.Rows[e.RowIndex].Cells["SerialNo"].Value.ToString());
            }
        }

        private void cboItemCode_Click(object sender, EventArgs e)
        {
            loadQty = true;
        }
    }
}
