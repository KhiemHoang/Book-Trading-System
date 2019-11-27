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
    public class DAL_Cart : DB_Connect
    {
        //change cart flag
        public bool UpdateFlag(int CusID)
        {
            try
            {
                _conn.Open();

                string SQL = string.Format("Update cart set cart_flag = 1 where cus_id = {0};", CusID);

                SqlCommand cmd = new SqlCommand(SQL, _conn);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }

            catch (Exception e) { }

            finally
            { _conn.Close(); }

            return false;
        }

        //Get cart ID
        public int GetCartID(int CusID)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select cart_id from cart where cus_id = " + CusID + " and cart_flag=0;", _conn);
            DataTable dtStock = new DataTable();
            da.Fill(dtStock);
            int CaID = int.Parse(dtStock.Rows[0][0].ToString());
            return CaID;
        }


        //Check cart available
        public int CheckCartAvailable(int CusID)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select count(*) from cart where cus_id = " + CusID + " and cart_flag=0;", _conn);
            DataTable dtCustomer = new DataTable();
            da.Fill(dtCustomer);
            if (dtCustomer.Rows[0][0].ToString() == "1")
            {
                return 1;
            }
            else if (dtCustomer.Rows[0][0].ToString() == "0")
            {
                return 2;
            }
            else
                return 3;
        }

        //Add new Cart
        public bool AddCart(int CuID)
        {
            try
            {
                _conn.Open();

                string SQL = string.Format("Insert into cart values({0}, 0, getdate());" ,CuID);

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
