namespace Project_POS.PurchaseModule
{
    partial class frmInventoryPurchase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInventoryPurchase));
            this.tsItem = new System.Windows.Forms.ToolStrip();
            this.btnNew = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnCancel = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.btnSearch = new System.Windows.Forms.ToolStripButton();
            this.btnHelp = new System.Windows.Forms.ToolStripButton();
            this.grpMain = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSuppName = new System.Windows.Forms.TextBox();
            this.cboSuppliers = new System.Windows.Forms.ComboBox();
            this.dtpReceiveDate = new System.Windows.Forms.DateTimePicker();
            this.dtpBillDate = new System.Windows.Forms.DateTimePicker();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.txtPurchaser = new System.Windows.Forms.TextBox();
            this.cboPayMode = new System.Windows.Forms.ComboBox();
            this.txtReceiptNo = new System.Windows.Forms.TextBox();
            this.txtBillNo = new System.Windows.Forms.TextBox();
            this.grpDetail = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtSummary = new System.Windows.Forms.NumericUpDown();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.btnDel = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtQtyTotal = new System.Windows.Forms.NumericUpDown();
            this.txtPPrice = new System.Windows.Forms.NumericUpDown();
            this.txtQty = new System.Windows.Forms.NumericUpDown();
            this.txtStoreName = new System.Windows.Forms.TextBox();
            this.cboStore = new System.Windows.Forms.ComboBox();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.cboItems = new System.Windows.Forms.ComboBox();
            this.tsItem.SuspendLayout();
            this.grpMain.SuspendLayout();
            this.grpDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQtyTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQty)).BeginInit();
            this.SuspendLayout();
            // 
            // tsItem
            // 
            this.tsItem.AutoSize = false;
            this.tsItem.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.tsItem.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNew,
            this.btnEdit,
            this.btnSave,
            this.btnCancel,
            this.btnDelete,
            this.btnPrint,
            this.btnSearch,
            this.btnHelp});
            this.tsItem.Location = new System.Drawing.Point(0, 0);
            this.tsItem.Name = "tsItem";
            this.tsItem.Size = new System.Drawing.Size(879, 75);
            this.tsItem.TabIndex = 20;
            this.tsItem.Text = "toolStrip1";
            // 
            // btnNew
            // 
            this.btnNew.AutoSize = false;
            this.btnNew.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(70, 70);
            this.btnNew.Text = "New";
            this.btnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.AutoSize = false;
            this.btnEdit.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(70, 70);
            this.btnEdit.Text = "Edit";
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = false;
            this.btnSave.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(70, 70);
            this.btnSave.Text = "Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = false;
            this.btnCancel.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 70);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.AutoSize = false;
            this.btnDelete.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(70, 70);
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.AutoSize = false;
            this.btnPrint.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(70, 70);
            this.btnPrint.Text = "Print";
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.AutoSize = false;
            this.btnSearch.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(70, 70);
            this.btnSearch.Text = "Search";
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.AutoSize = false;
            this.btnHelp.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(70, 70);
            this.btnHelp.Text = "Help";
            this.btnHelp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // grpMain
            // 
            this.grpMain.Controls.Add(this.label8);
            this.grpMain.Controls.Add(this.label7);
            this.grpMain.Controls.Add(this.label6);
            this.grpMain.Controls.Add(this.label5);
            this.grpMain.Controls.Add(this.label4);
            this.grpMain.Controls.Add(this.label3);
            this.grpMain.Controls.Add(this.label2);
            this.grpMain.Controls.Add(this.label1);
            this.grpMain.Controls.Add(this.txtSuppName);
            this.grpMain.Controls.Add(this.cboSuppliers);
            this.grpMain.Controls.Add(this.dtpReceiveDate);
            this.grpMain.Controls.Add(this.dtpBillDate);
            this.grpMain.Controls.Add(this.txtRemarks);
            this.grpMain.Controls.Add(this.txtPurchaser);
            this.grpMain.Controls.Add(this.cboPayMode);
            this.grpMain.Controls.Add(this.txtReceiptNo);
            this.grpMain.Controls.Add(this.txtBillNo);
            this.grpMain.Location = new System.Drawing.Point(12, 105);
            this.grpMain.Name = "grpMain";
            this.grpMain.Size = new System.Drawing.Size(855, 164);
            this.grpMain.TabIndex = 21;
            this.grpMain.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(422, 72);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Supplier :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(422, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Receive Date :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(422, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "BillDate :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Remarks :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Purchaser :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "PayMode :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "ReceiptNo :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "BillNo :";
            // 
            // txtSuppName
            // 
            this.txtSuppName.Location = new System.Drawing.Point(591, 69);
            this.txtSuppName.Multiline = true;
            this.txtSuppName.Name = "txtSuppName";
            this.txtSuppName.Size = new System.Drawing.Size(173, 20);
            this.txtSuppName.TabIndex = 8;
            // 
            // cboSuppliers
            // 
            this.cboSuppliers.FormattingEnabled = true;
            this.cboSuppliers.Location = new System.Drawing.Point(512, 68);
            this.cboSuppliers.Name = "cboSuppliers";
            this.cboSuppliers.Size = new System.Drawing.Size(73, 21);
            this.cboSuppliers.TabIndex = 7;
            this.cboSuppliers.SelectedIndexChanged += new System.EventHandler(this.cboSuppliers_SelectedIndexChanged);
            // 
            // dtpReceiveDate
            // 
            this.dtpReceiveDate.CustomFormat = "dd MMM yyyy";
            this.dtpReceiveDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpReceiveDate.Location = new System.Drawing.Point(512, 43);
            this.dtpReceiveDate.Name = "dtpReceiveDate";
            this.dtpReceiveDate.Size = new System.Drawing.Size(252, 20);
            this.dtpReceiveDate.TabIndex = 6;
            // 
            // dtpBillDate
            // 
            this.dtpBillDate.CustomFormat = "dd MMM yyyy";
            this.dtpBillDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBillDate.Location = new System.Drawing.Point(512, 17);
            this.dtpBillDate.Name = "dtpBillDate";
            this.dtpBillDate.Size = new System.Drawing.Size(252, 20);
            this.dtpBillDate.TabIndex = 5;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(105, 121);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(239, 20);
            this.txtRemarks.TabIndex = 4;
            // 
            // txtPurchaser
            // 
            this.txtPurchaser.Location = new System.Drawing.Point(105, 95);
            this.txtPurchaser.Multiline = true;
            this.txtPurchaser.Name = "txtPurchaser";
            this.txtPurchaser.Size = new System.Drawing.Size(239, 20);
            this.txtPurchaser.TabIndex = 3;
            // 
            // cboPayMode
            // 
            this.cboPayMode.FormattingEnabled = true;
            this.cboPayMode.Items.AddRange(new object[] {
            "Cash",
            "Credit"});
            this.cboPayMode.Location = new System.Drawing.Point(105, 68);
            this.cboPayMode.Name = "cboPayMode";
            this.cboPayMode.Size = new System.Drawing.Size(239, 21);
            this.cboPayMode.TabIndex = 2;
            // 
            // txtReceiptNo
            // 
            this.txtReceiptNo.Location = new System.Drawing.Point(105, 42);
            this.txtReceiptNo.Multiline = true;
            this.txtReceiptNo.Name = "txtReceiptNo";
            this.txtReceiptNo.Size = new System.Drawing.Size(239, 20);
            this.txtReceiptNo.TabIndex = 1;
            // 
            // txtBillNo
            // 
            this.txtBillNo.Location = new System.Drawing.Point(105, 17);
            this.txtBillNo.Multiline = true;
            this.txtBillNo.Name = "txtBillNo";
            this.txtBillNo.Size = new System.Drawing.Size(239, 20);
            this.txtBillNo.TabIndex = 0;
            // 
            // grpDetail
            // 
            this.grpDetail.Controls.Add(this.label16);
            this.grpDetail.Controls.Add(this.txtSummary);
            this.grpDetail.Controls.Add(this.dgvDetail);
            this.grpDetail.Controls.Add(this.panel1);
            this.grpDetail.Controls.Add(this.btnAdd);
            this.grpDetail.Controls.Add(this.txtQtyTotal);
            this.grpDetail.Controls.Add(this.txtPPrice);
            this.grpDetail.Controls.Add(this.txtQty);
            this.grpDetail.Controls.Add(this.txtStoreName);
            this.grpDetail.Controls.Add(this.cboStore);
            this.grpDetail.Controls.Add(this.txtItemName);
            this.grpDetail.Controls.Add(this.cboItems);
            this.grpDetail.Location = new System.Drawing.Point(12, 275);
            this.grpDetail.Name = "grpDetail";
            this.grpDetail.Size = new System.Drawing.Size(855, 361);
            this.grpDetail.TabIndex = 22;
            this.grpDetail.TabStop = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(568, 335);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(90, 13);
            this.label16.TabIndex = 11;
            this.label16.Text = "Total Summary :";
            // 
            // txtSummary
            // 
            this.txtSummary.Location = new System.Drawing.Point(665, 332);
            this.txtSummary.Maximum = new decimal(new int[] {
            1661992960,
            1808227885,
            5,
            0});
            this.txtSummary.Name = "txtSummary";
            this.txtSummary.Size = new System.Drawing.Size(178, 20);
            this.txtSummary.TabIndex = 10;
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.AllowUserToDeleteRows = false;
            this.dgvDetail.AllowUserToResizeColumns = false;
            this.dgvDetail.AllowUserToResizeRows = false;
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnDel});
            this.dgvDetail.Location = new System.Drawing.Point(6, 77);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(837, 248);
            this.dgvDetail.TabIndex = 9;
            this.dgvDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellClick);
            // 
            // btnDel
            // 
            this.btnDel.HeaderText = " ";
            this.btnDel.Image = ((System.Drawing.Image)(resources.GetObject("btnDel.Image")));
            this.btnDel.Name = "btnDel";
            this.btnDel.Width = 40;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Location = new System.Drawing.Point(6, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(758, 25);
            this.panel1.TabIndex = 8;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(635, 4);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(38, 13);
            this.label15.TabIndex = 23;
            this.label15.Text = "Total :";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(509, 4);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(45, 13);
            this.label14.TabIndex = 22;
            this.label14.Text = "PPrice :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(383, 4);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(58, 13);
            this.label13.TabIndex = 21;
            this.label13.Text = "Quantity :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(276, 6);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 13);
            this.label12.TabIndex = 20;
            this.label12.Text = "StoreName :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(185, 6);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 13);
            this.label11.TabIndex = 19;
            this.label11.Text = "StoreID :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(79, 6);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "ItemName :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(3, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "ItemCode :";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(768, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 52);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtQtyTotal
            // 
            this.txtQtyTotal.Location = new System.Drawing.Point(644, 41);
            this.txtQtyTotal.Maximum = new decimal(new int[] {
            1661992960,
            1808227885,
            5,
            0});
            this.txtQtyTotal.Name = "txtQtyTotal";
            this.txtQtyTotal.Size = new System.Drawing.Size(120, 20);
            this.txtQtyTotal.TabIndex = 6;
            // 
            // txtPPrice
            // 
            this.txtPPrice.Location = new System.Drawing.Point(518, 41);
            this.txtPPrice.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.txtPPrice.Name = "txtPPrice";
            this.txtPPrice.Size = new System.Drawing.Size(120, 20);
            this.txtPPrice.TabIndex = 5;
            this.txtPPrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPPrice_KeyDown);
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(392, 40);
            this.txtQty.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(120, 20);
            this.txtQty.TabIndex = 4;
            this.txtQty.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtQty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQty_KeyDown);
            this.txtQty.Leave += new System.EventHandler(this.txtQty_Leave);
            // 
            // txtStoreName
            // 
            this.txtStoreName.Location = new System.Drawing.Point(285, 41);
            this.txtStoreName.Name = "txtStoreName";
            this.txtStoreName.Size = new System.Drawing.Size(100, 20);
            this.txtStoreName.TabIndex = 3;
            // 
            // cboStore
            // 
            this.cboStore.FormattingEnabled = true;
            this.cboStore.Location = new System.Drawing.Point(194, 40);
            this.cboStore.Name = "cboStore";
            this.cboStore.Size = new System.Drawing.Size(85, 21);
            this.cboStore.TabIndex = 2;
            this.cboStore.SelectedIndexChanged += new System.EventHandler(this.cboStore_SelectedIndexChanged);
            // 
            // txtItemName
            // 
            this.txtItemName.Location = new System.Drawing.Point(88, 40);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(100, 20);
            this.txtItemName.TabIndex = 1;
            // 
            // cboItems
            // 
            this.cboItems.FormattingEnabled = true;
            this.cboItems.Location = new System.Drawing.Point(6, 39);
            this.cboItems.Name = "cboItems";
            this.cboItems.Size = new System.Drawing.Size(79, 21);
            this.cboItems.TabIndex = 0;
            this.cboItems.SelectedValueChanged += new System.EventHandler(this.cboItems_SelectedValueChanged);
            this.cboItems.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboItems_KeyPress);
            // 
            // frmInventoryPurchase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 648);
            this.Controls.Add(this.grpDetail);
            this.Controls.Add(this.grpMain);
            this.Controls.Add(this.tsItem);
            this.Name = "frmInventoryPurchase";
            this.Text = "Purchase Item (Rights Owner Fakhir-Gohar) fakhirgohar@gmail.com";
            this.Load += new System.EventHandler(this.frmInventoryPurchase_Load);
            this.tsItem.ResumeLayout(false);
            this.tsItem.PerformLayout();
            this.grpMain.ResumeLayout(false);
            this.grpMain.PerformLayout();
            this.grpDetail.ResumeLayout(false);
            this.grpDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQtyTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQty)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsItem;
        private System.Windows.Forms.ToolStripButton btnNew;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnCancel;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripButton btnPrint;
        private System.Windows.Forms.ToolStripButton btnSearch;
        private System.Windows.Forms.ToolStripButton btnHelp;
        private System.Windows.Forms.GroupBox grpMain;
        private System.Windows.Forms.TextBox txtSuppName;
        private System.Windows.Forms.ComboBox cboSuppliers;
        private System.Windows.Forms.DateTimePicker dtpReceiveDate;
        private System.Windows.Forms.DateTimePicker dtpBillDate;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.TextBox txtPurchaser;
        private System.Windows.Forms.ComboBox cboPayMode;
        private System.Windows.Forms.TextBox txtReceiptNo;
        private System.Windows.Forms.TextBox txtBillNo;
        private System.Windows.Forms.GroupBox grpDetail;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.NumericUpDown txtQtyTotal;
        private System.Windows.Forms.NumericUpDown txtPPrice;
        private System.Windows.Forms.NumericUpDown txtQty;
        private System.Windows.Forms.TextBox txtStoreName;
        private System.Windows.Forms.ComboBox cboStore;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.ComboBox cboItems;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown txtSummary;
        private System.Windows.Forms.DataGridViewImageColumn btnDel;
    }
}