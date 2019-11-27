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
    public class BUS_History
    {
        DAL_History dalHistory = new DAL_History();

        //Add History
        public bool addHistory(int PID, int CuID, int BID, int Quantity, int Price)
        {
            return dalHistory.AddHistory(PID, CuID, BID, Quantity, Price);
        }

        //Get History
        public DataTable getHistory(int CuID)
        {
            return dalHistory.GetHistory(CuID);
        }

        public DataTable getHistoryDate(int CuID, string Date)
        {
            return dalHistory.GetHistoryDate(CuID, Date);
        }
    }
}
