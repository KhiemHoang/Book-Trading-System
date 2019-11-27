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
    public class BUS_Book
    {
        DAL_Book dalBook = new DAL_Book();
        //Get all book information
        public DataTable getAllBook()
        {
            return dalBook.GetAllBook();
        }

        //Get all book for customer
        public DataTable getAllBook_forCus()
        {
            return dalBook.GetAllBook_forCus();
        }

        //Get Specific Book by Name
        public DataTable getBook_byName(string Name)
        {
            return dalBook.GetBook_byName(Name);
        }

        //Get Book Price
        public string getBookPrice(int BID)
        {
            return dalBook.GetBookPrice(BID);
        }

        //Count total Book
        public int countTotalBook()
        {
            return dalBook.CountTotalBook();
        }

        //Add Book
        public bool addBook(DTO_Book Book)
        {
            return dalBook.AddBook(Book);
        }

        //get Book Max ID
        public int getBookMaxID()
        {
            return dalBook.GetBookMaxID();
        }

        //update Book
        public bool updateBook(DTO_Book Book)
        {
            return dalBook.UpdateBook(Book);
        }

        //delete Book
        public bool delBook(int BID)
        {
            return dalBook.DelBook(BID);
        }
    }
}
