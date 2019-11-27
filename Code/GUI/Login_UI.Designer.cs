namespace GUI
{
    partial class Login_UI
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
            this.lbl_Forgot = new System.Windows.Forms.Label();
            this.lbl_PassWarn = new System.Windows.Forms.Label();
            this.lbl_UNameWarn = new System.Windows.Forms.Label();
            this.lbl_GenWarn = new System.Windows.Forms.Label();
            this.btn_Submit = new System.Windows.Forms.Button();
            this.lbl_Password = new System.Windows.Forms.Label();
            this.tbx_Password = new System.Windows.Forms.TextBox();
            this.lbl_Username = new System.Windows.Forms.Label();
            this.tbx_Username = new System.Windows.Forms.TextBox();
            this.lbl_Promo2 = new System.Windows.Forms.Label();
            this.lbl_Promo1 = new System.Windows.Forms.Label();
            this.lbl_Name = new System.Windows.Forms.Label();
            this.lbl_Create = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_Forgot
            // 
            this.lbl_Forgot.AutoSize = true;
            this.lbl_Forgot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lbl_Forgot.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbl_Forgot.Location = new System.Drawing.Point(144, 315);
            this.lbl_Forgot.Name = "lbl_Forgot";
            this.lbl_Forgot.Size = new System.Drawing.Size(117, 13);
            this.lbl_Forgot.TabIndex = 23;
            this.lbl_Forgot.Text = "Forgot your password ?";
            this.lbl_Forgot.Click += new System.EventHandler(this.lbl_Forgot_Click);
            // 
            // lbl_PassWarn
            // 
            this.lbl_PassWarn.AutoSize = true;
            this.lbl_PassWarn.ForeColor = System.Drawing.Color.Crimson;
            this.lbl_PassWarn.Location = new System.Drawing.Point(234, 244);
            this.lbl_PassWarn.Name = "lbl_PassWarn";
            this.lbl_PassWarn.Size = new System.Drawing.Size(104, 13);
            this.lbl_PassWarn.TabIndex = 22;
            this.lbl_PassWarn.Text = "* Password required.";
            // 
            // lbl_UNameWarn
            // 
            this.lbl_UNameWarn.AutoSize = true;
            this.lbl_UNameWarn.ForeColor = System.Drawing.Color.Crimson;
            this.lbl_UNameWarn.Location = new System.Drawing.Point(234, 184);
            this.lbl_UNameWarn.Name = "lbl_UNameWarn";
            this.lbl_UNameWarn.Size = new System.Drawing.Size(106, 13);
            this.lbl_UNameWarn.TabIndex = 21;
            this.lbl_UNameWarn.Text = "* Username required.";
            // 
            // lbl_GenWarn
            // 
            this.lbl_GenWarn.AutoSize = true;
            this.lbl_GenWarn.ForeColor = System.Drawing.Color.Crimson;
            this.lbl_GenWarn.Location = new System.Drawing.Point(46, 135);
            this.lbl_GenWarn.Name = "lbl_GenWarn";
            this.lbl_GenWarn.Size = new System.Drawing.Size(157, 13);
            this.lbl_GenWarn.TabIndex = 20;
            this.lbl_GenWarn.Text = "* Invalid username or password.";
            // 
            // btn_Submit
            // 
            this.btn_Submit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btn_Submit.ForeColor = System.Drawing.Color.Black;
            this.btn_Submit.Location = new System.Drawing.Point(165, 275);
            this.btn_Submit.Name = "btn_Submit";
            this.btn_Submit.Size = new System.Drawing.Size(75, 35);
            this.btn_Submit.TabIndex = 19;
            this.btn_Submit.Text = "Submit";
            this.btn_Submit.UseVisualStyleBackColor = true;
            this.btn_Submit.Click += new System.EventHandler(this.btn_Submit_Click);
            // 
            // lbl_Password
            // 
            this.lbl_Password.AutoSize = true;
            this.lbl_Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Password.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lbl_Password.Location = new System.Drawing.Point(50, 218);
            this.lbl_Password.Name = "lbl_Password";
            this.lbl_Password.Size = new System.Drawing.Size(82, 20);
            this.lbl_Password.TabIndex = 18;
            this.lbl_Password.Text = "Password:";
            // 
            // tbx_Password
            // 
            this.tbx_Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_Password.Location = new System.Drawing.Point(138, 215);
            this.tbx_Password.Name = "tbx_Password";
            this.tbx_Password.Size = new System.Drawing.Size(202, 26);
            this.tbx_Password.TabIndex = 17;
            this.tbx_Password.UseSystemPasswordChar = true;
            // 
            // lbl_Username
            // 
            this.lbl_Username.AutoSize = true;
            this.lbl_Username.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Username.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lbl_Username.Location = new System.Drawing.Point(45, 158);
            this.lbl_Username.Name = "lbl_Username";
            this.lbl_Username.Size = new System.Drawing.Size(87, 20);
            this.lbl_Username.TabIndex = 16;
            this.lbl_Username.Text = "Username:";
            // 
            // tbx_Username
            // 
            this.tbx_Username.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_Username.Location = new System.Drawing.Point(138, 155);
            this.tbx_Username.Name = "tbx_Username";
            this.tbx_Username.Size = new System.Drawing.Size(202, 26);
            this.tbx_Username.TabIndex = 15;
            // 
            // lbl_Promo2
            // 
            this.lbl_Promo2.AutoSize = true;
            this.lbl_Promo2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbl_Promo2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lbl_Promo2.Location = new System.Drawing.Point(102, 95);
            this.lbl_Promo2.Name = "lbl_Promo2";
            this.lbl_Promo2.Size = new System.Drawing.Size(206, 20);
            this.lbl_Promo2.TabIndex = 14;
            this.lbl_Promo2.Text = "to access into control panel.";
            // 
            // lbl_Promo1
            // 
            this.lbl_Promo1.AutoSize = true;
            this.lbl_Promo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbl_Promo1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lbl_Promo1.Location = new System.Drawing.Point(175, 75);
            this.lbl_Promo1.Name = "lbl_Promo1";
            this.lbl_Promo1.Size = new System.Drawing.Size(57, 20);
            this.lbl_Promo1.TabIndex = 13;
            this.lbl_Promo1.Text = "Sign in";
            // 
            // lbl_Name
            // 
            this.lbl_Name.AutoSize = true;
            this.lbl_Name.Font = new System.Drawing.Font("OCR A Extended", 30F, System.Drawing.FontStyle.Bold);
            this.lbl_Name.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lbl_Name.Location = new System.Drawing.Point(110, 20);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(193, 41);
            this.lbl_Name.TabIndex = 12;
            this.lbl_Name.Text = "ORG4NGE";
            // 
            // lbl_Create
            // 
            this.lbl_Create.AutoSize = true;
            this.lbl_Create.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Create.ForeColor = System.Drawing.Color.DarkCyan;
            this.lbl_Create.Location = new System.Drawing.Point(211, 384);
            this.lbl_Create.Name = "lbl_Create";
            this.lbl_Create.Size = new System.Drawing.Size(166, 18);
            this.lbl_Create.TabIndex = 28;
            this.lbl_Create.Text = "Create New Account >>";
            this.lbl_Create.Click += new System.EventHandler(this.lbl_Create_Click);
            // 
            // Login_UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.ClientSize = new System.Drawing.Size(394, 411);
            this.Controls.Add(this.lbl_Create);
            this.Controls.Add(this.lbl_Forgot);
            this.Controls.Add(this.lbl_PassWarn);
            this.Controls.Add(this.lbl_UNameWarn);
            this.Controls.Add(this.lbl_GenWarn);
            this.Controls.Add(this.btn_Submit);
            this.Controls.Add(this.lbl_Password);
            this.Controls.Add(this.tbx_Password);
            this.Controls.Add(this.lbl_Username);
            this.Controls.Add(this.tbx_Username);
            this.Controls.Add(this.lbl_Promo2);
            this.Controls.Add(this.lbl_Promo1);
            this.Controls.Add(this.lbl_Name);
            this.Name = "Login_UI";
            this.Text = "Login_UI";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Login_UI_FormClosing);
            this.Load += new System.EventHandler(this.Login_UI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Forgot;
        private System.Windows.Forms.Label lbl_PassWarn;
        private System.Windows.Forms.Label lbl_UNameWarn;
        private System.Windows.Forms.Label lbl_GenWarn;
        private System.Windows.Forms.Button btn_Submit;
        private System.Windows.Forms.Label lbl_Password;
        private System.Windows.Forms.TextBox tbx_Password;
        private System.Windows.Forms.Label lbl_Username;
        private System.Windows.Forms.TextBox tbx_Username;
        private System.Windows.Forms.Label lbl_Promo2;
        private System.Windows.Forms.Label lbl_Promo1;
        private System.Windows.Forms.Label lbl_Name;
        private System.Windows.Forms.Label lbl_Create;
    }
}