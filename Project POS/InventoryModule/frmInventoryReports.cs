using Project_POS.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_POS.InventoryModule
{
    public partial class frmInventoryReports : Form
    {
        public frmInventoryReports()
        {
            InitializeComponent();
            cboRepType.SelectedIndex = 0;
        }
        SqlConnection con; SqlTransaction tran;
        string ItemCode, ProdCode, CompCode, CatCode = string.Empty;
        DataTable DtItemcode, dtProdCode, dtCompCode, dtCatCode = new DataTable();

        public enum RepType
        {
            CurrentStock,
            BackDateStock,
        }
        public enum RepCase
        {
            StockReportItemWise,
            StockReportSerialWise,
            StockReportItemAndSerialWise,
            StockReportItemSerialAndPriceWise,
        }


        private void btnPreview_Click(object sender, EventArgs e)
        {
            ///////////////////-------------------Old Method-------------------///////////////////

            //string item = ItemCode;
            //string prodCode = ProdCode;
            //string serialNo = SerialNo;
            //string catCode = CatCode;

            //if (!chkItemCode.Checked)
            //{
            //    item = string.Empty;
            //}
            //if (!chkCategory.Checked)
            //{
            //    catCode = string.Empty;
            //}
            //if (!chkProduct.Checked)
            //{
            //    prodCode = string.Empty;
            //}
            //if (!chkSerialNo.Checked)
            //{
            //    serialNo = string.Empty;
            //}

            //if(string.IsNullOrEmpty(ItemCode) && string.IsNullOrEmpty(ItemCode) && string.IsNullOrEmpty(ItemCode) && string.IsNullOrEmpty(ItemCode))
            //{
            //    WhereClause = string.Empty;
            //}
            //if (!string.IsNullOrEmpty(ItemCode))
            //{
            //    WhereClause += $" Where ItemCode IN ({ItemCode})";
            //}
            //if (!string.IsNullOrEmpty(CatCode) && !string.IsNullOrEmpty(WhereClause))
            //{
            //    WhereClause += $" And CatId IN ({CatCode})";
            //}
            //if(!string.IsNullOrEmpty(CatCode) && string.IsNullOrEmpty(WhereClause))
            //{
            //    WhereClause += $" Where CatId IN ({CatCode})";
            //}

            //if (!string.IsNullOrEmpty(ProdCode) && !string.IsNullOrEmpty(WhereClause))
            //{
            //    WhereClause += $" And CatId IN ({ProdCode})";
            //}
            //if (!string.IsNullOrEmpty(ProdCode) && string.IsNullOrEmpty(WhereClause))
            //{
            //    WhereClause += $" Where CatId IN ({ProdCode})";
            //}

            //if (!string.IsNullOrEmpty(SerialNo) && !string.IsNullOrEmpty(WhereClause))
            //{
            //    WhereClause += $" And CatId IN ({SerialNo})";
            //}
            //if (!string.IsNullOrEmpty(SerialNo) && string.IsNullOrEmpty(WhereClause))
            //{
            //    WhereClause += $" Where CatId IN ({SerialNo})";
            //}

            //string WhereClause = string.Empty;
            //WhereClause = string.IsNullOrEmpty(item) ? string.Empty : $" WHERE ItemCode IN ({item})";
            //WhereClause += !string.IsNullOrEmpty(catCode) ? (string.IsNullOrEmpty(WhereClause) ? $" WHERE CatId IN ({catCode})" : $" AND CatId IN ({catCode})") : "";
            //WhereClause += !string.IsNullOrEmpty(prodCode) ? (string.IsNullOrEmpty(WhereClause) ? $" WHERE ProdCode IN ({prodCode})" : $" AND ProdId IN ({prodCode})") : "";
            //WhereClause += !string.IsNullOrEmpty(serialNo) ? (string.IsNullOrEmpty(WhereClause) ? $" WHERE SerialNo IN ({serialNo})" : $" AND SerialNo IN ({serialNo})") : "";

            ///////////////////-------------------New Method-------------------///////////////////

            string item = chkItemCode.Checked ? $"ItemCode IN ({ItemCode})" : string.Empty;
            string prodCode = chkProduct.Checked ? $"ProdCode IN ({ProdCode})" : string.Empty;
            string compcode = chkCompCode.Checked ? $"SerialNo IN ({CompCode})" : string.Empty;
            string catCode = chkCategory.Checked ? $"CatId IN ({CatCode})" : string.Empty;
            string WhereClause = string.Join(" AND ", new[] { item, prodCode, compcode, catCode }.Where(s => !string.IsNullOrEmpty(s)));
            WhereClause = !string.IsNullOrEmpty(WhereClause) ? $"WHERE {WhereClause}" : string.Empty;



            if (cboRepCase.SelectedItem == null || cboRepCase.SelectedItem.ToString() == "")
            {
                MessageBox.Show(this, "Select Report Type!", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }


            CheckReportValidations();
            Dictionary<string, DataTable> dataSets = new Dictionary<string, DataTable>();
            DataTable dtReports = new DataTable();
            switch (cboRepType.SelectedItem.ToString().Replace(" ", ""))
            {
                case nameof(RepType.CurrentStock):
                    dtReports.Clear();
                    dataSets.Clear();
                    dtReports = CurrentStock(WhereClause);
                    dataSets.Add("DataSet1", dtReports);
                    break;
                case nameof(RepType.BackDateStock):
                    dtReports.Clear();
                    dataSets.Clear();
                    dtReports = BackDateStock();
                    dataSets.Add("DataSetName", dtReports);
                    break;
                default:
                    dtReports.Clear();
                    dataSets.Clear();
                    break;
            }

            Tuple<string, string> rptNamePath = ReportPathAndName();
            Dictionary<string, string> dictReportParams = GetReportParams();
            dictReportParams.Add("pmrReportName", rptNamePath.Item1);

            frmReportVeiwer FrmReport = new frmReportVeiwer(rptNamePath.Item2, dataSets, dictReportParams);
            FrmReport.Text = "Stock Reports";
            FrmReport.Show();
        }

        private void cboRepType_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboRepType.SelectedItem.ToString().Replace(" ", "") == RepType.BackDateStock.ToString())
            {
                cboRepCase.Enabled = false;
                txtCategory.Enabled = false;
                txtProduct.Enabled = false;
                chkCategory.Enabled = false;
                chkProduct.Enabled = false;
                dtpFromDate.Enabled = true;
                dtpToDate.Enabled = true;
                chkFromDate.Enabled = true;
                chkToDate.Enabled = true;
            }
            else
            {
                cboRepCase.Enabled = true;
                txtCategory.Enabled = true;
                txtProduct.Enabled = true;
                chkCategory.Enabled = true;
                chkProduct.Enabled = true;
            }
            if (cboRepType.SelectedItem.ToString().Replace(" ", "") == RepType.CurrentStock.ToString())
            {
                dtpFromDate.Enabled = false;
                dtpToDate.Enabled = false;
                chkFromDate.Enabled = false;
                chkToDate.Enabled = false;
            }
        }

        private void cboRepCase_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void CheckReportValidations()
        {
            if (cboRepType.SelectedItem.ToString() == "Back Date Stock")
            {

            }
        }

        private DataTable CurrentStock(string WhereClause)
        {
            DataTable dt = new DataTable();
            switch (cboRepCase.SelectedItem.ToString().Replace(" ", ""))
            {
                case nameof(RepCase.StockReportItemWise):
                    dt = SqlQuery.Read(Global.Con, Global.tran, Global.ConnectionString, $"SELECT ItemCode, SUM(Qty) AS QTY FROM FN_CURRENT_STOCK() {WhereClause} GROUP BY ItemCode");
                    break;
                case nameof(RepCase.StockReportSerialWise):
                    dt = SqlQuery.Read(Global.Con, Global.tran, Global.ConnectionString, $"SELECT ItemCode, SerialNo, Qty FROM FN_CURRENT_STOCK() {WhereClause} GROUP BY ItemCode, SerialNo, Qty");
                    break;
                case nameof(RepCase.StockReportItemAndSerialWise):
                    dt = SqlQuery.Read(Global.Con, Global.tran, Global.ConnectionString, $"SELECT ItemCode, ItemName, SerialNo, Qty FROM FN_CURRENT_STOCK() {WhereClause} GROUP BY ItemCode, ItemName, SerialNo, Qty");
                    break;
                case nameof(RepCase.StockReportItemSerialAndPriceWise):
                    dt = SqlQuery.Read(Global.Con, Global.tran, Global.ConnectionString, $"SELECT ItemCode, ItemName, SerialNo, Qty, (SELECT PPrice FROM Inventory_PurchaseDetail IPD WITH(NOLOCK) WHERE IPD.ItemCode = FN.ItemCode AND IPD.SerialNo = FN.SerialNo ) AS PPrice FROM FN_CURRENT_STOCK() FN {WhereClause} GROUP BY ItemCode, ItemName, SerialNo, Qty");
                    break;
                default:
                    break;
            }
            return dt;
        }

        private DataTable BackDateStock()
        {
            DataTable dt = new DataTable();
            dt = SqlQuery.Read(Global.Con, Global.tran, Global.ConnectionString, "EXEC PROC_BACKDATE ''");
            return dt;
        }

        private void StockReconcilation()
        {

        }

        private Tuple<string, string> ReportPathAndName()
        {
            string reportPath = string.Empty, reportName = string.Empty;
            switch (cboRepType.SelectedItem.ToString().Replace(" ", ""))
            {
                case nameof(RepType.CurrentStock):
                    switch (cboRepCase.SelectedItem.ToString().Replace(" ", ""))
                    {
                        case nameof(RepCase.StockReportItemWise):
                            reportPath = Global.InventoryReportPath + @"StockReportItemWise.rdlc";
                            reportName = "Stock-Report-Item-Wise";
                            break;
                        case nameof(RepCase.StockReportSerialWise):
                            reportPath = Global.InventoryReportPath + @"rptReportPath";
                            reportName = "rptReportName";
                            break;
                        case nameof(RepCase.StockReportItemAndSerialWise):
                            reportPath = Global.InventoryReportPath + @"rptReportPath";
                            reportName = "rptReportName";
                            break;
                        case nameof(RepCase.StockReportItemSerialAndPriceWise):
                            reportPath = Global.InventoryReportPath + @"rptReportPath";
                            reportName = "rptReportName";
                            break;
                        default:
                            break;
                    }
                    break;

                default:
                    break;
            }
            return new Tuple<string, string>(reportName, reportPath);
        }

        private Dictionary<string, string> GetReportParams()
        {
            Dictionary<string, string> dictParm = new Dictionary<string, string>();
            //dictParm.Add("pmrReportName", "Stock Report Item Wise");
            return dictParm;
        }

        private void txtCompCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                DataTable dt = SqlQuery.Read(con, tran, Global.ConnectionString, $"SELECT CompCode as TransNo FROM Inventory_Company WITH(NOLOCK)");
                frmFilter frm = new frmFilter(dt, dtCompCode);
                frm.FormClosed += (Obj, key) =>
                {
                    var filter = Obj as frmFilter;
                    dtCompCode = filter.DtFilterdRows.Copy();
                    if (dtCompCode.Rows.Count > 0)
                    {
                        StringBuilder SerialNoBuilder = new StringBuilder();
                        foreach (DataRow row in dtCompCode.Rows)
                        {
                            string transNo = row["TransNo"].ToString();
                            SerialNoBuilder.Append($"'{transNo}',");
                        }
                        txtCompCode.Text = SerialNoBuilder.ToString().TrimEnd(',');
                        CompCode = txtCompCode.Text;
                    }
                    else
                    {
                        CompCode = txtCompCode.Text = string.Empty;
                    }
                };
                frm.ShowDialog();
            }
        }

       

        private void txtCategory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                DataTable dt = SqlQuery.Read(con, tran, Global.ConnectionString, $"SELECT CatID AS TransNo FROM Inventory_Category WITH(NOLOCK)");
                frmFilter frm = new frmFilter(dt, dtCatCode);
                frm.FormClosed += (Obj, key) =>
                {
                    var filter = Obj as frmFilter;
                    dtCatCode = filter.DtFilterdRows.Copy();
                    if (dtCatCode.Rows.Count > 0)
                    {
                        StringBuilder CatCodeBuilder = new StringBuilder();
                        foreach (DataRow row in dtCatCode.Rows)
                        {
                            string transNo = row["TransNo"].ToString();
                            CatCodeBuilder.Append($"'{transNo}',");
                        }
                        txtCategory.Text = CatCodeBuilder.ToString().TrimEnd(',');
                        CatCode = txtCategory.Text;
                    }
                    else
                    {
                        CatCode = txtCategory.Text = string.Empty;
                    }
                };
                frm.ShowDialog();
            }
        }

        private void txtProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                DataTable dtQuery = SqlQuery.Read(con, tran, Global.ConnectionString, $"SELECT ProdCode AS TransNo FROM Inventory_Products WITH(NOLOCK)");
                frmFilter frm = new frmFilter(dtQuery, dtProdCode);
                frm.FormClosed += (Obj, key) =>
                {
                    var filter = Obj as frmFilter;
                    dtProdCode = filter.DtFilterdRows.Copy();
                    if (dtProdCode.Rows.Count > 0)
                    {
                        StringBuilder ProdCodeBuilder = new StringBuilder();
                        foreach (DataRow row in dtProdCode.Rows)
                        {
                            string transNo = row["TransNo"].ToString();
                            ProdCodeBuilder.Append($"'{transNo}',");
                        }
                        txtProduct.Text = ProdCodeBuilder.ToString().TrimEnd(',');
                        ProdCode = txtProduct.Text;
                    }
                    else
                    {
                        ProdCode = txtProduct.Text = string.Empty;
                    }
                };
                frm.ShowDialog();
            }
        }
        private void txtItemCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                DataTable dtQuery = SqlQuery.Read(con, tran, Global.ConnectionString, $"SELECT ItemCode as TransNo FROM Inventory_Items where Active = 1");
                frmFilter frm = new frmFilter(dtQuery, DtItemcode);
                frm.FormClosed += (Obj, key) =>
                {
                    var filter = Obj as frmFilter;
                    DtItemcode = filter.DtFilterdRows.Copy();
                    if (DtItemcode.Rows.Count > 0)
                    {
                        StringBuilder itemCodeBuilder = new StringBuilder();
                        foreach (DataRow row in DtItemcode.Rows)
                        {
                            string transNo = row["TransNo"].ToString();
                            itemCodeBuilder.Append($"'{transNo}',");
                        }
                        txtItemCode.Text = itemCodeBuilder.ToString().TrimEnd(',');
                        ItemCode = txtItemCode.Text;
                    }
                    else
                    {
                        ItemCode = txtItemCode.Text = string.Empty;
                    }
                };
                frm.ShowDialog();
            }
        }
    }
}
