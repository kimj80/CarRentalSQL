namespace Cmpt291UI
{
    partial class LoginScreen
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
            this.Welcome = new System.Windows.Forms.Label();
            this.employeeNumLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.employeeNumBox = new System.Windows.Forms.TextBox();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.Clear = new System.Windows.Forms.Button();
            this.Login = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Welcome
            // 
            this.Welcome.AutoSize = true;
            this.Welcome.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Welcome.Font = new System.Drawing.Font("Arial", 15.9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Welcome.Location = new System.Drawing.Point(336, 75);
            this.Welcome.Name = "Welcome";
            this.Welcome.Size = new System.Drawing.Size(256, 62);
            this.Welcome.TabIndex = 0;
            this.Welcome.Text = "Welcome";
            // 
            // employeeNumLabel
            // 
            this.employeeNumLabel.AutoSize = true;
            this.employeeNumLabel.Location = new System.Drawing.Point(93, 224);
            this.employeeNumLabel.Name = "employeeNumLabel";
            this.employeeNumLabel.Size = new System.Drawing.Size(248, 32);
            this.employeeNumLabel.TabIndex = 1;
            this.employeeNumLabel.Text = "Employee Number";
            this.employeeNumLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(147, 335);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(138, 32);
            this.PasswordLabel.TabIndex = 2;
            this.PasswordLabel.Text = "Password";
            this.PasswordLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // employeeNumBox
            // 
            this.employeeNumBox.Location = new System.Drawing.Point(383, 218);
            this.employeeNumBox.Name = "employeeNumBox";
            this.employeeNumBox.Size = new System.Drawing.Size(322, 38);
            this.employeeNumBox.TabIndex = 3;
            this.employeeNumBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(383, 329);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.Size = new System.Drawing.Size(322, 38);
            this.passwordBox.TabIndex = 4;
            this.passwordBox.UseSystemPasswordChar = true;
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(259, 446);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(184, 68);
            this.Clear.TabIndex = 5;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // Login
            // 
            this.Login.Location = new System.Drawing.Point(489, 446);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(184, 68);
            this.Login.TabIndex = 6;
            this.Login.Text = "Login";
            this.Login.UseVisualStyleBackColor = true;
            this.Login.Click += new System.EventHandler(this.Login_Click);
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(647, 649);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(184, 59);
            this.Exit.TabIndex = 7;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(259, 536);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(414, 68);
            this.button1.TabIndex = 8;
            this.button1.Text = "Sign Up";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // LoginScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 785);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.Login);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.employeeNumBox);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.employeeNumLabel);
            this.Controls.Add(this.Welcome);
            this.Name = "LoginScreen";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.LoginScreen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Welcome;
        private System.Windows.Forms.Label employeeNumLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.TextBox employeeNumBox;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.Button Login;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Button button1;
    }
}