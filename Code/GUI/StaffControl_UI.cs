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
using System.Windows.Forms;
using DTO;
using BUS;

namespace GUI
{
    public partial class StaffControl_UI : Form
    {
        BUS_Book busBook = new BUS_Book();
        BUS_Stock busStock = new BUS_Stock();
        BUS_Customer busCus = new BUS_Customer();
        BUS_Staff busStf = new BUS_Staff();
        public static int BID;  //Book ID
        public static int UserID = Login_UI.UserID; //User Login ID
        public static int Price;    //Price of single book
        public static int CusID;    //Customer ID
        public static string Email;
        public static int StfID;
        public StaffControl_UI()
        {
            InitializeComponent();
        }

        private void StaffControl_UI_Load(object sender, EventArgs e)
        {

            //Hiding and showing Staff and Admin function
            Staff_Function.TabPages.Remove(tab_BookControl);
            Staff_Function.TabPages.Remove(tab_CustomerControll);
            Staff_Function.TabPages.Remove(tab_StfControl);
            Staff_Function.TabPages.Remove(tab_Report);
            Staff_Function.TabPages.Remove(tab_Account);

            lbl_StfName.Text = GUI.Login_UI.UserName;
            if (Login_UI.Admin_Flag == 1)
            {
                Staff_Function.TabPages.Add(tab_BookControl);
                Staff_Function.TabPages.Add(tab_CustomerControll);
                Staff_Function.TabPages.Add(tab_StfControl);
                Staff_Function.TabPages.Add(tab_Report);
                Staff_Function.TabPages.Add(tab_Account);
            }
            else
            {
                Staff_Function.TabPages.Add(tab_BookControl);
                Staff_Function.TabPages.Add(tab_CustomerControll);
                Staff_Function.TabPages.Add(tab_Report);
                Staff_Function.TabPages.Add(tab_Account);
            }


            //Fill Staff table
            this.dtg_StfView.DataSource = busStf.getAllStf();
            //Fill Customer table
            this.dtg_CustomerView.DataSource = busCus.getAllCustomer();
            //Fill Book table
            this.dtg_BookView.DataSource = busBook.getAllBook();



            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-BLOGEJ9;Initial Catalog=Book_controlling;Integrated Security=True");
            //SqlConnection con = new SqlConnection(@"Data Source=118.68.247.62;Initial Catalog=Book-controlling;Integrated Security=True");

            //Auto recommend Book
            //
            SqlCommand cmd_Book = new SqlCommand("select book_name from book;", con);
            con.Open();
            SqlDataReader sdr_Book = cmd_Book.ExecuteReader();
            AutoCompleteStringCollection myconnect_Book = new AutoCompleteStringCollection();
            while (sdr_Book.Read())
            {
                myconnect_Book.Add(sdr_Book.GetString(0));
            }
            tbx_BookSearch.AutoCompleteCustomSource = myconnect_Book;
            con.Close();
            //Count Total book
            lbl_TotalBook.Text = dtg_BookView.RowCount.ToString();


            //Auto recomend Customer
            //
            SqlCommand cmd_Customer = new SqlCommand("select cus_username from customer;", con);
            con.Open();
            SqlDataReader sdr_Customer = cmd_Customer.ExecuteReader();
            AutoCompleteStringCollection myconnect_Customer = new AutoCompleteStringCollection();
            while (sdr_Customer.Read())
            {
                myconnect_Customer.Add(sdr_Customer.GetString(0));
            }
            tbx_CustomerSearch.AutoCompleteCustomSource = myconnect_Customer;
            con.Close();
            //Count Total customer
            lbl_TotalCus.Text = dtg_CustomerView.RowCount.ToString();



            //Auto recomend Staff
            //
            SqlCommand cmd_Stf = new SqlCommand("select stf_username from staff;", con);
            con.Open();
            SqlDataReader sdr_Stf = cmd_Stf.ExecuteReader();
            AutoCompleteStringCollection myconnect_Stf = new AutoCompleteStringCollection();
            while (sdr_Stf.Read())
            {
                myconnect_Stf.Add(sdr_Stf.GetString(0));
            }
            tbx_StfSearch.AutoCompleteCustomSource = myconnect_Stf;
            con.Close();
            //Count Total staff
            lbl_TotalStf.Text = dtg_StfView.RowCount.ToString();


            //Get data of Account
            //
            SqlCommand cmd_Acc = new SqlCommand("select * from staff where stf_id = " + UserID, con);
            con.Open();
            SqlDataReader sdr_Acc = cmd_Acc.ExecuteReader();
            AutoCompleteStringCollection myconnect_Acc = new AutoCompleteStringCollection();
            while (sdr_Acc.Read())
            {
                tbx_AccID.Text = UserID.ToString();
                tbx_AccName.Text = sdr_Acc.GetString(1);
                tbx_AccEmail.Text = sdr_Acc.GetString(3);
                if (sdr_Acc.GetInt32(4) == 1)
                {
                    tbx_AccRole.Text = "Admin";
                }
                else
                    tbx_AccRole.Text = "Staff";
            }
            con.Close();
        }



