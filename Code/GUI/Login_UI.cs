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

namespace GUI
{
    public partial class Login_UI : Form
    {
        BUS_Customer busCus = new BUS_Customer();
        BUS_Staff busStf = new BUS_Staff();
        public static string UserName = "";
        public static int UserID = 0;
        public static int Admin_Flag = 0;
        public Login_UI()
        {
            InitializeComponent();
            this.lbl_GenWarn.Hide();
            this.lbl_UNameWarn.Hide();
            this.lbl_PassWarn.Hide();
        }

        private void Login_UI_Load(object sender, EventArgs e)
        {
        }

        //Confirm Login
        private void btn_Submit_Click(object sender, EventArgs e)
        {
            if (this.tbx_Username.Text == "")
            {
                this.lbl_UNameWarn.Show();
                this.lbl_GenWarn.Hide();
                this.lbl_PassWarn.Hide();
            }
            else if (this.tbx_Password.Text == "")
            {
                this.lbl_PassWarn.Show();
                this.lbl_UNameWarn.Hide();
                this.lbl_GenWarn.Hide();
            }
            else if (busCus.checkUserValid(tbx_Username.Text, tbx_Password.Text) == 1)
            {
                this.lbl_UNameWarn.Hide();
                this.lbl_GenWarn.Hide();
                this.lbl_PassWarn.Hide();
                UserName = tbx_Username.Text;
                UserID = busCus.getUserID(tbx_Username.Text);
                MessageBox.Show("Welcome back: " + tbx_Username.Text);
                this.Hide();
                GUI.Cus_Search_UI uiCus = new GUI.Cus_Search_UI();
                uiCus.Show();
            }
            else if (busStf.checkUserValid(tbx_Username.Text, tbx_Password.Text) == 1)
            {
                this.lbl_UNameWarn.Hide();
                this.lbl_GenWarn.Hide();
                this.lbl_PassWarn.Hide();
                UserName = tbx_Username.Text;
                UserID = busStf.getUserID(tbx_Username.Text);
                Admin_Flag = busStf.checkStfRole(tbx_Username.Text);
                MessageBox.Show("Welcome back: " + tbx_Username.Text);
                this.Hide();
                GUI.StaffControl_UI uiStf = new GUI.StaffControl_UI();
                uiStf.Show();
            }
            else if (busCus.checkUserValid(tbx_Username.Text, tbx_Password.Text) == 2 || busStf.checkUserValid(tbx_Username.Text, tbx_Password.Text) == 2)
            {
                this.lbl_GenWarn.Show();
                this.lbl_UNameWarn.Hide();
                this.lbl_PassWarn.Hide();
            }
            else
            {
                MessageBox.Show("Error happened!!!");
            }
        }
        
        //Confirm forgot password
        private void lbl_Forgot_Click(object sender, EventArgs e)
        {
            this.Hide();
            GUI.ForgotPass_UI form = new ForgotPass_UI();
            form.Show();
        }

        private void Login_UI_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
        
        private void lbl_Create_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register_UI uiRegister = new Register_UI();
            uiRegister.Show();
        }
    }
}
