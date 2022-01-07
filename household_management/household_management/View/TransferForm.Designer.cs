
namespace household_management.View
{
    partial class TransferForm
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
            this.tViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // tViewer
            // 
            this.tViewer.ActiveViewIndex = -1;
            this.tViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.tViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tViewer.Location = new System.Drawing.Point(0, 0);
            this.tViewer.Name = "tViewer";
            this.tViewer.Size = new System.Drawing.Size(800, 450);
            this.tViewer.TabIndex = 0;
            // 
            // TransferForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tViewer);
            this.Name = "TransferForm";
            this.Text = "TransferForm";
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer tViewer;
    }
}