using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_POS
{
    public partial class frmReportVeiwer : Form
    {
        public frmReportVeiwer()
        {
            InitializeComponent();
        }
        public frmReportVeiwer(string ReportPath, Dictionary<string, DataTable> dataSets, Dictionary<string, string> dictReportParams)
        {
            //MessageBox.Show("Method is Under Developement");
            InitializeComponent();
            //CtrlRptVeiwer.LocalReport.ReportPath = ReportPath;
            CtrlRptVeiwer.LocalReport.ReportEmbeddedResource = ReportPath;
            foreach (var dataset in dataSets)
            {
                CtrlRptVeiwer.LocalReport.DataSources.Add(new ReportDataSource(dataset.Key, dataset.Value));
            }
            foreach (var parameter in dictReportParams)
            {
                CtrlRptVeiwer.LocalReport.SetParameters(new ReportParameter(parameter.Key, parameter.Value));
            }
            CtrlRptVeiwer.RefreshReport();
        }

        public frmReportVeiwer(DataTable DtReport)
        {
            InitializeComponent();
            //dgvReport.Rows.Clear();
            //dgvReport.DataSource = DtReport;
        }

        private void LoadDataAndShowReport()
        {
            //// Load your data into a DataTable
            //DataTable dataTable = LoadDataFromDatabaseOrOtherSource();

            //// Set the report data source
            //SetReportDataSource(dataTable);

            //// Refresh the ReportViewer
            //reportViewer.RefreshReport();
        }


        private void SetReportDataSource(DataTable dataTable)
        {
            //ReportDataSource reportDataSource = new ReportDataSource("YourDataSetName", dataTable);
            //reportViewer.LocalReport.DataSources.Clear();
            //reportViewer.LocalReport.DataSources.Add(reportDataSource);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            this.CtrlRptVeiwer.RefreshReport();
        }
    }
}
