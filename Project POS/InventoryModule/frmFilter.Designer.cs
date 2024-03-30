namespace Project_POS.InventoryModule
{
    partial class frmFilter
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
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.Add = new System.Windows.Forms.DataGridViewButtonColumn();
            this.TransNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvFilterdRows = new System.Windows.Forms.DataGridView();
            this.Remove = new System.Windows.Forms.DataGridViewButtonColumn();
            this.FTransNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSearchDetial = new System.Windows.Forms.TextBox();
            this.btnSearchDetial = new System.Windows.Forms.Button();
            this.btnSearchFilterdRows = new System.Windows.Forms.Button();
            this.txtSearchFilterdRows = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnApplyFilter = new System.Windows.Forms.Button();
            this.btnRemoveAll = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAddAll = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFilterdRows)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.AllowUserToDeleteRows = false;
            this.dgvDetail.AllowUserToResizeColumns = false;
            this.dgvDetail.AllowUserToResizeRows = false;
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Add,
            this.TransNo});
            this.dgvDetail.Location = new System.Drawing.Point(6, 66);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.Size = new System.Drawing.Size(385, 374);
            this.dgvDetail.TabIndex = 0;
            this.dgvDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellClick);
            // 
            // Add
            // 
            this.Add.HeaderText = "Add";
            this.Add.Name = "Add";
            this.Add.Text = "Add";
            this.Add.ToolTipText = "Add";
            this.Add.UseColumnTextForButtonValue = true;
            this.Add.Width = 50;
            // 
            // TransNo
            // 
            this.TransNo.DataPropertyName = "TransNo";
            this.TransNo.HeaderText = "TransNo";
            this.TransNo.Name = "TransNo";
            this.TransNo.Width = 200;
            // 
            // dgvFilterdRows
            // 
            this.dgvFilterdRows.AllowUserToAddRows = false;
            this.dgvFilterdRows.AllowUserToDeleteRows = false;
            this.dgvFilterdRows.AllowUserToResizeColumns = false;
            this.dgvFilterdRows.AllowUserToResizeRows = false;
            this.dgvFilterdRows.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFilterdRows.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Remove,
            this.FTransNo});
            this.dgvFilterdRows.Location = new System.Drawing.Point(6, 65);
            this.dgvFilterdRows.MultiSelect = false;
            this.dgvFilterdRows.Name = "dgvFilterdRows";
            this.dgvFilterdRows.RowHeadersVisible = false;
            this.dgvFilterdRows.Size = new System.Drawing.Size(385, 374);
            this.dgvFilterdRows.TabIndex = 1;
            this.dgvFilterdRows.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFilterdRows_CellClick);
            // 
            // Remove
            // 
            this.Remove.HeaderText = "Remove";
            this.Remove.Name = "Remove";
            this.Remove.Text = "Remove";
            this.Remove.ToolTipText = "Remove";
            this.Remove.UseColumnTextForButtonValue = true;
            this.Remove.Width = 60;
            // 
            // FTransNo
            // 
            this.FTransNo.DataPropertyName = "TransNo";
            this.FTransNo.HeaderText = "TransNo";
            this.FTransNo.Name = "FTransNo";
            this.FTransNo.Width = 320;
            // 
            // txtSearchDetial
            // 
            this.txtSearchDetial.Location = new System.Drawing.Point(6, 30);
            this.txtSearchDetial.Name = "txtSearchDetial";
            this.txtSearchDetial.Size = new System.Drawing.Size(295, 20);
            this.txtSearchDetial.TabIndex = 2;
            // 
            // btnSearchDetial
            // 
            this.btnSearchDetial.Location = new System.Drawing.Point(307, 14);
            this.btnSearchDetial.Name = "btnSearchDetial";
            this.btnSearchDetial.Size = new System.Drawing.Size(75, 37);
            this.btnSearchDetial.TabIndex = 3;
            this.btnSearchDetial.Text = "Find";
            this.btnSearchDetial.UseVisualStyleBackColor = true;
            this.btnSearchDetial.Click += new System.EventHandler(this.btnSearchDetial_Click);
            // 
            // btnSearchFilterdRows
            // 
            this.btnSearchFilterdRows.Location = new System.Drawing.Point(307, 13);
            this.btnSearchFilterdRows.Name = "btnSearchFilterdRows";
            this.btnSearchFilterdRows.Size = new System.Drawing.Size(75, 37);
            this.btnSearchFilterdRows.TabIndex = 5;
            this.btnSearchFilterdRows.Text = "Find";
            this.btnSearchFilterdRows.UseVisualStyleBackColor = true;
            this.btnSearchFilterdRows.Click += new System.EventHandler(this.btnSearchFilterdRows_Click);
            // 
            // txtSearchFilterdRows
            // 
            this.txtSearchFilterdRows.Location = new System.Drawing.Point(6, 29);
            this.txtSearchFilterdRows.Name = "txtSearchFilterdRows";
            this.txtSearchFilterdRows.Size = new System.Drawing.Size(295, 20);
            this.txtSearchFilterdRows.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnApplyFilter);
            this.groupBox1.Controls.Add(this.btnRemoveAll);
            this.groupBox1.Controls.Add(this.dgvFilterdRows);
            this.groupBox1.Controls.Add(this.btnSearchFilterdRows);
            this.groupBox1.Controls.Add(this.txtSearchFilterdRows);
            this.groupBox1.Location = new System.Drawing.Point(425, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(397, 486);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // btnApplyFilter
            // 
            this.btnApplyFilter.Location = new System.Drawing.Point(87, 445);
            this.btnApplyFilter.Name = "btnApplyFilter";
            this.btnApplyFilter.Size = new System.Drawing.Size(75, 37);
            this.btnApplyFilter.TabIndex = 7;
            this.btnApplyFilter.Text = "Apply Filter";
            this.btnApplyFilter.UseVisualStyleBackColor = true;
            this.btnApplyFilter.Click += new System.EventHandler(this.btnApplyFilter_Click);
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.Location = new System.Drawing.Point(6, 445);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(75, 37);
            this.btnRemoveAll.TabIndex = 6;
            this.btnRemoveAll.Text = "Remove All";
            this.btnRemoveAll.UseVisualStyleBackColor = true;
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAddAll);
            this.groupBox2.Controls.Add(this.dgvDetail);
            this.groupBox2.Controls.Add(this.txtSearchDetial);
            this.groupBox2.Controls.Add(this.btnSearchDetial);
            this.groupBox2.Location = new System.Drawing.Point(12, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(397, 486);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            // 
            // btnAddAll
            // 
            this.btnAddAll.Location = new System.Drawing.Point(6, 445);
            this.btnAddAll.Name = "btnAddAll";
            this.btnAddAll.Size = new System.Drawing.Size(75, 37);
            this.btnAddAll.TabIndex = 8;
            this.btnAddAll.Text = "Add All";
            this.btnAddAll.UseVisualStyleBackColor = true;
            this.btnAddAll.Click += new System.EventHandler(this.btnAddAll_Click);
            // 
            // frmFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 501);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmFilter";
            this.Text = "frmFilter";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFilterdRows)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.DataGridView dgvFilterdRows;
        private System.Windows.Forms.TextBox txtSearchDetial;
        private System.Windows.Forms.Button btnSearchDetial;
        private System.Windows.Forms.Button btnSearchFilterdRows;
        private System.Windows.Forms.TextBox txtSearchFilterdRows;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnApplyFilter;
        private System.Windows.Forms.Button btnRemoveAll;
        private System.Windows.Forms.Button btnAddAll;
        private System.Windows.Forms.DataGridViewButtonColumn Remove;
        private System.Windows.Forms.DataGridViewTextBoxColumn FTransNo;
        private System.Windows.Forms.DataGridViewButtonColumn Add;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransNo;
    }
}