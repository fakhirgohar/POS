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
            this.dgvFilterdRows = new System.Windows.Forms.DataGridView();
            this.txtSearchDetial = new System.Windows.Forms.TextBox();
            this.btnSearchDetial = new System.Windows.Forms.Button();
            this.btnSearchFilterdRows = new System.Windows.Forms.Button();
            this.txtSearchFilterdRows = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Add = new System.Windows.Forms.DataGridViewButtonColumn();
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
            this.Add});
            this.dgvDetail.Location = new System.Drawing.Point(6, 66);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.Size = new System.Drawing.Size(385, 374);
            this.dgvDetail.TabIndex = 0;
            this.dgvDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellClick);
            // 
            // dgvFilterdRows
            // 
            this.dgvFilterdRows.AllowUserToAddRows = false;
            this.dgvFilterdRows.AllowUserToDeleteRows = false;
            this.dgvFilterdRows.AllowUserToResizeColumns = false;
            this.dgvFilterdRows.AllowUserToResizeRows = false;
            this.dgvFilterdRows.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFilterdRows.Location = new System.Drawing.Point(6, 65);
            this.dgvFilterdRows.MultiSelect = false;
            this.dgvFilterdRows.Name = "dgvFilterdRows";
            this.dgvFilterdRows.RowHeadersVisible = false;
            this.dgvFilterdRows.Size = new System.Drawing.Size(385, 374);
            this.dgvFilterdRows.TabIndex = 1;
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
            // 
            // btnSearchFilterdRows
            // 
            this.btnSearchFilterdRows.Location = new System.Drawing.Point(307, 13);
            this.btnSearchFilterdRows.Name = "btnSearchFilterdRows";
            this.btnSearchFilterdRows.Size = new System.Drawing.Size(75, 37);
            this.btnSearchFilterdRows.TabIndex = 5;
            this.btnSearchFilterdRows.Text = "Find";
            this.btnSearchFilterdRows.UseVisualStyleBackColor = true;
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
            this.groupBox1.Controls.Add(this.dgvFilterdRows);
            this.groupBox1.Controls.Add(this.btnSearchFilterdRows);
            this.groupBox1.Controls.Add(this.txtSearchFilterdRows);
            this.groupBox1.Location = new System.Drawing.Point(425, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(397, 448);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvDetail);
            this.groupBox2.Controls.Add(this.txtSearchDetial);
            this.groupBox2.Controls.Add(this.btnSearchDetial);
            this.groupBox2.Location = new System.Drawing.Point(12, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(397, 448);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            // 
            // Add
            // 
            this.Add.HeaderText = "Add";
            this.Add.Name = "Add";
            this.Add.Text = "Add";
            this.Add.ToolTipText = "Add";
            this.Add.Width = 50;
            // 
            // frmFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 457);
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
        private System.Windows.Forms.DataGridViewButtonColumn Add;
    }
}