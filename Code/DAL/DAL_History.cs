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
    public class DAL_History : DB_Connect
    {

        //Add new Hitory
        public bool AddHistory(int PID, int CuID, int BID, int Quantity, int Price)
        {
            try
            {
                _conn.Open();

                string SQL = string.Format("insert into history values('{0}', '{1}', '{2}', '{3}', '{4}')", PID, CuID, BID, Quantity, Price);

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

        //Get History Infor
        public DataTable GetHistory(int CuID)
        {
            SqlDataAdapter da = new SqlDataAdapter("select p.purchase_id as 'Purchase ID', b.book_name as 'Book Title', h.quantity as 'Quantity', h.price as 'Price', p.purchase_date as 'Purchase Date' from purchase as p, history as h, book as b where p.purchase_id = h.purchase_id and b.book_id = h.book_id and p.cus_id = " + CuID + ";", _conn);
            DataTable dtHistory = new DataTable();
            da.Fill(dtHistory);
            return dtHistory;
        }


        //Get history Date
        public DataTable GetHistoryDate(int CuID, string Date)
        {
            SqlDataAdapter da = new SqlDataAdapter("select p.purchase_id as 'Purchase ID', b.book_name as 'Book Title', h.quantity as 'Quantity', h.price as 'Price', p.purchase_date as 'Purchase Date' from purchase as p, history as h, book as b where p.purchase_id = h.purchase_id and b.book_id = h.book_id and p.cus_id = " + CuID + " and p.purchase_date = '" + Date +"';", _conn);
            DataTable dtHistory = new DataTable();
            da.Fill(dtHistory);
            return dtHistory;
        }
    }
}
