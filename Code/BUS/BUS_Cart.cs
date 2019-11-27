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
    public class BUS_Cart
    {
        DAL_Cart dalCart = new DAL_Cart();


        //Update Cart
        public bool updateFlag( int CusID)
        {
            return dalCart.UpdateFlag(CusID);
        }

        //Get Cart ID
        public int getCartID(int CuID)
        {
            return dalCart.GetCartID(CuID);
        }

        //check cart available
        public int checkCartAvailable(int CuID)
        {
            return dalCart.CheckCartAvailable(CuID);
        }

        //add new cart
        public bool addNewCart(int CuID)
        {
            return dalCart.AddCart(CuID);
        }
    }
}
