using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class DAL_Pick : DB_Connect
    {
        //Add new item to cart (pick)
        public bool AddPick(int CaID, int BID, int CuID, int PickQuantity)
        {
            try
            {
                _conn.Open();

                string SQL = string.Format("insert into pick_temp values('{0}','{1}','{2}','{3}', 0)", CaID, BID, CuID, PickQuantity);

                SqlCommand cmd = new SqlCommand(SQL, _conn);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }

            catch (Exception e)
            { }

            finally
            {
                _conn.Close();
            }

            return false;
        }

        //update Price
        public bool UpdatePrice(int Quantity, int Price, int BID)
        {
            try
            {
                _conn.Open();

                string SQL = string.Format("update pick_temp set total_price = {0} * {1} where book_id = {2}", Quantity, Price, BID, _conn);

                SqlCommand cmd = new SqlCommand(SQL, _conn);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }

            catch (Exception e)
            { }

            finally
            {
                _conn.Close();
            }

            return false;
        }

        //get Pick infor 
        public DataTable GetPick(int CaID, int CuID)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select b.book_id as 'SKU', b.book_name as 'Book Title', b.book_price as 'Price', p.quantity as 'Quantity', b.book_price*p.quantity as 'Total Price' from pick_temp as p, book as b where b.book_id = p.book_id and p.cart_id =" + CaID + "and p.cus_id = " + CuID + " and p.quantity != 0;", _conn);
            DataTable dtPick = new DataTable();
            da.Fill(dtPick);
            return dtPick;
        }

        //get Pick Cart info
        public DataTable GetCartInfo(int CaID, string BName)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select b.book_id as 'SKU', b.book_name as 'Book Title', b.book_price as 'Price', p.quantity as 'Quantity', b.book_price*p.quantity as 'Total Price' from pick_temp as p, book as b where b.book_id = p.book_id and p.cart_id =" + CaID + " and b.book_name like '%" + BName + "%' and p.quantity != 0;", _conn);
            DataTable dtPick = new DataTable();
            da.Fill(dtPick);
            return dtPick;
        }

        //calculate total price 
        public string CalTotalPrice(int CaID)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select sum(total_price) from pick_temp where cart_id = " + CaID + ";", _conn);
            DataTable dtPick = new DataTable();
            da.Fill(dtPick);
            string totalPrice = dtPick.Rows[0][0].ToString();
            return totalPrice;
        }

        //Update Pick
        public bool UpdatePickCart(int Quantity,int CaID, int CuID, int BookID)
        {
            try
            {
                _conn.Open();

                string SQL = string.Format("Update pick_temp set quantity = {0} where cart_id = {1} and cus_id = {2} and book_id = {3};", Quantity,CaID, CuID, BookID);

                SqlCommand cmd = new SqlCommand(SQL, _conn);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }

            catch (Exception e)
            { }

            finally
            {
                _conn.Close();
            }

            return false;
        }

        //Check available
        public int CheckPickAvailable(int CaID, int CuID, int BID)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select count(*) from pick_temp where cart_id = " + CaID + " and book_id=" + BID + " and cus_id=" +CuID+";", _conn);
            DataTable dtPick = new DataTable();
            da.Fill(dtPick);
            if (dtPick.Rows[0][0].ToString() == "1")
            {
                return 1;
            }
            else if (dtPick.Rows[0][0].ToString() == "0")
            {
                return 2;
            }
            else
                return 3;
        }

    }
}
