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
    public class DAL_Purchase : DB_Connect
    {
        //Add to Purchase
        public bool AddPurchase(int CuID)
        {
            try
            {
                _conn.Open();

                string SQL = string.Format("insert into purchase values('{0}', getdate(), 0)", CuID);

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

        //Return Purchase ID
        public int ReturnMaxID(int CuID)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select max(purchase_id) from purchase where cus_id = " + CuID + ";", _conn);
            DataTable dtPurchase = new DataTable();
            da.Fill(dtPurchase);
            int MaxID = Convert.ToInt32(dtPurchase.Rows[0][0].ToString());
            return MaxID;
        }

        //Update Purchase Price
        public bool UpdatePurchasePrice(int PID, int Total)
        {
            try
            {
                _conn.Open();

                string SQL = string.Format("update purchase set total_price = {1} where purchase_ID = {0}", PID, Total);

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

        //Delete Purchase
        public bool DelPurchase(int PID)
        {
            try
            {
                _conn.Open();

                string SQL = string.Format("delete from purchase where purchase_id = ", PID);

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

        //Get total Purchase
        public int GetTotalPurchase(int CusID)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select count(purchase_id) from purchase where cus_id = " + CusID + ";", _conn);
            DataTable dtPurchase = new DataTable();
            da.Fill(dtPurchase);
            int Count = Convert.ToInt32(dtPurchase.Rows[0][0].ToString());
            return Count;
        }
    }
}
