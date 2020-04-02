/***********************************************************************
 * <copyright file="IMergerFundView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   THODD
 * Email:    thodd@buca.vn
 * Website:
 * Create Date: 07 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

namespace TSD.AccountingSoft.View.Dictionary
{
    /// <summary>
    /// Interface IMergerFundView
    /// </summary>
    public interface IMergerFundView : IView
    {
        /// <summary>
        /// Gets or sets the merger fund identifier.
        /// </summary>
        /// <value>The merger fund identifier.</value>
        int MergerFundId { get; set; }

        /// <summary>
        /// Gets or sets the name of the merger fund.
        /// </summary>
        /// <value>The name of the merger fund.</value>
        string MergerFundName { get; set; }

        /// <summary>
        /// Gets or sets the merger fund code.
        /// </summary>
        /// <value>The merger fund code.</value>
        string MergerFundCode { get; set; }

        /// <summary>
        /// Gets or sets the parent identifier.
        /// </summary>
        /// <value>The parent identifier.</value>
        int? ParentId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is system.
        /// </summary>
        /// <value><c>true</c> if this instance is system; otherwise, <c>false</c>.</value>
        bool IsSystem { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        string Description { get; set; }

        /// <summary>
        /// Gets or sets the grade.
        /// </summary>
        /// <value>The grade.</value>
        int Grade { get; set; }

        /// <summary>
        /// Gets or sets the name of the foreign.
        /// </summary>
        /// <value>The name of the foreign.</value>
        string ForeignName { get; set; }
    }
}
