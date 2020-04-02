using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessComponents.Messages.Tool;
using TSD.AccountingSoft.BusinessEntities.Business;
using TSD.AccountingSoft.BusinessEntities.Business.Tool;
using TSD.AccountingSoft.DataAccess.IEntitiesDao;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace TSD.AccountingSoft.BusinessComponents.Facade.Tool
{
    public class SUIncrementDecrementFacade
    {
        private static readonly ISUIncrementDecrementDao SUIncrementDecrementDao = DataAccess.DataAccess.SUIncrementDecrementDao;
        private static readonly ISUIncrementDecrementDetailDao SUIncrementDecrementDetailDao = DataAccess.DataAccess.SUIncrementDecrementDetailDao;
        private static readonly IAutoNumberDao AutoNumberDao = DataAccess.DataAccess.AutoNumberDao; 
        private static readonly ISupplyLedgerDao SupplyLedgerDao = DataAccess.DataAccess.SupplyLedgerDao;
        private static readonly IInventoryItemDao InventoryItemDao = DataAccess.DataAccess.InventoryItemDao;


        public List<SUIncrementDecrementEntity> GetSUIncrementDecrements()
        {
            return SUIncrementDecrementDao.GetSUIncrementDecrements();
        }

        public List<SUIncrementDecrementEntity> GetSUIncrementDecrementsByRefTypeId(int refTypeId)
        {
            return SUIncrementDecrementDao.GetSUIncrementDecrementsByRefTypeId(refTypeId);
        }

        public List<SUIncrementDecrementEntity> GetSUIncrementDecrementsByRefTypeId(int refTypeId, DateTime refDate)
        {
            return SUIncrementDecrementDao.GetSUIncrementDecrementsByYearOfRefDate(refTypeId, (short)refDate.Year);
        }

        public SUIncrementDecrementEntity GetSUIncrementDecrementByRefNo(string refNo, bool hasDetail)
        {
            var sUIncrementDecrement = SUIncrementDecrementDao.GetSUIncrementDecrementByRefNo(refNo);
            if (sUIncrementDecrement == null)
                return null;
            if (hasDetail)
                sUIncrementDecrement.SUIncrementDecrementDetails =
                    SUIncrementDecrementDetailDao.GetSUIncrementDecrementDetailsByRefId(sUIncrementDecrement.RefId);
            return sUIncrementDecrement;
        }

        public SUIncrementDecrementEntity GetSUIncrementDecrementByRefId(long refId, bool hasDetail)
        {
            var sUIncrementDecrement = SUIncrementDecrementDao.GetSUIncrementDecrement(refId);
            if (sUIncrementDecrement == null)
                return null;
            if (hasDetail)
                sUIncrementDecrement.SUIncrementDecrementDetails =
                    SUIncrementDecrementDetailDao.GetSUIncrementDecrementDetailsByRefId(sUIncrementDecrement.RefId);
            return sUIncrementDecrement;
        }

        public decimal GetSUIncrementDecrementQuantity(string currencyCode, int inventoryItemId, int departmentId, long refId, DateTime postedDate)
        {
            return SUIncrementDecrementDao.GetSUIncrementDecrementQuantity(currencyCode, inventoryItemId, departmentId, refId, postedDate);
        }

        public SUIncrementDecrementResponse InsertSUIncrementDecrement(SUIncrementDecrementEntity sUIncrementDecrementEntity, bool isconvertDB)
        {
            var response = new SUIncrementDecrementResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!sUIncrementDecrementEntity.Validate())
                {
                    foreach (var error in sUIncrementDecrementEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                using (var scope = new TransactionScope())
                {
                    var sUIncrementDecrementByRefNo = SUIncrementDecrementDao.GetSUIncrementDecrementByRefNo(sUIncrementDecrementEntity.RefNo, sUIncrementDecrementEntity.PostedDate);
                    if (sUIncrementDecrementByRefNo != null && sUIncrementDecrementByRefNo.PostedDate.Year == sUIncrementDecrementEntity.PostedDate.Year)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        response.Message = "Mã chứng từ đã tồn tại!";
                        return response;
                    }
                    sUIncrementDecrementEntity.RefId = SUIncrementDecrementDao.InsertSUIncrementDecrement(sUIncrementDecrementEntity);
                    if (sUIncrementDecrementEntity.RefId <= 0)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }

                    #region Insert Detail & SupplyLedger

                    if (sUIncrementDecrementEntity.SUIncrementDecrementDetails != null)
                        foreach (var sUIncrementDecrementDetailEntity in sUIncrementDecrementEntity.SUIncrementDecrementDetails)
                        {
                            sUIncrementDecrementDetailEntity.RefId = sUIncrementDecrementEntity.RefId;
                            sUIncrementDecrementDetailEntity.RefDetailId = SUIncrementDecrementDetailDao.InsertSUIncrementDecrementDetail(sUIncrementDecrementDetailEntity);
                            if (sUIncrementDecrementDetailEntity.RefDetailId <= 0)
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }

                            var supplyLedgerEntity = MakeSupplyLedger(sUIncrementDecrementEntity, sUIncrementDecrementDetailEntity);
                            supplyLedgerEntity.SupplyLedgerId = SupplyLedgerDao.InsertSupplyLedger(supplyLedgerEntity);
                            if (supplyLedgerEntity.SupplyLedgerId <= 0)
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }
                        }

                    #endregion

                    #region Auto Number

                    var autoNumber = AutoNumberDao.GetAutoNumberByRefType(sUIncrementDecrementEntity.RefType);
                    if (sUIncrementDecrementEntity.CurrencyCode == "USD")
                        autoNumber.Value += 1;
                    else autoNumber.ValueLocalCurency += 1;

                    response.Message = AutoNumberDao.UpdateAutoNumber(autoNumber);
                    if (response.Message != null)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return response;
                    }

                    #endregion

                    scope.Complete();
                }
                response.RefId = sUIncrementDecrementEntity.RefId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }

        public SUIncrementDecrementResponse UpdateSUIncrementDecrement(SUIncrementDecrementEntity sUIncrementDecrementEntity)
        {
            var response = new SUIncrementDecrementResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!sUIncrementDecrementEntity.Validate())
                {
                    foreach (var error in sUIncrementDecrementEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                using (var scope = new TransactionScope())
                {
                    var sUIncrementDecrementByRefNo = SUIncrementDecrementDao.GetSUIncrementDecrementByRefNo(sUIncrementDecrementEntity.RefNo, sUIncrementDecrementEntity.PostedDate);
                    if (sUIncrementDecrementByRefNo != null && sUIncrementDecrementByRefNo.RefId != sUIncrementDecrementEntity.RefId)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        response.Message = "Mã chứng từ đã tồn tại!";
                        return response;
                    }
                    response.Message = SUIncrementDecrementDao.UpdateSUIncrementDecrement(sUIncrementDecrementEntity);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }

                    #region Delete Detail & SupplyLedger

                    response.Message = SUIncrementDecrementDetailDao.DeleteSUIncrementDecrementDetailByRefId(sUIncrementDecrementEntity.RefId);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }

                    response.Message = SupplyLedgerDao.DeleteSupplyLedgerByRefId(sUIncrementDecrementEntity.RefId, sUIncrementDecrementEntity.RefType);
                    if (response.Message != null)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return response;
                    }

                    #endregion

                    #region Insert Detail & SupplyLedger

                    if (sUIncrementDecrementEntity.SUIncrementDecrementDetails != null)
                        foreach (var sUIncrementDecrementDetailEntity in sUIncrementDecrementEntity.SUIncrementDecrementDetails)
                        {
                            sUIncrementDecrementDetailEntity.RefId = sUIncrementDecrementEntity.RefId;
                            sUIncrementDecrementDetailEntity.RefDetailId = SUIncrementDecrementDetailDao.InsertSUIncrementDecrementDetail(sUIncrementDecrementDetailEntity);
                            if (!string.IsNullOrEmpty(response.Message))
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }

                            var supplyLedgerEntity = MakeSupplyLedger(sUIncrementDecrementEntity, sUIncrementDecrementDetailEntity);
                            supplyLedgerEntity.SupplyLedgerId = SupplyLedgerDao.InsertSupplyLedger(supplyLedgerEntity);
                            if (supplyLedgerEntity.SupplyLedgerId <= 0)
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }
                        }

                    #endregion

                    scope.Complete();
                }
                response.RefId = sUIncrementDecrementEntity.RefId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }

        public SUIncrementDecrementResponse DeleteSUIncrementDecrement(long sUIncrementDecrementId)
        {
            var response = new SUIncrementDecrementResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                var sUIncrementDecrementEntity = SUIncrementDecrementDao.GetSUIncrementDecrement(sUIncrementDecrementId);
                if (sUIncrementDecrementEntity == null)
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = "Dữ liệu cần xóa không tồn tại!";
                    return response;
                }
                using (var scope = new TransactionScope())
                {
                    #region Delete SUIncrementDecrement

                    response.Message = SUIncrementDecrementDao.DeleteSUIncrementDecrement(sUIncrementDecrementEntity);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }

                    #endregion

                    #region Delete  SupplyLedger

                    response.Message = SupplyLedgerDao.DeleteSupplyLedgerByRefId(sUIncrementDecrementEntity.RefId, sUIncrementDecrementEntity.RefType);
                    if (response.Message != null)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return response;
                    }

                    #endregion

                    scope.Complete();
                }
                response.RefId = sUIncrementDecrementEntity.RefId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }


        private SupplyLedgerEntity MakeSupplyLedger(SUIncrementDecrementEntity suIncrementDecrement, SUIncrementDecrementDetailEntity suIncrementDecrementDetail)
        {
            var result = new SupplyLedgerEntity();
            result.SupplyLedgerId = 0;
            result.RefId = suIncrementDecrement.RefId;
            result.RefDetailId = suIncrementDecrementDetail.RefDetailId;
            result.RefType = suIncrementDecrement.RefType;
            result.RefNo = suIncrementDecrement.RefNo;
            result.RefDate = suIncrementDecrement.RefDate;
            result.PostedDate = suIncrementDecrement.PostedDate;
            result.Description = suIncrementDecrementDetail.Description;
            result.JournalMemo = suIncrementDecrement.JournalMemo;
            result.InventoryItemId = suIncrementDecrementDetail.InventoryItemId;
            result.DepartmentId = suIncrementDecrementDetail.DepartmentId;
            result.CurrencyCode = suIncrementDecrement.CurrencyCode;
            result.ExchangeRate = suIncrementDecrement.ExchangeRate;
            result.Unit = InventoryItemDao.GetInventoryItem(suIncrementDecrementDetail.InventoryItemId)?.Unit ?? null;
            result.Quantity = suIncrementDecrementDetail.Quantity;
            result.UnitPriceOc = suIncrementDecrementDetail.UnitPriceOc;
            result.UnitPriceExchange = suIncrementDecrementDetail.UnitPriceExchange;
            result.AmountOc = suIncrementDecrementDetail.AmountOc;
            result.AmountExchange = suIncrementDecrementDetail.AmountExchange;
            return result;
        }
    }
}
