using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.Model.BusinessObjects.Report.Finacial
{
    /// <summary>
    /// Class S03AHModel.
    /// </summary>
    public class S03AHModel
    {
        /// <summary>
        /// Nhóm tài khoản:
        /// A- Tài khoản trong nhóm
        /// B- Tài khoản ngoài nhóm
        /// </summary>
        public string AccountGroupCode { get; set; }
        public string RefNo { get; set; }
        public DateTime? RefDate { get; set; }
        public DateTime? PostedDate { get; set; }
        public string FontStyle { get; set; }
        public string Description { get; set; }
        public string AccountNumber { get; set; }
        public Decimal CreditAmount { get; set; }
        public Decimal DebitAmount { get; set; }
        public int RefId { get; set; }
        public int RefTypeId { get; set; }
    }
}
