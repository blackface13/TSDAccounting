using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.Model.BusinessObjects.Report.Finacial
{
    public class ReportB01BCTCModel
    {
        public int     Part        { get; set; }
        public string  Index       { get; set; }
        public string  ItemCode    { get; set; }
        public string  ItemName    { get; set; }
        public decimal BeginAmount { get; set; }
        public decimal EndAmount   { get; set; }
        public bool    IsBold      { get; set; }
        public bool    IsItalic    { get; set; }
        public int     SortOrder   { get; set; }
    }
}
