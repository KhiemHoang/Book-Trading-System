using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Purchase
    {
        private int _Purchase_ID;
        private int _Cus_ID;
        private int _Book_ID;
        private string _Purchase_Date;
        private int _TotalPrice;

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

        public int TotalPrice
        {
            get { return _TotalPrice; }
            set { _TotalPrice = value; }
        }

        public string Purchase_Date
        {
            get { return _Purchase_Date; }
            set { _Purchase_Date = value; }
        }

        public DTO_Purchase() { }

        public DTO_Purchase(int PID, int CuID, int BID, string PDate, int IPrice)
        {
            this.Purchase_ID = PID;
            this.Cus_ID = CuID;
            this.Book_ID = BID;
            this.Purchase_Date = PDate;
            this.TotalPrice = IPrice;
        }

    }
}
