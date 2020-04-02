/***********************************************************************
 * <copyright file="CalculateClosingModel.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: Tuesday, December 23, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/


namespace TSD.AccountingSoft.Model.BusinessObjects.Dictionary
{
    /// <summary>
    /// CalculateClosingModel
    /// </summary>
    public class CalculateClosingModel
    {
       /// <summary>
        /// Gets or sets the Account Id.
        /// </summary>
        /// <value>
        /// The Account Id.
        /// </value>
       public int AccountId { get; set;}

        /// <summary>
        /// Gets or sets the Account Code.
        /// </summary>
        /// <value>
        /// The Account Code.
        /// </value>
        public string AccountCode { get; set; }

        /// <summary>
        /// Gets or sets the Account Name.
        /// </summary>
        /// <value>
        /// The Account Name.
        /// </value>
       public string AccountName { get; set; }

        /// <summary>
        /// Gets or sets the Parent Id.
        /// </summary>
        /// <value>
        /// The Parent Id.
        /// </value>
       public int ParentId { get; set; }

         /// <summary>
        /// Gets or sets the Closing Amount.
        /// </summary>
        /// <value>
        /// The Closing Amount.
        /// </value>
       public decimal ClosingAmount { get; set; }


    }
}
