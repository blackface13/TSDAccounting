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
    public partial class FrmB01CII : FrmXtraBaseParameter
    {
        public FrmB01CII()
        {
            InitializeComponent();
            dateTimeRangeV1.DateRangePeriodMode = DateRangeMode.Reduce;
            dateTimeRangeV1.InitSelectedIndex = GlobalVariable.DateRangeSelectedIndex;
        }

        public string FromDate
        {
            get
            {
                return dateTimeRangeV1.FromDate.ToShortDateString();
            }
        }

        public string ToDate
        {
            get
            {
                return dateTimeRangeV1.ToDate.ToShortDateString();
            }
        }

        public string PeriodName
        {
            get
            {
                if (dateTimeRangeV1.cboDateRange.Text.Equals("Tự chọn") || dateTimeRangeV1.cboDateRange.Text.Equals("Năm nay"))
                    return "";
                return dateTimeRangeV1.cboDateRange.Text;
            }
        }
    }
}
