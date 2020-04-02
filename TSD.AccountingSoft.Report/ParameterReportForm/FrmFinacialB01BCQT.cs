using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Report.BaseParameterForm;
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
    public partial class FrmFinacialB01BCQT : FrmXtraBaseParameter
    {
        public FrmFinacialB01BCQT()
        {
            InitializeComponent();
        }

        public DateTime FromDate
        {
            get
            {
                return dateTimeRangeV1.FromDate;
            }
            set
            {
                dateTimeRangeV1.FromDate = value;
            }
        }
        public DateTime ToDate 
        {
            get
            {
                return dateTimeRangeV1.ToDate;
            }
            set
            {
                dateTimeRangeV1.ToDate = value;
            }
        }

        public bool IsCalcEstimateInYear
        {
            get { return checkBox1.Checked; }
            set { checkBox1.Checked = value; }
        }
        public decimal Amount02
        {
            get { return Convert.ToDecimal(textBox1.EditValue); }
            set { textBox1.EditValue = value; }
        }
        public decimal Amount05
        {
            get { return Convert.ToDecimal(textBox2.EditValue); }
            set { textBox2.EditValue = value; }
        }
        public decimal Amount06
        {
            get { return Convert.ToDecimal(textBox3.EditValue); }
            set { textBox3.EditValue = value; }
        }
        public decimal Amount07
        {
            get { return Convert.ToDecimal(textBox4.EditValue); }
            set { textBox4.EditValue = value; }
        }

        protected override bool ValidData()
        {
            return true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
            }
            else
            {
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
            }
        }
    }
}
