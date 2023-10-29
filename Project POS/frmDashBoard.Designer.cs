using System.Drawing;
using System.Windows.Forms;

namespace POS
{
    partial class frmDashBoard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDashBoard));
            PanelMenu = new Panel();
            Sale_Panel = new Panel();
            btnSaleRep = new Button();
            btnSaleReturn = new Button();
            btnCustomerPayment = new Button();
            btn_SaleItem = new Button();
            btnCustomer = new Button();
            btnSale = new Button();
            Purchase_Panel = new Panel();
            btnPurchaseRep = new Button();
            btnStore = new Button();
            btnStoreType = new Button();
            btnPurchaseReturn = new Button();
            btnSupplierPayment = new Button();
            btnPurchaseItem = new Button();
            btnSupplier = new Button();
            btnPurchase = new Button();
            Inventory_Panel = new Panel();
            btnInvRep = new Button();
            btnItem = new Button();
            btnProduct = new Button();
            btnCategory = new Button();
            btnCompany = new Button();
            btnInventory = new Button();
            pictureBox1 = new PictureBox();
            PanelLoadForms = new Panel();
            PanelMenu.SuspendLayout();
            Sale_Panel.SuspendLayout();
            Purchase_Panel.SuspendLayout();
            Inventory_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // PanelMenu
            // 
            PanelMenu.AutoScroll = true;
            PanelMenu.BackColor = SystemColors.GradientActiveCaption;
            PanelMenu.Controls.Add(Sale_Panel);
            PanelMenu.Controls.Add(btnSale);
            PanelMenu.Controls.Add(Purchase_Panel);
            PanelMenu.Controls.Add(btnPurchase);
            PanelMenu.Controls.Add(Inventory_Panel);
            PanelMenu.Controls.Add(btnInventory);
            PanelMenu.Controls.Add(pictureBox1);
            PanelMenu.Dock = DockStyle.Left;
            PanelMenu.Location = new Point(0, 0);
            PanelMenu.Name = "PanelMenu";
            PanelMenu.Size = new Size(202, 938);
            PanelMenu.TabIndex = 0;
            // 
            // Sale_Panel
            // 
            Sale_Panel.BackColor = SystemColors.GradientInactiveCaption;
            Sale_Panel.Controls.Add(btnSaleRep);
            Sale_Panel.Controls.Add(btnSaleReturn);
            Sale_Panel.Controls.Add(btnCustomerPayment);
            Sale_Panel.Controls.Add(btn_SaleItem);
            Sale_Panel.Controls.Add(btnCustomer);
            Sale_Panel.Dock = DockStyle.Top;
            Sale_Panel.Location = new Point(0, 623);
            Sale_Panel.Name = "Sale_Panel";
            Sale_Panel.Size = new Size(202, 159);
            Sale_Panel.TabIndex = 6;
            // 
            // btnSaleRep
            // 
            btnSaleRep.BackColor = Color.Transparent;
            btnSaleRep.Dock = DockStyle.Top;
            btnSaleRep.FlatAppearance.BorderSize = 0;
            btnSaleRep.FlatStyle = FlatStyle.Flat;
            btnSaleRep.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnSaleRep.ForeColor = SystemColors.ControlDarkDark;
            btnSaleRep.Location = new Point(0, 124);
            btnSaleRep.Name = "btnSaleRep";
            btnSaleRep.Padding = new Padding(30, 0, 0, 0);
            btnSaleRep.Size = new Size(202, 35);
            btnSaleRep.TabIndex = 4;
            btnSaleRep.Text = "Report";
            btnSaleRep.TextAlign = ContentAlignment.MiddleLeft;
            btnSaleRep.UseVisualStyleBackColor = false;
            // 
            // btnSaleReturn
            // 
            btnSaleReturn.BackColor = Color.Transparent;
            btnSaleReturn.Dock = DockStyle.Top;
            btnSaleReturn.FlatAppearance.BorderSize = 0;
            btnSaleReturn.FlatStyle = FlatStyle.Flat;
            btnSaleReturn.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnSaleReturn.ForeColor = SystemColors.ControlDarkDark;
            btnSaleReturn.Location = new Point(0, 93);
            btnSaleReturn.Name = "btnSaleReturn";
            btnSaleReturn.Padding = new Padding(30, 0, 0, 0);
            btnSaleReturn.Size = new Size(202, 31);
            btnSaleReturn.TabIndex = 3;
            btnSaleReturn.Text = "Sale Return";
            btnSaleReturn.TextAlign = ContentAlignment.MiddleLeft;
            btnSaleReturn.UseVisualStyleBackColor = false;
            btnSaleReturn.Click += btnSaleReturn_Click;
            // 
            // btnCustomerPayment
            // 
            btnCustomerPayment.BackColor = Color.Transparent;
            btnCustomerPayment.Dock = DockStyle.Top;
            btnCustomerPayment.FlatAppearance.BorderSize = 0;
            btnCustomerPayment.FlatStyle = FlatStyle.Flat;
            btnCustomerPayment.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnCustomerPayment.ForeColor = SystemColors.ControlDarkDark;
            btnCustomerPayment.Location = new Point(0, 62);
            btnCustomerPayment.Name = "btnCustomerPayment";
            btnCustomerPayment.Padding = new Padding(30, 0, 0, 0);
            btnCustomerPayment.Size = new Size(202, 31);
            btnCustomerPayment.TabIndex = 2;
            btnCustomerPayment.Text = "Customer Payment";
            btnCustomerPayment.TextAlign = ContentAlignment.MiddleLeft;
            btnCustomerPayment.UseVisualStyleBackColor = false;
            // 
            // btn_SaleItem
            // 
            btn_SaleItem.BackColor = Color.Transparent;
            btn_SaleItem.Dock = DockStyle.Top;
            btn_SaleItem.FlatAppearance.BorderSize = 0;
            btn_SaleItem.FlatStyle = FlatStyle.Flat;
            btn_SaleItem.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btn_SaleItem.ForeColor = SystemColors.ControlDarkDark;
            btn_SaleItem.Location = new Point(0, 31);
            btn_SaleItem.Name = "btn_SaleItem";
            btn_SaleItem.Padding = new Padding(30, 0, 0, 0);
            btn_SaleItem.Size = new Size(202, 31);
            btn_SaleItem.TabIndex = 1;
            btn_SaleItem.Text = "Sale Item";
            btn_SaleItem.TextAlign = ContentAlignment.MiddleLeft;
            btn_SaleItem.UseVisualStyleBackColor = false;
            btn_SaleItem.Click += btn_SaleItem_Click;
            // 
            // btnCustomer
            // 
            btnCustomer.BackColor = Color.Transparent;
            btnCustomer.Dock = DockStyle.Top;
            btnCustomer.FlatAppearance.BorderSize = 0;
            btnCustomer.FlatStyle = FlatStyle.Flat;
            btnCustomer.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnCustomer.ForeColor = SystemColors.ControlDarkDark;
            btnCustomer.Location = new Point(0, 0);
            btnCustomer.Name = "btnCustomer";
            btnCustomer.Padding = new Padding(30, 0, 0, 0);
            btnCustomer.Size = new Size(202, 31);
            btnCustomer.TabIndex = 0;
            btnCustomer.Text = "Customer";
            btnCustomer.TextAlign = ContentAlignment.MiddleLeft;
            btnCustomer.UseVisualStyleBackColor = false;
            btnCustomer.Click += btnCustomer_Click;
            // 
            // btnSale
            // 
            btnSale.BackColor = Color.Transparent;
            btnSale.Dock = DockStyle.Top;
            btnSale.FlatAppearance.BorderSize = 0;
            btnSale.FlatStyle = FlatStyle.Flat;
            btnSale.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnSale.ForeColor = SystemColors.ControlDarkDark;
            btnSale.Image = (Image)resources.GetObject("btnSale.Image");
            btnSale.ImageAlign = ContentAlignment.MiddleLeft;
            btnSale.Location = new Point(0, 588);
            btnSale.Margin = new Padding(0);
            btnSale.Name = "btnSale";
            btnSale.Padding = new Padding(10, 0, 0, 0);
            btnSale.Size = new Size(202, 35);
            btnSale.TabIndex = 5;
            btnSale.Text = "Sale";
            btnSale.TextAlign = ContentAlignment.MiddleLeft;
            btnSale.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSale.UseVisualStyleBackColor = false;
            btnSale.Click += btnSale_Click;
            // 
            // Purchase_Panel
            // 
            Purchase_Panel.BackColor = SystemColors.GradientInactiveCaption;
            Purchase_Panel.Controls.Add(btnPurchaseRep);
            Purchase_Panel.Controls.Add(btnStore);
            Purchase_Panel.Controls.Add(btnStoreType);
            Purchase_Panel.Controls.Add(btnPurchaseReturn);
            Purchase_Panel.Controls.Add(btnSupplierPayment);
            Purchase_Panel.Controls.Add(btnPurchaseItem);
            Purchase_Panel.Controls.Add(btnSupplier);
            Purchase_Panel.Dock = DockStyle.Top;
            Purchase_Panel.Location = new Point(0, 354);
            Purchase_Panel.Name = "Purchase_Panel";
            Purchase_Panel.Size = new Size(202, 234);
            Purchase_Panel.TabIndex = 4;
            // 
            // btnPurchaseRep
            // 
            btnPurchaseRep.BackColor = Color.Transparent;
            btnPurchaseRep.Dock = DockStyle.Top;
            btnPurchaseRep.FlatAppearance.BorderSize = 0;
            btnPurchaseRep.FlatStyle = FlatStyle.Flat;
            btnPurchaseRep.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnPurchaseRep.ForeColor = SystemColors.ControlDarkDark;
            btnPurchaseRep.Location = new Point(0, 196);
            btnPurchaseRep.Name = "btnPurchaseRep";
            btnPurchaseRep.Padding = new Padding(30, 0, 0, 0);
            btnPurchaseRep.Size = new Size(202, 38);
            btnPurchaseRep.TabIndex = 6;
            btnPurchaseRep.Text = "Report";
            btnPurchaseRep.TextAlign = ContentAlignment.MiddleLeft;
            btnPurchaseRep.UseVisualStyleBackColor = false;
            // 
            // btnStore
            // 
            btnStore.BackColor = Color.Transparent;
            btnStore.Dock = DockStyle.Top;
            btnStore.FlatAppearance.BorderSize = 0;
            btnStore.FlatStyle = FlatStyle.Flat;
            btnStore.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnStore.ForeColor = SystemColors.ControlDarkDark;
            btnStore.Location = new Point(0, 159);
            btnStore.Name = "btnStore";
            btnStore.Padding = new Padding(30, 0, 0, 0);
            btnStore.Size = new Size(202, 37);
            btnStore.TabIndex = 5;
            btnStore.Text = "Store";
            btnStore.TextAlign = ContentAlignment.MiddleLeft;
            btnStore.UseVisualStyleBackColor = false;
            btnStore.Click += btnStore_Click;
            // 
            // btnStoreType
            // 
            btnStoreType.BackColor = Color.Transparent;
            btnStoreType.Dock = DockStyle.Top;
            btnStoreType.FlatAppearance.BorderSize = 0;
            btnStoreType.FlatStyle = FlatStyle.Flat;
            btnStoreType.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnStoreType.ForeColor = SystemColors.ControlDarkDark;
            btnStoreType.Location = new Point(0, 128);
            btnStoreType.Name = "btnStoreType";
            btnStoreType.Padding = new Padding(30, 0, 0, 0);
            btnStoreType.Size = new Size(202, 31);
            btnStoreType.TabIndex = 4;
            btnStoreType.Text = "Store Type";
            btnStoreType.TextAlign = ContentAlignment.MiddleLeft;
            btnStoreType.UseVisualStyleBackColor = false;
            btnStoreType.Click += btnStoreType_Click;
            // 
            // btnPurchaseReturn
            // 
            btnPurchaseReturn.BackColor = Color.Transparent;
            btnPurchaseReturn.Dock = DockStyle.Top;
            btnPurchaseReturn.FlatAppearance.BorderSize = 0;
            btnPurchaseReturn.FlatStyle = FlatStyle.Flat;
            btnPurchaseReturn.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnPurchaseReturn.ForeColor = SystemColors.ControlDarkDark;
            btnPurchaseReturn.Location = new Point(0, 93);
            btnPurchaseReturn.Name = "btnPurchaseReturn";
            btnPurchaseReturn.Padding = new Padding(30, 0, 0, 0);
            btnPurchaseReturn.Size = new Size(202, 35);
            btnPurchaseReturn.TabIndex = 3;
            btnPurchaseReturn.Text = "Purchase Return";
            btnPurchaseReturn.TextAlign = ContentAlignment.MiddleLeft;
            btnPurchaseReturn.UseVisualStyleBackColor = false;
            btnPurchaseReturn.Click += btnPurchaseReturn_Click;
            // 
            // btnSupplierPayment
            // 
            btnSupplierPayment.BackColor = Color.Transparent;
            btnSupplierPayment.Dock = DockStyle.Top;
            btnSupplierPayment.FlatAppearance.BorderSize = 0;
            btnSupplierPayment.FlatStyle = FlatStyle.Flat;
            btnSupplierPayment.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnSupplierPayment.ForeColor = SystemColors.ControlDarkDark;
            btnSupplierPayment.Location = new Point(0, 62);
            btnSupplierPayment.Name = "btnSupplierPayment";
            btnSupplierPayment.Padding = new Padding(30, 0, 0, 0);
            btnSupplierPayment.Size = new Size(202, 31);
            btnSupplierPayment.TabIndex = 2;
            btnSupplierPayment.Text = "Supplier Payment";
            btnSupplierPayment.TextAlign = ContentAlignment.MiddleLeft;
            btnSupplierPayment.UseVisualStyleBackColor = false;
            // 
            // btnPurchaseItem
            // 
            btnPurchaseItem.BackColor = Color.Transparent;
            btnPurchaseItem.Dock = DockStyle.Top;
            btnPurchaseItem.FlatAppearance.BorderSize = 0;
            btnPurchaseItem.FlatStyle = FlatStyle.Flat;
            btnPurchaseItem.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnPurchaseItem.ForeColor = SystemColors.ControlDarkDark;
            btnPurchaseItem.Location = new Point(0, 31);
            btnPurchaseItem.Name = "btnPurchaseItem";
            btnPurchaseItem.Padding = new Padding(30, 0, 0, 0);
            btnPurchaseItem.Size = new Size(202, 31);
            btnPurchaseItem.TabIndex = 1;
            btnPurchaseItem.Text = "Purchase Item";
            btnPurchaseItem.TextAlign = ContentAlignment.MiddleLeft;
            btnPurchaseItem.UseVisualStyleBackColor = false;
            btnPurchaseItem.Click += btnPurchaseItem_Click;
            // 
            // btnSupplier
            // 
            btnSupplier.BackColor = Color.Transparent;
            btnSupplier.Dock = DockStyle.Top;
            btnSupplier.FlatAppearance.BorderSize = 0;
            btnSupplier.FlatStyle = FlatStyle.Flat;
            btnSupplier.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnSupplier.ForeColor = SystemColors.ControlDarkDark;
            btnSupplier.Location = new Point(0, 0);
            btnSupplier.Name = "btnSupplier";
            btnSupplier.Padding = new Padding(30, 0, 0, 0);
            btnSupplier.Size = new Size(202, 31);
            btnSupplier.TabIndex = 0;
            btnSupplier.Text = "Supplier";
            btnSupplier.TextAlign = ContentAlignment.MiddleLeft;
            btnSupplier.UseVisualStyleBackColor = false;
            btnSupplier.Click += btnSupplier_Click;
            // 
            // btnPurchase
            // 
            btnPurchase.BackColor = Color.Transparent;
            btnPurchase.Dock = DockStyle.Top;
            btnPurchase.FlatAppearance.BorderSize = 0;
            btnPurchase.FlatStyle = FlatStyle.Flat;
            btnPurchase.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnPurchase.ForeColor = SystemColors.ControlDarkDark;
            btnPurchase.Image = (Image)resources.GetObject("btnPurchase.Image");
            btnPurchase.ImageAlign = ContentAlignment.MiddleLeft;
            btnPurchase.Location = new Point(0, 319);
            btnPurchase.Margin = new Padding(0);
            btnPurchase.Name = "btnPurchase";
            btnPurchase.Padding = new Padding(10, 0, 0, 0);
            btnPurchase.Size = new Size(202, 35);
            btnPurchase.TabIndex = 3;
            btnPurchase.Text = "Purchase";
            btnPurchase.TextAlign = ContentAlignment.MiddleLeft;
            btnPurchase.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnPurchase.UseVisualStyleBackColor = false;
            btnPurchase.Click += btnPurchase_Click;
            // 
            // Inventory_Panel
            // 
            Inventory_Panel.BackColor = SystemColors.GradientInactiveCaption;
            Inventory_Panel.Controls.Add(btnInvRep);
            Inventory_Panel.Controls.Add(btnItem);
            Inventory_Panel.Controls.Add(btnProduct);
            Inventory_Panel.Controls.Add(btnCategory);
            Inventory_Panel.Controls.Add(btnCompany);
            Inventory_Panel.Dock = DockStyle.Top;
            Inventory_Panel.Location = new Point(0, 160);
            Inventory_Panel.Name = "Inventory_Panel";
            Inventory_Panel.Size = new Size(202, 159);
            Inventory_Panel.TabIndex = 2;
            // 
            // btnInvRep
            // 
            btnInvRep.BackColor = Color.Transparent;
            btnInvRep.Dock = DockStyle.Top;
            btnInvRep.FlatAppearance.BorderSize = 0;
            btnInvRep.FlatStyle = FlatStyle.Flat;
            btnInvRep.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnInvRep.ForeColor = SystemColors.ControlDarkDark;
            btnInvRep.Location = new Point(0, 121);
            btnInvRep.Name = "btnInvRep";
            btnInvRep.Padding = new Padding(30, 0, 0, 0);
            btnInvRep.Size = new Size(202, 38);
            btnInvRep.TabIndex = 4;
            btnInvRep.Text = "Report";
            btnInvRep.TextAlign = ContentAlignment.MiddleLeft;
            btnInvRep.UseVisualStyleBackColor = false;
            btnInvRep.Click += btnInvRep_Click;
            // 
            // btnItem
            // 
            btnItem.BackColor = Color.Transparent;
            btnItem.Dock = DockStyle.Top;
            btnItem.FlatAppearance.BorderSize = 0;
            btnItem.FlatStyle = FlatStyle.Flat;
            btnItem.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnItem.ForeColor = SystemColors.ControlDarkDark;
            btnItem.Location = new Point(0, 93);
            btnItem.Name = "btnItem";
            btnItem.Padding = new Padding(30, 0, 0, 0);
            btnItem.Size = new Size(202, 28);
            btnItem.TabIndex = 3;
            btnItem.Text = "Item";
            btnItem.TextAlign = ContentAlignment.MiddleLeft;
            btnItem.UseVisualStyleBackColor = false;
            btnItem.Click += btnItem_Click;
            // 
            // btnProduct
            // 
            btnProduct.BackColor = Color.Transparent;
            btnProduct.Dock = DockStyle.Top;
            btnProduct.FlatAppearance.BorderSize = 0;
            btnProduct.FlatStyle = FlatStyle.Flat;
            btnProduct.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnProduct.ForeColor = SystemColors.ControlDarkDark;
            btnProduct.Location = new Point(0, 62);
            btnProduct.Name = "btnProduct";
            btnProduct.Padding = new Padding(30, 0, 0, 0);
            btnProduct.Size = new Size(202, 31);
            btnProduct.TabIndex = 2;
            btnProduct.Text = "Product";
            btnProduct.TextAlign = ContentAlignment.MiddleLeft;
            btnProduct.UseVisualStyleBackColor = false;
            btnProduct.Click += btnProduct_Click;
            // 
            // btnCategory
            // 
            btnCategory.BackColor = Color.Transparent;
            btnCategory.Dock = DockStyle.Top;
            btnCategory.FlatAppearance.BorderSize = 0;
            btnCategory.FlatStyle = FlatStyle.Flat;
            btnCategory.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnCategory.ForeColor = SystemColors.ControlDarkDark;
            btnCategory.Location = new Point(0, 31);
            btnCategory.Name = "btnCategory";
            btnCategory.Padding = new Padding(30, 0, 0, 0);
            btnCategory.Size = new Size(202, 31);
            btnCategory.TabIndex = 1;
            btnCategory.Text = "Category";
            btnCategory.TextAlign = ContentAlignment.MiddleLeft;
            btnCategory.UseVisualStyleBackColor = false;
            btnCategory.Click += btnCategory_Click;
            // 
            // btnCompany
            // 
            btnCompany.BackColor = Color.Transparent;
            btnCompany.Dock = DockStyle.Top;
            btnCompany.FlatAppearance.BorderSize = 0;
            btnCompany.FlatStyle = FlatStyle.Flat;
            btnCompany.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnCompany.ForeColor = SystemColors.ControlDarkDark;
            btnCompany.Location = new Point(0, 0);
            btnCompany.Name = "btnCompany";
            btnCompany.Padding = new Padding(30, 0, 0, 0);
            btnCompany.Size = new Size(202, 31);
            btnCompany.TabIndex = 0;
            btnCompany.Text = "Company";
            btnCompany.TextAlign = ContentAlignment.MiddleLeft;
            btnCompany.UseVisualStyleBackColor = false;
            btnCompany.Click += btnCompany_Click;
            // 
            // btnInventory
            // 
            btnInventory.BackColor = Color.Transparent;
            btnInventory.Dock = DockStyle.Top;
            btnInventory.FlatAppearance.BorderSize = 0;
            btnInventory.FlatStyle = FlatStyle.Flat;
            btnInventory.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnInventory.ForeColor = SystemColors.ControlDarkDark;
            btnInventory.Image = (Image)resources.GetObject("btnInventory.Image");
            btnInventory.ImageAlign = ContentAlignment.MiddleLeft;
            btnInventory.Location = new Point(0, 125);
            btnInventory.Margin = new Padding(0);
            btnInventory.Name = "btnInventory";
            btnInventory.Padding = new Padding(10, 0, 0, 0);
            btnInventory.Size = new Size(202, 35);
            btnInventory.TabIndex = 1;
            btnInventory.Text = "Inventory";
            btnInventory.TextAlign = ContentAlignment.MiddleLeft;
            btnInventory.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnInventory.UseVisualStyleBackColor = false;
            btnInventory.Click += btnInventory_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Top;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(202, 125);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // PanelLoadForms
            // 
            PanelLoadForms.Location = new Point(208, 12);
            PanelLoadForms.Name = "PanelLoadForms";
            PanelLoadForms.Size = new Size(1571, 914);
            PanelLoadForms.TabIndex = 1;
            // 
            // frmDashBoard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1791, 938);
            Controls.Add(PanelLoadForms);
            Controls.Add(PanelMenu);
            Margin = new Padding(3, 2, 3, 2);
            Name = "frmDashBoard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DashBoard (Rights Owner Fakhir-Gohar) fakhirgohar@gmail.com";
            WindowState = FormWindowState.Maximized;
            Load += frmDashBoard_Load;
            PanelMenu.ResumeLayout(false);
            Sale_Panel.ResumeLayout(false);
            Purchase_Panel.ResumeLayout(false);
            Inventory_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelMenu;
        private Panel Inventory_Panel;
        private Button btnItem;
        private Button btnProduct;
        private Button btnCategory;
        private Button btnCompany;
        private Button btnInventory;
        private PictureBox pictureBox1;
        private Panel Sale_Panel;
        private Button btnSaleReturn;
        private Button btnCustomerPayment;
        private Button btn_SaleItem;
        private Button btnCustomer;
        private Button btnSale;
        private Panel Purchase_Panel;
        private Button btnPurchaseReturn;
        private Button btnSupplierPayment;
        private Button btnPurchaseItem;
        private Button btnSupplier;
        private Button btnPurchase;
        private Button btnStore;
        private Button btnStoreType;
        private Panel PanelLoadForms;
        private Button button3;
        private Button btnInvRep;
        private Button btnPurchaseRep;
        private Button btnSaleRep;
    }
}