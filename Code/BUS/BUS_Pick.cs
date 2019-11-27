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
    public class BUS_Pick
    {
        DAL_Pick dalPick = new DAL_Pick();


        //add new
        public bool addPick(int CaID, int BID, int CuID, int PickQuantity)
        {
            return dalPick.AddPick(CaID, BID, CuID, PickQuantity);
        }

        //get price table
        public bool updatePrice(int Quantity, int Price, int BID)
        {
            return dalPick.UpdatePrice(Quantity, Price, BID);
        }

        //get Pick info
        public DataTable getPick(int CaID, int CuID)
        {
            return dalPick.GetPick(CaID, CuID);
        }

        //get Cart info
        public DataTable getCartInfo(int CaID, string BName)
        {
            return dalPick.GetCartInfo(CaID, BName);
        }


        //calculate totalPrice of cart
        public string calTotalPrice(int CaID)
        {
            return dalPick.CalTotalPrice(CaID);
        }

        //Update Pick
        public bool updatePickQuantity(int Quantity, int CaID, int CuID, int BookID)
        {
            return dalPick.UpdatePickCart(Quantity, CaID, CuID, BookID);
        }

        //Check Pick available
        public int checkPickAvailable(int CaID, int CuID, int BookID)
        {
            return dalPick.CheckPickAvailable(CaID, CuID, BookID);
        }
        
    }
}
