
namespace household_management.View
{
    partial class TransferReport
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
            this.tRViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // tRViewer
            // 
            this.tRViewer.ActiveViewIndex = -1;
            this.tRViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tRViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.tRViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tRViewer.Location = new System.Drawing.Point(0, 0);
            this.tRViewer.Name = "tRViewer";
            this.tRViewer.Size = new System.Drawing.Size(800, 450);
            this.tRViewer.TabIndex = 0;
            // 
            // TransferReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tRViewer);
            this.Name = "TransferReport";
            this.Text = "TransferReport";
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer tRViewer;
    }
}