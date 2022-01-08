
namespace household_management.View
{
    partial class PopulationsReport
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
            this.pRViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // pRViewer
            // 
            this.pRViewer.ActiveViewIndex = -1;
            this.pRViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pRViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.pRViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pRViewer.Location = new System.Drawing.Point(0, 0);
            this.pRViewer.Name = "pRViewer";
            this.pRViewer.Size = new System.Drawing.Size(800, 450);
            this.pRViewer.TabIndex = 0;
            // 
            // PopulationsReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pRViewer);
            this.Name = "PopulationsReport";
            this.Text = "PopulationsReport";
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer pRViewer;
    }
}