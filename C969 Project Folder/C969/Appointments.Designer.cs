namespace C968
{
    partial class Appointments
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
            this.monthlyCalendar = new System.Windows.Forms.MonthCalendar();
            this.addAppointmentButton = new System.Windows.Forms.Button();
            this.updateAppointmentButton = new System.Windows.Forms.Button();
            this.deleteAppointmentButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.appointmentsReport = new System.Windows.Forms.Button();
            this.schedulesReport = new System.Windows.Forms.Button();
            this.customersAndAppointmentsReport = new System.Windows.Forms.Button();
            this.monthlyWeeklyApptDataGrid = new System.Windows.Forms.DataGridView();
            this.rbWeek = new System.Windows.Forms.RadioButton();
            this.rbMonth = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.monthlyWeeklyApptDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // monthlyCalendar
            // 
            this.monthlyCalendar.Location = new System.Drawing.Point(525, 29);
            this.monthlyCalendar.Name = "monthlyCalendar";
            this.monthlyCalendar.TabIndex = 1;
            this.monthlyCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthlyCalendar_DateChanged);
            this.monthlyCalendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthlyCalendar_DateSelected);
            // 
            // addAppointmentButton
            // 
            this.addAppointmentButton.Location = new System.Drawing.Point(18, 220);
            this.addAppointmentButton.Name = "addAppointmentButton";
            this.addAppointmentButton.Size = new System.Drawing.Size(75, 23);
            this.addAppointmentButton.TabIndex = 10;
            this.addAppointmentButton.Text = "Add";
            this.addAppointmentButton.UseVisualStyleBackColor = true;
            this.addAppointmentButton.Click += new System.EventHandler(this.addAppointmentButton_Click);
            // 
            // updateAppointmentButton
            // 
            this.updateAppointmentButton.Location = new System.Drawing.Point(99, 220);
            this.updateAppointmentButton.Name = "updateAppointmentButton";
            this.updateAppointmentButton.Size = new System.Drawing.Size(75, 23);
            this.updateAppointmentButton.TabIndex = 11;
            this.updateAppointmentButton.Text = "Update";
            this.updateAppointmentButton.UseVisualStyleBackColor = true;
            this.updateAppointmentButton.Click += new System.EventHandler(this.updateAppointmentButton_Click);
            // 
            // deleteAppointmentButton
            // 
            this.deleteAppointmentButton.Location = new System.Drawing.Point(180, 220);
            this.deleteAppointmentButton.Name = "deleteAppointmentButton";
            this.deleteAppointmentButton.Size = new System.Drawing.Size(75, 23);
            this.deleteAppointmentButton.TabIndex = 12;
            this.deleteAppointmentButton.Text = "Delete";
            this.deleteAppointmentButton.UseVisualStyleBackColor = true;
            this.deleteAppointmentButton.Click += new System.EventHandler(this.deleteAppointmentButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(677, 235);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 17;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // appointmentsReport
            // 
            this.appointmentsReport.Location = new System.Drawing.Point(275, 220);
            this.appointmentsReport.Name = "appointmentsReport";
            this.appointmentsReport.Size = new System.Drawing.Size(121, 37);
            this.appointmentsReport.TabIndex = 18;
            this.appointmentsReport.Text = "Monthly Appointments Report";
            this.appointmentsReport.UseVisualStyleBackColor = true;
            this.appointmentsReport.Click += new System.EventHandler(this.appointmentsReport_Click);
            // 
            // schedulesReport
            // 
            this.schedulesReport.Location = new System.Drawing.Point(402, 219);
            this.schedulesReport.Name = "schedulesReport";
            this.schedulesReport.Size = new System.Drawing.Size(121, 38);
            this.schedulesReport.TabIndex = 19;
            this.schedulesReport.Text = "User Schedules";
            this.schedulesReport.UseVisualStyleBackColor = true;
            this.schedulesReport.Click += new System.EventHandler(this.schedulesReport_Click);
            // 
            // customersAndAppointmentsReport
            // 
            this.customersAndAppointmentsReport.Location = new System.Drawing.Point(529, 220);
            this.customersAndAppointmentsReport.Name = "customersAndAppointmentsReport";
            this.customersAndAppointmentsReport.Size = new System.Drawing.Size(121, 38);
            this.customersAndAppointmentsReport.TabIndex = 20;
            this.customersAndAppointmentsReport.Text = "Customers and Appintments";
            this.customersAndAppointmentsReport.UseVisualStyleBackColor = true;
            this.customersAndAppointmentsReport.Click += new System.EventHandler(this.customersAndAppointmentsReport_Click);
            // 
            // monthlyWeeklyApptDataGrid
            // 
            this.monthlyWeeklyApptDataGrid.AllowUserToAddRows = false;
            this.monthlyWeeklyApptDataGrid.AllowUserToDeleteRows = false;
            this.monthlyWeeklyApptDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.monthlyWeeklyApptDataGrid.Location = new System.Drawing.Point(18, 29);
            this.monthlyWeeklyApptDataGrid.Name = "monthlyWeeklyApptDataGrid";
            this.monthlyWeeklyApptDataGrid.ReadOnly = true;
            this.monthlyWeeklyApptDataGrid.RowHeadersVisible = false;
            this.monthlyWeeklyApptDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.monthlyWeeklyApptDataGrid.Size = new System.Drawing.Size(478, 161);
            this.monthlyWeeklyApptDataGrid.TabIndex = 21;
            // 
            // rbWeek
            // 
            this.rbWeek.AutoSize = true;
            this.rbWeek.Location = new System.Drawing.Point(18, 8);
            this.rbWeek.Name = "rbWeek";
            this.rbWeek.Size = new System.Drawing.Size(91, 17);
            this.rbWeek.TabIndex = 22;
            this.rbWeek.TabStop = true;
            this.rbWeek.Text = "View by week";
            this.rbWeek.UseVisualStyleBackColor = true;
            this.rbWeek.CheckedChanged += new System.EventHandler(this.rbWeek_CheckedChanged);
            // 
            // rbMonth
            // 
            this.rbMonth.AutoSize = true;
            this.rbMonth.Location = new System.Drawing.Point(115, 8);
            this.rbMonth.Name = "rbMonth";
            this.rbMonth.Size = new System.Drawing.Size(94, 17);
            this.rbMonth.TabIndex = 23;
            this.rbMonth.TabStop = true;
            this.rbMonth.Text = "View by month";
            this.rbMonth.UseVisualStyleBackColor = true;
            this.rbMonth.CheckedChanged += new System.EventHandler(this.rbMonth_CheckedChanged);
            // 
            // Appointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 278);
            this.Controls.Add(this.rbMonth);
            this.Controls.Add(this.rbWeek);
            this.Controls.Add(this.monthlyWeeklyApptDataGrid);
            this.Controls.Add(this.customersAndAppointmentsReport);
            this.Controls.Add(this.schedulesReport);
            this.Controls.Add(this.appointmentsReport);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.deleteAppointmentButton);
            this.Controls.Add(this.updateAppointmentButton);
            this.Controls.Add(this.addAppointmentButton);
            this.Controls.Add(this.monthlyCalendar);
            this.Name = "Appointments";
            this.Text = "Appointments";
            this.Load += new System.EventHandler(this.Appointments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.monthlyWeeklyApptDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar monthlyCalendar;
        private System.Windows.Forms.Button addAppointmentButton;
        private System.Windows.Forms.Button updateAppointmentButton;
        private System.Windows.Forms.Button deleteAppointmentButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button appointmentsReport;
        private System.Windows.Forms.Button schedulesReport;
        private System.Windows.Forms.Button customersAndAppointmentsReport;
        private System.Windows.Forms.DataGridView monthlyWeeklyApptDataGrid;
        private System.Windows.Forms.RadioButton rbWeek;
        private System.Windows.Forms.RadioButton rbMonth;
    }
}