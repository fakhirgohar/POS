using Project_POS.Classes;
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

namespace Project_POS.InventoryModule
{
    public partial class frmStockDetail : Form
    {
        public frmStockDetail()
        {
            InitializeComponent();
        }


        SqlConnection con; SqlTransaction tran;
        string ItemsCode, ProdCode, CompCode, CatCode, Serial = string.Empty;
        DataTable DtItemcode, dtProdCode, dtCompCode, dtCatCode, dtSerialNo, dtDetail = new DataTable();

        private void txtCompany_KeyDown(object sender, KeyEventArgs e)
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
                        txtCompany.Text = SerialNoBuilder.ToString().TrimEnd(',');
                        CompCode = txtCompany.Text;
                    }
                    else
                    {
                        CompCode = txtCompany.Text = string.Empty;
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

        private void txtitemCode_KeyDown(object sender, KeyEventArgs e)
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
                        txtitemCode.Text = itemCodeBuilder.ToString().TrimEnd(',');
                        ItemsCode = txtitemCode.Text;
                    }
                    else
                    {
                        ItemsCode = txtitemCode.Text = string.Empty;
                    }
                };
                frm.ShowDialog();

            }
        }

        private void txtSerial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                DataTable dtQuery = SqlQuery.Read(con, tran, Global.ConnectionString, $"SELECT SerialNo AS TransNo FROM Inventory_ItemsDetail WITH(NOLOCK)");
                frmFilter frm = new frmFilter(dtQuery, dtSerialNo);
                frm.FormClosed += (Obj, key) =>
                {
                    var filter = Obj as frmFilter;
                    dtSerialNo = filter.DtFilterdRows.Copy();
                    if (dtSerialNo.Rows.Count > 0)
                    {
                        StringBuilder itemCodeBuilder = new StringBuilder();
                        foreach (DataRow row in dtSerialNo.Rows)
                        {
                            string transNo = row["TransNo"].ToString();
                            itemCodeBuilder.Append($"'{transNo}',");
                        }
                        txtSerial.Text = itemCodeBuilder.ToString().TrimEnd(',');
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string item = !string.IsNullOrEmpty(txtitemCode.Text.Trim()) ? $"ItemCode IN ({ItemsCode})" : string.Empty;
            string prodCode = !string.IsNullOrEmpty(txtProduct.Text.Trim()) ? $"ProdCode IN ({ProdCode})" : string.Empty;
            string compcode = !string.IsNullOrEmpty(txtCompany.Text.Trim()) ? $"SerialNo IN ({CompCode})" : string.Empty;
            string catCode = !string.IsNullOrEmpty(txtCategory.Text.Trim()) ? $"CatId IN ({CatCode})" : string.Empty;
            string serial = !string.IsNullOrEmpty(txtSerial.Text.Trim()) ? $"SerialNo IN ({Serial})" : string.Empty;
            string WhereClause = string.Join(" AND ", new[] { item, prodCode, compcode, catCode, serial }.Where(s => !string.IsNullOrEmpty(s)));
            WhereClause = !string.IsNullOrEmpty(WhereClause) ? $"WHERE {WhereClause}" : string.Empty;


            dtDetail = SqlQuery.Read(con, tran, Global.ConnectionString, $"SELECT ItemCode, ItemName, SerialNo, Qty, CompName as Company, ProdName as Product, CatName as Category FROM FN_CURRENT_STOCK()   {WhereClause} ");
            dgvDetail.DataSource =  dtDetail;
        }
    }
}
