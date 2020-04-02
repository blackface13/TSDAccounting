/***********************************************************************
 * <copyright file="S03BHModel.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: 16 May 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

namespace TSD.AccountingSoft.Model.BusinessObjects.Report.Finacial
{
    /// <summary>
    /// Class S03BHModel.
    /// </summary>
   public class S03BHModel
    {

        /// <summary>
        /// Gets or sets the vourcher no.
        /// </summary>
        /// <value>The vourcher no.</value>
        public string RefNo { get; set; }

        /// <summary>
        /// Gets or sets the posted date.
        /// </summary>
        /// <value>The posted date.</value>
        public string PostedDate { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the account number.
        /// </summary>
        /// <value>The account number.</value>
        public string AccountNumber { get; set; }

        /// <summary>
        /// Gets or sets the corresponding account number.
        /// </summary>
        /// <value>The corresponding account number.</value>
        public string CorrespondingAccountNumber { get; set; }

        /// <summary>
        /// Gets or sets the accumulated account numbber.
        /// </summary>
        /// <value>The accumulated account numbber.</value>
        public decimal AccumulatedAccountNumbber { get; set; }
        /// <summary>
        /// Gets or sets the accumulated corr account numbber.
        /// </summary>
        /// <value>The accumulated corr account numbber.</value>
        public decimal AccumulatedCorrAccountNumbber { get; set; }

        /// <summary>
        /// Gets or sets the budget item code.
        /// </summary>
        /// <value>The budget item code.</value>
        public string BudgetItemCode { get; set; }

        /// <summary>
        /// Gets or sets the amount account numbber.
        /// </summary>
        /// <value>The amount account numbber.</value>
        public decimal AmountAccountNumbber { get; set; }

        /// <summary>
        /// Gets or sets the amount corr account numbber.
        /// </summary>
        /// <value>The amount corr account numbber.</value>
        public decimal AmountCorrAccountNumbber { get; set; }

        /// <summary>
        /// Gets or sets the amount ogr account numbber.
        /// </summary>
        /// <value>The amount ogr account numbber.</value>
        public decimal AmountOgrAccountNumbber { get; set; }

        /// <summary>
        /// Gets or sets the amount ogr corr account numbber.
        /// </summary>
        /// <value>The amount ogr corr account numbber.</value>
        public decimal AmountOgrCorrAccountNumbber { get; set; }


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


    }
}
