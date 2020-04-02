using TSD.AccountingSoft.Model.BusinessObjects.Report;
using TSD.AccountingSoft.Presenter.Report;
using TSD.AccountingSoft.View.Report;
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
    public partial class FrmB04BCTC : FrmXtraBaseParameter, IReportDataTemplatesView
    {
        ReportDataTemplatesPresenter _reportDataTemplatesPresenter = null;
        public FrmB04BCTC()
        {
            InitializeComponent();

            dateTimeRangeV1.DateRangePeriodMode = DateRangeMode.Reduce;
            dateTimeRangeV1.InitSelectedIndex = GlobalVariable.DateRangeSelectedIndex;
            _reportDataTemplatesPresenter = new ReportDataTemplatesPresenter(this);

            this.Load += FrmB04BCTC_Load;
        }

        private void FrmB04BCTC_Load(object sender, EventArgs e)
        {
            try
            {
                List<string> dataTemplateCode = new List<string>()
                {
                    "ReportB04BCTC_Paramater01",
                    "ReportB04BCTC_Paramater02",
                    "ReportB04BCTC_Paramater03",
                    "ReportB04BCTC_Paramater04",
                    "ReportB04BCTC_Paramater05",
                    "ReportB04BCTC_Paramater06",
                    "ReportB04BCTC_Paramater07",
                    "ReportB04BCTC_Paramater08",
                    "ReportB04BCTC_Paramater09",
                    "ReportB04BCTC_Paramater10",
                };
                _reportDataTemplatesPresenter.Display(dataTemplateCode);
            }
            catch (Exception) { }
        }

        public string PeriodName
        {
            get
            {
                if (dateTimeRangeV1.cboDateRange.Text.Equals("Tự chọn") || dateTimeRangeV1.cboDateRange.Text.Equals("Năm nay")) return string.Empty;
                return dateTimeRangeV1.cboDateRange.Text;
            }
        }
        public DateTime FromDate
        {
            get { return dateTimeRangeV1.FromDate; }
            set { dateTimeRangeV1.FromDate = value; }
        }
        public DateTime ToDate
        {
            get { return dateTimeRangeV1.ToDate; }
            set { dateTimeRangeV1.ToDate = value; }
        }
        public string Paramater01
        {
            get { return txtParamater01.EditValue == null ? null : txtParamater01.EditValue.ToString(); }
            set { txtParamater01.EditValue = value; }
        }
        public string Paramater02
        {
            get { return txtParamater02.EditValue == null ? null : txtParamater02.EditValue.ToString(); }
            set { txtParamater02.EditValue = value; }
        }
        public string Paramater03
        {
            get { return txtParamater03.EditValue == null ? null : txtParamater03.EditValue.ToString(); }
            set { txtParamater03.EditValue = value; }
        }
        public DateTime? Paramater04
        {
            get { return txtParamater04.EditValue == null ? (DateTime?)null : Convert.ToDateTime(txtParamater04.EditValue); }
            set { txtParamater04.EditValue = value; }
        }
        public string Paramater05
        {
            get { return txtParamater05.EditValue == null ? null : txtParamater05.EditValue.ToString(); }
            set { txtParamater05.EditValue = value; }
        }
        public string Paramater06
        {
            get { return txtParamater06.EditValue == null ? null : txtParamater06.EditValue.ToString(); }
            set { txtParamater06.EditValue = value; }
        }
        public string Paramater07
        {
            get { return txtParamater07.EditValue == null ? null : txtParamater07.EditValue.ToString(); }
            set { txtParamater07.EditValue = value; }
        }
        public string Paramater08
        {
            get { return txtParamater08.EditValue == null ? null : txtParamater08.EditValue.ToString(); }
            set { txtParamater08.EditValue = value; }
        }
        public string Paramater09
        {
            get { return txtParamater09.EditValue == null ? null : txtParamater09.EditValue.ToString(); }
            set { txtParamater09.EditValue = value; }
        }
        public DateTime? Paramater10
        {
            get { return txtParamater10.EditValue == null ? (DateTime?)null : Convert.ToDateTime(txtParamater10.EditValue); }
            set { txtParamater10.EditValue = value; }
        }

        List<ReportDataTemplateModel> _reportDataTemplates;

        public IList<ReportDataTemplateModel> ReportDataTemplates
        {
            get { return _reportDataTemplates; }
            set
            {
                _reportDataTemplates = value.ToList();

                if (_reportDataTemplates != null && _reportDataTemplates.Count() > 0)
                {
                    foreach (var item in value)
                    {
                        if (item.DataTemplateCode == "ReportB04BCTC_Paramater01")
                            Paramater01 = item.Value;
                        else if (item.DataTemplateCode == "ReportB04BCTC_Paramater02")
                            Paramater02 = item.Value;
                        else if (item.DataTemplateCode == "ReportB04BCTC_Paramater03")
                            Paramater03 = item.Value;
                        else if (item.DataTemplateCode == "ReportB04BCTC_Paramater04")
                            Paramater04 = item.Value == null ? (DateTime?)null : Convert.ToDateTime(item.Value);
                        else if (item.DataTemplateCode == "ReportB04BCTC_Paramater05")
                            Paramater05 = item.Value;
                        else if (item.DataTemplateCode == "ReportB04BCTC_Paramater06")
                            Paramater06 = item.Value;
                        else if (item.DataTemplateCode == "ReportB04BCTC_Paramater07")
                            Paramater07 = item.Value;
                        else if (item.DataTemplateCode == "ReportB04BCTC_Paramater08")
                            Paramater08 = item.Value;
                        else if (item.DataTemplateCode == "ReportB04BCTC_Paramater09")
                            Paramater09 = item.Value;
                        else if (item.DataTemplateCode == "ReportB04BCTC_Paramater10")
                            Paramater10 = item.Value == null ? (DateTime?)null : Convert.ToDateTime(item.Value); ;
                    }
                }
            }
        }

        protected override void btnOk_Click(object sender, System.EventArgs e)
        {
            base.btnOk_Click(sender, e);

            InsertParamater();
        }

        private void InsertParamater()
        {
            List<ReportDataTemplateModel> reportDataTemplates = new List<ReportDataTemplateModel>()
            {
                new ReportDataTemplateModel()
                {
                    DataTemplateCode = "ReportB04BCTC_Paramater01",
                    Value = Paramater01,
                    Description = "Số quyết định"
                },
                new ReportDataTemplateModel()
                {
                    DataTemplateCode = "ReportB04BCTC_Paramater02",
                    Value = Paramater02,
                    Description = "Số, ngày quyết định giao chủ tài chính của"
                },
                new ReportDataTemplateModel()
                {
                    DataTemplateCode = "ReportB04BCTC_Paramater03",
                    Value = Paramater03,
                    Description = "Chức năng, nhiệm vụ chính của đơn vị"
                },
                new ReportDataTemplateModel()
                {
                    DataTemplateCode = "ReportB04BCTC_Paramater04",
                    Value = Paramater04.ToString(),
                    Description = "Ngày quyết định"
                },
                new ReportDataTemplateModel()
                {
                    DataTemplateCode = "ReportB04BCTC_Paramater05",
                    Value = Paramater05,
                    Description = "III. Các thông tin khác đơn vị thuyết minh thêm"
                },
                new ReportDataTemplateModel()
                {
                    DataTemplateCode = "ReportB04BCTC_Paramater06",
                    Value = Paramater06,
                    Description = "IV. Thông tin thuyết minh khác"
                },
                new ReportDataTemplateModel()
                {
                    DataTemplateCode = "ReportB04BCTC_Paramater07",
                    Value = Paramater07,
                    Description = "V.Thuyết minh khác cho báo cáo lưu chuyển tiền tệ"
                },
                new ReportDataTemplateModel()
                {
                    DataTemplateCode = "ReportB04BCTC_Paramater08",
                    Value = Paramater08,
                    Description = "VI. Thông tin thuyết minh khác"
                },
                new ReportDataTemplateModel()
                {
                    DataTemplateCode = "ReportB04BCTC_Paramater09",
                    Value = Paramater09,
                    Description = "QD tự chủ TC số"
                },
                new ReportDataTemplateModel()
                {
                    DataTemplateCode = "ReportB04BCTC_Paramater10",
                    Value = Paramater10.ToString(),
                    Description = "Ngày QĐ tự chủ"
                },
            };

            var index = _reportDataTemplatesPresenter.Save(reportDataTemplates);
        }
    }
}
