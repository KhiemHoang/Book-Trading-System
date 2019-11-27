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
    public class BUS_Purchase
    {
        DAL_Purchase dalPurchase = new DAL_Purchase();

        //Add new Purchase
        public bool addPurchase(int CuID)
        {
            return dalPurchase.AddPurchase(CuID);
        }

        //Get max Purchase ID
        public int returnMaxID(int CuID)
        {
            return dalPurchase.ReturnMaxID(CuID);
        }

        //Update Purchase Price
        public bool updatePurchasePrice(int PID, int Total)
        {
            return dalPurchase.UpdatePurchasePrice(PID, Total);
        }

        //Delete Purchase
        public bool delPurchase(int PID)
        {
            return dalPurchase.DelPurchase(PID);
        }

        //Count Total Purchase
        public int getTotalPurchase(int CuID)
        {
            return dalPurchase.GetTotalPurchase(CuID);
        }
    }
}
