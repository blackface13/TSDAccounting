/***********************************************************************
 * <copyright file="FixedAssetFacade.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Thursday, February 27, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Globalization;
using System.Linq;
using System.Transactions;
using TSD.AccountingSoft.BusinessComponents.Messages.Dictionary;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.Dictionary;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary;


namespace TSD.AccountingSoft.BusinessComponents.Facade.Dictionary
{
    /// <summary>
    /// Class FixedAssetFacade.
    /// </summary>
    public class FixedAssetFacade
    {
        private static readonly IFixedAssetDao FixedAssetDao = DataAccess.DataAccess.FixedAssetDao;
        private static readonly IFixedAssetCurrencyDao FixedAssetCurrencyDao = DataAccess.DataAccess.FixedAssetCurrencyDao;
        private static readonly IAutoNumberDao AutoNumberDao = DataAccess.DataAccess.AutoNumberDao;
        private static readonly IFixedAssetAccessaryDao FixedAssetAccessaryDao = DataAccess.DataAccess.FixedAssetAccessaryDao;
        /// <summary>
        /// Gets the fixed assets.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public FixedAssetResponse GetFixedAssets(FixedAssetRequest request)
        {
            var response = new FixedAssetResponse();

            if (request.LoadOptions.Contains("FixedAssets"))
            {
                if (request.LoadOptions.Contains("IsActive") && request.LoadOptions.Length < 3)
                    response.FixedAssets = FixedAssetDao.GetFixedAssetsByActive(request.IsActive);
                else if (request.LoadOptions.Contains("IsActive") && request.LoadOptions.Contains("IncludingFixedAssetCurrency"))
                {
                    response.FixedAssets = FixedAssetDao.GetFixedAssetsByActive(request.IsActive);

                    foreach (FixedAssetEntity t in response.FixedAssets)
                    {
                        t.FixedAssetCurrencies = FixedAssetCurrencyDao.GetFixedAssetCurrencysByFixedAssetId(t.FixedAssetId);
                        t.FixedAssetAccessarys = FixedAssetAccessaryDao.GetFixedAssetAccessarysByFixedAssetId(t.FixedAssetId);
                    }
                }
                else
                    response.FixedAssets = FixedAssetDao.GetAllFixedAssetsWithStoreProdure(request.StoreProdure);

            }

            if (request.LoadOptions.Contains("FixedAsset"))
            {
                response.FixedAsset = FixedAssetDao.GetFixedAsset(request.FixedAssetId);
                if (request.LoadOptions.Contains("IncludeFixedAssetCurrency"))
                {
                    if (response.FixedAsset == null)
                        response.FixedAsset = new FixedAssetEntity();
                    response.FixedAsset.FixedAssetCurrencies = FixedAssetCurrencyDao.GetFixedAssetCurrencysByFixedAssetId(request.FixedAssetId);
                    response.FixedAsset.FixedAssetAccessarys = FixedAssetAccessaryDao.GetFixedAssetAccessarysByFixedAssetId(request.FixedAssetId);

                }

                if (request.LoadOptions.Contains("FixedAssetCode"))
                {
                    response.FixedAsset = FixedAssetDao.GetFixedAssetByCode(request.FixedAssetCode);
                    if (response.FixedAsset != null)
                    {
                        response.FixedAsset.FixedAssetCurrencies = FixedAssetCurrencyDao.GetFixedAssetCurrencysByFixedAssetId(response.FixedAsset.FixedAssetId);
                        response.FixedAsset.FixedAssetAccessarys = FixedAssetAccessaryDao.GetFixedAssetAccessarysByFixedAssetId(response.FixedAsset.FixedAssetId);
                    }
                }

                if (request.LoadOptions.Contains("RemainingQuantity"))
                {
                    response.FixedAsset = FixedAssetDao.GetFixedAssetRemainingQuantity(request.FixedAssetId);
                }

                if (request.LoadOptions.Contains("CheckFAFixedAssetIncrement"))
                {
                    response.FixedAsset = FixedAssetDao.GetFixedAssetOnFixedAssetIncrement(request.FixedAssetId);
                }

                if (request.LoadOptions.Contains("GetFADecrement"))
                {
                    response.FixedAsset = FixedAssetDao.GetFixedAssetDecrement(request.FixedAssetId, request.CurrencyCode, request.PostedDate);
                }
                if (request.LoadOptions.Contains("GetFADecrementQuantity"))
                {
                    response.FixedAsset = FixedAssetDao.GetFixedAssetDecrement(request.FixedAssetId, request.CurrencyCode, request.RefTypeId);
                }
                if (request.LoadOptions.Contains("CheckFADecrement"))
                {
                    response.FixedAsset = FixedAssetDao.GetFixedAssetDecrement(request.FixedAssetId, request.RefTypeId);
                }
                if (request.LoadOptions.Contains("CheckOpening"))
                {
                    response.FixedAsset = FixedAssetDao.GetFixedAssetOpening(request.FixedAssetId);
                }
            }

            return response;
        }

        /// <summary>
        /// Sets the fixed assets.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public FixedAssetResponse SetFixedAssets(FixedAssetRequest request)
        {
            var response = new FixedAssetResponse();

            var fixedAssetEntity = request.FixedAsset;
            if (request.Action != PersistType.Delete)
            {
                if (!fixedAssetEntity.Validate())
                {
                    foreach (var error in fixedAssetEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
            }

            try
            {
                switch (request.Action)
                {
                    case PersistType.Insert:
                        var fixedAssetCode = fixedAssetEntity.FixedAssetCode;
                        var fixedAssetName = fixedAssetEntity.FixedAssetName;
                        var autoNumber = AutoNumberDao.GetAutoNumberByRefType(10);
                        string lengthOfValueInsert = null;
                        for (int i = 0; i < request.Replication + 1; i++)
                        {
                            using (var scope = new TransactionScope())
                            {
                                if (i == 0)
                                {
                                    fixedAssetEntity.FixedAssetCode = fixedAssetEntity.FixedAssetCode;
                                }
                                if (i != 0)
                                {
                                    //fixedAssetEntity.FixedAssetCode = "0" + autoNumber.Value;
                                    for (int a = 0; a < (autoNumber.LengthOfValue - autoNumber.Value.ToString(CultureInfo.InvariantCulture).Length); a++)
                                        lengthOfValueInsert += "0";
                                    fixedAssetEntity.FixedAssetCode = lengthOfValueInsert + autoNumber.Value;
                                    fixedAssetEntity.FixedAssetName = fixedAssetName + "(" + i + ")";
                                }
                                var fixedAssetByCode = FixedAssetDao.GetFixedAssetsByCode(fixedAssetEntity.FixedAssetCode);
                                if (fixedAssetByCode.Count != 0)
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    response.Message = @"Mã tài sản " + fixedAssetEntity.FixedAssetCode + @" đã tồn tại !";
                                    return response;
                                }

                                if (fixedAssetEntity.FixedAssetCurrencies.Count > 1)
                                    fixedAssetEntity.Quantity = 1;

                                if (fixedAssetEntity.FixedAssetCurrencies.Count == 2)
                                {
                                    decimal sum1 = 0;
                                    decimal sum2 = 0;
                                    foreach (var fixedAssetCurrency in fixedAssetEntity.FixedAssetCurrencies)
                                    {
                                        if (fixedAssetCurrency.CurrencyCode != "USD")
                                            sum1 = fixedAssetCurrency.OrgPriceUSD;
                                        else
                                        {
                                            sum2 = fixedAssetCurrency.OrgPrice;
                                        }
                                    }
                                    fixedAssetEntity.OrgPrice = sum1 + sum2;
                                }
                                else if (fixedAssetEntity.FixedAssetCurrencies.Count == 1)
                                {
                                    foreach (var fixedAssetCurrency in fixedAssetEntity.FixedAssetCurrencies)
                                    {
                                        if (fixedAssetCurrency.CurrencyCode != "USD")
                                            fixedAssetEntity.OrgPrice = fixedAssetCurrency.OrgPrice;
                                        else
                                            fixedAssetEntity.OrgPrice = fixedAssetCurrency.OrgPrice;
                                    }
                                }
                                else
                                {
                                    foreach (var fixedAssetCurrency in fixedAssetEntity.FixedAssetCurrencies)
                                    {
                                        fixedAssetEntity.OrgPrice = fixedAssetCurrency.OrgPrice;
                                    }
                                }

                                fixedAssetEntity.FixedAssetId = FixedAssetDao.InsertFixedAsset(fixedAssetEntity);
                                if (fixedAssetEntity.FixedAssetId <= 0)
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    scope.Dispose();
                                    return response;
                                }

                                if (fixedAssetEntity.FixedAssetCurrencies != null && fixedAssetEntity.FixedAssetCurrencies.Count > 0)
                                {
                                    foreach (var fixedAssetCurrency in fixedAssetEntity.FixedAssetCurrencies)
                                    {
                                        if (!fixedAssetCurrency.Validate())
                                        {
                                            foreach (string error in fixedAssetCurrency.ValidationErrors)
                                                response.Message += error + Environment.NewLine;
                                            response.Acknowledge = AcknowledgeType.Failure;
                                            return response;
                                        }
                                        fixedAssetCurrency.FixedAssetId = fixedAssetEntity.FixedAssetId;
                                        fixedAssetCurrency.FixedAssetCurrencyId = FixedAssetCurrencyDao.InsertFixedAssetCurrency(fixedAssetCurrency);
                                        if (fixedAssetCurrency.FixedAssetCurrencyId > 0) continue;
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        scope.Dispose();
                                        return response;
                                    }
                                }

                                if (fixedAssetEntity.FixedAssetAccessarys != null && fixedAssetEntity.FixedAssetAccessarys.Count > 0)
                                {
                                    foreach (var fixedAssetAccessary in fixedAssetEntity.FixedAssetAccessarys)
                                    {
                                        if (!fixedAssetAccessary.Validate())
                                        {
                                            foreach (string error in fixedAssetAccessary.ValidationErrors)
                                                response.Message += error + Environment.NewLine;
                                            response.Acknowledge = AcknowledgeType.Failure;
                                            return response;
                                        }
                                        fixedAssetAccessary.FixedAssetId = fixedAssetEntity.FixedAssetId;
                                        fixedAssetAccessary.FixedAssetAccessaryId = FixedAssetAccessaryDao.InsertFixedAssetAccessary(fixedAssetAccessary);
                                        if (fixedAssetAccessary.FixedAssetAccessaryId > 0) continue;
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        scope.Dispose();
                                        return response;
                                    }
                                }

                                autoNumber.Value += 1;
                                response.Message = AutoNumberDao.UpdateAutoNumber(autoNumber);
                                if (response.Message != null)
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    scope.Dispose();
                                    return response;
                                }

                                scope.Complete();
                            }
                        }

                        break;
                    case PersistType.Update:
                        var fixedAssetCodeUpdate = fixedAssetEntity.FixedAssetCode;
                        var fixedAssetNameUpdate = fixedAssetEntity.FixedAssetName;
                        var autoNumberUpdate = AutoNumberDao.GetAutoNumberByRefType(10);
                        string lengthOfValue = null;
                        int valueLocalCurency;
                        for (int i = 0; i < request.Replication + 1; i++)
                        {
                            using (var scope = new TransactionScope())
                            {
                                if (i == 0)
                                {
                                    //delete FixedAssetCurrency
                                    response.Message = FixedAssetCurrencyDao.DeleteFixedAssetCurrencyByFixedAssetId(fixedAssetEntity.FixedAssetId);
                                    if (response.Message != null)
                                    {
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        scope.Dispose();
                                        return response;
                                    }

                                    if (fixedAssetEntity.FixedAssetCurrencies.Count == 2)
                                    {
                                        decimal sum1 = 0;
                                        decimal sum2 = 0;
                                        foreach (var fixedAssetCurrency in fixedAssetEntity.FixedAssetCurrencies)
                                        {
                                            if (fixedAssetCurrency.CurrencyCode != "USD")
                                                sum1 = fixedAssetCurrency.OrgPriceUSD;
                                            else
                                            {
                                                sum2 = fixedAssetCurrency.OrgPrice;
                                            }
                                        }
                                        fixedAssetEntity.OrgPrice = sum1 + sum2;
                                    }
                                    else if (fixedAssetEntity.FixedAssetCurrencies.Count == 1)
                                    {
                                        foreach (var fixedAssetCurrency in fixedAssetEntity.FixedAssetCurrencies)
                                        {
                                            if (fixedAssetCurrency.CurrencyCode != "USD")
                                                fixedAssetEntity.OrgPrice = fixedAssetCurrency.OrgPrice;
                                            else
                                                fixedAssetEntity.OrgPrice = fixedAssetCurrency.OrgPrice;
                                        }
                                    }
                                    else
                                    {
                                        foreach (var fixedAssetCurrency in fixedAssetEntity.FixedAssetCurrencies)
                                        {
                                            fixedAssetEntity.OrgPrice = fixedAssetCurrency.OrgPrice;
                                        }
                                    }

                                    response.Message = FixedAssetAccessaryDao.DeleteFixedAssetAccessaryByFixedAssetId(fixedAssetEntity.FixedAssetId);
                                    if (response.Message != null)
                                    {
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        scope.Dispose();
                                        return response;
                                    }

                                    response.Message = FixedAssetDao.UpdateFixedAsset(fixedAssetEntity);
                                    if (response.Message != null)
                                    {
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        scope.Dispose();
                                        return response;
                                    }

                                    foreach (var fixedAssetCurrency in fixedAssetEntity.FixedAssetCurrencies)
                                    {
                                        if (!fixedAssetCurrency.Validate())
                                        {
                                            foreach (var error in fixedAssetCurrency.ValidationErrors)
                                                response.Message += error + Environment.NewLine;
                                            response.Acknowledge = AcknowledgeType.Failure;
                                            return response;
                                        }
                                        fixedAssetCurrency.FixedAssetId = fixedAssetEntity.FixedAssetId;
                                        fixedAssetCurrency.FixedAssetCurrencyId = FixedAssetCurrencyDao.InsertFixedAssetCurrency(fixedAssetCurrency);
                                        if (fixedAssetCurrency.FixedAssetCurrencyId > 0) continue;
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        scope.Dispose();
                                        return response;
                                    }

                                    if (fixedAssetEntity.FixedAssetAccessarys != null && fixedAssetEntity.FixedAssetAccessarys.Count > 0)
                                    {
                                        foreach (var fixedAssetAccessary in fixedAssetEntity.FixedAssetAccessarys)
                                        {
                                            if (!fixedAssetAccessary.Validate())
                                            {
                                                foreach (string error in fixedAssetAccessary.ValidationErrors)
                                                    response.Message += error + Environment.NewLine;
                                                response.Acknowledge = AcknowledgeType.Failure;
                                                return response;
                                            }
                                            fixedAssetAccessary.FixedAssetId = fixedAssetEntity.FixedAssetId;
                                            fixedAssetAccessary.FixedAssetAccessaryId = FixedAssetAccessaryDao.InsertFixedAssetAccessary(fixedAssetAccessary);
                                            if (fixedAssetAccessary.FixedAssetAccessaryId > 0) continue;
                                            response.Acknowledge = AcknowledgeType.Failure;
                                            scope.Dispose();
                                            return response;
                                        }
                                    }

                                    scope.Complete();
                                }
                                if (i != 0)
                                {
                                    lengthOfValue = "";
                                    for (int a = 0; a < (autoNumberUpdate.LengthOfValue - autoNumberUpdate.Value.ToString(CultureInfo.InvariantCulture).Length); a++)
                                        lengthOfValue += "0";
                                    fixedAssetEntity.FixedAssetCode = (autoNumberUpdate.Prefix == null ? string.Empty : autoNumberUpdate.Prefix) + lengthOfValue + autoNumberUpdate.Value + (autoNumberUpdate.Suffix == null ? string.Empty : autoNumberUpdate.Suffix);

                                    fixedAssetEntity.FixedAssetName = fixedAssetNameUpdate + "(" + i + ")";
                                    var fixedAssetByCode = FixedAssetDao.GetFixedAssetsByCode(fixedAssetEntity.FixedAssetCode);
                                    if (fixedAssetByCode.Count != 0)
                                    {
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        response.Message = @"Mã tài sản " + fixedAssetEntity.FixedAssetCode + @" đã tồn tại !";
                                        return response;
                                    }
                                    if (fixedAssetEntity.FixedAssetCurrencies.Count > 1)
                                        fixedAssetEntity.Quantity = 1;
                                    if (fixedAssetEntity.FixedAssetCurrencies.Count == 2)
                                    {
                                        decimal sum1 = 0;
                                        decimal sum2 = 0;
                                        foreach (var fixedAssetCurrency in fixedAssetEntity.FixedAssetCurrencies)
                                        {

                                            if (fixedAssetCurrency.CurrencyCode != "USD")
                                                sum1 = fixedAssetCurrency.OrgPriceUSD;
                                            else
                                            {
                                                sum2 = fixedAssetCurrency.OrgPrice;
                                            }

                                        }
                                        fixedAssetEntity.OrgPriceUSD = sum1 + sum2;
                                    }
                                    else if (fixedAssetEntity.FixedAssetCurrencies.Count == 1)
                                    {
                                        foreach (var fixedAssetCurrency in fixedAssetEntity.FixedAssetCurrencies)
                                        {
                                            if (fixedAssetCurrency.CurrencyCode != "USD")
                                                fixedAssetEntity.OrgPriceUSD = fixedAssetCurrency.OrgPrice;
                                            else
                                                fixedAssetEntity.OrgPriceUSD = fixedAssetCurrency.OrgPrice;
                                        }
                                    }
                                    else
                                    {
                                        foreach (var fixedAssetCurrency in fixedAssetEntity.FixedAssetCurrencies)
                                        {
                                            fixedAssetEntity.OrgPriceUSD = fixedAssetCurrency.OrgPrice;
                                        }
                                    }

                                    fixedAssetEntity.FixedAssetId = FixedAssetDao.InsertFixedAsset(fixedAssetEntity);
                                    if (fixedAssetEntity.FixedAssetId <= 0)
                                    {
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        scope.Dispose();
                                        return response;
                                    }

                                    foreach (var fixedAssetCurrency in fixedAssetEntity.FixedAssetCurrencies)
                                    {
                                        if (!fixedAssetCurrency.Validate())
                                        {
                                            foreach (string error in fixedAssetCurrency.ValidationErrors)
                                                response.Message += error + Environment.NewLine;
                                            response.Acknowledge = AcknowledgeType.Failure;
                                            return response;
                                        }
                                        fixedAssetCurrency.FixedAssetId = fixedAssetEntity.FixedAssetId;
                                        fixedAssetCurrency.FixedAssetCurrencyId = FixedAssetCurrencyDao.InsertFixedAssetCurrency(fixedAssetCurrency);
                                        if (fixedAssetCurrency.FixedAssetCurrencyId > 0) continue;
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        scope.Dispose();
                                        return response;
                                    }

                                    if (fixedAssetEntity.FixedAssetAccessarys != null && fixedAssetEntity.FixedAssetAccessarys.Count > 0)
                                    {
                                        foreach (var fixedAssetAccessary in fixedAssetEntity.FixedAssetAccessarys)
                                        {
                                            if (!fixedAssetAccessary.Validate())
                                            {
                                                foreach (string error in fixedAssetAccessary.ValidationErrors)
                                                    response.Message += error + Environment.NewLine;
                                                response.Acknowledge = AcknowledgeType.Failure;
                                                return response;
                                            }
                                            fixedAssetAccessary.FixedAssetId = fixedAssetEntity.FixedAssetId;
                                            fixedAssetAccessary.FixedAssetAccessaryId = FixedAssetAccessaryDao.InsertFixedAssetAccessary(fixedAssetAccessary);
                                            if (fixedAssetAccessary.FixedAssetAccessaryId > 0) continue;
                                            response.Acknowledge = AcknowledgeType.Failure;
                                            scope.Dispose();
                                            return response;
                                        }
                                    }

                                    //response.Message = null;
                                    autoNumberUpdate.Value += 1;
                                    response.Message = AutoNumberDao.UpdateAutoNumber(autoNumberUpdate);
                                    if (response.Message != null)
                                    {
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        scope.Dispose();
                                        return response;
                                    }
                                    scope.Complete();

                                }
                            }
                        }
                        break;
                    case PersistType.Delete:
                        var accountEntityForDelete = FixedAssetDao.GetFixedAsset(request.FixedAssetId);
                        response.Message = FixedAssetDao.DeleteFixedAsset(accountEntityForDelete);
                        break;
                }
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }

            response.FixedAssetId = fixedAssetEntity != null ? fixedAssetEntity.FixedAssetId : 0;
            response.Acknowledge = response.Message != null ? AcknowledgeType.Failure : AcknowledgeType.Success;
            return response;
        }
    }
}