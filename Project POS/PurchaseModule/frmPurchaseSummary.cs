using Project_POS.Classes;
using Project_POS.InventoryModule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Project_POS.PurchaseModule
{
    public partial class frmPurchaseSummary : Form
    {
        SqlConnection con; SqlTransaction tran;
        DataTable dtDetail = new DataTable();
        string FinalWhereCluase, Items, Serial, Bill, Pay, Supp = string.Empty;
        DataTable dtItemCode, dtSerialNo, dtBillNo, dtPayMode, dtSupplier = null;
        public frmPurchaseSummary()
        {
            InitializeComponent();
            cboOption.SelectedIndex = 0;
        }


        private void txtBillNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                string Query = string.Empty;
                if(cboOption.SelectedIndex == 0)
                {
                    Query = "SELECT BillNo AS TransNo FROM Inventory_Purchase WITH(NOLOCK)";
                }
                else
                {
                    Query = "SELECT BillNo AS TransNo FROM Inventory_PurchaseReturn WITH(NOLOCK)";
                }
                DataTable dt = SqlQuery.Read(con, tran, Global.ConnectionString, Query);
                frmFilter frm = new frmFilter(dt, dtBillNo, false);
                frm.FormClosed += (Obj, key) =>
                {
                    var filter = Obj as frmFilter;
                    dtBillNo = filter.DtFilterdRows.Copy();
                    if (dtBillNo.Rows.Count > 0)
                    {
                        StringBuilder StrbBill = new StringBuilder();
                        foreach (DataRow row in dtBillNo.Rows)
                        {
                            string transNo = row["TransNo"].ToString();
                            StrbBill.Append($"'{transNo}',");
                        }
                        txtBillNo.Text = StrbBill.ToString().TrimEnd(',');
                        Bill = txtBillNo.Text;
                    }
                    else
                    {
                        Bill = txtBillNo.Text = string.Empty;
                    }
                };
                frm.ShowDialog();
            }
        }

        private void txtPayMode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                string Query = string.Empty;
                DataTable dt = SqlQuery.Read(con, tran, Global.ConnectionString, "SELECT 'Cash' AS TransNo UNION SELECT 'Credit' AS TransNo");
                frmFilter frm = new frmFilter(dt, dtPayMode, true);
                frm.FormClosed += (Obj, key) =>
                {
                    var filter = Obj as frmFilter;
                    dtPayMode = filter.DtFilterdRows.Copy();
                    if (dtPayMode.Rows.Count > 0)
                    {
                        StringBuilder StrbPayMode = new StringBuilder();
                        foreach (DataRow row in dtPayMode.Rows)
                        {
                            string transNo = row["TransNo"].ToString();
                            StrbPayMode.Append($"'{transNo}',");
                        }
                        txtPayMode.Text = StrbPayMode.ToString().TrimEnd(',');
                        Pay = txtPayMode.Text;
                    }
                    else
                    {
                        Pay = txtPayMode.Text = string.Empty;
                    }
                };
                frm.ShowDialog();
            }
        }

        private void txtSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                string Query = string.Empty;
                
                DataTable dt = SqlQuery.Read(con, tran, Global.ConnectionString, "SELECT SuppCode AS TransNo, SuppName as Name FROM Inventory_Suppliers WITH(NOLOCK)");
                frmFilter frm = new frmFilter(dt, dtSupplier, false);
                frm.FormClosed += (Obj, key) =>
                {
                    var filter = Obj as frmFilter;
                    dtSupplier = filter.DtFilterdRows.Copy();
                    if (dtSupplier.Rows.Count > 0)
                    {
                        StringBuilder StrbSupp = new StringBuilder();
                        foreach (DataRow row in dtSupplier.Rows)
                        {
                            string transNo = row["TransNo"].ToString();
                            StrbSupp.Append($"'{transNo}',");
                        }
                        txtSupplier.Text = StrbSupp.ToString().TrimEnd(',');
                        Supp = txtSupplier.Text;
                    }
                    else
                    {
                        Supp = txtSupplier.Text = string.Empty;
                    }
                };
                frm.ShowDialog();
            }
        }


        private void txtSerial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                string Query = string.Empty;
                if (cboOption.SelectedIndex == 0)
                {
                    Query = "SELECT SerialNo AS TransNo FROM Inventory_PurchaseDetail WITH(NOLOCK)";
                }
                else
                {
                    Query = "SELECT SerialNo AS TransNo FROM Inventory_PurchaseReturnDetail WITH(NOLOCK)";
                }
                DataTable dt = SqlQuery.Read(con, tran, Global.ConnectionString, Query);
                frmFilter frm = new frmFilter(dt, dtSerialNo, false);
                frm.FormClosed += (Obj, key) =>
                {
                    var filter = Obj as frmFilter;
                    dtSerialNo = filter.DtFilterdRows.Copy();
                    if (dtSerialNo.Rows.Count > 0)
                    {
                        StringBuilder StrbSerial = new StringBuilder();
                        foreach (DataRow row in dtSerialNo.Rows)
                        {
                            string transNo = row["TransNo"].ToString();
                            StrbSerial.Append($"'{transNo}',");
                        }
                        txtSerial.Text = StrbSerial.ToString().TrimEnd(',');
                        Serial = txtSerial.Text;
                    }
                    else
                    {
                        Serial = txtSerial.Text = string.Empty;
                    }
                };
                frm.ShowDialog();
            }
        }
        

        private void txtItemCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                DataTable dt = SqlQuery.Read(con, tran, Global.ConnectionString, "SELECT ItemCode AS TransNo FROM Inventory_Items WITH(NOLOCK)");
                frmFilter frm = new frmFilter(dt, dtItemCode, false);
                frm.FormClosed += (Obj, key) =>
                {
                    var filter = Obj as frmFilter;
                    dtItemCode = filter.DtFilterdRows.Copy();
                    if (dtItemCode.Rows.Count > 0)
                    {
                        StringBuilder StrbItem = new StringBuilder();
                        foreach (DataRow row in dtItemCode.Rows)
                        {
                            string transNo = row["TransNo"].ToString();
                            StrbItem.Append($"'{transNo}',");
                        }
                        txtItemCode.Text = StrbItem.ToString().TrimEnd(',');
                        Items = txtItemCode.Text;
                    }
                    else
                    {
                        Items = txtItemCode.Text = string.Empty;
                    }
                };
                frm.ShowDialog();
            }
        }

        
      
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string item = !string.IsNullOrEmpty(Items) ? $"ItemCode IN ({Items})" : string.Empty;
            string serial = !string.IsNullOrEmpty(Serial) ? $"SerialNo IN ({Serial})" : string.Empty;
            string billno = !string.IsNullOrEmpty(Bill) ? $"BillNo IN ({Bill})" : string.Empty;
            string paymode = !string.IsNullOrEmpty(Pay) ? $"PayMode IN ( {Pay})" : string.Empty;
            string supplier = !string.IsNullOrEmpty(Supp) ? $"SuppCode IN ( {Supp})" : string.Empty;
            string FromDate = dtpFromDate.Checked ? $"BillDate >= ('{dtpFromDate.Value}')" : string.Empty;
            string ToDate = dtpToDate.Checked ? $"BillDate <= ('{dtpToDate.Value}')" : string.Empty;
            string WhereClause = string.Join(" AND ", new[] { item, serial, billno, paymode, supplier, FromDate, ToDate }.Where(s => !string.IsNullOrEmpty(s)));
            WhereClause = !string.IsNullOrEmpty(WhereClause) ? $"WHERE {WhereClause}" : string.Empty;

            if (cboOption.SelectedIndex == 0)
            {
                string Query = $"SELECT * FROM FN_PURCHASE_SUMMARY() {WhereClause} ";
                dtDetail = SqlQuery.Read(con, tran, Global.ConnectionString, Query);
                AddNumberToGrid();
                dgvDetail.DataSource = dtDetail;
                dgvDetail.Columns["#"].Width = 40;
            }
            else
            {
                string Query = $"SELECT * FROM FN_PURCHASE_RETURN_SUMMARY() {WhereClause} ";
                dtDetail = SqlQuery.Read(con, tran, Global.ConnectionString, Query);
                AddNumberToGrid();
                dgvDetail.DataSource = dtDetail;
                dgvDetail.Columns["#"].Width = 40;
            }
        }

        private void AddNumberToGrid()
        {
            DataColumn rownoColumn = new DataColumn("#", typeof(int));
            if (!dtDetail.Columns.Contains("#"))
            {
                dtDetail.Columns.Add(rownoColumn);
            }
            dtDetail.Columns["#"].SetOrdinal(0);
            for (int i = 0; i < dtDetail.Rows.Count; i++)
            {
                dtDetail.Rows[i]["#"] = i + 1;
            }

        }
    }
}
