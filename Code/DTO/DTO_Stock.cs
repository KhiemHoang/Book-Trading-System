using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Stock
    {
        private int _Stock_ID;
        private int _Book_ID;
        private int _Quantity;
        private string _Stock_CB;
        private string _Stock_CD;
        private string _Stock_UB;
        private string _Stock_UD;


        public int Book_ID
        {
            get { return _Book_ID; }
            set { _Book_ID = value; }
        }
        public int Stock_ID
        {
            get { return _Stock_ID; }
            set { _Stock_ID = value; }
        }
        public int Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; }
        }
        public string Stock_CB
        {
            get { return _Stock_CB; }
            set { _Stock_CB = value; }
        }
        public string Stock_CD
        {
            get { return _Stock_CD; }
            set { _Stock_CD = value; }
        }
        public string Stock_UB
        {
            get { return _Stock_UB; }
            set { _Stock_UB = value; }
        }
        public string Stock_UD
        {
            get { return _Stock_UD; }
            set { _Stock_UD = value; }
        }

        public DTO_Stock()
        {

        }

        public DTO_Stock(int SID, int BID, int SQuan, string SCB, string SCD, string SUB, string SUD)
        {
            this.Book_ID = BID;
            this.Stock_ID = SID;
            this.Quantity = SQuan;
            this.Stock_CB = SCB;
            this.Stock_CD = SCD;
            this.Stock_UB = SUB;
            this.Stock_UD = SUD;
        }
    }
}
