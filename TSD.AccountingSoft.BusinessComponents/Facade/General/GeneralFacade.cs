/***********************************************************************
 * <copyright file="GeneralFacade.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: 17 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 25/9/2014    LinhMC  Them dieu kien kiem tra trung so chung tu: neu la chuyen doi du lieu thi khong check
 * ************************************************************************/

using System;
using System.Linq;
using System.Collections.Generic;
using System.Transactions;
using TSD.AccountingSoft.BusinessComponents.Messages.General;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.Business;
using TSD.AccountingSoft.BusinessEntities.Business.General;
using TSD.AccountingSoft.DataAccess.IEntitiesDao;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.General;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary;


namespace TSD.AccountingSoft.BusinessComponents.Facade.General
{
    /// <summary>
    /// Class GeneralFacade.
    /// </summary>
    public class GeneralFacade
    {
        private static readonly IGeneralDao GeneralDao = DataAccess.DataAccess.GeneralDao;
        private static readonly IGeneralDetailDao GeneralDetailDao = DataAccess.DataAccess.GeneralDetailDao;
        private static readonly IAutoNumberDao AutoNumberDao = DataAccess.DataAccess.AutoNumberDao;
        private static readonly IJournalEntryAccountDao JournalEntryAccountDao = DataAccess.DataAccess.JournalEntryAccountDao;
        private static readonly IAccountBalanceDao AccountBalanceDao = DataAccess.DataAccess.AccountBalanceDao;
        private static readonly IBudgetSourceDao BudgetSourceDao = DataAccess.DataAccess.BudgetSourceDao;
        private static readonly IBudgetItemDao BudgetItemDao = DataAccess.DataAccess.BudgetItemDao;
        private static readonly IAutoBusinessParallelDao AutoBusinessParallelDao = DataAccess.DataAccess.AutoBusinessParallelDao;

