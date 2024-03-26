using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_POS.InventoryModule
{
    public partial class frmFilter : Form
    {
        public DataTable DtDetial  = new DataTable();
        public DataTable DtFilterdRows = new DataTable();
        bool SingleSelect = false;

        public frmFilter()
        {
            InitializeComponent();
        }

        public frmFilter(DataTable Dt1, DataTable Dt2, bool SingleSelection = false)
        {
            InitializeComponent();
            DtDetial.Clear();
            DtDetial = Dt1.Copy();
            if ( Dt2 != null)
            {
                DtFilterdRows.Clear();
                DtFilterdRows = Dt2.DefaultView.ToTable(false, "TransNo");
                SingleSelect = SingleSelection;
            }
            LoadData();
        }

        private void LoadData()
        {
            
            dgvDetail.DataSource = DtDetial;
            if(DtFilterdRows.Rows.Count > 0)
            {
                dgvFilterdRows.DataSource = DtFilterdRows;
            }
            else
            {
                DtFilterdRows = DtDetial.Clone();
            }
            
        }

        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                DataRow newRow = DtFilterdRows.NewRow();
                newRow["TransNo"] = dgvDetail.Rows[e.RowIndex].Cells["TransNo"].Value;

                if (!SingleSelect)
                {
                    DtFilterdRows.Rows.Add(newRow);
                }
                else
                {
                    DtFilterdRows.Rows.Clear();
                    DtFilterdRows.Rows.Add(newRow);
                }

                dgvFilterdRows.DataSource = DtFilterdRows;

            }
        }

        private void btnAddAll_Click(object sender, EventArgs e)
        {
            DtFilterdRows.Clear();
            DtFilterdRows = DtDetial.Copy();
            dgvFilterdRows.DataSource = DtFilterdRows;
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            DtFilterdRows.Clear();
            dgvFilterdRows.DataSource = DtFilterdRows;
        }

        private void dgvFilterdRows_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                DataRow newRow = DtFilterdRows.NewRow();
                DtFilterdRows.Rows.RemoveAt(e.RowIndex);
                dgvFilterdRows.DataSource = DtFilterdRows;
            }
        }

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
