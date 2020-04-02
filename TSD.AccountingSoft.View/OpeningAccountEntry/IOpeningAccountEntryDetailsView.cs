/***********************************************************************
 * <copyright file="IOpeningAccountEntryDetailsView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 25 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using TSD.AccountingSoft.Model.BusinessObjects.Opening;


namespace TSD.AccountingSoft.View.OpeningAccountEntry
{
    /// <summary>
    /// IOpeningAccountEntryDetailsView
    /// </summary>
    public interface IOpeningAccountEntryDetailsView : IView
    {
        /// <summary>
        /// Gets or sets the opening account entry details.
        /// </summary>
        /// <value>
        /// The opening account entry details.
        /// </value>
        IList<OpeningAccountEntryDetailModel> OpeningAccountEntryDetails { get; set; }
    }
}