        public GeneralReponse GetGenerals(GeneralRequest request)
        {
            var response = new GeneralReponse();
            if (request.LoadOptions.Contains("Generals"))
            {
                if (request.LoadOptions.Contains("IsCapitalAllocate"))
                    response.Generals = GeneralDao.GetGeneralByIsCapitalAllocate();
                else
                    response.Generals = GeneralDao.GetGeneralByRefTypeId(request.RefTypeId);
            }


            if (request.LoadOptions.Contains("General"))
            {
                if (request.LoadOptions.Contains("RefNo"))
                {
                    var general = GeneralDao.GetGeneralByRefNo(request.RefNo);
                    response.Generals = general;
                }
                else
                {
                    var general = GeneralDao.GetGeneral(request.RefId);
                    if (request.LoadOptions.Contains("IncludeDetail"))
                    {
                        general = general ?? new GeneralEntity();
                        general.GeneralDetails = GeneralDetailDao.GetGeneralDetailsByGeneral(general.RefId);
                        general.GeneralParalellDetails = GeneralDetailDao.GetGeneralParalellDetailsByGeneral(general.RefId);

                    }
                    response.General = general;
                }

            }
            return response;
        }
        public GeneralReponse SetGenerals(GeneralRequest request)
        {
            var response = new GeneralReponse();
            var generalEntity = request.GeneralEntity;


            var obJourentryAccount = new JournalEntryAccountEntity();
            IList<JournalEntryAccountEntity> listJournalEntryAccountEntity = new List<JournalEntryAccountEntity>();
            IList<AccountBalanceEntity> listAccountBalanceEntity = new List<AccountBalanceEntity>();
            if (request.GeneralEntity != null)
            {
                listJournalEntryAccountEntity = GetListJournalEntryAccount(request);
                listAccountBalanceEntity = GetListAccountBalance(request);
            }
            var i = 0;
            if (request.Action != PersistType.Delete)
            {
                if (!generalEntity.Validate())
                {
                    foreach (string error in generalEntity.ValidationErrors)
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

                        #region Kiểm tra sự tồn tại chứng từ trong ngày

                        List<JournalEntryAccountEntity> lstJournalEntry = JournalEntryAccountDao.GetJournalEntryAccountByRefNoRefDate(generalEntity.RefNo, generalEntity.RefDate)
                                                  .ToList();
                        if (lstJournalEntry.Count > 0)
                        {
                            if (request.IsConvertData == false)
                            {
                                response.Message = @"Chứng từ: " + generalEntity.RefNo + @" đã tồn tại trong ngày " + generalEntity.RefDate.ToShortDateString();
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }
                            var rd = new Random();
                            generalEntity.RefNo = generalEntity.RefNo + "_buca" + rd.Next(1, 1000);
                        }
                        #endregion

                        generalEntity.RefDate = generalEntity.RefDate;
                        generalEntity.RefId = GeneralDao.InsertGeneral(generalEntity);
                        foreach (var generalDetail in generalEntity.GeneralDetails)
                        {
                            if (!generalDetail.Validate())
                            {
                                foreach (string error in generalDetail.ValidationErrors)
                                    response.Message += error + Environment.NewLine;
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }
                            generalDetail.RefId = generalEntity.RefId;
                            var iCashDetailId = GeneralDetailDao.InsertGeneralDetail(generalDetail);

                            //LinhMC thêm đoạn kiểm tra việc InsertGeneralDetail có thành công hay không?
                            //Yêu cầu phải có để đảm bảo toàn vẹn dữ liệu
                            if (iCashDetailId == 0)
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }
                            // insert bang JourentryAccount
                            obJourentryAccount = listJournalEntryAccountEntity[i];
                            obJourentryAccount.RefId = generalDetail.RefId;
                            obJourentryAccount.RefDetailId = iCashDetailId;
                            obJourentryAccount.ExchangeRate = generalDetail.ExchangeRate;
                            // obJourentryAccount.JournalMemo = generalDetail.;
                            if (!obJourentryAccount.Validate())
                            {
                                foreach (string error in obJourentryAccount.ValidationErrors)
                                    response.Message += error + Environment.NewLine;
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }
                            JournalEntryAccountDao.InsertDoubleJournalEntryAccount(obJourentryAccount);
                            i = i + 1;
                        }

                        #region Sinh dinh khoan dong thoi
                        //trường hợp k sinh định khoản tự động 
                        i = 0;
                        if (!request.IsGenerateParalell)
                        {
                            foreach (var generalParalellDetail in generalEntity.GeneralParalellDetails)
                            {
                                if (!generalParalellDetail.Validate())
                                {
                                    foreach (string error in generalParalellDetail.ValidationErrors)
                                        response.Message += error + Environment.NewLine;
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    return response;
                                }
                                generalParalellDetail.RefId = generalEntity.RefId;
                                var iGeneralDetailId = GeneralDetailDao.InsertGeneralParalellDetail(generalParalellDetail);
                                //------------------------------------------------------------------
                                //LinhMC thêm đoạn kiểm tra việc InsertCashDetail có thành công hay không? 
                                //Yêu cầu phải có để đảm bảo toàn vẹn dữ liệu
                                if (iGeneralDetailId == 0)
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    return response;
                                }
                                // insert bang JourentryAccount
                                var obJourentryAccountParalell = GetListJournalEntryAccountParalell(generalEntity, generalParalellDetail);
                                obJourentryAccountParalell.RefDetailId = iGeneralDetailId;
                                #region " obJourentryAccount: thay đổi thông tin theo đối tượng Master"

                                //LinhMC bổ sung trường hợp người dùng chọn đối tượng khác ở phần chi tiết mà không chọn ở phần thông tin chung.
                                if (obJourentryAccountParalell.AccountingObjectId == null)
                                {
                                    obJourentryAccountParalell.AccountingObjectId = generalParalellDetail.AccountingObjectId;
                                }
                                #endregion

                                if (!obJourentryAccountParalell.Validate())
                                {
                                    foreach (string error in obJourentryAccountParalell.ValidationErrors)
                                        response.Message += error + Environment.NewLine;
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    return response;
                                }
                                JournalEntryAccountDao.InsertDoubleJournalEntryAccount(obJourentryAccountParalell);
                              
                            }

                        }
                        else //sinh định khoản tự động 
                        {
                            foreach (var generalDetail in generalEntity.GeneralDetails)
                            {
                                if (!generalEntity.Validate())
                                {
                                    foreach (string error in generalEntity.ValidationErrors)
                                        response.Message += error + Environment.NewLine;
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    return response;
                                }

                                var budgetSource = BudgetSourceDao.GetBudgetSourceByBudgetSourceCode(generalDetail.BudgetSourceCode);
                                var budgetItem = BudgetItemDao.GetBudgetItemsByCode(generalDetail.BudgetItemCode);
                                var autoBusinessParallelEntities = AutoBusinessParallelDao.GetAutoBusinessParallelsByAutoBussinessInformations(
                                       generalDetail.AccountNumber,
                                       generalDetail.CorrespondingAccountNumber,
                                       (generalDetail.BudgetSourceCode == null || budgetSource == null) ? 0 : budgetSource.BudgetSourceId,
                                       budgetItem.Count == 0 ? 0 : budgetItem.FirstOrDefault().BudgetItemId,
                                       0,
                                       generalDetail.VoucherTypeId == null ? 0 : (int)generalDetail.VoucherTypeId);
                                foreach ( var autoBusinessParallelEntity in autoBusinessParallelEntities)
                                {

                                    var budgetItemsParalell = BudgetItemDao.GetBudgetItem(autoBusinessParallelEntity.BudgetItemId) == null ? null : BudgetItemDao.GetBudgetItem(autoBusinessParallelEntity.BudgetItemId).BudgetItemCode;
                                    var budgetSoucreParalell = BudgetSourceDao.GetBudgetSource(autoBusinessParallelEntity.BudgetSourceId) == null ? null : BudgetSourceDao.GetBudgetSource(autoBusinessParallelEntity.BudgetSourceId).BudgetSourceCode;
                                    var generalParalellDetail = new GeneralParalellDetailEntity();

                                    generalParalellDetail.RefId = generalEntity.RefId;
                                    generalParalellDetail.AccountNumber = autoBusinessParallelEntity.DebitAccountParallel;
                                    generalParalellDetail.CorrespondingAccountNumber = autoBusinessParallelEntity.CreditAccountParallel;
                                    generalParalellDetail.AmountOc = autoBusinessParallelEntity.IsNegative == true ? generalDetail.AmountOc * (-1) : generalDetail.AmountOc;
                                    generalParalellDetail.AmountExchange = autoBusinessParallelEntity.IsNegative == true ? generalDetail.AmountExchange * (-1) : generalDetail.AmountExchange;
                                    generalParalellDetail.Description = generalDetail.Description;
                                    generalParalellDetail.AccountingObjectId = generalDetail.AccountingObjectId;
                                    generalParalellDetail.ProjectId = generalDetail.ProjectId;
                                    generalParalellDetail.IsInserted = generalDetail.IsInserted;
                                    generalParalellDetail.VoucherTypeId = autoBusinessParallelEntity.VoucherTypeId == null ? 0 : (int)autoBusinessParallelEntity.VoucherTypeIdParallel;
                                    generalParalellDetail.BudgetSourceCode = budgetSoucreParalell ??generalDetail.BudgetSourceCode;
                                    generalParalellDetail.BudgetItemCode = budgetItemsParalell ??generalDetail.BudgetItemCode;
                                    generalParalellDetail.VoucherTypeId = generalDetail.VoucherTypeId;
                                    generalParalellDetail.BankId = generalDetail.BankId;
                                    generalParalellDetail.CapitalAllocateCode = generalDetail.CapitalAllocateCode;
                                    generalParalellDetail.CurrencyCode = generalDetail.CurrencyCode;
                                    generalParalellDetail.CustomerId = generalDetail.CustomerId;
                                    generalParalellDetail.DepartmentId = generalDetail.DepartmentId;
                                    generalParalellDetail.EmployeeId = generalDetail.EmployeeId;
                                    generalParalellDetail.InventoryItemId = generalDetail.InventoryItemId;
                                    generalParalellDetail.VendorId = generalDetail.VendorId;
                                    generalParalellDetail.ExchangeRate = generalDetail.ExchangeRate;
                                    var iGeneralDetailId = GeneralDetailDao.InsertGeneralParalellDetail(generalParalellDetail);
                                    //------------------------------------------------------------------
                                    //LinhMC thêm đoạn kiểm tra việc InsertCashDetail có thành công hay không? 
                                    //Yêu cầu phải có để đảm bảo toàn vẹn dữ liệu
                                    if (iGeneralDetailId == 0)
                                    {
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        return response;
                                    }
                                    // insert bang JourentryAccount

                                    var obJourentryAccountParalell = GetListJournalEntryAccountParalell(generalEntity, generalParalellDetail);
                                    obJourentryAccountParalell.RefDetailId = iGeneralDetailId;
                                    #region " obJourentryAccount: thay đổi thông tin theo đối tượng Master"

                                    //LinhMC bổ sung trường hợp người dùng chọn đối tượng khác ở phần chi tiết mà không chọn ở phần thông tin chung.
                                    if (obJourentryAccountParalell.AccountingObjectId == null)
                                    {
                                        obJourentryAccountParalell.AccountingObjectId = generalParalellDetail.AccountingObjectId;
                                    }
                                    #endregion

                                    if (!obJourentryAccountParalell.Validate())
                                    {
                                        foreach (string error in obJourentryAccountParalell.ValidationErrors)
                                            response.Message += error + Environment.NewLine;
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        return response;
                                    }                                   
                                    JournalEntryAccountDao.InsertDoubleJournalEntryAccount(obJourentryAccountParalell);
                                  
                                }
                            }



                        }

                        #endregion


                        // Kiểm tra đã tồn tại trong bảng Account Balance
                        foreach (var accountBalanceEntity in listAccountBalanceEntity)
                        {
                            var obAccoutBalanceExit = AccountBalanceDao.GetExitsAccountBalance(accountBalanceEntity);
                            if (obAccoutBalanceExit != null)
                            {
                                // cập nhật bên TK nợ
                                if (accountBalanceEntity.MovementCreditAmountOC == 0)
                                {
                                    obAccoutBalanceExit.ExchangeRate = accountBalanceEntity.ExchangeRate;
                                    obAccoutBalanceExit.MovementDebitAmountExchange =
                                        obAccoutBalanceExit.MovementDebitAmountExchange +
                                        accountBalanceEntity.MovementDebitAmountExchange;
                                    obAccoutBalanceExit.MovementDebitAmountOC =
                                        obAccoutBalanceExit.MovementDebitAmountOC +
                                        accountBalanceEntity.MovementDebitAmountOC;
                                    AccountBalanceDao.UpdateAccountBalance(obAccoutBalanceExit);
                                }
                                else
                                {
                                    obAccoutBalanceExit.ExchangeRate = accountBalanceEntity.ExchangeRate;
                                    obAccoutBalanceExit.MovementCreditAmountExchange =
                                        obAccoutBalanceExit.MovementCreditAmountExchange +
                                        accountBalanceEntity.MovementCreditAmountExchange;
                                    obAccoutBalanceExit.MovementCreditAmountOC =
                                        obAccoutBalanceExit.MovementCreditAmountOC +
                                        accountBalanceEntity.MovementCreditAmountOC;
                                    AccountBalanceDao.UpdateAccountBalance(obAccoutBalanceExit);
                                }
                            }
                            else
                            {
                                AccountBalanceDao.InsertAccountBalance(accountBalanceEntity);
                            }
                        }
                        var autoNumber = AutoNumberDao.GetAutoNumberByRefType(generalEntity.RefTypeId);
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
                else if (request.Action == PersistType.Update)
                {
                    using (var scope = new TransactionScope())
                    {
                        #region Kiểm tra sự tồn tại chứng từ trong ngày

                        List<JournalEntryAccountEntity> lstJournalEntry = JournalEntryAccountDao.GetJournalEntryAccountByRefNoRefDate(generalEntity.RefNo, generalEntity.RefDate).ToList();
                        if (lstJournalEntry.Count > 0)
                        {
                            if (lstJournalEntry[0].RefId != generalEntity.RefId)
                            {
                                response.Message = @"Chứng từ: " + generalEntity.RefNo + @" đã tồn tại trong ngày " + generalEntity.RefDate.ToShortDateString();
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }
                        }

                        #endregion

                        // Trừ số tiền khi mà update xử lý Bảng cân đối tài khoản////////////////////////////////////
                        listAccountBalanceEntity.Clear();
                        listAccountBalanceEntity = GetListAccountBalanceOlder(generalEntity.RefId);
                        foreach (var accountBalanceEntity in listAccountBalanceEntity)
                        {
                            var obAccoutBalanceExit = AccountBalanceDao.GetExitsAccountBalance(accountBalanceEntity);
                            if (obAccoutBalanceExit != null)
                            {
                                obAccoutBalanceExit.CurrencyCode = accountBalanceEntity.CurrencyCode;

                                // cập nhật bên TK nợ
                                if (accountBalanceEntity.MovementCreditAmountOC == 0)
                                {
                                    obAccoutBalanceExit.ExchangeRate = accountBalanceEntity.ExchangeRate;
                                    obAccoutBalanceExit.MovementDebitAmountExchange =
                                        obAccoutBalanceExit.MovementDebitAmountExchange - accountBalanceEntity.MovementDebitAmountExchange;
                                    obAccoutBalanceExit.MovementDebitAmountOC =
                                        obAccoutBalanceExit.MovementDebitAmountOC - accountBalanceEntity.MovementDebitAmountOC;
                                    AccountBalanceDao.UpdateAccountBalance(obAccoutBalanceExit);
                                }
                                else
                                {
                                    obAccoutBalanceExit.ExchangeRate = accountBalanceEntity.ExchangeRate;
                                    obAccoutBalanceExit.MovementCreditAmountExchange =
                                        obAccoutBalanceExit.MovementCreditAmountExchange - accountBalanceEntity.MovementCreditAmountExchange;
                                    obAccoutBalanceExit.MovementCreditAmountOC =
                                        obAccoutBalanceExit.MovementCreditAmountOC - accountBalanceEntity.MovementCreditAmountOC;
                                    AccountBalanceDao.UpdateAccountBalance(obAccoutBalanceExit);
                                }
                            }

                        }
                        // Cập nhật lại dữ liệu vào bảng cân đối tài khoản
                        listAccountBalanceEntity.Clear();
                        listAccountBalanceEntity = GetListAccountBalance(request);
                        foreach (var accountBalanceEntity in listAccountBalanceEntity)
                        {
                            var obAccoutBalanceExit = AccountBalanceDao.GetExitsAccountBalance(accountBalanceEntity);
                            if (obAccoutBalanceExit != null)
                            {
                                obAccoutBalanceExit.CurrencyCode = accountBalanceEntity.CurrencyCode;

                                // cập nhật bên TK nợ
                                if (accountBalanceEntity.MovementCreditAmountOC == 0)
                                {
                                    obAccoutBalanceExit.ExchangeRate = accountBalanceEntity.ExchangeRate;
                                    obAccoutBalanceExit.MovementDebitAmountExchange =
                                        obAccoutBalanceExit.MovementDebitAmountExchange + accountBalanceEntity.MovementDebitAmountExchange;
                                    obAccoutBalanceExit.MovementDebitAmountOC =
                                        obAccoutBalanceExit.MovementDebitAmountOC + accountBalanceEntity.MovementDebitAmountOC;
                                    AccountBalanceDao.UpdateAccountBalance(obAccoutBalanceExit);
                                }
                                else
                                {
                                    obAccoutBalanceExit.ExchangeRate = accountBalanceEntity.ExchangeRate;
                                    obAccoutBalanceExit.MovementCreditAmountExchange =
                                        obAccoutBalanceExit.MovementCreditAmountExchange + accountBalanceEntity.MovementCreditAmountExchange;
                                    obAccoutBalanceExit.MovementCreditAmountOC =
                                        obAccoutBalanceExit.MovementCreditAmountOC + accountBalanceEntity.MovementCreditAmountOC;
                                    AccountBalanceDao.UpdateAccountBalance(obAccoutBalanceExit);
                                }
                            }
                            else
                            {
                                AccountBalanceDao.InsertAccountBalance(accountBalanceEntity);
                            }
                        }
                        // Xóa dữ liệu trống trong bảng Cân đối tài khoản
                        AccountBalanceDao.DeleteAccountBalance();

                        response.Message = GeneralDao.DeleteGeneralDetail(generalEntity.RefId);
                        if (response.Message != null)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return response;
                        }
                        response.Message = GeneralDetailDao.DeleteGeneralParalellDetailsByGeneral(generalEntity.RefId);

                        if (response.Message != null)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return response;
                        }

                        response.Message = GeneralDao.UpdateGeneral(generalEntity);
                        if (response.Message != null)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return response;
                        }
                        obJourentryAccount = listJournalEntryAccountEntity[0];
                        response.Message = JournalEntryAccountDao.DeleteJournalEntryAccount(obJourentryAccount);
                        if (response.Message != null)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return response;
                        }
                        foreach (var generalDetail in generalEntity.GeneralDetails)
                        {
                            if (!generalDetail.Validate())
                            {
                                foreach (string error in generalDetail.ValidationErrors)
                                    response.Message += error + Environment.NewLine;
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }
                            generalDetail.RefId = generalEntity.RefId;
                            var iRefDetailId = GeneralDetailDao.InsertGeneralDetail(generalDetail);
                            generalDetail.RefDetailId = iRefDetailId;
                            // Insert into JourentryAcocunt
                            obJourentryAccount = listJournalEntryAccountEntity[i];
                            obJourentryAccount.RefId = generalDetail.RefId;
                            obJourentryAccount.RefDetailId = generalDetail.RefDetailId;
                            if (!obJourentryAccount.Validate())
                            {
                                foreach (string error in obJourentryAccount.ValidationErrors)
                                    response.Message += error + Environment.NewLine;
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }
                            JournalEntryAccountDao.InsertDoubleJournalEntryAccount(obJourentryAccount);
                            i = i + 1;
                        }

