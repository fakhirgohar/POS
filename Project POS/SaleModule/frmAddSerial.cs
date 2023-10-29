using Project_POS.Classes;
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

namespace Project_POS.SaleModule
{
    public partial class frmAddSerial : Form
    {
        public frmAddSerial()
        {
            InitializeComponent();
        }

        SqlConnection con; SqlTransaction tran;
        public DataTable dtSrDetail = new DataTable();
        public DataTable dtTemp = new DataTable();
        public DataTable dtFinalResult = new DataTable();
        private bool HideCondition = false;
        public frmAddSerial(string ItemCode, DataTable dtCeckRows, string Query = "", bool HideSPrice = false)
        {
            InitializeComponent();
            HideCondition = HideSPrice;
            dtSrDetail.Clear();
            if (HideCondition)
            {
                lblItemCode.Text = string.Empty;
                lblItemCode.Text = ItemCode;
                txtSPrice.Visible = false;
                lblItemCode.Visible = false;
                label1.Visible = false;
                label3.Visible = false;
            }
            if (Query == "" || string.IsNullOrEmpty(Query.Trim()))
            {
                dtSrDetail = SqlQuery.Read(con, tran, Global.ConnectionString, $"SELECT ITD.Sno, ITD.ItemCode, ITD.ItemName, ITD.SerialNo, ITD.Qty, ITD.StoreID, IPD.PPrice, '' as SPrice FROM Inventory_ItemsDetail ITD WITH(NOLOCK) RIGHT JOIN Inventory_PurchaseDetail IPD WITH(NOLOCK) ON ITD.SerialNo = IPD.SerialNo WHERE ITD.ItemCode = '{ItemCode}'");
            }
            else
            {
                dtSrDetail = SqlQuery.Read(con, tran, Global.ConnectionString, Query);
            }
            List<DataRow> rowsToRemove = new List<DataRow>();
            foreach (DataRow CheckRow in dtCeckRows.Rows)
            {
                foreach (DataRow DetailRow in dtSrDetail.Rows)
                {
                    if (CheckRow["SerialNo"].ToString() == DetailRow["SerialNo"].ToString())
                    {
                        rowsToRemove.Add(DetailRow);
                    }
                }
            }
            //dtSrDetail.Columns.Add("SPrice", typeof(string));
            foreach (DataRow rowToRemove in rowsToRemove)
            {
                dtSrDetail.Rows.Remove(rowToRemove);
            }
            dgvAddSerial.DataSource = null;
            dgvAddSerial.DataSource = dtSrDetail;

            dgvAddSerial.Columns["Sno"].Width = 40;
            dgvAddSerial.Columns["ItemCode"].Width = 150;
            dgvAddSerial.Columns["ItemName"].Width = 180;
            dgvAddSerial.Columns["SerialNo"].Width = 180;
            dgvAddSerial.Columns["StoreID"].Width = 60;
            dgvAddSerial.Columns["Qty"].Width = 60;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (!HideCondition)
            {
                if (txtSPrice.Value == 0 || txtSPrice.Text == "")
                {
                    MessageBox.Show(this, $"Please Enter Sale Price For Selected Serials !", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1); return;
                }
            }

            if (dgvAddSerial.Rows.Count > 0)
            {

                dtTemp = dtSrDetail.Clone();
                dtTemp.Columns["SPrice"].MaxLength = 100;
                foreach (DataGridViewRow row in dgvAddSerial.Rows)
                {
                    DataGridViewCheckBoxCell checkBoxCell = row.Cells["dgvCheck"] as DataGridViewCheckBoxCell;
                    bool isChecked = Convert.ToBoolean(checkBoxCell.Value);
                    if (isChecked)
                    {
                        DataRow newRow = dtTemp.NewRow();
                        newRow["ItemCode"] = row.Cells["ItemCode"].Value;
                        newRow["ItemName"] = row.Cells["ItemName"].Value;
                        newRow["SerialNo"] = row.Cells["SerialNo"].Value;
                        newRow["Qty"] = row.Cells["Qty"].Value;
                        newRow["StoreID"] = row.Cells["StoreID"].Value;
                        if (!HideCondition) { newRow["SPrice"] = txtSPrice.Value.ToString(); }
                        else { newRow["SPrice"] = row.Cells["SPrice"].Value; }
                        newRow["PPrice"] = row.Cells["PPrice"].Value;
                        dtTemp.Rows.Add(newRow);
                    }
                }

                dtSrDetail.Clear();
                dtSrDetail = dtTemp.Copy();
                dtFinalResult = dtSrDetail.Copy();
                dtSrDetail.Clear();
            }
            this.Close();
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            foreach (DataGridViewRow row in dgvAddSerial.Rows)
            {
                DataGridViewCheckBoxCell checkBoxCell = row.Cells["dgvCheck"] as DataGridViewCheckBoxCell;
                checkBoxCell.Value = checkBox.Checked;
            }
        }
    }
}
