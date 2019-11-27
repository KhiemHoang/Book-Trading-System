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
    public class BUS_Stock
    {
        DAL_Stock dalStock = new DAL_Stock();

        //Get remain book quantity
        public int getQuantity(int BID)
        {
            return dalStock.GetQuantity(BID);
        }

        //Update book quantity
        public bool updateQuantity(int BID, int Quantity, string Update)
        {
            return dalStock.UpdateQuantity(BID, Quantity, Update);
        }

        //Add new Stock
        public bool addStock(DTO_Stock Stock)
        {
            return dalStock.AddStock(Stock);
        }

        //Delete Stock
        public bool delStock(int BID)
        {
            return dalStock.DelStock(BID);
        }
    }
}
