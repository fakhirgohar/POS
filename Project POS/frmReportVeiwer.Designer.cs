﻿namespace Project_POS
{
    partial class frmReportVeiwer
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
            this.CtrlRptVeiwer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // CtrlRptVeiwer
            // 
            this.CtrlRptVeiwer.Location = new System.Drawing.Point(12, 12);
            this.CtrlRptVeiwer.Name = "CtrlRptVeiwer";
            this.CtrlRptVeiwer.ServerReport.BearerToken = null;
            this.CtrlRptVeiwer.Size = new System.Drawing.Size(776, 426);
            this.CtrlRptVeiwer.TabIndex = 0;
            // 
            // frmReportVeiwer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CtrlRptVeiwer);
            this.Name = "frmReportVeiwer";
            this.Text = "Report Viewer (Rights Owner Fakhir-Gohar) fakhirgohar@gmail.com";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer CtrlRptVeiwer;
    }
}

