using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BillDetails
    {
        private static int _Cus_ID;
        private static string _Cus_UserName;
        private static string _Cus_Email;
        private static string _Cus_Address;
        private static int _Purchase_ID;
        private static string _Purchase_Date;

        public static int Cus_ID
        {
            get { return _Cus_ID; }
            set { _Cus_ID = value; }
        }
        public static string Cus_UserName
        {
            get { return _Cus_UserName; }
            set { _Cus_UserName = value; }
        }
        public static string Cus_Email
        {
            get { return _Cus_Email; }
            set { _Cus_Email = value; }
        }
        public static string Cus_Address
        {
            get { return _Cus_Address; }
            set { _Cus_Address = value; }
        }
        public static int Purchase_ID
        {
            get { return _Purchase_ID; }
            set { _Purchase_ID = value; }
        }
        public static string Purchase_Date
        {
            get { return _Purchase_Date; }
            set { _Purchase_Date = value; }
        }


    }
}
