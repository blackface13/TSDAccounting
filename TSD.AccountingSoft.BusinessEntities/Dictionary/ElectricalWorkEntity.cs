/***********************************************************************
 * <copyright file="StockEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: Thursday, March 13, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using TSD.AccountingSoft.BusinessEntities.BusinessRules;


namespace TSD.AccountingSoft.BusinessEntities.Dictionary
{
    public class ElectricalWorkEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StockEntity"/> class.
        /// </summary>
        public ElectricalWorkEntity()
        {
            AddRule(new ValidateId("ElectricalWorkId"));
        }


        public ElectricalWorkEntity(int electricalWorkId, string name, int postedDate)
        {
            ElectricalWorkId = electricalWorkId;
            Name = name;
            PostedDate = postedDate;
        }

        public int ElectricalWorkId { get; set; }
        public string Name { get; set; }
        public int PostedDate { get; set; }



    }
}
