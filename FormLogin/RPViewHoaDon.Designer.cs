
namespace FormLogin
{
    partial class RPViewHoaDon
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
            this.RPVHoaDon = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // RPVHoaDon
            // 
            this.RPVHoaDon.LocalReport.ReportEmbeddedResource = "FormLogin.ReportHoaDon.rdlc";
            this.RPVHoaDon.Location = new System.Drawing.Point(-3, 7);
            this.RPVHoaDon.Name = "RPVHoaDon";
            this.RPVHoaDon.ServerReport.BearerToken = null;
            this.RPVHoaDon.Size = new System.Drawing.Size(1554, 761);
            this.RPVHoaDon.TabIndex = 0;
            // 
            // RPViewHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1553, 770);
            this.Controls.Add(this.RPVHoaDon);
            this.Name = "RPViewHoaDon";
            this.Text = "RPViewHoaDon";
            this.Load += new System.EventHandler(this.RPViewHoaDon_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer RPVHoaDon;
    }
}