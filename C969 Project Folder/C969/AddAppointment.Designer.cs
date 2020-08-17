namespace C968
{
    partial class AddAppointment
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
            this.custComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.typeTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.startDTP = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.endDTP = new System.Windows.Forms.DateTimePicker();
            this.addButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // custComboBox
            // 
            this.custComboBox.FormattingEnabled = true;
            this.custComboBox.Location = new System.Drawing.Point(109, 30);
            this.custComboBox.Name = "custComboBox";
            this.custComboBox.Size = new System.Drawing.Size(200, 21);
            this.custComboBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Customer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Title";
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new System.Drawing.Point(109, 72);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(200, 20);
            this.titleTextBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Type";
            // 
            // typeTextBox
            // 
            this.typeTextBox.Location = new System.Drawing.Point(109, 109);
            this.typeTextBox.Name = "typeTextBox";
            this.typeTextBox.Size = new System.Drawing.Size(200, 20);
            this.typeTextBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Start Time";
            // 
            // startDTP
            // 
            this.startDTP.CustomFormat = "MM/dd/yyyy hh:mm tt";
            this.startDTP.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startDTP.Location = new System.Drawing.Point(109, 154);
            this.startDTP.Name = "startDTP";
            this.startDTP.Size = new System.Drawing.Size(200, 20);
            this.startDTP.TabIndex = 50;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 196);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 51;
            this.label5.Text = "End Time";
            // 
            // endDTP
            // 
            this.endDTP.CustomFormat = "MM/dd/yyyy hh:mm tt";
            this.endDTP.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.endDTP.Location = new System.Drawing.Point(109, 196);
            this.endDTP.Name = "endDTP";
            this.endDTP.Size = new System.Drawing.Size(200, 20);
            this.endDTP.TabIndex = 52;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(100, 233);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 27);
            this.addButton.TabIndex = 53;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(181, 233);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 27);
            this.cancelButton.TabIndex = 54;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // AddAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 286);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.endDTP);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.startDTP);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.typeTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.custComboBox);
            this.Name = "AddAppointment";
            this.Text = "AddAppointment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox custComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox typeTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker startDTP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker endDTP;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button cancelButton;
    }
}