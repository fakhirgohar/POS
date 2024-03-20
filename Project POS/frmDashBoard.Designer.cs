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
            this.PanelMenu = new System.Windows.Forms.Panel();
            this.Sale_Panel = new System.Windows.Forms.Panel();
            this.btnSaleRep = new System.Windows.Forms.Button();
            this.btnSaleReturn = new System.Windows.Forms.Button();
            this.btnCustomerPayment = new System.Windows.Forms.Button();
            this.btn_SaleItem = new System.Windows.Forms.Button();
            this.btnCustomer = new System.Windows.Forms.Button();
            this.btnSale = new System.Windows.Forms.Button();
            this.Purchase_Panel = new System.Windows.Forms.Panel();
            this.btnPurchaseRep = new System.Windows.Forms.Button();
            this.btnStore = new System.Windows.Forms.Button();
            this.btnStoreType = new System.Windows.Forms.Button();
            this.btnPurchaseReturn = new System.Windows.Forms.Button();
            this.btnSupplierPayment = new System.Windows.Forms.Button();
            this.btnPurchaseItem = new System.Windows.Forms.Button();
            this.btnSupplier = new System.Windows.Forms.Button();
            this.btnPurchase = new System.Windows.Forms.Button();
            this.Inventory_Panel = new System.Windows.Forms.Panel();
            this.btnInvRep = new System.Windows.Forms.Button();
            this.btnStockDetail = new System.Windows.Forms.Button();
            this.btnItem = new System.Windows.Forms.Button();
            this.btnProduct = new System.Windows.Forms.Button();
            this.btnCategory = new System.Windows.Forms.Button();
            this.btnCompany = new System.Windows.Forms.Button();
            this.btnInventory = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PanelLoadForms = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.PanelMenu.SuspendLayout();
            this.Sale_Panel.SuspendLayout();
            this.Purchase_Panel.SuspendLayout();
            this.Inventory_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelMenu
            // 
            this.PanelMenu.AutoScroll = true;
            this.PanelMenu.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.PanelMenu.Controls.Add(this.Sale_Panel);
            this.PanelMenu.Controls.Add(this.btnSale);
            this.PanelMenu.Controls.Add(this.Purchase_Panel);
            this.PanelMenu.Controls.Add(this.btnPurchase);
            this.PanelMenu.Controls.Add(this.Inventory_Panel);
            this.PanelMenu.Controls.Add(this.btnInventory);
            this.PanelMenu.Controls.Add(this.pictureBox1);
            this.PanelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelMenu.Location = new System.Drawing.Point(0, 0);
            this.PanelMenu.Name = "PanelMenu";
            this.PanelMenu.Size = new System.Drawing.Size(173, 1043);
            this.PanelMenu.TabIndex = 0;
            // 
            // Sale_Panel
            // 
            this.Sale_Panel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Sale_Panel.Controls.Add(this.btnSaleRep);
            this.Sale_Panel.Controls.Add(this.btnSaleReturn);
            this.Sale_Panel.Controls.Add(this.btnCustomerPayment);
            this.Sale_Panel.Controls.Add(this.btn_SaleItem);
            this.Sale_Panel.Controls.Add(this.btnCustomer);
            this.Sale_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Sale_Panel.Location = new System.Drawing.Point(0, 551);
            this.Sale_Panel.Name = "Sale_Panel";
            this.Sale_Panel.Size = new System.Drawing.Size(173, 138);
            this.Sale_Panel.TabIndex = 6;
            // 
            // btnSaleRep
            // 
            this.btnSaleRep.BackColor = System.Drawing.Color.Transparent;
            this.btnSaleRep.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSaleRep.FlatAppearance.BorderSize = 0;
            this.btnSaleRep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaleRep.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSaleRep.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnSaleRep.Location = new System.Drawing.Point(0, 108);
            this.btnSaleRep.Name = "btnSaleRep";
            this.btnSaleRep.Padding = new System.Windows.Forms.Padding(26, 0, 0, 0);
            this.btnSaleRep.Size = new System.Drawing.Size(173, 30);
            this.btnSaleRep.TabIndex = 4;
            this.btnSaleRep.Text = "Report";
            this.btnSaleRep.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaleRep.UseVisualStyleBackColor = false;
            this.btnSaleRep.Click += new System.EventHandler(this.btnSaleRep_Click);
            // 
            // btnSaleReturn
            // 
            this.btnSaleReturn.BackColor = System.Drawing.Color.Transparent;
            this.btnSaleReturn.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSaleReturn.FlatAppearance.BorderSize = 0;
            this.btnSaleReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaleReturn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSaleReturn.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnSaleReturn.Location = new System.Drawing.Point(0, 81);
            this.btnSaleReturn.Name = "btnSaleReturn";
            this.btnSaleReturn.Padding = new System.Windows.Forms.Padding(26, 0, 0, 0);
            this.btnSaleReturn.Size = new System.Drawing.Size(173, 27);
            this.btnSaleReturn.TabIndex = 3;
            this.btnSaleReturn.Text = "Sale Return";
            this.btnSaleReturn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaleReturn.UseVisualStyleBackColor = false;
            this.btnSaleReturn.Click += new System.EventHandler(this.btnSaleReturn_Click);
            // 
            // btnCustomerPayment
            // 
            this.btnCustomerPayment.BackColor = System.Drawing.Color.Transparent;
            this.btnCustomerPayment.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCustomerPayment.FlatAppearance.BorderSize = 0;
            this.btnCustomerPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomerPayment.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnCustomerPayment.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCustomerPayment.Location = new System.Drawing.Point(0, 54);
            this.btnCustomerPayment.Name = "btnCustomerPayment";
            this.btnCustomerPayment.Padding = new System.Windows.Forms.Padding(26, 0, 0, 0);
            this.btnCustomerPayment.Size = new System.Drawing.Size(173, 27);
            this.btnCustomerPayment.TabIndex = 2;
            this.btnCustomerPayment.Text = "Customer Payment";
            this.btnCustomerPayment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCustomerPayment.UseVisualStyleBackColor = false;
            this.btnCustomerPayment.Click += new System.EventHandler(this.btnCustomerPayment_Click);
            // 
            // btn_SaleItem
            // 
            this.btn_SaleItem.BackColor = System.Drawing.Color.Transparent;
            this.btn_SaleItem.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_SaleItem.FlatAppearance.BorderSize = 0;
            this.btn_SaleItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SaleItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn_SaleItem.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_SaleItem.Location = new System.Drawing.Point(0, 27);
            this.btn_SaleItem.Name = "btn_SaleItem";
            this.btn_SaleItem.Padding = new System.Windows.Forms.Padding(26, 0, 0, 0);
            this.btn_SaleItem.Size = new System.Drawing.Size(173, 27);
            this.btn_SaleItem.TabIndex = 1;
            this.btn_SaleItem.Text = "Sale Item";
            this.btn_SaleItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_SaleItem.UseVisualStyleBackColor = false;
            this.btn_SaleItem.Click += new System.EventHandler(this.btn_SaleItem_Click);
            // 
            // btnCustomer
            // 
            this.btnCustomer.BackColor = System.Drawing.Color.Transparent;
            this.btnCustomer.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCustomer.FlatAppearance.BorderSize = 0;
            this.btnCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomer.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnCustomer.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCustomer.Location = new System.Drawing.Point(0, 0);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Padding = new System.Windows.Forms.Padding(26, 0, 0, 0);
            this.btnCustomer.Size = new System.Drawing.Size(173, 27);
            this.btnCustomer.TabIndex = 0;
            this.btnCustomer.Text = "Customer";
            this.btnCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCustomer.UseVisualStyleBackColor = false;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // btnSale
            // 
            this.btnSale.BackColor = System.Drawing.Color.Transparent;
            this.btnSale.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSale.FlatAppearance.BorderSize = 0;
            this.btnSale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSale.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnSale.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnSale.Image = ((System.Drawing.Image)(resources.GetObject("btnSale.Image")));
            this.btnSale.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSale.Location = new System.Drawing.Point(0, 521);
            this.btnSale.Margin = new System.Windows.Forms.Padding(0);
            this.btnSale.Name = "btnSale";
            this.btnSale.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.btnSale.Size = new System.Drawing.Size(173, 30);
            this.btnSale.TabIndex = 5;
            this.btnSale.Text = "Sale";
            this.btnSale.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSale.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSale.UseVisualStyleBackColor = false;
            this.btnSale.Click += new System.EventHandler(this.btnSale_Click);
            // 
            // Purchase_Panel
            // 
            this.Purchase_Panel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Purchase_Panel.Controls.Add(this.btnPurchaseRep);
            this.Purchase_Panel.Controls.Add(this.btnStore);
            this.Purchase_Panel.Controls.Add(this.btnStoreType);
            this.Purchase_Panel.Controls.Add(this.btnPurchaseReturn);
            this.Purchase_Panel.Controls.Add(this.btnSupplierPayment);
            this.Purchase_Panel.Controls.Add(this.btnPurchaseItem);
            this.Purchase_Panel.Controls.Add(this.btnSupplier);
            this.Purchase_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Purchase_Panel.Location = new System.Drawing.Point(0, 330);
            this.Purchase_Panel.Name = "Purchase_Panel";
            this.Purchase_Panel.Size = new System.Drawing.Size(173, 191);
            this.Purchase_Panel.TabIndex = 4;
            // 
            // btnPurchaseRep
            // 
            this.btnPurchaseRep.BackColor = System.Drawing.Color.Transparent;
            this.btnPurchaseRep.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPurchaseRep.FlatAppearance.BorderSize = 0;
            this.btnPurchaseRep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPurchaseRep.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnPurchaseRep.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnPurchaseRep.Location = new System.Drawing.Point(0, 165);
            this.btnPurchaseRep.Name = "btnPurchaseRep";
            this.btnPurchaseRep.Padding = new System.Windows.Forms.Padding(26, 0, 0, 0);
            this.btnPurchaseRep.Size = new System.Drawing.Size(173, 27);
            this.btnPurchaseRep.TabIndex = 6;
            this.btnPurchaseRep.Text = "Report";
            this.btnPurchaseRep.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPurchaseRep.UseVisualStyleBackColor = false;
            this.btnPurchaseRep.Click += new System.EventHandler(this.btnPurchaseRep_Click);
            // 
            // btnStore
            // 
            this.btnStore.BackColor = System.Drawing.Color.Transparent;
            this.btnStore.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStore.FlatAppearance.BorderSize = 0;
            this.btnStore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStore.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnStore.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnStore.Location = new System.Drawing.Point(0, 138);
            this.btnStore.Name = "btnStore";
            this.btnStore.Padding = new System.Windows.Forms.Padding(26, 0, 0, 0);
            this.btnStore.Size = new System.Drawing.Size(173, 27);
            this.btnStore.TabIndex = 5;
            this.btnStore.Text = "Store";
            this.btnStore.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStore.UseVisualStyleBackColor = false;
            this.btnStore.Click += new System.EventHandler(this.btnStore_Click);
            // 
            // btnStoreType
            // 
            this.btnStoreType.BackColor = System.Drawing.Color.Transparent;
            this.btnStoreType.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStoreType.FlatAppearance.BorderSize = 0;
            this.btnStoreType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStoreType.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnStoreType.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnStoreType.Location = new System.Drawing.Point(0, 111);
            this.btnStoreType.Name = "btnStoreType";
            this.btnStoreType.Padding = new System.Windows.Forms.Padding(26, 0, 0, 0);
            this.btnStoreType.Size = new System.Drawing.Size(173, 27);
            this.btnStoreType.TabIndex = 4;
            this.btnStoreType.Text = "Store Type";
            this.btnStoreType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStoreType.UseVisualStyleBackColor = false;
            this.btnStoreType.Click += new System.EventHandler(this.btnStoreType_Click);
            // 
            // btnPurchaseReturn
            // 
            this.btnPurchaseReturn.BackColor = System.Drawing.Color.Transparent;
            this.btnPurchaseReturn.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPurchaseReturn.FlatAppearance.BorderSize = 0;
            this.btnPurchaseReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPurchaseReturn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnPurchaseReturn.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnPurchaseReturn.Location = new System.Drawing.Point(0, 81);
            this.btnPurchaseReturn.Name = "btnPurchaseReturn";
            this.btnPurchaseReturn.Padding = new System.Windows.Forms.Padding(26, 0, 0, 0);
            this.btnPurchaseReturn.Size = new System.Drawing.Size(173, 30);
            this.btnPurchaseReturn.TabIndex = 3;
            this.btnPurchaseReturn.Text = "Purchase Return";
            this.btnPurchaseReturn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPurchaseReturn.UseVisualStyleBackColor = false;
            this.btnPurchaseReturn.Click += new System.EventHandler(this.btnPurchaseReturn_Click);
            // 
            // btnSupplierPayment
            // 
            this.btnSupplierPayment.BackColor = System.Drawing.Color.Transparent;
            this.btnSupplierPayment.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSupplierPayment.FlatAppearance.BorderSize = 0;
            this.btnSupplierPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSupplierPayment.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSupplierPayment.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnSupplierPayment.Location = new System.Drawing.Point(0, 54);
            this.btnSupplierPayment.Name = "btnSupplierPayment";
            this.btnSupplierPayment.Padding = new System.Windows.Forms.Padding(26, 0, 0, 0);
            this.btnSupplierPayment.Size = new System.Drawing.Size(173, 27);
            this.btnSupplierPayment.TabIndex = 2;
            this.btnSupplierPayment.Text = "Supplier Payment";
            this.btnSupplierPayment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSupplierPayment.UseVisualStyleBackColor = false;
            this.btnSupplierPayment.Click += new System.EventHandler(this.btnSupplierPayment_Click);
            // 
            // btnPurchaseItem
            // 
            this.btnPurchaseItem.BackColor = System.Drawing.Color.Transparent;
            this.btnPurchaseItem.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPurchaseItem.FlatAppearance.BorderSize = 0;
            this.btnPurchaseItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPurchaseItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnPurchaseItem.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnPurchaseItem.Location = new System.Drawing.Point(0, 27);
            this.btnPurchaseItem.Name = "btnPurchaseItem";
            this.btnPurchaseItem.Padding = new System.Windows.Forms.Padding(26, 0, 0, 0);
            this.btnPurchaseItem.Size = new System.Drawing.Size(173, 27);
            this.btnPurchaseItem.TabIndex = 1;
            this.btnPurchaseItem.Text = "Purchase Item";
            this.btnPurchaseItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPurchaseItem.UseVisualStyleBackColor = false;
            this.btnPurchaseItem.Click += new System.EventHandler(this.btnPurchaseItem_Click);
            // 
            // btnSupplier
            // 
            this.btnSupplier.BackColor = System.Drawing.Color.Transparent;
            this.btnSupplier.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSupplier.FlatAppearance.BorderSize = 0;
            this.btnSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSupplier.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSupplier.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnSupplier.Location = new System.Drawing.Point(0, 0);
            this.btnSupplier.Name = "btnSupplier";
            this.btnSupplier.Padding = new System.Windows.Forms.Padding(26, 0, 0, 0);
            this.btnSupplier.Size = new System.Drawing.Size(173, 27);
            this.btnSupplier.TabIndex = 0;
            this.btnSupplier.Text = "Supplier";
            this.btnSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSupplier.UseVisualStyleBackColor = false;
            this.btnSupplier.Click += new System.EventHandler(this.btnSupplier_Click);
            // 
            // btnPurchase
            // 
            this.btnPurchase.BackColor = System.Drawing.Color.Transparent;
            this.btnPurchase.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPurchase.FlatAppearance.BorderSize = 0;
            this.btnPurchase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPurchase.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnPurchase.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnPurchase.Image = ((System.Drawing.Image)(resources.GetObject("btnPurchase.Image")));
            this.btnPurchase.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPurchase.Location = new System.Drawing.Point(0, 300);
            this.btnPurchase.Margin = new System.Windows.Forms.Padding(0);
            this.btnPurchase.Name = "btnPurchase";
            this.btnPurchase.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.btnPurchase.Size = new System.Drawing.Size(173, 30);
            this.btnPurchase.TabIndex = 3;
            this.btnPurchase.Text = "Purchase";
            this.btnPurchase.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPurchase.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPurchase.UseVisualStyleBackColor = false;
            this.btnPurchase.Click += new System.EventHandler(this.btnPurchase_Click);
            // 
            // Inventory_Panel
            // 
            this.Inventory_Panel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Inventory_Panel.Controls.Add(this.btnInvRep);
            this.Inventory_Panel.Controls.Add(this.btnStockDetail);
            this.Inventory_Panel.Controls.Add(this.btnItem);
            this.Inventory_Panel.Controls.Add(this.btnProduct);
            this.Inventory_Panel.Controls.Add(this.btnCategory);
            this.Inventory_Panel.Controls.Add(this.btnCompany);
            this.Inventory_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Inventory_Panel.Location = new System.Drawing.Point(0, 138);
            this.Inventory_Panel.Name = "Inventory_Panel";
            this.Inventory_Panel.Size = new System.Drawing.Size(173, 162);
            this.Inventory_Panel.TabIndex = 2;
            // 
            // btnInvRep
            // 
            this.btnInvRep.BackColor = System.Drawing.Color.Transparent;
            this.btnInvRep.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnInvRep.FlatAppearance.BorderSize = 0;
            this.btnInvRep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInvRep.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnInvRep.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnInvRep.Location = new System.Drawing.Point(0, 135);
            this.btnInvRep.Name = "btnInvRep";
            this.btnInvRep.Padding = new System.Windows.Forms.Padding(26, 0, 0, 0);
            this.btnInvRep.Size = new System.Drawing.Size(173, 27);
            this.btnInvRep.TabIndex = 5;
            this.btnInvRep.Text = "Report";
            this.btnInvRep.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInvRep.UseVisualStyleBackColor = false;
            this.btnInvRep.Click += new System.EventHandler(this.btnInvRep_Click_1);
            // 
            // btnStockDetail
            // 
            this.btnStockDetail.BackColor = System.Drawing.Color.Transparent;
            this.btnStockDetail.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStockDetail.FlatAppearance.BorderSize = 0;
            this.btnStockDetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStockDetail.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnStockDetail.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnStockDetail.Location = new System.Drawing.Point(0, 108);
            this.btnStockDetail.Name = "btnStockDetail";
            this.btnStockDetail.Padding = new System.Windows.Forms.Padding(26, 0, 0, 0);
            this.btnStockDetail.Size = new System.Drawing.Size(173, 27);
            this.btnStockDetail.TabIndex = 4;
            this.btnStockDetail.Text = "Stock Detail";
            this.btnStockDetail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStockDetail.UseVisualStyleBackColor = false;
            this.btnStockDetail.Click += new System.EventHandler(this.btnStockDetail_Click);
            // 
            // btnItem
            // 
            this.btnItem.BackColor = System.Drawing.Color.Transparent;
            this.btnItem.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnItem.FlatAppearance.BorderSize = 0;
            this.btnItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnItem.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnItem.Location = new System.Drawing.Point(0, 81);
            this.btnItem.Name = "btnItem";
            this.btnItem.Padding = new System.Windows.Forms.Padding(26, 0, 0, 0);
            this.btnItem.Size = new System.Drawing.Size(173, 27);
            this.btnItem.TabIndex = 3;
            this.btnItem.Text = "Item";
            this.btnItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnItem.UseVisualStyleBackColor = false;
            this.btnItem.Click += new System.EventHandler(this.btnItem_Click);
            // 
            // btnProduct
            // 
            this.btnProduct.BackColor = System.Drawing.Color.Transparent;
            this.btnProduct.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProduct.FlatAppearance.BorderSize = 0;
            this.btnProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProduct.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnProduct.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnProduct.Location = new System.Drawing.Point(0, 54);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Padding = new System.Windows.Forms.Padding(26, 0, 0, 0);
            this.btnProduct.Size = new System.Drawing.Size(173, 27);
            this.btnProduct.TabIndex = 2;
            this.btnProduct.Text = "Product";
            this.btnProduct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProduct.UseVisualStyleBackColor = false;
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);
            // 
            // btnCategory
            // 
            this.btnCategory.BackColor = System.Drawing.Color.Transparent;
            this.btnCategory.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCategory.FlatAppearance.BorderSize = 0;
            this.btnCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategory.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnCategory.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCategory.Location = new System.Drawing.Point(0, 27);
            this.btnCategory.Name = "btnCategory";
            this.btnCategory.Padding = new System.Windows.Forms.Padding(26, 0, 0, 0);
            this.btnCategory.Size = new System.Drawing.Size(173, 27);
            this.btnCategory.TabIndex = 1;
            this.btnCategory.Text = "Category";
            this.btnCategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCategory.UseVisualStyleBackColor = false;
            this.btnCategory.Click += new System.EventHandler(this.btnCategory_Click);
            // 
            // btnCompany
            // 
            this.btnCompany.BackColor = System.Drawing.Color.Transparent;
            this.btnCompany.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCompany.FlatAppearance.BorderSize = 0;
            this.btnCompany.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompany.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnCompany.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCompany.Location = new System.Drawing.Point(0, 0);
            this.btnCompany.Name = "btnCompany";
            this.btnCompany.Padding = new System.Windows.Forms.Padding(26, 0, 0, 0);
            this.btnCompany.Size = new System.Drawing.Size(173, 27);
            this.btnCompany.TabIndex = 0;
            this.btnCompany.Text = "Company";
            this.btnCompany.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCompany.UseVisualStyleBackColor = false;
            this.btnCompany.Click += new System.EventHandler(this.btnCompany_Click);
            // 
            // btnInventory
            // 
            this.btnInventory.BackColor = System.Drawing.Color.Transparent;
            this.btnInventory.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnInventory.FlatAppearance.BorderSize = 0;
            this.btnInventory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInventory.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnInventory.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnInventory.Image = ((System.Drawing.Image)(resources.GetObject("btnInventory.Image")));
            this.btnInventory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInventory.Location = new System.Drawing.Point(0, 108);
            this.btnInventory.Margin = new System.Windows.Forms.Padding(0);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.btnInventory.Size = new System.Drawing.Size(173, 30);
            this.btnInventory.TabIndex = 1;
            this.btnInventory.Text = "Inventory";
            this.btnInventory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInventory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnInventory.UseVisualStyleBackColor = false;
            this.btnInventory.Click += new System.EventHandler(this.btnInventory_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(173, 108);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // PanelLoadForms
            // 
            this.PanelLoadForms.Location = new System.Drawing.Point(178, 10);
            this.PanelLoadForms.Name = "PanelLoadForms";
            this.PanelLoadForms.Size = new System.Drawing.Size(1734, 1008);
            this.PanelLoadForms.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(174, 1021);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "User :";
            this.label2.Visible = false;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(216, 1021);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(35, 13);
            this.lblUser.TabIndex = 0;
            this.lblUser.Text = "label1";
            this.lblUser.Visible = false;
            // 
            // frmDashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1043);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PanelLoadForms);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.PanelMenu);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmDashBoard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DashBoard (Rights Owner Fakhir-Gohar) fakhirgohar@gmail.com";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDashBoard_Load_1);
            this.PanelMenu.ResumeLayout(false);
            this.Sale_Panel.ResumeLayout(false);
            this.Purchase_Panel.ResumeLayout(false);
            this.Inventory_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private Button btnStockDetail;
        private Button btnPurchaseRep;
        private Button btnSaleRep;
        private Label label2;
        private Label lblUser;
        private Button btnInvRep;
    }
}