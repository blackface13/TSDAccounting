/***********************************************************************
 * <copyright file="IOpeningSupplyEntryDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Wednesday, January 3, 2018
 * Usage: 
 * 
 * RevisionHistory: 
 * DateWednesday, January 3, 2018 Author SonTV  Description 
 * 
 * ************************************************************************/

using TSD.AccountingSoft.BusinessEntities.Business.Opening;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.DataAccess.IEntitiesDao.Opening
{
    public interface IOpeningSupplyEntryDao
    {
        OpeningSupplyEntryEntity GetOpeningSupplyEntrybyRefId(long refId);
        OpeningSupplyEntryEntity GetOpeningSupplyEntrybyRefNo(string refNo);
        List<OpeningSupplyEntryEntity> GetOpeningSupplyEntry();
        List<OpeningSupplyEntryEntity> GetOpeningSupplyEntrysByRefTypeId(int refTypeId);
        long InsertOpeningSupplyEntry(OpeningSupplyEntryEntity openingCommitment);
        string UpdateOpeningSupplyEntry(OpeningSupplyEntryEntity openingCommitment);
        string DeleteOpeningSupplyEntry(OpeningSupplyEntryEntity openingCommitment);
        string DeleteOpeningSupplyEntry(long refId);
        string DeleteOpeningSupplyEntries();
    }
}
