using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Book
    {
        private int _Book_ID;
        private string _Book_Name;
        private string _Book_Author;
        private int _Book_Price;
        private string _Book_CB;
        private string _Book_CD;
        private string _Book_UB;
        private string _Book_UD;


        public int Book_ID
        {
            get { return _Book_ID; }
            set { _Book_ID = value; }
        }
        public string Book_Name
        {
            get { return _Book_Name; }
            set { _Book_Name = value; }
        }
        public string Book_Author
        {
            get { return _Book_Author; }
            set { _Book_Author = value; }
        }
        public int Book_Price
        {
            get { return _Book_Price; }
            set { _Book_Price = value; }
        }
        public string Book_CB
        {
            get { return _Book_CB; }
            set { _Book_CB = value; }
        }
        public string Book_CD
        {
            get { return _Book_CD; }
            set { _Book_CD = value; }
        }
        public string Book_UB
        {
            get { return _Book_UB; }
            set { _Book_UB = value; }
        }
        public string Book_UD
        {
            get { return _Book_UD; }
            set { _Book_UD = value; }
        }

        public DTO_Book()
        {

        }

        public DTO_Book(int BID, string BName, string BAuthor, int BPrice, string BCB, string BCD, string BUB, string BUD)
        {
            this.Book_ID = BID;
            this.Book_Name = BName;
            this.Book_Author = BAuthor;
            this.Book_Price = BPrice;
            this.Book_CB = BCB;
            this.Book_CD = BCD;
            this.Book_UB = BUB;
            this.Book_UD = BUD;
        }
    }
}
