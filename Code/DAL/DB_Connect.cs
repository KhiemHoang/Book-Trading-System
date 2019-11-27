using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class DB_Connect
    {
        protected SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-BLOGEJ9;Initial Catalog=Book_controlling;Integrated Security=True");
        //118.68.247.62
        //protected SqlConnection _conn = new SqlConnection(@"Data Source=118.68.247.62;Initial Catalog=Book-controlling;Integrated Security=True");
    }
}
