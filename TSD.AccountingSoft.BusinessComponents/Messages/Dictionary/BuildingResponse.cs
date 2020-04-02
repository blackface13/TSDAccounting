/***********************************************************************
 * <copyright file="BuildingResponse.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 10 June 2014
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
    /// BuildingResponse
    /// </summary>
    public class BuildingResponse : ResponseBase
    {
        /// <summary>
        /// The buildings
        /// </summary>
        public IList<BuildingEntity> Buildings;

        /// <summary>
        /// The building
        /// </summary>
        public BuildingEntity Building;

        /// <summary>
        /// Gets or sets the building identifier.
        /// </summary>
        /// <value>
        /// The building identifier.
        /// </value>
        public int BuildingId { get; set; }
    }
}
