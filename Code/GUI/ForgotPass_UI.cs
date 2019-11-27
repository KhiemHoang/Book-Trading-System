using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DTO;
using BUS;
using System.Net;
using System.Net.Mail;

namespace GUI
{
    public partial class ForgotPass_UI : Form
    {
        BUS_Customer busCus = new BUS_Customer();
        private static string Pass = "";
        public ForgotPass_UI()
        {
            InitializeComponent();
            this.lbl_GenWarn.Hide();
            this.lbl_EmailWarn.Hide();
            this.lbl_OTPWarn.Hide();
        }

        private void ForgotPass_UI_Load(object sender, EventArgs e)
        {

        }

        private void btn_Send_Click(object sender, EventArgs e)
        {
            if (this.tbx_Email.Text == "")
            {
                this.lbl_GenWarn.Hide();
                this.lbl_EmailWarn.Show();
                this.lbl_OTPWarn.Hide();
            }
            else if (busCus.checkCusEmail(tbx_Email.Text) == 2)
            {
                this.lbl_GenWarn.Show();
                this.lbl_EmailWarn.Hide();
                this.lbl_OTPWarn.Hide();
            }
            else if (busCus.checkCusEmail(tbx_Email.Text) == 1)
            {
                Pass = busCus.getCusPass(tbx_Email.Text);
                this.lbl_GenWarn.Hide();
                this.lbl_EmailWarn.Hide();
                this.lbl_OTPWarn.Hide();
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("khiem120998@gmail.com");
                msg.To.Add(tbx_Email.Text);
                msg.Subject = "OTP Code request";
                msg.Body = "123";
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Credentials = new System.Net.NetworkCredential("khiem120998@gmail.com", "Minhkhiem123");
                smtp.Send(msg);
            }
            else
            {
                MessageBox.Show("Error happaned!!!" + busCus.checkCusEmail(tbx_Email.Text));
            }

        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            if (tbx_OTP.Text != "123")
            {
                this.lbl_GenWarn.Hide();
                this.lbl_EmailWarn.Hide();
                this.lbl_OTPWarn.Show();
            }
            else if (tbx_OTP.Text == "123")
            {
                this.lbl_GenWarn.Hide();
                this.lbl_EmailWarn.Hide();
                this.lbl_OTPWarn.Hide();
                MessageBox.Show("Your password is: " + Pass);
            }
        }

        private void lbl_Login_Click(object sender, EventArgs e)
        {
            this.Hide();
            GUI.Login_UI Login = new Login_UI();
            Login.Show();
        }
        

        private void ForgotPass_UI_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
        
    }
}
