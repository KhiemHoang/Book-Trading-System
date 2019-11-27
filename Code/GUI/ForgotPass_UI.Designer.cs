namespace GUI
{
    partial class ForgotPass_UI
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
            this.btn_Submit = new System.Windows.Forms.Button();
            this.lbl_Promo3 = new System.Windows.Forms.Label();
            this.lbl_Promo2 = new System.Windows.Forms.Label();
            this.lbl_Login = new System.Windows.Forms.Label();
            this.lbl_OTPWarn = new System.Windows.Forms.Label();
            this.lbl_EmailWarn = new System.Windows.Forms.Label();
            this.lbl_GenWarn = new System.Windows.Forms.Label();
            this.btn_Send = new System.Windows.Forms.Button();
            this.lbl_OTP = new System.Windows.Forms.Label();
            this.tbx_OTP = new System.Windows.Forms.TextBox();
            this.lbl_Email = new System.Windows.Forms.Label();
            this.tbx_Email = new System.Windows.Forms.TextBox();
            this.lbl_Promo1 = new System.Windows.Forms.Label();
            this.lbl_Name = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Submit
            // 
            this.btn_Submit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btn_Submit.ForeColor = System.Drawing.Color.Black;
            this.btn_Submit.Location = new System.Drawing.Point(165, 375);
            this.btn_Submit.Name = "btn_Submit";
            this.btn_Submit.Size = new System.Drawing.Size(75, 35);
            this.btn_Submit.TabIndex = 3;
            this.btn_Submit.Text = "Submit";
            this.btn_Submit.UseVisualStyleBackColor = true;
            this.btn_Submit.Click += new System.EventHandler(this.btn_Submit_Click);
            // 
            // lbl_Promo3
            // 
            this.lbl_Promo3.AutoSize = true;
            this.lbl_Promo3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lbl_Promo3.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lbl_Promo3.Location = new System.Drawing.Point(107, 269);
            this.lbl_Promo3.Name = "lbl_Promo3";
            this.lbl_Promo3.Size = new System.Drawing.Size(195, 17);
            this.lbl_Promo3.TabIndex = 27;
            this.lbl_Promo3.Text = "please type OTP Code below.";
            // 
            // lbl_Promo2
            // 
            this.lbl_Promo2.AutoSize = true;
            this.lbl_Promo2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lbl_Promo2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lbl_Promo2.Location = new System.Drawing.Point(72, 250);
            this.lbl_Promo2.Name = "lbl_Promo2";
            this.lbl_Promo2.Size = new System.Drawing.Size(270, 17);
            this.lbl_Promo2.TabIndex = 26;
            this.lbl_Promo2.Text = "An intruction has been sent to your email,";
            // 
            // lbl_Login
            // 
            this.lbl_Login.AutoSize = true;
            this.lbl_Login.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lbl_Login.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbl_Login.Location = new System.Drawing.Point(303, 425);
            this.lbl_Login.Name = "lbl_Login";
            this.lbl_Login.Size = new System.Drawing.Size(94, 13);
            this.lbl_Login.TabIndex = 4;
            this.lbl_Login.Text = "Back to Login >>>";
            this.lbl_Login.Click += new System.EventHandler(this.lbl_Login_Click);
            // 
            // lbl_OTPWarn
            // 
            this.lbl_OTPWarn.AutoSize = true;
            this.lbl_OTPWarn.ForeColor = System.Drawing.Color.Crimson;
            this.lbl_OTPWarn.Location = new System.Drawing.Point(174, 339);
            this.lbl_OTPWarn.Name = "lbl_OTPWarn";
            this.lbl_OTPWarn.Size = new System.Drawing.Size(168, 13);
            this.lbl_OTPWarn.TabIndex = 24;
            this.lbl_OTPWarn.Text = "* OTP Code must be filled or valid.";
            // 
            // lbl_EmailWarn
            // 
            this.lbl_EmailWarn.AutoSize = true;
            this.lbl_EmailWarn.ForeColor = System.Drawing.Color.Crimson;
            this.lbl_EmailWarn.Location = new System.Drawing.Point(257, 170);
            this.lbl_EmailWarn.Name = "lbl_EmailWarn";
            this.lbl_EmailWarn.Size = new System.Drawing.Size(83, 13);
            this.lbl_EmailWarn.TabIndex = 23;
            this.lbl_EmailWarn.Text = "* Email required.";
            // 
            // lbl_GenWarn
            // 
            this.lbl_GenWarn.AutoSize = true;
            this.lbl_GenWarn.ForeColor = System.Drawing.Color.Crimson;
            this.lbl_GenWarn.Location = new System.Drawing.Point(83, 123);
            this.lbl_GenWarn.Name = "lbl_GenWarn";
            this.lbl_GenWarn.Size = new System.Drawing.Size(75, 13);
            this.lbl_GenWarn.TabIndex = 22;
            this.lbl_GenWarn.Text = "* Invalid email.";
            // 
            // btn_Send
            // 
            this.btn_Send.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btn_Send.ForeColor = System.Drawing.Color.Black;
            this.btn_Send.Location = new System.Drawing.Point(165, 195);
            this.btn_Send.Name = "btn_Send";
            this.btn_Send.Size = new System.Drawing.Size(75, 35);
            this.btn_Send.TabIndex = 1;
            this.btn_Send.Text = "Send";
            this.btn_Send.UseVisualStyleBackColor = true;
            this.btn_Send.Click += new System.EventHandler(this.btn_Send_Click);
            // 
            // lbl_OTP
            // 
            this.lbl_OTP.AutoSize = true;
            this.lbl_OTP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_OTP.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lbl_OTP.Location = new System.Drawing.Point(48, 313);
            this.lbl_OTP.Name = "lbl_OTP";
            this.lbl_OTP.Size = new System.Drawing.Size(86, 20);
            this.lbl_OTP.TabIndex = 20;
            this.lbl_OTP.Text = "OTP Code:";
            // 
            // tbx_OTP
            // 
            this.tbx_OTP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_OTP.Location = new System.Drawing.Point(140, 310);
            this.tbx_OTP.Name = "tbx_OTP";
            this.tbx_OTP.Size = new System.Drawing.Size(202, 26);
            this.tbx_OTP.TabIndex = 2;
            this.tbx_OTP.UseSystemPasswordChar = true;
            // 
            // lbl_Email
            // 
            this.lbl_Email.AutoSize = true;
            this.lbl_Email.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Email.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lbl_Email.Location = new System.Drawing.Point(82, 143);
            this.lbl_Email.Name = "lbl_Email";
            this.lbl_Email.Size = new System.Drawing.Size(52, 20);
            this.lbl_Email.TabIndex = 18;
            this.lbl_Email.Text = "Email:";
            // 
            // tbx_Email
            // 
            this.tbx_Email.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_Email.Location = new System.Drawing.Point(140, 140);
            this.tbx_Email.Name = "tbx_Email";
            this.tbx_Email.Size = new System.Drawing.Size(202, 26);
            this.tbx_Email.TabIndex = 0;
            // 
            // lbl_Promo1
            // 
            this.lbl_Promo1.AutoSize = true;
            this.lbl_Promo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbl_Promo1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lbl_Promo1.Location = new System.Drawing.Point(82, 80);
            this.lbl_Promo1.Name = "lbl_Promo1";
            this.lbl_Promo1.Size = new System.Drawing.Size(245, 20);
            this.lbl_Promo1.TabIndex = 16;
            this.lbl_Promo1.Text = "Enter your email to get OTP Code";
            // 
            // lbl_Name
            // 
            this.lbl_Name.AutoSize = true;
            this.lbl_Name.Font = new System.Drawing.Font("OCR A Extended", 30F, System.Drawing.FontStyle.Bold);
            this.lbl_Name.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lbl_Name.Location = new System.Drawing.Point(133, 25);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(168, 41);
            this.lbl_Name.TabIndex = 15;
            this.lbl_Name.Text = "OR4NGE";
            // 
            // ForgotPass_UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.ClientSize = new System.Drawing.Size(409, 446);
            this.Controls.Add(this.btn_Submit);
            this.Controls.Add(this.lbl_Promo3);
            this.Controls.Add(this.lbl_Promo2);
            this.Controls.Add(this.lbl_Login);
            this.Controls.Add(this.lbl_OTPWarn);
            this.Controls.Add(this.lbl_EmailWarn);
            this.Controls.Add(this.lbl_GenWarn);
            this.Controls.Add(this.btn_Send);
            this.Controls.Add(this.lbl_OTP);
            this.Controls.Add(this.tbx_OTP);
            this.Controls.Add(this.lbl_Email);
            this.Controls.Add(this.tbx_Email);
            this.Controls.Add(this.lbl_Promo1);
            this.Controls.Add(this.lbl_Name);
            this.Name = "ForgotPass_UI";
            this.Text = "ForgotPass_UI";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ForgotPass_UI_FormClosing);
            this.Load += new System.EventHandler(this.ForgotPass_UI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Submit;
        private System.Windows.Forms.Label lbl_Promo3;
        private System.Windows.Forms.Label lbl_Promo2;
        private System.Windows.Forms.Label lbl_Login;
        private System.Windows.Forms.Label lbl_OTPWarn;
        private System.Windows.Forms.Label lbl_EmailWarn;
        private System.Windows.Forms.Label lbl_GenWarn;
        private System.Windows.Forms.Button btn_Send;
        private System.Windows.Forms.Label lbl_OTP;
        private System.Windows.Forms.TextBox tbx_OTP;
        private System.Windows.Forms.Label lbl_Email;
        private System.Windows.Forms.TextBox tbx_Email;
        private System.Windows.Forms.Label lbl_Promo1;
        private System.Windows.Forms.Label lbl_Name;
    }
}