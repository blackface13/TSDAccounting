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

using System.Collections.Generic;
using TSD.AccountingSoft.BusinessEntities.BusinessRules;


namespace TSD.AccountingSoft.BusinessEntities.Dictionary
{
    /// <summary>
    /// Class PlanTemplateListEntity.
    /// </summary>
    public class PlanTemplateListEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlanTemplateListEntity"/> class.
        /// </summary>
        public PlanTemplateListEntity()
        {
            AddRule(new ValidateRequired("PlanTemplateListCode"));
            AddRule(new ValidateRequired("PlanTemplateListName"));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlanTemplateListEntity"/> class.
        /// </summary>
        /// <param name="planTemplateListId">The plan template list identifier.</param>
        /// <param name="planTemplateListCode">The plan template list code.</param>
        /// <param name="planTemplateListName">Name of the plan template list.</param>
        /// <param name="planYear">The plan year.</param>
        /// <param name="planType">Type of the plan.</param>
        /// <param name="parentId">The parent identifier.</param>
        public PlanTemplateListEntity(int planTemplateListId, string planTemplateListCode, string planTemplateListName,
            short planYear, short planType, int? parentId)
            : this()
        {
            PlanTemplateListId = planTemplateListId;
            PlanTemplateListCode = planTemplateListCode;
            PlanTemplateListName = planTemplateListName;
            PlanYear = planYear;
            PlanType = planType;
            ParentId = parentId;
        }

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
        public IList<PlanTemplateItemEntity> PlanTemplateItems { get; set; }
    }
}
