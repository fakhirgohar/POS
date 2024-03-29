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

namespace Project_POS.SaleModule
{
    public partial class frmSaleSummary : Form
    {
        SqlConnection con; SqlTransaction tran;
        string FinalWhereCluase, Items, Serial, Bill, Pay, Customer = string.Empty;
        DataTable dtItemCode, dtSerialNo, dtBillNo, dtPayMode, dtCustomer = null;
        public frmSaleSummary()
        {
            InitializeComponent();
            cboOption.SelectedIndex = 0;
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

        private void txtSerial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                string Query = string.Empty;
                if (cboOption.SelectedIndex == 0)
                {
                    Query = "SELECT SerialNo AS TransNo FROM Inventory_SaleDetail WITH(NOLOCK)";
                }
                else
                {
                    Query = "SELECT SerialNo AS TransNo FROM Inventory_SaleReturnDetail WITH(NOLOCK)";
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

        private void txtBillNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                string Query = string.Empty;
                if (cboOption.SelectedIndex == 0)
                {
                    Query = "SELECT BillNo AS TransNo FROM Inventory_Sale WITH(NOLOCK)";
                }
                else
                {
                    Query = "SELECT RBillNo AS TransNo FROM Inventory_SaleReturn WITH(NOLOCK)";
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

        private void txtCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                string Query = string.Empty;

                DataTable dt = SqlQuery.Read(con, tran, Global.ConnectionString, "SELECT CustCode AS TransNo, CustName as Name FROM Inventory_Customer WITH(NOLOCK)");
                frmFilter frm = new frmFilter(dt, dtCustomer, false);
                frm.FormClosed += (Obj, key) =>
                {
                    var filter = Obj as frmFilter;
                    dtCustomer = filter.DtFilterdRows.Copy();
                    if (dtCustomer.Rows.Count > 0)
                    {
                        StringBuilder StrbSupp = new StringBuilder();
                        foreach (DataRow row in dtCustomer.Rows)
                        {
                            string transNo = row["TransNo"].ToString();
                            StrbSupp.Append($"'{transNo}',");
                        }
                        txtCustomer.Text = StrbSupp.ToString().TrimEnd(',');
                        Customer = txtCustomer.Text;
                    }
                    else
                    {
                        Customer = txtCustomer.Text = string.Empty;
                    }
                };
                frm.ShowDialog();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string item = !string.IsNullOrEmpty(Items) ? $"ItemCode IN ({Items})" : string.Empty;
            string serial = !string.IsNullOrEmpty(Serial) ? $"SerialNo IN ({Serial})" : string.Empty;
            string billno = string.Empty;
            billno = cboOption.SelectedIndex == 0 ? (!string.IsNullOrEmpty(Bill) ? $"BillNo IN ({Bill})" : string.Empty) : (!string.IsNullOrEmpty(Bill) ? $"RBillNo IN ({Bill})" : string.Empty);
            string paymode = !string.IsNullOrEmpty(Pay) ? $"PayMode IN ( {Pay})" : string.Empty;
            string customer = !string.IsNullOrEmpty(Customer) ? $"SuppCode IN ( {Customer})" : string.Empty;
            string FromDate = dtpFromDate.Checked ? $"BillDate >= ('{dtpFromDate.Value}')" : string.Empty;
            string ToDate = dtpToDate.Checked ? $"BillDate <= ('{dtpToDate.Value}')" : string.Empty;
            string WhereClause = string.Join(" AND ", new[] { item, serial, billno, paymode, customer, FromDate, ToDate }.Where(s => !string.IsNullOrEmpty(s)));
            WhereClause = !string.IsNullOrEmpty(WhereClause) ? $"WHERE {WhereClause}" : string.Empty;

            if (cboOption.SelectedIndex == 0)
            {
                string Query = $"SELECT * FROM FN_SALE_SUMMARY() {WhereClause} ";
                DataTable dt = SqlQuery.Read(con, tran, Global.ConnectionString, Query);
                dgvDetail.DataSource = dt;
            }
            else
            {
                string Query = $"SELECT * FROM FN_SALE_RETURN_SUMMARY() {WhereClause} ";
                DataTable dt = SqlQuery.Read(con, tran, Global.ConnectionString, Query);
                dgvDetail.DataSource = dt;
            }
        }
    }
}
