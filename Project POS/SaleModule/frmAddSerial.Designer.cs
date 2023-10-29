namespace Project_POS.SaleModule
{
    partial class frmAddSerial
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
            this.dgvAddSerial = new System.Windows.Forms.DataGridView();
            this.grpMain = new System.Windows.Forms.GroupBox();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblItemCode = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSPrice = new System.Windows.Forms.NumericUpDown();
            this.btnSelect = new System.Windows.Forms.Button();
            this.dgvCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddSerial)).BeginInit();
            this.grpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAddSerial
            // 
            this.dgvAddSerial.AllowUserToAddRows = false;
            this.dgvAddSerial.AllowUserToDeleteRows = false;
            this.dgvAddSerial.AllowUserToResizeColumns = false;
            this.dgvAddSerial.AllowUserToResizeRows = false;
            this.dgvAddSerial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAddSerial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvCheck});
            this.dgvAddSerial.Location = new System.Drawing.Point(12, 80);
            this.dgvAddSerial.MultiSelect = false;
            this.dgvAddSerial.Name = "dgvAddSerial";
            this.dgvAddSerial.RowHeadersVisible = false;
            this.dgvAddSerial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAddSerial.Size = new System.Drawing.Size(717, 345);
            this.dgvAddSerial.TabIndex = 0;
            // 
            // grpMain
            // 
            this.grpMain.Controls.Add(this.btnSelect);
            this.grpMain.Controls.Add(this.txtSPrice);
            this.grpMain.Controls.Add(this.label3);
            this.grpMain.Controls.Add(this.lblItemCode);
            this.grpMain.Controls.Add(this.label1);
            this.grpMain.Controls.Add(this.chkSelectAll);
            this.grpMain.Location = new System.Drawing.Point(12, 12);
            this.grpMain.Name = "grpMain";
            this.grpMain.Size = new System.Drawing.Size(717, 62);
            this.grpMain.TabIndex = 1;
            this.grpMain.TabStop = false;
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSelectAll.Location = new System.Drawing.Point(12, 38);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(73, 17);
            this.chkSelectAll.TabIndex = 0;
            this.chkSelectAll.Text = "Select All";
            this.chkSelectAll.UseVisualStyleBackColor = true;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(159, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "ItemCode :";
            // 
            // lblItemCode
            // 
            this.lblItemCode.AutoSize = true;
            this.lblItemCode.Location = new System.Drawing.Point(228, 33);
            this.lblItemCode.Name = "lblItemCode";
            this.lblItemCode.Size = new System.Drawing.Size(62, 13);
            this.lblItemCode.TabIndex = 2;
            this.lblItemCode.Text = "lblItemCode";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(356, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Sale Price :";
            // 
            // txtSPrice
            // 
            this.txtSPrice.Location = new System.Drawing.Point(424, 31);
            this.txtSPrice.Name = "txtSPrice";
            this.txtSPrice.Size = new System.Drawing.Size(206, 20);
            this.txtSPrice.TabIndex = 4;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(636, 28);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 5;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // dgvCheck
            // 
            this.dgvCheck.HeaderText = " ";
            this.dgvCheck.Name = "dgvCheck";
            this.dgvCheck.Width = 40;
            // 
            // frmAddSerial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 439);
            this.Controls.Add(this.grpMain);
            this.Controls.Add(this.dgvAddSerial);
            this.Name = "frmAddSerial";
            this.Text = "frmAddSerial";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddSerial)).EndInit();
            this.grpMain.ResumeLayout(false);
            this.grpMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSPrice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAddSerial;
        private System.Windows.Forms.GroupBox grpMain;
        private System.Windows.Forms.CheckBox chkSelectAll;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.NumericUpDown txtSPrice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblItemCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgvCheck;
    }
}