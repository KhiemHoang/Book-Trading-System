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
    public class BUS_Customer
    {
        DAL_Customer dalCus = new DAL_Customer();

        //Update Cus Pass
        public bool changeUserPass(int CuID, string Pass)
        {
            return dalCus.ChangeUserPass(CuID, Pass);
        }

        //Update Address
        public bool updateAddress(int CuID, string Address, string UpdateBy)
        {
            return dalCus.UpdateAddress(CuID, Address, UpdateBy);
        }

        //check user valid
        public int checkUserValid(string UserName, string Pass)
        {
            return dalCus.CheckUserValid(UserName, Pass);
        }

        //Check user Pass
        public int checkUserPass(int CuID, string Pass)
        {
            return dalCus.CheckUserPass(CuID, Pass);
        }

        //get Customer ID
        public int getUserID(string UserName)
        {
            return dalCus.GetUserID(UserName);
        }

        //check valid Email
        public int checkCusEmail(string Email)
        {
            return dalCus.CheckCusEmail(Email);
        }

        //Get Cus Pass
        public string getCusPass(string Email)
        {
            return dalCus.GetCusPass(Email);
        }

        //Calculate Total Purchase
        public int calculatePurchase(int CuID)
        {
            return dalCus.CalculatePurchase(CuID);
        }

        //Add new Customer
        public bool addCustomer(DTO_Customer Cus)
        {
            return dalCus.AddCustomer(Cus);
        }

        //Delete Cusomer
        public bool deleteCustomer(int CuID)
        {
            return dalCus.DeleteCustomer(CuID);
        }

        //Ban Customer
        public bool banCustomer(int CuID)
        {
            return dalCus.BanCustomer(CuID);
        }

        //get Customer by name
        public DataTable getCus_byName(string UserName)
        {
            return dalCus.GetCus_byName(UserName);
        }

        //get All
        public DataTable getAllCustomer()
        {
            return dalCus.GetAllCustomer();
        }

        //check Name
        public int checkNameExist(string Name)
        {
            return dalCus.CheckNameExist(Name);
        }
    }
}
