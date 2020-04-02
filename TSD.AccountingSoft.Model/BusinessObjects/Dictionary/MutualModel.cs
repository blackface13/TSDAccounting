/***********************************************************************
 * <copyright file="BuildingModel.cs" company="BUCA JSC">
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

namespace TSD.AccountingSoft.Model.BusinessObjects.Dictionary
{

    public class MutualModel
    {

        public int MutualId { get; set; }


        public string MutualCode { get; set; }


        public string MutualName { get; set; }


        public string JobCandidate { get; set; }


        public string Address { get; set; }


        public decimal Area { get; set; }

        public int State { get; set; }

        public int TotalFloor { get; set; }

        public DateTime UseDate { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }
    }
}
