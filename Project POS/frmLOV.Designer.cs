namespace Project_POS
{
    partial class frmLOV
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
            this.grpMain = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.grpDetail = new System.Windows.Forms.GroupBox();
            this.dgvLov = new System.Windows.Forms.DataGridView();
            this.grpMain.SuspendLayout();
            this.grpDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLov)).BeginInit();
            this.SuspendLayout();
            // 
            // grpMain
            // 
            this.grpMain.Controls.Add(this.btnSearch);
            this.grpMain.Controls.Add(this.txtSearch);
            this.grpMain.Location = new System.Drawing.Point(12, 12);
            this.grpMain.Name = "grpMain";
            this.grpMain.Size = new System.Drawing.Size(776, 71);
            this.grpMain.TabIndex = 0;
            this.grpMain.TabStop = false;
            // 
            // btnSearch
            // 
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSearch.Location = new System.Drawing.Point(693, 15);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 43);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(7, 36);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(682, 20);
            this.txtSearch.TabIndex = 0;
            // 
            // grpDetail
            // 
            this.grpDetail.Controls.Add(this.dgvLov);
            this.grpDetail.Location = new System.Drawing.Point(12, 88);
            this.grpDetail.Name = "grpDetail";
            this.grpDetail.Size = new System.Drawing.Size(776, 354);
            this.grpDetail.TabIndex = 1;
            this.grpDetail.TabStop = false;
            // 
            // dgvLov
            // 
            this.dgvLov.AllowUserToAddRows = false;
            this.dgvLov.AllowUserToDeleteRows = false;
            this.dgvLov.AllowUserToResizeColumns = false;
            this.dgvLov.AllowUserToResizeRows = false;
            this.dgvLov.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLov.Location = new System.Drawing.Point(4, 14);
            this.dgvLov.Name = "dgvLov";
            this.dgvLov.RowHeadersVisible = false;
            this.dgvLov.Size = new System.Drawing.Size(764, 334);
            this.dgvLov.TabIndex = 0;
            this.dgvLov.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLov_CellDoubleClick);
            // 
            // frmLOV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grpDetail);
            this.Controls.Add(this.grpMain);
            this.Name = "frmLOV";
            this.Text = "LOV (Rights Owner Fakhir-Gohar) fakhirgohar@gmail.com";
            this.grpMain.ResumeLayout(false);
            this.grpMain.PerformLayout();
            this.grpDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLov)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpMain;
        private System.Windows.Forms.GroupBox grpDetail;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgvLov;
    }
}