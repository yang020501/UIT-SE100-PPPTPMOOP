
namespace household_management.View
{
    partial class AbsenceReport
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
            this.aRViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // aRViewer
            // 
            this.aRViewer.ActiveViewIndex = -1;
            this.aRViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.aRViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.aRViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aRViewer.Location = new System.Drawing.Point(0, 0);
            this.aRViewer.Name = "aRViewer";
            this.aRViewer.Size = new System.Drawing.Size(800, 450);
            this.aRViewer.TabIndex = 0;
            // 
            // AbsenceReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.aRViewer);
            this.Name = "AbsenceReport";
            this.Text = "AbsenceReport";
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer aRViewer;
    }
}