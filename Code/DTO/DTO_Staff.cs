using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Staff
    {
        private int _Stf_ID;
        private string _Stf_UsrName;
        private string _Stf_Pass;
        private string _Stf_Email;
        private int _Admin_Flag;
        private string _Stf_CB;
        private string _Stf_CD;
        private string _Stf_UB;
        private string _Stf_UD;

        public int Stf_ID
        {
            get { return _Stf_ID; }
            set { _Stf_ID = value; }
        }
        public string Stf_UsrName
        {
            get { return _Stf_UsrName; }
            set { _Stf_UsrName = value;}
        }
        public string Stf_Pass
        {
            get { return _Stf_Pass; }
            set { _Stf_Pass = value;}
        }
        public string Stf_Email
        {
            get { return _Stf_Email; }
            set { _Stf_Email = value; }
        }
        public int Admin_Flag
        {
            get { return _Admin_Flag; }
            set { _Admin_Flag = value; }
        }
        public string Stf_CB
        {
            get { return _Stf_CB; }
            set { _Stf_CB = value; }
        }
        public string Stf_CD
        {
            get { return _Stf_CD; }
            set { _Stf_CD = value; }
        }
        public string Stf_UB
        {
            get { return _Stf_UB; }
            set { _Stf_UB = value; }
        }
        public string Stf_UD
        {
            get { return _Stf_UD; }
            set { _Stf_UD = value; }
        }

        public DTO_Staff() { }

        public DTO_Staff(int StfID, string StfUName, string StfPass, string StfEmail, int StfFlag, string StfCB, string StfCD, string StfUB, string StfUD)
        {
            this.Stf_ID = StfID;
            this.Stf_UsrName = StfUName;
            this.Stf_Pass = StfPass;
            this.Stf_Email = StfEmail;
            this.Admin_Flag = StfFlag;
            this.Stf_CB = StfCB;
            this.Stf_CD = StfCD;
            this.Stf_UB = StfUB;
            this.Stf_UD = Stf_UD;
        }
    }
}
