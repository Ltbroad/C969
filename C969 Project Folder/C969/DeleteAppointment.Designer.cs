namespace C968
{
    partial class DeleteAppointment
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
            this.searchButton = new System.Windows.Forms.Button();
            this.appComboBox = new System.Windows.Forms.ComboBox();
            this.appointmentLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.endDTP = new System.Windows.Forms.DateTimePicker();
            this.endTimeLabel = new System.Windows.Forms.Label();
            this.startDTP = new System.Windows.Forms.DateTimePicker();
            this.startTimeLabel = new System.Windows.Forms.Label();
            this.typeTextBox = new System.Windows.Forms.TextBox();
            this.typeLabel = new System.Windows.Forms.Label();
            this.locationLabel = new System.Windows.Forms.Label();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.customerLabel = new System.Windows.Forms.Label();
            this.locationTextBox = new System.Windows.Forms.TextBox();
            this.customerTextBox = new System.Windows.Forms.TextBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(19, 305);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 89;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // appComboBox
            // 
            this.appComboBox.FormattingEnabled = true;
            this.appComboBox.Location = new System.Drawing.Point(114, 16);
            this.appComboBox.Name = "appComboBox";
            this.appComboBox.Size = new System.Drawing.Size(200, 21);
            this.appComboBox.TabIndex = 88;
            // 
            // appointmentLabel
            // 
            this.appointmentLabel.AutoSize = true;
            this.appointmentLabel.Location = new System.Drawing.Point(17, 16);
            this.appointmentLabel.Name = "appointmentLabel";
            this.appointmentLabel.Size = new System.Drawing.Size(66, 13);
            this.appointmentLabel.TabIndex = 87;
            this.appointmentLabel.Text = "Appointment";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(262, 303);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 27);
            this.cancelButton.TabIndex = 86;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // endDTP
            // 
            this.endDTP.CustomFormat = "MM/dd/yyyy hh:mm tt";
            this.endDTP.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.endDTP.Location = new System.Drawing.Point(114, 267);
            this.endDTP.Name = "endDTP";
            this.endDTP.Size = new System.Drawing.Size(200, 20);
            this.endDTP.TabIndex = 84;
            // 
            // endTimeLabel
            // 
            this.endTimeLabel.AutoSize = true;
            this.endTimeLabel.Location = new System.Drawing.Point(17, 267);
            this.endTimeLabel.Name = "endTimeLabel";
            this.endTimeLabel.Size = new System.Drawing.Size(52, 13);
            this.endTimeLabel.TabIndex = 83;
            this.endTimeLabel.Text = "End Time";
            // 
            // startDTP
            // 
            this.startDTP.CustomFormat = "MM/dd/yyyy hh:mm tt";
            this.startDTP.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startDTP.Location = new System.Drawing.Point(114, 225);
            this.startDTP.Name = "startDTP";
            this.startDTP.Size = new System.Drawing.Size(200, 20);
            this.startDTP.TabIndex = 82;
            // 
            // startTimeLabel
            // 
            this.startTimeLabel.AutoSize = true;
            this.startTimeLabel.Location = new System.Drawing.Point(17, 225);
            this.startTimeLabel.Name = "startTimeLabel";
            this.startTimeLabel.Size = new System.Drawing.Size(55, 13);
            this.startTimeLabel.TabIndex = 81;
            this.startTimeLabel.Text = "Start Time";
            // 
            // typeTextBox
            // 
            this.typeTextBox.Location = new System.Drawing.Point(114, 180);
            this.typeTextBox.Name = "typeTextBox";
            this.typeTextBox.Size = new System.Drawing.Size(200, 20);
            this.typeTextBox.TabIndex = 80;
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Location = new System.Drawing.Point(17, 180);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(31, 13);
            this.typeLabel.TabIndex = 79;
            this.typeLabel.Text = "Type";
            // 
            // locationLabel
            // 
            this.locationLabel.AutoSize = true;
            this.locationLabel.Location = new System.Drawing.Point(17, 137);
            this.locationLabel.Name = "locationLabel";
            this.locationLabel.Size = new System.Drawing.Size(48, 13);
            this.locationLabel.TabIndex = 77;
            this.locationLabel.Text = "Location";
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new System.Drawing.Point(114, 97);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(200, 20);
            this.titleTextBox.TabIndex = 76;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(17, 97);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(27, 13);
            this.titleLabel.TabIndex = 75;
            this.titleLabel.Text = "Title";
            // 
            // customerLabel
            // 
            this.customerLabel.AutoSize = true;
            this.customerLabel.Location = new System.Drawing.Point(18, 54);
            this.customerLabel.Name = "customerLabel";
            this.customerLabel.Size = new System.Drawing.Size(51, 13);
            this.customerLabel.TabIndex = 74;
            this.customerLabel.Text = "Customer";
            // 
            // locationTextBox
            // 
            this.locationTextBox.Location = new System.Drawing.Point(114, 137);
            this.locationTextBox.Name = "locationTextBox";
            this.locationTextBox.Size = new System.Drawing.Size(200, 20);
            this.locationTextBox.TabIndex = 91;
            // 
            // customerTextBox
            // 
            this.customerTextBox.Location = new System.Drawing.Point(114, 54);
            this.customerTextBox.Name = "customerTextBox";
            this.customerTextBox.Size = new System.Drawing.Size(200, 20);
            this.customerTextBox.TabIndex = 92;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(137, 307);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 93;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // DeleteAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 357);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.customerTextBox);
            this.Controls.Add(this.locationTextBox);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.appComboBox);
            this.Controls.Add(this.appointmentLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.endDTP);
            this.Controls.Add(this.endTimeLabel);
            this.Controls.Add(this.startDTP);
            this.Controls.Add(this.startTimeLabel);
            this.Controls.Add(this.typeTextBox);
            this.Controls.Add(this.typeLabel);
            this.Controls.Add(this.locationLabel);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.customerLabel);
            this.Name = "DeleteAppointment";
            this.Text = "DeleteAppointment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.ComboBox appComboBox;
        private System.Windows.Forms.Label appointmentLabel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.DateTimePicker endDTP;
        private System.Windows.Forms.Label endTimeLabel;
        private System.Windows.Forms.DateTimePicker startDTP;
        private System.Windows.Forms.Label startTimeLabel;
        private System.Windows.Forms.TextBox typeTextBox;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.Label locationLabel;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label customerLabel;
        private System.Windows.Forms.TextBox locationTextBox;
        private System.Windows.Forms.TextBox customerTextBox;
        private System.Windows.Forms.Button deleteButton;
    }
}