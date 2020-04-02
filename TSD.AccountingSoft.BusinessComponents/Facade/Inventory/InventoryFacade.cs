/***********************************************************************
 * <copyright file="InventoryFacade.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuanMH
 * Email:    TuanMH@buca.vn
 * Website:
 * Create Date: 17 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using TSD.AccountingSoft.BusinessComponents.Messages.Inventory;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.Business;
using TSD.AccountingSoft.BusinessEntities.Business.Inventory;
using TSD.AccountingSoft.BusinessEntities.Dictionary;
using TSD.AccountingSoft.DataAccess.IEntitiesDao;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Inventory;



namespace TSD.AccountingSoft.BusinessComponents.Facade.Inventory
{
    /// <summary>
    /// InventoryFacade
    /// </summary>
    public class InventoryFacade
    {
        private static readonly IItemTransactionDao ItemTransactionDao = DataAccess.DataAccess.ItemTransactionDao;
        private static readonly IItemTransactionDetailDao ItemTransactionDetailDao = DataAccess.DataAccess.ItemTransactionDetailDao;
        private static readonly IItemTransactionDetailParallelDao ItemTransactionDetailParallelDao = DataAccess.DataAccess.ItemTransactionDetailParallelDao;
        private static readonly IAutoNumberDao AutoNumberDao = DataAccess.DataAccess.AutoNumberDao;
        private static readonly IJournalEntryAccountDao JournalEntryAccountDao = DataAccess.DataAccess.JournalEntryAccountDao;
        private static readonly IAccountBalanceDao AccountBalanceDao = DataAccess.DataAccess.AccountBalanceDao;
        private static readonly IAutoBusinessParallelDao AutoBusinessParallelDao = DataAccess.DataAccess.AutoBusinessParallelDao;
        private static readonly IBudgetSourceDao BudgetSourceDao = DataAccess.DataAccess.BudgetSourceDao;
        private static readonly IBudgetItemDao BudgetItemDao = DataAccess.DataAccess.BudgetItemDao;

        public ItemTransactionResponse GetItemTransactions(ItemTransactionRequest request)
        {
            var response = new ItemTransactionResponse();
            if (request.LoadOptions.Contains("ItemTransactions"))
            {
                response.ItemTransactions = request.LoadOptions.Contains("RefType")
                                        ? ItemTransactionDao.GetItemTransactionsByRefTypeId(request.RefType)
                                        : ItemTransactionDao.GetItemTransactions();
            }
            if (request.LoadOptions.Contains("ItemTransaction"))
            {
                if (request.LoadOptions.Contains("RefNo"))
                {
                    var itemTransaction = ItemTransactionDao.GetItemTransactionByRefNo(request.RefNo);
                    if (request.LoadOptions.Contains("IncludeDetail"))
                    {
                        itemTransaction = itemTransaction ?? new ItemTransactionEntity();
                        itemTransaction.ItemTransactionDetails = ItemTransactionDetailDao.GetItemTransactionDetailsByItemTransaction(itemTransaction.RefId);
                        itemTransaction.ItemTransactionDetailParallels = ItemTransactionDetailParallelDao.GetItemTransactionDetailParallelByRefId(itemTransaction.RefId, itemTransaction.RefTypeId);
                    }
                    response.ItemTransaction = itemTransaction;
                }
                else
                {
                    var itemTransaction = ItemTransactionDao.GetItemTransaction(request.RefId);
                    if (request.LoadOptions.Contains("IncludeDetail"))
                    {
                        itemTransaction = itemTransaction ?? new ItemTransactionEntity();
                        itemTransaction.ItemTransactionDetails = ItemTransactionDetailDao.GetItemTransactionDetailsByItemTransaction(itemTransaction.RefId);
                        itemTransaction.ItemTransactionDetailParallels = ItemTransactionDetailParallelDao.GetItemTransactionDetailParallelByRefId(itemTransaction.RefId, itemTransaction.RefTypeId);
                    }
                    response.ItemTransaction = itemTransaction;
                }
            }
            if (request.LoadOptions.Contains("ItemTransactionByDate"))
            {
                var itemTransaction = ItemTransactionDao.GetItemTransactionsByDate(request.FromDateForReCalOutputStock, request.ToDateForReCalOutputStock);
                response.ItemTransactions = itemTransaction;
            }
            if (request.LoadOptions.Contains("OutputItemTransactionByDate"))
            {
                var itemTransaction = ItemTransactionDao.GetOutputItemTransactionsByDate(request.FromDateForReCalOutputStock, request.ToDateForReCalOutputStock);
                response.ItemTransactions = itemTransaction;
            }

            if (request.LoadOptions.Contains("OutputItemTransactionBArisePeriod"))
            {
                var itemTransaction = ItemTransactionDao.GetOutputItemTransactionsByArisePeriod(request.FromDateForReCalOutputStock, request.ToDateForReCalOutputStock, request.StockId, request.CurrencyCode);
                response.ItemTransactions = itemTransaction;
            }

            return response;
        }

        public ItemTransactionResponse SetItemTransactions(ItemTransactionRequest request)
        {
            var response = new ItemTransactionResponse();
            var journalEntryAccountEntity = new JournalEntryAccountEntity();
            IList<JournalEntryAccountEntity> listJournalEntryAccountEntity = new List<JournalEntryAccountEntity>();
            IList<AccountBalanceEntity> listAccountBalanceEntity = new List<AccountBalanceEntity>();
            var itemTransactionEntity = request.ItemTransaction;
            // decimal dcTotalAmount = 0;
            // decimal dcTotalAmountEx = 0;
            //if (itemTransactionEntity != null && itemTransactionEntity.ItemTransactionDetails!=null)
            // {
            //     //Làm tròn số tại đây: hiện tại hơi fix  ========================================================
            //     for (int j = 0; j < itemTransactionEntity.ItemTransactionDetails.Count(); j++)
            //     {
            //         if (itemTransactionEntity.RefTypeId ==401)
            //        {
            //             if (request.CurrencyDecimalDigits > 0) // tính giá theo kỳ
            //             {
            //                 dcTotalAmount = dcTotalAmount + Math.Round(itemTransactionEntity.ItemTransactionDetails[j].AmountOc, request.CurrencyDecimalDigits);
            //                 dcTotalAmountEx = dcTotalAmountEx + Math.Round(itemTransactionEntity.ItemTransactionDetails[j].AmountExchange, request.CurrencyDecimalDigits);
            //                 itemTransactionEntity.ItemTransactionDetails[j].AmountExchange = Math.Round(itemTransactionEntity.ItemTransactionDetails[j].AmountExchange, request.CurrencyDecimalDigits);
            //                 itemTransactionEntity.ItemTransactionDetails[j].AmountOc = Math.Round(itemTransactionEntity.ItemTransactionDetails[j].AmountOc, request.CurrencyDecimalDigits);

            //             }

            //        }
            //         else
            //         {
            //             dcTotalAmount = dcTotalAmount + itemTransactionEntity.ItemTransactionDetails[j].AmountOc;
            //             dcTotalAmountEx = dcTotalAmountEx + itemTransactionEntity.ItemTransactionDetails[j].AmountExchange;
            //         }

            //     }


            // }


            if (request.LoadOptions == null)
            {
                if (request.ItemTransaction != null)
                {
                    listJournalEntryAccountEntity = GetListJournalEntryAccount(request);
                    listAccountBalanceEntity = GetListAccountBalance(request);
                }
            }
            var i = 0;
            if (request.Action != PersistType.Delete)
            {
                if (!itemTransactionEntity.Validate())
                {
                    foreach (string error in itemTransactionEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
            }
            try
            {
                if (request.Action == PersistType.Insert)
                {
                    using (var scope = new TransactionScope())
                    {
                        itemTransactionEntity.RefId = ItemTransactionDao.InsertItemTransaction(itemTransactionEntity);
                        foreach (var itemTransactionDetail in itemTransactionEntity.ItemTransactionDetails)
                        {
                            if (!itemTransactionDetail.Validate())
                            {
                                foreach (string error in itemTransactionDetail.ValidationErrors)
                                    response.Message += error + Environment.NewLine;
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }
                            // insert bang detail
                            itemTransactionDetail.RefId = itemTransactionEntity.RefId;
                            var itemTransactionDetailId = ItemTransactionDetailDao.InsertItemTransactionDetail(itemTransactionDetail);
                            // insert bang JourentryAccount
                            journalEntryAccountEntity = listJournalEntryAccountEntity[i];
                            journalEntryAccountEntity.RefId = itemTransactionDetail.RefId;
                            journalEntryAccountEntity.RefDetailId = itemTransactionDetailId;

                            #region " obJourentryAccount: thay đổi thông tin theo đối tượng Master"
                            int accountingObjectType = itemTransactionEntity.AccountingObjectType == null ? 0 : int.Parse(itemTransactionEntity.AccountingObjectType.ToString());
                            switch (accountingObjectType)
                            {
                                case 0:
                                    journalEntryAccountEntity.VendorId = itemTransactionEntity.VendorId;
                                    break;
                                case 1:
                                    journalEntryAccountEntity.EmployeeId = itemTransactionEntity.EmployeeId;
                                    break;
                                case 2:
                                    journalEntryAccountEntity.AccountingObjectId = itemTransactionEntity.AccountingObjectId;
                                    break;
                                case 3:
                                    journalEntryAccountEntity.CustomerId = itemTransactionEntity.CustomerId;
                                    break;
                            }
                            #endregion


                            if (!journalEntryAccountEntity.Validate())
                            {
                                foreach (string error in journalEntryAccountEntity.ValidationErrors)
                                    response.Message += error + Environment.NewLine;
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }
                            JournalEntryAccountDao.InsertDoubleJournalEntryAccount(journalEntryAccountEntity);
                            i = i + 1;
                        }
                        // Kiểm tra đã tồn tại trong bảng Account Balance
                        foreach (var accountBalanceEntity in listAccountBalanceEntity)
                        {
                            var accountBalanceEntityExits = AccountBalanceDao.GetExitsAccountBalance(accountBalanceEntity);
                            if (accountBalanceEntityExits != null)
                            {
                                // cập nhật bên TK nợ
                                if (accountBalanceEntity.MovementCreditAmountOC == 0)
                                {
                                    accountBalanceEntityExits.ExchangeRate = accountBalanceEntity.ExchangeRate;
                                    accountBalanceEntityExits.MovementDebitAmountExchange = accountBalanceEntityExits.MovementDebitAmountExchange + accountBalanceEntity.MovementDebitAmountExchange;
                                    accountBalanceEntityExits.MovementDebitAmountOC = accountBalanceEntityExits.MovementDebitAmountOC + accountBalanceEntity.MovementDebitAmountOC;
                                    AccountBalanceDao.UpdateAccountBalance(accountBalanceEntityExits);
                                }
                                else
                                {
                                    accountBalanceEntityExits.ExchangeRate = accountBalanceEntity.ExchangeRate;
                                    accountBalanceEntityExits.MovementCreditAmountExchange = accountBalanceEntityExits.MovementCreditAmountExchange + accountBalanceEntity.MovementCreditAmountExchange;
                                    accountBalanceEntityExits.MovementCreditAmountOC = accountBalanceEntityExits.MovementCreditAmountOC + accountBalanceEntity.MovementCreditAmountOC;
                                    AccountBalanceDao.UpdateAccountBalance(accountBalanceEntityExits);
                                }
                            }
                            else
                            {
                                AccountBalanceDao.InsertAccountBalance(accountBalanceEntity);
                            }
                        }
                        // get autoNumer
                        var autoNumber = AutoNumberDao.GetAutoNumberByRefType(itemTransactionEntity.RefTypeId);
                        //------------------------------------------------------------------
                        //LinhMC 29/11/2014
                        //Lưu giá trị số tự động tăng theo loại tiền
                        //---------------------------------------------------------------
                        if (itemTransactionEntity.CurrencyCode == "USD")
                            autoNumber.Value += 1;
                        else autoNumber.ValueLocalCurency += 1;

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
                else if (request.Action == PersistType.Update)
                {
                    if (request.LoadOptions != null)
                    {
                        if (request.LoadOptions.Contains("ReCalOutputStock"))
                        {
                            ReCalOutputStock(request.FromDateForReCalOutputStock, request.ToDateForReCalOutputStock, request.StockId, request.CurrencyCode, request.CurrencyDecimalDigits);
                        }
                    }
                    else
                    {
                        using (var scope = new TransactionScope())
                        {
                            // Trừ số tiền khi mà update xử lý Bảng cân đối tài khoản////////////////////////////////////
                            listAccountBalanceEntity.Clear();
                            listAccountBalanceEntity = GetListAccountBalanceOlder(itemTransactionEntity.RefId);
                            foreach (var accountBalanceEntity in listAccountBalanceEntity)
                            {
                                var accountBalanceEntityExits = AccountBalanceDao.GetExitsAccountBalance(accountBalanceEntity);
                                if (accountBalanceEntityExits != null)
                                {
                                    // cập nhật bên TK nợ
                                    if (accountBalanceEntity.MovementCreditAmountOC == 0)
                                    {
                                        accountBalanceEntityExits.ExchangeRate = accountBalanceEntity.ExchangeRate;
                                        accountBalanceEntityExits.MovementDebitAmountExchange = accountBalanceEntityExits.MovementDebitAmountExchange - accountBalanceEntity.MovementDebitAmountExchange;
                                        accountBalanceEntityExits.MovementDebitAmountOC = accountBalanceEntityExits.MovementDebitAmountOC - accountBalanceEntity.MovementDebitAmountOC;
                                        AccountBalanceDao.UpdateAccountBalance(accountBalanceEntityExits);
                                    }
                                    else
                                    {
                                        accountBalanceEntityExits.ExchangeRate = accountBalanceEntity.ExchangeRate;
                                        accountBalanceEntityExits.MovementCreditAmountExchange = accountBalanceEntityExits.MovementCreditAmountExchange - accountBalanceEntity.MovementCreditAmountExchange;
                                        accountBalanceEntityExits.MovementCreditAmountOC = accountBalanceEntityExits.MovementCreditAmountOC - accountBalanceEntity.MovementCreditAmountOC;
                                        AccountBalanceDao.UpdateAccountBalance(accountBalanceEntityExits);
                                    }
                                }

                            }
                            // Cập nhật lại dữ liệu vào bảng cân đối tài khoản
                            listAccountBalanceEntity.Clear();
                            listAccountBalanceEntity = GetListAccountBalance(request);
                            foreach (var accountBalanceEntity in listAccountBalanceEntity)
                            {
                                var accountBalanceEntityExits = AccountBalanceDao.GetExitsAccountBalance(accountBalanceEntity);
                                if (accountBalanceEntityExits != null)
                                {
                                    // cập nhật bên TK nợ
                                    if (accountBalanceEntity.MovementCreditAmountOC == 0)
                                    {
                                        accountBalanceEntityExits.ExchangeRate = accountBalanceEntity.ExchangeRate;
                                        accountBalanceEntityExits.MovementDebitAmountExchange = accountBalanceEntityExits.MovementDebitAmountExchange + accountBalanceEntity.MovementDebitAmountExchange;
                                        accountBalanceEntityExits.MovementDebitAmountOC = accountBalanceEntityExits.MovementDebitAmountOC + accountBalanceEntity.MovementDebitAmountOC;
                                        AccountBalanceDao.UpdateAccountBalance(accountBalanceEntityExits);
                                    }
                                    else
                                    {
                                        accountBalanceEntityExits.ExchangeRate = accountBalanceEntity.ExchangeRate;
                                        accountBalanceEntityExits.MovementCreditAmountExchange = accountBalanceEntityExits.MovementCreditAmountExchange + accountBalanceEntity.MovementCreditAmountExchange;
                                        accountBalanceEntityExits.MovementCreditAmountOC = accountBalanceEntityExits.MovementCreditAmountOC + accountBalanceEntity.MovementCreditAmountOC;
                                        AccountBalanceDao.UpdateAccountBalance(accountBalanceEntityExits);
                                    }
                                }
                                else
                                {
                                    AccountBalanceDao.InsertAccountBalance(accountBalanceEntity);
                                }
                            }
                            // Xóa dữ liệu trống trong bảng Cân đối tài khoản
                            AccountBalanceDao.DeleteAccountBalance();
                            ////////////////////END BANG CAN DOI TAI KHOAN///////////////////////////////////////////////
                            // Update Master
                            response.Message = ItemTransactionDao.UpdateItemTransaction(itemTransactionEntity);
                            if (response.Message != null)
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                scope.Dispose();
                                return response;
                            }
                            //delete Details
                            response.Message = ItemTransactionDetailDao.DeleteItemTransactionDetailByItemTransactionId(itemTransactionEntity.RefId);
                            if (response.Message != null)
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                scope.Dispose();
                                return response;
                            }
                            journalEntryAccountEntity = listJournalEntryAccountEntity[0];
                            response.Message = JournalEntryAccountDao.DeleteJournalEntryAccount(journalEntryAccountEntity);
                            if (response.Message != null)
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                scope.Dispose();
                                return response;
                            }
                            foreach (var itemTransactionDetail in itemTransactionEntity.ItemTransactionDetails)
                            {
                                if (!itemTransactionDetail.Validate())
                                {
                                    foreach (string error in itemTransactionDetail.ValidationErrors)
                                        response.Message += error + Environment.NewLine;
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    return response;
                                }

                                itemTransactionDetail.RefId = itemTransactionEntity.RefId;
                                //Insert Details
                                itemTransactionDetail.RefDetailId = ItemTransactionDetailDao.InsertItemTransactionDetail(itemTransactionDetail);
                                // Insert into JourentryAcocunt
                                journalEntryAccountEntity = listJournalEntryAccountEntity[i];
                                journalEntryAccountEntity.RefId = itemTransactionDetail.RefId;
                                journalEntryAccountEntity.RefDetailId = itemTransactionDetail.RefDetailId;

                                #region " obJourentryAccount: thay đổi thông tin theo đối tượng Master"
                                int accountingObjectType = itemTransactionEntity.AccountingObjectType == null ? 0 : int.Parse(itemTransactionEntity.AccountingObjectType.ToString());
                                switch (accountingObjectType)
                                {
                                    case 0:
                                        journalEntryAccountEntity.VendorId = itemTransactionEntity.VendorId;
                                        break;
                                    case 1:
                                        journalEntryAccountEntity.EmployeeId = itemTransactionEntity.EmployeeId;
                                        break;
                                    case 2:
                                        journalEntryAccountEntity.AccountingObjectId = itemTransactionEntity.AccountingObjectId;
                                        break;
                                    case 3:
                                        journalEntryAccountEntity.CustomerId = itemTransactionEntity.CustomerId;
                                        break;
                                }
                                #endregion

                                if (!journalEntryAccountEntity.Validate())
                                {
                                    foreach (string error in journalEntryAccountEntity.ValidationErrors)
                                        response.Message += error + Environment.NewLine;
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    return response;
                                }
                                JournalEntryAccountDao.InsertDoubleJournalEntryAccount(journalEntryAccountEntity);
                                i = i + 1;
                            }
                            scope.Complete();
                        }
                    }
                }
                //////////////////////////////Xóa chứng từ///////////////////////////////////////////////////////
                else
                {
                    using (var scope = new TransactionScope())
                    {
                        var itemTransactionDetails = ItemTransactionDetailDao.GetItemTransactionDetailsByItemTransaction(request.RefId);
                        var receiptVoucherEntityForDelete = ItemTransactionDao.GetItemTransaction(request.RefId);
                        response.Message = ItemTransactionDao.DeleteItemTransaction(receiptVoucherEntityForDelete);
                        // Xóa bảng JourentryAccount
                        journalEntryAccountEntity.RefId = receiptVoucherEntityForDelete.RefId;
                        journalEntryAccountEntity.RefTypeId = receiptVoucherEntityForDelete.RefTypeId;
                        journalEntryAccountEntity.RefNo = receiptVoucherEntityForDelete.RefNo;
                        response.Message = JournalEntryAccountDao.DeleteJournalEntryAccount(journalEntryAccountEntity);
                        // Cập nhật lại dữ liệu vào bảng cân đối tài khoản
                        listAccountBalanceEntity.Clear();
                        request.ItemTransaction = receiptVoucherEntityForDelete;
                        request.ItemTransaction.ItemTransactionDetails = itemTransactionDetails;
                        listAccountBalanceEntity = GetListAccountBalance(request);
                        foreach (var accountBalanceEntity in listAccountBalanceEntity)
                        {
                            var accountBalanceEntityExits = AccountBalanceDao.GetExitsAccountBalance(accountBalanceEntity);
                            if (accountBalanceEntityExits != null)
                            {
                                // cập nhật bên TK nợ
                                // cập nhật bên TK nợ
                                if (accountBalanceEntity.MovementCreditAmountOC == 0)
                                {
                                    accountBalanceEntityExits.ExchangeRate = accountBalanceEntity.ExchangeRate;
                                    accountBalanceEntityExits.MovementDebitAmountExchange = accountBalanceEntityExits.MovementDebitAmountExchange - accountBalanceEntity.MovementDebitAmountExchange;
                                    accountBalanceEntityExits.MovementDebitAmountOC = accountBalanceEntityExits.MovementDebitAmountOC - accountBalanceEntity.MovementDebitAmountOC;
                                    AccountBalanceDao.UpdateAccountBalance(accountBalanceEntityExits);
                                }
                                else
                                {
                                    accountBalanceEntityExits.ExchangeRate = accountBalanceEntity.ExchangeRate;
                                    accountBalanceEntityExits.MovementCreditAmountExchange = accountBalanceEntityExits.MovementCreditAmountExchange - accountBalanceEntity.MovementCreditAmountExchange;
                                    accountBalanceEntityExits.MovementCreditAmountOC = accountBalanceEntityExits.MovementCreditAmountOC - accountBalanceEntity.MovementCreditAmountOC;
                                    AccountBalanceDao.UpdateAccountBalance(accountBalanceEntityExits);
                                }
                            }
                        }
                        // Xóa dữ liệu trống trong bảng Cân đối tài khoản
                        AccountBalanceDao.DeleteAccountBalance();
                        scope.Complete();
                    }

                }
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }
            response.RefId = itemTransactionEntity != null ? itemTransactionEntity.RefId : 0;
            response.Acknowledge = response.Message != null ? AcknowledgeType.Failure : AcknowledgeType.Success;
            return response;
        }

        public ItemTransactionResponse InsertItemTransactions(ItemTransactionRequest request, bool isAutoGenerateParallel)
        {
            var response = new ItemTransactionResponse();
            var journalEntryAccountEntity = new JournalEntryAccountEntity();
            IList<JournalEntryAccountEntity> listJournalEntryAccountEntity = new List<JournalEntryAccountEntity>();
            IList<AccountBalanceEntity> listAccountBalanceEntity = new List<AccountBalanceEntity>();
            var itemTransactionEntity = request.ItemTransaction;

            if (request.LoadOptions == null)
            {
                if (request.ItemTransaction != null)
                {
                    listJournalEntryAccountEntity = GetListJournalEntryAccount(request);
                    listAccountBalanceEntity = GetListAccountBalance(request);
                }
            }
            var i = 0;
            if (!itemTransactionEntity.Validate())
            {
                foreach (string error in itemTransactionEntity.ValidationErrors)
                    response.Message += error + Environment.NewLine;
                response.Acknowledge = AcknowledgeType.Failure;
                return response;
            }
            try
            {
                using (var scope = new TransactionScope())
                {
                    itemTransactionEntity.RefId = ItemTransactionDao.InsertItemTransaction(itemTransactionEntity);
                    if(itemTransactionEntity.RefId < 1)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return response;
                    }

                    #region Thêm mới chi tiết chứng từ

                    foreach (var itemTransactionDetail in itemTransactionEntity.ItemTransactionDetails)
                    {
                        if (!itemTransactionDetail.Validate())
                        {
                            foreach (string error in itemTransactionDetail.ValidationErrors)
                                response.Message += error + Environment.NewLine;
                            response.Acknowledge = AcknowledgeType.Failure;
                            return response;
                        }
                        // insert bang detail
                        itemTransactionDetail.RefId = itemTransactionEntity.RefId;
                        var itemTransactionDetailId = ItemTransactionDetailDao.InsertItemTransactionDetail(itemTransactionDetail);
                        // insert bang JourentryAccount
                        journalEntryAccountEntity = listJournalEntryAccountEntity[i];
                        journalEntryAccountEntity.RefId = itemTransactionDetail.RefId;
                        journalEntryAccountEntity.RefDetailId = itemTransactionDetailId;
                        journalEntryAccountEntity.VendorId = itemTransactionEntity.VendorId;
                        journalEntryAccountEntity.EmployeeId = itemTransactionEntity.EmployeeId;
                        journalEntryAccountEntity.AccountingObjectId = itemTransactionEntity.AccountingObjectId;
                        journalEntryAccountEntity.CustomerId = itemTransactionEntity.CustomerId;
                        if (!journalEntryAccountEntity.Validate())
                        {
                            foreach (string error in journalEntryAccountEntity.ValidationErrors)
                                response.Message += error + Environment.NewLine;
                            response.Acknowledge = AcknowledgeType.Failure;
                            return response;
                        }
                        JournalEntryAccountDao.InsertDoubleJournalEntryAccount(journalEntryAccountEntity);
                        i = i + 1;
                    }

                    #endregion

                    #region Kiểm tra đã tồn tại trong bảng Account Balance

                    foreach (var accountBalanceEntity in listAccountBalanceEntity)
                    {
                        var accountBalanceEntityExits = AccountBalanceDao.GetExitsAccountBalance(accountBalanceEntity);
                        if (accountBalanceEntityExits != null)
                        {
                            // cập nhật bên TK nợ
                            if (accountBalanceEntity.MovementCreditAmountOC == 0)
                            {
                                accountBalanceEntityExits.ExchangeRate = accountBalanceEntity.ExchangeRate;
                                accountBalanceEntityExits.MovementDebitAmountExchange = accountBalanceEntityExits.MovementDebitAmountExchange + accountBalanceEntity.MovementDebitAmountExchange;
                                accountBalanceEntityExits.MovementDebitAmountOC = accountBalanceEntityExits.MovementDebitAmountOC + accountBalanceEntity.MovementDebitAmountOC;
                                AccountBalanceDao.UpdateAccountBalance(accountBalanceEntityExits);
                            }
                            else
                            {
                                accountBalanceEntityExits.ExchangeRate = accountBalanceEntity.ExchangeRate;
                                accountBalanceEntityExits.MovementCreditAmountExchange = accountBalanceEntityExits.MovementCreditAmountExchange + accountBalanceEntity.MovementCreditAmountExchange;
                                accountBalanceEntityExits.MovementCreditAmountOC = accountBalanceEntityExits.MovementCreditAmountOC + accountBalanceEntity.MovementCreditAmountOC;
                                AccountBalanceDao.UpdateAccountBalance(accountBalanceEntityExits);
                            }
                        }
                        else
                        {
                            AccountBalanceDao.InsertAccountBalance(accountBalanceEntity);
                        }
                    }

                    #endregion

                    #region Sinh định khoản đồng thời

                    if (!isAutoGenerateParallel)
                    {
                        // nếu không tự sinh định khoản --> lấy định khoản trong grid định khoản
                        if (itemTransactionEntity.ItemTransactionDetailParallels != null && itemTransactionEntity.ItemTransactionDetailParallels.Count > 0)
                        {
                            foreach (var itemTransactionDetailParallel in itemTransactionEntity.ItemTransactionDetailParallels)
                            {
                                #region Insert ItemTransactionDetailParallel

                                itemTransactionDetailParallel.RefId = itemTransactionEntity.RefId;
                                itemTransactionDetailParallel.RefTypeId = itemTransactionEntity.RefTypeId;
                                itemTransactionDetailParallel.AccountingObjectId = itemTransactionEntity.AccountingObjectId;
                                itemTransactionDetailParallel.CustomerId = itemTransactionEntity.CustomerId;
                                itemTransactionDetailParallel.EmployeeId = itemTransactionEntity.EmployeeId;
                                itemTransactionDetailParallel.VendorId = itemTransactionEntity.VendorId;
                                if (!itemTransactionDetailParallel.Validate())
                                {
                                    foreach (var error in itemTransactionDetailParallel.ValidationErrors)
                                        response.Message += error + Environment.NewLine;
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    scope.Dispose();
                                    return response;
                                }

                                itemTransactionDetailParallel.RefDetailId = ItemTransactionDetailParallelDao.InsertItemTransactionDetailParallel(itemTransactionDetailParallel);
                                if (itemTransactionDetailParallel.RefDetailId < 1)
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    scope.Dispose();
                                    return response;
                                }

                                #endregion

                                #region Insert JourentryAccount

                                var journalEntryAccount = MakeJournalEntryAccount(itemTransactionEntity, itemTransactionDetailParallel);
                                journalEntryAccount.JournalEntryId = JournalEntryAccountDao.InsertDoubleJournalEntryAccount(journalEntryAccount);
                                if (journalEntryAccount.JournalEntryId < 1)
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    scope.Dispose();
                                    return response;
                                }

                                #endregion
                            }
                        }
                    }
                    else
                    {
                        //truong hop sinh tu dong se sinh theo chung tu chi tiet
                        if (itemTransactionEntity.ItemTransactionDetails != null && itemTransactionEntity.ItemTransactionDetails.Count > 0)
                        {
                            foreach (var itemTransactionDetail in itemTransactionEntity.ItemTransactionDetails)
                            {
                                var budgetSourceId = BudgetSourceDao.GetBudgetSourceByBudgetSourceCode(itemTransactionDetail.BudgetSourceCode);
                                var budgetItemId = BudgetItemDao.GetBudgetItemsByCode(itemTransactionDetail.BudgetItemCode);
                                //insert dl moi
                                var autoBusinessParallelEntitys = AutoBusinessParallelDao.GetAutoBusinessParallelsByAutoBussinessInformations(
                                    itemTransactionDetail.AccountNumber
                                    , itemTransactionDetail.CorrespondingAccountNumber
                                    , budgetSourceId == null ? 0 : budgetSourceId.BudgetSourceId
                                    , (budgetItemId == null || budgetItemId.Count == 0) ? 0 : budgetItemId.FirstOrDefault().BudgetItemId
                                    , 0
                                    , itemTransactionDetail.VoucherTypeId == null ? 0 : (int)itemTransactionDetail.VoucherTypeId);

                                if (autoBusinessParallelEntitys != null)
                                {
                                    foreach (var autoBusinessParallelEntity in autoBusinessParallelEntitys)
                                    {
                                        #region Insert ItemTransactionDetailParallel

                                        var itemTransactionDetailParallel = MakeItemTransactionDetailParallel(itemTransactionEntity, itemTransactionDetail, autoBusinessParallelEntity);
                                        itemTransactionDetailParallel.RefDetailId = 0;
                                        if (!itemTransactionDetailParallel.Validate())
                                        {
                                            foreach (var error in itemTransactionDetailParallel.ValidationErrors)
                                                response.Message += error + Environment.NewLine;
                                            response.Acknowledge = AcknowledgeType.Failure;
                                            scope.Dispose();
                                            return response;
                                        }

                                        itemTransactionDetailParallel.RefDetailId = ItemTransactionDetailParallelDao.InsertItemTransactionDetailParallel(itemTransactionDetailParallel);
                                        if (itemTransactionDetailParallel.RefDetailId < 1)
                                        {
                                            response.Acknowledge = AcknowledgeType.Failure;
                                            scope.Dispose();
                                            return response;
                                        }

                                        #endregion

                                        #region Insert JournalEntryAccount

                                        var journalEntryAccount = MakeJournalEntryAccount(itemTransactionEntity, itemTransactionDetailParallel);
                                        journalEntryAccount.JournalEntryId = JournalEntryAccountDao.InsertDoubleJournalEntryAccount(journalEntryAccount);
                                        if (journalEntryAccount.JournalEntryId < 1)
                                        {
                                            response.Acknowledge = AcknowledgeType.Failure;
                                            scope.Dispose();
                                            return response;
                                        }

                                        #endregion
                                    }
                                }
                            }
                        }
                    }

                    #endregion

                    #region Đánh số tự động

                    var autoNumber = AutoNumberDao.GetAutoNumberByRefType(itemTransactionEntity.RefTypeId);
                    //Lưu giá trị số tự động tăng theo loại tiền
                    if (itemTransactionEntity.CurrencyCode == "USD")
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
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }
            response.RefId = itemTransactionEntity != null ? itemTransactionEntity.RefId : 0;
            response.Acknowledge = response.Message != null ? AcknowledgeType.Failure : AcknowledgeType.Success;
            return response;
        }

        public ItemTransactionResponse UpdateItemTransactions(ItemTransactionRequest request, bool isAutoGenerateParallel)
        {
            var response = new ItemTransactionResponse();
            var journalEntryAccountEntity = new JournalEntryAccountEntity();
            IList<JournalEntryAccountEntity> listJournalEntryAccountEntity = new List<JournalEntryAccountEntity>();
            IList<AccountBalanceEntity> listAccountBalanceEntity = new List<AccountBalanceEntity>();
            var itemTransactionEntity = request.ItemTransaction;

            if (request.LoadOptions == null)
            {
                if (request.ItemTransaction != null)
                {
                    listJournalEntryAccountEntity = GetListJournalEntryAccount(request);
                    listAccountBalanceEntity = GetListAccountBalance(request);
                }
            }
            var i = 0;
            if (!itemTransactionEntity.Validate())
            {
                foreach (string error in itemTransactionEntity.ValidationErrors)
                    response.Message += error + Environment.NewLine;
                response.Acknowledge = AcknowledgeType.Failure;
                return response;
            }
            try
            {
                if (request.LoadOptions != null)
                {
                    if (request.LoadOptions.Contains("ReCalOutputStock"))
                    {
                        ReCalOutputStock(request.FromDateForReCalOutputStock, request.ToDateForReCalOutputStock, request.StockId, request.CurrencyCode, request.CurrencyDecimalDigits);
                    }
                }
                else
                {
                    using (var scope = new TransactionScope())
                    {
                        #region Update AccountBalance

                        // Trừ số tiền khi mà update xử lý Bảng cân đối tài khoản
                        listAccountBalanceEntity.Clear();
                        listAccountBalanceEntity = GetListAccountBalanceOlder(itemTransactionEntity.RefId);
                        foreach (var accountBalanceEntity in listAccountBalanceEntity)
                        {
                            var accountBalanceEntityExits = AccountBalanceDao.GetExitsAccountBalance(accountBalanceEntity);
                            if (accountBalanceEntityExits != null)
                            {
                                // cập nhật bên TK nợ
                                if (accountBalanceEntity.MovementCreditAmountOC == 0)
                                {
                                    accountBalanceEntityExits.ExchangeRate = accountBalanceEntity.ExchangeRate;
                                    accountBalanceEntityExits.MovementDebitAmountExchange = accountBalanceEntityExits.MovementDebitAmountExchange - accountBalanceEntity.MovementDebitAmountExchange;
                                    accountBalanceEntityExits.MovementDebitAmountOC = accountBalanceEntityExits.MovementDebitAmountOC - accountBalanceEntity.MovementDebitAmountOC;
                                    AccountBalanceDao.UpdateAccountBalance(accountBalanceEntityExits);
                                }
                                else
                                {
                                    accountBalanceEntityExits.ExchangeRate = accountBalanceEntity.ExchangeRate;
                                    accountBalanceEntityExits.MovementCreditAmountExchange = accountBalanceEntityExits.MovementCreditAmountExchange - accountBalanceEntity.MovementCreditAmountExchange;
                                    accountBalanceEntityExits.MovementCreditAmountOC = accountBalanceEntityExits.MovementCreditAmountOC - accountBalanceEntity.MovementCreditAmountOC;
                                    AccountBalanceDao.UpdateAccountBalance(accountBalanceEntityExits);
                                }
                            }

                        }
                        // Cập nhật lại dữ liệu vào bảng cân đối tài khoản
                        listAccountBalanceEntity.Clear();
                        listAccountBalanceEntity = GetListAccountBalance(request);
                        foreach (var accountBalanceEntity in listAccountBalanceEntity)
                        {
                            var accountBalanceEntityExits = AccountBalanceDao.GetExitsAccountBalance(accountBalanceEntity);
                            if (accountBalanceEntityExits != null)
                            {
                                // cập nhật bên TK nợ
                                if (accountBalanceEntity.MovementCreditAmountOC == 0)
                                {
                                    accountBalanceEntityExits.ExchangeRate = accountBalanceEntity.ExchangeRate;
                                    accountBalanceEntityExits.MovementDebitAmountExchange = accountBalanceEntityExits.MovementDebitAmountExchange + accountBalanceEntity.MovementDebitAmountExchange;
                                    accountBalanceEntityExits.MovementDebitAmountOC = accountBalanceEntityExits.MovementDebitAmountOC + accountBalanceEntity.MovementDebitAmountOC;
                                    AccountBalanceDao.UpdateAccountBalance(accountBalanceEntityExits);
                                }
                                else
                                {
                                    accountBalanceEntityExits.ExchangeRate = accountBalanceEntity.ExchangeRate;
                                    accountBalanceEntityExits.MovementCreditAmountExchange = accountBalanceEntityExits.MovementCreditAmountExchange + accountBalanceEntity.MovementCreditAmountExchange;
                                    accountBalanceEntityExits.MovementCreditAmountOC = accountBalanceEntityExits.MovementCreditAmountOC + accountBalanceEntity.MovementCreditAmountOC;
                                    AccountBalanceDao.UpdateAccountBalance(accountBalanceEntityExits);
                                }
                            }
                            else
                            {
                                AccountBalanceDao.InsertAccountBalance(accountBalanceEntity);
                            }
                        }
                        // Xóa dữ liệu trống trong bảng Cân đối tài khoản
                        AccountBalanceDao.DeleteAccountBalance();

                        #endregion

                        #region Update Master

                        response.Message = ItemTransactionDao.UpdateItemTransaction(itemTransactionEntity);
                        if (response.Message != null)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return response;
                        }

                        #endregion

                        #region Update ItemTransactionDetail And JournalEntryAccount

                        response.Message = ItemTransactionDetailDao.DeleteItemTransactionDetailByItemTransactionId(itemTransactionEntity.RefId);
                        if (response.Message != null)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return response;
                        }
                        journalEntryAccountEntity = listJournalEntryAccountEntity[0];
                        response.Message = JournalEntryAccountDao.DeleteJournalEntryAccount(journalEntryAccountEntity);
                        if (response.Message != null)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return response;
                        }
                        foreach (var itemTransactionDetail in itemTransactionEntity.ItemTransactionDetails)
                        {
                            if (!itemTransactionDetail.Validate())
                            {
                                foreach (string error in itemTransactionDetail.ValidationErrors)
                                    response.Message += error + Environment.NewLine;
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }

                            itemTransactionDetail.RefId = itemTransactionEntity.RefId;
                            //Insert Details
                            itemTransactionDetail.RefDetailId = ItemTransactionDetailDao.InsertItemTransactionDetail(itemTransactionDetail);
                            // Insert into JourentryAcocunt
                            journalEntryAccountEntity = listJournalEntryAccountEntity[i];
                            journalEntryAccountEntity.RefId = itemTransactionDetail.RefId;
                            journalEntryAccountEntity.RefDetailId = itemTransactionDetail.RefDetailId;
                            journalEntryAccountEntity.VendorId = itemTransactionEntity.VendorId;
                            journalEntryAccountEntity.EmployeeId = itemTransactionEntity.EmployeeId;
                            journalEntryAccountEntity.AccountingObjectId = itemTransactionEntity.AccountingObjectId;
                            journalEntryAccountEntity.CustomerId = itemTransactionEntity.CustomerId;

                            if (!journalEntryAccountEntity.Validate())
                            {
                                foreach (string error in journalEntryAccountEntity.ValidationErrors)
                                    response.Message += error + Environment.NewLine;
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }
                            JournalEntryAccountDao.InsertDoubleJournalEntryAccount(journalEntryAccountEntity);
                            i = i + 1;
                        }

                        #endregion

                        #region Update ItemTransactionDetailParallel And JournalEntryAccount

                        // xóa dữ liệu cũ (journal entry account đã xóa cùng với mục details)
                        response.Message = ItemTransactionDetailParallelDao.DeleteItemTransactionDetailParallelById(itemTransactionEntity.RefId);
                        if (response.Message != null)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return response;
                        }

                        // thêm dữ liệu mới
                        if (!isAutoGenerateParallel)
                        {
                            //neu khong tu dong sinh dinh khoan dong thoi -> lay theo grid dinh khoan dong thoi
                            if (itemTransactionEntity.ItemTransactionDetailParallels != null && itemTransactionEntity.ItemTransactionDetailParallels.Count > 0)
                            {
                                foreach (var itemTransactionDetailParallel in itemTransactionEntity.ItemTransactionDetailParallels)
                                {
                                    #region Insert ItemTransactionDetailParallel

                                    itemTransactionDetailParallel.RefId = itemTransactionEntity.RefId;
                                    itemTransactionDetailParallel.RefTypeId = itemTransactionEntity.RefTypeId;
                                    itemTransactionDetailParallel.AccountingObjectId = itemTransactionEntity.AccountingObjectId;
                                    itemTransactionDetailParallel.CustomerId = itemTransactionEntity.CustomerId;
                                    itemTransactionDetailParallel.EmployeeId = itemTransactionEntity.EmployeeId;
                                    itemTransactionDetailParallel.VendorId = itemTransactionEntity.VendorId;
                                    if (!itemTransactionDetailParallel.Validate())
                                    {
                                        foreach (var error in itemTransactionDetailParallel.ValidationErrors)
                                            response.Message += error + Environment.NewLine;
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        scope.Dispose();
                                        return response;
                                    }

                                    itemTransactionDetailParallel.RefDetailId = ItemTransactionDetailParallelDao.InsertItemTransactionDetailParallel(itemTransactionDetailParallel);
                                    if (itemTransactionDetailParallel.RefDetailId < 1)
                                    {
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        scope.Dispose();
                                        return response;
                                    }

                                    #endregion

                                    #region Insert JournalEntryAccount

                                    var journalEntryAccount = MakeJournalEntryAccount(itemTransactionEntity, itemTransactionDetailParallel);
                                    journalEntryAccount.JournalEntryId = JournalEntryAccountDao.InsertDoubleJournalEntryAccount(journalEntryAccount);
                                    if (journalEntryAccount.JournalEntryId < 1)
                                    {
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        scope.Dispose();
                                        return response;
                                    }

                                    #endregion
                                }
                            }
                        }
                        else
                        {
                            //truong hop sinh tu dong se sinh theo chung tu chi tiet
                            foreach (var itemTransactionDetail in itemTransactionEntity.ItemTransactionDetails)
                            {
                                var budgetSourceId = BudgetSourceDao.GetBudgetSourceByBudgetSourceCode(itemTransactionDetail.BudgetSourceCode);
                                var budgetItemId = BudgetItemDao.GetBudgetItemsByCode(itemTransactionDetail.BudgetItemCode);

                                var autoBusinessParallelEntitys = AutoBusinessParallelDao.GetAutoBusinessParallelsByAutoBussinessInformations(
                                    itemTransactionDetail.AccountNumber
                                    , itemTransactionDetail.CorrespondingAccountNumber
                                    , budgetSourceId == null ? 0 : budgetSourceId.BudgetSourceId
                                    , (budgetItemId == null || budgetItemId.Count == 0) ? 0 : budgetItemId.FirstOrDefault().BudgetItemId
                                    , 0
                                    , itemTransactionDetail.VoucherTypeId == null ? 0 : (int)itemTransactionDetail.VoucherTypeId);

                                if (autoBusinessParallelEntitys != null)
                                {
                                    foreach (var autoBusinessParallelEntity in autoBusinessParallelEntitys)
                                    {
                                        #region Insert ItemTransactionDetailParallel

                                        var itemTransactionDetailParallel = MakeItemTransactionDetailParallel(itemTransactionEntity, itemTransactionDetail, autoBusinessParallelEntity);
                                        if (!itemTransactionDetailParallel.Validate())
                                        {
                                            foreach (var error in itemTransactionDetailParallel.ValidationErrors)
                                                response.Message += error + Environment.NewLine;
                                            response.Acknowledge = AcknowledgeType.Failure;
                                            scope.Dispose();
                                            return response;
                                        }

                                        itemTransactionDetailParallel.RefDetailId = ItemTransactionDetailParallelDao.InsertItemTransactionDetailParallel(itemTransactionDetailParallel);
                                        if (itemTransactionDetailParallel.RefDetailId < 1)
                                        {
                                            response.Acknowledge = AcknowledgeType.Failure;
                                            scope.Dispose();
                                            return response;
                                        }

                                        #endregion

                                        #region Insert JournalEntryAccount

                                        var journalEntryAccount = MakeJournalEntryAccount(itemTransactionEntity, itemTransactionDetailParallel);
                                        journalEntryAccount.JournalEntryId = JournalEntryAccountDao.InsertDoubleJournalEntryAccount(journalEntryAccount);
                                        if (journalEntryAccount.JournalEntryId < 1)
                                        {
                                            response.Acknowledge = AcknowledgeType.Failure;
                                            scope.Dispose();
                                            return response;
                                        }

                                        #endregion
                                    }
                                }
                            }
                        }

                        #endregion

                        scope.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }
            response.RefId = itemTransactionEntity != null ? itemTransactionEntity.RefId : 0;
            response.Acknowledge = response.Message != null ? AcknowledgeType.Failure : AcknowledgeType.Success;
            return response;
        }

        public ItemTransactionResponse DeleteItemTransactions(ItemTransactionRequest request)
        {
            var response = new ItemTransactionResponse();
            var journalEntryAccountEntity = new JournalEntryAccountEntity();
            IList<JournalEntryAccountEntity> listJournalEntryAccountEntity = new List<JournalEntryAccountEntity>();
            IList<AccountBalanceEntity> listAccountBalanceEntity = new List<AccountBalanceEntity>();
            var itemTransactionEntity = request.ItemTransaction;

            if (request.LoadOptions == null)
            {
                if (request.ItemTransaction != null)
                {
                    listJournalEntryAccountEntity = GetListJournalEntryAccount(request);
                    listAccountBalanceEntity = GetListAccountBalance(request);
                }
            }
            var i = 0;
            try
            {
                using (var scope = new TransactionScope())
                {
                    var itemTransactionDetails = ItemTransactionDetailDao.GetItemTransactionDetailsByItemTransaction(request.RefId);
                    var receiptVoucherEntityForDelete = ItemTransactionDao.GetItemTransaction(request.RefId);
                    response.Message = ItemTransactionDao.DeleteItemTransaction(receiptVoucherEntityForDelete);
                    // Xóa bảng JourentryAccount
                    journalEntryAccountEntity.RefId = receiptVoucherEntityForDelete.RefId;
                    journalEntryAccountEntity.RefTypeId = receiptVoucherEntityForDelete.RefTypeId;
                    journalEntryAccountEntity.RefNo = receiptVoucherEntityForDelete.RefNo;
                    response.Message = JournalEntryAccountDao.DeleteJournalEntryAccount(journalEntryAccountEntity);
                    // Cập nhật lại dữ liệu vào bảng cân đối tài khoản
                    listAccountBalanceEntity.Clear();
                    request.ItemTransaction = receiptVoucherEntityForDelete;
                    request.ItemTransaction.ItemTransactionDetails = itemTransactionDetails;
                    listAccountBalanceEntity = GetListAccountBalance(request);
                    foreach (var accountBalanceEntity in listAccountBalanceEntity)
                    {
                        var accountBalanceEntityExits = AccountBalanceDao.GetExitsAccountBalance(accountBalanceEntity);
                        if (accountBalanceEntityExits != null)
                        {
                            // cập nhật bên TK nợ
                            // cập nhật bên TK nợ
                            if (accountBalanceEntity.MovementCreditAmountOC == 0)
                            {
                                accountBalanceEntityExits.ExchangeRate = accountBalanceEntity.ExchangeRate;
                                accountBalanceEntityExits.MovementDebitAmountExchange = accountBalanceEntityExits.MovementDebitAmountExchange - accountBalanceEntity.MovementDebitAmountExchange;
                                accountBalanceEntityExits.MovementDebitAmountOC = accountBalanceEntityExits.MovementDebitAmountOC - accountBalanceEntity.MovementDebitAmountOC;
                                AccountBalanceDao.UpdateAccountBalance(accountBalanceEntityExits);
                            }
                            else
                            {
                                accountBalanceEntityExits.ExchangeRate = accountBalanceEntity.ExchangeRate;
                                accountBalanceEntityExits.MovementCreditAmountExchange = accountBalanceEntityExits.MovementCreditAmountExchange - accountBalanceEntity.MovementCreditAmountExchange;
                                accountBalanceEntityExits.MovementCreditAmountOC = accountBalanceEntityExits.MovementCreditAmountOC - accountBalanceEntity.MovementCreditAmountOC;
                                AccountBalanceDao.UpdateAccountBalance(accountBalanceEntityExits);
                            }
                        }
                    }
                    // Xóa dữ liệu trống trong bảng Cân đối tài khoản
                    AccountBalanceDao.DeleteAccountBalance();
                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }
            response.RefId = itemTransactionEntity != null ? itemTransactionEntity.RefId : 0;
            response.Acknowledge = response.Message != null ? AcknowledgeType.Failure : AcknowledgeType.Success;
            return response;
        } 

        public ItemTransactionResponse ReCalOutputStock2(DateTime fromDate, DateTime toDate, List<int> lstStockIds, string currencyCode, int currencyDecimalDigits)
        {
            var response = new ItemTransactionResponse();
            try
            {
                var listItemTransactionEntity = ItemTransactionDao.GetItemTransactionsForCalOutputInventory(fromDate, toDate, lstStockIds, currencyCode);
                foreach (var itemTransactionEntity in listItemTransactionEntity)
                {
                    var request = new ItemTransactionRequest
                    {
                        Action = PersistType.Update,
                        ItemTransaction = itemTransactionEntity,
                        CurrencyDecimalDigits = currencyDecimalDigits
                    };
                    UpdateItemTransactions(request, false);
                }
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }
            response.Acknowledge = response.Message != null ? AcknowledgeType.Failure : AcknowledgeType.Success;
            return response;
        }

        public IList<JournalEntryAccountEntity> GetListJournalEntryAccount(ItemTransactionRequest request)
        {
            var itemTransactionEntity = request.ItemTransaction;

            return (from itemTransactionDetail in itemTransactionEntity.ItemTransactionDetails
                    let iItemTransactionDetailId = itemTransactionDetail.RefDetailId
                    select new JournalEntryAccountEntity
                    {
                        RefId = itemTransactionEntity.RefId,
                        RefTypeId = itemTransactionEntity.RefTypeId,
                        RefNo = itemTransactionEntity.RefNo,
                        RefDate = itemTransactionEntity.RefDate,
                        PostedDate = itemTransactionEntity.PostedDate,
                        JournalMemo = itemTransactionEntity.JournalMemo,
                        CurrencyCode = itemTransactionEntity.CurrencyCode,
                        ExchangeRate = itemTransactionEntity.ExchangeRate,
                        RefDetailId = iItemTransactionDetailId,
                        AccountNumber = itemTransactionDetail.AccountNumber,
                        CorrespondingAccountNumber = itemTransactionDetail.CorrespondingAccountNumber,
                        AmountOc = itemTransactionDetail.AmountOc,
                        Description = itemTransactionDetail.Description,
                        AmountExchange = itemTransactionDetail.AmountExchange,
                        BudgetSourceCode = itemTransactionDetail.BudgetSourceCode,
                        BudgetItemCode = itemTransactionDetail.BudgetItemCode,
                        AccountingObjectId = itemTransactionDetail.AccountingObjectId,
                        MergerFundId = itemTransactionDetail.MergerFundId,
                        VoucherTypeId = itemTransactionDetail.VoucherTypeId,
                        Quantity = itemTransactionDetail.Quantity ,
                        ProjectId = itemTransactionDetail.ProjectId,
                        InventoryItemId = itemTransactionDetail.InventoryItemId
                        
                    }).ToList();
        }

        public IList<AccountBalanceEntity> GetListAccountBalance(ItemTransactionRequest request)
        {
            var itemTransactionEntity = request.ItemTransaction;
            IList<AccountBalanceEntity> obListAccountBalanceEntity = new List<AccountBalanceEntity>();
            foreach (var itemTransactionDetail in itemTransactionEntity.ItemTransactionDetails)
            {
                var accountBalanceEntity = new AccountBalanceEntity
                {
                    BalanceDate = itemTransactionEntity.PostedDate,
                    CurrencyCode = itemTransactionEntity.CurrencyCode,
                    ExchangeRate = itemTransactionEntity.ExchangeRate,
                    AccountNumber = itemTransactionDetail.AccountNumber,
                    MovementDebitAmountOC = itemTransactionDetail.AmountOc,
                    MovementDebitAmountExchange = itemTransactionDetail.AmountExchange,
                    BudgetSourceCode = itemTransactionDetail.BudgetSourceCode,
                    BudgetItemCode = itemTransactionDetail.BudgetItemCode,
                    MovementCreditAmountOC = 0,
                    MovementCreditAmountExchange = 0,
                    ProjectId = itemTransactionDetail.ProjectId == 0 ? null : itemTransactionDetail.ProjectId
                };
                //Dòng tài khoản nợ
                obListAccountBalanceEntity.Add(accountBalanceEntity);
                // Dòng tài khoản có
                var accountBalanceEntity1 = new AccountBalanceEntity
                {
                    BalanceDate = itemTransactionEntity.PostedDate,
                    CurrencyCode = itemTransactionEntity.CurrencyCode,
                    ExchangeRate = itemTransactionEntity.ExchangeRate,
                    AccountNumber = itemTransactionDetail.CorrespondingAccountNumber,
                    MovementCreditAmountOC = itemTransactionDetail.AmountOc,
                    MovementCreditAmountExchange = itemTransactionDetail.AmountExchange,
                    BudgetSourceCode = itemTransactionDetail.BudgetSourceCode,
                    BudgetItemCode = itemTransactionDetail.BudgetItemCode,
                    MovementDebitAmountOC = 0,
                    MovementDebitAmountExchange = 0,
                    ProjectId = itemTransactionDetail.ProjectId == 0 ? null : itemTransactionDetail.ProjectId
                };

                obListAccountBalanceEntity.Add(accountBalanceEntity1);
            }

            return obListAccountBalanceEntity;
        }

        public IList<AccountBalanceEntity> GetListAccountBalanceOlder(long refId)
        {
            var itemTransactionEntity = ItemTransactionDao.GetItemTransaction(refId);
            itemTransactionEntity.ItemTransactionDetails = ItemTransactionDetailDao.GetItemTransactionDetailsByItemTransaction(refId);
            IList<AccountBalanceEntity> obListAccountBalanceEntity = new List<AccountBalanceEntity>();
            foreach (var itemTransactionDetail in itemTransactionEntity.ItemTransactionDetails)
            {
                var accountBalanceEntity = new AccountBalanceEntity
                {
                    BalanceDate = itemTransactionEntity.PostedDate,
                    CurrencyCode = itemTransactionEntity.CurrencyCode,
                    ExchangeRate = itemTransactionEntity.ExchangeRate,
                    AccountNumber = itemTransactionDetail.AccountNumber,
                    MovementDebitAmountOC = itemTransactionDetail.AmountOc,
                    MovementDebitAmountExchange = itemTransactionDetail.AmountExchange,
                    BudgetSourceCode = itemTransactionDetail.BudgetSourceCode,
                    BudgetItemCode = itemTransactionDetail.BudgetItemCode,
                    MovementCreditAmountOC = 0,
                    MovementCreditAmountExchange = 0,
                    ProjectId = itemTransactionDetail.ProjectId == 0 ? null : itemTransactionDetail.ProjectId
                };
                //Dòng tài khoản nợ
                obListAccountBalanceEntity.Add(accountBalanceEntity);
                // Dòng tài khoản có
                var obAccountBalanceEntity1 = new AccountBalanceEntity
                {
                    BalanceDate = itemTransactionEntity.PostedDate,
                    CurrencyCode = itemTransactionEntity.CurrencyCode,
                    ExchangeRate = itemTransactionEntity.ExchangeRate,
                    AccountNumber = itemTransactionDetail.CorrespondingAccountNumber,
                    MovementCreditAmountOC = itemTransactionDetail.AmountOc,
                    MovementCreditAmountExchange = itemTransactionDetail.AmountExchange,
                    BudgetSourceCode = itemTransactionDetail.BudgetSourceCode,
                    BudgetItemCode = itemTransactionDetail.BudgetItemCode,
                    MovementDebitAmountOC = 0,
                    MovementDebitAmountExchange = 0,
                    ProjectId = itemTransactionDetail.ProjectId == 0 ? null : itemTransactionDetail.ProjectId
                };

                obListAccountBalanceEntity.Add(obAccountBalanceEntity1);
            }

            return obListAccountBalanceEntity;
        }

        public void ReCalOutputStock(DateTime fromDateForReCalOutputStock, DateTime toDateForReCalOutputStock, List<int> stockId, string currencyCode, int currencyDecimalDigits)
        {
            var listItemTransactionEntity = ItemTransactionDao.GetItemTransactionsForCalOutputInventory(fromDateForReCalOutputStock, toDateForReCalOutputStock, stockId, currencyCode);
            foreach (var itemTransactionEntity in listItemTransactionEntity)
            {
                var request = new ItemTransactionRequest
                {
                    Action = PersistType.Update,
                    ItemTransaction = itemTransactionEntity,
                    CurrencyDecimalDigits = currencyDecimalDigits
                };
                SetItemTransactions(request);
            }
        }

        /// <summary>
        /// Tính số lượng vật tư còn tồn trong kho đến khoảng thời gian nào đó
        /// </summary>
        public decimal GetQuantityOfInventory(int inventoryItemID, int stockId, DateTime postDate, long refID, string currencyCode)
        {
            return ItemTransactionDao.GetQuantityOfInventory(inventoryItemID, stockId, postDate, refID, currencyCode);
        }

        #region Make object

        public JournalEntryAccountEntity MakeJournalEntryAccount(ItemTransactionEntity itemTransaction, ItemTransactionDetailParallelEntity itemTransactionDetailParallel)
        {
            var journalEntryAccount = new JournalEntryAccountEntity();
            if (itemTransactionDetailParallel != null)
            {
                journalEntryAccount.RefDetailId = itemTransactionDetailParallel.RefDetailId;
                journalEntryAccount.RefId = itemTransactionDetailParallel.RefId;
                journalEntryAccount.RefTypeId = itemTransactionDetailParallel.RefTypeId;
                journalEntryAccount.RefNo = itemTransaction.RefNo;
                journalEntryAccount.RefDate = itemTransaction.RefDate;
                journalEntryAccount.PostedDate = itemTransaction.PostedDate;
                journalEntryAccount.Description = itemTransactionDetailParallel.Description;
                journalEntryAccount.JournalMemo = itemTransaction.JournalMemo;
                journalEntryAccount.CurrencyCode = itemTransaction.CurrencyCode;
                journalEntryAccount.ExchangeRate = itemTransaction.ExchangeRate;
                journalEntryAccount.AccountNumber = itemTransactionDetailParallel.AccountNumber;
                journalEntryAccount.CorrespondingAccountNumber = itemTransactionDetailParallel.CorrespondingAccountNumber;
                journalEntryAccount.Quantity = itemTransactionDetailParallel.TotalQuantity;
                //journalEntryAccount.JournalType = 
                journalEntryAccount.AmountOc = itemTransactionDetailParallel.AmountOc;
                journalEntryAccount.AmountExchange = itemTransactionDetailParallel.AmountExchange;
                journalEntryAccount.BudgetSourceCode = itemTransactionDetailParallel.BudgetSourceCode;
                journalEntryAccount.BudgetItemCode = itemTransactionDetailParallel.BudgetItemCode;
                journalEntryAccount.CustomerId = itemTransaction.CustomerId;
                journalEntryAccount.VendorId = itemTransaction.VendorId;
                journalEntryAccount.EmployeeId = itemTransaction.EmployeeId;
                journalEntryAccount.AccountingObjectId = itemTransaction.AccountingObjectId;
                journalEntryAccount.VoucherTypeId = itemTransactionDetailParallel.VoucherTypeId;
                journalEntryAccount.MergerFundId = itemTransactionDetailParallel.MergerFundId;
                journalEntryAccount.ProjectId = itemTransactionDetailParallel.ProjectId;
                journalEntryAccount.InventoryItemId = itemTransactionDetailParallel.InventoryItemId;
                journalEntryAccount.BankId = itemTransaction.BankId;
                //journalEntryAccount.BankAccount 
            }
            return journalEntryAccount;
        }

        public ItemTransactionDetailParallelEntity MakeItemTransactionDetailParallel(ItemTransactionEntity itemTransaction, ItemTransactionDetailEntity itemTransactionDetail, AutoBusinessParallelEntity autoBusinessParallel)
        {
            var itemTransactionDetailParallel = new ItemTransactionDetailParallelEntity();
            itemTransactionDetailParallel.RefDetailId = itemTransactionDetail.RefDetailId;
            itemTransactionDetailParallel.RefId = itemTransactionDetail.RefId;
            itemTransactionDetailParallel.RefTypeId = itemTransaction.RefTypeId;
            itemTransactionDetailParallel.Description = itemTransactionDetail.Description;
            itemTransactionDetailParallel.AccountNumber = autoBusinessParallel.DebitAccountParallel;//itemTransactionDetail.AccountNumber;
            itemTransactionDetailParallel.CorrespondingAccountNumber = autoBusinessParallel.CreditAccountParallel;//itemTransactionDetail.CorrespondingAccountNumber;
            itemTransactionDetailParallel.TotalQuantity = itemTransactionDetail.TotalQuantity;
            if (autoBusinessParallel.IsNegative)
            {
                itemTransactionDetailParallel.Price = -1 * itemTransactionDetail.Price;
                itemTransactionDetailParallel.PriceExchange = -1 * itemTransactionDetail.PriceExchange;
                itemTransactionDetailParallel.AmountOc = -1 * itemTransactionDetail.AmountOc;
                itemTransactionDetailParallel.AmountExchange = -1 * itemTransactionDetail.AmountExchange;
            }
            else
            {
                itemTransactionDetailParallel.Price = itemTransactionDetail.Price;
                itemTransactionDetailParallel.PriceExchange = itemTransactionDetail.PriceExchange;
                itemTransactionDetailParallel.AmountOc = itemTransactionDetail.AmountOc;
                itemTransactionDetailParallel.AmountExchange = itemTransactionDetail.AmountExchange;
            }
            itemTransactionDetailParallel.BudgetSourceCode = autoBusinessParallel.BudgetSourceIdParallel == 0 ? itemTransactionDetail.BudgetSourceCode : (BudgetSourceDao.GetBudgetSource(autoBusinessParallel.BudgetSourceIdParallel)?.BudgetSourceCode ?? null);
            itemTransactionDetailParallel.BudgetItemCode = autoBusinessParallel.BudgetItemIdParallel == 0 ? itemTransactionDetail.BudgetItemCode : (BudgetItemDao.GetBudgetItem(autoBusinessParallel.BudgetItemIdParallel)?.BudgetItemCode ?? null);
            itemTransactionDetailParallel.VoucherTypeId = autoBusinessParallel.VoucherTypeIdParallel == 0 ? itemTransactionDetail.VoucherTypeId : autoBusinessParallel.VoucherTypeIdParallel;
            itemTransactionDetailParallel.DepartmentId = itemTransactionDetail.DepartmentId;
            itemTransactionDetailParallel.ProjectId = itemTransactionDetail.ProjectId;
            itemTransactionDetailParallel.FixedAssetId = null;
            itemTransactionDetailParallel.InventoryItemId = itemTransactionDetail.InventoryItemId;
            itemTransactionDetailParallel.MergerFundId = itemTransactionDetail.MergerFundId;
            itemTransactionDetailParallel.AccountingObjectId = itemTransaction.AccountingObjectId;
            itemTransactionDetailParallel.EmployeeId = itemTransaction.EmployeeId;
            itemTransactionDetailParallel.CustomerId = itemTransaction.CustomerId;
            itemTransactionDetailParallel.VendorId = itemTransaction.VendorId;

            return itemTransactionDetailParallel;
        }

        #endregion
    }
}
