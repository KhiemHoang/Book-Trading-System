using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Data.SqlClient;
using System.Windows.Forms;
using DTO;
using BUS;


namespace GUI
{
    public partial class Cus_Search_UI : Form
    {
        BUS_Book busBook = new BUS_Book();
        BUS_Stock busStock = new BUS_Stock();
        BUS_Cart busCart = new BUS_Cart();
        BUS_Pick busPick = new BUS_Pick();
        BUS_Purchase busPurchase = new BUS_Purchase();
        BUS_History busHistory = new BUS_History();
        BUS_Customer busCustomer = new BUS_Customer();
        public static int Quantity;
        public static int CusID = 0;
        public static int BID;
        public static int Price;
        public static int CaID = 0;
        public static int Count = 0;
        public static int PID = 0;
        public static int Total = 0;
        public static string Date;


        public Cus_Search_UI()
        {
            InitializeComponent();
            
        }

        private void Cus_Search_UI_Load(object sender, EventArgs e)
        {
                // TODO: This line of code loads data into the '_Book_controllingDataSet2.book' table. You can move, or remove it, as needed.
            //Fill the Book table
            dtg_BookView.DataSource = busBook.getAllBook_forCus();
            

            dtg_History.DataSource = busHistory.getHistory(CusID);
            dtg_CartView.DataSource = busPick.getPick(0, CusID);

            lbl_CusName.Text = GUI.Login_UI.UserName;
            CusID = GUI.Login_UI.UserID;
                       

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-BLOGEJ9;Initial Catalog=Book_controlling;Integrated Security=True");
            //SqlConnection con = new SqlConnection(@"Data Source=118.68.247.62;Initial Catalog=Book-controlling;Integrated Security=True");

            //Get Account information
            SqlCommand cmd_Customer = new SqlCommand("select * from customer where cus_id =" + CusID, con);
            con.Open();
            SqlDataReader sdr_Customer = cmd_Customer.ExecuteReader();
            while(sdr_Customer.Read())
            {
                tbx_UserName.Text = sdr_Customer.GetString(1);
                tbx_UserEmail.Text = sdr_Customer.GetString(3);
                tbx_UserAddress.Text = sdr_Customer.GetString(4);
                tbx_UserPurchase.Text = busPurchase.getTotalPurchase(CusID).ToString();
            }
            con.Close();


            //Auto Suggestion Book
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
            //


            //Auto Suggestion Cart
            //
            SqlCommand cmd_Cart = new SqlCommand("select b.book_name from book as b, pick_temp as p where b.book_id = p.book_id;", con);
            con.Open();
            SqlDataReader sdr_Cart = cmd_Cart.ExecuteReader();
            AutoCompleteStringCollection myconnect_Cart = new AutoCompleteStringCollection();
            while (sdr_Cart.Read())
            {
                myconnect_Cart.Add(sdr_Cart.GetString(0));
            }
            tbx_CartSearch.AutoCompleteCustomSource = myconnect_Cart;
            con.Close();
        }
        

