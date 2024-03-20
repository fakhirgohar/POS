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
            InitializeComponent();

            try
            {
                if (CtrlRptVeiwer.LocalReport == null)
                    throw new ApplicationException("LocalReport is not initialized.");

                if (string.IsNullOrEmpty(ReportPath))
                    throw new ApplicationException("ReportPath is not specified.");

                CtrlRptVeiwer.LocalReport.ReportEmbeddedResource = ReportPath;
                CtrlRptVeiwer.LocalReport.ReportPath = ReportPath;

                if (dataSets != null)
                {
                    foreach (var dataset in dataSets)
                    {
                        CtrlRptVeiwer.LocalReport.DataSources.Add(new ReportDataSource(dataset.Key, dataset.Value));
                    }
                }

                if (CtrlRptVeiwer.LocalReport != null)
                {
                    foreach (var parameter in dictReportParams)
                    {
                        CtrlRptVeiwer.LocalReport.SetParameters(new ReportParameter(parameter.Key, parameter.Value));
                    }
                }
                CtrlRptVeiwer.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            this.CtrlRptVeiwer.RefreshReport();
        }
    }
}
