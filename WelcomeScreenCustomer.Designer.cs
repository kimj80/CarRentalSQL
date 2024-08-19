namespace Cmpt291UI
{
    partial class CustomerLogin
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
            this.SignUpButton = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.Login = new System.Windows.Forms.Button();
            this.Clear = new System.Windows.Forms.Button();
            this.customerPasswordBox = new System.Windows.Forms.TextBox();
            this.customerIDBox = new System.Windows.Forms.TextBox();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.employeeNumLabel = new System.Windows.Forms.Label();
            this.Welcome = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SignUpButton
            // 
            this.SignUpButton.Location = new System.Drawing.Point(228, 522);
            this.SignUpButton.Name = "SignUpButton";
            this.SignUpButton.Size = new System.Drawing.Size(362, 64);
            this.SignUpButton.TabIndex = 17;
            this.SignUpButton.Text = "Sign Up";
            this.SignUpButton.UseVisualStyleBackColor = true;
            this.SignUpButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(568, 628);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(161, 55);
            this.Exit.TabIndex = 16;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Login
            // 
            this.Login.Location = new System.Drawing.Point(430, 438);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(161, 64);
            this.Login.TabIndex = 15;
            this.Login.Text = "Login";
            this.Login.UseVisualStyleBackColor = true;
            this.Login.Click += new System.EventHandler(this.Login_Click);
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(228, 438);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(161, 64);
            this.Clear.TabIndex = 14;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // customerPasswordBox
            // 
            this.customerPasswordBox.Location = new System.Drawing.Point(414, 328);
            this.customerPasswordBox.Name = "customerPasswordBox";
            this.customerPasswordBox.Size = new System.Drawing.Size(282, 35);
            this.customerPasswordBox.TabIndex = 13;
            this.customerPasswordBox.UseSystemPasswordChar = true;
            // 
            // customerIDBox
            // 
            this.customerIDBox.Location = new System.Drawing.Point(414, 225);
            this.customerIDBox.Name = "customerIDBox";
            this.customerIDBox.Size = new System.Drawing.Size(282, 35);
            this.customerIDBox.TabIndex = 12;
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(167, 334);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(126, 29);
            this.PasswordLabel.TabIndex = 11;
            this.PasswordLabel.Text = "Password:";
            // 
            // employeeNumLabel
            // 
            this.employeeNumLabel.AutoSize = true;
            this.employeeNumLabel.Location = new System.Drawing.Point(139, 230);
            this.employeeNumLabel.Name = "employeeNumLabel";
            this.employeeNumLabel.Size = new System.Drawing.Size(152, 29);
            this.employeeNumLabel.TabIndex = 10;
            this.employeeNumLabel.Text = "Customer ID:";
            // 
            // Welcome
            // 
            this.Welcome.AutoSize = true;
            this.Welcome.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Welcome.Font = new System.Drawing.Font("Arial", 15.9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Welcome.Location = new System.Drawing.Point(294, 70);
            this.Welcome.Name = "Welcome";
            this.Welcome.Size = new System.Drawing.Size(234, 56);
            this.Welcome.TabIndex = 9;
            this.Welcome.Text = "Welcome";
            // 
            // CustomerLogin
            // 
            this.AcceptButton = this.Login;
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 736);
            this.Controls.Add(this.SignUpButton);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.Login);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.customerPasswordBox);
            this.Controls.Add(this.customerIDBox);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.employeeNumLabel);
            this.Controls.Add(this.Welcome);
            this.Name = "CustomerLogin";
            this.Text = "Customer Login";
            this.Load += new System.EventHandler(this.CustomerLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SignUpButton;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Button Login;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.TextBox customerPasswordBox;
        private System.Windows.Forms.TextBox customerIDBox;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Label employeeNumLabel;
        private System.Windows.Forms.Label Welcome;
    }
}