namespace C968
{
    partial class MonthlyAppointments
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
            this.monthlyAppReportDGV = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.monthlyAppReportDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // monthlyAppReportDGV
            // 
            this.monthlyAppReportDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.monthlyAppReportDGV.Location = new System.Drawing.Point(12, 61);
            this.monthlyAppReportDGV.Name = "monthlyAppReportDGV";
            this.monthlyAppReportDGV.RowHeadersVisible = false;
            this.monthlyAppReportDGV.Size = new System.Drawing.Size(561, 377);
            this.monthlyAppReportDGV.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(208, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Monthly Appointments Report";
            // 
            // MonthlyAppointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.monthlyAppReportDGV);
            this.Name = "MonthlyAppointments";
            this.Text = "MonthlyAppointments";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MonthlyAppointments_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.monthlyAppReportDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView monthlyAppReportDGV;
        private System.Windows.Forms.Label label1;
    }
}