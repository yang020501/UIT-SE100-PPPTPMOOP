
namespace household_management.View
{
    partial class PopulationsForm
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
            this.pViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // pViewer
            // 
            this.pViewer.ActiveViewIndex = -1;
            this.pViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.pViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pViewer.Location = new System.Drawing.Point(0, 0);
            this.pViewer.Name = "pViewer";
            this.pViewer.Size = new System.Drawing.Size(800, 450);
            this.pViewer.TabIndex = 0;
            // 
            // PopulationsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pViewer);
            this.Name = "PopulationsForm";
            this.Text = "PopulationsForm";
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer pViewer;
    }
}