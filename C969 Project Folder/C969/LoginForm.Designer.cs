namespace C969
{
    partial class LoginForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.ExitButton = new System.Windows.Forms.Button();
            this.LoginButton = new System.Windows.Forms.Button();
            this.PassLabel = new System.Windows.Forms.Label();
            this.UserLabel = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.LanguageTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // ExitButton
            // 
            resources.ApplyResources(this.ExitButton, "ExitButton");
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // LoginButton
            // 
            resources.ApplyResources(this.LoginButton, "LoginButton");
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // PassLabel
            // 
            resources.ApplyResources(this.PassLabel, "PassLabel");
            this.PassLabel.Name = "PassLabel";
            // 
            // UserLabel
            // 
            resources.ApplyResources(this.UserLabel, "UserLabel");
            this.UserLabel.Name = "UserLabel";
            // 
            // passwordTextBox
            // 
            resources.ApplyResources(this.passwordTextBox, "passwordTextBox");
            this.passwordTextBox.Name = "passwordTextBox";
            // 
            // usernameTextBox
            // 
            resources.ApplyResources(this.usernameTextBox, "usernameTextBox");
            this.usernameTextBox.Name = "usernameTextBox";
            // 
            // LanguageTimer
            // 
            this.LanguageTimer.Tick += new System.EventHandler(this.LanguageTimer_Tick);
            // 
            // LoginForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.PassLabel);
            this.Controls.Add(this.UserLabel);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.usernameTextBox);
            this.Name = "LoginForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.Label PassLabel;
        private System.Windows.Forms.Label UserLabel;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Timer LanguageTimer;
    }
}

