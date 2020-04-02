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
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.Dictionary;


namespace TSD.AccountingSoft.BusinessComponents.Messages.Dictionary
{
    /// <summary>
    /// Class PlanTemplateListResponse.
    /// </summary>
    public class PlanTemplateListResponse : ResponseBase
    {
        /// <summary>
        /// The budget item
        /// </summary>
        public IList<PlanTemplateListEntity> PlanTemplateLists;

        /// <summary>
        /// The budget item
        /// </summary>
        public PlanTemplateListEntity PlanTemplateList;

        /// <summary>
        /// The budget item identifier
        /// </summary>
        public int PlanTemplateListId;
    }
}
