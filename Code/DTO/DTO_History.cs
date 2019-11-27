using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_History
    {
        private int _Purchase_ID;
        private int _Cus_ID;
        private int _Book_ID;
        private int _Purchase_Quantity;
        private int _Item_Price;

        public int Purchase_ID
        {
            get { return _Purchase_ID; }
            set { _Purchase_ID = value; }
        }
        public int Cus_ID
        {
            get { return _Cus_ID; }
            set { _Cus_ID = value; }
        }
        public int Book_ID
        {
            get { return _Book_ID; }
            set { _Book_ID = value; }
        }
        public int Purchase_Quantity
        {
            get { return _Purchase_Quantity; }
            set { _Purchase_Quantity = value; }
        }
        public int Item_Price
        {
            get { return _Item_Price; }
            set { _Item_Price = value; }
        }

        public DTO_History() { }

        public DTO_History(int PID, int CuID, int BID, int PQuantity, int PPrice)
        {
            this.Purchase_ID = PID;
            this.Cus_ID = CuID;
            this.Book_ID = BID;
            this.Purchase_Quantity = PQuantity;
            this.Item_Price = PPrice;
        }
    }
}
