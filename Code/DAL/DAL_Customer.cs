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
    public class DAL_Customer : DB_Connect
    {
        //Change Password
        public bool ChangeUserPass(int CuID, string Pass)
        {
            try
            {
                _conn.Open();

                string SQL = string.Format("update customer set cus_pass = {1} where cus_id = {0}", CuID, Pass);

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

        //Update Address
        public bool UpdateAddress(int CuID, string Address, string UpdateBy)
        {
            try
            {
                _conn.Open();

                string SQL = string.Format("update customer set cus_address = '{1}', update_by = '{2}', update_date = getdate() where cus_id = {0}", CuID, Address, UpdateBy);

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

        //Check User Valid
        public int CheckUserValid(string UserName, string Pass)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select count(*) from customer where cus_username = '" + UserName + "' and cus_pass='" + Pass +  "';", _conn);
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

        //Check UserPass
        public int CheckUserPass(int CuID, string Pass)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select count(*) from customer where cus_id = " + CuID + " and cus_pass=" + Pass + ";", _conn);
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

        //Change update by
        public bool ChangeUpdateBy(int CuID, string UserName)
        {
            try
            {
                _conn.Open();

                string SQL = string.Format("update customer set update_by = '{1}', update_date = getdate()  where cus_id = {0}", CuID, UserName);

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

        //Get Customer ID
        public int GetUserID(string UserName)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select cus_id from customer where cus_username = '" + UserName + "';", _conn);
            DataTable dtCustomer = new DataTable();
            da.Fill(dtCustomer);
            int quantity = int.Parse(dtCustomer.Rows[0][0].ToString());
            return quantity;
        }

        //Get specific customer by Name
        public DataTable GetCus_byName(string CusName)
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from customer where cus_username like '%" + CusName + "%';", _conn);
            DataTable dtCus = new DataTable();
            da.Fill(dtCus);
            return dtCus;
        }

        //Check Customer Email
        public int CheckCusEmail(string Email)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select count(*) from customer where cus_email = '" + Email + "';", _conn);
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

        //Get Customer Pass
        public string GetCusPass(string Email)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select cus_pass from customer where cus_email = '" + Email + "';", _conn);
            DataTable dtCustomer = new DataTable();
            da.Fill(dtCustomer);
            string Pass = dtCustomer.Rows[0][0].ToString();
            return Pass;
        }

        //Calculate Total Purchase
        public int CalculatePurchase(int CuID)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select count(*) from purchase where cus_id = '" + CuID + "';", _conn);
            DataTable dtCustomer = new DataTable();
            da.Fill(dtCustomer);
            int quantity = int.Parse(dtCustomer.Rows[0][0].ToString());
            return quantity;
        }

        //Add Customer
        public bool AddCustomer(DTO_Customer Cus)
        {
            try
            {
                _conn.Open();

                string SQL = string.Format("insert into customer values('{0}', 1, '{1}','{2}', 0, '{3}', getdate(), '{4}', getdate());", Cus.Cus_UserName, Cus.Cus_Email, Cus.Cus_Address,  Cus.Cus_CB, Cus.Cus_UB);

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

        //Delete Customer
        public bool DeleteCustomer(int CuID)
        {
            try
            {
                _conn.Open();

                string SQL = string.Format("delete from customer where cus_id = {0}", CuID);

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

        //Ban Customer
        public bool BanCustomer(int CuID)
        {
            try
            {
                _conn.Open();

                string SQL = string.Format("update customer set ban_flag = 1 where cus_id = {0}", CuID);

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

        //Get all customer
        public DataTable GetAllCustomer()
        {
            SqlDataAdapter da = new SqlDataAdapter("select cus_id as ID, cus_username as 'User name', cus_email as Email, cus_address as 'Address', ban_flag as Status, create_by as 'Create by', create_date as 'Create date', update_by as 'Update by', update_date as 'Update date' from customer;", _conn);
            DataTable dtCus = new DataTable();
            da.Fill(dtCus);
            return dtCus;
        }

        //check Username exist
        public int CheckNameExist(string Name)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select count(*) from customer where cus_username = '" + Name + "';", _conn);
            DataTable dtCustomer = new DataTable();
            da.Fill(dtCustomer);
            int quantity = int.Parse(dtCustomer.Rows[0][0].ToString());
            return quantity;
        }

    }
}
