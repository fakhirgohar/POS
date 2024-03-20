namespace Project_POS.InventoryModule
{
    partial class frmInventoryItems
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInventoryItems));
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
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkCanPurchase = new System.Windows.Forms.CheckBox();
            this.chkCanSale = new System.Windows.Forms.CheckBox();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.txtReOrdLev = new System.Windows.Forms.TextBox();
            this.txtMaxLev = new System.Windows.Forms.TextBox();
            this.txtMinLev = new System.Windows.Forms.TextBox();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.cboSubCat = new System.Windows.Forms.ComboBox();
            this.cboCat = new System.Windows.Forms.ComboBox();
            this.cboBrand = new System.Windows.Forms.ComboBox();
            this.txtItemCode = new System.Windows.Forms.TextBox();
            this.grpDetail = new System.Windows.Forms.GroupBox();
            this.dgvItemDetail = new System.Windows.Forms.DataGridView();
            this.tsItem.SuspendLayout();
            this.grpMain.SuspendLayout();
            this.grpDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemDetail)).BeginInit();
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
            this.tsItem.Size = new System.Drawing.Size(764, 75);
            this.tsItem.TabIndex = 19;
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
            this.grpMain.Controls.Add(this.label9);
            this.grpMain.Controls.Add(this.label8);
            this.grpMain.Controls.Add(this.label7);
            this.grpMain.Controls.Add(this.label6);
            this.grpMain.Controls.Add(this.label5);
            this.grpMain.Controls.Add(this.label4);
            this.grpMain.Controls.Add(this.label3);
            this.grpMain.Controls.Add(this.label2);
            this.grpMain.Controls.Add(this.label1);
            this.grpMain.Controls.Add(this.chkCanPurchase);
            this.grpMain.Controls.Add(this.chkCanSale);
            this.grpMain.Controls.Add(this.chkActive);
            this.grpMain.Controls.Add(this.txtReOrdLev);
            this.grpMain.Controls.Add(this.txtMaxLev);
            this.grpMain.Controls.Add(this.txtMinLev);
            this.grpMain.Controls.Add(this.txtQty);
            this.grpMain.Controls.Add(this.txtItemName);
            this.grpMain.Controls.Add(this.cboSubCat);
            this.grpMain.Controls.Add(this.cboCat);
            this.grpMain.Controls.Add(this.cboBrand);
            this.grpMain.Controls.Add(this.txtItemCode);
            this.grpMain.Location = new System.Drawing.Point(12, 78);
            this.grpMain.Name = "grpMain";
            this.grpMain.Size = new System.Drawing.Size(740, 159);
            this.grpMain.TabIndex = 20;
            this.grpMain.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(390, 97);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Re Order :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(390, 72);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Max Level :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(390, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Min Level :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(390, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Bal Qty :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "ItemName :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Product :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Category :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Brand :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "ItemCode :";
            // 
            // chkCanPurchase
            // 
            this.chkCanPurchase.AutoSize = true;
            this.chkCanPurchase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCanPurchase.Location = new System.Drawing.Point(621, 120);
            this.chkCanPurchase.Name = "chkCanPurchase";
            this.chkCanPurchase.Size = new System.Drawing.Size(105, 17);
            this.chkCanPurchase.TabIndex = 11;
            this.chkCanPurchase.Text = "Can Purchase";
            this.chkCanPurchase.UseVisualStyleBackColor = true;
            // 
            // chkCanSale
            // 
            this.chkCanSale.AutoSize = true;
            this.chkCanSale.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCanSale.Location = new System.Drawing.Point(548, 121);
            this.chkCanSale.Name = "chkCanSale";
            this.chkCanSale.Size = new System.Drawing.Size(77, 17);
            this.chkCanSale.TabIndex = 10;
            this.chkCanSale.Text = "Can Sale";
            this.chkCanSale.UseVisualStyleBackColor = true;
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkActive.Location = new System.Drawing.Point(486, 121);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(62, 17);
            this.chkActive.TabIndex = 9;
            this.chkActive.Text = "Active";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // txtReOrdLev
            // 
            this.txtReOrdLev.Location = new System.Drawing.Point(485, 94);
            this.txtReOrdLev.Multiline = true;
            this.txtReOrdLev.Name = "txtReOrdLev";
            this.txtReOrdLev.Size = new System.Drawing.Size(241, 20);
            this.txtReOrdLev.TabIndex = 8;
            // 
            // txtMaxLev
            // 
            this.txtMaxLev.Location = new System.Drawing.Point(485, 68);
            this.txtMaxLev.Multiline = true;
            this.txtMaxLev.Name = "txtMaxLev";
            this.txtMaxLev.Size = new System.Drawing.Size(241, 20);
            this.txtMaxLev.TabIndex = 7;
            // 
            // txtMinLev
            // 
            this.txtMinLev.Location = new System.Drawing.Point(485, 42);
            this.txtMinLev.Multiline = true;
            this.txtMinLev.Name = "txtMinLev";
            this.txtMinLev.Size = new System.Drawing.Size(241, 20);
            this.txtMinLev.TabIndex = 6;
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(485, 16);
            this.txtQty.Multiline = true;
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(241, 20);
            this.txtQty.TabIndex = 5;
            // 
            // txtItemName
            // 
            this.txtItemName.Location = new System.Drawing.Point(109, 124);
            this.txtItemName.Multiline = true;
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(241, 20);
            this.txtItemName.TabIndex = 4;
            // 
            // cboSubCat
            // 
            this.cboSubCat.FormattingEnabled = true;
            this.cboSubCat.Location = new System.Drawing.Point(109, 96);
            this.cboSubCat.Name = "cboSubCat";
            this.cboSubCat.Size = new System.Drawing.Size(241, 21);
            this.cboSubCat.TabIndex = 3;
            // 
            // cboCat
            // 
            this.cboCat.FormattingEnabled = true;
            this.cboCat.Location = new System.Drawing.Point(109, 69);
            this.cboCat.Name = "cboCat";
            this.cboCat.Size = new System.Drawing.Size(241, 21);
            this.cboCat.TabIndex = 2;
            this.cboCat.SelectedValueChanged += new System.EventHandler(this.cboCat_SelectedValueChanged);
            // 
            // cboBrand
            // 
            this.cboBrand.FormattingEnabled = true;
            this.cboBrand.Location = new System.Drawing.Point(109, 42);
            this.cboBrand.Name = "cboBrand";
            this.cboBrand.Size = new System.Drawing.Size(241, 21);
            this.cboBrand.TabIndex = 1;
            // 
            // txtItemCode
            // 
            this.txtItemCode.Location = new System.Drawing.Point(109, 16);
            this.txtItemCode.Multiline = true;
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.Size = new System.Drawing.Size(241, 20);
            this.txtItemCode.TabIndex = 0;
            // 
            // grpDetail
            // 
            this.grpDetail.Controls.Add(this.dgvItemDetail);
            this.grpDetail.Location = new System.Drawing.Point(12, 239);
            this.grpDetail.Name = "grpDetail";
            this.grpDetail.Size = new System.Drawing.Size(740, 306);
            this.grpDetail.TabIndex = 21;
            this.grpDetail.TabStop = false;
            // 
            // dgvItemDetail
            // 
            this.dgvItemDetail.AllowUserToAddRows = false;
            this.dgvItemDetail.AllowUserToDeleteRows = false;
            this.dgvItemDetail.AllowUserToResizeColumns = false;
            this.dgvItemDetail.AllowUserToResizeRows = false;
            this.dgvItemDetail.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvItemDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItemDetail.Location = new System.Drawing.Point(6, 14);
            this.dgvItemDetail.Name = "dgvItemDetail";
            this.dgvItemDetail.RowHeadersVisible = false;
            this.dgvItemDetail.Size = new System.Drawing.Size(720, 282);
            this.dgvItemDetail.TabIndex = 0;
            // 
            // frmInventoryItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 552);
            this.Controls.Add(this.grpDetail);
            this.Controls.Add(this.grpMain);
            this.Controls.Add(this.tsItem);
            this.Name = "frmInventoryItems";
            this.Text = "Inventory Items (Rights Owner Fakhir-Gohar) fakhirgohar@gmail.com";
            this.Load += new System.EventHandler(this.frmInventoryItems_Load);
            this.tsItem.ResumeLayout(false);
            this.tsItem.PerformLayout();
            this.grpMain.ResumeLayout(false);
            this.grpMain.PerformLayout();
            this.grpDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemDetail)).EndInit();
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
        private System.Windows.Forms.ComboBox cboBrand;
        private System.Windows.Forms.TextBox txtItemCode;
        private System.Windows.Forms.GroupBox grpDetail;
        private System.Windows.Forms.DataGridView dgvItemDetail;
        private System.Windows.Forms.CheckBox chkCanPurchase;
        private System.Windows.Forms.CheckBox chkCanSale;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.TextBox txtReOrdLev;
        private System.Windows.Forms.TextBox txtMaxLev;
        private System.Windows.Forms.TextBox txtMinLev;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.ComboBox cboSubCat;
        private System.Windows.Forms.ComboBox cboCat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}