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

        public frmFilter()
        {
            InitializeComponent();
        }

        public frmFilter(DataTable DT)
        {
            InitializeComponent();
            DtDetial.Clear();
            DtDetial = DT.Copy();
            LoadData();
        }

        private void LoadData()
        {
            dgvDetail.DataSource = DtDetial;
        }

        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                MessageBox.Show("add button click");

                
            }
        }
    }
}