                        #region Sinh dinh khoan dong thoi
                        //trường hợp k sinh định khoản tự động 
                        i = 0;
                        if (!request.IsGenerateParalell)
                        {
                            foreach (var generalParalellDetail in generalEntity.GeneralParalellDetails)
                            {
                                if (!generalParalellDetail.Validate())
                                {
                                    foreach (string error in generalParalellDetail.ValidationErrors)
                                        response.Message += error + Environment.NewLine;
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    return response;
                                }
                                generalParalellDetail.RefId = generalEntity.RefId;
                                var iGeneralDetailId = GeneralDetailDao.InsertGeneralParalellDetail(generalParalellDetail);
                                //------------------------------------------------------------------
                                //LinhMC thêm đoạn kiểm tra việc InsertCashDetail có thành công hay không? 
                                //Yêu cầu phải có để đảm bảo toàn vẹn dữ liệu
                                if (iGeneralDetailId == 0)
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    return response;
                                }
                                // insert bang JourentryAccount
                                var obJourentryAccountParalell = GetListJournalEntryAccountParalell(generalEntity, generalParalellDetail);
                                obJourentryAccountParalell.RefDetailId = iGeneralDetailId;
                                #region " obJourentryAccount: thay đổi thông tin theo đối tượng Master"

                                //LinhMC bổ sung trường hợp người dùng chọn đối tượng khác ở phần chi tiết mà không chọn ở phần thông tin chung.
                                if (obJourentryAccountParalell.AccountingObjectId == null)
                                {
                                    obJourentryAccountParalell.AccountingObjectId = generalParalellDetail.AccountingObjectId;
                                }
                                #endregion

                                if (!obJourentryAccountParalell.Validate())
                                {
                                    foreach (string error in obJourentryAccountParalell.ValidationErrors)
                                        response.Message += error + Environment.NewLine;
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    return response;
                                }
                                JournalEntryAccountDao.InsertDoubleJournalEntryAccount(obJourentryAccountParalell);
                                i = i + 1;
                            }

                        }
                        else //sinh định khoản tự động 
                        {
                            foreach (var generalDetail in generalEntity.GeneralDetails)
                            {
                                if (!generalEntity.Validate())
                                {
                                    foreach (string error in generalEntity.ValidationErrors)
                                        response.Message += error + Environment.NewLine;
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    return response;
                                }

                                var budgetSource = BudgetSourceDao.GetBudgetSourceByBudgetSourceCode(generalDetail.BudgetSourceCode);
                                var budgetItem = BudgetItemDao.GetBudgetItemsByCode(generalDetail.BudgetItemCode);
                                var autoBusinessParallelEntities = AutoBusinessParallelDao.GetAutoBusinessParallelsByAutoBussinessInformations(
                                       generalDetail.AccountNumber,
                                       generalDetail.CorrespondingAccountNumber,
                                       (generalDetail.BudgetSourceCode == null || budgetSource == null) ? 0 : budgetSource.BudgetSourceId,
                                       budgetItem.Count == 0 ? 0 : budgetItem.FirstOrDefault().BudgetItemId,
                                       0,
                                       generalDetail.VoucherTypeId == null ? 0 : (int)generalDetail.VoucherTypeId);
                                foreach ( var autoBusinessParallelEntity in autoBusinessParallelEntities)
                                {
                                    
                                    var budgetItemsParalell = BudgetItemDao.GetBudgetItem(autoBusinessParallelEntity.BudgetItemId) == null ? null : BudgetItemDao.GetBudgetItem(autoBusinessParallelEntity.BudgetItemId).BudgetItemCode;
                                    var budgetSoucreParalell = BudgetSourceDao.GetBudgetSource(autoBusinessParallelEntity.BudgetSourceId) == null ? null : BudgetSourceDao.GetBudgetSource(autoBusinessParallelEntity.BudgetSourceId).BudgetSourceCode;
                                    var generalParalellDetail = new GeneralParalellDetailEntity();

                                    generalParalellDetail.RefId = generalEntity.RefId;
                                    generalParalellDetail.AccountNumber = autoBusinessParallelEntity.DebitAccountParallel;
                                    generalParalellDetail.CorrespondingAccountNumber = autoBusinessParallelEntity.CreditAccountParallel;
                                    generalParalellDetail.AmountOc = autoBusinessParallelEntity.IsNegative == true ? generalDetail.AmountOc * (-1) : generalDetail.AmountOc;
                                    generalParalellDetail.AmountExchange = autoBusinessParallelEntity.IsNegative == true ? generalDetail.AmountExchange * (-1) : generalDetail.AmountExchange;
                                    generalParalellDetail.Description = generalDetail.Description;
                                    generalParalellDetail.AccountingObjectId = generalDetail.AccountingObjectId;
                                    generalParalellDetail.ProjectId = generalDetail.ProjectId;
                                    generalParalellDetail.IsInserted = generalDetail.IsInserted;
                                    generalParalellDetail.VoucherTypeId = autoBusinessParallelEntity.VoucherTypeId == null ? 0 : (int)autoBusinessParallelEntity.VoucherTypeIdParallel;
                                    generalParalellDetail.BudgetSourceCode = budgetSoucreParalell ??generalDetail.BudgetSourceCode;
                                    generalParalellDetail.BudgetItemCode = budgetItemsParalell ?? generalDetail.BudgetItemCode;
                                    generalParalellDetail.VoucherTypeId = generalDetail.VoucherTypeId;
                                    generalParalellDetail.BankId = generalDetail.BankId;
                                    generalParalellDetail.CapitalAllocateCode = generalDetail.CapitalAllocateCode;
                                    generalParalellDetail.CurrencyCode = generalDetail.CurrencyCode;
                                    generalParalellDetail.CustomerId = generalDetail.CustomerId;
                                    generalParalellDetail.DepartmentId = generalDetail.DepartmentId;
                                    generalParalellDetail.EmployeeId = generalDetail.EmployeeId;
                                    generalParalellDetail.InventoryItemId = generalDetail.InventoryItemId;
                                    generalParalellDetail.VendorId = generalDetail.VendorId;
                                    generalParalellDetail.ExchangeRate = generalDetail.ExchangeRate;

                                    var iGeneralDetailId = GeneralDetailDao.InsertGeneralParalellDetail(generalParalellDetail);
                                    //------------------------------------------------------------------
                                    //LinhMC thêm đoạn kiểm tra việc InsertCashDetail có thành công hay không? 
                                    //Yêu cầu phải có để đảm bảo toàn vẹn dữ liệu
                                    if (iGeneralDetailId == 0)
                                    {
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        return response;
                                    }
                                    // insert bang JourentryAccount
                                    var obJourentryAccountParalell = GetListJournalEntryAccountParalell(generalEntity, generalParalellDetail);
                                    obJourentryAccountParalell.RefDetailId = iGeneralDetailId;
                                    #region " obJourentryAccount: thay đổi thông tin theo đối tượng Master"

                                    //LinhMC bổ sung trường hợp người dùng chọn đối tượng khác ở phần chi tiết mà không chọn ở phần thông tin chung.
                                    if (obJourentryAccountParalell.AccountingObjectId == null)
                                    {
                                        obJourentryAccountParalell.AccountingObjectId = generalParalellDetail.AccountingObjectId;
                                    }
                                    #endregion

                                    if (!obJourentryAccountParalell.Validate())
                                    {
                                        foreach (string error in obJourentryAccountParalell.ValidationErrors)
                                            response.Message += error + Environment.NewLine;
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        return response;
                                    }
                                    JournalEntryAccountDao.InsertDoubleJournalEntryAccount(obJourentryAccountParalell);
                                }
                            }



                        }

                        #endregion

                        scope.Complete();
                    }
                }
                else
                {
                    using (var scope = new TransactionScope())
                    {
                        var details = GeneralDetailDao.GetGeneralDetailsByGeneral(request.RefId);
                        var generalEntityForDelete = GeneralDao.GetGeneral(request.RefId);
                        response.Message = GeneralDao.DeleteGeneral(generalEntityForDelete);
                        if (string.IsNullOrEmpty(response.Message))
                            generalEntity = generalEntityForDelete;
                        // Xóa bảng JourentryAccount
                        obJourentryAccount.RefId = generalEntityForDelete.RefId;
                        obJourentryAccount.RefTypeId = generalEntityForDelete.RefTypeId;
                        obJourentryAccount.RefNo = generalEntityForDelete.RefNo;
                        response.Message = JournalEntryAccountDao.DeleteJournalEntryAccount(obJourentryAccount);
                        // Cập nhật lại dữ liệu vào bảng cân đối tài khoản
                        listAccountBalanceEntity.Clear();
                        request.GeneralEntity = generalEntityForDelete;
                        request.GeneralEntity.GeneralDetails = details;
                        listAccountBalanceEntity = GetListAccountBalance(request);
                        foreach (var accountBalanceEntity in listAccountBalanceEntity)
                        {
                            var obAccoutBalanceExit = AccountBalanceDao.GetExitsAccountBalance(accountBalanceEntity);
                            if (obAccoutBalanceExit != null)
                            {
                                obAccoutBalanceExit.CurrencyCode = accountBalanceEntity.CurrencyCode;
                                // cập nhật bên TK nợ
                                if (accountBalanceEntity.MovementCreditAmountOC == 0)
                                {
                                    obAccoutBalanceExit.ExchangeRate = accountBalanceEntity.ExchangeRate;
                                    obAccoutBalanceExit.MovementDebitAmountExchange =
                                        obAccoutBalanceExit.MovementDebitAmountExchange - accountBalanceEntity.MovementDebitAmountExchange;
                                    obAccoutBalanceExit.MovementDebitAmountOC =
                                        obAccoutBalanceExit.MovementDebitAmountOC - accountBalanceEntity.MovementDebitAmountOC;
                                    AccountBalanceDao.UpdateAccountBalance(obAccoutBalanceExit);
                                }
                                else
                                {
                                    obAccoutBalanceExit.ExchangeRate = accountBalanceEntity.ExchangeRate;
                                    obAccoutBalanceExit.MovementCreditAmountExchange =
                                        obAccoutBalanceExit.MovementCreditAmountExchange - accountBalanceEntity.MovementCreditAmountExchange;
                                    obAccoutBalanceExit.MovementCreditAmountOC =
                                        obAccoutBalanceExit.MovementCreditAmountOC - accountBalanceEntity.MovementCreditAmountOC;
                                    AccountBalanceDao.UpdateAccountBalance(obAccoutBalanceExit);
                                }
                            }
                        }
                        // Xóa dữ liệu trống trong bảng Cân đối tài khoản
                        AccountBalanceDao.DeleteAccountBalance();

                        scope.Complete();
                        scope.Dispose();
                    }

                }
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }

            response.RefId = generalEntity != null ? generalEntity.RefId : 0;
            response.Acknowledge = response.Message != null ? AcknowledgeType.Failure : AcknowledgeType.Success;
            return response;
        }

        public GeneralEntity GetGeneralVoucher(int refType, long refForeignId)
        {
            return GeneralDao.GetGeneralVoucher(refType, refForeignId);
        }

        /// <summary>
        /// Gets the list journal entry account entity.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>IList&lt;JournalEntryAccountEntity&gt;.</returns>
        public IList<JournalEntryAccountEntity> GetListJournalEntryAccount(GeneralRequest request)
        {
            var generalEntity = request.GeneralEntity;

            return (from generalDetail in generalEntity.GeneralDetails
                    select new JournalEntryAccountEntity
                    {
                        RefId = generalEntity.RefId,
                        RefTypeId = generalEntity.RefTypeId,
                        RefNo = generalEntity.RefNo,
                        RefDate = generalEntity.RefDate,
                        PostedDate = generalEntity.PostedDate,
                        RefDetailId = (long)generalDetail.RefDetailId,
                        AmountOc = generalDetail.AmountOc,
                        Description = generalDetail.Description,
                        AmountExchange = generalDetail.AmountExchange,
                        BudgetSourceCode = generalDetail.BudgetSourceCode,
                        BudgetItemCode = generalDetail.BudgetItemCode,
                        AccountingObjectId = generalDetail.AccountingObjectId,
                        VoucherTypeId = generalDetail.VoucherTypeId,
                        VendorId = generalDetail.VendorId,
                        CurrencyCode = generalDetail.CurrencyCode,
                        AccountNumber = generalDetail.AccountNumber,
                        CorrespondingAccountNumber = generalDetail.CorrespondingAccountNumber,
                        ProjectId = generalDetail.ProjectId,
                        EmployeeId = generalDetail.EmployeeId,
                        ExchangeRate = generalDetail.ExchangeRate,
                        CustomerId = generalDetail.CustomerId,
                        JournalMemo = generalEntity.JournalMemo,
                        BankId = generalDetail.BankId,
                        InventoryItemId = generalDetail.InventoryItemId
                    }).ToList();
        }

        /// <summary>
        /// Gets the list account balance.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>IList&lt;AccountBalanceEntity&gt;.</returns>
        public IList<AccountBalanceEntity> GetListAccountBalance(GeneralRequest request)
        {
            var generalEntity = request.GeneralEntity;
            IList<AccountBalanceEntity> obListAccountBalanceEntity = new List<AccountBalanceEntity>();
            foreach (var generalDetailEntity in generalEntity.GeneralDetails)
            {
                var obAccountBalanceEntity = new AccountBalanceEntity
                {
                    BalanceDate = generalEntity.PostedDate,
                    CurrencyCode = generalDetailEntity.CurrencyCode,
                    ExchangeRate = generalDetailEntity.ExchangeRate,
                    AccountNumber = generalDetailEntity.AccountNumber,
                    MovementDebitAmountOC = generalDetailEntity.AmountOc,
                    MovementDebitAmountExchange = generalDetailEntity.AmountExchange,
                    BudgetSourceCode = generalDetailEntity.BudgetSourceCode,
                    BudgetItemCode = generalDetailEntity.BudgetItemCode,
                    CustomerId = generalDetailEntity.CustomerId,
                    VendorId = generalDetailEntity.VendorId,
                    EmployeeId = generalDetailEntity.EmployeeId,
                    AccountingObjectId = generalDetailEntity.AccountingObjectId,
                    ProjectId = generalDetailEntity.ProjectId == 0 ? null : generalDetailEntity.ProjectId,
                    MovementCreditAmountOC = 0,
                    MovementCreditAmountExchange = 0,
                    InventoryItemId = generalDetailEntity.InventoryItemId

                };
                //Dòng tài khoản nợ
                obListAccountBalanceEntity.Add(obAccountBalanceEntity);
                // Dòng tài khoản có
                var obAccountBalanceEntity1 = new AccountBalanceEntity
                {
                    BalanceDate = generalEntity.PostedDate,
                    CurrencyCode = generalDetailEntity.CurrencyCode,
                    ExchangeRate = generalDetailEntity.ExchangeRate,
                    AccountNumber = generalDetailEntity.CorrespondingAccountNumber,
                    MovementCreditAmountOC = generalDetailEntity.AmountOc,
                    MovementCreditAmountExchange = generalDetailEntity.AmountExchange,
                    BudgetSourceCode = generalDetailEntity.BudgetSourceCode,
                    BudgetItemCode = generalDetailEntity.BudgetItemCode,
                    CustomerId = generalDetailEntity.CustomerId,
                    VendorId = generalDetailEntity.VendorId,
                    EmployeeId = generalDetailEntity.EmployeeId,
                    AccountingObjectId = generalDetailEntity.AccountingObjectId,
                    ProjectId = generalDetailEntity.ProjectId == 0 ? null : generalDetailEntity.ProjectId,
                    MovementDebitAmountOC = 0,
                    MovementDebitAmountExchange = 0,
                    InventoryItemId = generalDetailEntity.InventoryItemId

                };

                obListAccountBalanceEntity.Add(obAccountBalanceEntity1);

            }

            return obListAccountBalanceEntity;
        }

        /// <summary>
        /// Gets the list account balance older.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>IList&lt;AccountBalanceEntity&gt;.</returns>
        public IList<AccountBalanceEntity> GetListAccountBalanceOlder(long refId)
        {
            var generalEntity = GeneralDao.GetGeneral(refId);
            generalEntity.GeneralDetails = GeneralDetailDao.GetGeneralDetailsByGeneral(refId);
            IList<AccountBalanceEntity> obListAccountBalanceEntity = new List<AccountBalanceEntity>();
            foreach (var generalDetail in generalEntity.GeneralDetails)
            {
                var obAccountBalanceEntity = new AccountBalanceEntity
                {
                    BalanceDate = generalEntity.PostedDate,
                    AccountNumber = generalDetail.AccountNumber,
                    MovementCreditAmountOC = 0,
                    MovementCreditAmountExchange = 0,
                    BudgetSourceCode = generalDetail.BudgetSourceCode,
                    BudgetItemCode = generalDetail.BudgetItemCode,
                    ProjectId = generalDetail.ProjectId == 0 ? null : generalDetail.ProjectId,
                    CustomerId = generalDetail.CustomerId == 0 ? null : generalDetail.CustomerId,
                    EmployeeId = generalDetail.EmployeeId == 0 ? null : generalDetail.EmployeeId,
                    VendorId = generalDetail.VendorId == 0 ? null : generalDetail.VendorId,
                    AccountingObjectId = generalDetail.AccountingObjectId == 0 ? null : generalDetail.AccountingObjectId,
                    CurrencyCode = generalDetail.CurrencyCode,
                    ExchangeRate = generalDetail.ExchangeRate,
                    MovementDebitAmountOC = generalDetail.AmountOc,
                    MovementDebitAmountExchange = generalDetail.AmountExchange,
                };
                //Dòng tài khoản nợ
                obListAccountBalanceEntity.Add(obAccountBalanceEntity);
                // Dòng tài khoản có
                var obAccountBalanceEntity1 = new AccountBalanceEntity
                {
                    BalanceDate = generalEntity.PostedDate,
                    AccountNumber = generalDetail.CorrespondingAccountNumber,
                    MovementCreditAmountOC = generalDetail.AmountOc,
                    MovementCreditAmountExchange = generalDetail.AmountExchange,
                    BudgetSourceCode = generalDetail.BudgetSourceCode,
                    BudgetItemCode = generalDetail.BudgetItemCode,
                    ProjectId = generalDetail.ProjectId == 0 ? null : generalDetail.ProjectId,
                    CustomerId = generalDetail.CustomerId == 0 ? null : generalDetail.CustomerId,
                    EmployeeId = generalDetail.EmployeeId == 0 ? null : generalDetail.EmployeeId,
                    VendorId = generalDetail.VendorId == 0 ? null : generalDetail.VendorId,
                    AccountingObjectId = generalDetail.AccountingObjectId == 0 ? null : generalDetail.AccountingObjectId,
                    CurrencyCode = generalDetail.CurrencyCode,
                    ExchangeRate = generalDetail.ExchangeRate,
                    MovementDebitAmountOC = 0,
                    MovementDebitAmountExchange = 0,

                };

                obListAccountBalanceEntity.Add(obAccountBalanceEntity1);
            }

            return obListAccountBalanceEntity;
        }

        public JournalEntryAccountEntity GetListJournalEntryAccountParalell(GeneralEntity generalEntity, GeneralParalellDetailEntity generalParalellDetailEntity)
        {

            var journalEntryAccount = new JournalEntryAccountEntity();

            if (generalParalellDetailEntity != null)
            {


                journalEntryAccount.RefId = generalEntity.RefId;
                journalEntryAccount.RefTypeId = generalEntity.RefTypeId;
                journalEntryAccount.RefNo = generalEntity.RefNo;
                journalEntryAccount.RefDate = generalEntity.RefDate;
                journalEntryAccount.PostedDate = generalEntity.PostedDate;
                journalEntryAccount.RefDetailId = (long)generalParalellDetailEntity.RefDetailId;
                journalEntryAccount.AmountOc = generalParalellDetailEntity.AmountOc;
                journalEntryAccount.Description = generalParalellDetailEntity.Description;
                journalEntryAccount.AmountExchange = generalParalellDetailEntity.AmountExchange;
                journalEntryAccount.BudgetSourceCode = generalParalellDetailEntity.BudgetSourceCode;
                journalEntryAccount.BudgetItemCode = generalParalellDetailEntity.BudgetItemCode;
                journalEntryAccount.AccountingObjectId = generalParalellDetailEntity.AccountingObjectId;
                journalEntryAccount.VoucherTypeId = generalParalellDetailEntity.VoucherTypeId;
                journalEntryAccount.VendorId = generalParalellDetailEntity.VendorId;
                journalEntryAccount.CurrencyCode = generalParalellDetailEntity.CurrencyCode;
                journalEntryAccount.AccountNumber = generalParalellDetailEntity.AccountNumber;
                journalEntryAccount.CorrespondingAccountNumber = generalParalellDetailEntity.CorrespondingAccountNumber;
                journalEntryAccount.ProjectId = generalParalellDetailEntity.ProjectId;
                journalEntryAccount.EmployeeId = generalParalellDetailEntity.EmployeeId;
                journalEntryAccount.ExchangeRate = generalParalellDetailEntity.ExchangeRate;
                journalEntryAccount.CustomerId = generalParalellDetailEntity.CustomerId;
                journalEntryAccount.JournalMemo = generalEntity.JournalMemo;
                journalEntryAccount.BankId = generalParalellDetailEntity.BankId;
                journalEntryAccount.InventoryItemId = generalParalellDetailEntity.InventoryItemId;
            }
            return journalEntryAccount;
        }
    }
}
