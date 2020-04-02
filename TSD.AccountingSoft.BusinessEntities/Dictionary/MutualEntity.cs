/***********************************************************************
 * <copyright file="BuildingEntity.cs" company="BUCA JSC">
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

using System;

namespace TSD.AccountingSoft.BusinessEntities.Dictionary
{
    /// <summary>
    /// BuildingEntity
    /// </summary>
    public class MutualEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BuildingEntity"/> class.
        /// </summary>
        public MutualEntity()
        {

        }

        public MutualEntity (int mutualId ,string  mutualCode,  string  mutualName ,string   jobCandidate ,string  address ,decimal  area, DateTime useDate ,int  totalFloor ,int  state , string    description , bool  isActive)
            : this()
        {
        MutualId = MutualId;
        MutualCode =mutualCode;
        MutualName=mutualName;
        JobCandidate =jobCandidate;
        Address =address;
        Area =area;
        UseDate =useDate;
        TotalFloor =totalFloor;
        State =state;
         Description =description;
         IsActive = IsActive;            
        }

        public int MutualId { get; set; }
        public string MutualCode { get; set; }
        public string MutualName { get; set; }
        public string JobCandidate { get; set; }
        public string Address { get; set; }
        public decimal Area { get; set; }
        public DateTime UseDate { get; set; }
        public int TotalFloor { get; set; }
        public int State { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
