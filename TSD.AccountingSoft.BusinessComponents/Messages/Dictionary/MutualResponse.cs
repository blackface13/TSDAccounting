/***********************************************************************
 * <copyright file="BuildingResponse.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
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

    public class MutualResponse : ResponseBase
    {
        /// <summary>
        /// The buildings
        /// </summary>
        public IList<MutualEntity> Mutuals;

        /// <summary>
        /// The building
        /// </summary>
        public MutualEntity Mutual;

        public int MutualId { get; set; }

        public string MutualCode{ get; set; }
    }
}
