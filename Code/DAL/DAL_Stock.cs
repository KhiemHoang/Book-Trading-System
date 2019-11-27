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
    public class DAL_Stock : DB_Connect
    {
        //Get book quantity
        public int GetQuantity(int BID)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select quantity from stock where book_id = " + BID + ";", _conn);
            DataTable dtStock = new DataTable();
            da.Fill(dtStock);
            int quantity = int.Parse(dtStock.Rows[0][0].ToString());
            return quantity;
        }

        //Update book quantity
        public bool UpdateQuantity(int BID, int Quantity, string Update)
        {
            try
            {
                _conn.Open();

                string SQL = string.Format("update stock set quantity = {1}, update_by = '{2}', update_date = getdate() where book_ID = {0}", BID, Quantity, Update);

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

        //Add Stock
        public bool AddStock(DTO_Stock Stock)
        {
            try
            {
                _conn.Open();

                string SQL = string.Format("insert into stock values({0},{1},'{2}',{3},'{4}',{5})", Stock.Book_ID, Stock.Quantity, Stock.Stock_CB, Stock.Stock_CD, Stock.Stock_UB, Stock.Stock_UD);

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

        //Delete Stock
        public bool DelStock(int BID)
        {
            try
            {
                _conn.Open();

                string SQL = string.Format("delete from stock where book_id = {0}", BID);

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
    }
}
