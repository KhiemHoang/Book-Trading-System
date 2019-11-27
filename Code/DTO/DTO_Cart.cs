using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Cart
    {
        private int _Cart_ID;
        private int _Cus_ID;
        private int _Cart_Flag;
        private string _Cart_Date;

        public int Cart_ID
        {
            get { return _Cart_ID; }
            set { _Cart_ID = value; }
        }

        public int Cus_ID
        {
            get { return _Cus_ID; }
            set { _Cus_ID = value; }
        }
        
        public int Cart_Flag
        {
            get { return _Cart_Flag; }
            set { _Cart_Flag = value; }
        }

        public string Cart_Date
        {
            get { return _Cart_Date; }
            set { _Cart_Date = value; }
        }

        public DTO_Cart()
        { }

        public DTO_Cart(int Ca_ID, int CID, int Ca_Flag, string CDate)
        {
            this.Cart_ID = Ca_ID;
            this.Cus_ID = CID;
            this.Cart_Flag = Cart_Flag;
            this.Cart_Date = CDate;
        }

    }
}
