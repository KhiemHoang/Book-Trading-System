using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;
using System.Net;
using System.Net.Mail;

namespace GUI
{
    public partial class Email_UI : Form
    {
        public static string Email;
        public Email_UI()
        {
            InitializeComponent();
        }

        private void Email_UI_Load(object sender, EventArgs e)
        {
            Email = GUI.StaffControl_UI.Email;
            tbx_Email.Text = Email;
        }

        //For sending Email
        private void btn_Send_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbx_Content.Text) == false)
            {
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("khiem120998@gmail.com");
                msg.To.Add(tbx_Email.Text);
                msg.Subject = tbx_Subject.Text;
                msg.Body = tbx_Content.Text;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Credentials = new System.Net.NetworkCredential("khiem120998@gmail.com", "Minhkhiem123");
                smtp.Send(msg);
            }
            else
                MessageBox.Show("At least type something !!!");
        }

        //Back to Staff Control
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            GUI.StaffControl_UI uiStf = new StaffControl_UI();
            this.Hide();
            uiStf.Show();
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            tbx_Content.Text = tbx_Subject.Text = "";
        }
    }
}
