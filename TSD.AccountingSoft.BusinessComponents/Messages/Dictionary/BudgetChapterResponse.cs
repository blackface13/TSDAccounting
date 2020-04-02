/***********************************************************************
 * <copyright file="BudgetChapterResponse.cs" company="BUCA JSC">
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

using System.Collections.Generic;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.Dictionary;


namespace TSD.AccountingSoft.BusinessComponents.Messages.Dictionary
{
    /// <summary>
    /// Class BudgetChapterResponse.
    /// </summary>
    public class BudgetChapterResponse : ResponseBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BudgetChapterResponse"/> class.
        /// </summary>
        public BudgetChapterResponse() { }

        /// <summary>
        /// The budget chapters
        /// </summary>
        public IList<BudgetChapterEntity> BudgetChapters;

        /// <summary>
        /// The budget chapter
        /// </summary>
        public BudgetChapterEntity BudgetChapter;

        /// <summary>
        /// Gets or sets the budget chapter identifier.
        /// </summary>
        /// <value>The budget chapter identifier.</value>
        public int BudgetChapterId { get; set; }
    }
}
