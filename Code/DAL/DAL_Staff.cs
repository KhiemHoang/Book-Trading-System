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
    public class DAL_Staff : DB_Connect
    {
        //check Staff valid
        public int CheckUserValid(string UserName, string Pass)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select count(*) from staff where stf_username = '" + UserName + "' and stf_pass='" + Pass + "';", _conn);
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

        //get Staff ID
        public int GetUserID(string UserName)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select stf_id from staff where stf_username = '" + UserName + "';", _conn);
            DataTable dtStf = new DataTable();
            da.Fill(dtStf);
            int quantity = int.Parse(dtStf.Rows[0][0].ToString());
            return quantity;
        }

        //Check Staff Role
        public int CheckStfRole(string UserName)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select admin_flag from staff where stf_username = '" + UserName + "';", _conn);
            DataTable dtStf = new DataTable();
            da.Fill(dtStf);
            int role = int.Parse(dtStf.Rows[0][0].ToString());
            return role;
        }

        //Get Specific Staff
        public DataTable GetStf_byName(string Username)
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from staff where stf_username like '%" + Username + "%';", _conn);
            DataTable dtCus = new DataTable();
            da.Fill(dtCus);
            return dtCus;
        }

        //Get all
        public DataTable GetAllStf()
        {
            SqlDataAdapter da = new SqlDataAdapter("select stf_id as ID, stf_username as 'User name', stf_email as Email, admin_flag as Role, create_by as 'Created by', create_date as 'Created date', update_by as 'Updated by', update_date as 'Updated date' from staff;", _conn);
            DataTable dtCus = new DataTable();
            da.Fill(dtCus);
            return dtCus;
        }

        //Add new Staf
        public bool AddStf(DTO_Staff Stf)
        {
            try
            {
                _conn.Open();

                string SQL = string.Format("insert into staff values('{0}', 1, '{1}', 0, '{2}', getdate(), '{3}', getdate());", Stf.Stf_UsrName, Stf.Stf_Email, Stf.Stf_CB, Stf.Stf_UB);
            
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

        //Update Staff Email
        public bool UpdateStfEmail(int StfID, string Email, string Updateby)
        {
            try
            {
                _conn.Open();

                string SQL = string.Format("update staff set stf_email = '{1}', update_by = '{2}', update_date = getdate() where stf_id = {0};", StfID, Email, Updateby);

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

        //Remove staff
        public bool DeleteStf(int StfID)
        {
            try
            {
                _conn.Open();

                string SQL = string.Format("delete from staff where stf_id = {0};", StfID);

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

        //Set Admin
        public bool SetAdmin(int StfID)
        {
            try
            {
                _conn.Open();

                string SQL = string.Format("update staff set admin_flag = 1 where stf_id = {0};", StfID);

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

        //Check Staff Pass
        public int CheckUserPass(int StfID, string Pass)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select count(*) from staff where stf_id = " + StfID + " and stf_pass=" + Pass + ";", _conn);
            DataTable dtStf = new DataTable();
            da.Fill(dtStf);
            if (dtStf.Rows[0][0].ToString() == "1")
            {
                return 1;
            }
            else if (dtStf.Rows[0][0].ToString() == "0")
            {
                return 2;
            }
            else
                return 3;
        }

        //Update Staff Pass
        public bool ChangeUserPass(int SID, string Pass)
        {
            try
            {
                _conn.Open();

                string SQL = string.Format("update staff set stf_pass = {1} where stf_id = {0}", SID, Pass);

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
