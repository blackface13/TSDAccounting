/***********************************************************************
 * <copyright file="B03BNGModel.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 19 May 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

namespace TSD.AccountingSoft.Model.BusinessObjects.Report.Finacial
{
    /// <summary>
    /// B03BNGModel
    /// </summary>
    public class B03BNGModel
    {
        /// <summary>
        /// Gets or sets the accounting object code.
        /// </summary>
        /// <value>
        /// The accounting object code.
        /// </value>
        public string AccountingObjectCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the accounting object.
        /// </summary>
        /// <value>
        /// The name of the accounting object.
        /// </value>
        public string AccountingObjectName { get; set; }

        /// <summary>
        /// Gets or sets the accounting object group.
        /// </summary>
        /// <value>
        /// The accounting object group.
        /// </value>
        public string AccountingObjectGroup { get; set; }

        /// <summary>
        /// Gets or sets the opening amount.
        /// </summary>
        /// <value>
        /// The opening amount.
        /// </value>
        public decimal OpeningAmount { get; set; }

        /// <summary>
        /// Gets or sets the receive advance.
        /// </summary>
        /// <value>
        /// The receive advance.
        /// </value>
        public decimal ReceiveAdvance { get; set; }

        /// <summary>
        /// Gets or sets the advance payment.
        /// </summary>
        /// <value>
        /// The advance payment.
        /// </value>
        public decimal AdvancePayment { get; set; }

        /// <summary>
        /// Gets or sets the closing amount.
        /// </summary>
        /// <value>
        /// The closing amount.
        /// </value>
        public decimal ClosingAmount { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public short Type { get; set; }
    }
}