        //====================================Book Search Tab==================================================
        //Recommend Search For Book//
        private void tbx_BookSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtg_BookView.DataSource = busBook.getBook_byName(tbx_BookSearch.Text);
            }
        }

        //Pull data to Book Search text box
        private void dtg_BookView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = e.RowIndex;
                DataGridViewRow selectRow = dtg_BookView.Rows[index];
                tbx_SKU.Text = selectRow.Cells[0].Value.ToString();
                tbx_Title.Text = selectRow.Cells[1].Value.ToString();
                tbx_Author.Text = selectRow.Cells[2].Value.ToString();
                tbx_Price.Text = selectRow.Cells[3].Value.ToString();

                //Get quantity of Book
                int i = 0;
                try
                {
                    i = System.Convert.ToInt32(tbx_SKU.Text);
                }
                catch (FormatException) { }
                catch (OverflowException) { }
                tbx_Quantity.Text = busStock.getQuantity(i).ToString();
            }
            catch { };
        }
        
        //Select Quantity
        private void btn_QuantitySelect_Click(object sender, EventArgs e)
        {
            try
            {
                Quantity = Convert.ToInt32(cbb_Quantity.Text.ToString());
                BID = Convert.ToInt32(tbx_SKU.Text.ToString());
                Price = Convert.ToInt32(tbx_Price.Text.ToString());
            }
            catch (FormatException) { }
            catch (OverflowException) { }
            
            if(busStock.getQuantity(BID) >= Quantity) //Check if there still enough book to order
            {
                if (busCart.checkCartAvailable(CusID) == 1) //If there's available uncheck cart
                {
                    CaID = busCart.getCartID(CusID);


                    //THrough DTO didnt work as normal
                    //DTO_Pick Pick = new DTO_Pick(CaID, BID, CusID, quantity);

                    //MessageBox.Show("BID = " + BID + " Quantity = " + Quantity + " CaID = " + CaID + " CusID = " + CusID);

                    if (busPick.checkPickAvailable(CaID, CusID, BID) == 1) //If there already selected book in cart, update new quantity
                    {
                        if (busPick.updatePickQuantity(Quantity, CaID, CusID, BID) && busPick.updatePrice(Quantity, Price, BID))
                        {
                            MessageBox.Show("Add to cart success");
                            dtg_CartView.DataSource = busPick.getPick(CaID, CusID);
                            lbl_TotalPrice.Text = busPick.calTotalPrice(CaID);
                        }
                        else
                            MessageBox.Show("Error 1 happened, please try again later.");
                    }

                    else if (busPick.checkPickAvailable(CaID, CusID, BID) == 2) //If there's no selected book in cart, create new pick information
                    {
                        if (busPick.addPick(CaID, BID, CusID, Quantity))
                        {
                            if (busPick.updatePrice(Quantity, Price, BID))
                            {
                                MessageBox.Show("Add to cart success");
                                dtg_CartView.DataSource = busPick.getPick(CaID, CusID);
                                lbl_TotalPrice.Text = busPick.calTotalPrice(CaID);
                            }
                            else
                                MessageBox.Show("Error happened 1.1, please try again later.");
                        }
                        else
                            MessageBox.Show("Error happened 1, please try again later.");
                    }
                    else
                        MessageBox.Show("Sorry, please try again later.");

                }
                else if (busCart.checkCartAvailable(CusID) == 2) //If there's not available uncheck cart
                {
                    if (busCart.addNewCart(CusID))
                    {
                        int CaID = busCart.getCartID(CusID);

                        //MessageBox.Show("" + CaID + "" + CusID);
                        //DTO_Pick Pick = new DTO_Pick(CaID, BID, CusID, quantity);
                        if (busPick.addPick(CaID, BID, CusID, Quantity))
                        {
                            if (busPick.updatePrice(Quantity, Price, BID))
                            {
                                MessageBox.Show("Add to cart success");
                                dtg_CartView.DataSource = busPick.getPick(CaID, CusID);
                            }
                            else
                                MessageBox.Show("Error happened 1.1, please try again later.");
                        }
                        else
                            MessageBox.Show("Error happened 2, please try again later.");
                    }
                    else
                        MessageBox.Show("Error happened, please try again later.");
                }
                else
                    MessageBox.Show("Error happened 3, please try again later.");
            }
            else if (busStock.getQuantity(BID) < Quantity) //If there's not enough book, error
            {
                MessageBox.Show("The Book you select is over our quantity stock remain, please order below: " + busStock.getQuantity(BID));
            }
            else
                MessageBox.Show("Error happened 4, please try again later.");
        }

        //Refresh the seacrh result
        private void btn_SearchRefresh_Click(object sender, EventArgs e)
        {
            dtg_BookView.DataSource = busBook.getAllBook_forCus();
            tbx_SKU.Text = tbx_Title.Text = tbx_Author.Text = tbx_Price.Text = tbx_Quantity.Text = "";
            cbb_Quantity.Text = 1.ToString();
        }


        //==========================================================Cart Search Tab=======================================================
        //Recommend Search for Cart//
        private void tbx_CartSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtg_CartView.DataSource = busPick.getCartInfo(CaID, tbx_CartSearch.Text);
            }
        }

        //Pull data to Cart Search dtg
        private void dtg_Cart_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = e.RowIndex;
                DataGridViewRow selectRow = dtg_CartView.Rows[index];
                tbx_BookTitle.Text = selectRow.Cells[1].Value.ToString();
                tbx_BookPrice.Text = selectRow.Cells[2].Value.ToString();
                tbx_BookQuantity.Text = selectRow.Cells[3].Value.ToString();
                tbx_Total.Text = selectRow.Cells[3].Value.ToString();
                Count = dtg_CartView.RowCount;
                try
                {
                    BID = System.Convert.ToInt32(selectRow.Cells[0].Value.ToString());
                }
                catch (FormatException) { }
                catch (OverflowException) { }
            }
            catch { };
        }

        //Update Pick quantity
        private void btn_Update_Click(object sender, EventArgs e)
        {
            Quantity = System.Convert.ToInt32(tbx_BookQuantity.Text);

            Price = System.Convert.ToInt32(busBook.getBookPrice(BID));
            if (busStock.getQuantity(BID) >= Quantity) //Check if there still enough book to order
            {
                if (busPick.updatePickQuantity(Quantity, CaID, CusID, BID) && busPick.updatePrice(Quantity, Price, BID))
                {
                    MessageBox.Show("Update success.");
                    dtg_CartView.DataSource = busPick.getPick(CaID, CusID);
                    lbl_TotalPrice.Text = busPick.calTotalPrice(CaID);
                }
                else
                    MessageBox.Show("Error 1 happened, please try again later.");
            }
            else if (busStock.getQuantity(BID) < Quantity) // IF there's not enough book to order
            {
                MessageBox.Show("We don't have enough book for you to order, please order below: " + busStock.getQuantity(BID));
            }
        }

        //Reset button
        private void btn_CartReset_Click(object sender, EventArgs e)
        {
            dtg_CartView.DataSource = busPick.getPick(CaID, CusID);
            lbl_TotalPrice.Text = busPick.calTotalPrice(CaID);
            tbx_BookPrice.Text = tbx_BookQuantity.Text = tbx_BookTitle.Text = tbx_Total.Text = "";
        }        

        //Remove button
        private void btn_Remove_Click(object sender, EventArgs e)
        {
                DialogResult dr = MessageBox.Show("Are you sure to remove this item ?", "Confirm Message" , MessageBoxButtons.YesNo);
                if(dr == DialogResult.Yes)
                {
                    if (busPick.updatePickQuantity(0, CaID, CusID, BID) && busPick.updatePrice(0, Price, BID))
                    {
                        MessageBox.Show("Remove success.");
                        dtg_CartView.DataSource = busPick.getPick(CaID, CusID);
                        lbl_TotalPrice.Text = busPick.calTotalPrice(CaID);
                    }
                    else
                    {
                        MessageBox.Show("Error 1 happened, please try again later.");
                    }
                }
        }

        //Cancel Update Quantity
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            tbx_BookTitle.Text = tbx_BookPrice.Text = tbx_BookQuantity.Text = tbx_Total.Text = "";
            dtg_CartView.DataSource = busPick.getPick(CaID, CusID);
        }


        //confrim Buy item
        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure to buy these item ?", "Confirm Message", MessageBoxButtons.YesNo);
            if(dr == DialogResult.Yes)
            {
                if(busPurchase.addPurchase(CusID))
                {
                    Count = dtg_CartView.RowCount;
                    for (int i = 0; i < Count; i++)
                    {
                        try
                        {
                            BID = System.Convert.ToInt32(dtg_CartView.Rows[i].Cells[0].Value.ToString());
                            Quantity = System.Convert.ToInt32(dtg_CartView.Rows[i].Cells[3].Value.ToString());
                            Price = System.Convert.ToInt32(dtg_CartView.Rows[i].Cells[4].Value.ToString());
                        }
                        catch (FormatException) { }
                        catch (OverflowException) { }

                        if (busStock.getQuantity(BID) >= Quantity) //Check if there still enough book to order
                        {
                            PID = busPurchase.returnMaxID(CusID);

                            Total = Total + Price;
                            int newQuantity = busStock.getQuantity(BID) - Quantity;

                            if (busHistory.addHistory(PID, CusID, BID, Quantity, Price)) // Add new record to purchase history
                            {
                                busStock.updateQuantity(BID, newQuantity, "System");
                            }
                            else
                                MessageBox.Show("End game 1");
                        }
                        else if (busStock.getQuantity(BID) < Quantity) // IF there's not enough book to order
                        {
                            MessageBox.Show("We don't have enough book for you to order, please order below: " + busStock.getQuantity(BID));
                            busPurchase.delPurchase(PID);
                        }
                    }
                    if(busPurchase.updatePurchasePrice(PID, Total))
                    {
                        if(busCart.updateFlag(CusID))
                        {
                            MessageBox.Show("Purchase success");
                            dtg_History.DataSource = busHistory.getHistory(CusID);
                        }
                        else
                            MessageBox.Show("Error happaned.");
                    }
                    else
                        MessageBox.Show("End game 2");
                }
                else
                    MessageBox.Show("Error 1");
            }
        }


        //==========================================================History Search Tab=======================================================

         //Pick date to search
        private void dtp_History_ValueChanged(object sender, EventArgs e)
        {
            Date = dtp_History.Value.ToString("yyyy-MM-dd");
            dtg_History.DataSource = busHistory.getHistoryDate(CusID, Date);
        }

        //get data from dtg
        private void dtg_History_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = e.RowIndex;
                DataGridViewRow selectRow = dtg_History.Rows[index];
                tbx_PurchaseID.Text = selectRow.Cells[0].Value.ToString();
                tbx_HistoryTitle.Text = selectRow.Cells[1].Value.ToString();
                tbx_HistoryQuantity.Text = selectRow.Cells[2].Value.ToString();
                tbx_HistoryPrice.Text = selectRow.Cells[3].Value.ToString();
                tbx_HistoryDate.Text = selectRow.Cells[4].Value.ToString();
            }
            catch { };

        }

        //reset History
        private void btn_PurchaseReset_Click(object sender, EventArgs e)
        {
            dtg_History.DataSource = busHistory.getHistory(CusID);
            tbx_HistoryTitle.Text = tbx_HistoryQuantity.Text = tbx_PurchaseID.Text = tbx_HistoryDate.Text = tbx_HistoryPrice.Text = "";
        }
        

        //==========================================================ACCOUNT CONTROL Tab=======================================================

        //Update User Address
        private void btn_UpdateAdd_Click(object sender, EventArgs e)
        {
            if (busCustomer.updateAddress(CusID, tbx_UserAddress.Text, "User"))
            {
                MessageBox.Show("Update Address success.");
            }
            else
                MessageBox.Show("Update Fail");
        }
        
        //Access to change Pass
        private void btn_ChangePass_Click(object sender, EventArgs e)
        {
            lbl_UOP.Visible = tbx_UserOPass.Visible = true;
            lbl_UNP.Visible = tbx_UNPass.Visible = true;
            lbl_UCP.Visible = tbx_UserCPass.Visible = true;
            btn_Save.Visible = true;
        }

        //Change user Pass
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if ((tbx_UserOPass.Text != "" || tbx_UNPass.Text != "" || tbx_UserCPass.Text != ""))
            {
                if (busCustomer.checkUserPass(CusID, tbx_UserOPass.Text) == 1)
                {
                    if (tbx_UNPass.Text == tbx_UserCPass.Text)
                    {
                        if (busCustomer.changeUserPass(CusID, tbx_UNPass.Text))
                        {
                            MessageBox.Show("Change Password Sucess");
                            lbl_UOP.Visible = tbx_UserOPass.Visible = false;
                            lbl_UNP.Visible = tbx_UNPass.Visible = false;
                            lbl_UCP.Visible = tbx_UserCPass.Visible = false;
                            btn_Save.Visible = false;
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
                else if (busCustomer.checkUserPass(CusID, tbx_UserOPass.Text) == 2)
                {
                    MessageBox.Show("Wrong Password, please try again.");
                }
                else
                    MessageBox.Show("Error Happen.");
            }
            else
                MessageBox.Show("Please fill the require information.");
        }

        //Confirm Forgot Pass
        private void btn_ForgotPass_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("You will be log out, process ?", "Confirm Message", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                this.Hide();
                GUI.ForgotPass_UI uiForgot = new GUI.ForgotPass_UI();
                uiForgot.Show();
            }
        }


        /*====================Log Out==========================*/
        private void btn_LogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            GUI.Login_UI uiLog = new GUI.Login_UI();
            uiLog.Show();
        }

        private void Cus_Search_UI_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
            busCart.updateFlag(CusID);
        }


    }
}
