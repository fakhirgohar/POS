using Project_POS.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            //Stock Report Item Wise
            //Stock Report Serial Wise
            //Stock Report Item & Serial Wise
            //Stock Report Item, Serial &Price Wise


            //Current Stock
            //Back Date Stock

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
                    dtReports = CurrentStock();
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

            //frmReportViewer FrmReport = new frmReportViewer(rptNamePath.Item2, dataSets, dictReportParams);
            frmReportVeiwer FrmReport = new frmReportVeiwer(dtReports);
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

        private DataTable CurrentStock()
        {
            DataTable dt = new DataTable();

            switch (cboRepCase.SelectedItem.ToString().Replace(" ", ""))
            {
                case nameof(RepCase.StockReportItemWise):
                    dt = SqlQuery.Read(Global.Con, Global.tran, Global.ConnectionString, "SELECT DISTINCT ItemCode, SUM(Qty) AS QTY FROM FN_CURRENT_STOCK() GROUP BY ItemCode");
                    break;
                case nameof(RepCase.StockReportSerialWise):
                    dt = SqlQuery.Read(Global.Con, Global.tran, Global.ConnectionString, "SELECT SerialNo, Qty FROM FN_CURRENT_STOCK()");
                    break;
                case nameof(RepCase.StockReportItemAndSerialWise):
                    dt = SqlQuery.Read(Global.Con, Global.tran, Global.ConnectionString, "SELECT ItemCode, ItemName, SerialNo, Qty FROM FN_CURRENT_STOCK()");
                    break;
                case nameof(RepCase.StockReportItemSerialAndPriceWise):
                    dt = SqlQuery.Read(Global.Con, Global.tran, Global.ConnectionString, "SELECT ItemCode, ItemName, SerialNo, Qty, (SELECT PPrice FROM Inventory_PurchaseDetail IPD WITH(NOLOCK) WHERE IPD.ItemCode = FN.ItemCode AND IPD.SerialNo = FN.SerialNo ) AS PPrice FROM FN_CURRENT_STOCK() FN");
                    break;
                default:
                    break;
            }
            //dt = SqllExtension.Read(Global.Con, Global.tran, Global.ConnectionString, "SELECT * FROM FN_CURRENT_STOCK()");

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
                            reportPath = Global.InventoryReportPath + @"rptReportPath";
                            reportName = "rptReportName";
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
            dictParm.Add("pmrHeader1", "");
            dictParm.Add("pmrHeader2", "");
            return dictParm;
        }
    }
}
