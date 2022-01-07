
namespace household_management.View
{
    partial class HouseholdForm
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
            this.hViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // hViewer
            // 
            this.hViewer.ActiveViewIndex = -1;
            this.hViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.hViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hViewer.Location = new System.Drawing.Point(0, 0);
            this.hViewer.Name = "hViewer";
            this.hViewer.Size = new System.Drawing.Size(800, 450);
            this.hViewer.TabIndex = 0;
            // 
            // HouseholdForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.hViewer);
            this.Name = "HouseholdForm";
            this.Text = "HouseholdForm";
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer hViewer;
    }
}