/***********************************************************************
 * <copyright file="ReportGroupEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Thursday, March 13, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/
using TSD.AccountingSoft.BusinessEntities.BusinessRules;

namespace TSD.AccountingSoft.BusinessEntities.Report
{
    /// <summary>
    /// Report Group Entity
    /// </summary>
    public class ReportGroupEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReportGroupEntity"/> class.
        /// </summary>
        public ReportGroupEntity()
        {
            AddRule(new ValidateRequired("ReportGroupID"));
            AddRule(new ValidateRequired("ReportGroupName"));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportGroupEntity"/> class.
        /// </summary>
        /// <param name="reportGroupId">The report group identifier.</param>
        /// <param name="reportGroupName">Name of the report group.</param>
        /// <param name="description">The description.</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <param name="isVoucher">if set to <c>true</c> [is voucher].</param>
        public ReportGroupEntity(int reportGroupId, string reportGroupName, string description, bool isActive, bool isVoucher)
            : this()
        {
            ReportGroupId = reportGroupId;
            ReportGroupName = reportGroupName;
            Description = description;
            IsVoucher = isVoucher;
            IsActive = isActive;
        }

        /// <summary>
        /// Gets or sets the report group identifier.
        /// </summary>
        /// <value>
        /// The report group identifier.
        /// </value>
        public int ReportGroupId { get; set; }
        /// <summary>
        /// Gets or sets the name of the report group.
        /// </summary>
        /// <value>
        /// The name of the report group.
        /// </value>
        public string ReportGroupName { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is voucher.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is voucher; otherwise, <c>false</c>.
        /// </value>
        public bool IsVoucher { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }
    }
}
