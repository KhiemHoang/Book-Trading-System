using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
using DTO;

namespace BUS
{
    public class BUS_Staff
    {
        DAL_Staff dalStf = new DAL_Staff();

        //Check Staff Valid
        public int checkUserValid(string UserName, string Pass)
        {
            return dalStf.CheckUserValid(UserName, Pass);
        }

        //get Stf ID
        public int getUserID(string UserName)
        {
            return dalStf.GetUserID(UserName);
        }

        //check Stf Role
        public int checkStfRole(string Username)
        {
            return dalStf.CheckStfRole(Username);
        }

        //get Spec Staff
        public DataTable getStf_byName(string Username)
        {
            return dalStf.GetStf_byName(Username);
        }

        //get All
        public DataTable getAllStf()
        {
            return dalStf.GetAllStf();
        }

        //Add Staff
        public bool addStf(DTO_Staff Stf)
        {
            return dalStf.AddStf(Stf);
        }

        //Update Staff
        public bool updateStfEmail(int StfID, string Email, string UpdateBy)
        {
            return dalStf.UpdateStfEmail(StfID, Email, UpdateBy);
        }

        //Delete Staff
        public bool deleteStf(int StfID)
        {
            return dalStf.DeleteStf(StfID);
        }

        //Set Admin
        public bool setAdmin(int StfID)
        {
            return dalStf.SetAdmin(StfID);
        }
        
        //Get Stf Pass
        public int checkUserPass(int SID, string Pass)
        {
            return dalStf.CheckUserPass(SID, Pass);
        }

        //Update Stf Pass
        public bool changeUserPass(int SID, string Pass)
        {
            return dalStf.ChangeUserPass(SID, Pass);
        }
    }
}