        /*===================================BOOK CONTROL TAB================================*/

        //Enter Search Box
        private void tbx_BookSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtg_BookView.DataSource = busBook.getBook_byName(tbx_BookSearch.Text);
                lbl_TotalBook.Text = dtg_BookView.RowCount.ToString();
            }
        }


        //Pull data to textbox from dtg
        private void dtg_BookView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = e.RowIndex;
                DataGridViewRow selectRow = dtg_BookView.Rows[index];
                tbx_SKU.Text = selectRow.Cells[0].Value.ToString();
                tbx_BookName.Text = selectRow.Cells[1].Value.ToString();
                tbx_BookAuthor.Text = selectRow.Cells[2].Value.ToString();
                tbx_BookPrice.Text = selectRow.Cells[3].Value.ToString();
                tbx_BCB.Text = selectRow.Cells[4].Value.ToString();
                tbx_BCD.Text = selectRow.Cells[5].Value.ToString();
                tbx_BUB.Text = selectRow.Cells[6].Value.ToString();
                tbx_BUD.Text = selectRow.Cells[7].Value.ToString();
                try
                {
                    BID = Convert.ToInt32(tbx_SKU.Text);
                    Price = Convert.ToInt32(tbx_BookPrice.Text);
                }
                catch { };

                tbx_BookQuantity.Text = busStock.getQuantity(BID).ToString();
            }
            catch { };
        }


        //Click add button
        private void btn_BookAdd_Click(object sender, EventArgs e)
        {
            btn_BAddSave.Visible = btn_BookCancel.Visible = true;
            btn_BookAdd.Enabled = false;            
            tbx_SKU.Text = tbx_BookName.Text = tbx_BookAuthor.Text = tbx_BookPrice.Text = tbx_BCB.Text = tbx_BCD.Text = tbx_BUB.Text = tbx_BUD.Text = tbx_BookQuantity.Text = "";
            tbx_BookName.ReadOnly = tbx_BookAuthor.ReadOnly = tbx_BookPrice.ReadOnly = tbx_BookQuantity.ReadOnly = false;
        }
        //Save Add information 
        private void btn_BAddSave_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty(tbx_BookName.Text) == false) && (string.IsNullOrEmpty(tbx_BookAuthor.Text) == false) && (string.IsNullOrEmpty(tbx_BookPrice.Text) == false) && (string.IsNullOrEmpty(tbx_BookQuantity.Text) == false))
            {
                DTO_Book dtoBook = new DTO_Book(0, tbx_BookName.Text, tbx_BookAuthor.Text, Convert.ToInt32(tbx_BookPrice.Text), lbl_StfName.Text, "getdate()", lbl_StfName.Text, "getdate()");

                if (busBook.addBook(dtoBook))
                {
                    DTO_Stock dtoStock = new DTO_Stock(0, busBook.getBookMaxID(), Convert.ToInt32(tbx_BookQuantity.Text), lbl_StfName.Text, "getdate()", lbl_StfName.Text, "getdate()");
                    if (busStock.addStock(dtoStock))
                    {
                        MessageBox.Show("Add success.");
                        btn_BAddSave.Visible = false;
                        btn_BookAdd.Enabled = true;
                        tbx_SKU.Text = tbx_BookName.Text = tbx_BookAuthor.Text = tbx_BookPrice.Text = tbx_BCB.Text = tbx_BCD.Text = tbx_BUB.Text = tbx_BUD.Text = tbx_BookQuantity.Text = "";
                        tbx_BookName.ReadOnly = tbx_BookAuthor.ReadOnly = tbx_BookPrice.ReadOnly = tbx_BookQuantity.ReadOnly = true;
                        this.dtg_BookView.DataSource = busBook.getAllBook();
                        lbl_TotalBook.Text = dtg_BookView.RowCount.ToString();
                    }
                    else
                        MessageBox.Show("Error Stock happened");
                }
                else
                    MessageBox.Show("Error Book happened");
                
            }
            else
                MessageBox.Show("Please fill needed information!!!");
        }


        //Click Update button
        private void btn_Update_Click(object sender, EventArgs e)
        {
            btn_Update.Enabled = false;
            btn_BUpdateSave.Visible = btn_BookCancel.Visible = true;            
            tbx_BookName.ReadOnly = tbx_BookAuthor.ReadOnly = tbx_BookPrice.ReadOnly = tbx_BookQuantity.ReadOnly = false;
        }
        //Save Update information 
        private void btn_BUpdateSave_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty(tbx_BookName.Text) == false) && (string.IsNullOrEmpty(tbx_BookAuthor.Text) == false) && (string.IsNullOrEmpty(tbx_BookPrice.Text) == false) && (string.IsNullOrEmpty(tbx_BookQuantity.Text) == false))
            {
                DTO_Book dtoBook = new DTO_Book(Convert.ToInt32(tbx_SKU.Text), tbx_BookName.Text, tbx_BookAuthor.Text, Convert.ToInt32(tbx_BookPrice.Text), lbl_StfName.Text, "getdate()", lbl_StfName.Text, "getdate()");
                                
                if(busBook.updateBook(dtoBook))
                {
                    if(busStock.updateQuantity(Convert.ToInt32(tbx_SKU.Text), Convert.ToInt32(tbx_BookQuantity.Text), lbl_StfName.Text))
                    {
                        MessageBox.Show("Update Success.");
                        btn_Update.Enabled = true;
                        btn_BUpdateSave.Visible = btn_BookCancel.Visible = false;
                        tbx_BookName.ReadOnly = tbx_BookAuthor.ReadOnly = tbx_BookPrice.ReadOnly = tbx_BookQuantity.ReadOnly = true;
                        this.dtg_BookView.DataSource = busBook.getAllBook();
                        lbl_TotalBook.Text = dtg_BookView.RowCount.ToString();
                    }
                    else
                        MessageBox.Show("Error Stock happened");
                }
                else
                    MessageBox.Show("Error Book happened");
            }
            else
                MessageBox.Show("Please fill needed information!!!");
        }

        
        //Click Delete button
        private void btn_BookDelete_Click(object sender, EventArgs e)
        {
            btn_BookDelete.Enabled = false;
            btn_BDelSave.Visible = btn_BookCancel.Visible = true;

        }
        //Save Delete information
        private void btn_BDelSave_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty(tbx_SKU.Text) == false))
            {
                if(busStock.delStock(Convert.ToInt32(tbx_SKU.Text)) && busBook.delBook(Convert.ToInt32(tbx_SKU.Text)))
                {
                    MessageBox.Show("Remove success.");
                    btn_BookDelete.Enabled = true;
                    btn_BDelSave.Visible = btn_BookCancel.Visible = false;
                    this.dtg_BookView.DataSource = busBook.getAllBook();
                    lbl_TotalBook.Text = dtg_BookView.RowCount.ToString();
                }
                else
                    MessageBox.Show("Error book happened!!!");
            }
            else
                MessageBox.Show("Please pick a book to remove!!!");
        }


        //Click Refresh Button
        private void btn_BookReset_Click(object sender, EventArgs e)
        {
            dtg_BookView.DataSource = busBook.getAllBook();
            lbl_TotalBook.Text = dtg_BookView.RowCount.ToString();
            btn_BAddSave.Visible = btn_BUpdateSave.Visible = btn_BDelSave.Visible = btn_BookCancel.Visible = false;
            btn_BookAdd.Enabled = btn_Update.Enabled = btn_BookDelete.Enabled = true;
            tbx_SKU.Text = tbx_BookName.Text = tbx_BookAuthor.Text = tbx_BookPrice.Text = tbx_BCB.Text = tbx_BCD.Text = tbx_BUB.Text = tbx_BUD.Text = tbx_BookQuantity.Text = "";
            tbx_BookName.ReadOnly = tbx_BookAuthor.ReadOnly = tbx_BookPrice.ReadOnly = tbx_BookQuantity.ReadOnly = true;
        }
        //Click to stop any action
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            btn_BAddSave.Visible = btn_BUpdateSave.Visible = btn_BDelSave.Visible = btn_BookCancel.Visible = false;
            btn_BookAdd.Enabled = btn_Update.Enabled = btn_BookDelete.Enabled = true;
            tbx_SKU.Text = tbx_BookName.Text = tbx_BookAuthor.Text = tbx_BookPrice.Text = tbx_BCB.Text = tbx_BCD.Text = tbx_BUB.Text = tbx_BUD.Text = tbx_BookQuantity.Text = "";
            tbx_BookName.ReadOnly = tbx_BookAuthor.ReadOnly = tbx_BookPrice.ReadOnly = tbx_BookQuantity.ReadOnly = true;
        }




        /*===================================CUSTOMER CONTROL TAB================================*/

        //Key down for Customer Search
        private void tbx_CustomerSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtg_CustomerView.DataSource = busCus.getCus_byName(tbx_CustomerSearch.Text);
                lbl_TotalCus.Text = dtg_CustomerView.RowCount.ToString();
            }
        }

        //pull data to textbox
        private void dtg_CustomerView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = e.RowIndex;
                DataGridViewRow selectRow = dtg_CustomerView.Rows[index];
                tbx_CusID.Text = selectRow.Cells[0].Value.ToString();
                tbx_CusName.Text = selectRow.Cells[1].Value.ToString();
                tbx_CusEmail.Text = selectRow.Cells[2].Value.ToString();
                tbx_CusAddr.Text = selectRow.Cells[3].Value.ToString();
                if (Convert.ToInt32(selectRow.Cells[4].Value.ToString()) == 1)
                {
                    tbx_CusStatus.Text = "Ban";
                }
                else
                    tbx_CusStatus.Text = "Normal";
                tbx_CusCB.Text = selectRow.Cells[5].Value.ToString();
                tbx_CusCD.Text = selectRow.Cells[6].Value.ToString();
                tbx_CusUB.Text = selectRow.Cells[7].Value.ToString();
                tbx_CusUD.Text = selectRow.Cells[8].Value.ToString();
                try
                {
                    CusID = Convert.ToInt32(selectRow.Cells[0].Value.ToString());
                }
                catch { };
                tbx_CusTotalPurchase.Text = busCus.calculatePurchase(CusID).ToString();
            }
            catch { };
        }
        
        //Refresh the control panel
        private void btn_CusRefresh_Click(object sender, EventArgs e)
        {
            tbx_CusID.Text = tbx_CusName.Text = tbx_CusEmail.Text = tbx_CusAddr.Text = tbx_CusStatus.Text = tbx_CusCB.Text = tbx_CusCD.Text = tbx_CusUB.Text = tbx_CusUD.Text = tbx_CusTotalPurchase.Text = "";
            btn_CusSave.Visible = btn_CusCancel.Visible = false;
            btn_CusAdd.Enabled = btn_CusUpdate.Enabled = btn_CusDelete.Enabled = true;
            dtg_CustomerView.DataSource = busCus.getAllCustomer();
            lbl_TotalCus.Text = dtg_CustomerView.RowCount.ToString();
        }


        //Add new Customer
        private void btn_CusAdd_Click(object sender, EventArgs e)
        {
            tbx_CusID.Text = tbx_CusName.Text = tbx_CusEmail.Text = tbx_CusAddr.Text = tbx_CusStatus.Text = tbx_CusCB.Text = tbx_CusCD.Text = tbx_CusUB.Text = tbx_CusUD.Text = tbx_CusTotalPurchase.Text = "";
            btn_CusAdd.Enabled = false;
            btn_CusSave.Visible = btn_CusCancel.Visible = true;
            tbx_CusName.ReadOnly = tbx_CusEmail.ReadOnly = tbx_CusAddr.ReadOnly = false;
            btn_CusUpdate.Enabled = btn_CusDelete.Enabled = true;
        }

        //Update Customer
        private void btn_CusUpdate_Click(object sender, EventArgs e)
        {
            btn_CusUpdate.Enabled = false;
            btn_CusSave.Visible = btn_CusCancel.Visible = true;
            tbx_CusAddr.ReadOnly = false;
            btn_CusAdd.Enabled = btn_CusDelete.Enabled  = true;
        }

        //Delete Customer
        private void btn_CusDelete_Click(object sender, EventArgs e)
        {
            btn_CusDelete.Enabled = false;
            btn_CusSave.Visible = btn_CusCancel.Visible = true;
            btn_CusUpdate.Enabled = btn_CusAdd.Enabled = true;
        }

        //Ban Customer
        private void btn_CusBan_Click(object sender, EventArgs e)
        {
            btn_CusDelete.Enabled = btn_CusUpdate.Enabled = btn_CusAdd.Enabled = true;
            tbx_CusName.ReadOnly = tbx_CusEmail.ReadOnly = tbx_CusAddr.ReadOnly = true;

            if ((string.IsNullOrEmpty(tbx_CusName.Text) == false))
            {
                if(busCus.banCustomer(Convert.ToInt32(tbx_CusID.Text)))
                {
                    MessageBox.Show("User has been ban.");
                    this.dtg_CustomerView.DataSource = busCus.getAllCustomer();
                    lbl_TotalCus.Text = dtg_CustomerView.RowCount.ToString();
                }
                else
                    MessageBox.Show("This user has protected Aura, can not removed.");
            }
            else
                MessageBox.Show("Please select at least 1 customer!!!");
        }

        //Email to Customer
        private void btn_CusEmail_Click(object sender, EventArgs e)
        {
            btn_CusUpdate.Enabled = btn_CusAdd.Enabled = btn_CusDelete.Enabled = true;
            btn_CusSave.Visible = btn_CusCancel.Visible = false;
            tbx_CusName.ReadOnly = tbx_CusEmail.ReadOnly = tbx_CusAddr.ReadOnly = true;
            Email = tbx_CusEmail.Text;
            GUI.Email_UI uiEmail = new Email_UI();
            uiEmail.Show();
        }

        

        //Save Customer Control Function
        private void btn_CusSave_Click(object sender, EventArgs e)
        {
            //save Add information
            if (btn_CusAdd.Enabled == false)
            {
                if ((string.IsNullOrEmpty(tbx_CusName.Text) == false) && (string.IsNullOrEmpty(tbx_CusEmail.Text) == false) && (string.IsNullOrEmpty(tbx_CusAddr.Text) == false))
                {
                    DTO_Customer dtoCus = new DTO_Customer(0, tbx_CusName.Text, "1", tbx_CusEmail.Text, tbx_CusAddr.Text, 0, lbl_StfName.Text, "getdate()", lbl_StfName.Text, "getdate()");

                    if (busCus.addCustomer(dtoCus))
                    {
                        MessageBox.Show("Adding success.");
                        tbx_CusID.Text = tbx_CusName.Text = tbx_CusEmail.Text = tbx_CusAddr.Text = tbx_CusStatus.Text = tbx_CusCB.Text = tbx_CusCD.Text = tbx_CusUB.Text = tbx_CusUD.Text = tbx_CusTotalPurchase.Text = "";
                        btn_CusUpdate.Enabled = btn_CusAdd.Enabled = btn_CusDelete.Enabled = true;
                        btn_CusSave.Visible = btn_CusCancel.Visible = false;
                        tbx_CusName.ReadOnly = tbx_CusEmail.ReadOnly = tbx_CusAddr.ReadOnly = true;
                        dtg_CustomerView.DataSource = busCus.getAllCustomer();
                        lbl_TotalCus.Text = dtg_CustomerView.RowCount.ToString();
                    }
                    else
                        MessageBox.Show("Adding fail.");
                }
                else
                    MessageBox.Show("Please fill needed information!!!");
            }


            //Save Update information
            if (btn_CusUpdate.Enabled == false)
            {
                if ((string.IsNullOrEmpty(tbx_CusName.Text) == false) && (string.IsNullOrEmpty(tbx_CusEmail.Text) == false) && (string.IsNullOrEmpty(tbx_CusAddr.Text) == false))
                {
                    if (busCus.updateAddress(Convert.ToInt32(tbx_CusID.Text), tbx_CusAddr.Text, lbl_StfName.Text))
                    {
                        MessageBox.Show("Update Address success.");
                        btn_CusUpdate.Enabled = btn_CusAdd.Enabled = btn_CusDelete.Enabled = true;
                        btn_CusSave.Visible = btn_CusCancel.Visible = false;
                        tbx_CusName.ReadOnly = tbx_CusEmail.ReadOnly = tbx_CusAddr.ReadOnly = true;
                        dtg_CustomerView.DataSource = busCus.getAllCustomer();
                        lbl_TotalCus.Text = dtg_CustomerView.RowCount.ToString();
                    }
                    else
                        MessageBox.Show("Update fail");
                }
                else
                    MessageBox.Show("Please fill needed information!!!");
            }


            //Save Delete Information
            if(btn_CusDelete.Enabled == false)
            {
                if ((string.IsNullOrEmpty(tbx_CusName.Text) == false) && (string.IsNullOrEmpty(tbx_CusEmail.Text) == false) && (string.IsNullOrEmpty(tbx_CusAddr.Text) == false))
                {
                    DialogResult dr = MessageBox.Show("Are you sure to buy delete this customer ?", "Confirm Message", MessageBoxButtons.YesNo);

                    if (dr == DialogResult.Yes)
                    {
                        if (busCus.deleteCustomer(Convert.ToInt32(tbx_CusID.Text)))
                        {
                            MessageBox.Show("Delete sucess.");
                            btn_CusUpdate.Enabled = btn_CusAdd.Enabled = btn_CusDelete.Enabled = true;
                            btn_CusSave.Visible = btn_CusCancel.Visible = false;
                            tbx_CusName.ReadOnly = tbx_CusEmail.ReadOnly = tbx_CusAddr.ReadOnly = true;
                            dtg_CustomerView.DataSource = busCus.getAllCustomer();
                            lbl_TotalCus.Text = dtg_CustomerView.RowCount.ToString();
                        }
                        else
                            MessageBox.Show("Delete fail!!!!");
                    }
                }
                else
                    MessageBox.Show("Please pick at least one customer.");
            }

        }




        /*===================================STAFF CONTROL TAB================================*/
        //Key down for Staff Searching
        private void tbx_StfSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtg_StfView.DataSource = busStf.getStf_byName(tbx_StfSearch.Text);
                lbl_TotalStf.Text = dtg_StfView.RowCount.ToString();
            }
        }

        //Pull data to textbox
        private void dtg_StfView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = e.RowIndex;
                DataGridViewRow selectRow = dtg_StfView.Rows[index];
                tbx_StfID.Text = selectRow.Cells[0].Value.ToString();
                tbx_StfUserName.Text = selectRow.Cells[1].Value.ToString();
                tbx_StfEmail.Text = selectRow.Cells[2].Value.ToString();
                if (Convert.ToInt32(selectRow.Cells[3].Value.ToString()) == 1)
                {
                    tbx_StfStatus.Text = "Admin";
                }
                else
                    tbx_StfStatus.Text = "Staff";
                tbx_StfCB.Text = selectRow.Cells[4].Value.ToString();
                tbx_StfCD.Text = selectRow.Cells[5].Value.ToString();
                tbx_StfUB.Text = selectRow.Cells[6].Value.ToString();
                tbx_StfUD.Text = selectRow.Cells[7].Value.ToString();
                try
                {
                    StfID = Convert.ToInt32(tbx_StfID.Text);
                }
                catch { };
            }
            catch { };
        }

        //Refresh Staff Panel
        private void btn_StfReset_Click(object sender, EventArgs e)
        {
            tbx_StfID.Text = tbx_StfUserName.Text = tbx_StfEmail.Text = tbx_StfStatus.Text = tbx_StfCB.Text = tbx_StfCD.Text = tbx_StfUB.Text = tbx_StfUD.Text = "";
            dtg_StfView.DataSource = busStf.getAllStf();
            lbl_TotalStf.Text = dtg_StfView.RowCount.ToString();
            btn_StfDelete.Enabled = btn_StfAdd.Enabled = btn_StfUpdate.Enabled = true;
            btn_StfSave.Visible = btn_StfCancel.Visible = false;
        }


        //Click Add button
        private void btn_StfAdd_Click(object sender, EventArgs e)
        {
            btn_StfAdd.Enabled = false;
            btn_StfDelete.Enabled = btn_StfUpdate.Enabled = true;
            btn_StfSave.Visible = btn_StfCancel.Visible = true;
            tbx_StfUserName.ReadOnly = tbx_StfEmail.ReadOnly = false;
        }

        //Click Update button
        private void btn_StfUpdate_Click(object sender, EventArgs e)
        {
            btn_StfUpdate.Enabled = false;
            btn_StfDelete.Enabled = btn_StfAdd.Enabled = true;
            btn_StfSave.Visible = btn_StfCancel.Visible = true;
            tbx_StfEmail.ReadOnly = false;
            tbx_StfUserName.ReadOnly = true;
        }

        //Click delete button
        private void btn_StfDelete_Click(object sender, EventArgs e)
        {
            btn_StfDelete.Enabled = false;
            btn_StfUpdate.Enabled = btn_StfAdd.Enabled = true;
            btn_StfSave.Visible = btn_StfCancel.Visible = false;
            tbx_StfUserName.ReadOnly = tbx_StfEmail.ReadOnly = true;
        }
        
        //Send Email to Staff
        private void btn_StfEmail_Click(object sender, EventArgs e)
        {
            btn_StfDelete.Enabled = btn_StfAdd.Enabled = btn_StfUpdate.Enabled = true;
            btn_StfSave.Visible = btn_StfCancel.Visible = false;
            tbx_StfUserName.ReadOnly = tbx_StfEmail.ReadOnly = true;
            Email = tbx_StfEmail.Text;
            GUI.Email_UI uiEmail = new Email_UI();
            uiEmail.Show();
        }

        //Set Staff to Admin
        private void btn_StfSet_Click(object sender, EventArgs e)
        {
            btn_StfDelete.Enabled = btn_StfAdd.Enabled = btn_StfUpdate.Enabled = true;
            btn_StfSave.Visible = btn_StfCancel.Visible = false;
            tbx_StfUserName.ReadOnly = tbx_StfEmail.ReadOnly = true;
            if (string.IsNullOrEmpty(tbx_StfUserName.Text) == false && string.IsNullOrEmpty(tbx_StfEmail.Text) == false)
            {
                if (busStf.setAdmin(Convert.ToInt32(tbx_StfID.Text)))
                {
                    MessageBox.Show("Set Success.");
                    dtg_StfView.DataSource = busStf.getAllStf();
                    lbl_TotalStf.Text = dtg_StfView.RowCount.ToString();
                }
                else
                    MessageBox.Show("Set Admin Error!!!");
            }
            else
                MessageBox.Show("Please pick at least one Staff!!!");
        }



        //Save Function Information
        private void btn_StfSave_Click(object sender, EventArgs e)
        {
            //save add information
            if (btn_StfAdd.Enabled == false)
            {
                if (string.IsNullOrEmpty(tbx_StfUserName.Text) == false && string.IsNullOrEmpty(tbx_StfEmail.Text) == false)
                {
                    DTO_Staff dtoStf = new DTO_Staff(0, tbx_StfUserName.Text, "1", tbx_StfEmail.Text, 0, lbl_StfName.Text, "getdate()", lbl_StfName.Text, "getdate()");

                    if (busStf.addStf(dtoStf))
                    {
                        MessageBox.Show("Add Success.");
                        btn_StfDelete.Enabled = btn_StfAdd.Enabled = btn_StfUpdate.Enabled = true;
                        btn_StfSave.Visible = btn_StfCancel.Visible = false;
                        tbx_StfUserName.ReadOnly = tbx_StfEmail.ReadOnly = true;
                        tbx_StfID.Text = tbx_StfUserName.Text = tbx_StfEmail.Text = tbx_StfStatus.Text = tbx_StfCB.Text = tbx_StfCD.Text = tbx_StfUB.Text = tbx_StfUD.Text = "";
                        dtg_StfView.DataSource = busStf.getAllStf();
                        lbl_TotalStf.Text = dtg_StfView.RowCount.ToString();
                    }
                    else
                        MessageBox.Show("Adding Error!!!");
                }
                else
                    MessageBox.Show("Please fill needed information!!!");
            }

            //save update infor
            else if (btn_StfUpdate.Enabled == false)
            {
                if (string.IsNullOrEmpty(tbx_StfUserName.Text) == false && string.IsNullOrEmpty(tbx_StfEmail.Text) == false)
                {
                    if (busStf.updateStfEmail(Convert.ToInt32(tbx_StfID.Text), tbx_StfEmail.Text, lbl_StfName.Text))
                    {
                        MessageBox.Show("Update Sucess.");
                        btn_StfDelete.Enabled = btn_StfAdd.Enabled = btn_StfUpdate.Enabled = true;
                        btn_StfSave.Visible = btn_StfCancel.Visible = false;
                        tbx_StfUserName.ReadOnly = tbx_StfEmail.ReadOnly = true;
                        tbx_StfID.Text = tbx_StfUserName.Text = tbx_StfEmail.Text = tbx_StfStatus.Text = tbx_StfCB.Text = tbx_StfCD.Text = tbx_StfUB.Text = tbx_StfUD.Text = "";
                        dtg_StfView.DataSource = busStf.getAllStf();
                        lbl_TotalStf.Text = dtg_StfView.RowCount.ToString();
                    }
                    else
                        MessageBox.Show("Updating Error!!!");
                }
                else
                    MessageBox.Show("Please fill needed information!!!");
            }


            //save del infor
            else if (btn_StfDelete.Enabled == false)
            {
                if (string.IsNullOrEmpty(tbx_StfUserName.Text) == false && string.IsNullOrEmpty(tbx_StfEmail.Text) == false)
                {
                    DialogResult dr = MessageBox.Show("Are you sure to buy delete this staff ?", "Confirm Message", MessageBoxButtons.YesNo);

                    if (dr == DialogResult.Yes)
                    {
                        if (busStf.deleteStf(Convert.ToInt32(tbx_StfID.Text)))
                        {
                            MessageBox.Show("Remove Sucess.");
                            btn_StfDelete.Enabled = btn_StfAdd.Enabled = btn_StfUpdate.Enabled = true;
                            btn_StfSave.Visible = btn_StfCancel.Visible = false;
                            tbx_StfUserName.ReadOnly = tbx_StfEmail.ReadOnly = true;
                            tbx_StfID.Text = tbx_StfUserName.Text = tbx_StfEmail.Text = tbx_StfStatus.Text = tbx_StfCB.Text = tbx_StfCD.Text = tbx_StfUB.Text = tbx_StfUD.Text = "";
                            dtg_StfView.DataSource = busStf.getAllStf();
                            lbl_TotalStf.Text = dtg_StfView.RowCount.ToString();
                        }
                        else
                            MessageBox.Show("Delete Error!!!");
                    }
                }
                else
                    MessageBox.Show("Please pick at least one staff to remove!!");
            }
        }





        /*===================================ACCOUNT CONTROL TAB================================*/
        //Update Email
        private void btn_AccUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbx_AccEmail.Text) == false)
            {
                if (busStf.updateStfEmail(UserID, tbx_AccEmail.Text, lbl_StfName.Text))
                {
                    MessageBox.Show("Update Sucess.");
                }
                else
                    MessageBox.Show("Updating Error!!!");
            }
            else
                MessageBox.Show("Please fill needed information!!!");
        }

        //Click Change Password
        private void btn_AccChange_Click(object sender, EventArgs e)
        {
            lbl_AccOld.Visible = tbx_AccOld.Visible = true;
            lbl_AccNew.Visible = tbx_AccNew.Visible = true;
            lbl_AccConfirm.Visible = tbx_AccConfirm.Visible = true;
            btn_AccSave.Visible = true;
        }

        //Save Change pass infor
        private void btn_AccSave_Click(object sender, EventArgs e)
        {
            if ((tbx_AccOld.Text != "" || tbx_AccNew.Text != "" || tbx_AccConfirm.Text != ""))
            {
                if (busStf.checkUserPass(UserID, tbx_AccOld.Text) == 1)
                {
                    if (tbx_AccNew.Text == tbx_AccConfirm.Text)
                    {
                        if (busStf.changeUserPass(UserID, tbx_AccNew.Text))
                        {
                            MessageBox.Show("Change Password Sucess");
                            lbl_AccOld.Visible = tbx_AccOld.Visible = false;
                            lbl_AccNew.Visible = tbx_AccNew.Visible = false;
                            lbl_AccConfirm.Visible = tbx_AccConfirm.Visible = false;
                            btn_AccSave.Visible = false;
                        }
                        else
                        {
                            MessageBox.Show("Error Happen, please try again.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Confirm Password not match, please try again.");
                    }
                }
                else if (busStf.checkUserPass(UserID, tbx_AccOld.Text) == 2)
                {
                    MessageBox.Show("Wrong Password, please try again.");
                }
                else
                    MessageBox.Show("Error Happen.");
            }
            else
                MessageBox.Show("Please fill the require information.");
        }
        
        //Forgot Password
        private void btn_AccForgot_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("You will be log out, process ?", "Confirm Message", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                this.Hide();
                GUI.ForgotPass_UI uiForgot = new GUI.ForgotPass_UI();
                uiForgot.Show();
            }
        }






        /*===================================Report tab================================*/

        private void btn_BookQuantity_Click(object sender, EventArgs e)
        {
            /*Option = 1;
            Print_UI prnt = new Print_UI();
            prnt.Show();*/
            MessageBox.Show("Function not available!!!");
        }


        //Sale report
        private void btn_SaleReport_Click(object sender, EventArgs e)
        {
            /*Option = 2;
            Print_UI prnt = new Print_UI();
            prnt.Show();*/
            MessageBox.Show("Function not available!!!");
        }

        //Staff report
        private void btn_StfReport_Click(object sender, EventArgs e)
        {
            /*Option = 3;
            Print_UI prnt = new Print_UI();
            prnt.Show(); */
            MessageBox.Show("Function not available!!!");
        }

        //Customer REport
        private void btn_CusReport_Click(object sender, EventArgs e)
        {
            /*Option = 4;
            Print_UI prnt = new Print_UI();
            prnt.Show();*/
            MessageBox.Show("Function not available!!!");
        }

        /*===================================EXIT FORM================================*/

        //Close the form
        private void StaffControl_UI_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
        //Log out
        private void btn_LogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            GUI.Login_UI uiLog = new GUI.Login_UI();
            uiLog.Show();
        }

    }
}
