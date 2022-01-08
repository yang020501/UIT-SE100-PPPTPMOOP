
namespace household_management.View
{
    partial class HouseholdReport
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
            this.hRViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // hRViewer
            // 
            this.hRViewer.ActiveViewIndex = -1;
            this.hRViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hRViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.hRViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hRViewer.Location = new System.Drawing.Point(0, 0);
            this.hRViewer.Name = "hRViewer";
            this.hRViewer.Size = new System.Drawing.Size(800, 450);
            this.hRViewer.TabIndex = 0;
            // 
            // HouseholdReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.hRViewer);
            this.Name = "HouseholdReport";
            this.Text = "HouseholdReport";
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer hRViewer;
    }
}