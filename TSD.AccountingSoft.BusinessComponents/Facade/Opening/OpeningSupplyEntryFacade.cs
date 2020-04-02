/***********************************************************************
 * <copyright file="OpeningSupplyEntryFacade.cs" company="BUCA JSC">
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

using TSD.AccountingSoft.BusinessComponents.Message;
using TSD.AccountingSoft.BusinessComponents.Message.Opening;
using TSD.AccountingSoft.BusinessEntities.Business.Opening;
using TSD.AccountingSoft.DataAccess.IEntitiesDao;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Opening;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.Business;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary;

namespace TSD.AccountingSoft.BusinessComponents.Facade.Opening
{
    public class OpeningSupplyEntryFacade
    {
        private static readonly IOpeningSupplyEntryDao OpeningSupplyEntryDao = DataAccess.DataAccess.OpeningSupplyEntryDao;
        private static readonly ISupplyLedgerDao SupplyLedgerDao = DataAccess.DataAccess.SupplyLedgerDao;
        private static readonly IInventoryItemDao InventoryItemDao = DataAccess.DataAccess.InventoryItemDao;

        public OpeningSupplyEntryEntity GetOpeningSupplyEntrybyRefId(long refId)
        {
            return OpeningSupplyEntryDao.GetOpeningSupplyEntrybyRefId(refId);
        }

        public OpeningSupplyEntryEntity GetOpeningSupplyEntryVoucherByRefId(long refId, bool isIncludedOpeningSupplyEntryDetail)
        {
            var openingSupplyEntry = OpeningSupplyEntryDao.GetOpeningSupplyEntrybyRefId(refId);
            return openingSupplyEntry;
        }

        public IList<OpeningSupplyEntryEntity> GetOpeningSupplyEntry()
        {
            return OpeningSupplyEntryDao.GetOpeningSupplyEntry();
        }

        public List<OpeningSupplyEntryEntity> GetOpeningSupplyEntrysByRefTypeId(int refTypeId)
        {
            return OpeningSupplyEntryDao.GetOpeningSupplyEntrysByRefTypeId(refTypeId);
        }

        public OpeningSupplyEntryResponse UpdateOpeningSupplyEntry(IList<OpeningSupplyEntryEntity> openingSupplyEntries)
        {
            var openingSupplyEntryResponse = new OpeningSupplyEntryResponse { Acknowledge = AcknowledgeType.Success };
            using (var scope = new TransactionScope())
            {
                #region Delete Opening & SupplyLedger

                openingSupplyEntryResponse.Message = OpeningSupplyEntryDao.DeleteOpeningSupplyEntries();
                if (openingSupplyEntryResponse.Message != null)
                {
                    openingSupplyEntryResponse.Acknowledge = AcknowledgeType.Failure;
                    scope.Dispose();
                    return openingSupplyEntryResponse;
                }

                openingSupplyEntryResponse.Message = SupplyLedgerDao.DeleteSupplyLedgerByOPN();
                if (openingSupplyEntryResponse.Message != null)
                {
                    openingSupplyEntryResponse.Acknowledge = AcknowledgeType.Failure;
                    scope.Dispose();
                    return openingSupplyEntryResponse;
                }

                #endregion

                #region Insert Opening & SupplyLedger

                if (openingSupplyEntries != null)
                {
                    foreach (var opening in openingSupplyEntries)
                    {
                        if (!opening.Validate())
                        {
                            foreach (string error in opening.ValidationErrors)
                                openingSupplyEntryResponse.Message += error + Environment.NewLine;
                            openingSupplyEntryResponse.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return openingSupplyEntryResponse;
                        }

                        opening.RefId = OpeningSupplyEntryDao.InsertOpeningSupplyEntry(opening);
                        if(opening.RefId <= 0)
                        {
                            openingSupplyEntryResponse.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return openingSupplyEntryResponse;
                        }

                        var supplyLedger = MakeSupplyLedger(opening);
                        openingSupplyEntryResponse.RefId = SupplyLedgerDao.InsertSupplyLedger(supplyLedger);
                        if (!string.IsNullOrEmpty(openingSupplyEntryResponse.Message))
                        {
                            openingSupplyEntryResponse.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return openingSupplyEntryResponse;
                        }
                    }
                }

                #endregion

                scope.Complete();
            }
            return openingSupplyEntryResponse;
        }

        public OpeningSupplyEntryResponse DeleteOpeningSupplyEntry(long refId)
        {
            var openingSupplyEntryResponse = new OpeningSupplyEntryResponse { Acknowledge = AcknowledgeType.Success };
            using (var scope = new TransactionScope())
            {
                var openingSupplyEntryForDelete = OpeningSupplyEntryDao.GetOpeningSupplyEntrybyRefId(refId);


                openingSupplyEntryResponse.Message = OpeningSupplyEntryDao.DeleteOpeningSupplyEntry(openingSupplyEntryForDelete);
                if (openingSupplyEntryResponse.Message != null)
                {
                    openingSupplyEntryResponse.Acknowledge = AcknowledgeType.Failure;
                    scope.Dispose();
                    return openingSupplyEntryResponse;
                }

                #region Xóa bảng SupplyLedger

                openingSupplyEntryResponse.Message = SupplyLedgerDao.DeleteSupplyLedgerByRefId(openingSupplyEntryForDelete.RefId, openingSupplyEntryForDelete.RefType);
                if (openingSupplyEntryResponse.Message != null)
                {
                    openingSupplyEntryResponse.Acknowledge = AcknowledgeType.Failure;
                    scope.Dispose();
                    return openingSupplyEntryResponse;
                }
                    
                #endregion

                scope.Complete();
            }

            return openingSupplyEntryResponse;
        }

        private SupplyLedgerEntity MakeSupplyLedger(OpeningSupplyEntryEntity openingSupplyEntry)
        {
            var result = new SupplyLedgerEntity();
            result.SupplyLedgerId = 0;
            result.RefId = openingSupplyEntry.RefId;
            result.RefDetailId = 0;
            result.RefType = openingSupplyEntry.RefType;
            result.RefNo = "OPN";
            result.RefDate = openingSupplyEntry.RefDate;
            result.PostedDate = openingSupplyEntry.PostedDate;
            result.Description = null;
            result.JournalMemo = null;
            result.InventoryItemId = openingSupplyEntry.InventoryItemId;
            result.DepartmentId = openingSupplyEntry.DepartmentId;
            result.CurrencyCode = openingSupplyEntry.CurrencyCode;
            result.ExchangeRate = openingSupplyEntry.ExchangeRate;
            result.Unit = InventoryItemDao.GetInventoryItem(openingSupplyEntry.InventoryItemId)?.Unit ?? null;
            result.Quantity = openingSupplyEntry.Quantity;
            result.UnitPriceOc = openingSupplyEntry.UnitPriceOc;
            result.UnitPriceExchange = openingSupplyEntry.UnitPriceExchange;
            result.AmountOc = openingSupplyEntry.AmountOc;
            result.AmountExchange = openingSupplyEntry.AmountExchange;
            return result;
        }
    }
}
