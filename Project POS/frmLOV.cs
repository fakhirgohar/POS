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

namespace Project_POS
{
    public partial class frmLOV : Form
    {
        public string Code; string ColumnName;
        public DataRow LovSelRow = null;
        DataTable dtGridRec = new DataTable();
        public frmLOV()
        {
            InitializeComponent();
            dgvLov.Focus();
        }

        public void SetData(SqlConnection con, string connectinstring, string query, string KeyColName)
        {
            try
            {
                using (con = new SqlConnection(connectinstring))
                {
                    con.Open();

                    if (con.State != ConnectionState.Open) { con.Open(); }
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    dtGridRec.Load(reader);
                    AddCountColumn();
                    dgvLov.DataSource = null;
                    dgvLov.DataSource = dtGridRec;
                    dgvLov.Columns[0].Width = 40;
                    ColumnName = KeyColName;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public void SetData(SqlConnection con, string connectinstring, string TableName, string KeyColName, List<string> Lst = null)
        {
            try
            {
                using (con = new SqlConnection(connectinstring))
                {
                    con.Open();
                    string query;
                    if (Lst.Count > 0) { query = $"SELECT {string.Join(", ", Lst)} FROM {TableName}"; }
                    else { query = $"SELECT * FROM {TableName}"; }
                    if (con.State != ConnectionState.Open) { con.Open(); }
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    dtGridRec.Load(reader);
                    AddCountColumn();
                    dgvLov.DataSource = null;
                    dgvLov.DataSource = dtGridRec;
                    dgvLov.Columns[0].Width = 40;
                    ColumnName = KeyColName;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void LovGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearch.Text.Trim()) && txtSearch.Text != $"Search Record by {ColumnName}")
            {
                if (dtGridRec.Rows.Count > 0)
                {
                    DataTable dtTemp = new DataTable();
                    string Expression = $"{ColumnName} = '{txtSearch.Text}'";
                    DataRow[] filteredRows = dtGridRec.Select(Expression);
                    if (filteredRows.Any()) { dtTemp = filteredRows.CopyToDataTable(); }
                    dgvLov.DataSource = null;
                    dgvLov.DataSource = dtTemp;
                }
            }
            else
            {
                dgvLov.DataSource = null;
                dgvLov.DataSource = dtGridRec;
            }
        }

        private void EnterText()
        {
            if (txtSearch.Text == string.Empty)
            {
                txtSearch.Text = $"Search Record by {ColumnName}";
                txtSearch.ForeColor = SystemColors.GrayText; // Placeholder text color
            }
        }

        private void frmLOV_Load(object sender, EventArgs e)
        {
            EnterText();
            dgvLov.Focus();
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            EnterText();
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearch.Text.Trim()))
            {
                txtSearch.Text = string.Empty;
                txtSearch.ForeColor = SystemColors.WindowText; // Default text color
            }
        }
        //private void AddGridCountColumn()
        //{
        //    var countColumn = new DataGridViewTextBoxColumn();
        //    countColumn.HeaderText = "#";
        //    countColumn.Name = "#";
        //    countColumn.ReadOnly = true;
        //    countColumn.ValueType = typeof(string);
        //    //countColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
        //    dgvLov.Columns.Insert(0, countColumn);
        //}
        //private void UpdateRowCount()
        //{
        //    if (dgvLov.Rows.Count > 0)
        //    {
        //        for (int i = 0; i < dgvLov.Rows.Count; i++)
        //        {
        //            dgvLov.Rows[i].Cells[0].Value = (i + 1).ToString();
        //        }
        //    }
        //}

        private void AddCountColumn()
        {
            DataTable newDataTable = new DataTable();
            newDataTable.Columns.Add("#", typeof(string));
            foreach (DataColumn column in dtGridRec.Columns)
            {
                newDataTable.Columns.Add(column.ColumnName, column.DataType);
            }
            foreach (DataRow row in dtGridRec.Rows)
            {
                DataRow newRow = newDataTable.NewRow();
                newRow["#"] = "";
                foreach (DataColumn column in dtGridRec.Columns)
                {
                    newRow[column.ColumnName] = row[column.ColumnName];
                }
                newDataTable.Rows.Add(newRow);
            }
            dtGridRec = newDataTable;
            int i = 1;
            foreach (DataRow row in dtGridRec.Rows)
            {
                row["#"] = i;
                i++;
            }
        }

        private void dgvLov_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                Code = dgvLov.Rows[e.RowIndex].Cells[ColumnName].Value.ToString();
                DataGridViewRow selectedRow = dgvLov.Rows[e.RowIndex];
                DataRowView dataRowView = (DataRowView)selectedRow.DataBoundItem;
                LovSelRow = dataRowView.Row;
            }
            Close();
        }
    }
}
