using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class DAL_Book : DB_Connect
    {
        //Get all information
        public DataTable GetAllBook()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select book_id as SKU, book_name as Title, book_author as Author, book_price as Price, create_by as 'Create by', create_date as 'Create date', update_by as 'Update By', update_date as 'Update date' from book", _conn);
            DataTable dtBook = new DataTable();
            da.Fill(dtBook);
            return dtBook;
        }

        //Get all for Customer
        public DataTable GetAllBook_forCus()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select book_id as SKU, book_name as Title, book_author as Author, book_price as Price from book", _conn);
            DataTable dtBook = new DataTable();
            da.Fill(dtBook);
            return dtBook;
        }


        //Get specific Book by Name
        public DataTable GetBook_byName(string Name)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from book where book_name like '" + Name + "%';", _conn);
            DataTable dtBook = new DataTable();
            da.Fill(dtBook);
            return dtBook;
        }

        //Get Book's Price
        public string GetBookPrice(int BID)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select book_price from book where book_id = " + BID, _conn);
            DataTable dtBook = new DataTable();
            da.Fill(dtBook);
            string Price = dtBook.Rows[0][0].ToString();
            return Price;
        }

        //Count Total Book
        public int CountTotalBook()
        {
            SqlDataAdapter da = new SqlDataAdapter("select count(*) from book", _conn);
            DataTable dtBook = new DataTable();
            da.Fill(dtBook);
            int Total = Convert.ToInt32(dtBook.Rows[0][0].ToString());
            return Total;
        }

        //Add new Book
        public bool AddBook(DTO_Book Book)
        {
            try
            {
                _conn.Open();

                string SQL = string.Format("insert into book values('{0}','{1}', {2},'{3}', {4}, '{5}', {6})", Book.Book_Name, Book.Book_Author, Book.Book_Price, Book.Book_CB, Book.Book_CD, Book.Book_UB, Book.Book_UD);

                SqlCommand cmd = new SqlCommand(SQL, _conn);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }

            catch (Exception e)
            { }

            finally
            {
                _conn.Close();
            }

            return false;
        }

        //Get Book ID
        public int GetBookMaxID()
        {
            SqlDataAdapter da = new SqlDataAdapter("select max(book_id) from book;", _conn);
            DataTable dtBook = new DataTable();
            da.Fill(dtBook);
            int ID = Convert.ToInt32(dtBook.Rows[0][0].ToString());
            return ID;
        }

        //Update Book
        public bool UpdateBook(DTO_Book Book)
        {
            try
            {
                _conn.Open();

                string SQL = string.Format("update book set book_name = '{0}', book_author = '{1}', book_price = {2}, update_by = '{3}', update_date = {4} where book_id = {5};", Book.Book_Name, Book.Book_Author, Book.Book_Price, Book.Book_UB, Book.Book_UD, Book.Book_ID);

                SqlCommand cmd = new SqlCommand(SQL, _conn);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }

            catch (Exception e)
            { }

            finally
            {
                _conn.Close();
            }

            return false;
        }

        //Delete Book
        public bool DelBook(int BID)
        {
            try
            {
                _conn.Open();

                string SQL = string.Format("delete from book where book_id = {0}", BID);

                SqlCommand cmd = new SqlCommand(SQL, _conn);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }

            catch (Exception e)
            { }

            finally
            {
                _conn.Close();
            }

            return false;
        }


    }
}
