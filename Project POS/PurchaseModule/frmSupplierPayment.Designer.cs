namespace Project_POS.PurchaseModule
{
    partial class frmSupplierPayment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSupplierPayment));
            this.tsItem = new System.Windows.Forms.ToolStrip();
            this.btnNew = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnCancel = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.btnSearch = new System.Windows.Forms.ToolStripButton();
            this.btnHelp = new System.Windows.Forms.ToolStripButton();
            this.cboSupp = new System.Windows.Forms.ComboBox();
            this.cboPBillNo = new System.Windows.Forms.ComboBox();
            this.txtReceiptNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPayMode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSupp = new System.Windows.Forms.TextBox();
            this.txtPBillNo = new System.Windows.Forms.TextBox();
            this.grpMain = new System.Windows.Forms.GroupBox();
            this.txtPayment = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpReceiptDate = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpBillDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtpending = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTotalPaid = new System.Windows.Forms.TextBox();
            this.grpDetail = new System.Windows.Forms.GroupBox();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.tsItem.SuspendLayout();
            this.grpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPayment)).BeginInit();
            this.grpDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
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
            this.tsItem.Size = new System.Drawing.Size(699, 75);
            this.tsItem.TabIndex = 21;
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
            // cboSupp
            // 
            this.cboSupp.FormattingEnabled = true;
            this.cboSupp.Location = new System.Drawing.Point(84, 45);
            this.cboSupp.Name = "cboSupp";
            this.cboSupp.Size = new System.Drawing.Size(100, 21);
            this.cboSupp.TabIndex = 22;
            this.cboSupp.SelectedValueChanged += new System.EventHandler(this.cboSupp_SelectedValueChanged);
            // 
            // cboPBillNo
            // 
            this.cboPBillNo.FormattingEnabled = true;
            this.cboPBillNo.Location = new System.Drawing.Point(84, 72);
            this.cboPBillNo.Name = "cboPBillNo";
            this.cboPBillNo.Size = new System.Drawing.Size(100, 21);
            this.cboPBillNo.TabIndex = 23;
            this.cboPBillNo.ValueMemberChanged += new System.EventHandler(this.cboPBillNo_ValueMemberChanged);
            this.cboPBillNo.SelectedValueChanged += new System.EventHandler(this.cboPBillNo_SelectedValueChanged);
            // 
            // txtReceiptNo
            // 
            this.txtReceiptNo.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtReceiptNo.Location = new System.Drawing.Point(84, 19);
            this.txtReceiptNo.Multiline = true;
            this.txtReceiptNo.Name = "txtReceiptNo";
            this.txtReceiptNo.ReadOnly = true;
            this.txtReceiptNo.Size = new System.Drawing.Size(266, 20);
            this.txtReceiptNo.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Receipt No :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "PBill No :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Supplier :";
            // 
            // txtPayMode
            // 
            this.txtPayMode.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtPayMode.Location = new System.Drawing.Point(441, 125);
            this.txtPayMode.Name = "txtPayMode";
            this.txtPayMode.ReadOnly = true;
            this.txtPayMode.Size = new System.Drawing.Size(100, 20);
            this.txtPayMode.TabIndex = 28;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(361, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "Pay Mode :";
            // 
            // txtSupp
            // 
            this.txtSupp.Location = new System.Drawing.Point(190, 46);
            this.txtSupp.Name = "txtSupp";
            this.txtSupp.Size = new System.Drawing.Size(160, 20);
            this.txtSupp.TabIndex = 30;
            // 
            // txtPBillNo
            // 
            this.txtPBillNo.Location = new System.Drawing.Point(190, 73);
            this.txtPBillNo.Name = "txtPBillNo";
            this.txtPBillNo.Size = new System.Drawing.Size(160, 20);
            this.txtPBillNo.TabIndex = 31;
            // 
            // grpMain
            // 
            this.grpMain.Controls.Add(this.txtPayment);
            this.grpMain.Controls.Add(this.label10);
            this.grpMain.Controls.Add(this.dtpReceiptDate);
            this.grpMain.Controls.Add(this.label9);
            this.grpMain.Controls.Add(this.dtpBillDate);
            this.grpMain.Controls.Add(this.label8);
            this.grpMain.Controls.Add(this.txtRemarks);
            this.grpMain.Controls.Add(this.label7);
            this.grpMain.Controls.Add(this.label6);
            this.grpMain.Controls.Add(this.txtpending);
            this.grpMain.Controls.Add(this.label5);
            this.grpMain.Controls.Add(this.txtTotalPaid);
            this.grpMain.Controls.Add(this.txtReceiptNo);
            this.grpMain.Controls.Add(this.txtPBillNo);
            this.grpMain.Controls.Add(this.cboSupp);
            this.grpMain.Controls.Add(this.txtSupp);
            this.grpMain.Controls.Add(this.cboPBillNo);
            this.grpMain.Controls.Add(this.label4);
            this.grpMain.Controls.Add(this.label1);
            this.grpMain.Controls.Add(this.txtPayMode);
            this.grpMain.Controls.Add(this.label2);
            this.grpMain.Controls.Add(this.label3);
            this.grpMain.Location = new System.Drawing.Point(12, 78);
            this.grpMain.Name = "grpMain";
            this.grpMain.Size = new System.Drawing.Size(550, 185);
            this.grpMain.TabIndex = 32;
            this.grpMain.TabStop = false;
            // 
            // txtPayment
            // 
            this.txtPayment.Location = new System.Drawing.Point(84, 126);
            this.txtPayment.Maximum = new decimal(new int[] {
            -1486618624,
            232830643,
            0,
            0});
            this.txtPayment.Name = "txtPayment";
            this.txtPayment.Size = new System.Drawing.Size(266, 20);
            this.txtPayment.TabIndex = 44;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(361, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 13);
            this.label10.TabIndex = 43;
            this.label10.Text = "ReceiptDate :";
            // 
            // dtpReceiptDate
            // 
            this.dtpReceiptDate.CustomFormat = "dd MMM yyyy";
            this.dtpReceiptDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpReceiptDate.Location = new System.Drawing.Point(441, 45);
            this.dtpReceiptDate.Name = "dtpReceiptDate";
            this.dtpReceiptDate.Size = new System.Drawing.Size(100, 20);
            this.dtpReceiptDate.TabIndex = 42;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(361, 75);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 41;
            this.label9.Text = "BillDate :";
            // 
            // dtpBillDate
            // 
            this.dtpBillDate.CustomFormat = "dd MMM yyyy";
            this.dtpBillDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBillDate.Location = new System.Drawing.Point(441, 72);
            this.dtpBillDate.Name = "dtpBillDate";
            this.dtpBillDate.Size = new System.Drawing.Size(100, 20);
            this.dtpBillDate.TabIndex = 40;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 154);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 39;
            this.label8.Text = "Remarks :";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(84, 151);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(457, 20);
            this.txtRemarks.TabIndex = 38;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 37;
            this.label7.Text = "Payment :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 35;
            this.label6.Text = "Pending :";
            // 
            // txtpending
            // 
            this.txtpending.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtpending.Location = new System.Drawing.Point(84, 99);
            this.txtpending.Name = "txtpending";
            this.txtpending.ReadOnly = true;
            this.txtpending.Size = new System.Drawing.Size(266, 20);
            this.txtpending.TabIndex = 34;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(361, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 33;
            this.label5.Text = "Total Paid :";
            // 
            // txtTotalPaid
            // 
            this.txtTotalPaid.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtTotalPaid.Location = new System.Drawing.Point(441, 99);
            this.txtTotalPaid.Name = "txtTotalPaid";
            this.txtTotalPaid.ReadOnly = true;
            this.txtTotalPaid.Size = new System.Drawing.Size(100, 20);
            this.txtTotalPaid.TabIndex = 32;
            // 
            // grpDetail
            // 
            this.grpDetail.Controls.Add(this.dgvDetail);
            this.grpDetail.Location = new System.Drawing.Point(12, 269);
            this.grpDetail.Name = "grpDetail";
            this.grpDetail.Size = new System.Drawing.Size(676, 318);
            this.grpDetail.TabIndex = 33;
            this.grpDetail.TabStop = false;
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.AllowUserToDeleteRows = false;
            this.dgvDetail.AllowUserToResizeColumns = false;
            this.dgvDetail.AllowUserToResizeRows = false;
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetail.Location = new System.Drawing.Point(6, 14);
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.Size = new System.Drawing.Size(663, 298);
            this.dgvDetail.TabIndex = 0;
            // 
            // frmSupplierPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 599);
            this.Controls.Add(this.grpDetail);
            this.Controls.Add(this.grpMain);
            this.Controls.Add(this.tsItem);
            this.Name = "frmSupplierPayment";
            this.Text = "Supplier Payment (Rights Owner Fakhir-Gohar) fakhirgohar@gmail.com";
            this.tsItem.ResumeLayout(false);
            this.tsItem.PerformLayout();
            this.grpMain.ResumeLayout(false);
            this.grpMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPayment)).EndInit();
            this.grpDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
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
        private System.Windows.Forms.ComboBox cboSupp;
        private System.Windows.Forms.ComboBox cboPBillNo;
        private System.Windows.Forms.TextBox txtReceiptNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPayMode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSupp;
        private System.Windows.Forms.TextBox txtPBillNo;
        private System.Windows.Forms.GroupBox grpMain;
        private System.Windows.Forms.GroupBox grpDetail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTotalPaid;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpBillDate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpReceiptDate;
        private System.Windows.Forms.NumericUpDown txtPayment;
        private System.Windows.Forms.TextBox txtpending;
    }
}