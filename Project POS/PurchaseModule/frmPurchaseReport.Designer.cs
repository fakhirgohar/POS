namespace Project_POS.PurchaseModule
{
    partial class frmPurchaseReport
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnPreview = new System.Windows.Forms.Button();
            this.cboRepCase = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkProduct = new System.Windows.Forms.CheckBox();
            this.chkCategory = new System.Windows.Forms.CheckBox();
            this.chkCompCode = new System.Windows.Forms.CheckBox();
            this.chkItemCode = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtProduct = new System.Windows.Forms.TextBox();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.txtCompCode = new System.Windows.Forms.TextBox();
            this.txtItemCode = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkToDate = new System.Windows.Forms.CheckBox();
            this.chkFromDate = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.cboRepType = new System.Windows.Forms.ComboBox();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox3.Controls.Add(this.btnPreview);
            this.groupBox3.Controls.Add(this.cboRepCase);
            this.groupBox3.Location = new System.Drawing.Point(11, 309);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(564, 122);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(237, 60);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(88, 54);
            this.btnPreview.TabIndex = 1;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            // 
            // cboRepCase
            // 
            this.cboRepCase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRepCase.FormattingEnabled = true;
            this.cboRepCase.Items.AddRange(new object[] {
            "Stock Report Item Wise",
            "Stock Report Serial Wise",
            "Stock Report Item And Serial Wise",
            "Stock Report Item Serial And Price Wise"});
            this.cboRepCase.Location = new System.Drawing.Point(80, 33);
            this.cboRepCase.Name = "cboRepCase";
            this.cboRepCase.Size = new System.Drawing.Size(421, 21);
            this.cboRepCase.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox2.Controls.Add(this.chkProduct);
            this.groupBox2.Controls.Add(this.chkCategory);
            this.groupBox2.Controls.Add(this.chkCompCode);
            this.groupBox2.Controls.Add(this.chkItemCode);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtProduct);
            this.groupBox2.Controls.Add(this.txtCategory);
            this.groupBox2.Controls.Add(this.txtCompCode);
            this.groupBox2.Controls.Add(this.txtItemCode);
            this.groupBox2.Location = new System.Drawing.Point(11, 163);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(564, 140);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // chkProduct
            // 
            this.chkProduct.AutoSize = true;
            this.chkProduct.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkProduct.Location = new System.Drawing.Point(506, 103);
            this.chkProduct.Name = "chkProduct";
            this.chkProduct.Size = new System.Drawing.Size(57, 17);
            this.chkProduct.TabIndex = 11;
            this.chkProduct.Text = "Apply";
            this.chkProduct.UseVisualStyleBackColor = true;
            // 
            // chkCategory
            // 
            this.chkCategory.AutoSize = true;
            this.chkCategory.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCategory.Location = new System.Drawing.Point(506, 75);
            this.chkCategory.Name = "chkCategory";
            this.chkCategory.Size = new System.Drawing.Size(57, 17);
            this.chkCategory.TabIndex = 10;
            this.chkCategory.Text = "Apply";
            this.chkCategory.UseVisualStyleBackColor = true;
            // 
            // chkCompCode
            // 
            this.chkCompCode.AutoSize = true;
            this.chkCompCode.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCompCode.Location = new System.Drawing.Point(506, 50);
            this.chkCompCode.Name = "chkCompCode";
            this.chkCompCode.Size = new System.Drawing.Size(57, 17);
            this.chkCompCode.TabIndex = 9;
            this.chkCompCode.Text = "Apply";
            this.chkCompCode.UseVisualStyleBackColor = true;
            // 
            // chkItemCode
            // 
            this.chkItemCode.AutoSize = true;
            this.chkItemCode.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkItemCode.Location = new System.Drawing.Point(506, 25);
            this.chkItemCode.Name = "chkItemCode";
            this.chkItemCode.Size = new System.Drawing.Size(57, 17);
            this.chkItemCode.TabIndex = 8;
            this.chkItemCode.Text = "Apply";
            this.chkItemCode.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(7, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Product :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Category :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Company :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "ItemCode :";
            // 
            // txtProduct
            // 
            this.txtProduct.Location = new System.Drawing.Point(80, 103);
            this.txtProduct.Multiline = true;
            this.txtProduct.Name = "txtProduct";
            this.txtProduct.Size = new System.Drawing.Size(421, 24);
            this.txtProduct.TabIndex = 3;
            // 
            // txtCategory
            // 
            this.txtCategory.Location = new System.Drawing.Point(80, 75);
            this.txtCategory.Multiline = true;
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(421, 24);
            this.txtCategory.TabIndex = 2;
            // 
            // txtCompCode
            // 
            this.txtCompCode.Location = new System.Drawing.Point(80, 47);
            this.txtCompCode.Multiline = true;
            this.txtCompCode.Name = "txtCompCode";
            this.txtCompCode.Size = new System.Drawing.Size(421, 24);
            this.txtCompCode.TabIndex = 1;
            // 
            // txtItemCode
            // 
            this.txtItemCode.Location = new System.Drawing.Point(80, 19);
            this.txtItemCode.Multiline = true;
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.Size = new System.Drawing.Size(421, 24);
            this.txtItemCode.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Controls.Add(this.chkToDate);
            this.groupBox1.Controls.Add(this.chkFromDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpToDate);
            this.groupBox1.Controls.Add(this.dtpFromDate);
            this.groupBox1.Controls.Add(this.cboRepType);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(564, 129);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // chkToDate
            // 
            this.chkToDate.AutoSize = true;
            this.chkToDate.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkToDate.Location = new System.Drawing.Point(395, 86);
            this.chkToDate.Name = "chkToDate";
            this.chkToDate.Size = new System.Drawing.Size(57, 17);
            this.chkToDate.TabIndex = 6;
            this.chkToDate.Text = "Apply";
            this.chkToDate.UseVisualStyleBackColor = true;
            // 
            // chkFromDate
            // 
            this.chkFromDate.AutoSize = true;
            this.chkFromDate.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFromDate.Location = new System.Drawing.Point(395, 62);
            this.chkFromDate.Name = "chkFromDate";
            this.chkFromDate.Size = new System.Drawing.Size(57, 17);
            this.chkFromDate.TabIndex = 5;
            this.chkFromDate.Text = "Apply";
            this.chkFromDate.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(131, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "To Date :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(117, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "From Date :";
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "dd MMM yyyy";
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(189, 85);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(200, 20);
            this.dtpToDate.TabIndex = 2;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "dd MMM yyyy";
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(189, 59);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(200, 20);
            this.dtpFromDate.TabIndex = 1;
            // 
            // cboRepType
            // 
            this.cboRepType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRepType.FormattingEnabled = true;
            this.cboRepType.Items.AddRange(new object[] {
            "Current Stock",
            "Back Date Stock"});
            this.cboRepType.Location = new System.Drawing.Point(80, 29);
            this.cboRepType.Name = "cboRepType";
            this.cboRepType.Size = new System.Drawing.Size(421, 21);
            this.cboRepType.TabIndex = 0;
            // 
            // frmPurchaseReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 436);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmPurchaseReport";
            this.Text = "Purchase Report (Rights Owner Fakhir-Gohar) fakhirgohar@gmail.com";
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.ComboBox cboRepCase;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkProduct;
        private System.Windows.Forms.CheckBox chkCategory;
        private System.Windows.Forms.CheckBox chkCompCode;
        private System.Windows.Forms.CheckBox chkItemCode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtProduct;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.TextBox txtCompCode;
        private System.Windows.Forms.TextBox txtItemCode;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkToDate;
        private System.Windows.Forms.CheckBox chkFromDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.ComboBox cboRepType;
    }
}