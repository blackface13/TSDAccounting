/***********************************************************************
 * <copyright file="Mapper.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 08 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using TSD.AccountingSoft.BusinessEntities.Business;
using TSD.AccountingSoft.BusinessEntities.Business.Cash;
using TSD.AccountingSoft.BusinessEntities.Business.FixedAsset;
using TSD.AccountingSoft.BusinessEntities.Business.General;
using TSD.AccountingSoft.BusinessEntities.Business.Deposit;
using TSD.AccountingSoft.BusinessEntities.Business.Estimate;
using TSD.AccountingSoft.BusinessEntities.Business.FixedAssetArmortization;
using TSD.AccountingSoft.BusinessEntities.Business.FixedAssetIncrement;
using TSD.AccountingSoft.BusinessEntities.Business.Inventory;
using TSD.AccountingSoft.BusinessEntities.Business.Opening;
using TSD.AccountingSoft.BusinessEntities.Business.Search;
using TSD.AccountingSoft.BusinessEntities.Dictionary;
using TSD.AccountingSoft.BusinessEntities.Report;
using TSD.AccountingSoft.BusinessEntities.Report.Estimate;
using TSD.AccountingSoft.BusinessEntities.Report.Finacial;
using TSD.AccountingSoft.BusinessEntities.Report.FixedAsset;
using TSD.AccountingSoft.BusinessEntities.Report.Voucher;
using TSD.AccountingSoft.BusinessEntities.Salary;
using TSD.AccountingSoft.Model.BusinessObjects.Cash;
using TSD.AccountingSoft.Model.BusinessObjects.Deposit;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Model.BusinessObjects.Estimate;
using TSD.AccountingSoft.Model.BusinessObjects.FixedAsset;
using TSD.AccountingSoft.Model.BusinessObjects.Inventory;
using TSD.AccountingSoft.Model.BusinessObjects.Opening;
using TSD.AccountingSoft.Model.BusinessObjects.Report;
using TSD.AccountingSoft.Model.BusinessObjects.Report.Estimate;
using TSD.AccountingSoft.Model.BusinessObjects.Report.Finacial;
using TSD.AccountingSoft.Model.BusinessObjects.Report.FixedAsset;
using TSD.AccountingSoft.Model.BusinessObjects.Report.Voucher;
using TSD.AccountingSoft.Model.BusinessObjects.Salary;
using TSD.AccountingSoft.Model.BusinessObjects.General;
using TSD.AccountingSoft.BusinessEntities.Business.FixedAssetDecrement;
using System;
using System.Collections.Generic;
using System.Linq;
using TSD.AccountingSoft.Model.BusinessObjects.Search;
using TSD.AccountingSoft.Model.BusinessObjects.System;
using TSD.AccountingSoft.BusinessEntities.System;


namespace TSD.AccountingSoft.Model.DataTransferObjectMapper
{
    /// <summary>
    /// Class Mapper.
    /// </summary>
    public class Mapper
    {
        #region FromDataTransferObject

        internal static LockModel FromDataTransferObject(LockEntity entity)
        {
            if (entity == null) return null;
            return new LockModel
            {
                LockDate = entity.LockDate,
                IsLock = entity.IsLock,
                Content = entity.Content
            };
        }

        internal static SalaryVoucherModel FromDataTransferObject(SalaryVoucherEntity entity)
        {
            if (entity == null) return null;
            return new SalaryVoucherModel
            {
                RefTypeId = entity.RefTypeId,
                PostedDate = entity.PostedDate,
                RefNo = entity.RefNo
            };
        }

        internal static AutoNumberListModel FromDataTransferObject(AutoNumberListEntity entity)
        {
            if (entity == null) return null;
            return new AutoNumberListModel
            {
                TableCode = entity.TableCode,
                LengthOfValue = entity.LengthOfValue,
                Prefix = entity.Prefix,
                Suffix = entity.Suffix,
                TableName = entity.TableName,
                Value = entity.Value
            };
        }

        internal static ElectricalWorkModel FromDataTransferObject(ElectricalWorkEntity model)
        {
            if (model == null) return null;
            return new ElectricalWorkModel
            {
                ElectricalWorkId = model.ElectricalWorkId,
                Name = model.Name,
                PostedDate = model.PostedDate
            };
        }

        internal static MutualModel FromDataTransferObject(MutualEntity model)
        {
            if (model == null) return null;
            return new MutualModel
            {
                Address = model.Address,
                Area = model.Area,
                Description = model.Description,
                IsActive = model.IsActive,
                JobCandidate = model.JobCandidate,
                MutualCode = model.MutualCode,
                MutualId = model.MutualId,
                MutualName = model.MutualName,
                State = model.State,
                TotalFloor = model.TotalFloor,
                UseDate = model.UseDate

            };
        }


        /// <summary>
        /// Froms the payment detail data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static ItemTransactionDetailModel FromDataTransferObject(ItemTransactionDetailEntity model)
        {
            if (model == null) return null;
            return new ItemTransactionDetailModel
            {
                RefDetailId = model.RefDetailId,
                InventoryItemId = model.InventoryItemId,
                AccountNumber = model.AccountNumber,
                CorrespondingAccountNumber = model.CorrespondingAccountNumber,
                Description = model.Description,
                AmountOc = model.AmountOc,
                AmountExchange = model.AmountExchange,
                VoucherTypeId = model.VoucherTypeId,
                BudgetSourceCode = model.BudgetSourceCode,
                BudgetItemCode = model.BudgetItemCode,
                AccountingObjectId = model.AccountingObjectId,
                MergerFundId = model.MergerFundId,
                ProjectId = model.ProjectId,
                RefId = model.RefId,
                Quantity = model.Quantity,
                Price = model.Price,
                PriceExchange = model.PriceExchange,
                FreeQuantity = model.FreeQuantity,
                CancelQuantity = model.CancelQuantity,
                TotalQuantity = model.TotalQuantity,
                DepartmentId = model.DepartmentId
            };
        }

        /// <summary>
        /// Froms the payment data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static ItemTransactionModel FromDataTransferObject(ItemTransactionEntity entity)
        {
            if (entity == null) return null;

            return new ItemTransactionModel
            {
                RefId = entity.RefId,
                RefTypeId = entity.RefTypeId,
                RefNo = entity.RefNo,
                RefDate = entity.RefDate,
                PostedDate = entity.PostedDate,
                AccountingObjectId = entity.AccountingObjectId,
                CustomerId = entity.CustomerId,
                VendorId = entity.VendorId,
                EmployeeId = entity.EmployeeId,
                Trader = entity.Trader,
                CurrencyCode = entity.CurrencyCode,
                StockId = entity.StockId,
                TotalAmount = entity.TotalAmount,
                ExchangeRate = entity.ExchangeRate,
                TotalAmountExchange = entity.TotalAmountExchange,
                JournalMemo = entity.JournalMemo,
                DocumentInclude = entity.DocumentInclude,
                AccountingObjectType = entity.AccountingObjectType,
                TaxCode = entity.TaxCode,
                BankId = entity.BankId,
                IsCalculatePrice = entity.IsCalculatePrice,
                ItemTransactionDetails = entity.ItemTransactionDetails == null ? null : FromDataTransferObjects(entity.ItemTransactionDetails)
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static SalaryModel FromDataTransferObject(SalaryEntity entity)
        {
            if (entity == null) return null;

            return new SalaryModel
            {
                EmployeePayrollId = entity.EmployeePayrollId,
                RefTypeId = entity.RefTypeId,
                RefNo = entity.RefNo,
                RefDate = entity.RefDate.ToShortDateString(),
                TotalAmountOc = entity.TotalAmountOc,
                PostedDate = entity.PostedDate.ToShortDateString(),
                CurrencyCode = entity.CurrencyCode,
                JournalMemo = entity.JournalMemo,
                EmployeeId = entity.EmployeeId,
                ExchangeRate = entity.ExchangeRate,
                TotalAmountExchange = entity.TotalAmountExchange,
                Employees = entity.Employees == null ? null : FromDataTransferObjects(entity.Employees)
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static CapitalAllocateModel FromDataTransferObject(CapitalAllocateEntity entity)
        {
            if (entity == null) return null;

            return new CapitalAllocateModel
            {
                CapitalAllocateId = entity.CapitalAllocateId,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetSourceCode = entity.BudgetSourceCode,
                ActivityId = entity.Activityid,
                AllocatePercent = entity.AllocatePercent,
                AllocateType = entity.AllocateType,
                //  DeterminedDate = entity.DeterminedDate,
                DeterminedDate = entity.DeterminedDate == null ? null : DateTime.Parse(entity.DeterminedDate.ToString()).ToShortDateString(),

                CapitalAccountCode = entity.CapitalAccountCode,
                RevenueAccountCode = entity.RevenueAccountCode,
                ExpenseAccountCode = entity.ExpenseAccountCode,
                Description = entity.Description,
                IsActive = entity.IsActive,
                WaitBudgetSourceCode = entity.WaitBudgetSourceCode,
                CapitalAllocateCode = entity.CapitalAllocateCode,
                FromDate = entity.FromDate.ToShortDateString(),
                ToDate = entity.ToDate.ToShortDateString(),
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static OpeningSupplyEntryModel FromDataTransferObjectOpeningSupply(OpeningSupplyEntryEntity entity)
        {
            if (entity == null) return null;

            return new OpeningSupplyEntryModel
            {
                RefId = entity.RefId,
                RefType = entity.RefType,
                PostedDate = entity.PostedDate,
                ExchangeRate = entity.ExchangeRate,
                AccountNumber = entity.AccountNumber,
                InventoryItemId = entity.InventoryItemId,
                DepartmentId = entity.DepartmentId,
                Quantity = entity.Quantity,
                UnitPriceOc = entity.UnitPriceOc,
                UnitPriceExchange = entity.UnitPriceExchange,
                AmountOc = entity.AmountOc,
                AmountExchange = entity.AmountExchange,
                SortOrder = entity.SortOrder,
                CurrencyCode = entity.CurrencyCode,
                RefDate = entity.RefDate,
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static CurrencyModel FromDataTransferObject(CurrencyEntity entity)
        {
            if (entity == null) return null;

            return new CurrencyModel
            {
                CurrencyId = entity.CurrencyId,
                CurrencyCode = entity.CurrencyCode,
                CurrencyName = entity.CurrencyName,
                Prefix = entity.Prefix,
                Suffix = entity.Suffix,
                IsMain = entity.IsMain,
                IsActive = entity.IsActive
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static BudgetSourcePropertyModel FromDataTransferObject(BudgetSourcePropertyEntity entity)
        {
            if (entity == null) return null;

            return new BudgetSourcePropertyModel
            {
                BudgetSourcePropertyID = entity.BudgetSourcePropertyID,
                BudgetSourcePropertyCode = entity.BudgetSourcePropertyCode,
                BudgetSourcePropertyName = entity.BudgetSourcePropertyName,
                Description = entity.Description,
                IsActive = entity.IsActive,
                IsSystem = entity.IsSystem
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static AccountModel FromDataTransferObject(AccountEntity entity)
        {
            if (entity == null) return null;

            return new AccountModel
            {
                AccountId = entity.AccountId,
                AccountCategoryId = entity.AccountCategoryId,
                AccountCode = entity.AccountCode,
                AccountName = entity.AccountName,
                ForeignName = entity.ForeignName,
                ParentId = entity.ParentId,
                Grade = entity.Grade,
                IsDetail = entity.IsDetail,
                Description = entity.Description,
                BalanceSide = entity.BalanceSide,
                ConcomitantAccount = entity.ConcomitantAccount,
                BankId = entity.BankId,
                CurrencyCode = entity.CurrencyCode,
                IsChapter = entity.IsChapter,
                IsBudgetCategory = entity.IsBudgetCategory,
                IsBudgetItem = entity.IsBudgetItem,
                IsBudgetGroup = entity.IsBudgetGroup,
                IsBudgetSource = entity.IsBudgetSource,
                IsActivity = entity.IsActivity,
                IsCurrency = entity.IsCurrency,
                IsCustomer = entity.IsCustomer,
                IsVendor = entity.IsVendor,
                IsEmployee = entity.IsEmployee,
                IsAccountingObject = entity.IsAccountingObject,
                IsInventoryItem = entity.IsInventoryItem,
                IsFixedAsset = entity.IsFixedAsset,
                IsCapitalAllocate = entity.IsCapitalAllocate,
                IsActive = entity.IsActive,
                IsSystem = entity.IsSystem,
                IsAllowinputcts = entity.IsAllowinputcts,
                IsProject = entity.IsProject,
                IsBudgetSubItem = entity.IsBudgetSubItem,
                IsBank = entity.IsBank
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static AccountCategoryModel FromDataTransferObject(AccountCategoryEntity entity)
        {
            if (entity == null) return null;

            return new AccountCategoryModel
            {
                AccountCategoryId = entity.AccountCategoryId,
                AccountCategoryCode = entity.AccountCategoryCode,
                AccountCategoryName = entity.AccountCategoryName,
                ParentId = entity.ParentId,
                Grade = entity.Grade,
                IsDetail = entity.IsDetail,
                IsActive = entity.IsActive
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static AutoNumberModel FromDataTransferObject(AutoNumberEntity entity)
        {
            if (entity == null) return null;

            return new AutoNumberModel
            {
                RefTypeId = entity.RefTypeId,
                Prefix = entity.Prefix,
                Suffix = entity.Suffix,
                Value = entity.Value,
                ValueLocalCurency = entity.ValueLocalCurency,
                LengthOfValue = entity.LengthOfValue
            };
        }

        internal static CalculateClosingModel FromDataTransferObject(CalculateClosingEntity entity)
        {
            if (entity == null) return null;

            return new CalculateClosingModel
            {
                AccountId = entity.AccountId,
                AccountCode = entity.AccountCode,
                AccountName = entity.AccountName,
                ParentId = entity.AccountId,
                ClosingAmount = entity.ClosingAmounts,
            };
        }


        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static DepartmentModel FromDataTransferObject(DepartmentEntity entity)
        {
            if (entity == null) return null;

            return new DepartmentModel
            {
                DepartmentId = entity.DepartmentId,
                DepartmentCode = entity.DepartmentCode,
                DepartmentName = entity.DepartmentName,
                Description = entity.Description,
                IsActive = entity.IsActive,
                ParentId = entity.ParentId
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static BudgetSourceCategoryModel FromDataTransferObject(BudgetSourceCategoryEntity entity)
        {
            if (entity == null) return null;

            return new BudgetSourceCategoryModel
            {
                BudgetSourceCategoryId = entity.BudgetSourceCategoryId,
                BudgetSourceCategoryCode = entity.BudgetSourceCategoryCode,
                BudgetSourceCategoryName = entity.BudgetSourceCategoryName,
                Description = entity.Description,
                IsActive = entity.IsActive,
                ForeignName = entity.ForeignName,
                IsSummaryEstimateReport = entity.IsSummaryEstimateReport
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static BudgetItemModel FromDataTransferObject(BudgetItemEntity entity)
        {
            if (entity == null) return null;
            return new BudgetItemModel
            {
                BudgetItemId = entity.BudgetItemId,
                BudgetGroupId = entity.BudgetGroupId,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetItemName = entity.BudgetItemName,
                ForeignName = entity.ForeignName,
                ParentId = entity.ParentId,
                IsParent = entity.IsParent,
                IsActive = entity.IsActive,
                IsExpandItem = entity.IsExpandItem,
                IsFixedItem = entity.IsFixedItem,
                IsNoAllocate = entity.IsNoAllocate,
                IsOrganItem = entity.IsOrganItem,
                BudgetItemType = entity.BudgetItemType,
                IsReceipt = entity.IsReceipt,
                Rate = entity.Rate,
                NumberOrder = entity.NumberOrder
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static PlanTemplateListModel FromDataTransferObject(PlanTemplateListEntity entity)
        {
            if (entity == null) return null;
            return new PlanTemplateListModel
            {
                PlanTemplateListId = entity.PlanTemplateListId,
                PlanTemplateListCode = entity.PlanTemplateListCode,
                PlanTemplateListName = entity.PlanTemplateListName,
                PlanType = entity.PlanType,
                PlanYear = entity.PlanYear,
                ParentId = entity.ParentId,
                PlanTemplateItems = entity.PlanTemplateItems == null ? null : FromDataTransferObjects(entity.PlanTemplateItems)
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static PlanTemplateItemModel FromDataTransferObject(PlanTemplateItemEntity entity)
        {
            if (entity == null) return null;
            return new PlanTemplateItemModel
            {
                PlanTemplateItemId = entity.PlanTemplateItemId,
                PlanTemplateListId = entity.PlanTemplateListId,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetItemName = entity.BudgetItemName,
                PreviousYearOfEstimateAmountUSD = entity.PreviousYearOfEstimateAmountUSD,
                PreviousYearOfEstimateAmount = entity.PreviousYearOfEstimateAmount,
                PreviousYearOfAutonomyBudget = entity.PreviousYearOfAutonomyBudget,
                PreviousYearOfNonAutonomyBudget = entity.PreviousYearOfNonAutonomyBudget,
                SixMonthBeginingAutonomyBudget = entity.SixMonthBeginingAutonomyBudget,
                SixMonthBeginingNonAutonomyBudget = entity.SixMonthBeginingNonAutonomyBudget,
                TotalAmountSixMonthBegining = entity.TotalAmountSixMonthBegining,
                TotalAmountThisYear = entity.TotalAmountThisYear,
                ItemCodeList = entity.ItemCodeList,
                NumberOrder = entity.NumberOrder,
                FontStyle = entity.FontStyle
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static JournalEntryAccountModel FromDataTransferObject(JournalEntryAccountEntity entity)
        {
            if (entity == null) return null;
            return new JournalEntryAccountModel
            {
                JournalEntryId = entity.JournalEntryId,
                RefId = entity.RefId,
                RefDetailId = entity.RefDetailId,
                RefTypeId = entity.RefTypeId,
                RefNo = entity.RefNo,
                RefDate = entity.RefDate,
                PostedDate = entity.PostedDate,
                Description = entity.Description,
                JournalMemo = entity.JournalMemo,
                CurrencyCode = entity.CurrencyCode,
                ExchangeRate = entity.ExchangeRate,
                AccountNumber = entity.AccountNumber,
                CorrespondingAccountNumber = entity.CorrespondingAccountNumber,
                Quantity = entity.Quantity,
                JournalType = entity.JournalType,
                AmountOc = entity.AmountOc,
                AmountExchange = entity.AmountExchange,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetCategoryCode = entity.BudgetCategoryCode,
                BudgetSourceCode = entity.BudgetSourceCode,
                BudgetItemCode = entity.BudgetItemCode,
                CustomerId = entity.CustomerId,
                VendorId = entity.VendorId,
                VoucherTypeId = entity.VoucherTypeId,
                BankAccount = entity.BankAccount,
                EmployeeId = entity.EmployeeId,
                AccountingObjectId = entity.AccountingObjectId,
                MergerFundId = entity.MergerFundId,
                ProjectId = entity.ProjectId,
                InventoryItemId = entity.InventoryItemId,
                BankId = entity.BankId,
                MovementDebitAmountOC = entity.MovementDebitAmountOC,
                MovementDebitAmountExchange = entity.MovementDebitAmountExchange,
                MovementCreditAmountOC = entity.MovementCreditAmountOC,
                MovementCreditAmountExchange = entity.MovementCreditAmountExchange
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static FixedAssetCategoryModel FromDataTransferObject(FixedAssetCategoryEntity entity)
        {
            if (entity == null) return null;

            return new FixedAssetCategoryModel
            {
                FixedAssetCategoryId = entity.FixedAssetCategoryId,
                ParentId = entity.ParentId,
                FixedAssetCategoryCode = entity.FixedAssetCategoryCode,
                FixedAssetCategoryName = entity.FixedAssetCategoryName,
                FixedAssetCategoryForeignName = entity.FixedAssetCategoryForeignName,
                DepreciationRate = entity.DepreciationRate,
                LifeTime = entity.LifeTime,
                Grade = entity.Grade,
                IsParent = entity.IsParent,
                OrgPriceAccountCode = entity.OrgPriceAccountCode,
                DepreciationAccountCode = entity.DepreciationAccountCode,
                CapitalAccountCode = entity.CapitalAccountCode,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetCategoryCode = entity.BudgetCategoryCode,
                BudgetGroupCode = entity.BudgetGroupCode,
                BudgetItemCode = entity.BudgetItemCode,
                IsActive = entity.IsActive
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static FixedAssetModel FromDataTransferObject(FixedAssetEntity entity)
        {
            if (entity == null) return null;
            return new FixedAssetModel
            {
                FixedAssetId = entity.FixedAssetId,
                FixedAssetCode = entity.FixedAssetCode,
                FixedAssetName = entity.FixedAssetName,
                FixedAssetForeignName = entity.FixedAssetForeignName,
                FixedAssetCategoryId = entity.FixedAssetCategoryId,
                State = entity.State,
                Description = entity.Description,
                ProductionYear = entity.ProductionYear,
                MadeIn = entity.MadeIn,
                PurchasedDate = entity.PurchasedDate,
                UsedDate = entity.UsedDate,
                DepreciationDate = entity.DepreciationDate,
                IncrementDate = entity.IncrementDate,
                DisposedDate = entity.DisposedDate,
                Unit = entity.Unit,
                SerialNumber = entity.SerialNumber,
                Accessories = entity.Accessories,
                Quantity = entity.Quantity,
                UnitPrice = entity.UnitPrice,
                OrgPrice = entity.OrgPrice,
                AccumDepreciationAmount = entity.AccumDepreciationAmount,
                RemainingAmount = entity.RemainingAmount,
                CurrencyCode = entity.CurrencyCode,
                ExchangeRate = entity.ExchangeRate,
                UnitPriceUSD = entity.UnitPriceUSD,
                OrgPriceUSD = entity.OrgPriceUSD,
                AccumDepreciationAmountUSD = entity.AccumDepreciationAmountUSD,
                RemainingAmountUSD = entity.RemainingAmountUSD,
                AnnualDepreciationAmountUSD = entity.AnnualDepreciationAmountUSD,
                AnnualDepreciationAmount = entity.AnnualDepreciationAmount,
                LifeTime = entity.LifeTime,
                DepreciationRate = entity.DepreciationRate,
                OrgPriceAccountCode = entity.OrgPriceAccountCode,
                DepreciationAccountCode = entity.DepreciationAccountCode,
                CapitalAccountCode = entity.CapitalAccountCode,
                DepartmentId = entity.DepartmentId,
                EmployeeId = entity.EmployeeId,
                IsActive = entity.IsActive,
                FixedAssetCurrencies = FromDataTransferObjects(entity.FixedAssetCurrencies),
                RemainingOrgPrice = entity.RemainingOrgPrice,
                RemainingOrgPriceUSD = entity.RemainingOrgPriceUSD,
                NumberOfFloor = entity.NumberOfFloor,
                AreaOfBuilding = entity.AreaOfBuilding,
                AreaOfFloor = entity.AreaOfFloor,
                AdministrationArea = entity.AdministrationArea,
                WorkingArea = entity.WorkingArea,
                NumberOfSeat = entity.NumberOfSeat,
                ControlPlate = entity.ControlPlate,
                GuestHouseArea = entity.GuestHouseArea,
                HousingArea = entity.HousingArea,
                IsBussiness = entity.IsBussiness,
                IsStateManagement = entity.IsStateManagement,
                LeasingArea = entity.LeasingArea,
                OccupiedArea = entity.OccupiedArea,
                OtherArea = entity.OtherArea,
                VacancyArea = entity.VacancyArea,
                Address = entity.Address,
                BudgetSourceCode = entity.BudgetSourceCode,
                ManagementCar = entity.ManagementCar,
                Brand = entity.Brand,
                IsEstimateEmployee = entity.IsEstimateEmployee,
                ArmortizationAccount = entity.ArmortizationAccount,
                BudgetItemCode = entity.BudgetItemCode
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static CustomerModel FromDataTransferObject(CustomerEntity entity)
        {
            if (entity == null) return null;
            return new CustomerModel
            {
                CustomerId = entity.CustomerId,
                CustomerCode = entity.CustomerCode,
                CustomerName = entity.CustomerName,
                Address = entity.Address,
                ContactName = entity.ContactName,
                ContactRegency = entity.ContactRegency,
                Phone = entity.Phone,
                Mobile = entity.Mobile,
                Fax = entity.Fax,
                Email = entity.Email,
                TaxCode = entity.TaxCode,
                Website = entity.Website,
                Province = entity.Province,
                City = entity.City,
                ZipCode = entity.ZipCode,
                Area = entity.Area,
                Country = entity.Country,
                BankNumber = entity.BankNumber,
                BankId = entity.BankId,
                BankName = entity.BankName,
                IsActive = entity.IsActive,
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static VendorModel FromDataTransferObject(VendorEntity entity)
        {
            if (entity == null) return null;
            return new VendorModel
            {
                VendorId = entity.VendorId,
                VendorCode = entity.VendorCode,
                VendorName = entity.VendorName,
                Address = entity.Address,
                ContactName = entity.ContactName,
                ContactRegency = entity.ContactRegency,
                Phone = entity.Phone,
                Mobile = entity.Mobile,
                Fax = entity.Fax,
                Email = entity.Email,
                TaxCode = entity.TaxCode,
                Website = entity.Website,
                Province = entity.Province,
                City = entity.City,
                ZipCode = entity.ZipCode,
                Area = entity.Area,
                Country = entity.Country,
                BankNumber = entity.BankNumber,
                BankName = entity.BankName,
                BankId = entity.BankId,
                IsActive = entity.IsActive,
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static VoucherListModel FromDataTransferObject(VoucherListEntity entity)
        {
            return new VoucherListModel
            {
                VoucherListId = entity.VoucherListId,
                VoucherListCode = entity.VoucherListCode,
                VoucherDate = entity.VoucherDate,
                PostDate = entity.PostDate,
                Description = entity.Description,
                DocAttach = entity.DocAttach,
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static PayItemModel FromDataTransferObject(PayItemEntity entity)
        {
            if (entity == null) return null;

            return new PayItemModel
            {
                PayItemId = entity.PayItemId,
                PayItemCode = entity.PayItemCode,
                PayItemName = entity.PayItemName,
                Type = entity.Type,
                IsCalculateRatio = entity.IsCalculateRatio,
                IsSocialInsurance = entity.IsSocialInsurance,
                IsCareInsurance = entity.IsCareInsurance,
                IsTradeUnionFee = entity.IsTradeUnionFee,
                Description = entity.Description,
                DebitAccountCode = entity.DebitAccountCode,
                CreditAccountCode = entity.CreditAccountCode,
                BudgetChapterCode = entity.BudgetChapterCode,
                IsDefault = entity.IsDefault,
                IsActive = entity.IsActive,
                BudgetSourceCode = entity.BudgetSourceCode,
                BudgetCategoryCode = entity.BudgetCategoryCode,
                BudgetGroupCode = entity.BudgetGroupCode,
                BudgetItemCode = entity.BudgetItemCode
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static BudgetChapterModel FromDataTransferObject(BudgetChapterEntity entity)
        {
            if (entity == null) return null;

            return new BudgetChapterModel
            {
                BudgetChapterId = entity.BudgetChapterId,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetChapterName = entity.BudgetChapterName,
                Description = entity.Description,
                IsActive = entity.IsActive,
                IsSystem = entity.IsSystem,
                ForeignName = entity.ForeignName
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static BudgetCategoryModel FromDataTransferObject(BudgetCategoryEntity entity)
        {
            if (entity == null) return null;

            return new BudgetCategoryModel
            {
                BudgetCategoryId = entity.BudgetCategoryId,
                BudgetCategoryCode = entity.BudgetCategoryCode,
                BudgetCategoryName = entity.BudgetCategoryName,
                ParentId = entity.ParentId,
                IsParent = entity.IsParent,
                Description = entity.Description,
                IsActive = entity.IsActive,
                IsSystem = entity.IsSystem,
                Grade = entity.Grade,
                ForeignName = entity.ForeignName
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static MergerFundModel FromDataTransferObject(MergerFundEntity entity)
        {
            if (entity == null) return null;

            return new MergerFundModel
            {
                MergerFundId = entity.MergerFundId,
                MergerFundCode = entity.MergerFundCode,
                MergerFundName = entity.MergerFundName,
                ParentId = entity.ParentId,
                Description = entity.Description,
                IsActive = entity.IsActive,
                IsSystem = entity.IsSystem,
                Grade = entity.Grade,
                ForeignName = entity.ForeignName
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static BudgetSourceModel FromDataTransferObject(BudgetSourceEntity entity)
        {
            if (entity == null) return null;

            return new BudgetSourceModel
            {
                BudgetSourceId = entity.BudgetSourceId,
                BudgetSourceCode = entity.BudgetSourceCode,
                BudgetSourceName = entity.BudgetSourceName,
                ForeignName = entity.ForeignName,
                ParentId = entity.ParentId,
                Description = entity.Description,
                Grade = entity.Grade,
                IsParent = entity.IsParent,
                Type = entity.Type,
                IsSystem = entity.IsSystem,
                IsActive = entity.IsActive,
                Allocation = entity.Allocation,
                BudgetItemCode = entity.BudgetItemCode,
                IsFund = entity.IsFund,
                IsExpense = entity.IsExpense,
                AccountCode = entity.AccountCode,
                AutonomyBudgetType = entity.AutonomyBudgetType
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static EmployeeModel FromDataTransferObject(EmployeeEntity entity)
        {
            if (entity == null) return null;

            return new EmployeeModel
            {
                EmployeeId = entity.EmployeeId,
                EmployeeCode = entity.EmployeeCode,
                EmployeeName = entity.EmployeeName,
                JobCandidateName = entity.JobCandidateName,
                SortOrder = entity.SortOrder,
                BirthDate = entity.BirthDate == null ? null : DateTime.Parse(entity.BirthDate.ToString()).ToShortDateString(),
                TypeOfSalary = entity.TypeOfSalary,
                Sex = entity.Sex,
                LevelOfSalary = entity.LevelOfSalary,
                DepartmentId = entity.DepartmentId,
                CurrencyCode = entity.CurrencyCode,
                IdentityNo = entity.IdentityNo,
                IssueDate = entity.IssueDate == null ? null : DateTime.Parse(entity.IssueDate.ToString()).ToShortDateString(),
                IssueBy = entity.IssueBy,
                IsActive = entity.IsActive,
                Description = entity.Description,
                Address = entity.Address,
                PhoneNumber = entity.PhoneNumber,
                IsOffice = entity.IsOffice,
                RetiredDate = entity.RetiredDate == null ? null : DateTime.Parse(entity.RetiredDate.ToString()).ToShortDateString(),
                StartingDate = entity.StartingDate == null ? null : DateTime.Parse(entity.StartingDate.ToString()).ToShortDateString(),
                EmployeePayItems = entity.EmployeePayItems == null ? null : FromDataTransferObjects(entity.EmployeePayItems)
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static EmployeePayItemModel FromDataTransferObject(EmployeePayItemEntity entity)
        {
            if (entity == null) return null;

            return new EmployeePayItemModel
            {
                EmployeeId = entity.EmployeeId,
                EmployeePayItemId = entity.EmployeePayItemId,
                PayItemId = entity.PayItemId,
                Amount = entity.Amount,
                SalaryRatio = entity.SalaryRatio
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static StockModel FromDataTransferObject(StockEntity entity)
        {
            if (entity == null) return null;

            return new StockModel
            {
                StockId = entity.StockId,
                StockCode = entity.StockCode,
                Description = entity.Description,
                StockName = entity.StockName,
                IsActive = entity.IsActive,


            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static CaptitalAllocateVoucherModel FromDataTransferObject(CaptitalAllocateVoucherEntity entity)
        {
            if (entity == null) return null;

            return new CaptitalAllocateVoucherModel
            {
                ActivityId = entity.ActivityId,
                AllocatePercent = entity.AllocatePercent,
                AllocateType = entity.AllocateType,
                Amount = entity.Amount,
                TotalAmount = entity.TotalAmount,
                RefId = entity.RefId,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetSourceCode = entity.BudgetSourceCode,
                CapitalAccountCode = entity.CapitalAccountCode,
                CapitalAllocateCode = entity.CapitalAllocateCode,
                RefDetailId = entity.RefDetailId,
                Description = entity.Description,
                DeterminedDate = entity.DeterminedDate,
                ExpenseAccountCode = entity.ExpenseAccountCode,
                ExpenseAmount = entity.ExpenseAmount,
                IsActive = entity.IsActive,
                RevenueAccountCode = entity.RevenueAccountCode,
                WaitBudgetSourceCode = entity.WaitBudgetSourceCode,
                CurrencyCode = entity.CurrencyCode,
                FromDate = entity.FromDate,
                ToDate = entity.ToDate,
                BudgetSourceName = entity.BudgetSourceName,
                ExchangeRate = entity.ExchangeRate
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static AccountTranferVourcherModel FromDataTransferObject(AccountTranferVourcherEntity entity)
        {
            if (entity == null) return null;

            return new AccountTranferVourcherModel
            {
                RefId = entity.RefId,
                BudgetSourceCode = entity.BudgetSourceCode,
                RefDetailId = entity.RefDetailId,
                Description = entity.Description,
                CurrencyCode = entity.CurrencyCode,
                ExchangeRate = entity.ExchangeRate,
                AccountNumber = entity.AccountNumber,
                CorrespondingAccountNumber = entity.CorrespondingAccountNumber,
                AmountExchange = entity.AmountExchange,
                AmountOc = entity.AmountOc,
                PostedDate = entity.PostedDate,
                VoucherTypeId = entity.VoucherTypeId
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static InventoryItemModel FromDataTransferObject(InventoryItemEntity entity)
        {
            if (entity == null) return null;

            return new InventoryItemModel
            {
                InventoryItemId = entity.InventoryItemId,
                InventoryItemName = entity.InventoryItemName,
                InventoryItemCode = entity.InventoryItemCode,
                AccountCode = entity.AccountCode,
                CurrencyCode = entity.CurrencyCode,
                IsActive = entity.IsActive,
                CostMethod = entity.CostMethod,
                Unit = entity.Unit,
                StockId = entity.StockId,
                StockCode = entity.StockCode,
                ExpenseAccountCode = entity.ExpenseAccountCode
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static BankModel FromDataTransferObject(BankEntity entity)
        {
            if (entity == null) return null;

            return new BankModel
            {
                BankId = entity.BankId,
                BankAccount = entity.BankAccount,
                BankAddress = entity.BankAddress,
                BankName = entity.BankName,
                Description = entity.Description,
                IsActive = entity.IsActive,
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static ExchangeRateModel FromDataTransferObject(ExchangeRateEntity entity)
        {
            if (entity == null) return null;

            return new ExchangeRateModel
            {
                ExchangeRateId = entity.ExchangeRateId,
                BudgetSourceCode = entity.BudgetSourceCode,
                ExchangeRate = entity.ExchangeRate,
                Description = entity.Description,
                FromDate = entity.FromDate,
                ToDate = entity.ToDate,
                Inactive = entity.Inactive
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static AccountTranferModel FromDataTransferObject(AccountTranferEntity entity)
        {
            if (entity == null) return null;

            return new AccountTranferModel
            {
                AccountTranferId = entity.AccountTranferId,
                AccountTranferCode = entity.AccountTranferCode,
                SortOrder = entity.SortOrder,
                AccountDestinationCode = entity.AccountDestinationCode,
                AccountSourceCode = entity.AccountSourceCode,
                SideOfTranfer = entity.SideOfTranfer,
                Type = entity.Type,
                IsActive = entity.IsActive,
                Description = entity.Description
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static DBOptionModel FromDataTransferObject(DBOptionEntity entity)
        {
            if (entity == null) return null;

            return new DBOptionModel
            {
                OptionId = entity.OptionId,
                OptionValue = entity.OptionValue,
                ValueType = entity.ValueType,
                IsSystem = entity.IsSystem,
                Description = entity.Description
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static ReportListModel FromDataTransferObject(ReportListEntity entity)
        {
            if (entity == null) return null;

            return new ReportListModel
            {
                ReportID = entity.ReportId,
                ReportName = entity.ReportName,
                Description = entity.Description,
                GroupID = entity.GroupId,
                ReportFile = entity.ReportFile,
                OutputAssembly = entity.OutputAssembly,
                InputTypeName = entity.InputTypeName,
                FunctionReportName = entity.FunctionReportName,
                ProcedureName = entity.ProcedureName,
                TableName = entity.TableName,
                TrackType = entity.TrackType,
                ProcedureNameByLot = entity.ProcedureNameByLot,
                ProcedureNameVoucherList = entity.ProcedureNameVoucherList,
                Selected = entity.Selected,
                Inactive = entity.Inactive,
                RefRypeVoucherID = entity.RefRypeVoucherID,
                PrintVoucherDefault = entity.PrintVoucherDefault,
                LicenceType = entity.LicenceType,
                ParamFormName = entity.ParamFormName,
                SupplementInfoReportID = entity.SupplementInfoReportId,
                SupplementInfoTableName = entity.SupplementInfoTableName,
                SortOrder = entity.SortOrder
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static ReportGroupModel FromDataTransferObject(ReportGroupEntity entity)
        {
            if (entity == null) return null;

            return new ReportGroupModel
            {
                ReportGroupID = entity.ReportGroupId,
                ReportGroupName = entity.ReportGroupName,
                Description = entity.Description,
                IsActive = entity.IsActive,
                IsVoucher = entity.IsVoucher,
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static AudittingLogModel FromDataTransferObject(AudittingLogEntity entity)
        {
            if (entity == null) return null;

            return new AudittingLogModel
            {
                EventId = entity.EventId,
                LoginName = entity.LoginName,
                ComputerName = entity.ComputerName,
                EventTime = entity.EventTime,
                ComponentName = entity.ComponentName,
                EventAction = entity.EventAction,
                Reference = entity.Reference,
                Amount = entity.Amount
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static EstimateModel FromDataTransferObject(EstimateEntity entity)
        {
            if (entity == null) return null;

            return new EstimateModel
            {
                RefId = entity.RefId,
                RefTypeId = entity.RefTypeId,
                RefNo = entity.RefNo,
                RefDate = entity.RefDate.ToShortDateString(),
                PostedDate = entity.PostedDate.ToShortDateString(),
                PlanTemplateListId = entity.PlanTemplateListId,
                YearOfPlaning = entity.YearOfPlaning,
                CurrencyCode = entity.CurrencyCode,
                ExchangeRate = entity.ExchangeRate,
                TotalEstimateAmount = entity.TotalEstimateAmount,
                NextYearOfTotalEstimateAmount = entity.NextYearOfTotalEstimateAmount,
                JournalMemo = entity.JournalMemo,
                BudgetSourceCategoryId = entity.BudgetSourceCategoryId,
                ExchangeRateLastYear = entity.ExchangeRateLastYear,
                ExchangeRateThisYear = entity.ExchangeRateThisYear,
                EstimateDetails = entity.EstimateDetails == null ? null : FromDataTransferObjects(entity.EstimateDetails)
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static EstimateDetailModel FromDataTransferObject(EstimateDetailEntity entity)
        {
            if (entity == null) return null;

            return new EstimateDetailModel
            {
                RefId = entity.RefId,
                RefDetailId = entity.RefDetailId,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetItemName = entity.BudgetItemName,
                AutonomyBudget = entity.AutonomyBudget,
                Description = entity.Description,
                NextYearOfEstimateAmount = entity.NextYearOfEstimateAmount,
                NonAutonomyBudget = entity.NonAutonomyBudget,
                PreviousYearOfEstimateAmount = entity.PreviousYearOfEstimateAmount,
                PreviousYearOfEstimateAmountUSD = entity.PreviousYearOfEstimateAmountUSD,
                TotalEstimateAmountUSD = entity.TotalEstimateAmountUSD,
                YearOfEstimateAmount = entity.YearOfEstimateAmount,
                TotalNextYearOfEstimateAmount = entity.TotalNextYearOfEstimateAmount,
                PreviousYearOfAutonomyBudget = entity.PreviousYearOfAutonomyBudget,
                PreviousYearOfNonAutonomyBudget = entity.PreviousYearOfNonAutonomyBudget,
                YearOfAutonomyBudget = entity.YearOfAutonomyBudget,
                YearOfNonAutonomyBudget = entity.YearOfNonAutonomyBudget,
                SixMonthBeginingAutonomyBudget = entity.SixMonthBeginingAutonomyBudget,
                SixMonthBeginingNonAutonomyBudget = entity.SixMonthBeginingNonAutonomyBudget,
                TotalAmountSixMonthBegining = entity.TotalAmountSixMonthBegining,
                SixMonthEndingAutonomyBudget = entity.SixMonthEndingAutonomyBudget,
                SixMonthEndingNonAutonomyBudget = entity.SixMonthEndingNonAutonomyBudget,
                TotalAmountSixMonthEnding = entity.TotalAmountSixMonthEnding,
                PreviousYeaOfAutonomyBudgetBalance = entity.PreviousYeaOfAutonomyBudgetBalance,
                PreviousYeaOfNonAutonomyBudgetBalance = entity.PreviousYeaOfNonAutonomyBudgetBalance,
                TotalPreviousYearBalance = entity.TotalPreviousYearBalance,
                ThisYearOfAutonomyBudget = entity.ThisYearOfAutonomyBudget,
                ThisYearOfNonAutonomyBudget = entity.ThisYearOfNonAutonomyBudget,
                TotalAmountThisYear = entity.TotalAmountThisYear,
                IsInserted = entity.IsInserted,
                ItemCodeList = entity.ItemCodeList,
                NumberOrder = entity.NumberOrder,
                FontStyle = entity.FontStyle
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>
        /// DepositModel.
        /// </returns>
        internal static DepositModel FromDataTransferObject(DepositEntity entity)
        {
            if (entity == null) return null;

            return new DepositModel
            {
                RefId = entity.RefId,
                RefTypeId = entity.RefTypeId,
                RefDate = entity.RefDate,
                PostedDate = entity.PostedDate,
                RefNo = entity.RefNo,
                AccountingObjectType = entity.AccountingObjectType,
                AccountingObjectId = entity.AccountingObjectId,
                Trader = entity.Trader,
                CustomerId = entity.CustomerId,
                VendorId = entity.VendorId,
                EmployeeId = entity.EmployeeId,
                BankAccountCode = entity.BankAccountCode,
                CurrencyCode = entity.CurrencyCode,
                ExchangeRate = entity.ExchangeRate,
                TotalAmountOc = entity.TotalAmountOc,
                TotalAmountExchange = entity.TotalAmountExchange,
                JournalMemo = entity.JournalMemo,
                BankId = entity.BankId,
                DepositDetails = entity.DepositDetails == null ? null : FromDataTransferObjects(entity.DepositDetails)
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>
        /// DepositDetailModel.
        /// </returns>
        internal static DepositDetailModel FromDataTransferObject(DepositDetailEntity entity)
        {
            if (entity == null) return null;
            return new DepositDetailModel
            {
                RefDetailId = entity.RefDetailId,
                RefId = entity.RefId,
                Description = entity.Description,
                AccountNumber = entity.AccountNumber,
                CorrespondingAccountNumber = entity.CorrespondingAccountNumber,
                AmountOc = entity.AmountOc,
                AmountExchange = entity.AmountExchange,
                VoucherTypeId = entity.VoucherTypeId,
                BudgetSourceCode = entity.BudgetSourceCode,
                AccountingObjectId = entity.AccountingObjectId,
                BudgetItemCode = entity.BudgetItemCode,
                DepartmentId = entity.DepartmentId,
                MergerFundId = entity.MergerFundId,
                ProjectId = entity.ProjectId,
                AutoBusinessId = entity.AutoBusinessId
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static ReceiptVoucherModel FromReceiptDataTransferObject(CashEntity entity)
        {
            if (entity == null) return null;

            return new ReceiptVoucherModel
            {
                RefId = entity.RefId,
                RefTypeId = entity.RefTypeId,
                RefNo = entity.RefNo,
                RefDate = entity.RefDate,
                PostedDate = entity.PostedDate,
                AccountingObjectId = entity.AccountingObjectId,
                CustomerId = entity.CustomerId,
                VendorId = entity.VendorId,
                EmployeeId = entity.EmployeeId,
                Trader = entity.Trader,
                CurrencyCode = entity.CurrencyCode,
                AccountNumber = entity.AccountNumber,
                TotalAmount = entity.TotalAmount,
                ExchangeRate = entity.ExchangeRate,
                TotalAmountExchange = entity.TotalAmountExchange,
                JournalMemo = entity.JournalMemo,
                DocumentInclude = entity.DocumentInclude,
                AccountingObjectType = entity.AccountingObjectType,
                BankId = entity.BankId,
                BankAccount = entity.BankAccount,
                IsIncludeCharge = entity.IsIncludeCharge,
                ReceiptVoucherDetails = ToReceiptDetailDataTransferObjects(entity.CashDetails),
                ReceiptVoucherDetailParalells = VoucherMapper.FromDataTransferObjects(entity.CashParalellDetails)
              
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        //internal static GeneralVocherModel FromGeneralDataTransferObject(GeneralEntity entity)
        //{
        //    if (entity == null) return null;

        //    return new GeneralVocherModel
        //    {
        //        RefId = entity.RefId,
        //        RefTypeId = entity.RefTypeId,
        //        RefNo = entity.RefNo,
        //        RefDate = entity.RefDate,
        //        JournalMemo = entity.JournalMemo,
        //        PostedDate = entity.PostedDate,
        //        GeneralVoucherDetails = ToGeneralVoucherDetailDataTransferObjects(entity.GeneralDetails.ToList()),
        //        GeneralParalellDetails = ToGeneralVoucherDetailDataTransferObjects(entity.GeneralParalellDetails.ToList()),
        //    };
        //}

        /// <summary>
        /// Froms the payment data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static CashModel FromDataTransferObject(CashEntity entity)
        {
            if (entity == null) return null;

            return new CashModel
            {
                RefId = entity.RefId,
                RefTypeId = entity.RefTypeId,
                RefNo = entity.RefNo,
                RefDate = entity.RefDate.ToShortDateString(),
                PostedDate = entity.PostedDate.ToShortDateString(),
                AccountingObjectId = entity.AccountingObjectId,
                CustomerId = entity.CustomerId,
                VendorId = entity.VendorId,
                EmployeeId = entity.EmployeeId,
                Trader = entity.Trader,
                CurrencyCode = entity.CurrencyCode,
                AccountNumber = entity.AccountNumber,
                TotalAmount = entity.TotalAmount,
                ExchangeRate = entity.ExchangeRate,
                TotalAmountExchange = entity.TotalAmountExchange,
                JournalMemo = entity.JournalMemo,
                DocumentInclude = entity.DocumentInclude,
                AccountingObjectType = entity.AccountingObjectType,
                BankId = entity.BankId,
                BankAccount = entity.BankAccount,
                CashDetails = ToDataTransferObjects(entity.CashDetails),
                CashParalellDetails = VoucherMapper.CashFromDataTransferObjects(entity.CashParalellDetails)
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static GeneralVocherModel FromDataTransferObject(GeneralEntity entity)
        {
            if (entity == null) return null;

            return new GeneralVocherModel
            {
                RefId = entity.RefId,
                RefTypeId = entity.RefTypeId,
                RefNo = entity.RefNo,
                RefDate = entity.RefDate,
                PostedDate = entity.PostedDate,
                JournalMemo = entity.JournalMemo,
                TotalAmountExchange = entity.TotalAmountExchange,
                TotalAmountOc = entity.TotalAmountOc,
                GeneralVoucherDetails = ToDataTransferObjects(entity.GeneralDetails.ToList()),
                GeneralParalellDetails = VoucherMapper.GeneralFromDataTransferObjects(entity.GeneralParalellDetails.ToList())
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static VoucherTypeModel FromDataTransferObject(VoucherTypeEntity entity)
        {
            if (entity == null) return null;

            return new VoucherTypeModel
            {
                VoucherTypeId = entity.VoucherTypeId,
                VoucherTypeName = entity.VoucherTypeName,
                IsActive = entity.IsActive
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static AutoBusinessModel FromDataTransferObject(AutoBusinessEntity entity)
        {
            if (entity == null) return null;

            return new AutoBusinessModel
            {
                AutoBusinessId = entity.AutoBusinessId,
                AutoBusinessCode = entity.AutoBusinessCode,
                AutoBusinessName = entity.AutoBusinessName,
                RefTypeId = entity.RefTypeId,
                VoucherTypeId = entity.VoucherTypeId,
                DebitAccountNumber = entity.DebitAccountNumber,
                CreditAccountNumber = entity.CreditAccountNumber,
                BudgetSourceCode = entity.BudgetSourceCode,
                BudgetItemCode = entity.BudgetItemCode,
                Description = entity.Description,
                CurrencyCode = entity.Description,
                IsActive = entity.IsActive
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static RefTypeModel FromDataTransferObject(RefTypeEntity entity)
        {
            if (entity == null) return null;

            return new RefTypeModel
            {
                RefTypeId = entity.RefTypeId,
                RefTypeName = entity.RefTypeName,
                FunctionId = entity.FunctionId,
                RefTypeCategoryId = entity.RefTypeCategoryId,
                MasterTableName = entity.MasterTableName,
                DetailTableName = entity.DetailTableName,
                LayoutMaster = entity.LayoutMaster,
                LayoutDetail = entity.LayoutDetail,
                DefaultDebitAccountCategoryId = entity.DefaultDebitAccountCategoryId,
                DefaultDebitAccountId = entity.DefaultDebitAccountId,
                DefaultCreditAccountCategoryId = entity.DefaultCreditAccountCategoryId,
                DefaultCreditAccountId = entity.DefaultCreditAccountId,
                DefaultTaxAccountCategoryId = entity.DefaultTaxAccountCategoryId,
                DefaultTaxAccountId = entity.DefaultTaxAccountId,
                AllowDefaultSetting = entity.AllowDefaultSetting,
                Postable = entity.Postable,
                Searchable = entity.Searchable,
                SortOrder = entity.SortOrder,
                SubSystem = entity.SubSystem
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static RefTypeEntity ToDataTransferObject(RefTypeModel model)
        {
            return new RefTypeEntity
            {
                RefTypeId = model.RefTypeId,
                DefaultTaxAccountId = model.DefaultTaxAccountId,
                DefaultCreditAccountCategoryId = model.DefaultCreditAccountCategoryId,
                AllowDefaultSetting = model.AllowDefaultSetting,
                DefaultDebitAccountId = model.DefaultDebitAccountId,
                RefTypeName = model.RefTypeName,
                DefaultCreditAccountId = model.DefaultCreditAccountId,
                DefaultTaxAccountCategoryId = model.DefaultTaxAccountCategoryId,
                DefaultDebitAccountCategoryId = model.DefaultDebitAccountCategoryId,
                DetailTableName = model.DetailTableName,
                FunctionId = model.FunctionId,
                LayoutDetail = model.LayoutDetail,
                LayoutMaster = model.LayoutMaster,
                MasterTableName = model.MasterTableName,
                Postable = model.Postable,
                RefTypeCategoryId = model.RefTypeCategoryId,
                Searchable = model.Searchable,
                SortOrder = model.SortOrder,
                SubSystem = model.SubSystem
            };
        }
        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static ProjectModel FromDataTransferObject(ProjectEntity entity)
        {
            if (entity == null) return null;
            return new ProjectModel
            {
                ProjectId = entity.ProjectId,
                ProjectCode = entity.ProjectCode,
                ProjectName = entity.ProjectName,
                ForeignName = entity.ForeignName,
                ParentId = entity.ParentId,
                IsParent = entity.IsParent,
                IsActive = entity.IsActive,
                Description = entity.Description
            }
            ;
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static FixedAssetArmortizationModel FromDataTransferObject(FAArmortizationEntity entity)
        {
            if (entity == null) return null;
            return new FixedAssetArmortizationModel
            {
                RefId = entity.RefId,
                RefNo = entity.RefNo,
                RefDate = entity.RefDate.ToShortDateString(),
                PostedDate = entity.PostedDate.ToShortDateString(),
                RefTypeId = entity.RefTypeId,
                TotalAmountOC = entity.TotalAmountOC,
                TotalAmountExchange = entity.TotalAmountExchange,
                JournalMemo = entity.JournalMemo,
                CurrencyCode = entity.CurrencyCode,
                FixedAssetArmortizationDetails = entity.FAArmortizationDetails == null ? null : FromDataTransferObjects(entity.FAArmortizationDetails)
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static FixedAssetArmortizationDetailModel FromDataTransferObject(FAArmortizationDetailEntity entity)
        {
            if (entity == null) return null;
            return new FixedAssetArmortizationDetailModel
            {
                RefDetailId = entity.RefDetailId,
                RefId = entity.RefId,
                FixedAssetId = entity.FixedAssetId,
                AccountNumber = entity.AccountNumber,
                CorrespondingAccountNumber = entity.CorrespondingAccountNumber,
                Quantity = entity.Quantity,
                CurrencyCode = entity.CurrencyCode,
                ExchangeRate = entity.ExchangeRate,
                AmountOC = entity.AmountOC,
                AmountExchange = entity.AmountExchange,
                VoucherTypeId = entity.VoucherTypeId,
                BudgetSourceCode = entity.BudgetSourceCode,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetCategoryCode = entity.BudgetCategoryCode,
                BudgetChapterCode = entity.BudgetChapterCode,
                Description = entity.Description,
                DepartmentId = entity.DepartmentId,
                ProjectId = entity.ProjectId,
                AutoBusinessId = entity.AutoBusinessId
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static FixedAssetDecrementModel FromDataTransferObject(FADecrementEntity entity)
        {
            if (entity == null) return null;
            return new FixedAssetDecrementModel
            {
                RefId = entity.RefId,
                RefNo = entity.RefNo,
                RefDate = entity.RefDate.ToShortDateString(),
                PostedDate = entity.PostedDate.ToShortDateString(),
                RefTypeId = entity.RefTypeId,
                AccountingObjectType = entity.AccountingObjectType,
                AccountingObjectId = entity.AccountingObjectId,
                CustomerId = entity.CustomerId,
                VendorId = entity.VendorId,
                EmployeeId = entity.EmployeeId,
                CurrencyCode = entity.CurrencyCode,
                ExchangeRate = entity.ExchangeRate,
                TotalAmountExchange = entity.TotalAmountExchange,
                TotalAmountOC = entity.TotalAmountOC,
                JournalMemo = entity.JournalMemo,
                DocumentInclude = entity.DocumentInclude,
                Trader = entity.Trader,
                BankId = entity.BankId,
                FixedAssetDecrementDetails = entity.FADecrementDetails == null ? null : FromDataTransferObjects(entity.FADecrementDetails)
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static FixedAssetDecrementDetailModel FromDataTransferObject(FADecrementDetailEntity entity)
        {
            if (entity == null) return null;
            return new FixedAssetDecrementDetailModel
            {
                RefDetailId = entity.RefDetailId,
                RefId = entity.RefId,
                FixedAssetId = entity.FixedAssetId,
                AccountNumber = entity.AccountNumber,
                CorrespondingAccountNumber = entity.CorrespondingAccountNumber,
                Quantity = entity.Quantity,
                AmountExchange = entity.AmountExchange,
                VoucherTypeId = entity.VoucherTypeId,
                BudgetSourceCode = entity.BudgetSourceCode,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetCategoryCode = entity.BudgetCategoryCode,
                BudgetChapterCode = entity.BudgetChapterCode,
                Description = entity.Description,
                DepartmentId = entity.DepartmentId,
                ProjectId = entity.ProjectId,
                AccountingObjectId = entity.AccountingObjectId,
                AutoBusinessId = entity.AutoBusinessId,
                UnitPriceExchange = entity.UnitPriceExchange,
                AmountOC = entity.AmountOC,
                UnitPriceOC = entity.UnitPriceOC
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static FixedAssetIncrementModel FromDataTransferObject(FAIncrementEntity entity)
        {
            if (entity == null) return null;
            return new FixedAssetIncrementModel
            {
                RefId = entity.RefId,
                RefNo = entity.RefNo,
                RefDate = entity.RefDate.ToShortDateString(),
                PostedDate = entity.PostedDate.ToShortDateString(),
                RefTypeId = entity.RefTypeId,
                AccountingObjectType = entity.AccountingObjectType,
                AccountingObjectId = entity.AccountingObjectId,
                CustomerId = entity.CustomerId,
                VendorId = entity.VendorId,
                EmployeeId = entity.EmployeeId,
                Trader = entity.Trader,
                CurrencyCode = entity.CurrencyCode,
                ExchangeRate = entity.ExchangeRate,
                TotalAmountExchange = entity.TotalAmountExchange,
                TotalAmountOC = entity.TotalAmountOC,
                JournalMemo = entity.JournalMemo,
                DocumentInclude = entity.DocumentInclude,
                BankId = entity.BankId,
                FixedAssetIncrementDetails = entity.FAIncrementDetails == null ? null : FromDataTransferObjects(entity.FAIncrementDetails)
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static FixedAssetIncrementDetailModel FromDataTransferObject(FAIncrementDetailEntity entity)
        {
            if (entity == null) return null;
            return new FixedAssetIncrementDetailModel
            {
                RefDetailId = entity.RefDetailId,
                RefId = entity.RefId,
                FixedAssetId = entity.FixedAssetId,
                AccountNumber = entity.AccountNumber,
                CorrespondingAccountNumber = entity.CorrespondingAccountNumber,
                Quantity = entity.Quantity,
                AmountExchange = entity.AmountExchange,
                VoucherTypeId = entity.VoucherTypeId,
                BudgetSourceCode = entity.BudgetSourceCode,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetCategoryCode = entity.BudgetCategoryCode,
                BudgetChapterCode = entity.BudgetChapterCode,
                Description = entity.Description,
                DepartmentId = entity.DepartmentId,
                ProjectId = entity.ProjectId,
                AccountingObjectId = entity.AccountingObjectId,
                AutoBusinessId = entity.AutoBusinessId,
                UnitPriceExchange = entity.UnitPriceExchange,
                AmountOC = entity.AmountOC,
                UnitPriceOC = entity.UnitPriceOC
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static GeneralDetailModel FromDataTransferObject(GeneralDetailEntity entity)
        {
            if (entity == null) return null;
            return new GeneralDetailModel
            {
                RefId = entity.RefId,
                RefDetailId = entity.RefDetailId,
                AccountNumber = entity.AccountNumber,
                CorrespondingAccountNumber = entity.CorrespondingAccountNumber,
                AmountExchange = entity.AmountExchange,
                BudgetSourceCode = entity.BudgetSourceCode,
                BudgetItemCode = entity.BudgetItemCode,
                Description = entity.Description,
                ProjectId = entity.ProjectId,
                AccountingObjectId = entity.AccountingObjectId,
                CurrencyCode = entity.CurrencyCode,
                CustomerId = entity.CustomerId,
                EmployeeId = entity.EmployeeId,
                ExchangeRate = entity.ExchangeRate,
                VendorId = entity.VendorId,
                AmountOc = entity.AmountOc,
                VoucherTypeId = entity.VoucherTypeId,
                DepartmentId = entity.DepartmentId,
                InventoryItemId = entity.InventoryItemId,
                BankId = entity.BankId,
                CapitalAllocateCode = entity.CapitalAllocateCode,
                AutoBusiness = entity.AutoBusiness
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static FixedAssetCurrencyModel FromDataTransferObject(FixedAssetCurrencyEntity entity)
        {
            if (entity == null) return null;
            return new FixedAssetCurrencyModel
            {
                FixedAssetCurrencyId = entity.FixedAssetCurrencyId,
                FixedAssetId = entity.FixedAssetId,
                CurrencyCode = entity.CurrencyCode,
                UnitPrice = entity.UnitPrice,
                UnitPriceUSD = entity.UnitPriceUSD,
                OrgPrice = entity.OrgPrice,
                OrgPriceUSD = entity.OrgPriceUSD,
                AccumDepreciationAmount = entity.AccumDepreciationAmount,
                AccumDepreciationAmountUSD = entity.AccumDepreciationAmountUSD,
                RemainingAmount = entity.RemainingAmount,
                RemainingAmountUSD = entity.RemainingAmountUSD,
                AnnualDepreciationAmount = entity.AnnualDepreciationAmount,
                AnnualDepreciationAmountUSD = entity.AnnualDepreciationAmountUSD,
                ExchangeRate = entity.ExchangeRate
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static OpeningInventoryEntryModel FromDataTransferObject(OpeningInventoryEntryEntity entity)
        {
            if (entity == null) return null;
            return new OpeningInventoryEntryModel
            {
                AccountName = entity.AccountName,
                AccountId = entity.AccountId,
                ParentId = entity.ParentId,

                RefId = entity.RefId,
                RefTypeId = entity.RefTypeId,
                PostedDate = entity.PostedDate,
                AccountNumber = entity.AccountNumber,
                AmountExchange = entity.AmountExchange,
                ExchangeRate = entity.ExchangeRate,
                AmountOc = entity.AmountOc,
                CurrencyCode = entity.CurrencyCode,
                Quantity = entity.Quantity,
                RefNo = entity.RefNo,
                InventoryItemId = entity.InventoryItemId,
                StockId = entity.StockId,
                UnitPriceExchange = entity.UnitPriceExchange,
                UnitPriceOc = entity.UnitPriceOc
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static OpeningAccountEntryModel FromDataTransferObject(OpeningAccountEntryEntity entity)
        {
            if (entity == null) return null;
            return new OpeningAccountEntryModel
            {
                RefId = entity.RefId,
                RefTypeId = entity.RefTypeId,
                PostedDate = entity.PostedDate,
                AccountCode = entity.AccountCode,
                AccountName = entity.AccountName,
                AccountId = entity.AccountId,
                ParentId = entity.ParentId,
                TotalAccountBeginningDebitAmountOC = entity.TotalAccountBeginningDebitAmountOC,
                TotalAccountBeginningCreditAmountOC = entity.TotalAccountBeginningCreditAmountOC,
                TotalDebitAmountOC = entity.TotalDebitAmountOC,
                TotalCreditAmountOC = entity.TotalCreditAmountOC,
                TotalAccountBeginningDebitAmountExchange = entity.TotalAccountBeginningDebitAmountExchange,
                TotalAccountBeginningCreditAmountExchange = entity.TotalAccountBeginningCreditAmountExchange,
                TotalDebitAmountExchange = entity.TotalDebitAmountExchange,
                TotalCreditAmountExchange = entity.TotalCreditAmountExchange,
                OpeningAccountEntryDetails = FromDataTransferObjects(entity.OpeningAccountEntryDetails)
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static OpeningAccountEntryDetailModel FromDataTransferObject(OpeningAccountEntryDetailEntity entity)
        {
            if (entity == null) return null;
            return new OpeningAccountEntryDetailModel
            {
                RefDetailId = entity.RefDetailId,
                RefTypeId = entity.RefTypeId,
                PostedDate = entity.PostedDate,
                AccountCode = entity.AccountCode,
                AccountName = entity.AccountName,
                AccountId = entity.AccountId,
                ParentId = entity.ParentId,
                AccountBeginningDebitAmountOC = entity.AccountBeginningDebitAmountOC,
                AccountBeginningCreditAmountOC = entity.AccountBeginningCreditAmountOC,
                DebitAmountOC = entity.DebitAmountOC,
                CreditAmountOC = entity.CreditAmountOC,
                AccountBeginningDebitAmountExchange = entity.AccountBeginningDebitAmountExchange,
                AccountBeginningCreditAmountExchange = entity.AccountBeginningCreditAmountExchange,
                DebitAmountExchange = entity.DebitAmountExchange,
                CreditAmountExchange = entity.CreditAmountExchange,
                CurrencyCode = entity.CurrencyCode,
                ExchangeRate = entity.ExchangeRate,
                BudgetSourceCode = entity.BudgetSourceCode,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetCategoryCode = entity.BudgetCategoryCode,
                BudgetGroupItemCode = entity.BudgetGroupItemCode,
                BudgetItemCode = entity.BudgetItemCode,
                MergerFundId = entity.MergerFundId,
                EmployeeId = entity.EmployeeId,
                CustomerId = entity.CustomerId,
                VendorId = entity.VendorId,
                AccountingObjectId = entity.AccountingObjectId,
                ProjectId = entity.ProjectId,
                BankId = entity.BankId
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static GeneralReceiptEstimateModel FromDataTransferObject(GeneralReceiptEstimateEntity entity)
        {
            if (entity == null) return null;
            return new GeneralReceiptEstimateModel
            {
                Id = entity.Id,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetItemName = entity.BudgetItemName,
                PreviousYearOfTotalEstimateAmount = entity.PreviousYearOfTotalEstimateAmount,
                YearOfEstimateAmount = entity.YearOfEstimateAmount,
                NextYearOfEstimateAmount = entity.NextYearOfEstimateAmount,
                Description = entity.Description,
                ItemCodeList = entity.ItemCodeList,
                NumberOrder = entity.NumberOrder,
                FontStyle = entity.FontStyle,
                IsParent = entity.IsParent
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static GeneralPaymentEstimateModel FromDataTransferObject(GeneralPaymentEstimateEntity entity)
        {
            if (entity == null) return null;
            return new GeneralPaymentEstimateModel
            {
                BudgetItemId = entity.BudgetItemId,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetItemName = entity.BudgetItemName,
                ParentId = entity.ParentId,
                Grade = entity.Grade,
                TotalEstimateAmountUSD = entity.TotalEstimateAmountUSD,
                YearOfEstimateAmount = entity.YearOfEstimateAmount,
                NextYearOfEstimateAmount = entity.NextYearOfEstimateAmount,
                AutonomyBudget = entity.AutonomyBudget,
                NonAutonomyBudget = entity.NonAutonomyBudget,
                TotalNextYearOfEstimateAmount = entity.TotalNextYearOfEstimateAmount,
                Description = entity.Description,
                BudgetSourceCategoryName = entity.BudgetSourceCategoryName
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static GeneralEstimateModel FromDataTransferObject(GeneralEstimateEntity entity)
        {
            if (entity == null) return null;
            return new GeneralEstimateModel
            {
                BudgetItemName = entity.BudgetItemName,
                PreviousYearOfTotalEstimateAmount = entity.PreviousYearOfTotalEstimateAmount,
                YearOfEstimateAmount = entity.YearOfEstimateAmount,
                NextYearOfEstimateAmount = entity.NextYearOfEstimateAmount,
                Description = entity.Description
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static GeneralPaymentDetailEstimateModel FromDataTransferObject(GeneralPaymentDetailEstimateEntity entity)
        {
            if (entity == null) return null;
            return new GeneralPaymentDetailEstimateModel
            {
                BudgetItemId = entity.BudgetItemId,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetItemName = entity.BudgetItemName,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                ParentId = entity.ParentId,
                Grade = entity.Grade,
                TotalEstimateAmountUSD = entity.TotalEstimateAmountUSD,
                YearOfEstimateAmount = entity.YearOfEstimateAmount,
                NextYearOfEstimateAmount = entity.NextYearOfEstimateAmount,
                AutonomyBudget = entity.AutonomyBudget,
                NonAutonomyBudget = entity.NonAutonomyBudget,
                TotalNextYearOfEstimateAmount = entity.TotalNextYearOfEstimateAmount,
                Description = entity.Description,
                BudgetSourceCategoryName = entity.BudgetSourceCategoryName
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static FixedAssetB03HModel FromDataTransferObject(FixedAssetB03HEntity entity)
        {
            if (entity == null) return null;
            return new FixedAssetB03HModel
            {
                FixedAssetCategoryId = entity.FixedAssetCategoryId,
                FixedAssetCategoryCode = entity.FixedAssetCategoryCode,
                FixedAssetCategoryName = entity.FixedAssetCategoryName,
                ParentId = entity.ParentId,
                Unit = entity.Unit,
                QuantityOpening = entity.QuantityOpening,
                QuantityIncrement = entity.QuantityIncrement,
                QuantityDecrement = entity.QuantityDecrement,
                QuantityClosing = entity.QuantityClosing,
                OrgPriceOpening = entity.OrgPriceOpening,
                OrgPriceOpeningUSD = entity.OrgPriceOpeningUSD,
                OrgPriceOpeningCurrencyUSD = entity.OrgPriceOpeningCurrencyUSD,
                TotalOrgPriceOpeningUSD = entity.TotalOrgPriceOpeningUSD,
                OrgPriceIncrement = entity.OrgPriceIncrement,
                OrgPriceIncrementUSD = entity.OrgPriceIncrementUSD,
                OrgPriceIncrementCurrencyUSD = entity.OrgPriceIncrementCurrencyUSD,
                TotalOrgPriceIncrementUSD = entity.TotalOrgPriceIncrementUSD,
                OrgPriceDecrement = entity.OrgPriceDecrement,
                OrgPriceDecrementUSD = entity.OrgPriceDecrementUSD,
                OrgPriceDecrementCurrencyUSD = entity.OrgPriceDecrementCurrencyUSD,
                TotalOrgPriceDecrementUSD = entity.TotalOrgPriceDecrementUSD,
                OrgPriceClosing = entity.OrgPriceClosing,
                OrgPriceClosingUSD = entity.OrgPriceClosingUSD,
                OrgPriceClosingCurrencyUSD = entity.OrgPriceClosingCurrencyUSD,
                TotalOrgPriceClosingUSD = entity.TotalOrgPriceClosingUSD,
                Grade = entity.Grade,
                Sort = entity.Sort
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static FixedAssetB01Model FromDataTransferObject(FixedAssetB01Entity entity)
        {
            if (entity == null) return null;
            return new FixedAssetB01Model
            {
                OrderNumber = 0,
                FixedAssetCategoryCode = entity.FixedAssetCategoryCode,
                FixedAssetId = entity.FixedAssetId,
                FixedAssetCode = entity.FixedAssetCode,
                FixedAssetName = entity.FixedAssetName,
                ParentId = entity.ParentId,
                YearOfUsing = entity.YearOfUsing,
                Description = entity.Description,
                AddressUsing = entity.AddressUsing,
                DepreciationRate = entity.DepreciationRate,
                Unit = entity.Unit,
                SerialNumber = entity.SerialNumber,
                OrgPrice = entity.OrgPrice,
                QuantityDecrement = entity.QuantityDecrement,
                OrgPriceDecrement = entity.OrgPriceDecrement,
                OrgPriceDecrementUSD = entity.OrgPriceDecrementUSD,
                OrgPriceDecrementCurrencyUSD = entity.OrgPriceDecrementCurrencyUSD,
                TotalOrgPriceDecrementUSD = entity.TotalOrgPriceDecrementUSD,
                QuantityAnnualDepreciation = entity.QuantityAnnualDepreciation,
                AnnualDepreciationAmount = entity.AnnualDepreciationAmount,
                AnnualDepreciationAmountUSD = entity.AnnualDepreciationAmountUSD,
                AnnualDepreciationAmountCurrencyUSD = entity.AnnualDepreciationAmountCurrencyUSD,
                TotalAnnualDepreciationAmountUSD = entity.TotalAnnualDepreciationAmountUSD,
                QuantityRemainingDecrement = entity.QuantityRemainingDecrement,
                RemainingAmountDecrement = entity.RemainingAmountDecrement,
                RemainingAmountDecrementUSD = entity.RemainingAmountDecrementUSD,
                RemainingAmountDecrementCurrencyUSD = entity.RemainingAmountDecrementCurrencyUSD,
                TotalRemainingAmountDecrementUSD = entity.TotalRemainingAmountDecrementUSD,
                Grade = entity.Grade,
                Sort = entity.Sort
            };
        }

        /// <summary>
        /// Froms the payment detail data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static FixedAssetC55aHDModel FromDataTransferObject(FixedAssetC55aHDEntity entity)
        {
            if (entity == null) return null;
            return new FixedAssetC55aHDModel
            {
                OrderNumber = entity.OrderNumber,
                FixedAssetId = entity.FixedAssetId,
                FixedAssetName = entity.FixedAssetName,
                FixedAssetCategoryCode = entity.FixedAssetCategoryCode,
                FixedAssetCategoryName = entity.FixedAssetCategoryName,
                YearOfUsing = entity.YearOfUsing,
                AddressUsing = entity.AddressUsing,
                Unit = entity.Unit,
                SerialNumber = entity.SerialNumber,
                QuantityOrgPrice = entity.QuantityOrgPrice,
                OrgPrice = entity.OrgPrice,
                OrgPriceUSD = entity.OrgPriceUSD,
                OrgPriceCurrencyUSD = entity.OrgPriceCurrencyUSD,
                TotalOrgPriceUSD = entity.TotalOrgPriceUSD,
                AnnualDepreciationAmount = entity.AnnualDepreciationAmount,
                RemainigAmount = entity.RemainigAmount,
                LifeTime = entity.LifeTime,
                AnnualDepreciationRate = entity.AnnualDepreciationRate,
                QuantityDepreciation = entity.QuantityDepreciation,
                DepreciationYearAmount = entity.DepreciationYearAmount,
                DepreciationYearAmountUSD = entity.DepreciationYearAmountUSD,
                DepreciationYearAmountCurrencyUSD = entity.DepreciationYearAmountCurrencyUSD,
                TotalDepreciationYearAmountUSD = entity.TotalDepreciationYearAmountUSD
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static FixedAssetFAInventoryModel FromDataTransferObject(FixedAssetFAInventoryEntity entity)
        {
            if (entity == null) return null;
            return new FixedAssetFAInventoryModel
            {
                OrderNumber = entity.OrderNumber,
                FixedAssetCategoryCode = entity.FixedAssetCategoryCode,
                FixedAssetId = entity.FixedAssetId,
                FixedAssetCode = entity.FixedAssetCode,
                FixedAssetName = entity.FixedAssetName,
                ParentId = entity.ParentId,
                YearOfUsing = entity.YearOfUsing,
                Description = entity.Description,
                Unit = entity.Unit,
                DepreciationRate = entity.DepreciationRate,
                SerialNumber = entity.SerialNumber,
                CountryProduction = entity.CountryProduction,
                Quantity = entity.Quantity,
                OrgPrice = entity.OrgPrice,
                OrgPriceUsd = entity.OrgPriceUsd,
                OrgPriceCurrencyUsd = entity.OrgPriceCurrencyUsd,
                TotalOrgPriceUsd = entity.TotalOrgPriceUsd,

                QuantityInvetory = entity.QuantityInvetory,
                OrgPriceInvetory = entity.OrgPriceInvetory,
                OrgPriceCurrencyInvetoryUsd = entity.OrgPriceCurrencyInvetoryUsd,
                OrgPriceInvetoryUsd = entity.OrgPriceInvetoryUsd,
                TotalOrgPriceInvetoryUsd = entity.TotalOrgPriceInvetoryUsd,

                QuantityDifference = entity.QuantityDifference,
                OrgPriceDifference = entity.OrgPriceDifference,
                OrgPriceCurrencyDifferenceUsd = entity.OrgPriceCurrencyDifferenceUsd,
                OrgPriceDifferenceUsd = entity.OrgPriceDifferenceUsd,
                TotalOrgPriceDifferenceUsd = entity.TotalOrgPriceDifferenceUsd,

                Grade = entity.Grade,
                Sort = entity.Sort,
                IsParent = entity.IsParent
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static FixedAssetFAInventoryHouseModel FromDataTransferObject(FixedAssetFAInventoryHouseEntity entity)
        {
            if (entity == null) return null;
            return new FixedAssetFAInventoryHouseModel
            {
                OrderNumber = entity.OrderNumber,
                FixedAssetId = entity.FixedAssetId,
                FixedAssetCode = entity.FixedAssetCode,
                FixedAssetName = entity.FixedAssetName,
                UsedDate = entity.UsedDate,
                ProductionYear = entity.ProductionYear,
                Description = entity.Description,
                OrgPrice = entity.OrgPrice,
                OrgPriceUsd = entity.OrgPriceUsd,
                OrgPriceCurrencyUsd = entity.OrgPriceCurrencyUsd,
                OrgPriceDifference = entity.OrgPriceDifference,
                OrgPriceCurrencyDifferenceUsd = entity.OrgPriceCurrencyDifferenceUsd,
                OrgPriceDifferenceUsd = entity.OrgPriceDifferenceUsd,
                AreaOfBuilding = entity.AreaOfBuilding,
                AreaOfFloor = entity.AreaOfFloor,
                NumberOfFloor = entity.NumberOfFloor,
                WorkingArea = entity.WorkingArea,
                GradeHouse = entity.GradeHouse,
                GuestHouseArea = entity.GuestHouseArea,
                HousingArea = entity.HousingArea,
                OtherArea = entity.OtherArea,
                RemainingAmount = entity.RemainingAmount
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static FixedAssetFAInventoryCarModel FromDataTransferObject(FixedAssetFAInventoryCarEntity entity)
        {
            if (entity == null) return null;
            return new FixedAssetFAInventoryCarModel
            {
                OrderNumber = entity.OrderNumber,
                FixedAssetId = entity.FixedAssetId,
                FixedAssetCode = entity.FixedAssetCode,
                FixedAssetName = entity.FixedAssetName,
                UsedDate = entity.UsedDate,
                Description = entity.Description,
                SerialNumber = entity.SerialNumber,
                Brand = entity.Brand,
                CountryProduction = entity.CountryProduction,
                OrgPrice = entity.OrgPrice,
                OrgPriceUsd = entity.OrgPriceUsd,
                OrgPriceCurrencyUsd = entity.OrgPriceCurrencyUsd,
                OrgPriceDifference = entity.OrgPriceDifference,
                OrgPriceDifferenceUsd = entity.OrgPriceDifferenceUsd,
                OrgPriceCurrencyDifferenceUsd = entity.OrgPriceCurrencyDifferenceUsd,
                ControlPlate = entity.ControlPlate,
                NumberOfSeat = entity.NumberOfSeat,
                ProductionYear = entity.ProductionYear,
                Car1 = entity.Car1,
                Car2 = entity.Car2,
                Car = entity.Car,
                RemainingAmount = entity.RemainingAmount
            };
        }

        internal static FixedAsset30KPart2Model FromDataTransferObject(FixedAsset30KPart2Entity entity)
        {
            if (entity == null) return null;
            return new FixedAsset30KPart2Model
            {
                FixedAssetId = entity.FixedAssetId,
                FixedAssetCategoryCode = entity.FixedAssetCategoryCode,
                FixedAssetName = entity.FixedAssetName,
                FixedAssetCode = entity.FixedAssetCode,
                ProductionYear = entity.ProductionYear,
                CountryProduction = entity.CountryProduction,
                DateOfUsing = entity.DateOfUsing,
                OrgPrice = entity.OrgPrice,
                OrgPriceDifference = entity.OrgPriceDifference,
                RemainingAmount = entity.RemainingAmount,
                StateManagement = entity.StateManagement,
                Bussiness = entity.Bussiness,
                Description = entity.Description
            };
        }

        internal static FixedAssetCardModel FromDataTransferObject(FixedAssetCardEntity entity)
        {
            if (entity == null) return null;
            return new FixedAssetCardModel
            {
                FixedAssetId = entity.FixedAssetId,
                OrderNumber = entity.OrderNumber,
                FixedAssetName = entity.FixedAssetName,
                FixedAssetCode = entity.FixedAssetCode,
                ProductionYear = entity.ProductionYear,
                MadeIn = entity.MadeIn,
                UsedDate = entity.UsedDate,
                PurchasedDate = entity.PurchasedDate,
                OrgPrice = entity.OrgPrice,
                OrgPriceUsd = entity.OrgPriceUsd,
                TotalOrgPriceUsd = entity.TotalOrgPriceUsd,
                DepartmentName = entity.DepartmentName,
                EmployeeName = entity.EmployeeName
            };
        }

        internal static FixedAssetB03H30KModel FromDataTransferObject(FixedAssetB03H30KEntity entity)
        {
            if (entity == null) return null;
            return new FixedAssetB03H30KModel
            {
                FixedAssetId = entity.FixedAssetId,
                FixedAssetCategoryCode = entity.FixedAssetCategoryCode,
                FixedAssetName = entity.FixedAssetName,
                FixedAssetCode = entity.FixedAssetCode,
                FixedAssetType = entity.FixedAssetType,
                Grade = entity.Grade,
                QuantityOpening = entity.QuantityOpening,
                AreaOpening = entity.AreaOpening,
                OrgPriceOpening = entity.OrgPriceOpening,
                OrgPriceOpeningDifference = entity.OrgPriceOpeningDifference,
                QuantityIncrement = entity.QuantityIncrement,
                AreaIncrement = entity.AreaIncrement,
                OrgPriceIncrement = entity.OrgPriceIncrement,
                OrgPriceIncrementDifference = entity.OrgPriceIncrementDifference,
                QuantityDecrement = entity.QuantityDecrement,
                AreaDecrement = entity.AreaDecrement,
                OrgPriceDecrement = entity.OrgPriceDecrement,
                OrgPriceDecrementDifference = entity.OrgPriceDecrementDifference,
                QuantityClosing = entity.QuantityClosing,
                AreaClosing = entity.AreaClosing,
                OrgPriceClosing = entity.OrgPriceClosing,
                OrgPriceClosingDifference = entity.OrgPriceClosingDifference
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static FixedAssetB02Model FromDataTransferObject(FixedAssetB02Entity entity)
        {
            if (entity == null) return null;
            return new FixedAssetB02Model
            {
                OrderNumber = entity.OrderNumber,
                FixedAssetCategoryCode = entity.FixedAssetCategoryCode,
                FixedAssetId = entity.FixedAssetId,
                FixedAssetCode = entity.FixedAssetCode,
                FixedAssetName = entity.FixedAssetName,
                ParentId = entity.ParentId,
                YearOfUsing = entity.YearOfUsing,
                AddressUsing = entity.AddressUsing,
                DepreciationRate = entity.DepreciationRate,
                Description = entity.Description,
                Unit = entity.Unit,
                SerialNumber = entity.SerialNumber,
                CountryProduction = entity.CountryProduction,
                Quantity = entity.Quantity,
                OrgPrice = entity.OrgPrice,
                OrgPriceUsd = entity.OrgPriceUsd,
                OrgPriceCurrencyUsd = entity.OrgPriceCurrencyUsd,
                TotalOrgPriceUsd = entity.TotalOrgPriceUsd,
                Grade = entity.Grade,
                Sort = entity.Sort

            };
        }
        /// <summary>
        /// Froms the payment detail data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static FixedAssetS31HModel FromDataTransferObject(FixedAssetS31HEntity entity)
        {
            if (entity == null) return null;
            return new FixedAssetS31HModel
            {
                PostedDate = entity.PostedDate,
                RefNo = entity.RefNo,
                RefDate = entity.RefDate,
                FixedAssetName = entity.FixedAssetName,
                FixedAssetCode = entity.FixedAssetCode,
                DepartmentName = entity.DepartmentName,
                EmployeeName = entity.EmployeeName,
                YearOfUsing = entity.YearOfUsing,
                LifeTime = entity.LifeTime,
                AnnualDepreciationRate = entity.AnnualDepreciationRate,
                OrgPrice = entity.OrgPrice,
                AnnualDepreciationAmount = entity.AnnualDepreciationAmount,
                RemainingPriceBeforeDecrement = entity.RemainingPriceBeforeDecrement
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static C30BBModel FromDataTransferObject(C30BBEntity entity)
        {
            if (entity == null) return null;
            return new C30BBModel
            {
                AccountNumber = entity.AccountNumber,
                PostedDate = entity.PostedDate,
                RefDate = entity.RefDate,
                RefNo = entity.RefNo,
                Address = entity.Address,
                CorrespondingAccountNumber = entity.CorrespondingAccountNumber,
                DocumentInclude = entity.DocumentInclude,
                ExchangeRate = entity.ExchangeRate,
                IsSelect = entity.IsSelect,
                JournalMemo = entity.JournalMemo,
                RefId = entity.RefId,
                TotalAmount = entity.TotalAmount,
                TotalAmountExchange = entity.TotalAmountExchange,
                Trader = entity.Trader,
                CurrencyCode = entity.CurrencyCode,
                ContactName = entity.ContactName

            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static CashReportModel FromDataTransferObject(CashReportEntity entity)
        {
            if (entity == null) return null;
            return new CashReportModel
            {
                AccountNumber = entity.AccountNumber,
                AmountType = entity.AmountType,
                CorrespondingAccountNumber = entity.CorrespondingAccountNumber,
                Description = entity.Description,
                FromDate = entity.FromDate,
                PayAmount = entity.PayAmount,
                PostedDate = entity.PostedDate,
                ReceiptAmount = entity.ReceiptAmount,
                RefNo = entity.RefNo,
                RestAmount = entity.RestAmount,
                ToDate = entity.ToDate,
                AccumulatedPayAmount = entity.AccumulatedPayAmount,
                AccumulatedReceiptAmount = entity.AccumulatedReceiptAmount,
                RefId = entity.RefId,
                RefTypeId = entity.RefTypeId


            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static S03BHModel FromDataTransferObject(S03BHEntity entity)
        {
            if (entity == null) return null;
            return new S03BHModel
            {
                AccountNumber = entity.AccountNumber,
                CorrespondingAccountNumber = entity.CorrespondingAccountNumber,
                Description = entity.Description,
                PostedDate = entity.PostedDate,
                BudgetItemCode = entity.BudgetItemCode,
                AccumulatedAccountNumbber = entity.AccumulatedAccountNumbber,
                AccumulatedCorrAccountNumbber = entity.AccumulatedCorrAccountNumbber,
                AmountAccountNumbber = entity.AmountAccountNumbber,
                AmountCorrAccountNumbber = entity.AmountCorrAccountNumbber,
                AmountOgrAccountNumbber = entity.AmountOgrAccountNumbber,
                AmountOgrCorrAccountNumbber = entity.AmountOgrCorrAccountNumbber,
                RefNo = entity.RefNo,
                RefId = entity.RefId,
                RefTypeId = entity.RefTypeId
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static B03BNGModel FromDataTransferObject(B03BNGEntity entity)
        {
            if (entity == null) return null;
            return new B03BNGModel
            {
                AccountingObjectCode = entity.AccountingObjectCode,
                AccountingObjectName = entity.AccountingObjectName,
                AccountingObjectGroup = entity.AccountingObjectGroup,
                OpeningAmount = entity.OpeningAmount,
                ReceiveAdvance = entity.ReceiveAdvance,
                AdvancePayment = entity.AdvancePayment,
                ClosingAmount = entity.ClosingAmount,
                Type = entity.Type
            };
        }

        internal static F03BNGModel FromDataTransferObject(F03BNGEntity entity)
        {
            if (entity == null) return null;
            return new F03BNGModel
            {
                AccumulatedAutonomyBudgetAmount = entity.AccumulatedAutonomyBudgetAmount,
                AccumulatedAutonomyOtherAmount = entity.AccumulatedAutonomyOtherAmount,
                AccumulatedNonAutonomyBudgetAmount = entity.AccumulatedNonAutonomyBudgetAmount,
                AccumulatedNonAutonomyOtherAmount = entity.AccumulatedNonAutonomyOtherAmount,
                AccumulatedProjectBudgetAmount = entity.AccumulatedProjectBudgetAmount,
                AccumulatedRegulateOtherAmount = entity.AccumulatedRegulateOtherAmount,
                AccumulatedDiplomaticBudgetAmount = entity.AccumulatedDiplomaticBudgetAmount,
                AccumulatedTotalAmount = entity.AccumulatedTotalAmount,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetItemId = entity.BudgetItemId,
                BudgetItemType = entity.BudgetItemType,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                Content = entity.Content,
                FontStyle = entity.FontStyle,
                Grade = entity.Grade,
                ParentId = entity.ParentId,
                ThisMonthAutonomyBudgetAmount = entity.ThisMonthAutonomyBudgetAmount,
                ThisMonthAutonomyOtherAmount = entity.ThisMonthAutonomyOtherAmount,
                ThisMonthNonAutonomyBudgetAmount = entity.ThisMonthNonAutonomyBudgetAmount,
                ThisMonthNonAutonomyOtherAmount = entity.ThisMonthNonAutonomyOtherAmount,
                ThisMonthProjectBudgetAmount = entity.ThisMonthProjectBudgetAmount,
                ThisMonthRegulateOtherAmount = entity.ThisMonthRegulateOtherAmount,
                ThisMonthDiplomaticBudgetAmount = entity.ThisMonthDiplomaticBudgetAmount,
                ThisMonthTotalAmount = entity.ThisMonthTotalAmount
            };
        }

        internal static F331BNGModel FromDataTransferObject(F331BNGEntity entity)
        {
            if (entity == null) return null;
            return new F331BNGModel
            {
                AccumulatedAmount = entity.AccumulatedAmount,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetItemId = entity.BudgetItemId,
                BudgetItemType = entity.BudgetItemType,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                Content = entity.Content,
                FontStyle = entity.FontStyle,
                Grade = entity.Grade,
                ParentId = entity.ParentId,
                ThisMonthAmount = entity.ThisMonthAmount
            };
        }

        internal static B09BNGModel FromDataTransferObject(B09BNGEntity entity)
        {
            if (entity == null) return null;
            return new B09BNGModel
            {
                AccumulatedAmount = entity.AccumulatedAmount,
                ItemId = entity.ItemId,
                ItemName = entity.ItemName,
                FontStyle = entity.FontStyle,
                Grade = entity.Grade,
                ParentId = entity.ParentId,
                Amount = entity.Amount
            };
        }
        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static SearchModel FromDataTransferObject(SearchEntity entity)
        {
            if (entity == null) return null;
            return new SearchModel
            {
                RefId = entity.RefId,
                RefNo = entity.RefNo,
                RefDate = DateTime.Parse(entity.RefDate).ToShortDateString(),
                PostedDate = DateTime.Parse(entity.PostedDate).ToShortDateString(),
                RefTypeId = entity.RefTypeId,
                CurrencyCode = entity.CurrencyCode,
                JournalMemo = entity.JournalMemo,
                TotalAmount = entity.AmountOc,

                AccountNumber = entity.AccountNumber,
                CorrespondingAccountNumber = entity.CorrespondingAccountNumber,
                AmountExchange = entity.AmountExchange,
                BudgetSourceCode = entity.BudgetSourceCode,
                BudgetItemCode = entity.BudgetItemCode,
                AccountingObjectId = entity.AccountingObjectId,
                CustomerId = entity.CustomerId,
                EmployeeId = entity.EmployeeId,
                VendorId = entity.VendorId,
                AccountingObjectCode = entity.AccountingObjectCode,
                CustomerCode = entity.CustomerCode,
                EmployeeCode = entity.EmployeeCode,
                VendorCode = entity.VendorCode,
                ProjectId = entity.ProjectId,
                ProjectCode = entity.ProjectCode,
                InventoryItemCode = entity.InventoryItemCode,
                InventoryItemId = entity.InventoryItemId,
                VoucherTypeId = entity.VoucherTypeId,
                VoucherTypeName = entity.VoucherTypeName,
                RefTypeName = entity.RefTypeName,
                BudgetGroupCode = entity.BudgetGroupCode,
                DepartmentCode = entity.DepartmentCode,
                FixedAssetCode = entity.FixedAssetCode,
                ExchangeRate = entity.ExchangeRate,
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static FixedAssetLedgerModel FromDataTransferObject(FixedAssetLedgerEntity entity)
        {
            if (entity == null) return null;
            return new FixedAssetLedgerModel
            {
                FixedAssetLedgerId = entity.FixedAssetLedgerId,
                RefId = entity.RefId,
                RefTypeId = entity.RefTypeId,
                RefNo = entity.RefNo,
                RefDate = entity.RefDate,
                PostedDate = entity.PostedDate,
                FixedAssetId = entity.FixedAssetId,
                DepartmentId = entity.DepartmentId,
                LifeTime = entity.LifeTime,
                CurrencyCode = entity.CurrencyCode,
                AnnualDepreciationRate = entity.AnnualDepreciationRate,
                AnnualDepreciationAmount = entity.AnnualDepreciationAmount,
                ExchangeRate = entity.ExchangeRate,
                OrgPriceAccount = entity.OrgPriceAccount,
                OrgPriceDebitAmount = entity.OrgPriceDebitAmount,
                OrgPriceCreditAmount = entity.OrgPriceCreditAmount,
                OrgPriceDebitAmountExchange = entity.OrgPriceDebitAmountExchange,
                OrgPriceCreditAmountExchange = entity.OrgPriceCreditAmountExchange,
                DepreciationAccount = entity.DepreciationAccount,
                DepreciationDebitAmount = entity.DepreciationDebitAmount,
                DepreciationCreditAmount = entity.DepreciationCreditAmount,
                DepreciationDebitAmountExchange = entity.DepreciationDebitAmountExchange,
                DepreciationCreditAmountExchange = entity.DepreciationCreditAmountExchange,
                BudgetSourceAccount = entity.BudgetSourceAccount,
                BudgetSourcelDebitAmount = entity.BudgetSourcelDebitAmount,
                BudgetSourceCreditAmount = entity.BudgetSourceCreditAmount,
                BudgetSourcelDebitAmountExchange = entity.BudgetSourcelDebitAmountExchange,
                BudgetSourceCreditAmountExchange = entity.BudgetSourceCreditAmountExchange,
                JournalMemo = entity.JournalMemo,
                Description = entity.Description,
                Quantity = entity.Quantity
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static FixedAssetVoucherModel FromDataTransferObject(FixedAssetVoucherEntity entity)
        {
            if (entity == null) return null;
            return new FixedAssetVoucherModel
            {
                RefId = entity.RefId,
                RefTypeId = entity.RefTypeId,
                RefNo = entity.RefNo,
                PostedDate = entity.PostedDate.ToString("dd/MM/yyyy"),
                Description = entity.Description,
                AccountNumber = entity.AccountNumber,
                CorrespondingAccountNumber = entity.CorrespondingAccountNumber,
                AmountExchange = entity.AmountExchange,
                AmountOC = entity.AmountOC,
                AccumDepreciationAmount = entity.AccumDepreciationAmount,
                AccumDepreciationAmountUSD = entity.AccumDepreciationAmountUSD,
                RemainingAmount = entity.RemainingAmount,
                RemainingAmountUSD = entity.RemainingAmountUSD,
                AnnualDepreciationAmount = entity.AnnualDepreciationAmount,
                AnnualDepreciationAmountUSD = entity.AnnualDepreciationAmountUSD

            };

        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static RoleModel FromDataTransferObject(RoleEntity entity)
        {
            if (entity == null) return null;
            return new RoleModel
            {
                RoleId = entity.RoleId,
                RoleName = entity.RoleName,
                Description = entity.Description,
                IsActive = entity.IsActive,
                RoleSiteModels = FromDataTransferObjects(entity.RoleSiteEntities)
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static SiteModel FromDataTransferObject(SiteEntity entity)
        {
            if (entity == null) return null;
            return new SiteModel
            {
                SiteId = entity.SiteId,
                SiteCode = entity.SiteCode,
                SiteName = entity.SiteName,
                Description = entity.Description,
                ParentId = entity.ParentId,
                Order = entity.Order,
                IsActive = entity.IsActive,
                PermissionSiteModels = FromDataTransferObjects(entity.PermissionSiteEntities)
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static PermissionModel FromDataTransferObject(PermissionEntity entity)
        {
            if (entity == null) return null;
            return new PermissionModel
            {
                PermissionId = entity.PermissionId,
                PermissionCode = entity.PermissionCode,
                PermissionName = entity.PermissionName,
                Description = entity.Description,
                IsActive = entity.IsActive
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static PermissionSiteModel FromDataTransferObject(PermissionSiteEntity entity)
        {
            return new PermissionSiteModel
            {
                PermissionSiteId = entity.PermissionSiteId,
                SiteId = entity.SiteId,
                PermissionId = entity.PermissionId,
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static RoleSiteModel FromDataTransferObject(RoleSiteEntity entity)
        {
            return new RoleSiteModel
            {
                RoleSiteId = entity.RoleSiteId,
                RoleId = entity.RoleId,
                SiteId = entity.SiteId,
                PermissionId = entity.PermissionId
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static UserProfileModel FromDataTransferObject(UserProfileEntity entity)
        {
            return new UserProfileModel
            {
                UserProfileId = entity.UserProfileId,
                UserProfileName = entity.UserProfileName,
                FullName = entity.FullName,
                Password = entity.Password,
                IsActive = entity.IsActive,
                Email = entity.Email,
                CreateDate = entity.CreateDate == null ? null : ((DateTime)entity.CreateDate).ToShortDateString(),
                Description = entity.Description
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static OpeningFixedAssetEntryModel FromDataTransferObject(OpeningFixedAssetEntryEntity entity)
        {
            return new OpeningFixedAssetEntryModel
            {
                AccountId = entity.AccountId,
                ParentId = entity.ParentId,
                AccountName = entity.AccountName,
                AccountNumber = entity.AccountNumber,
                AmountOc = entity.AmountOc,
                AmountExchange = entity.AmountExchange,
                RefId = entity.RefId,
                RefNo = entity.RefNo,
                RefTypeId = entity.RefTypeId,
                PostedDate = entity.PostedDate,
                FixedAssetId = entity.FixedAssetId,
                DepartmentId = entity.DepartmentId,
                LifeTime = entity.LifeTime,
                IncrementDate = entity.IncrementDate,
                Unit = entity.Unit,
                UsedDate = entity.UsedDate,
                CurrencyCode = entity.CurrencyCode,
                ExchangeRate = entity.ExchangeRate,
                OrgPriceAccount = entity.OrgPriceAccount,
                OrgPriceDebitAmount = entity.OrgPriceDebitAmount,
                OrgPriceDebitAmountUSD = entity.OrgPriceDebitAmountUSD,
                DepreciationAccount = entity.DepreciationAccount,
                DepreciationCreditAmount = entity.DepreciationCreditAmount,
                DepreciationCreditAmountUSD = entity.DepreciationCreditAmountUSD,
                CapitalAccount = entity.CapitalAccount,
                CapitalCreditAmount = entity.CapitalCreditAmount,
                CapitalCreditAmountUSD = entity.CapitalCreditAmountUSD,
                RemainingAmount = entity.RemainingAmount,
                RemainingAmountUSD = entity.RemainingAmountUSD,
                BudgetChapterCode = entity.BudgetChapterCode,
                Description = entity.Description,
                Quantity = entity.Quantity,
                BudgetSourceCode = entity.BudgetSourceCode
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static EmployeeLeasingModel FromDataTransferObject(EmployeeLeasingEntity entity)
        {
            return new EmployeeLeasingModel
            {
                OrderNumber = entity.OrderNumber,
                EmployeeLeasingId = entity.EmployeeLeasingId,
                EmployeeLeasingCode = entity.EmployeeLeasingCode,
                EmployeeLeasingName = entity.EmployeeLeasingName,
                JobCandidate = entity.JobCandidate,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                Description = entity.Description,
                IsActive = entity.IsActive,
                IsLeasing = entity.IsLeasing,
                InsurancePrice = entity.InsurancePrice,
                SalaryPrice = entity.SalaryPrice,
                UniformPrice = entity.UniformPrice
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static BuildingModel FromDataTransferObject(BuildingEntity entity)
        {
            return new BuildingModel
            {
                OrderNumber = entity.OrderNumber,
                BuildingId = entity.BuildingId,
                BuildingCode = entity.BuildingCode,
                BuildingName = entity.BuildingName,
                JobCandidate = entity.JobCandidate,
                Address = entity.Address,
                Area = entity.Area,
                UnitPrice = entity.UnitPrice,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                Description = entity.Description,
                IsActive = entity.IsActive
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static EmployeeForEstimateModel FromDataTransferObject(EmployeeForEstimateEntity entity)
        {
            return new EmployeeForEstimateModel
            {
                OrderNumber = entity.OrderNumber,
                EmployeeName = entity.EmployeeName,
                JobCandidateName = entity.JobCandidateName,
                SubsitenceFee = entity.SubsitenceFee,
                WomenAllowance = entity.WomenAllowance,
                PluralityAllowance = entity.PluralityAllowance,
                StartedDate = entity.StartedDate,
                FinishedDate = entity.FinishedDate,
                Description = entity.Description
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static FixedAssetForEstimateModel FromDataTransferObject(FixedAssetForEstimateEntity entity)
        {
            return new FixedAssetForEstimateModel
            {
                OrderNumber = entity.OrderNumber,
                EmployeeName = entity.EmployeeName,
                JobCandidateName = entity.JobCandidateName,
                Address = entity.Address,
                UsingOfArea = entity.UsingOfArea,
                Description = entity.Description,
                PurchasedDate = entity.PurchasedDate
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static EstimateDetailStatementModel FromDataTransferObject(EstimateDetailStatementEntity entity)
        {
            return new EstimateDetailStatementModel
            {
                Employees = FromDataTransferObjects(entity.Employees),
                EmployeeOthers = FromDataTransferObjects(entity.EmployeeOthers),
                EmployeeLeasings = FromDataTransferObjects(entity.EmployeeLeasings),
                FixedAssets = FromDataTransferObjects(entity.FixedAssets),
                Buildings = FromDataTransferObjects(entity.Buildings),
                EstimateDetailStatementPartBs = FromDataTransferObjects(entity.EstimateDetailStatementPartBs),
                EstimateDetailStatementFixedAssets = FromDataTransferObjects(entity.EstimateDetailStatementFixedAssets),
                Mutuals = FromDataTransferObjects(entity.Mutuals),
                FixedAssetCars = FromDataTransferObjects(entity.FixedAssetCars)
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static FundStuationModel FromDataTransferObject(FundStuationEntity entity)
        {
            return new FundStuationModel
            {
                BudgetItemId = entity.BudgetItemId,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                BudgetItemName = entity.BudgetItemName,
                ParentId = entity.ParentId,
                Grade = entity.Grade,
                Sort = entity.Sort,
                BudgetItemType = entity.BudgetItemType,
                PreviousYearOfAutonomyBudget = entity.PreviousYearOfAutonomyBudget,
                PreviousYearOfNonAutonomyBudget = entity.PreviousYearOfNonAutonomyBudget,
                TotalEstimateAmountUSD = entity.TotalEstimateAmountUSD,
                YearOfAutonomyBudget = entity.YearOfAutonomyBudget,
                YearOfNonAutonomyBudget = entity.YearOfNonAutonomyBudget,
                YearOfEstimateAmount = entity.YearOfEstimateAmount,
                SixMonthBeginingAutonomyBudget = entity.SixMonthBeginingAutonomyBudget,
                SixMonthBeginingNonAutonomyBudget = entity.SixMonthBeginingNonAutonomyBudget,
                TotalAmountSixMonthBegining = entity.TotalAmountSixMonthBegining,
                SixMonthEndingAutonomyBudget = entity.SixMonthEndingAutonomyBudget,
                SixMonthEndingNonAutonomyBudget = entity.SixMonthEndingNonAutonomyBudget,
                TotalAmountSixMonthEnding = entity.TotalAmountSixMonthEnding,
                YearOfAmountAutonomyBudget = entity.YearOfAmountAutonomyBudget,
                YearOfAmountNonAutonomyBudget = entity.YearOfAmountNonAutonomyBudget,
                YearOfTotalAmount = entity.YearOfTotalAmount,
                YearOfDifferenceAmountAutonomyBudget = entity.YearOfDifferenceAmountAutonomyBudget,
                YearOfDifferenceAmountNonAutonomyBudget = entity.YearOfDifferenceAmountNonAutonomyBudget,
                YearOfDifferenceTotalAmount = entity.YearOfDifferenceTotalAmount,
                Description = entity.Description,
                BudgetSourceCategoryName = entity.BudgetSourceCategoryName
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static EstimateDetailStatementInfoModel FromDataTransferObject(EstimateDetailStatementInfoEntity entity)
        {
            if (entity == null) return null;
            return new EstimateDetailStatementInfoModel
            {
                EstimateDetailStatementId = entity.EstimateDetailStatementId,
                GeneralDescription = entity.GeneralDescription,
                EmployeeContractDescription = entity.EmployeeContractDescription,
                EmployeeLeasingDescription = entity.EmployeeLeasingDescription,
                BuildingOfFixedAssetDescription = entity.BuildingOfFixedAssetDescription,
                CarDescription = entity.CarDescription,
                DescriptionForBuilding = entity.DescriptionForBuilding,
                InventoryDescription = entity.InventoryDescription,
                PartC = entity.PartC,
                PartC1 = entity.PartC1,
                IsActive = entity.IsActive
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static EstimateDetailStatementPartBModel FromDataTransferObject(EstimateDetailStatementPartBEntity entity)
        {
            if (entity == null) return null;
            return new EstimateDetailStatementPartBModel
            {
                EstimateDetailStatementPartBId = entity.EstimateDetailStatementPartBId,
                OrderNumber = entity.OrderNumber,
                Description = entity.Description,
                Amount = entity.Amount,
                Note = entity.Note,
                IsActive = entity.IsActive
            };
        }

        internal static EstimateDetailStatementFixedAssetModel FromDataTransferObject(EstimateDetailStatementFixedAssetEntity entity)
        {
            if (entity == null) return null;
            return new EstimateDetailStatementFixedAssetModel
            {
                EstimateDetailStatementFixedAssetId = entity.EstimateDetailStatementFixedAssetId,
                OrderNumber = entity.OrderNumber,
                PurchasedYear = entity.PurchasedYear,
                OrgPriceUsd = entity.OrgPriceUsd,
                PurchasedOrgPriceUsd = entity.PurchasedOrgPriceUsd,
                Department = entity.Department,
                ReplacementReason = entity.ReplacementReason,
                PostedYear = entity.PostedYear,
                IsActive = entity.IsActive
            };
        }


        internal static CompanyProfileModel FromDataTransferObject(CompanyProfileEntity entity)
        {
            if (entity == null) return null;
            return new CompanyProfileModel
            {
                LineId = entity.LineId,
                AssetOwnArea = entity.AssetOwnArea,
                AssetOwnRoom = entity.AssetOwnRoom,
                AssetBuyDate = entity.AssetBuyDate,
                AssetOwnDescription = entity.AssetOwnDescription,
                AssetMutualArea = entity.AssetMutualArea,
                AssetMutualRoom = entity.AssetMutualRoom,
                AssetMutualMethod = entity.AssetMutualMethod,
                AssetMutualDescription = entity.AssetMutualDescription,
                AssetRentContractLen = entity.AssetRentContractLen,
                AssetRentPrice = entity.AssetRentPrice,
                AssetRentRoom = entity.AssetRentRoom,
                AssetRentArea = entity.AssetRentArea,
                AssetRentDescription = entity.AssetRentDescription,
                AssetNumberOfCars = entity.AssetNumberOfCars,
                AssetCarDetail = entity.AssetCarDetail,
                EmployeePayrollsTotal = entity.EmployeePayrollsTotal,
                EmployeeNumberOfWifeOrHusband = entity.EmployeeNumberOfWifeOrHusband,
                EmployeeNumberOfOfficers = entity.EmployeeNumberOfOfficers,
                EmployeeNumberOfStaff = entity.EmployeeNumberOfStaff,
                EmployeeOtherCompany = entity.EmployeeOtherCompany,
                EmployeeNumberOfSecondingOfficers = entity.EmployeeNumberOfSecondingOfficers,
                EmployeeDetail = entity.EmployeeDetail,
                EmployeeNumberOfRentLocal = entity.EmployeeNumberOfRentLocal,
                ProfileAddress = entity.ProfileAddress,
                ProfileFoundDate = entity.ProfileFoundDate,
                ProfileHeadPhone = entity.ProfileHeadPhone,
                ProfileAmbassadorName = entity.ProfileAmbassadorName,
                ProfileAmbassadorPhone = entity.ProfileAmbassadorPhone,
                ProfileAmbassadorStartDate = entity.ProfileAmbassadorStartDate,
                ProfileAmbassadorFinishDate = entity.ProfileAmbassadorFinishDate,
                ProfileAccountingManagerName = entity.ProfileAccountingManagerName,
                ProfileAccountingManagerPhone = entity.ProfileAccountingManagerPhone,
                ProfileAccountingManagerStartDate = entity.ProfileAccountingManagerStartDate,
                ProfileAccountingManagerFinishDate = entity.ProfileAccountingManagerFinishDate,
                ProfileAccountantName = entity.ProfileAccountantName,
                ProfileAccountantPhone = entity.ProfileAccountantPhone,
                ProfileAccountantStartDate = entity.ProfileAccountantStartDate,
                ProfileAccountantFinishDate = entity.ProfileAccountantFinishDate,
                ProfileMinimumSalary = entity.ProfileMinimumSalary,
                ProfileSalaryGroup = entity.ProfileSalaryGroup,
                ProfileWorkingArea = entity.ProfileWorkingArea,
                ProfileCurrencyCodeFinalization = entity.ProfileCurrencyCodeFinalization,
                ProfileServices = entity.ProfileServices,
                ProfileReportHeader = entity.ProfileReportHeader,
                ProfileBankName = entity.ProfileBankName,
                ProfileBankAddress = entity.ProfileBankAddress,
                ProfileBankAccount = entity.ProfileBankAccount,
                ProfileBankCIF = entity.ProfileBankCIF,
                OtherNote = entity.OtherNote,
                NativeCategory = entity.NativeCategory,
                ManagementArea = entity.ManagementArea
            };
        }


        #endregion

        #region FromDataTransferObjects

        internal static List<SalaryVoucherModel> FromDataTransferObjects(IList<SalaryVoucherEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }



        internal static List<AutoNumberListModel> FromDataTransferObjects(IList<AutoNumberListEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        internal static List<MutualModel> FromDataTransferObjects(IList<MutualEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<SearchModel> FromDataTransferObjects(IList<SearchEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<C22HModel> FromDataTransferObjects(IList<C22HEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<C30BB501Model> FromDataTransferObjects(IList<C30BB501Entity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<B01HModel> FromDataTransferObjects(IList<B01HEntity> entities)
        {
            if (entities == null)
                return null;
            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<FixedAssetHousingReportModel> FromDataTransferObjects(IList<FixedAssetHousingReportEntity> entities)
        {
            if (entities == null)
                return null;
            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<C30BBModel> FromDataTransferObjects(IList<C30BBEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<CashReportModel> FromDataTransferObjects(IList<CashReportEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<S03BHModel> FromDataTransferObjects(IList<S03BHEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<S03AHModel> FromDataTransferObjects(IList<S03AHEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<B14QModel> FromDataTransferObjects(IList<B14QEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<A02LDTLModel> FromDataTransferObjects(IList<A02LDTLEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<AccountingVoucherModel> FromDataTransferObjects(IList<AccountingVoucherEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<C11HModel> FromDataTransferObjects(IList<C11HEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<ItemTransactionModel> FromDataTransferObjects(IList<ItemTransactionEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<ItemTransactionDetailModel> FromDataTransferObjects(IList<ItemTransactionDetailEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<SalaryModel> FromDataTransferObjects(IList<SalaryEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<CapitalAllocateModel> FromDataTransferObjects(IList<CapitalAllocateEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }


        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>IList&lt;OpeningSupplyEntryModel&gt;.</returns>
        internal static IList<OpeningSupplyEntryModel> FromDataTransferObjects(IList<OpeningSupplyEntryEntity> entities)
        {
            if (entities == null)
                return null;
            return entities.Select(FromDataTransferObjectOpeningSupply).ToList();
           
           //return entities.Select(m => AutoMapper(m, new OpeningSupplyEntryModel())).ToList();
        }

        internal static OpeningSupplyEntryModel FromDataTransferObject(OpeningSupplyEntryEntity entity)
        {
            if (entity == null)
                return null;
            return new OpeningSupplyEntryModel
            {
                RefId = entity.RefId,
                RefType = entity.RefType,
                PostedDate = entity.PostedDate,
                CurrencyCode = entity.CurrencyCode,
                ExchangeRate = entity.ExchangeRate,
                AccountNumber = entity.AccountNumber,
                InventoryItemId = entity.InventoryItemId,
                DepartmentId = entity.DepartmentId,
                Quantity = entity.Quantity,
                UnitPriceOc = entity.UnitPriceOc,
                UnitPriceExchange = entity.UnitPriceExchange,
                AmountOc = entity.AmountOc,
                AmountExchange = entity.AmountExchange,
                SortOrder = entity.SortOrder,
                RefDate = entity.RefDate
            };
        }

        internal static IList<CurrencyModel> FromDataTransferObjects(IList<CurrencyEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        internal static IList<BudgetSourcePropertyModel> FromDataTransferObjects(IList<BudgetSourcePropertyEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<AccountModel> FromDataTransferObjects(IList<AccountEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<AccountCategoryModel> FromDataTransferObjects(IList<AccountCategoryEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<DepartmentModel> FromDataTransferObjects(IList<DepartmentEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<BudgetSourceCategoryModel> FromDataTransferObjects(IList<BudgetSourceCategoryEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<BudgetItemModel> FromDataTransferObjects(IList<BudgetItemEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<PlanTemplateListModel> FromDataTransferObjects(IList<PlanTemplateListEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<PlanTemplateItemModel> FromDataTransferObjects(IList<PlanTemplateItemEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        internal static IList<JournalEntryAccountModel> FromDataTransferObjects(IList<JournalEntryAccountEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<FixedAssetCategoryModel> FromDataTransferObjects(IList<FixedAssetCategoryEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<FixedAssetModel> FromDataTransferObjects(IList<FixedAssetEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<PayItemModel> FromDataTransferObjects(IList<PayItemEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<BudgetChapterModel> FromDataTransferObjects(IList<BudgetChapterEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<BudgetCategoryModel> FromDataTransferObjects(IList<BudgetCategoryEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<MergerFundModel> FromDataTransferObjects(IList<MergerFundEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<BudgetSourceModel> FromDataTransferObjects(IList<BudgetSourceEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static List<VendorModel> FromDataTransferObjects(List<VendorEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static List<CustomerModel> FromDataTransferObjects(List<CustomerEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<VoucherListModel> FromDataTransferObjects(IList<VoucherListEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<EmployeeModel> FromDataTransferObjects(IList<EmployeeEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<EmployeePayItemModel> FromDataTransferObjects(IList<EmployeePayItemEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<StockModel> FromDataTransferObjects(IList<StockEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<CaptitalAllocateVoucherModel> FromDataTransferObjects(IList<CaptitalAllocateVoucherEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<AccountTranferVourcherModel> FromDataTransferObjects(IList<AccountTranferVourcherEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<InventoryItemModel> FromDataTransferObjects(IList<InventoryItemEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<BankModel> FromDataTransferObjects(IList<BankEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<ExchangeRateModel> FromDataTransferObjects(IList<ExchangeRateEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<AccountTranferModel> FromDataTransferObjects(IList<AccountTranferEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<DBOptionModel> FromDataTransferObjects(IList<DBOptionEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static List<ReportListModel> FromDataTransferObjects(List<ReportListEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static List<ReportGroupModel> FromDataTransferObjects(List<ReportGroupEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<AudittingLogModel> FromDataTransferObjects(IList<AudittingLogEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<EstimateModel> FromDataTransferObjects(IList<EstimateEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<EstimateDetailModel> FromDataTransferObjects(IList<EstimateDetailEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>
        /// IList{DepositModel}.
        /// </returns>
        internal static IList<DepositModel> FromDataTransferObjects(IList<DepositEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>
        /// IList{DepositDetailModel}.
        /// </returns>
        internal static IList<DepositDetailModel> FromDataTransferObjects(IList<DepositDetailEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the receipt data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static List<ReceiptVoucherModel> FromReceiptDataTransferObjects(IList<CashEntity> entities)
        {
            return entities == null ? null : entities.Select(FromReceiptDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the payment data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static List<CashModel> FromDataTransferObjects(IList<CashEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static List<GeneralVocherModel> FromDataTransferObjects(IList<GeneralEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<VoucherTypeModel> FromDataTransferObjects(IList<VoucherTypeEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<AutoBusinessModel> FromDataTransferObjects(IList<AutoBusinessEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<ProjectModel> FromDataTransferObjects(IList<ProjectEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<CompanyProfileModel> FromDataTransferObjects(IList<CompanyProfileEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<RefTypeModel> FromDataTransferObjects(IList<RefTypeEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<FixedAssetArmortizationModel> FromDataTransferObjects(IList<FAArmortizationEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<FixedAssetArmortizationDetailModel> FromDataTransferObjects(IList<FAArmortizationDetailEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<FixedAssetDecrementModel> FromDataTransferObjects(IList<FADecrementEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<FixedAssetDecrementDetailModel> FromDataTransferObjects(IList<FADecrementDetailEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<FixedAssetIncrementModel> FromDataTransferObjects(IList<FAIncrementEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<FixedAssetIncrementDetailModel> FromDataTransferObjects(IList<FAIncrementDetailEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<FixedAssetCurrencyModel> FromDataTransferObjects(IList<FixedAssetCurrencyEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<OpeningAccountEntryModel> FromDataTransferObjects(IList<OpeningAccountEntryEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<OpeningInventoryEntryModel> FromDataTransferObjects(IList<OpeningInventoryEntryEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }
        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<OpeningAccountEntryDetailModel> FromDataTransferObjects(IList<OpeningAccountEntryDetailEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<GeneralReceiptEstimateModel> FromDataTransferObjects(IList<GeneralReceiptEstimateEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<GeneralPaymentEstimateModel> FromDataTransferObjects(IList<GeneralPaymentEstimateEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<GeneralEstimateModel> FromDataTransferObjects(IList<GeneralEstimateEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<GeneralPaymentDetailEstimateModel> FromDataTransferObjects(IList<GeneralPaymentDetailEstimateEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<FixedAssetB03HModel> FromDataTransferObjects(IList<FixedAssetB03HEntity> entities)
        {
            if (entities == null)
                return null;
            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<FixedAssetB01Model> FromDataTransferObjects(IList<FixedAssetB01Entity> entities)
        {
            if (entities == null)
                return null;
            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<FixedAssetC55aHDModel> FromDataTransferObjects(IList<FixedAssetC55aHDEntity> entities)
        {
            if (entities == null)
                return null;
            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<FixedAssetFAInventoryModel> FromDataTransferObjects(IList<FixedAssetFAInventoryEntity> entities)
        {
            if (entities == null)
                return null;
            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<FixedAssetFAInventoryCarModel> FromDataTransferObjects(IList<FixedAssetFAInventoryCarEntity> entities)
        {
            if (entities == null)
                return null;
            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<FixedAssetFAInventoryHouseModel> FromDataTransferObjects(IList<FixedAssetFAInventoryHouseEntity> entities)
        {
            if (entities == null)
                return null;
            return entities.Select(FromDataTransferObject).ToList();
        }

        internal static IList<FixedAsset30KPart2Model> FromDataTransferObjects(IList<FixedAsset30KPart2Entity> entities)
        {
            if (entities == null)
                return null;
            return entities.Select(FromDataTransferObject).ToList();
        }

        internal static IList<FixedAssetCardModel> FromDataTransferObjects(IList<FixedAssetCardEntity> entities)
        {
            if (entities == null)
                return null;
            return entities.Select(FromDataTransferObject).ToList();
        }

        internal static IList<FixedAssetB03H30KModel> FromDataTransferObjects(IList<FixedAssetB03H30KEntity> entities)
        {
            if (entities == null)
                return null;
            return entities.Select(FromDataTransferObject).ToList();
        }
        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<FixedAssetB02Model> FromDataTransferObjects(IList<FixedAssetB02Entity> entities)
        {
            if (entities == null)
                return null;
            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<AutoNumberModel> FromDataTransferObjects(IList<AutoNumberEntity> entities)
        {
            if (entities == null)
                return null;
            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<FixedAssetS31HModel> FromDataTransferObjects(IList<FixedAssetS31HEntity> entities)
        {
            if (entities == null)
                return null;
            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<S33HModel> FromDataTransferObjects(IList<S33HEntity> entities)
        {
            if (entities == null)
                return null;
            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<B03BNGModel> FromDataTransferObjects(IList<B03BNGEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        internal static IList<F03BNGModel> FromDataTransferObjects(IList<F03BNGEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        internal static IList<F331BNGModel> FromDataTransferObjects(IList<F331BNGEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        internal static IList<B09BNGModel> FromDataTransferObjects(IList<B09BNGEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        //internal static IList<CashReportModel> FromDataTransferObjects(IList<CashReportEntity> entities)
        //{
        //    if (entities == null)
        //        return null;
        //    return entities.Select(FromDataTransferObject).ToList();
        //}
        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<FixedAssetLedgerModel> FromDataTransferObjects(IList<FixedAssetLedgerEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }
        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<FixedAssetVoucherModel> FromDataTransferObjects(IList<FixedAssetVoucherEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<RoleModel> FromDataTransferObjects(IList<RoleEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<SiteModel> FromDataTransferObjects(IList<SiteEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<PermissionModel> FromDataTransferObjects(IList<PermissionEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<PermissionSiteModel> FromDataTransferObjects(IList<PermissionSiteEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<RoleSiteModel> FromDataTransferObjects(IList<RoleSiteEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<UserProfileModel> FromDataTransferObjects(IList<UserProfileEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<OpeningFixedAssetEntryModel> FromDataTransferObjects(IList<OpeningFixedAssetEntryEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<EmployeeLeasingModel> FromDataTransferObjects(IList<EmployeeLeasingEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<BuildingModel> FromDataTransferObjects(IList<BuildingEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<EmployeeForEstimateModel> FromDataTransferObjects(IList<EmployeeForEstimateEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<FixedAssetForEstimateModel> FromDataTransferObjects(IList<FixedAssetForEstimateEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<InventoryItemReportModel> FromDataTransferObjects(IList<InventoryItemReportEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<FundStuationModel> FromDataTransferObjects(IList<FundStuationEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<EstimateDetailStatementInfoModel> FromDataTransferObjects(IList<EstimateDetailStatementInfoEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<EstimateDetailStatementPartBModel> FromDataTransferObjects(IList<EstimateDetailStatementPartBEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<EstimateDetailStatementFixedAssetModel> FromDataTransferObjects(IList<EstimateDetailStatementFixedAssetEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }
        #endregion

        #region ToDataTransferObject

        internal static LockEntity ToDataTransferObject(LockModel model)
        {
            return new LockEntity
            {
                IsLock = model.IsLock,
                Content = model.Content,
                LockDate = model.LockDate
            };
        }



        internal static SalaryVoucherEntity ToDataTransferObject(SalaryVoucherModel model)
        {
            return new SalaryVoucherEntity
            {
                PostedDate = model.PostedDate,
                RefNo = model.RefNo,
                RefTypeId = model.RefTypeId

            };
        }

        internal static AutoNumberListEntity ToDataTransferObject(AutoNumberListModel model)
        {
            return new AutoNumberListEntity
            {
                TableCode = model.TableCode,
                LengthOfValue = model.LengthOfValue,
                Prefix = model.Prefix,
                Suffix = model.Suffix,
                TableName = model.TableName,
                Value = model.Value
            };
        }

        internal static OpeningSupplyEntryEntity ToDataTransferObject(OpeningSupplyEntryModel model)
        {
            return new OpeningSupplyEntryEntity
            {
                RefId = model.RefId,
                RefType = model.RefType,
                PostedDate = model.PostedDate,
                CurrencyCode = model.CurrencyCode,
                ExchangeRate = model.ExchangeRate,
                AccountNumber = model.AccountNumber,
                InventoryItemId = model.InventoryItemId,
                DepartmentId = model.DepartmentId,
                Quantity = model.Quantity,
                UnitPriceOc = model.UnitPriceOc,
                UnitPriceExchange = model.UnitPriceExchange,
                AmountOc = model.AmountOc,
                AmountExchange = model.AmountExchange,
                SortOrder = model.SortOrder,
                RefDate = model.RefDate
            };
        }

        internal static ElectricalWorkEntity ToDataTransferObject(ElectricalWorkModel model)
        {
            return new ElectricalWorkEntity
            {
                ElectricalWorkId = model.ElectricalWorkId,
                Name = model.Name,
                PostedDate = model.PostedDate
            };
        }


        internal static MutualEntity ToDataTransferObject(MutualModel model)
        {
            return new MutualEntity
            {
                IsActive = model.IsActive,
                Address = model.Address,
                Description = model.Description,
                Area = model.Area,
                UseDate = model.UseDate,
                TotalFloor = model.TotalFloor,
                State = model.State,
                JobCandidate = model.JobCandidate,
                MutualName = model.MutualName,
                MutualCode = model.MutualCode,
                MutualId = model.MutualId
            };
        }


        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static SalaryEntity ToDataTransferObject(SalaryModel model)
        {
            return new SalaryEntity
            {
                EmployeePayrollId = model.EmployeePayrollId,
                RefTypeId = model.RefTypeId,
                RefNo = model.RefNo,
                RefDate = DateTime.Parse(model.RefDate), // + new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second),
                TotalAmountOc = model.TotalAmountOc,
                PostedDate = DateTime.Parse(model.PostedDate),
                CurrencyCode = model.CurrencyCode,
                JournalMemo = model.JournalMemo,
                EmployeeId = model.EmployeeId,
                ExchangeRate = model.ExchangeRate,
                TotalAmountExchange = model.TotalAmountExchange,
                Employees = ToDataTransferObjects(model.Employees)
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static CapitalAllocateEntity ToDataTransferObject(CapitalAllocateModel model)
        {
            return new CapitalAllocateEntity
            {
                CapitalAllocateId = model.CapitalAllocateId,
                BudgetItemCode = model.BudgetItemCode,
                BudgetSourceCode = model.BudgetSourceCode,
                Activityid = model.ActivityId,
                AllocatePercent = model.AllocatePercent,
                AllocateType = model.AllocateType,
                DeterminedDate = model.DeterminedDate == null ? (DateTime?)null : DateTime.Parse(model.DeterminedDate),
                CapitalAccountCode = model.CapitalAccountCode,
                RevenueAccountCode = model.RevenueAccountCode,
                ExpenseAccountCode = model.ExpenseAccountCode,
                Description = model.Description,
                IsActive = model.IsActive,
                WaitBudgetSourceCode = model.WaitBudgetSourceCode,
                CapitalAllocateCode = model.CapitalAllocateCode,
                FromDate = DateTime.Parse(model.FromDate),
                ToDate = DateTime.Parse(model.ToDate),
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static CurrencyEntity ToDataTransferObject(CurrencyModel model)
        {
            return new CurrencyEntity
            {
                CurrencyId = model.CurrencyId,
                CurrencyCode = model.CurrencyCode,
                CurrencyName = model.CurrencyName,
                Prefix = model.Prefix,
                Suffix = model.Suffix,
                IsMain = model.IsMain,
                IsActive = model.IsActive
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static BudgetSourcePropertyEntity ToDataTransferObject(BudgetSourcePropertyModel model)
        {
            return new BudgetSourcePropertyEntity
            {
                BudgetSourcePropertyID = model.BudgetSourcePropertyID,
                BudgetSourcePropertyCode = model.BudgetSourcePropertyCode,
                BudgetSourcePropertyName = model.BudgetSourcePropertyName,
                Description = model.Description,
                IsActive = model.IsActive,
                IsSystem = model.IsSystem
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static AccountEntity ToDataTransferObject(AccountModel model)
        {
            return new AccountEntity
            {
                AccountId = model.AccountId,
                AccountCategoryId = model.AccountCategoryId,
                AccountCode = model.AccountCode,
                AccountName = model.AccountName,
                ForeignName = model.ForeignName,
                ParentId = model.ParentId,
                Grade = model.Grade,
                IsDetail = model.IsDetail,
                Description = model.Description,
                BalanceSide = model.BalanceSide,
                ConcomitantAccount = model.ConcomitantAccount,
                BankId = model.BankId,
                CurrencyCode = model.CurrencyCode,
                IsChapter = model.IsChapter,
                IsBudgetCategory = model.IsBudgetCategory,
                IsBudgetItem = model.IsBudgetItem,
                IsBudgetGroup = model.IsBudgetGroup,
                IsBudgetSource = model.IsBudgetSource,
                IsActivity = model.IsActivity,
                IsCurrency = model.IsCurrency,
                IsCustomer = model.IsCustomer,
                IsVendor = model.IsVendor,
                IsEmployee = model.IsEmployee,
                IsAccountingObject = model.IsAccountingObject,
                IsInventoryItem = model.IsInventoryItem,
                IsFixedAsset = model.IsFixedAsset,
                IsCapitalAllocate = model.IsCapitalAllocate,
                IsActive = model.IsActive,
                IsSystem = model.IsSystem,
                IsAllowinputcts = model.IsAllowinputcts,
                IsProject = model.IsProject,
                IsBudgetSubItem = model.IsBudgetSubItem,
                IsBank = model.IsBank
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static AccountCategoryEntity ToDataTransferObject(AccountCategoryModel model)
        {
            return new AccountCategoryEntity
            {
                AccountCategoryId = model.AccountCategoryId,
                AccountCategoryCode = model.AccountCategoryCode,
                AccountCategoryName = model.AccountCategoryName,
                ForeignName = model.ForeignName,
                ParentId = model.ParentId,
                Grade = model.Grade,
                IsDetail = model.IsDetail,
                IsActive = model.IsActive,
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static CashEntity ToReceiptDataTransferObject(ReceiptVoucherModel model)
        {
            if (model == null) return null;
            return new CashEntity
            {
                RefId = model.RefId,
                RefTypeId = model.RefTypeId,
                RefNo = model.RefNo,
                RefDate = model.RefDate,
                PostedDate = model.PostedDate,
                AccountingObjectId = model.AccountingObjectId,
                CustomerId = model.CustomerId,
                VendorId = model.VendorId,
                EmployeeId = model.EmployeeId,
                Trader = model.Trader,
                CurrencyCode = model.CurrencyCode,
                AccountNumber = model.AccountNumber,
                TotalAmount = model.TotalAmount,
                ExchangeRate = model.ExchangeRate,
                TotalAmountExchange = model.TotalAmountExchange,
                JournalMemo = model.JournalMemo,
                DocumentInclude = model.DocumentInclude,
                AccountingObjectType = model.AccountingObjectType,
                BankAccount = model.BankAccount,
                BankId = model.BankId,
                IsIncludeCharge = model.IsIncludeCharge,
                CashDetails = ToCashDataTransferObjects(model.ReceiptVoucherDetails),
                CashParalellDetails = VoucherMapper.ToDataTransferObjects(model.ReceiptVoucherDetailParalells)
            };
        }

        internal static ReportListEntity ToReceiptDataTransferObject(ReportListModel model)
        {
            if (model == null) return null;
            return new ReportListEntity
            {
                ReportId = model.ReportID,
                PrintVoucherDefault = model.PrintVoucherDefault
            };
        }


        /// <summary>
        /// To the payment detail data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static ItemTransactionDetailEntity ToDataTransferObject(ItemTransactionDetailModel model)
        {
            if (model == null) return null;
            return new ItemTransactionDetailEntity
            {
                RefDetailId = model.RefDetailId,
                AccountNumber = model.AccountNumber,
                CorrespondingAccountNumber = model.CorrespondingAccountNumber,
                Description = model.Description,
                AmountOc = model.AmountOc,
                AmountExchange = model.AmountExchange,
                VoucherTypeId = model.VoucherTypeId,
                BudgetSourceCode = model.BudgetSourceCode,
                BudgetItemCode = model.BudgetItemCode,
                AccountingObjectId = model.AccountingObjectId,
                MergerFundId = model.MergerFundId,
                ProjectId = model.ProjectId,
                RefId = model.RefId,
                InventoryItemId = model.InventoryItemId,
                Quantity = model.Quantity,
                CancelQuantity = model.CancelQuantity,
                FreeQuantity = model.FreeQuantity,
                TotalQuantity = model.TotalQuantity,
                Price = model.Price,
                PriceExchange = model.PriceExchange,
                DepartmentId = model.DepartmentId
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static ItemTransactionEntity ToDataTransferObject(ItemTransactionModel model)
        {
            if (model == null) return null;
            return new ItemTransactionEntity
            {
                RefId = model.RefId,
                RefTypeId = model.RefTypeId,
                RefNo = model.RefNo,
                RefDate = model.RefDate,// + new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second),
                PostedDate = model.PostedDate,// + new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second),
                AccountingObjectId = model.AccountingObjectId,
                CustomerId = model.CustomerId,
                VendorId = model.VendorId,
                EmployeeId = model.EmployeeId,
                Trader = model.Trader,
                CurrencyCode = model.CurrencyCode,
                StockId = model.StockId,
                TotalAmount = model.TotalAmount,
                ExchangeRate = model.ExchangeRate,
                TotalAmountExchange = model.TotalAmountExchange,
                JournalMemo = model.JournalMemo,
                DocumentInclude = model.DocumentInclude,
                AccountingObjectType = model.AccountingObjectType,
                TaxCode = model.TaxCode,
                BankId = model.BankId,
                ItemTransactionDetails = ToDataTransferObjects(model.ItemTransactionDetails)
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static CashEntity ToDataTransferObject(CashModel model)
        {
            if (model == null) return null;
            return new CashEntity
            {
                RefId = model.RefId,
                RefTypeId = model.RefTypeId,
                RefNo = model.RefNo,
                RefDate = DateTime.Parse(model.RefDate),
                PostedDate = DateTime.Parse(model.PostedDate),
                AccountingObjectId = model.AccountingObjectId,
                CustomerId = model.CustomerId,
                VendorId = model.VendorId,
                EmployeeId = model.EmployeeId,
                Trader = model.Trader,
                CurrencyCode = model.CurrencyCode,
                AccountNumber = model.AccountNumber,
                TotalAmount = model.TotalAmount,
                ExchangeRate = model.ExchangeRate,
                TotalAmountExchange = model.TotalAmountExchange,
                JournalMemo = model.JournalMemo,
                DocumentInclude = model.DocumentInclude,
                AccountingObjectType = model.AccountingObjectType,
                BankAccount = model.BankAccount,
                BankId = model.BankId,
                CashDetails = ToCashDataTransferObjects(model.CashDetails),
                CashParalellDetails = VoucherMapper.CashToDataTransferObjects(model.CashParalellDetails.ToList())
                
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static GeneralEntity ToDataTransferObject(GeneralVocherModel model)
        {
            if (model == null) return null;
            return new GeneralEntity
            {
                RefId = model.RefId,
                RefTypeId = model.RefTypeId,
                RefNo = model.RefNo,
                RefDate = model.RefDate,
                PostedDate = model.PostedDate,
                JournalMemo = model.JournalMemo,
                TotalAmountExchange = model.TotalAmountExchange,
                TotalAmountOc = model.TotalAmountOc,
                GeneralDetails = ToGeneralVoucherDetailDataTransferObject(model.GeneralVoucherDetails),
                GeneralParalellDetails = VoucherMapper.GeneralToDataTransferObjects(model.GeneralParalellDetails)
                
            };
        }

        /// <summary>
        /// To the general detail data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static GeneralDetailModel ToGeneralDetailDataTransferObject(GeneralDetailEntity model)
        {
            if (model == null) return null;
            return new GeneralDetailModel
            {
                AccountNumber = model.AccountNumber,
                CorrespondingAccountNumber = model.CorrespondingAccountNumber,
                Description = model.Description,
                AmountOc = model.AmountOc,
                AmountExchange = model.AmountExchange,
                VoucherTypeId = model.VoucherTypeId,
                BudgetSourceCode = model.BudgetSourceCode,
                BudgetItemCode = model.BudgetItemCode,
                AccountingObjectId = model.AccountingObjectId,
                RefId = model.RefId,
                ProjectId = model.ProjectId,
                CurrencyCode = model.CurrencyCode,
                CustomerId = model.CustomerId,
                DepartmentId = model.DepartmentId,
                EmployeeId = model.EmployeeId,
                ExchangeRate = model.ExchangeRate,
                VendorId = model.VendorId,
                BankId = model.BankId,
                RefDetailId = model.RefDetailId,
                AutoBusiness = model.AutoBusiness
            };
        }

        /// <summary>
        /// To the receipt detail data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static ReceiptVoucherDetailModel ToReceiptDetailDataTransferObject(CashDetailEntity model)
        {
            if (model == null) return null;
            return new ReceiptVoucherDetailModel
            {
                RefDetailId = model.RefDetailId,
                AccountNumber = model.AccountNumber,
                CorrespondingAccountNumber = model.CorrespondingAccountNumber,
                Description = model.Description,
                AmountOc = model.AmountOc,
                AmountExchange = model.AmountExchange,
                Charge = model.Charge,
                ChargeExchange = model.ChargeExchange,
                VoucherTypeId = model.VoucherTypeId,
                BudgetSourceCode = model.BudgetSourceCode,
                BudgetItemCode = model.BudgetItemCode,
                AccountingObjectId = model.AccountingObjectId,
                MergerFundId = model.MergerFundId,
                RefId = model.RefId,
                ProjectId = model.ProjectId,
                AutoBusinessId = model.AutoBusinessId
            };
        }

        /// <summary>
        /// To the payment detail data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static CashDetailModel ToDataTransferObject(CashDetailEntity model)
        {
            if (model == null) return null;
            return new CashDetailModel
            {
                RefDetailId = model.RefDetailId,
                AccountNumber = model.AccountNumber,
                CorrespondingAccountNumber = model.CorrespondingAccountNumber,
                Description = model.Description,
                AmountOc = model.AmountOc,
                AmountExchange = model.AmountExchange,
                Charge = model.Charge,
                ChargeExchange =model.ChargeExchange,
                VoucherTypeId = model.VoucherTypeId,
                BudgetSourceCode = model.BudgetSourceCode,
                BudgetItemCode = model.BudgetItemCode,
                AccountingObjectId = model.AccountingObjectId,
                MergerFundId = model.MergerFundId,
                ProjectId = model.ProjectId,
                RefId = model.RefId,
                AutoBusinessId = model.AutoBusinessId
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static GeneralDetailModel ToDataTransferObject(GeneralDetailEntity model)
        {
            if (model == null) return null;
            return new GeneralDetailModel
            {
                RefDetailId = model.RefDetailId,
                AccountNumber = model.AccountNumber,
                CorrespondingAccountNumber = model.CorrespondingAccountNumber,
                Description = model.Description,
                AmountOc = model.AmountOc,
                AmountExchange = model.AmountExchange,
                VoucherTypeId = model.VoucherTypeId,
                BudgetSourceCode = model.BudgetSourceCode,
                BudgetItemCode = model.BudgetItemCode,
                AccountingObjectId = model.AccountingObjectId,
                ProjectId = model.ProjectId,
                CurrencyCode = model.CurrencyCode,
                CustomerId = model.CustomerId,
                EmployeeId = model.EmployeeId,
                VendorId = model.VendorId,
                BankId = model.BankId,
                DepartmentId = model.DepartmentId,
                ExchangeRate = model.ExchangeRate,
                RefId = model.RefId,
                InventoryItemId = model.InventoryItemId,
                AutoBusiness =model.AutoBusiness
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static CashDetailEntity ToReceiptDetailDataTransferObject(ReceiptVoucherDetailModel model)
        {
            if (model == null) return null;
            return new CashDetailEntity
            {
                RefDetailId = model.RefDetailId,
                AccountNumber = model.AccountNumber,
                CorrespondingAccountNumber = model.CorrespondingAccountNumber,
                Description = model.Description,
                AmountOc = model.AmountOc,
                AmountExchange = model.AmountExchange,
                Charge = model.Charge,
                ChargeExchange = model.ChargeExchange,
                VoucherTypeId = model.VoucherTypeId,
                BudgetSourceCode = model.BudgetSourceCode,
                BudgetItemCode = model.BudgetItemCode,
                AccountingObjectId = model.AccountingObjectId,
                MergerFundId = model.MergerFundId,
                RefId = model.RefId,
                ProjectId = model.ProjectId,
                AutoBusinessId = model.AutoBusinessId
            };
        }

        internal static GeneralDetailEntity ToGeneralVoucherDetailDataTransferObject(GeneralDetailModel model)
        {
            if (model == null) return null;
            return new GeneralDetailEntity
            {
                AccountNumber = model.AccountNumber,
                CorrespondingAccountNumber = model.CorrespondingAccountNumber,
                Description = model.Description,
                AmountOc = model.AmountOc,
                AmountExchange = model.AmountExchange,
                VoucherTypeId = model.VoucherTypeId,
                BudgetSourceCode = model.BudgetSourceCode,
                BudgetItemCode = model.BudgetItemCode,
                AccountingObjectId = model.AccountingObjectId,
                RefId = model.RefId,
                CurrencyCode = model.CurrencyCode,
                CustomerId = model.CustomerId,
                EmployeeId = model.EmployeeId,
                ExchangeRate = model.ExchangeRate,
                ProjectId = model.ProjectId,
                DepartmentId = model.DepartmentId,
                VendorId = model.VendorId,
                BankId = model.BankId,
                InventoryItemId = model.InventoryItemId,
                AutoBusiness = model.AutoBusiness
            };

        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static GeneralDetailEntity FromDataTransferObject(GeneralDetailModel model)
        {
            if (model == null) return null;
            return new GeneralDetailEntity
            {
                RefId = model.RefId,
                AccountNumber = model.AccountNumber,
                CorrespondingAccountNumber = model.CorrespondingAccountNumber,
                Description = model.Description,
                AmountOc = model.AmountOc,
                AmountExchange = model.AmountExchange,
                VoucherTypeId = model.VoucherTypeId,
                BudgetSourceCode = model.BudgetSourceCode,
                BudgetItemCode = model.BudgetItemCode,
                AccountingObjectId = model.AccountingObjectId,
                ProjectId = model.ProjectId,
                RefDetailId = model.RefDetailId,
                CurrencyCode = model.CurrencyCode,
                EmployeeId = model.EmployeeId,
                CustomerId = model.CustomerId,
                DepartmentId = model.DepartmentId,
                VendorId = model.VendorId,
                BankId = model.BankId,
                ExchangeRate = model.ExchangeRate,
                AutoBusiness = model.AutoBusiness
            };
        }

        /// <summary>
        /// Froms the payment detail data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static CashDetailEntity FromDataTransferObject(CashDetailModel model)
        {
            if (model == null) return null;
            return new CashDetailEntity
            {
                RefDetailId = model.RefDetailId,
                AccountNumber = model.AccountNumber,
                CorrespondingAccountNumber = model.CorrespondingAccountNumber,
                Description = model.Description,
                AmountOc = model.AmountOc,
                AmountExchange = model.AmountExchange,
                Charge = model.Charge,
                ChargeExchange = model.ChargeExchange,
                VoucherTypeId = model.VoucherTypeId,
                BudgetSourceCode = model.BudgetSourceCode,
                BudgetItemCode = model.BudgetItemCode,
                AccountingObjectId = model.AccountingObjectId,
                MergerFundId = model.MergerFundId,
                ProjectId = model.ProjectId,
                RefId = model.RefId,
                AutoBusinessId = model.AutoBusinessId
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static DepartmentEntity ToDataTransferObject(DepartmentModel model)
        {
            return new DepartmentEntity
            {
                DepartmentId = model.DepartmentId,
                DepartmentCode = model.DepartmentCode,
                DepartmentName = model.DepartmentName,
                Description = model.Description,
                IsActive = model.IsActive,
                ParentId = model.ParentId
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static BudgetSourceCategoryEntity ToDataTransferObject(BudgetSourceCategoryModel model)
        {
            return new BudgetSourceCategoryEntity
            {
                BudgetSourceCategoryId = model.BudgetSourceCategoryId,
                BudgetSourceCategoryCode = model.BudgetSourceCategoryCode,
                BudgetSourceCategoryName = model.BudgetSourceCategoryName,
                Description = model.Description,
                IsActive = model.IsActive,
                ForeignName = model.ForeignName,
                IsSummaryEstimateReport = model.IsSummaryEstimateReport
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The entity.</param>
        /// <returns></returns>
        internal static BudgetItemEntity ToDataTransferObject(BudgetItemModel model)
        {
            return new BudgetItemEntity
            {
                BudgetItemId = model.BudgetItemId,
                BudgetGroupId = model.BudgetGroupId,
                BudgetItemCode = model.BudgetItemCode,
                BudgetItemName = model.BudgetItemName,
                ForeignName = model.ForeignName,
                ParentId = model.ParentId,
                IsParent = model.IsParent,
                IsActive = model.IsActive,
                IsExpandItem = model.IsExpandItem,
                IsFixedItem = model.IsFixedItem,
                IsNoAllocate = model.IsNoAllocate,
                IsOrganItem = model.IsOrganItem,
                BudgetItemType = model.BudgetItemType,
                IsReceipt = model.IsReceipt,
                Rate = model.Rate
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The entity.</param>
        /// <returns></returns>
        internal static PlanTemplateListEntity ToDataTransferObject(PlanTemplateListModel model)
        {
            return new PlanTemplateListEntity
            {
                PlanTemplateListId = model.PlanTemplateListId,
                PlanTemplateListCode = model.PlanTemplateListCode,
                PlanType = model.PlanType,
                PlanYear = model.PlanYear,
                PlanTemplateListName = model.PlanTemplateListName,
                ParentId = model.ParentId,
                PlanTemplateItems = ToDataTransferObjects(model.PlanTemplateItems)
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static AutoNumberEntity ToDataTransferObject(AutoNumberModel model)
        {
            return new AutoNumberEntity
            {
                RefTypeId = model.RefTypeId,
                Prefix = model.Prefix,
                Suffix = model.Suffix,
                Value = model.Value,
                ValueLocalCurency = model.ValueLocalCurency,
                LengthOfValue = model.LengthOfValue
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static PlanTemplateItemEntity ToDataTransferObject(PlanTemplateItemModel model)
        {
            return new PlanTemplateItemEntity
            {
                PlanTemplateItemId = model.PlanTemplateItemId,
                PlanTemplateListId = model.PlanTemplateListId,
                BudgetItemCode = model.BudgetItemCode,
                BudgetItemName = model.BudgetItemName,
                IsInserted = model.IsInserted //LINHMC ADD
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static FixedAssetCategoryEntity ToDataTransferObject(FixedAssetCategoryModel model)
        {
            return new FixedAssetCategoryEntity
            {
                FixedAssetCategoryId = model.FixedAssetCategoryId,
                ParentId = model.ParentId,
                FixedAssetCategoryCode = model.FixedAssetCategoryCode,
                FixedAssetCategoryName = model.FixedAssetCategoryName,
                FixedAssetCategoryForeignName = model.FixedAssetCategoryForeignName,
                DepreciationRate = model.DepreciationRate,
                LifeTime = model.LifeTime,
                Grade = model.Grade,
                IsParent = model.IsParent,
                OrgPriceAccountCode = model.OrgPriceAccountCode,
                DepreciationAccountCode = model.DepreciationAccountCode,
                CapitalAccountCode = model.CapitalAccountCode,
                BudgetChapterCode = model.BudgetChapterCode,
                BudgetCategoryCode = model.BudgetCategoryCode,
                BudgetGroupCode = model.BudgetGroupCode,
                BudgetItemCode = model.BudgetItemCode,
                IsActive = model.IsActive
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static FixedAssetEntity ToDataTransferObject(FixedAssetModel model)
        {
            return new FixedAssetEntity
            {
                FixedAssetId = model.FixedAssetId,
                FixedAssetCode = model.FixedAssetCode,
                FixedAssetName = model.FixedAssetName,
                FixedAssetForeignName = model.FixedAssetForeignName,
                FixedAssetCategoryId = model.FixedAssetCategoryId,
                State = model.State,
                Description = model.Description,
                ProductionYear = model.ProductionYear,
                MadeIn = model.MadeIn,
                PurchasedDate = model.PurchasedDate,
                UsedDate = model.UsedDate,
                DepreciationDate = model.DepreciationDate,
                IncrementDate = model.IncrementDate,
                DisposedDate = model.DisposedDate,
                Unit = model.Unit,
                SerialNumber = model.SerialNumber,
                Accessories = model.Accessories,
                Quantity = model.Quantity,
                UnitPrice = model.UnitPrice,
                OrgPrice = model.OrgPrice,
                AccumDepreciationAmount = model.AccumDepreciationAmount,
                RemainingAmount = model.RemainingAmount,
                CurrencyCode = model.CurrencyCode,
                ExchangeRate = model.ExchangeRate,
                UnitPriceUSD = model.UnitPriceUSD,
                OrgPriceUSD = model.OrgPriceUSD,
                AccumDepreciationAmountUSD = model.AccumDepreciationAmountUSD,
                RemainingAmountUSD = model.RemainingAmountUSD,
                AnnualDepreciationAmountUSD = model.AnnualDepreciationAmountUSD,
                AnnualDepreciationAmount = model.AnnualDepreciationAmount,
                LifeTime = model.LifeTime,
                DepreciationRate = model.DepreciationRate,
                OrgPriceAccountCode = model.OrgPriceAccountCode,
                DepreciationAccountCode = model.DepreciationAccountCode,
                CapitalAccountCode = model.CapitalAccountCode,
                DepartmentId = model.DepartmentId,
                EmployeeId = model.EmployeeId,
                IsActive = model.IsActive,
                NumberOfFloor = model.NumberOfFloor,
                AreaOfBuilding = model.AreaOfBuilding,
                AreaOfFloor = model.AreaOfFloor,
                AdministrationArea = model.AdministrationArea,
                WorkingArea = model.WorkingArea,
                NumberOfSeat = model.NumberOfSeat,
                ControlPlate = model.ControlPlate,
                GuestHouseArea = model.GuestHouseArea,
                HousingArea = model.HousingArea,
                IsBussiness = model.IsBussiness,
                IsStateManagement = model.IsStateManagement,
                LeasingArea = model.LeasingArea,
                OccupiedArea = model.OccupiedArea,
                OtherArea = model.OtherArea,
                VacancyArea = model.VacancyArea,
                Address = model.Address,
                BudgetSourceCode = model.BudgetSourceCode,
                ManagementCar = model.ManagementCar,
                Brand = model.Brand,
                IsEstimateEmployee = model.IsEstimateEmployee,
                ArmortizationAccount = model.ArmortizationAccount,
                BudgetItemCode = model.BudgetItemCode,
                FixedAssetCurrencies = ToDataTransferObjects(model.FixedAssetCurrencies)
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static PayItemEntity ToDataTransferObject(PayItemModel model)
        {
            return new PayItemEntity
            {
                PayItemId = model.PayItemId,
                PayItemCode = model.PayItemCode,
                PayItemName = model.PayItemName,
                Type = model.Type,
                IsCalculateRatio = model.IsCalculateRatio,
                IsSocialInsurance = model.IsSocialInsurance,
                IsCareInsurance = model.IsCareInsurance,
                IsTradeUnionFee = model.IsTradeUnionFee,
                Description = model.Description,
                DebitAccountCode = model.DebitAccountCode,
                CreditAccountCode = model.CreditAccountCode,
                BudgetChapterCode = model.BudgetChapterCode,
                IsDefault = model.IsDefault,
                IsActive = model.IsActive,
                BudgetSourceCode = model.BudgetSourceCode,
                BudgetCategoryCode = model.BudgetCategoryCode,
                BudgetGroupCode = model.BudgetGroupCode,
                BudgetItemCode = model.BudgetItemCode
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static CustomerEntity ToDataTransferObject(CustomerModel model)
        {
            if (model == null) return null;
            return new CustomerEntity
            {
                CustomerId = model.CustomerId,
                CustomerCode = model.CustomerCode,
                CustomerName = model.CustomerName,
                Address = model.Address,
                ContactName = model.ContactName,
                ContactRegency = model.ContactRegency,
                Phone = model.Phone,
                Mobile = model.Mobile,
                Fax = model.Fax,
                Email = model.Email,
                TaxCode = model.TaxCode,
                Website = model.Website,
                Province = model.Province,
                City = model.City,
                ZipCode = model.ZipCode,
                Area = model.Area,
                Country = model.Country,
                BankNumber = model.BankNumber,
                BankId = model.BankId,
                BankName = model.BankName,
                IsActive = model.IsActive
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static VendorEntity ToDataTransferObject(VendorModel model)
        {
            if (model == null) return null;
            return new VendorEntity
            {
                VendorId = model.VendorId,
                VendorCode = model.VendorCode,
                VendorName = model.VendorName,
                Address = model.Address,
                ContactName = model.ContactName,
                ContactRegency = model.ContactRegency,
                Phone = model.Phone,
                Mobile = model.Mobile,
                Fax = model.Fax,
                Email = model.Email,
                TaxCode = model.TaxCode,
                Website = model.Website,
                Province = model.Province,
                City = model.City,
                ZipCode = model.ZipCode,
                Area = model.Area,
                Country = model.Country,
                BankNumber = model.BankNumber,
                BankName = model.BankName,
                BankId = model.BankId,
                IsActive = model.IsActive,
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static VoucherListEntity ToDataTransferObject(VoucherListModel model)
        {
            return new VoucherListEntity
            {
                VoucherListId = model.VoucherListId,
                VoucherListCode = model.VoucherListCode,
                VoucherDate = model.VoucherDate,
                PostDate = model.PostDate,
                Description = model.Description,
                DocAttach = model.DocAttach,
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static BudgetChapterEntity ToDataTransferObject(BudgetChapterModel model)
        {
            return new BudgetChapterEntity
            {
                BudgetChapterId = model.BudgetChapterId,
                BudgetChapterCode = model.BudgetChapterCode,
                BudgetChapterName = model.BudgetChapterName,
                Description = model.Description,
                IsActive = model.IsActive,
                IsSystem = model.IsSystem,
                ForeignName = model.ForeignName
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static BudgetCategoryEntity ToDataTransferObject(BudgetCategoryModel model)
        {
            return new BudgetCategoryEntity
            {
                BudgetCategoryId = model.BudgetCategoryId,
                BudgetCategoryCode = model.BudgetCategoryCode,
                BudgetCategoryName = model.BudgetCategoryName,
                ParentId = model.ParentId,
                Description = model.Description,
                IsParent = model.IsParent,
                IsActive = model.IsActive,
                IsSystem = model.IsSystem,
                Grade = model.Grade,
                ForeignName = model.ForeignName

            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static MergerFundEntity ToDataTransferObject(MergerFundModel model)
        {
            return new MergerFundEntity
            {
                MergerFundId = model.MergerFundId,
                MergerFundCode = model.MergerFundCode,
                MergerFundName = model.MergerFundName,
                ParentId = model.ParentId,
                Description = model.Description,
                IsActive = model.IsActive,
                IsSystem = model.IsSystem,
                Grade = model.Grade,
                ForeignName = model.ForeignName
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static BudgetSourceEntity ToDataTransferObject(BudgetSourceModel model)
        {
            return new BudgetSourceEntity
            {
                BudgetSourceId = model.BudgetSourceId,
                BudgetSourceCode = model.BudgetSourceCode,
                BudgetSourceName = model.BudgetSourceName,
                ForeignName = model.ForeignName,
                ParentId = model.ParentId,
                Description = model.Description,
                Grade = model.Grade,
                IsParent = model.IsParent,
                Type = model.Type,
                IsSystem = model.IsSystem,
                IsActive = model.IsActive,
                Allocation = model.Allocation,
                BudgetItemCode = model.BudgetItemCode,
                IsFund = model.IsFund,
                IsExpense = model.IsExpense,
                AccountCode = model.AccountCode,
                AutonomyBudgetType = model.AutonomyBudgetType
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static EmployeeEntity ToDataTransferObject(EmployeeModel model)
        {
            return new EmployeeEntity
            {
                EmployeeId = model.EmployeeId,
                EmployeeCode = model.EmployeeCode,
                EmployeeName = model.EmployeeName,
                JobCandidateName = model.JobCandidateName,
                SortOrder = model.SortOrder,
                BirthDate = model.BirthDate == null ? (DateTime?)null : DateTime.Parse(model.BirthDate),
                TypeOfSalary = model.TypeOfSalary,
                Sex = model.Sex,
                LevelOfSalary = model.LevelOfSalary,
                DepartmentId = model.DepartmentId,
                CurrencyCode = model.CurrencyCode,
                IdentityNo = model.IdentityNo,
                IssueDate = model.IssueDate == null ? (DateTime?)null : DateTime.Parse(model.IssueDate),
                IssueBy = model.IssueBy,
                IsActive = model.IsActive,
                Description = model.Description,
                PhoneNumber = model.PhoneNumber,
                Address = model.Address,
                IsOffice = model.IsOffice,
                RetiredDate = model.RetiredDate == null ? (DateTime?)null : DateTime.Parse(model.RetiredDate),
                StartingDate = model.StartingDate == null ? (DateTime?)null : DateTime.Parse(model.StartingDate),
                EmployeePayItems = ToDataTransferObjects(model.EmployeePayItems)
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static StockEntity ToDataTransferObject(StockModel model)
        {
            return new StockEntity
            {
                StockId = model.StockId,
                StockCode = model.StockCode,
                StockName = model.StockName,
                Description = model.Description,
                IsActive = model.IsActive
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static CaptitalAllocateVoucherEntity ToDataTransferObject(CaptitalAllocateVoucherModel model)
        {
            return new CaptitalAllocateVoucherEntity
            {
                ActivityId = model.ActivityId,
                AllocatePercent = model.AllocatePercent,
                AllocateType = model.AllocateType,
                Amount = model.Amount,
                TotalAmount = model.TotalAmount,
                RefId = model.RefId,
                BudgetItemCode = model.BudgetItemCode,
                BudgetSourceCode = model.BudgetSourceCode,
                CapitalAccountCode = model.CapitalAccountCode,
                CapitalAllocateCode = model.CapitalAllocateCode,
                RefDetailId = model.RefDetailId,
                Description = model.Description,
                DeterminedDate = model.DeterminedDate,
                ExpenseAccountCode = model.ExpenseAccountCode,
                ExpenseAmount = model.ExpenseAmount,
                IsActive = model.IsActive,
                RevenueAccountCode = model.RevenueAccountCode,
                WaitBudgetSourceCode = model.WaitBudgetSourceCode,
                CurrencyCode = model.CurrencyCode,
                FromDate = model.FromDate,
                ToDate = model.ToDate
            };
        }


        internal static AccountTranferVourcherEntity ToDataTransferObject(AccountTranferVourcherModel model)
        {
            return new AccountTranferVourcherEntity
            {


                BudgetSourceCode = model.BudgetSourceCode,
                RefDetailId = model.RefDetailId,
                Description = model.Description,
                CurrencyCode = model.CurrencyCode,
                AccountNumber = model.AccountNumber,
                CorrespondingAccountNumber = model.CorrespondingAccountNumber,
                AmountExchange = model.AmountExchange,
                AmountOc = model.AmountOc,
                ExchangeRate = model.ExchangeRate,
                RefId = model.RefId,
                PostedDate = model.PostedDate,
                VoucherTypeId = model.VoucherTypeId
            };
        }




        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static InventoryItemEntity ToDataTransferObject(InventoryItemModel model)
        {
            return new InventoryItemEntity
            {
                InventoryItemId = model.InventoryItemId,
                InventoryItemName = model.InventoryItemName,
                InventoryItemCode = model.InventoryItemCode,
                AccountCode = model.AccountCode,
                IsActive = model.IsActive,
                Unit = model.Unit,
                CurrencyCode = model.CurrencyCode,
                CostMethod = model.CostMethod,
                StockId = model.StockId,
                StockCode = model.StockCode,
                ExpenseAccountCode = model.ExpenseAccountCode,
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static EmployeePayItemEntity ToDataTransferObject(EmployeePayItemModel model)
        {
            return new EmployeePayItemEntity
            {
                EmployeeId = model.EmployeeId,
                EmployeePayItemId = model.EmployeePayItemId,
                PayItemId = model.PayItemId,
                Amount = model.Amount,
                SalaryRatio = model.SalaryRatio
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static BankEntity ToDataTransferObject(BankModel model)
        {
            return new BankEntity
            {
                BankId = model.BankId,
                BankAccount = model.BankAccount,
                BankAddress = model.BankAddress,
                BankName = model.BankName,
                Description = model.Description,
                IsActive = model.IsActive,
            };
        }

        internal static ExchangeRateEntity ToDataTransferObject(ExchangeRateModel model)
        {
            return new ExchangeRateEntity
            {
                ExchangeRateId = model.ExchangeRateId,
                Description = model.Description,
                FromDate = model.FromDate,
                ToDate = model.ToDate,
                ExchangeRate = model.ExchangeRate,
                Inactive = model.Inactive,
                BudgetSourceCode = model.BudgetSourceCode
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static AccountTranferEntity ToDataTransferObject(AccountTranferModel model)
        {
            return new AccountTranferEntity
            {
                AccountTranferId = model.AccountTranferId,
                AccountTranferCode = model.AccountTranferCode,
                SortOrder = model.SortOrder,
                AccountDestinationCode = model.AccountDestinationCode,
                AccountSourceCode = model.AccountSourceCode,
                SideOfTranfer = model.SideOfTranfer,
                Type = model.Type,
                IsActive = model.IsActive,
                Description = model.Description
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static AudittingLogEntity ToDataTransferObject(AudittingLogModel model)
        {
            return new AudittingLogEntity
            {
                EventId = model.EventId,
                LoginName = model.LoginName,
                ComputerName = model.ComputerName,
                EventTime = model.EventTime,
                ComponentName = model.ComponentName,
                EventAction = model.EventAction,
                Reference = model.Reference,
                Amount = model.Amount
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static EstimateEntity ToDataTransferObject(EstimateModel model)
        {
            return new EstimateEntity
            {
                RefId = model.RefId,
                RefTypeId = model.RefTypeId,
                RefNo = model.RefNo,
                RefDate = DateTime.Parse(model.RefDate), // + new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second),
                PostedDate = DateTime.Parse(model.PostedDate), // + new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second),
                PlanTemplateListId = model.PlanTemplateListId,
                YearOfPlaning = model.YearOfPlaning,
                CurrencyCode = model.CurrencyCode,
                ExchangeRate = model.ExchangeRate,
                TotalEstimateAmount = model.TotalEstimateAmount,
                NextYearOfTotalEstimateAmount = model.NextYearOfTotalEstimateAmount,
                JournalMemo = model.JournalMemo,
                BudgetSourceCategoryId = model.BudgetSourceCategoryId,
                ExchangeRateLastYear = model.ExchangeRateLastYear,
                ExchangeRateThisYear = model.ExchangeRateThisYear,
                EstimateDetails = ToDataTransferObjects(model.EstimateDetails)
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static EstimateDetailEntity ToDataTransferObject(EstimateDetailModel model)
        {
            return new EstimateDetailEntity
            {
                RefId = model.RefId,
                RefDetailId = model.RefDetailId,
                BudgetItemCode = model.BudgetItemCode,
                BudgetItemName = model.BudgetItemName,
                AutonomyBudget = model.AutonomyBudget,
                Description = model.Description,
                NextYearOfEstimateAmount = model.NextYearOfEstimateAmount,
                NonAutonomyBudget = model.NonAutonomyBudget,
                PreviousYearOfEstimateAmount = model.PreviousYearOfEstimateAmount,
                PreviousYearOfEstimateAmountUSD = model.PreviousYearOfEstimateAmountUSD,
                TotalEstimateAmountUSD = model.TotalEstimateAmountUSD,
                YearOfEstimateAmount = model.YearOfEstimateAmount,
                TotalNextYearOfEstimateAmount = model.TotalNextYearOfEstimateAmount,
                PreviousYearOfAutonomyBudget = model.PreviousYearOfAutonomyBudget,
                PreviousYearOfNonAutonomyBudget = model.PreviousYearOfNonAutonomyBudget,
                YearOfAutonomyBudget = model.YearOfAutonomyBudget,
                YearOfNonAutonomyBudget = model.YearOfNonAutonomyBudget,
                SixMonthBeginingAutonomyBudget = model.SixMonthBeginingAutonomyBudget,
                SixMonthBeginingNonAutonomyBudget = model.SixMonthBeginingNonAutonomyBudget,
                TotalAmountSixMonthBegining = model.TotalAmountSixMonthBegining,
                SixMonthEndingAutonomyBudget = model.SixMonthEndingAutonomyBudget,
                SixMonthEndingNonAutonomyBudget = model.SixMonthEndingNonAutonomyBudget,
                TotalAmountSixMonthEnding = model.TotalAmountSixMonthEnding,
                PreviousYeaOfAutonomyBudgetBalance = model.PreviousYeaOfAutonomyBudgetBalance,
                PreviousYeaOfNonAutonomyBudgetBalance = model.PreviousYeaOfNonAutonomyBudgetBalance,
                TotalPreviousYearBalance = model.TotalPreviousYearBalance,
                ThisYearOfAutonomyBudget = model.ThisYearOfAutonomyBudget,
                ThisYearOfNonAutonomyBudget = model.ThisYearOfNonAutonomyBudget,
                TotalAmountThisYear = model.TotalAmountThisYear,
                IsInserted = model.IsInserted,
                ItemCodeList = model.ItemCodeList
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>
        /// DepositEntity.
        /// </returns>
        internal static DepositEntity ToDataTransferObject(DepositModel model)
        {
            return new DepositEntity
            {
                RefId = model.RefId,
                RefTypeId = model.RefTypeId,
                RefDate = model.RefDate,
                PostedDate = model.PostedDate,
                RefNo = model.RefNo,
                AccountingObjectType = model.AccountingObjectType,
                AccountingObjectId = model.AccountingObjectId,
                Trader = model.Trader,
                CustomerId = model.CustomerId,
                VendorId = model.VendorId,
                EmployeeId = model.EmployeeId,
                BankAccountCode = model.BankAccountCode,
                CurrencyCode = model.CurrencyCode,
                ExchangeRate = model.ExchangeRate,
                TotalAmountOc = model.TotalAmountOc,
                TotalAmountExchange = model.TotalAmountExchange,
                JournalMemo = model.JournalMemo,
                BankId = model.BankId,
                DepositDetails = ToDataTransferObjects(model.DepositDetails)
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>
        /// DepositDetailEntity.
        /// </returns>
        internal static DepositDetailEntity ToDataTransferObject(DepositDetailModel model)
        {
            return new DepositDetailEntity
            {
                RefDetailId = model.RefDetailId,
                RefId = model.RefId,
                Description = model.Description,
                AccountNumber = model.AccountNumber,
                CorrespondingAccountNumber = model.CorrespondingAccountNumber,
                AmountOc = model.AmountOc,
                AmountExchange = model.AmountExchange,
                VoucherTypeId = model.VoucherTypeId,
                BudgetSourceCode = model.BudgetSourceCode,
                AccountingObjectId = model.AccountingObjectId,
                BudgetItemCode = model.BudgetItemCode,
                DepartmentId = model.DepartmentId,
                MergerFundId = model.MergerFundId,
                ProjectId = model.ProjectId,
                AutoBusinessId = model.AutoBusinessId
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static AutoBusinessEntity ToDataTransferObject(AutoBusinessModel model)
        {
            return new AutoBusinessEntity
            {
                AutoBusinessId = model.AutoBusinessId,
                AutoBusinessCode = model.AutoBusinessCode,
                AutoBusinessName = model.AutoBusinessName,
                RefTypeId = model.RefTypeId,
                VoucherTypeId = model.VoucherTypeId,
                DebitAccountNumber = model.DebitAccountNumber,
                CreditAccountNumber = model.CreditAccountNumber,
                BudgetItemCode = model.BudgetItemCode,
                BudgetSourceCode = model.BudgetSourceCode,
                Description = model.Description,
                CurrencyCode = model.CurrencyCode,
                IsActive = model.IsActive
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static DBOptionEntity ToDataTransferObject(DBOptionModel model)
        {
            return new DBOptionEntity
            {
                OptionId = model.OptionId,
                OptionValue = model.OptionValue,
                ValueType = model.ValueType,
                IsSystem = model.IsSystem,
                Description = model.Description
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The entity.</param>
        /// <returns></returns>
        internal static ProjectEntity ToDataTransferObject(ProjectModel model)
        {
            return new ProjectEntity
            {
                ProjectId = model.ProjectId,
                ProjectCode = model.ProjectCode,
                ProjectName = model.ProjectName,
                ForeignName = model.ForeignName,
                ParentId = model.ParentId,
                IsParent = model.IsParent,
                IsActive = model.IsActive,
                Description = model.Description
            };
        }

        internal static CompanyProfileEntity ToDataTransferObject(CompanyProfileModel model)
        {
            return new CompanyProfileEntity
            {
                LineId = model.LineId,
                AssetOwnArea = model.AssetOwnArea,
                AssetOwnRoom = model.AssetOwnRoom,
                AssetBuyDate = model.AssetBuyDate,
                AssetOwnDescription = model.AssetOwnDescription,
                AssetMutualArea = model.AssetMutualArea,
                AssetMutualRoom = model.AssetMutualRoom,
                AssetMutualMethod = model.AssetMutualMethod,
                AssetMutualDescription = model.AssetMutualDescription,
                AssetRentContractLen = model.AssetRentContractLen,
                AssetRentPrice = model.AssetRentPrice,
                AssetRentRoom = model.AssetRentRoom,
                AssetRentArea = model.AssetRentArea,
                AssetRentDescription = model.AssetRentDescription,
                AssetNumberOfCars = model.AssetNumberOfCars,
                AssetCarDetail = model.AssetCarDetail,
                EmployeePayrollsTotal = model.EmployeePayrollsTotal,
                EmployeeNumberOfWifeOrHusband = model.EmployeeNumberOfWifeOrHusband,
                EmployeeNumberOfOfficers = model.EmployeeNumberOfOfficers,
                EmployeeNumberOfStaff = model.EmployeeNumberOfStaff,
                EmployeeOtherCompany = model.EmployeeOtherCompany,
                EmployeeNumberOfSecondingOfficers = model.EmployeeNumberOfSecondingOfficers,
                EmployeeDetail = model.EmployeeDetail,
                EmployeeNumberOfRentLocal = model.EmployeeNumberOfRentLocal,
                ProfileAddress = model.ProfileAddress,
                ProfileFoundDate = model.ProfileFoundDate,
                ProfileHeadPhone = model.ProfileHeadPhone,
                ProfileAmbassadorName = model.ProfileAmbassadorName,
                ProfileAmbassadorPhone = model.ProfileAmbassadorPhone,
                ProfileAmbassadorStartDate = model.ProfileAmbassadorStartDate,
                ProfileAmbassadorFinishDate = model.ProfileAmbassadorFinishDate,
                ProfileAccountingManagerName = model.ProfileAccountingManagerName,
                ProfileAccountingManagerPhone = model.ProfileAccountingManagerPhone,
                ProfileAccountingManagerStartDate = model.ProfileAccountingManagerStartDate,
                ProfileAccountingManagerFinishDate = model.ProfileAccountingManagerFinishDate,
                ProfileAccountantName = model.ProfileAccountantName,
                ProfileAccountantPhone = model.ProfileAccountantPhone,
                ProfileAccountantStartDate = model.ProfileAccountantStartDate,
                ProfileAccountantFinishDate = model.ProfileAccountantFinishDate,
                ProfileMinimumSalary = model.ProfileMinimumSalary,
                ProfileSalaryGroup = model.ProfileSalaryGroup,
                ProfileWorkingArea = model.ProfileWorkingArea,
                ProfileCurrencyCodeFinalization = model.ProfileCurrencyCodeFinalization,
                ProfileServices = model.ProfileServices,
                ProfileReportHeader = model.ProfileReportHeader,
                ProfileBankName = model.ProfileBankName,
                ProfileBankAddress = model.ProfileBankAddress,
                ProfileBankAccount = model.ProfileBankAccount,
                ProfileBankCIF = model.ProfileBankCIF,
                OtherNote = model.OtherNote,
                NativeCategory = model.NativeCategory,
                ManagementArea = model.ManagementArea
            };
        }
        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static FAArmortizationEntity ToDataTransferObject(FixedAssetArmortizationModel model)
        {
            return new FAArmortizationEntity
            {
                RefId = model.RefId,
                RefNo = model.RefNo,
                RefDate = DateTime.Parse(model.RefDate), // + new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second),
                PostedDate = DateTime.Parse(model.PostedDate), // + new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second),
                RefTypeId = model.RefTypeId,
                TotalAmountOC = model.TotalAmountOC,
                TotalAmountExchange = model.TotalAmountExchange,
                JournalMemo = model.JournalMemo,
                CurrencyCode = model.CurrencyCode,
                FAArmortizationDetails = ToDataTransferObjects(model.FixedAssetArmortizationDetails)
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static FAArmortizationDetailEntity ToDataTransferObject(FixedAssetArmortizationDetailModel model)
        {
            return new FAArmortizationDetailEntity
            {
                RefDetailId = model.RefDetailId,
                RefId = model.RefId,
                FixedAssetId = model.FixedAssetId,
                AccountNumber = model.AccountNumber,
                CorrespondingAccountNumber = model.CorrespondingAccountNumber,
                Quantity = model.Quantity,
                CurrencyCode = model.CurrencyCode,
                ExchangeRate = model.ExchangeRate,
                AmountOC = model.AmountOC,
                AmountExchange = model.AmountExchange,
                VoucherTypeId = model.VoucherTypeId,
                BudgetSourceCode = model.BudgetSourceCode,
                BudgetItemCode = model.BudgetItemCode,
                BudgetCategoryCode = model.BudgetCategoryCode,
                BudgetChapterCode = model.BudgetChapterCode,
                Description = model.Description,
                DepartmentId = model.DepartmentId,
                ProjectId = model.ProjectId,
                AutoBusinessId = model.AutoBusinessId
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static FADecrementEntity ToDataTransferObject(FixedAssetDecrementModel model)
        {
            return new FADecrementEntity
            {
                RefId = model.RefId,
                RefNo = model.RefNo,
                RefDate = DateTime.Parse(model.RefDate), // + new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second),
                PostedDate = DateTime.Parse(model.PostedDate), // + new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second),
                RefTypeId = model.RefTypeId,
                AccountingObjectId = model.AccountingObjectId,
                AccountingObjectType = model.AccountingObjectType,
                CustomerId = model.CustomerId,
                EmployeeId = model.EmployeeId,
                VendorId = model.VendorId,
                TotalAmountExchange = model.TotalAmountExchange,
                CurrencyCode = model.CurrencyCode,
                ExchangeRate = model.ExchangeRate,
                TotalAmountOC = model.TotalAmountOC,
                JournalMemo = model.JournalMemo,
                DocumentInclude = model.DocumentInclude,
                Trader = model.Trader,
                BankId = model.BankId,
                FADecrementDetails = ToDataTransferObjects(model.FixedAssetDecrementDetails)
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static FADecrementDetailEntity ToDataTransferObject(FixedAssetDecrementDetailModel model)
        {
            return new FADecrementDetailEntity
            {
                RefDetailId = model.RefDetailId,
                RefId = model.RefId,
                FixedAssetId = model.FixedAssetId,
                AccountNumber = model.AccountNumber,
                CorrespondingAccountNumber = model.CorrespondingAccountNumber,
                Quantity = model.Quantity,
                AmountOC = model.AmountOC,
                AmountExchange = model.AmountExchange,
                VoucherTypeId = model.VoucherTypeId,
                BudgetSourceCode = model.BudgetSourceCode,
                BudgetItemCode = model.BudgetItemCode,
                BudgetCategoryCode = model.BudgetCategoryCode,
                BudgetChapterCode = model.BudgetChapterCode,
                Description = model.Description,
                DepartmentId = model.DepartmentId,
                ProjectId = model.ProjectId,
                AccountingObjectId = model.AccountingObjectId,
                AutoBusinessId = model.AutoBusinessId,
                UnitPriceExchange = model.UnitPriceExchange,
                UnitPriceOC = model.UnitPriceOC
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static FAIncrementEntity ToDataTransferObject(FixedAssetIncrementModel model)
        {
            return new FAIncrementEntity
            {
                RefId = model.RefId,
                RefNo = model.RefNo,
                RefDate = DateTime.Parse(model.RefDate), // + new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second),
                PostedDate = DateTime.Parse(model.PostedDate), // + new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second),
                RefTypeId = model.RefTypeId,
                AccountingObjectId = model.AccountingObjectId,
                AccountingObjectType = model.AccountingObjectType,
                CustomerId = model.CustomerId,
                EmployeeId = model.EmployeeId,
                VendorId = model.VendorId,
                Trader = model.Trader,
                TotalAmountExchange = model.TotalAmountExchange,
                CurrencyCode = model.CurrencyCode,
                ExchangeRate = model.ExchangeRate,
                TotalAmountOC = model.TotalAmountOC,
                JournalMemo = model.JournalMemo,
                DocumentInclude = model.DocumentInclude,
                BankId = model.BankId,
                FAIncrementDetails = ToDataTransferObjects(model.FixedAssetIncrementDetails)
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static FAIncrementDetailEntity ToDataTransferObject(FixedAssetIncrementDetailModel model)
        {
            return new FAIncrementDetailEntity
            {
                RefDetailId = model.RefDetailId,
                RefId = model.RefId,
                FixedAssetId = model.FixedAssetId,
                AccountNumber = model.AccountNumber,
                CorrespondingAccountNumber = model.CorrespondingAccountNumber,
                Quantity = model.Quantity,
                AmountOC = model.AmountOC,
                AmountExchange = model.AmountExchange,
                VoucherTypeId = model.VoucherTypeId,
                BudgetSourceCode = model.BudgetSourceCode,
                BudgetItemCode = model.BudgetItemCode,
                BudgetCategoryCode = model.BudgetCategoryCode,
                BudgetChapterCode = model.BudgetChapterCode,
                Description = model.Description,
                DepartmentId = model.DepartmentId,
                ProjectId = model.ProjectId,
                AccountingObjectId = model.AccountingObjectId,
                AutoBusinessId = model.AutoBusinessId,
                UnitPriceExchange = model.UnitPriceExchange,
                UnitPriceOC = model.UnitPriceOC
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static FixedAssetCurrencyEntity ToDataTransferObject(FixedAssetCurrencyModel model)
        {
            return new FixedAssetCurrencyEntity
            {
                FixedAssetCurrencyId = model.FixedAssetCurrencyId,
                FixedAssetId = model.FixedAssetId,
                CurrencyCode = model.CurrencyCode,
                UnitPrice = model.UnitPrice,
                UnitPriceUSD = model.UnitPriceUSD,
                OrgPrice = model.OrgPrice,
                OrgPriceUSD = model.OrgPriceUSD,
                AccumDepreciationAmount = model.AccumDepreciationAmount,
                AccumDepreciationAmountUSD = model.AccumDepreciationAmountUSD,
                RemainingAmount = model.RemainingAmount,
                RemainingAmountUSD = model.RemainingAmountUSD,
                AnnualDepreciationAmount = model.AnnualDepreciationAmount,
                AnnualDepreciationAmountUSD = model.AnnualDepreciationAmountUSD,
                ExchangeRate = model.ExchangeRate
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static OpeningAccountEntryDetailEntity ToDataTransferObject(OpeningAccountEntryDetailModel model)
        {
            return new OpeningAccountEntryDetailEntity
            {
                RefDetailId = model.RefDetailId,
                RefTypeId = model.RefTypeId,
                PostedDate = model.PostedDate,
                AccountCode = model.AccountCode,
                AccountName = model.AccountName,
                AccountId = model.AccountId,
                ParentId = model.ParentId,
                AccountBeginningDebitAmountOC = model.AccountBeginningDebitAmountOC,
                AccountBeginningCreditAmountOC = model.AccountBeginningCreditAmountOC,
                DebitAmountOC = model.DebitAmountOC,
                CreditAmountOC = model.CreditAmountOC,
                AccountBeginningDebitAmountExchange = model.AccountBeginningDebitAmountExchange,
                AccountBeginningCreditAmountExchange = model.AccountBeginningCreditAmountExchange,
                DebitAmountExchange = model.DebitAmountExchange,
                CreditAmountExchange = model.CreditAmountExchange,
                CurrencyCode = model.CurrencyCode,
                ExchangeRate = model.ExchangeRate,
                BudgetSourceCode = model.BudgetSourceCode,
                BudgetChapterCode = model.BudgetChapterCode,
                BudgetCategoryCode = model.BudgetCategoryCode,
                BudgetGroupItemCode = model.BudgetGroupItemCode,
                BudgetItemCode = model.BudgetItemCode,
                MergerFundId = model.MergerFundId,
                EmployeeId = model.EmployeeId,
                CustomerId = model.CustomerId,
                VendorId = model.VendorId,
                AccountingObjectId = model.AccountingObjectId,
                ProjectId = model.ProjectId,
                BankId = model.BankId
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static OpeningAccountEntryEntity ToDataTransferObject(OpeningAccountEntryModel model)
        {
            return new OpeningAccountEntryEntity
            {
                RefId = model.RefId,
                RefTypeId = model.RefTypeId,
                PostedDate = model.PostedDate, // + new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second),
                AccountCode = model.AccountCode,
                AccountName = model.AccountName,
                AccountId = model.AccountId,
                ParentId = model.ParentId,
                TotalAccountBeginningDebitAmountOC = model.TotalAccountBeginningDebitAmountOC,
                TotalAccountBeginningCreditAmountOC = model.TotalAccountBeginningCreditAmountOC,
                TotalDebitAmountOC = model.TotalDebitAmountOC,
                TotalCreditAmountOC = model.TotalCreditAmountOC,
                TotalAccountBeginningDebitAmountExchange = model.TotalAccountBeginningDebitAmountExchange,
                TotalAccountBeginningCreditAmountExchange = model.TotalAccountBeginningCreditAmountExchange,
                TotalDebitAmountExchange = model.TotalDebitAmountExchange,
                TotalCreditAmountExchange = model.TotalCreditAmountExchange,
                OpeningAccountEntryDetails = ToDataTransferObjects(model.OpeningAccountEntryDetails)
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static OpeningInventoryEntryEntity ToDataTransferObject(OpeningInventoryEntryModel model)
        {
            return new OpeningInventoryEntryEntity
            {
                AccountName = model.AccountName,
                AccountId = model.AccountId,
                ParentId = model.ParentId,

                RefId = model.RefId,
                RefTypeId = model.RefTypeId,
                PostedDate = model.PostedDate, // + new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second),
                UnitPriceOc = model.UnitPriceOc,
                UnitPriceExchange = model.UnitPriceExchange,
                AccountNumber = model.AccountNumber,
                CurrencyCode = model.CurrencyCode,
                ExchangeRate = model.ExchangeRate,
                RefNo = model.RefNo,
                AmountExchange = model.AmountExchange,
                AmountOc = model.AmountOc,
                Quantity = model.Quantity,
                InventoryItemId = model.InventoryItemId,
                StockId = model.StockId

            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static FixedAssetB03HEntity ToDataTransferObject(FixedAssetB03HModel model)
        {
            return new FixedAssetB03HEntity
            {
                FixedAssetCategoryId = model.FixedAssetCategoryId,
                FixedAssetCategoryCode = model.FixedAssetCategoryCode,
                FixedAssetCategoryName = model.FixedAssetCategoryName,
                ParentId = model.ParentId,
                Unit = model.Unit,
                QuantityOpening = model.QuantityOpening,
                QuantityIncrement = model.QuantityIncrement,
                QuantityDecrement = model.QuantityDecrement,
                QuantityClosing = model.QuantityClosing,
                OrgPriceOpening = model.OrgPriceOpening,
                OrgPriceOpeningUSD = model.OrgPriceOpeningUSD,
                OrgPriceOpeningCurrencyUSD = model.OrgPriceOpeningCurrencyUSD,
                TotalOrgPriceOpeningUSD = model.TotalOrgPriceOpeningUSD,
                OrgPriceIncrement = model.OrgPriceIncrement,
                OrgPriceIncrementUSD = model.OrgPriceIncrementUSD,
                OrgPriceIncrementCurrencyUSD = model.OrgPriceIncrementCurrencyUSD,
                TotalOrgPriceIncrementUSD = model.TotalOrgPriceIncrementUSD,
                OrgPriceDecrement = model.OrgPriceDecrement,
                OrgPriceDecrementUSD = model.OrgPriceDecrementUSD,
                OrgPriceDecrementCurrencyUSD = model.OrgPriceDecrementCurrencyUSD,
                TotalOrgPriceDecrementUSD = model.TotalOrgPriceDecrementUSD,
                OrgPriceClosing = model.OrgPriceClosing,
                OrgPriceClosingUSD = model.OrgPriceClosingUSD,
                OrgPriceClosingCurrencyUSD = model.OrgPriceClosingCurrencyUSD,
                TotalOrgPriceClosingUSD = model.TotalOrgPriceClosingUSD,
                Grade = model.Grade,
                Sort = model.Sort
            };
        }

        /// <summary>
        /// Froms the payment detail data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static FixedAssetC55aHDEntity FromDataTransferObject(FixedAssetC55aHDModel model)
        {
            if (model == null) return null;
            return new FixedAssetC55aHDEntity
            {
                OrderNumber = model.OrderNumber,
                FixedAssetId = model.FixedAssetId,
                FixedAssetName = model.FixedAssetName,
                FixedAssetCategoryCode = model.FixedAssetCategoryCode,
                FixedAssetCategoryName = model.FixedAssetCategoryName,
                YearOfUsing = model.YearOfUsing,
                AddressUsing = model.AddressUsing,
                Unit = model.Unit,
                SerialNumber = model.SerialNumber,
                OrgPrice = model.OrgPrice,
                OrgPriceUSD = model.OrgPriceUSD,
                OrgPriceCurrencyUSD = model.OrgPriceCurrencyUSD,
                TotalOrgPriceUSD = model.TotalOrgPriceUSD,
                AnnualDepreciationAmount = model.AnnualDepreciationAmount,
                RemainigAmount = model.RemainigAmount,
                LifeTime = model.LifeTime,
                AnnualDepreciationRate = model.AnnualDepreciationRate,
                DepreciationYearAmount = model.DepreciationYearAmount,
                DepreciationYearAmountUSD = model.DepreciationYearAmountUSD,
                DepreciationYearAmountCurrencyUSD = model.DepreciationYearAmountCurrencyUSD,
                TotalDepreciationYearAmountUSD = model.TotalDepreciationYearAmountUSD
            };
        }

        /// <summary>
        /// Froms the payment detail data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static FixedAssetFAInventoryEntity FromDataTransferObject(FixedAssetFAInventoryModel model)
        {
            if (model == null) return null;
            return new FixedAssetFAInventoryEntity
            {
                OrderNumber = model.OrderNumber,
                FixedAssetCategoryCode = model.FixedAssetCategoryCode,
                FixedAssetId = model.FixedAssetId,
                FixedAssetCode = model.FixedAssetCode,
                FixedAssetName = model.FixedAssetName,
                ParentId = model.ParentId,
                YearOfUsing = model.YearOfUsing,
                Description = model.Description,
                Unit = model.Unit,
                DepreciationRate = model.DepreciationRate,
                SerialNumber = model.SerialNumber,
                CountryProduction = model.CountryProduction,
                Quantity = model.Quantity,
                OrgPrice = model.OrgPrice,
                OrgPriceUsd = model.OrgPriceUsd,
                OrgPriceCurrencyUsd = model.OrgPriceCurrencyUsd,
                TotalOrgPriceUsd = model.TotalOrgPriceUsd,

                QuantityInvetory = model.QuantityInvetory,
                OrgPriceInvetory = model.OrgPriceInvetory,
                OrgPriceCurrencyInvetoryUsd = model.OrgPriceCurrencyInvetoryUsd,
                OrgPriceInvetoryUsd = model.OrgPriceInvetoryUsd,
                TotalOrgPriceInvetoryUsd = model.TotalOrgPriceInvetoryUsd,

                QuantityDifference = model.QuantityDifference,
                OrgPriceDifference = model.OrgPriceDifference,
                OrgPriceCurrencyDifferenceUsd = model.OrgPriceCurrencyDifferenceUsd,
                OrgPriceDifferenceUsd = model.OrgPriceDifferenceUsd,
                TotalOrgPriceDifferenceUsd = model.TotalOrgPriceDifferenceUsd,

                Grade = model.Grade,
                Sort = model.Sort
            };
        }

        /// <summary>
        /// Froms the payment detail data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static FixedAssetS31HEntity FromDataTransferObject(FixedAssetS31HModel model)
        {
            if (model == null) return null;
            return new FixedAssetS31HEntity
            {
                PostedDate = model.PostedDate,
                RefNo = model.RefNo,
                RefDate = model.RefDate,
                FixedAssetName = model.FixedAssetName,
                FixedAssetCode = model.FixedAssetCode,
                YearOfUsing = model.YearOfUsing,
                LifeTime = model.LifeTime,
                AnnualDepreciationRate = model.AnnualDepreciationRate,
                OrgPrice = model.OrgPrice,
                AnnualDepreciationAmount = model.AnnualDepreciationAmount,
                RemainingPriceBeforeDecrement = model.RemainingPriceBeforeDecrement
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static RoleEntity ToDataTransferObject(RoleModel model)
        {
            return new RoleEntity
            {
                RoleId = model.RoleId,
                RoleName = model.RoleName,
                Description = model.Description,
                IsActive = model.IsActive,
                RoleSiteEntities = ToDataTransferObjects(model.RoleSiteModels)
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static SiteEntity ToDataTransferObject(SiteModel model)
        {
            return new SiteEntity
            {
                SiteId = model.SiteId,
                SiteCode = model.SiteCode,
                SiteName = model.SiteName,
                Description = model.Description,
                ParentId = model.ParentId,
                Order = model.Order,
                IsActive = model.IsActive,
                PermissionSiteEntities = ToDataTransferObjects(model.PermissionSiteModels),
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static PermissionEntity ToDataTransferObject(PermissionModel model)
        {
            return new PermissionEntity
            {
                PermissionId = model.PermissionId,
                PermissionCode = model.PermissionCode,
                PermissionName = model.PermissionName,
                Description = model.Description,
                IsActive = model.IsActive
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static PermissionSiteEntity ToDataTransferObject(PermissionSiteModel model)
        {
            return new PermissionSiteEntity
            {
                PermissionSiteId = model.PermissionSiteId,
                SiteId = model.SiteId,
                PermissionId = model.PermissionId,
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static RoleSiteEntity ToDataTransferObject(RoleSiteModel model)
        {
            return new RoleSiteEntity
            {
                RoleSiteId = model.RoleSiteId,
                RoleId = model.RoleId,
                SiteId = model.SiteId,
                PermissionId = model.PermissionId
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static UserProfileEntity ToDataTransferObject(UserProfileModel model)
        {
            return new UserProfileEntity
            {
                UserProfileId = model.UserProfileId,
                UserProfileName = model.UserProfileName,
                FullName = model.FullName,
                Password = model.Password,
                IsActive = model.IsActive,
                Email = model.Email,
                CreateDate = model.CreateDate == null ? (DateTime?)null : DateTime.Parse(model.CreateDate),
                Description = model.Description
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static OpeningFixedAssetEntryEntity ToDataTransferObject(OpeningFixedAssetEntryModel model)
        {
            return new OpeningFixedAssetEntryEntity
            {
                AccountId = model.AccountId,
                ParentId = model.ParentId,
                AccountNumber = model.AccountNumber,
                AccountName = model.AccountName,
                AmountOc = model.AmountOc,
                AmountExchange = model.AmountExchange,
                RefId = model.RefId,
                RefNo = model.RefNo,
                RefTypeId = model.RefTypeId,
                PostedDate = model.PostedDate,
                FixedAssetId = model.FixedAssetId,
                DepartmentId = model.DepartmentId,
                LifeTime = model.LifeTime,
                IncrementDate = model.IncrementDate,
                Unit = model.Unit,
                UsedDate = model.UsedDate,
                CurrencyCode = model.CurrencyCode,
                ExchangeRate = model.ExchangeRate,
                OrgPriceAccount = model.OrgPriceAccount,
                OrgPriceDebitAmount = model.OrgPriceDebitAmount,
                OrgPriceDebitAmountUSD = model.OrgPriceDebitAmountUSD,
                DepreciationAccount = model.DepreciationAccount,
                DepreciationCreditAmount = model.DepreciationCreditAmount,
                DepreciationCreditAmountUSD = model.DepreciationCreditAmountUSD,
                CapitalAccount = model.CapitalAccount,
                CapitalCreditAmount = model.CapitalCreditAmount,
                CapitalCreditAmountUSD = model.CapitalCreditAmountUSD,
                RemainingAmount = model.RemainingAmount,
                RemainingAmountUSD = model.RemainingAmountUSD,
                BudgetChapterCode = model.BudgetChapterCode,
                Description = model.Description,
                Quantity = model.Quantity,
                BudgetSourceCode = model.BudgetSourceCode
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static EmployeeLeasingEntity ToDataTransferObject(EmployeeLeasingModel model)
        {
            return new EmployeeLeasingEntity
            {
                EmployeeLeasingId = model.EmployeeLeasingId,
                EmployeeLeasingCode = model.EmployeeLeasingCode,
                EmployeeLeasingName = model.EmployeeLeasingName,
                JobCandidate = model.JobCandidate,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Description = model.Description,
                IsActive = model.IsActive,
                IsLeasing = model.IsLeasing,
                InsurancePrice = model.InsurancePrice,
                SalaryPrice = model.SalaryPrice,
                UniformPrice = model.UniformPrice
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static BuildingEntity ToDataTransferObject(BuildingModel model)
        {
            return new BuildingEntity
            {
                OrderNumber = model.OrderNumber,
                BuildingId = model.BuildingId,
                BuildingCode = model.BuildingCode,
                BuildingName = model.BuildingName,
                JobCandidate = model.JobCandidate,
                Address = model.Address,
                Area = model.Area,
                UnitPrice = model.UnitPrice,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Description = model.Description,
                IsActive = model.IsActive
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static EstimateDetailStatementInfoEntity ToDataTransferObject(EstimateDetailStatementInfoModel model)
        {
            return new EstimateDetailStatementInfoEntity
            {
                EstimateDetailStatementId = model.EstimateDetailStatementId,
                GeneralDescription = model.GeneralDescription,
                EmployeeContractDescription = model.EmployeeContractDescription,
                EmployeeLeasingDescription = model.EmployeeLeasingDescription,
                BuildingOfFixedAssetDescription = model.BuildingOfFixedAssetDescription,
                CarDescription = model.CarDescription,
                DescriptionForBuilding = model.DescriptionForBuilding,
                InventoryDescription = model.InventoryDescription,
                PartC = model.PartC,
                PartC1 = model.PartC1,
                IsActive = model.IsActive,
                Type = model.Type

            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static EstimateDetailStatementPartBEntity ToDataTransferObject(EstimateDetailStatementPartBModel model)
        {
            return new EstimateDetailStatementPartBEntity
            {
                EstimateDetailStatementPartBId = model.EstimateDetailStatementPartBId,
                OrderNumber = model.OrderNumber,
                Description = model.Description,
                Amount = model.Amount,
                Note = model.Note,
                IsActive = model.IsActive
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static EstimateDetailStatementFixedAssetEntity ToDataTransferObject(EstimateDetailStatementFixedAssetModel model)
        {
            return new EstimateDetailStatementFixedAssetEntity
            {
                EstimateDetailStatementFixedAssetId = model.EstimateDetailStatementFixedAssetId,
                OrderNumber = model.OrderNumber,
                PurchasedYear = model.PurchasedYear,
                OrgPriceUsd = model.OrgPriceUsd,
                PurchasedOrgPriceUsd = model.PurchasedOrgPriceUsd,
                Department = model.Department,
                ReplacementReason = model.ReplacementReason,
                PostedYear = model.PostedYear,
                IsActive = model.IsActive
            };
        }

        #endregion

        #region ToDataTransferObjects
        internal static IList<SalaryVoucherEntity> ToDataTransferObjects(IList<SalaryVoucherModel> models)
        {
            if (models == null)
                return null;
            return models.Select(ToDataTransferObject).ToList();
        }

        internal static IList<AutoNumberListEntity> ToDataTransferObjects(IList<AutoNumberListModel> models)
        {
            if (models == null)
                return null;
            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns>IList&lt;OpeningSupplyEntryEntity&gt;.</returns>
        internal static IList<OpeningSupplyEntryEntity> ToDataTransferObjects(IList<OpeningSupplyEntryModel> models)
        {
            if (models == null)
                return null;
            return models.Select(ToDataTransferObject).ToList();
            //return models.Select(m => AutoMapper(m, new OpeningSupplyEntryEntity())).ToList();
        }

        internal static IList<MutualEntity> ToDataTransferObjects(IList<MutualModel> models)
        {
            if (models == null)
                return null;
            return models.Select(ToDataTransferObject).ToList();
        }



        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        internal static IList<ItemTransactionEntity> ToDataTransferObjects(IList<ItemTransactionModel> models)
        {
            if (models == null)
                return null;

            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        internal static IList<OpeningInventoryEntryEntity> ToDataTransferObjects(IList<OpeningInventoryEntryModel> models)
        {
            if (models == null)
                return null;

            return models.Select(ToDataTransferObject).ToList();
        }
        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        internal static IList<AutoNumberEntity> ToDataTransferObjects(IList<AutoNumberModel> models)
        {
            if (models == null)
                return null;

            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        internal static IList<EmployeeEntity> ToDataTransferObjects(IList<EmployeeModel> models)
        {
            if (models == null)
                return null;

            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The entities.</param>
        /// <returns></returns>
        internal static IList<SalaryEntity> ToDataTransferObjects(IList<SalaryModel> models)
        {
            if (models == null)
                return null;

            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The entities.</param>
        /// <returns></returns>
        internal static IList<CapitalAllocateEntity> ToDataTransferObjects(IList<CapitalAllocateModel> models)
        {
            if (models == null)
                return null;

            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the cash data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static List<CashDetailEntity> ToCashDataTransferObjects(IList<ReceiptVoucherDetailModel> entities)
        {
            return entities == null ? null : entities.Select(ToReceiptDetailDataTransferObject).ToList();
        }

        /// <summary>
        /// To the cash data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static List<CashDetailEntity> ToCashDataTransferObjects(IList<CashDetailModel> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// To the general voucher detail data transfer object.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static List<GeneralDetailEntity> ToGeneralVoucherDetailDataTransferObject(IList<GeneralDetailModel> entities)
        {
            return entities == null ? null : entities.Select(ToGeneralVoucherDetailDataTransferObject).ToList();
        }

        /// <summary>
        /// To the general data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static List<GeneralDetailEntity> ToGeneralDataTransferObjects(IList<GeneralDetailModel> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The entities.</param>
        /// <returns></returns>
        internal static IList<CustomerEntity> ToDataTransferObjects(IList<CustomerModel> models)
        {
            if (models == null)
                return null;

            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        internal static IList<VoucherListEntity> ToDataTransferObjects(IList<VoucherListModel> models)
        {
            if (models == null)
                return null;
            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The entities.</param>
        /// <returns></returns>
        internal static IList<AccountCategoryEntity> ToDataTransferObjects(IList<AccountCategoryModel> models)
        {
            if (models == null)
                return null;

            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The entities.</param>
        /// <returns></returns>
        internal static IList<EstimateEntity> ToDataTransferObjects(IList<EstimateModel> models)
        {
            if (models == null)
                return null;

            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The entities.</param>
        /// <returns></returns>
        internal static IList<EstimateDetailEntity> ToDataTransferObjects(IList<EstimateDetailModel> models)
        {
            if (models == null)
                return null;

            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The entities.</param>
        /// <returns></returns>
        internal static IList<StockEntity> ToDataTransferObjects(IList<StockModel> models)
        {
            if (models == null)
                return null;

            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The entities.</param>
        /// <returns></returns>
        internal static IList<InventoryItemEntity> ToDataTransferObjects(IList<InventoryItemModel> models)
        {
            if (models == null)
                return null;

            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The entities.</param>
        /// <returns></returns>
        internal static IList<EmployeePayItemEntity> ToDataTransferObjects(IList<EmployeePayItemModel> models)
        {
            if (models == null)
                return null;

            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The entities.</param>
        /// <returns></returns>
        internal static IList<PlanTemplateItemEntity> ToDataTransferObjects(IList<PlanTemplateItemModel> models)
        {
            if (models == null)
                return null;

            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns>
        /// IList{DepositEntity}.
        /// </returns>
        internal static IList<DepositEntity> ToDataTransferObjects(IList<DepositModel> models)
        {
            if (models == null)
                return null;
            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns>
        /// IList{DepositDetailEntity}.
        /// </returns>
        internal static IList<DepositDetailEntity> ToDataTransferObjects(IList<DepositDetailModel> models)
        {
            if (models == null)
                return null;
            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns>
        /// IList{DepositDetailEntity}.
        /// </returns>
        internal static IList<ItemTransactionDetailEntity> ToDataTransferObjects(IList<ItemTransactionDetailModel> models)
        {
            if (models == null)
                return null;
            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The entities.</param>
        /// <returns></returns>
        internal static IList<DBOptionEntity> ToDataTransferObjects(IList<DBOptionModel> models)
        {
            if (models == null)
                return null;

            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        internal static IList<FAArmortizationDetailEntity> ToDataTransferObjects(IList<FixedAssetArmortizationDetailModel> models)
        {
            if (models == null)
                return null;

            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        internal static IList<FADecrementDetailEntity> ToDataTransferObjects(IList<FixedAssetDecrementDetailModel> models)
        {
            if (models == null)
                return null;

            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        internal static IList<FAIncrementDetailEntity> ToDataTransferObjects(IList<FixedAssetIncrementDetailModel> models)
        {
            if (models == null)
                return null;

            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        internal static IList<FixedAssetCurrencyEntity> ToDataTransferObjects(IList<FixedAssetCurrencyModel> models)
        {
            if (models == null)
                return null;

            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        internal static IList<FAIncrementEntity> ToDataTransferObjects(IList<FixedAssetIncrementModel> models)
        {
            if (models == null)
                return null;

            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        internal static IList<FADecrementEntity> ToDataTransferObjects(IList<FixedAssetDecrementModel> models)
        {
            if (models == null)
                return null;

            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        internal static IList<OpeningAccountEntryDetailEntity> ToDataTransferObjects(IList<OpeningAccountEntryDetailModel> models)
        {
            if (models == null)
                return null;

            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static List<ReceiptVoucherDetailModel> ToReceiptDetailDataTransferObjects(List<CashDetailEntity> entities)
        {
            if (entities == null) return null;
            return entities.Select(ToReceiptDetailDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static List<GeneralDetailModel> ToDataTransferObjects(List<GeneralDetailEntity> entities)
        {
            if (entities == null) return null;
            return entities.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static List<CashDetailModel> ToDataTransferObjects(List<CashDetailEntity> entities)
        {
            if (entities == null) return null;
            return entities.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the general voucher detail data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static List<GeneralDetailModel> ToGeneralVoucherDetailDataTransferObjects(List<GeneralDetailEntity> entities)
        {
            if (entities == null) return null;
            return entities.Select(ToGeneralDetailDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        internal static IList<PermissionEntity> ToDataTransferObjects(IList<PermissionModel> models)
        {
            if (models == null)
                return null;

            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        internal static IList<PermissionSiteEntity> ToDataTransferObjects(IList<PermissionSiteModel> models)
        {
            if (models == null)
                return null;

            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        internal static IList<RoleSiteEntity> ToDataTransferObjects(IList<RoleSiteModel> models)
        {
            if (models == null)
                return null;

            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        internal static IList<OpeningFixedAssetEntryEntity> ToDataTransferObjects(IList<OpeningFixedAssetEntryModel> models)
        {
            if (models == null)
                return null;

            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        internal static IList<EstimateDetailStatementInfoEntity> ToDataTransferObjects(IList<EstimateDetailStatementInfoModel> models)
        {
            if (models == null)
                return null;

            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        internal static IList<EstimateDetailStatementPartBEntity> ToDataTransferObjects(IList<EstimateDetailStatementPartBModel> models)
        {
            if (models == null)
                return null;

            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        internal static IList<EstimateDetailStatementFixedAssetEntity> ToDataTransferObjects(IList<EstimateDetailStatementFixedAssetModel> models)
        {
            if (models == null)
                return null;

            return models.Select(ToDataTransferObject).ToList();
        }
        #endregion

        #region Report Mapper
        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static FixedAssetHousingReportModel FromDataTransferObject(FixedAssetHousingReportEntity entity)
        {
            if (entity == null) return null;

            return new FixedAssetHousingReportModel
            {
                FixedAssetHousingReportId = entity.FixedAssetHousingReportId,
                AreaOfBuilding = entity.AreaOfBuilding,
                WorkingArea = entity.WorkingArea,
                HousingArea = entity.HousingArea,
                GuestHouseArea = entity.GuestHouseArea,
                OccupiedArea = entity.OccupiedArea,
                OtherArea = entity.OtherArea,
                AccountingValue = entity.AccountingValue,
                Attachments = entity.Attachments
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static B01HModel FromDataTransferObject(B01HEntity entity)
        {
            if (entity == null) return null;

            return new B01HModel
            {
                AccountCode = entity.AccountCode,
                AccountName = entity.AccountName,
                OpeningCredit = entity.OpeningCredit,
                OpeningDebit = entity.OpeningDebit,
                MovementCredit = entity.MovementCredit,
                MovementDebit = entity.MovementDebit,
                MovementAccumCredit = entity.MovementAccumCredit,
                MovementAccumDebit = entity.MovementAccumDebit,
                ClosingCredit = entity.ClosingCredit,
                ClosingDebit = entity.ClosingDebit,
                IsDetail = entity.IsDetail,
                Grade = entity.Grade,
            };
        }
        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static C22HModel FromDataTransferObject(C22HEntity entity)
        {
            if (entity == null) return null;

            return new C22HModel
            {
                RefId = entity.RefId,
                RefNo = entity.RefNo,
                RefDate = entity.RefDate,
                PostedDate = entity.PostedDate,
                AccountingObjectName = entity.AccountingObjectName,
                AccountingObjectAddress = entity.AccountingObjectAddress,
                DebitAccount = entity.DebitAccount,
                CreditAccount = entity.CreditAccount,
                TotalAmount = entity.TotalAmount,
                JournalMemo = entity.JournalMemo,
                DocumentInclude = entity.DocumentInclude,
                CurrencyCode = entity.CurrencyCode,
                ExchangeRate = entity.ExchangeRate,
                TotalAmountExchange = entity.TotalAmountExchange,
                Trader = entity.Trader
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static C30BB501Model FromDataTransferObject(C30BB501Entity entity)
        {
            if (entity == null) return null;

            return new C30BB501Model
            {
                AccountNumber = entity.AccountNumber,
                PostedDate = entity.PostedDate,
                RefNo = entity.RefNo,
                Address = entity.Address,
                CorrespondingAccountNumber = entity.CorrespondingAccountNumber,
                DocumentInclude = entity.DocumentInclude,
                ExchangeRate = entity.ExchangeRate,
                IsSelect = entity.IsSelect,
                JournalMemo = entity.JournalMemo,
                RefId = entity.RefId,
                TotalAmount = entity.TotalAmount,
                TotalAmountExchange = entity.TotalAmountExchange,
                Trader = entity.Trader,
                CurrencyCode = entity.CurrencyCode,
                ContactName = entity.ContactName
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns
        /// ></returns>
        internal static C11HModel FromDataTransferObject(C11HEntity entity)
        {
            if (entity == null) return null;

            return new C11HModel
            {
                RefId = entity.RefId,
                RefNo = entity.RefNo,
                RefDate = entity.RefDate,
                PostedDate = entity.PostedDate,
                AccountingObjectName = entity.AccountingObjectName,
                AccountingObjectAddress = entity.AccountingObjectAddress,
                //  DebitAccount = entity.DebitAccount,
                CurrencyCode = entity.CurrencyCode,
                TotalAmount = entity.TotalAmount,
                JournalMemo = entity.JournalMemo,
                StockName = entity.StockName,
                Trader = entity.Trader,
                InventoryItems = FromDataTransferObjects(entity.InventoryItems)
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static InventoryItemReportModel FromDataTransferObject(InventoryItemReportEntity entity)
        {
            if (entity == null) return null;

            return new InventoryItemReportModel
            {
                OrderNumber = entity.OrderNumber,
                InventoryItemName = entity.InventoryItemName,
                Quantity = entity.Quantity,
                Price = entity.Price,
                AmountOc = entity.AmountOc,
                Unit = entity.Unit

            };
        }

        /// <summary>
        /// Froms
        ///  the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static A02LDTLModel FromDataTransferObject(A02LDTLEntity entity)
        {
            if (entity == null) return null;

            return new A02LDTLModel
            {
                OrderNumber = entity.OrderNumber,
                EmployeeName = entity.EmployeeName,
                JobCandidateName = entity.JobCandidateName,
                NumberSHP = entity.NumberSHP,
                SHP = entity.SHP,
                PCVS = entity.PCVS,
                PCKiemNhiem = entity.PCKiemNhiem,
                TroCapCT = entity.TroCapCT,
                TongCong = entity.TongCong,
                QuiDoi = entity.QuiDoi,
                ExchangeRate = entity.ExchangeRate,
                CurrencyCode = entity.CurrencyCode,
                CalcDate = entity.CalcDate,
                BaseOfSalary = entity.BaseOfSalary,
                WorkDays = entity.WorkDay
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static B14QModel FromDataTransferObject(B14QEntity entity)
        {
            if (entity == null) return null;

            return new B14QModel
            {
                InventoryItemCode = entity.InventoryItemCode,
                InventoryItemName = entity.InventoryItemName,
                Unit = entity.Unit,
                QuantityOpening = entity.QuantityOpening,
                QuantityInwardStock = entity.QuantityInwardStock,
                QuantityOutwardStock = entity.QuantityOutwardStock,
                QuantityClosing = entity.QuantityClosing,

                OrgPriceClosing = entity.OrgPriceClosing,
                OrgPriceInwardStock = entity.OrgPriceInwardStock,
                OrgPriceOpening = entity.OrgPriceOpening,
                OrgPriceOutwardStock = entity.OrgPriceOutwardStock,
                CancelQuantity = entity.CancelQuantity,
                FreeQuantity = entity.FreeQuantity,
                TotalQuantity = entity.TotalQuantity
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static S03AHModel FromDataTransferObject(S03AHEntity entity)
        {
            if (entity == null) return null;

            return new S03AHModel
            {
                PostedDate = entity.PostedDate,
                RefDate = entity.RefDate,
                RefNo = entity.RefNo,
                Description = entity.Description,
                AccountNumber = entity.AccountNumber,
                DebitAmount = entity.DebitAmount,
                CreditAmount = entity.CreditAmount,
                FontStyle = entity.FontStyle,
                RefId = entity.RefId,
                RefTypeId = entity.RefTypeId
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static AccountingVoucherModel FromDataTransferObject(AccountingVoucherEntity entity)
        {
            if (entity == null) return null;

            return new AccountingVoucherModel
            {
                CurrencyCode = entity.CurrencyCode,
                PostedDate = entity.PostedDate,
                RefDate = entity.RefDate,
                RefNo = entity.RefNo,
                Description = entity.Description,
                AccountNumber = entity.AccountNumber,
                CorrespondingAccountNumber = entity.CorrespondingAccountNumber,
                OrderNumber = entity.OrderNumber,
                AmountOC = entity.AmountOC,
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static S33HModel FromDataTransferObject(S33HEntity entity)
        {
            if (entity == null) return null;

            return new S33HModel
            {
                PostedDate = entity.PostedDate,
                RefDate = entity.RefDate,
                RefNo = entity.RefNo,
                Description = entity.Description,
                CorrespondingAccountNumber = entity.CorrespondingAccountNumber,
                JournalMemo = entity.JournalMemo,
                DebitAmountBalance = entity.DebitAmountBalance,
                CreditAmountBalance = entity.CreditAmountBalance,
                DebitAmountOriginal = entity.DebitAmountOriginal,
                CreditAmountOriginal = entity.CreditAmountOriginal,
                FontStyle = entity.FontStyle,
                RefId = entity.RefId,
                RefTypeId = entity.RefTypeId
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static FixedAssetHousingReportEntity ToDataTransferObject(FixedAssetHousingReportModel model)
        {
            return new FixedAssetHousingReportEntity
            {
                FixedAssetHousingReportId = model.FixedAssetHousingReportId,
                AreaOfBuilding = model.AreaOfBuilding,
                WorkingArea = model.WorkingArea,
                HousingArea = model.HousingArea,
                GuestHouseArea = model.GuestHouseArea,
                OccupiedArea = model.OccupiedArea,
                OtherArea = model.OtherArea,
                AccountingValue = model.AccountingValue,
                Attachments = model.Attachments
            };
        }

        internal static IList<FixedAssetHousingReportEntity> ToDataTransferObjects(IList<FixedAssetHousingReportModel> models)
        {
            if (models == null)
                return null;

            return models.Select(ToDataTransferObject).ToList();
        }
        #endregion

    }
}