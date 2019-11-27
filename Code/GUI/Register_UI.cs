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
    public partial class Register_UI : Form
    {
        BUS_Customer busCus = new BUS_Customer();
        DTO_Customer dtoCus = new DTO_Customer();
        public Register_UI()
        {
            InitializeComponent();
        }
        
        private void Register_UI_Load(object sender, EventArgs e)
        {

        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbx_Address.Text) || string.IsNullOrEmpty(tbx_Email.Text) || string.IsNullOrEmpty(tbx_Password.Text) || string.IsNullOrEmpty(tbx_UserName.Text))
            {
                MessageBox.Show("You must fill required Information!!!");
            }
            else if (busCus.checkNameExist(tbx_UserName.Text) > 0)
            {
                MessageBox.Show("User name exits!!!");
            }
            else
            {
                dtoCus = new DTO_Customer(0, tbx_UserName.Text, tbx_Password.Text, tbx_Email.Text, tbx_Address.Text, 0, "System", "getdate()", "System", "getdate()");
                if (busCus.addCustomer(dtoCus))
                {
                    MessageBox.Show("Register success.");
                }

                else
                    MessageBox.Show("Register fail.");
            }
        }

        private void lbl_Login_Click(object sender, EventArgs e)
        {
            this.Hide();
            GUI.Login_UI uiLogin = new Login_UI();
            uiLogin.Show();
        }
    }
}
