using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Customer
    {
        private int _Cus_ID;
        private string _Cus_UserName;
        private string _Cus_Pass;
        private string _Cus_Email;
        private string _Cus_Address;
        private int _Cus_BanFlag;
        private string _Cus_CB;
        private string _Cus_CD;
        private string _Cus_UB;
        private string _Cus_UD;

        public int Cus_ID
        {
            get { return _Cus_ID; }
            set { _Cus_ID = value; }
        }
        public string Cus_UserName
        {
            get { return _Cus_UserName; }
            set { _Cus_UserName = value; }
        }
        public string Cus_Pass
        {
            get { return _Cus_Pass; }
            set { _Cus_Pass = value; }
        }
        public string Cus_Email
        {
            get { return _Cus_Email; }
            set { _Cus_Email = value; }
        }
        public string Cus_Address
        {
            get { return _Cus_Address; }
            set { _Cus_Address = value; }
        }
        public int Cus_BanFlag
        {
            get { return _Cus_BanFlag; }
            set { _Cus_BanFlag = value; }
        }
        public string Cus_CB
        {
            get { return _Cus_CB; }
            set { _Cus_CB = value; }
        }
        public string Cus_CD
        {
            get { return _Cus_CD; }
            set { _Cus_CD = value; }
        }
        public string Cus_UB
        {
            get { return _Cus_UB; }
            set { _Cus_UB = value; }
        }
        public string Cus_UD
        {
            get { return _Cus_UD; }
            set { _Cus_UD = value; }
        }

        public DTO_Customer() { }

        public DTO_Customer(int CuID, string CuName, string CuPass, string CuEmail, string CuAddr, int Ban, string CuCB, string CuCD, string CuUB, string CuUD)
        {
            this.Cus_ID = CuID;
            this.Cus_UserName = CuName;
            this.Cus_Pass = CuPass;
            this.Cus_Email = CuEmail;
            this.Cus_Address = CuAddr;
            this.Cus_BanFlag = Ban;
            this.Cus_CB = CuCB;
            this.Cus_CD = CuCD;
            this.Cus_UB = CuUB;
            this.Cus_UD = CuUD;
        }
    }
}
