using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Print_UI : Form
    {
        public Print_UI()
        {
            InitializeComponent();
        }

        int Option = StaffControl_UI.Option;

        private void PrintQuantity_UI_Load(object sender, EventArgs e)
        {
            if(Option == 1)
            {
                quantity_Report1.Load("D:\\Study\\Y3_S2\\Object Oriented and Design\\Lab\\Project\\Book-controlling\\GUI\\Quantity_Report.rpt");
                crystalReportViewer1.ReportSource = quantity_Report1;
                crystalReportViewer1.Refresh();
            }
            else if(Option == 2)
            {
                sale_Report1.Load("D:\\Study\\Y3_S2\\Object Oriented and Design\\Lab\\Project\\Book-controlling\\GUI\\Sale_Report.rpt");
                crystalReportViewer1.ReportSource = sale_Report1;
                crystalReportViewer1.Refresh();
            }
            else if (Option == 3)
            {
                staff_Report1.Load("D:\\Study\\Y3_S2\\Object Oriented and Design\\Lab\\Project\\Book-controlling\\GUI\\Staff_Report.rpt");
                crystalReportViewer1.ReportSource = staff_Report1;
                crystalReportViewer1.Refresh();
            }
            else if (Option == 4)
            {
                customer_Report1.Load("D:\\Study\\Y3_S2\\Object Oriented and Design\\Lab\\Project\\Book-controlling\\GUI\\Customer_Report.rpt");
                crystalReportViewer1.ReportSource = customer_Report1;
                crystalReportViewer1.Refresh();
            }
        }
    }
}
