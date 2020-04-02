using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.BusinessEntities.Report.Finacial
{
    /// <summary>
    /// Class S33HEntity.
    /// </summary>
    public class S33HEntity 
    {
        /// <summary>
        /// Gets or sets the reference no.
        /// </summary>
        /// <value>The reference no.</value>
        public string RefNo { get; set; }

        /// <summary>
        /// Gets or sets the reference date.
        /// </summary>
        /// <value>The reference date.</value>
        public DateTime? RefDate { get; set; }

        /// <summary>
        /// Gets or sets the posted date.
        /// </summary>
        /// <value>The posted date.</value>
        public DateTime? PostedDate { get; set; }


        /// <summary>
        /// Gets or sets the document include.
        /// </summary>
        /// <value>The document include.</value>
        public string Description { get; set; }

        /// <summary>
        /// Tài khoản đối ứng
        /// </summary>
        public string CorrespondingAccountNumber { get; set; }

        /// <summary>
        /// Gets or sets the account number.
        /// </summary>
        /// <value>The account number.</value>
        public string JournalMemo { get; set; }
        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>The amount.</value>
        public Decimal CreditAmountOriginal { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>The amount.</value>
        public Decimal DebitAmountOriginal { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>The amount.</value>
        public Decimal CreditAmountBalance { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>The amount.</value>
        public Decimal DebitAmountBalance { get; set; }

        /// <summary>
        /// Gets or sets the font style.
        /// </summary>
        /// <value>The font style.</value>
        public string FontStyle { get; set; }

        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>The reference identifier.</value>
        public int RefId { get; set; }

        /// <summary>
        /// Gets or sets the reference type identifier.
        /// </summary>
        /// <value>The reference type identifier.</value>
        public int RefTypeId { get; set; }

        /// <summary>
        /// Gets or sets the selected field.
        /// </summary>
        /// <value>
        /// The selected field.
        /// </value>
        public string SelectedField { get; set; }

        /// <summary>
        /// Gets or sets the selected all value field.
        /// </summary>
        /// <value>
        /// The selected all value field.
        /// </value>
        public string SelectedAllValueField { get; set; }

    }
}
