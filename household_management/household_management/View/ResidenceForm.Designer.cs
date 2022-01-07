
namespace household_management.View
{
    partial class ResidenceForm
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
            this.rViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // rViewer
            // 
            this.rViewer.ActiveViewIndex = -1;
            this.rViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.rViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rViewer.Location = new System.Drawing.Point(0, 0);
            this.rViewer.Name = "rViewer";
            this.rViewer.Size = new System.Drawing.Size(800, 450);
            this.rViewer.TabIndex = 0;
            // 
            // ResidenceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rViewer);
            this.Name = "ResidenceForm";
            this.Text = "ResidenceForm";
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer rViewer;
    }
}