using Project_POS.InventoryModule;
using Project_POS.Login;
using Project_POS.PurchaseModule;
using Project_POS.SaleModule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    public partial class frmDashBoard : Form
    {
        public frmDashBoard()
        {
            InitializeComponent();
            //PanelMenu.Enabled = false;
            //frmLoginVerification frm = new frmLoginVerification();
            //frm.TopLevel = false;
            //frm.Parent = PanelLoadForms;
            //int x = (PanelLoadForms.Width - frm.Width) / 2;
            //int y = (PanelLoadForms.Height - frm.Height) / 2;
            //frm.Location = new Point(x, y);
            //PanelLoadForms.Controls.Add(frm);
            //frm.Visible = true;
            //frm.FormClosing += (o, a) =>
            //{ PanelMenu.Enabled = true; };
        }
        public string UserId, UserName = string.Empty;
        private void HideSubMenu()
        {
            if (Inventory_Panel.Visible)
            {
                //Inventory_Panel.Visible = false;
            }
        }

        private void ShowSubMenu(Panel P)
        {
            if (!(P.Visible))
            {
                HideSubMenu();
                P.Visible = true;
            }
            else
                P.Visible = false;
        }
        private void LoadForm(Form frm)
        {
            Type type = frm.GetType();
            if (PanelLoadForms.Controls.OfType<Form>().Any(f => f.GetType() == type))
            {
                MessageBox.Show(this, "This Form is Already Opened!", "Message Box Title", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else
            {
                frm.TopLevel = false;
                frm.Parent = PanelLoadForms;
                frm.StartPosition = FormStartPosition.Manual;
                int x = (PanelLoadForms.Width - frm.Width) / 2;
                int y = (PanelLoadForms.Height - frm.Height) / 2;
                frm.Location = new Point(x, y);
                PanelLoadForms.Controls.Add(frm);
                frm.Visible = true;
                frm.BringToFront();
            }
        }

        private void frmDashBoard_Load_1(object sender, EventArgs e)
        {
            Inventory_Panel.Visible = false;
            Purchase_Panel.Visible = false;
            Sale_Panel.Visible = false;


            //frmLoginVerification frm = new frmLoginVerification();
            //frm.Owner = this;
            //frm.StartPosition = FormStartPosition.CenterParent;
            //frm.ShowDialog();
            //frm.FormClosing += (o, a) =>
            //{
            //    var Key = o as frmLoginVerification;
            //    UserId = Key.UserId;
            //    UserName = Key.UserName;
            //    lblUser.Text = Key.UserName;
            //};
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            ShowSubMenu(Inventory_Panel);
        }

        private void btnCompany_Click(object sender, EventArgs e)
        {
            frmInventoryCompany frm = new frmInventoryCompany();
            LoadForm(frm);
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            frmInventoryCategory frm = new frmInventoryCategory();
            LoadForm(frm);
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            frmInventoryProduct frm = new frmInventoryProduct();
            LoadForm(frm);
        }

        private void btnItem_Click(object sender, EventArgs e)
        {
            frmInventoryItems frm = new frmInventoryItems();
            LoadForm(frm);
        }

        private void btnInvRep_Click(object sender, EventArgs e)
        {
            frmInventoryReports frm = new frmInventoryReports();
            LoadForm(frm);
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            ShowSubMenu(Purchase_Panel);
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            frmSupplier frm = new frmSupplier();
            LoadForm(frm);
        }

        private void btnPurchaseItem_Click(object sender, EventArgs e)
        {
            frmInventoryPurchase frm = new frmInventoryPurchase();
            LoadForm(frm);
        }

        private void btnSupplierPayment_Click(object sender, EventArgs e)
        {

        }

        private void btnPurchaseReturn_Click(object sender, EventArgs e)
        {
            frmInventoryPurchaseReturn frm = new frmInventoryPurchaseReturn();
            LoadForm(frm);
        }

        private void btnStoreType_Click(object sender, EventArgs e)
        {
            frmInventoryStoreType frm = new frmInventoryStoreType();
            LoadForm(frm);
        }

        private void btnStore_Click(object sender, EventArgs e)
        {
            frmInventoryStore frm = new frmInventoryStore();
            LoadForm(frm);
        }

        private void btnPurchaseRep_Click(object sender, EventArgs e)
        {

        }

        private void btnSale_Click(object sender, EventArgs e)
        {
            ShowSubMenu(Sale_Panel);
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            frmInventoryCustomer frm = new frmInventoryCustomer();
            LoadForm(frm);
        }

        private void btn_SaleItem_Click(object sender, EventArgs e)
        {
            frmInventorySale frm = new frmInventorySale();
            LoadForm(frm);
        }

        private void btnCustomerPayment_Click(object sender, EventArgs e)
        {

        }

        private void btnSaleReturn_Click(object sender, EventArgs e)
        {
            frmInventorySaleReturn frm = new frmInventorySaleReturn();
            LoadForm(frm);
        }

        private void btnSaleRep_Click(object sender, EventArgs e)
        {

        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            frmCreateUser frm = new frmCreateUser();
            LoadForm(frm);
        }
    }
}
