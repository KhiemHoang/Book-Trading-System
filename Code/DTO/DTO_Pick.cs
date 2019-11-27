using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Pick
    {
        private int _Cart_ID;
        private int _Book_ID;
        private int _Cus_ID;
        private int _Pick_Quantity;
        private int _Pick_Price;

        public int Cart_ID
        {
            get { return _Cart_ID; }
            set { _Cart_ID = value; }
        }
        public int Book_ID
        {
            get { return _Book_ID; }
            set { _Book_ID = value; }
        }
        public int Cus_ID
        {
            get { return _Cus_ID; }
            set { _Cus_ID = value; }
        }
        public int Pick_Quantity
        {
            get { return _Pick_Quantity; }
            set { _Pick_Quantity = value; }
        }

        public int Pick_Price
        {
            get { return _Pick_Price; }
            set { _Pick_Price = value; }
        }

        public DTO_Pick(){}
        
        public DTO_Pick(int CaID, int BID, int CuID, int PickQuan, int PickPrice)
        {
            this.Cart_ID = CaID;
            this.Book_ID = BID;
            this.Cus_ID = Cus_ID;
            this.Pick_Quantity = PickQuan;
            this.Pick_Price = PickPrice;
        }
    }
}
