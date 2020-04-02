using TSD.AccountingSoft.Report.BaseParameterForm;
using TSD.AccountingSoft.Session;
using DateTimeRangeBlockDev.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TSD.AccountingSoft.Report.ParameterReportForm
{
    public partial class FrmB01CI : FrmXtraBaseParameter
    {
        public DateTime FromDate { get { return dateTimeRangeV1.FromDate; } set { dateTimeRangeV1.FromDate = value; } }
        public DateTime ToDate { get { return dateTimeRangeV1.ToDate; } set { dateTimeRangeV1.ToDate = value; } }
        public string PeriodName { 
            get 
            {
                if (dateTimeRangeV1.cboDateRange.Text.Equals("Tự chọn") || dateTimeRangeV1.cboDateRange.Text.Equals("Năm nay"))
                    return "";
                return dateTimeRangeV1.cboDateRange.Text; 
            } 
        }

        public FrmB01CI()
        {
            InitializeComponent();
            dateTimeRangeV1.DateRangePeriodMode = DateRangeMode.Reduce;
            dateTimeRangeV1.InitSelectedIndex = GlobalVariable.DateRangeSelectedIndex;
        }
    }
}
