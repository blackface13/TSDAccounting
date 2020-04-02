/***********************************************************************
 * <copyright file="SqlServerFixedAssetDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Thursday, February 26, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  07/03/2014       Author    Tudt           Description: Coding standard
 * 
 * ************************************************************************/

using System.Collections.Generic;


namespace TSD.AccountingSoft.Model.BusinessObjects.Dictionary
{
    /// <summary>
    /// Class PlanTemplateListModel.
    /// </summary>
    public class PlanTemplateListModel
    {
        /// <summary>
        /// Gets or sets the plan template list identifier.
        /// </summary>
        /// <value>The plan template list identifier.</value>
        public int PlanTemplateListId { get; set; }

        /// <summary>
        /// Gets or sets the plan template list code.
        /// </summary>
        /// <value>The plan template list code.</value>
        public string PlanTemplateListCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the plan template list.
        /// </summary>
        /// <value>The name of the plan template list.</value>
        public string PlanTemplateListName { get; set; }

        /// <summary>
        /// Gets or sets the plan year.
        /// </summary>
        /// <value>The plan year.</value>
        public short PlanYear { get; set; }

        /// <summary>
        /// Gets or sets the type of the plan.
        /// </summary>
        /// <value>The type of the plan.</value>
        public short PlanType { get; set; }

        /// <summary>
        /// Gets or sets the parent identifier.
        /// </summary>
        /// <value>The parent identifier.</value>
        public int? ParentId { get; set; }

        /// <summary>
        /// Gets or sets the plan template items.
        /// </summary>
        /// <value>The plan template items.</value>
        public IList<PlanTemplateItemModel> PlanTemplateItems { get; set; }
    }
}
