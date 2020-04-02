/***********************************************************************
 * <copyright file="SqlServerFixedAssetDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Thursday, February 28, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  07/03/2014       Author    Tudt           Description: Coding standard
 * 
 * ************************************************************************/

using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.Dictionary;


namespace TSD.AccountingSoft.BusinessComponents.Messages.Dictionary
{
    /// <summary>
    /// Class PlanTemplateItemRequest.
    /// </summary>
    public class PlanTemplateItemRequest : RequestBase
    {
        /// <summary>
        /// Gets or sets the plan template item identifier.
        /// </summary>
        /// <value>The plan template item identifier.</value>
        public int PlanTemplateItemId { get; set; }

        /// <summary>
        /// The budget item
        /// </summary>
        public PlanTemplateItemEntity PlanTemplateItem;

        /// <summary>
        /// Gets or sets the plan template list identifier.
        /// </summary>
        /// <value>The plan template list identifier.</value>
        public int PlanTemplateListId { get; set; }
        
        /// <summary>
        /// Gets or sets the plan template list identifier.
        /// </summary>
        /// <value>The plan template list identifier.</value>
        public short PlanYear { get; set; }

        public int BudgetSourceCategoryId { get; set; }

        public int Option { get; set; }


    }
}
