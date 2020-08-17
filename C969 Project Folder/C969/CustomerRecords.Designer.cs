namespace C968
{
    partial class CustomerRecords
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
            this.customerDataGrid = new System.Windows.Forms.DataGridView();
            this.addCustomerButton = new System.Windows.Forms.Button();
            this.updateCustomerButton = new System.Windows.Forms.Button();
            this.deleteCustomerButton = new System.Windows.Forms.Button();
            this.appointmentsButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.customerDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // customerDataGrid
            // 
            this.customerDataGrid.AllowUserToAddRows = false;
            this.customerDataGrid.AllowUserToDeleteRows = false;
            this.customerDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customerDataGrid.Location = new System.Drawing.Point(31, 59);
            this.customerDataGrid.Name = "customerDataGrid";
            this.customerDataGrid.ReadOnly = true;
            this.customerDataGrid.RowHeadersVisible = false;
            this.customerDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.customerDataGrid.Size = new System.Drawing.Size(741, 307);
            this.customerDataGrid.TabIndex = 0;
            this.customerDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.customerDataGrid_CellContentClick);
            // 
            // addCustomerButton
            // 
            this.addCustomerButton.Location = new System.Drawing.Point(28, 384);
            this.addCustomerButton.Name = "addCustomerButton";
            this.addCustomerButton.Size = new System.Drawing.Size(111, 23);
            this.addCustomerButton.TabIndex = 1;
            this.addCustomerButton.Text = "Add Customer";
            this.addCustomerButton.UseVisualStyleBackColor = true;
            this.addCustomerButton.Click += new System.EventHandler(this.addCustomerButton_Click);
            // 
            // updateCustomerButton
            // 
            this.updateCustomerButton.Location = new System.Drawing.Point(145, 384);
            this.updateCustomerButton.Name = "updateCustomerButton";
            this.updateCustomerButton.Size = new System.Drawing.Size(111, 23);
            this.updateCustomerButton.TabIndex = 2;
            this.updateCustomerButton.Text = "Update Customer";
            this.updateCustomerButton.UseVisualStyleBackColor = true;
            this.updateCustomerButton.Click += new System.EventHandler(this.updateCustomerButton_Click);
            // 
            // deleteCustomerButton
            // 
            this.deleteCustomerButton.Location = new System.Drawing.Point(262, 384);
            this.deleteCustomerButton.Name = "deleteCustomerButton";
            this.deleteCustomerButton.Size = new System.Drawing.Size(111, 23);
            this.deleteCustomerButton.TabIndex = 3;
            this.deleteCustomerButton.Text = "Delete Customer";
            this.deleteCustomerButton.UseVisualStyleBackColor = true;
            this.deleteCustomerButton.Click += new System.EventHandler(this.deleteCustomerButton_Click);
            // 
            // appointmentsButton
            // 
            this.appointmentsButton.Location = new System.Drawing.Point(541, 384);
            this.appointmentsButton.Name = "appointmentsButton";
            this.appointmentsButton.Size = new System.Drawing.Size(111, 23);
            this.appointmentsButton.TabIndex = 4;
            this.appointmentsButton.Text = "Appointments";
            this.appointmentsButton.UseVisualStyleBackColor = true;
            this.appointmentsButton.Click += new System.EventHandler(this.appointmentsButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(658, 384);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(111, 23);
            this.exitButton.TabIndex = 5;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // CustomerRecords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.appointmentsButton);
            this.Controls.Add(this.deleteCustomerButton);
            this.Controls.Add(this.updateCustomerButton);
            this.Controls.Add(this.addCustomerButton);
            this.Controls.Add(this.customerDataGrid);
            this.Name = "CustomerRecords";
            this.Text = "Customer Records";
            ((System.ComponentModel.ISupportInitialize)(this.customerDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView customerDataGrid;
        private System.Windows.Forms.Button addCustomerButton;
        private System.Windows.Forms.Button updateCustomerButton;
        private System.Windows.Forms.Button deleteCustomerButton;
        private System.Windows.Forms.Button appointmentsButton;
        private System.Windows.Forms.Button exitButton;
    }
}