namespace Cmpt291UI
{
    partial class CustomerWindow
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.Title = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.CarColor = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CarEngine = new System.Windows.Forms.RichTextBox();
            this.CarYear = new System.Windows.Forms.RichTextBox();
            this.CarTrim = new System.Windows.Forms.RichTextBox();
            this.CarName = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Logout = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.BtnReceipt = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.Title);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(906, 91);
            this.panel1.TabIndex = 0;
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(31)))), ((int)(((byte)(63)))));
            this.Title.Location = new System.Drawing.Point(139, 32);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(485, 36);
            this.Title.TabIndex = 0;
            this.Title.Text = "Welcome to Elites Car Rentals!";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pictureBox1.Location = new System.Drawing.Point(12, 162);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(846, 492);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.label1.Location = new System.Drawing.Point(14, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.label2.Location = new System.Drawing.Point(14, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Car Type:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.label3.Location = new System.Drawing.Point(14, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "Year:";
            // 
            // BtnSearch
            // 
            this.BtnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.BtnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnSearch.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSearch.ForeColor = System.Drawing.Color.White;
            this.BtnSearch.Location = new System.Drawing.Point(613, 685);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(277, 74);
            this.BtnSearch.TabIndex = 6;
            this.BtnSearch.Text = "Book Cars";
            this.BtnSearch.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.CarColor);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.CarEngine);
            this.panel2.Controls.Add(this.CarYear);
            this.panel2.Controls.Add(this.CarTrim);
            this.panel2.Controls.Add(this.CarName);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(12, 685);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(570, 217);
            this.panel2.TabIndex = 7;
            // 
            // CarColor
            // 
            this.CarColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.CarColor.Font = new System.Drawing.Font("Calibri", 10F);
            this.CarColor.ForeColor = System.Drawing.Color.Black;
            this.CarColor.Location = new System.Drawing.Point(84, 166);
            this.CarColor.Name = "CarColor";
            this.CarColor.Size = new System.Drawing.Size(217, 29);
            this.CarColor.TabIndex = 11;
            this.CarColor.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F);
            this.label5.Location = new System.Drawing.Point(18, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 24);
            this.label5.TabIndex = 10;
            this.label5.Text = "Color:";
            // 
            // CarEngine
            // 
            this.CarEngine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.CarEngine.Font = new System.Drawing.Font("Calibri", 10F);
            this.CarEngine.ForeColor = System.Drawing.Color.Black;
            this.CarEngine.Location = new System.Drawing.Point(131, 126);
            this.CarEngine.Name = "CarEngine";
            this.CarEngine.Size = new System.Drawing.Size(170, 29);
            this.CarEngine.TabIndex = 9;
            this.CarEngine.Text = "";
            // 
            // CarYear
            // 
            this.CarYear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.CarYear.Font = new System.Drawing.Font("Calibri", 10F);
            this.CarYear.ForeColor = System.Drawing.Color.Black;
            this.CarYear.Location = new System.Drawing.Point(71, 88);
            this.CarYear.Name = "CarYear";
            this.CarYear.Size = new System.Drawing.Size(111, 29);
            this.CarYear.TabIndex = 8;
            this.CarYear.Text = "";
            // 
            // CarTrim
            // 
            this.CarTrim.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.CarTrim.Font = new System.Drawing.Font("Calibri", 10F);
            this.CarTrim.ForeColor = System.Drawing.Color.Black;
            this.CarTrim.Location = new System.Drawing.Point(107, 49);
            this.CarTrim.Name = "CarTrim";
            this.CarTrim.Size = new System.Drawing.Size(282, 29);
            this.CarTrim.TabIndex = 7;
            this.CarTrim.Text = "";
            // 
            // CarName
            // 
            this.CarName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.CarName.Font = new System.Drawing.Font("Calibri", 10F);
            this.CarName.ForeColor = System.Drawing.Color.Black;
            this.CarName.Location = new System.Drawing.Point(84, 10);
            this.CarName.Name = "CarName";
            this.CarName.Size = new System.Drawing.Size(440, 29);
            this.CarName.TabIndex = 6;
            this.CarName.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.label4.Location = new System.Drawing.Point(14, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 24);
            this.label4.TabIndex = 5;
            this.label4.Text = "Engine Type:";
            // 
            // Logout
            // 
            this.Logout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Logout.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Logout.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Logout.ForeColor = System.Drawing.Color.White;
            this.Logout.Location = new System.Drawing.Point(613, 867);
            this.Logout.Name = "Logout";
            this.Logout.Size = new System.Drawing.Size(277, 74);
            this.Logout.TabIndex = 6;
            this.Logout.Text = "Log Out";
            this.Logout.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 14F);
            this.label6.Location = new System.Drawing.Point(666, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(160, 29);
            this.label6.TabIndex = 9;
            this.label6.Text = "Welcome, User";
            // 
            // BtnReceipt
            // 
            this.BtnReceipt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.BtnReceipt.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnReceipt.Font = new System.Drawing.Font("Cambria", 12F);
            this.BtnReceipt.ForeColor = System.Drawing.Color.White;
            this.BtnReceipt.Location = new System.Drawing.Point(613, 777);
            this.BtnReceipt.Name = "BtnReceipt";
            this.BtnReceipt.Size = new System.Drawing.Size(277, 74);
            this.BtnReceipt.TabIndex = 6;
            this.BtnReceipt.Text = "Booking Receipt";
            this.BtnReceipt.UseVisualStyleBackColor = false;
            // 
            // CustomerWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(950, 989);
            this.Controls.Add(this.BtnReceipt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Logout);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.BtnSearch);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Name = "CustomerWindow";
            this.Text = "CustomerWindow";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox CarEngine;
        private System.Windows.Forms.RichTextBox CarYear;
        private System.Windows.Forms.RichTextBox CarTrim;
        private System.Windows.Forms.RichTextBox CarName;
        private System.Windows.Forms.Button Logout;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox CarColor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BtnReceipt;
    }
}