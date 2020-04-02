/***********************************************************************
 * <copyright file="Model.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 12 March 2014 
 * Usage:  
 * 
 * RevisionHistory: 
 * Date: 19/05/2014  Author: ThangND   Description: Thêm các region, mọi người code cho hẳn hoi chút tạo các phần mục theo chuẩn để code không bị lẫn lộn
 * Date: 30/05/2014  Author: LinhMC    Description: Thêm hàm lấy mã ID theo code của bất kỳ bảng nào phụ thuộc vào tham số truyền vào.
 * ************************************************************************/

using System;
using System.Linq;
using System.Collections.Generic;
using TSD.AccountingSoft.BusinessComponents.Facade;
using TSD.AccountingSoft.BusinessComponents.Facade.Cash;
using TSD.AccountingSoft.BusinessComponents.Facade.Deposit;
using TSD.AccountingSoft.BusinessComponents.Facade.Dictionary;
using TSD.AccountingSoft.BusinessComponents.Facade.Estimate;
using TSD.AccountingSoft.BusinessComponents.Facade.Inventory;
using TSD.AccountingSoft.BusinessComponents.Facade.Report;
using TSD.AccountingSoft.BusinessComponents.Facade.Salary;
using TSD.AccountingSoft.BusinessComponents.Facade.General;
using TSD.AccountingSoft.BusinessComponents.Facade.Search;
using TSD.AccountingSoft.BusinessComponents.Messages;
using TSD.AccountingSoft.BusinessComponents.Messages.Cash;
using TSD.AccountingSoft.BusinessComponents.Messages.Deposit;
using TSD.AccountingSoft.BusinessComponents.Messages.Dictionary;
using TSD.AccountingSoft.BusinessComponents.Messages.Estimate;
using TSD.AccountingSoft.BusinessComponents.Messages.Inventory;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessComponents.Messages.Report;
using TSD.AccountingSoft.BusinessComponents.Messages.Salary;
using TSD.AccountingSoft.BusinessComponents.Messages.General;
using TSD.AccountingSoft.BusinessComponents.Messages.Search;
using TSD.AccountingSoft.BusinessComponents.Messages.System;
using TSD.AccountingSoft.BusinessEntities.Business.Inventory;
using TSD.AccountingSoft.Model.BusinessObjects.Cash;
using TSD.AccountingSoft.Model.BusinessObjects.General;
using TSD.AccountingSoft.Model.BusinessObjects.Deposit;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Model.BusinessObjects.Estimate;
using TSD.AccountingSoft.Model.BusinessObjects.FixedAsset;
using TSD.AccountingSoft.Model.BusinessObjects.Report;
using TSD.AccountingSoft.Model.BusinessObjects.Report.Finacial;
using TSD.AccountingSoft.Model.BusinessObjects.Report.FixedAsset;
using TSD.AccountingSoft.Model.BusinessObjects.Salary;
using TSD.AccountingSoft.Model.BusinessObjects.System;
using TSD.AccountingSoft.Model.DataTransferObjectMapper;
using TSD.AccountingSoft.Model.BusinessObjects.Report.Voucher;
using TSD.AccountingSoft.BusinessComponents.Facade.FixedAsset;
using TSD.AccountingSoft.BusinessComponents.Messages.FixedAsset;
using TSD.AccountingSoft.Model.BusinessObjects.Opening;
using TSD.AccountingSoft.BusinessComponents.Messages.Opening;
using TSD.AccountingSoft.BusinessComponents.Facade.Opening;
using TSD.AccountingSoft.Model.BusinessObjects.Report.Estimate;
using TSD.AccountingSoft.BusinessComponents.Facade.System;
using TSD.AccountingSoft.Model.BusinessObjects.Tool;
using TSD.AccountingSoft.BusinessComponents.Facade.Tool;

namespace TSD.AccountingSoft.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class Model : IModel
    {
        public bool IsConvertData { get; set; }

        #region Statics

        private static readonly SalaryFacade SalaryFacadeClient = new SalaryFacade();
        private static readonly BudgetSourceFacade BudgetSourceClient = new BudgetSourceFacade();
        private static readonly BudgetChapterFacade BudgetChapterClient = new BudgetChapterFacade();
        private static readonly AccountFacade AccountClient = new AccountFacade();
        private static readonly BudgetCategoryFacade BudgetCategoryClient = new BudgetCategoryFacade();
        private static readonly MergerFundFacade MergerFundClient = new MergerFundFacade();
        private static readonly AutoNumberFacade AutoNumberClient = new AutoNumberFacade();
        private static readonly DepartmentFacade DepartmentClient = new DepartmentFacade();
        private static readonly BudgetItemFacade BudgetItemClient = new BudgetItemFacade();
        private static readonly AccountCategoryFacade AccountCategoryClient = new AccountCategoryFacade();
        private static readonly FixedAssetCategoryFacade FixedAssetCategoryClient = new FixedAssetCategoryFacade();
        private static readonly FixedAssetFacade FixedAssetClient = new FixedAssetFacade();
        private static readonly PayItemFacade PayItemClient = new PayItemFacade();
        private static readonly CustomerFacade CustomerClient = new CustomerFacade();
        private static readonly VendorFacade VendorClient = new VendorFacade();
        private static readonly AccountingObjectFacade AccountingObjectClient = new AccountingObjectFacade();
        private static readonly VoucherListFacade VoucherListClient = new VoucherListFacade();
        private static readonly EmployeeFacade EmployeeClient = new EmployeeFacade();
        private static readonly CurrencyFacade CurrencyClient = new CurrencyFacade();
        private static readonly PlanTemplateListFacade PlanTemplateListClient = new PlanTemplateListFacade();
        private static readonly PlanTemplateItemFacade PlanTemplateItemClient = new PlanTemplateItemFacade();
        private static readonly StockFacade StockClient = new StockFacade();
        private static readonly InventoryItemFacade InventoryItemClient = new InventoryItemFacade();
        private static readonly CapitalAllocateFacade CapitalAllocateClient = new CapitalAllocateFacade();
        private static readonly BankFacade BankClient = new BankFacade();
        private static readonly AccountTranferFacade AccountTranferClient = new AccountTranferFacade();
        private static readonly DBOptionFacade DBOptionClient = new DBOptionFacade();
        private static readonly ReportListFacade ReportListClient = new ReportListFacade();
        private static readonly ReportGroupFacade ReportGroupClient = new ReportGroupFacade();
        private static readonly AudittingLogFacade AudittingLogClient = new AudittingLogFacade();
        private static readonly EstimateFacade EstimateClient = new EstimateFacade();
        private static readonly DepositFacade DepositClient = new DepositFacade();
        private static readonly CashFacade CashClient = new CashFacade();
        private static readonly VoucherTypeFacade VoucherTypeClient = new VoucherTypeFacade();
        private static readonly AutoBusinessFacade AutoBusinessClient = new AutoBusinessFacade();
        private static readonly RefTypeFacade RefTypeClient = new RefTypeFacade();
        private static readonly ProjectFacade ProjectClient = new ProjectFacade();
        private static readonly InventoryFacade InventoryClient = new InventoryFacade();
        private static readonly FAArmortizationFacade FAArmortizationClient = new FAArmortizationFacade();
        private static readonly FADecrementFacade FADecrementClient = new FADecrementFacade();
        private static readonly FAIncrementFacade FAIncrementClient = new FAIncrementFacade();
        private static readonly FixedAssetLedgerFacade FixedAssetLedgerClient = new FixedAssetLedgerFacade();
        private static readonly FixedAssetVoucherFacade FixedAssetVoucherClient = new FixedAssetVoucherFacade();
        private static readonly GeneralFacade GeneralClient = new GeneralFacade();
        private static readonly SearchFacade SearchClient = new SearchFacade();
        private static readonly CaptitalAllocateVoucherFacade CaptitalAllocateVoucherClient = new CaptitalAllocateVoucherFacade();
        private static readonly AccountTranferVoucherFacade AccountTranferVoucherClient = new AccountTranferVoucherFacade();
        private static readonly OpeningAccountEntryFacade OpeningAccountEntryClient = new OpeningAccountEntryFacade();
        private static readonly OpeningAccountEntryDetailFacade OpeningAccountEntryDetailClient = new OpeningAccountEntryDetailFacade();
        private static readonly CommonFacade CommonFacadeClient = new CommonFacade();
        private static readonly RoleFacade RoleClient = new RoleFacade();
        private static readonly SiteFacade SiteClient = new SiteFacade();
        private static readonly LockFacade LockClient = new LockFacade();
        private static readonly PermissionFacade PermissionClient = new PermissionFacade();
        private static readonly UserProfileFacade UserProfileClient = new UserProfileFacade();
        private static readonly OpeningFixedAssetEntryFacade OpeningFixedAssetEntryClient = new OpeningFixedAssetEntryFacade();
        private static readonly OpeningInventoryEntryFacade OpeningInventoryEntryClient = new OpeningInventoryEntryFacade();
        private static readonly OpeningSupplyEntryFacade OpeningSupplyEntryClient = new OpeningSupplyEntryFacade();
        private static readonly EmployeeLeasingFacade EmployeeLeasingClient = new EmployeeLeasingFacade();
        private static readonly BuildingFacade BuildingClient = new BuildingFacade();
        private static readonly BudgetSourceCategoryFacade BudgetSourceCategoryClient = new BudgetSourceCategoryFacade();
        private static readonly CompanyProfileFacade CompanyProfileClient = new CompanyProfileFacade();
        private static readonly CalculateClosingFacade CalculateClosingClient = new CalculateClosingFacade();
        private static readonly FixedAssetHousingReportFacade FixedAssetHousingReportClient = new FixedAssetHousingReportFacade();
        private static readonly MutualFacade MutualClient = new MutualFacade();
        private static readonly ElectricalWorkFacade ElectricalWorkClient = new ElectricalWorkFacade();
        private static readonly AutoNumberListFacade AutoNumberListClient = new AutoNumberListFacade();
        private static readonly SalaryVoucherFacade SalaryVoucherFacade = new SalaryVoucherFacade();
        private static readonly ExchangeRateFacade ExchangeRateFacade = new ExchangeRateFacade();
        private static readonly JournalEntryAccountFacade JournalEntryAccountFacade = new JournalEntryAccountFacade();
        private static readonly AutoBusinessParallelFacade AutoBusinessParallelClient = new AutoBusinessParallelFacade();
        private static readonly ActivityFacade ActivityClient = new ActivityFacade();
        private static readonly AccountingObjectCategoryFacade AccountingObjectCategoryClient = new AccountingObjectCategoryFacade();
        private static readonly SUIncrementDecrementFacade sUIncrementDecrementFacade = new SUIncrementDecrementFacade();
        private static readonly ReportDataTemplateFacade ReportDataTemplateClient = new ReportDataTemplateFacade();

        /// <summary>
        /// Adds RequestId, ClientTag, and AccessToken to all request types.
        /// </summary>
        /// <typeparam name="T">The request type.</typeparam>
        /// <param name="request">The request</param>
        /// <returns>Fully prepared request, ready to use.</returns>
        private static T PrepareRequest<T>(T request) where T : RequestBase
        {
            return request;
        }
        #endregion

        #region AccountingObjectCategory

        public IList<AccountingObjectCategoryModel> GetAccountingObjectCategories()
        {
            var accountingObjectCategory = AccountingObjectCategoryClient.GetAccountingObjectCategories();
            return DictionaryMapper.FromDataTransferObjects(accountingObjectCategory);
        }

        #endregion

        #region Activity

        public ActivityModel GetActivity(int activityId)
        {
            var activity = ActivityClient.GetActivitys(activityId);
            return DictionaryMapper.FromDataTransferObject(activity);
        }

        public IList<ActivityModel> GetActivitys()
        {
            var activitys = ActivityClient.GetActivitys();
            return DictionaryMapper.FromDataTransferObjects(activitys);
        }

        public IList<ActivityModel> GetActivitysActive(bool isActive)
        {
            var activitys = ActivityClient.GetActivityByActive(isActive);
            return DictionaryMapper.FromDataTransferObjects(activitys);
        }

        public int AddActivity(ActivityModel activity)
        {
            var activityEntity = DictionaryMapper.ToDataTransferObject(activity);
            var response = ActivityClient.InsertActivity(activityEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.ActivityId;
        }

        public int UpdateActivity(ActivityModel activity)
        {
            var activityEntity = DictionaryMapper.ToDataTransferObject(activity);
            var response = ActivityClient.UpdateActivity(activityEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.ActivityId;
        }

        public int DeleteActivity(int activityId)
        {
            var response = ActivityClient.DeleteActivity(activityId);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.ActivityId;
        }

        #endregion

        #region AutoBusinessParallel

        public IList<AutoBusinessParallelModel> GetAutoBusinessParallels()
        {
            var autoBusinesses = AutoBusinessParallelClient.GetAutoBusinessParallels();
            return DictionaryMapper.FromDataTransferObjects(autoBusinesses);
        }

        public IList<AutoBusinessParallelModel> GetAutoBusinessParallelsActive()
        {
            const bool isActive = true;
            var autoBusinesses = AutoBusinessParallelClient.GetAutoBusinessParallelsByActive(isActive);
            return DictionaryMapper.FromDataTransferObjects(autoBusinesses);
        }

        public IList<AutoBusinessParallelModel> GetAutoBusinessParallelsNonActive()
        {
            const bool isActive = false;
            var autoBusinesses = AutoBusinessParallelClient.GetAutoBusinessParallelsByActive(isActive);
            return DictionaryMapper.FromDataTransferObjects(autoBusinesses);
        }

        public AutoBusinessParallelModel GetAutoBusinessParallel(int autoBusinessId)
        {
            var autoBusiness = AutoBusinessParallelClient.GetAutoBusinessParallel(autoBusinessId);
            return DictionaryMapper.FromDataTransferObject(autoBusiness);
        }

        public int AddAutoBusinessParallel(AutoBusinessParallelModel autoBusiness)
        {
            var autoBusinessEntity = DictionaryMapper.ToDataTransferObject(autoBusiness);
            var response = AutoBusinessParallelClient.InsertAutoBusinessParallel(autoBusinessEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.AutoBusinessParallelId;
        }

        public int UpdateAutoBusinessParallel(AutoBusinessParallelModel autoBusiness)
        {
            var autoBusinessEntity = DictionaryMapper.ToDataTransferObject(autoBusiness);
            var response = AutoBusinessParallelClient.UpdateAutoBusinessParallel(autoBusinessEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.AutoBusinessParallelId;
        }

        public int DeleteAutoBusinessParallel(int autoBusinessId)
        {
            var response = AutoBusinessParallelClient.DeleteAutoBusinessParallel(autoBusinessId);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.AutoBusinessParallelId;
        }

        #endregion

        #region BugdetSource

        /// <summary>
        /// Gets the budget sources.
        /// </summary>
        /// <returns>
        /// IList{BudgetSourceModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<BudgetSourceModel> GetBudgetSources()
        {
            var request = PrepareRequest(new BudgetSourceRequest());
            request.LoadOptions = new[] { "BudgetSources" };
            var response = BudgetSourceClient.GetBudgetSources(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return DictionaryMapper.FromDataTransferObjects(response.BudgetSources);
        }

        /// <summary>
        /// Gets the budget sources for combo tree.
        /// </summary>
        /// <param name="budgetCategoryId">The budget category identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<BudgetSourceModel> GetBudgetSourcesForComboTree(int budgetCategoryId)
        {
            var request = PrepareRequest(new BudgetSourceRequest());
            request.LoadOptions = new[] { "BudgetSources", "IsActive", "ForComboTree" };
            request.BudgetSourceId = budgetCategoryId;
            var response = BudgetSourceClient.GetBudgetSources(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return DictionaryMapper.FromDataTransferObjects(response.BudgetSources);
        }

        /// <summary>
        /// Gets the budget sources by fund.
        /// </summary>
        /// <returns>
        /// IList{BudgetSourceModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<BudgetSourceModel> GetBudgetSourcesByFund()
        {
            var request = PrepareRequest(new BudgetSourceRequest());
            request.LoadOptions = new[] { "BudgetSources", "Fund" };
            var response = BudgetSourceClient.GetBudgetSources(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return DictionaryMapper.FromDataTransferObjects(response.BudgetSources);
        }

        /// <summary>
        /// Gets the budget sources active.
        /// </summary>
        /// <returns>
        /// IList{BudgetSourceModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<BudgetSourceModel> GetBudgetSourcesActive()
        {
            var request = PrepareRequest(new BudgetSourceRequest());
            request.LoadOptions = new[] { "BudgetSources", "IsActive" };
            var response = BudgetSourceClient.GetBudgetSources(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return DictionaryMapper.FromDataTransferObjects(response.BudgetSources);
        }

        /// <summary>
        /// Gets the budget sources is parent.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<BudgetSourceModel> GetBudgetSourcesIsParent(bool isParent)
        {
            var request = PrepareRequest(new BudgetSourceRequest());
            request.LoadOptions = new[] { "BudgetSources", "IsParent" };
            request.IsParent = isParent;
            var response = BudgetSourceClient.GetBudgetSources(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return DictionaryMapper.FromDataTransferObjects(response.BudgetSources);
        }
        /// <summary>
        /// Gets the budget source.
        /// </summary>
        /// <param name="budgetCategoryId">The budget category identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public BudgetSourceModel GetBudgetSource(int budgetCategoryId)
        {
            var request = PrepareRequest(new BudgetSourceRequest());
            request.LoadOptions = new[] { "BudgetSource" };
            request.BudgetSourceId = budgetCategoryId;

            var response = BudgetSourceClient.GetBudgetSources(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return DictionaryMapper.FromDataTransferObject(response.BudgetSource);
        }

        /// <summary>
        /// Adds the budget source.
        /// </summary>
        /// <param name="budgetCategory">The budget category.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int AddBudgetSource(BudgetSourceModel budgetCategory)
        {
            var request = PrepareRequest(new BudgetSourceRequest());
            request.Action = PersistType.Insert;
            request.BudgetSource = DictionaryMapper.ToDataTransferObject(budgetCategory);

            var response = BudgetSourceClient.SetBudgetSources(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.BudgetSourceId;
        }

        /// <summary>
        /// Updates the budget source.
        /// </summary>
        /// <param name="budgetCategory">The budget category.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int UpdateBudgetSource(BudgetSourceModel budgetCategory)
        {
            var request = PrepareRequest(new BudgetSourceRequest());
            request.Action = PersistType.Update;
            request.BudgetSource = DictionaryMapper.ToDataTransferObject(budgetCategory);

            var response = BudgetSourceClient.SetBudgetSources(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.BudgetSourceId;
        }

        /// <summary>
        /// Deletes the budget source.
        /// </summary>
        /// <param name="budgetCategoryId">The budget category identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int DeleteBudgetSource(int budgetCategoryId)
        {
            var request = PrepareRequest(new BudgetSourceRequest());
            request.Action = PersistType.Delete;
            request.BudgetSourceId = budgetCategoryId;

            var response = BudgetSourceClient.SetBudgetSources(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RowsAffected;
        }

        #endregion

        #region BudgetChapter

        /// <summary>
        /// Gets the budget chapters.
        /// </summary>
        /// <returns>
        /// IList{BudgetChapterModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<BudgetChapterModel> GetBudgetChapters()
        {
            var request = PrepareRequest(new BudgetChapterRequest());
            request.LoadOptions = new[] { "BudgetChapters" };

            var response = BudgetChapterClient.GetBudgetChapters(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.BudgetChapters);
        }

        /// <summary>
        /// Gets the budget chapters active.
        /// </summary>
        /// <returns>
        /// IList{BudgetChapterModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<BudgetChapterModel> GetBudgetChaptersActive()
        {
            var request = PrepareRequest(new BudgetChapterRequest());
            request.LoadOptions = new[] { "BudgetChapters", "IsActive" };

            var response = BudgetChapterClient.GetBudgetChapters(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.BudgetChapters);
        }

        /// <summary>
        /// Gets the budget chapters non active.
        /// </summary>
        /// <returns>
        /// IList{BudgetChapterModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<BudgetChapterModel> GetBudgetChaptersNonActive()
        {
            var request = PrepareRequest(new BudgetChapterRequest());
            request.LoadOptions = new[] { "BudgetChapters", "NonActive" };

            var response = BudgetChapterClient.GetBudgetChapters(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.BudgetChapters);
        }

        /// <summary>
        /// Gets the budget chapter.
        /// </summary>
        /// <param name="budgetChapterId">The budget chapter identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public BudgetChapterModel GetBudgetChapter(int budgetChapterId)
        {
            var request = PrepareRequest(new BudgetChapterRequest());
            request.LoadOptions = new[] { "BudgetChapter" };
            request.BudgetChapterId = budgetChapterId;

            var response = BudgetChapterClient.GetBudgetChapters(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObject(response.BudgetChapter);
        }

        /// <summary>
        /// Adds the budget chapter.
        /// </summary>
        /// <param name="budgetChapter">The budget chapter.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int AddBudgetChapter(BudgetChapterModel budgetChapter)
        {
            var request = PrepareRequest(new BudgetChapterRequest());
            request.Action = PersistType.Insert;
            request.BudgetChapter = Mapper.ToDataTransferObject(budgetChapter);

            var response = BudgetChapterClient.SetBudgetChapters(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.BudgetChapterId;
        }

        /// <summary>
        /// Updates the budget chapter.
        /// </summary>
        /// <param name="budgetChapter">The budget chapter.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int UpdateBudgetChapter(BudgetChapterModel budgetChapter)
        {
            var request = PrepareRequest(new BudgetChapterRequest());
            request.Action = PersistType.Update;
            request.BudgetChapter = Mapper.ToDataTransferObject(budgetChapter);

            var response = BudgetChapterClient.SetBudgetChapters(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.BudgetChapterId;
        }

        /// <summary>
        /// Deletes the budget chapter.
        /// </summary>
        /// <param name="budgetChapterId">The budget chapter identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int DeleteBudgetChapter(int budgetChapterId)
        {
            var request = PrepareRequest(new BudgetChapterRequest());
            request.Action = PersistType.Delete;
            request.BudgetChapterId = budgetChapterId;

            var response = BudgetChapterClient.SetBudgetChapters(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RowsAffected;
        }

        #endregion

        #region BudgetCategory

        /// <summary>
        /// Gets the budget categories.
        /// </summary>
        /// <returns>
        /// IList{BudgetCategoryModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<BudgetCategoryModel> GetBudgetCategories()
        {
            var request = PrepareRequest(new BudgetCategoryRequest());
            request.LoadOptions = new[] { "BudgetCategories" };

            var response = BudgetCategoryClient.GetBudgetCategories(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.BudgetCategories);
        }

        /// <summary>
        /// Gets the budget categories for combo tree.
        /// </summary>
        /// <param name="budgetCategoryId">The budget category identifier.</param>
        /// <returns>
        /// IList{BudgetCategoryModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<BudgetCategoryModel> GetBudgetCategoriesForComboTree(int budgetCategoryId)
        {
            var request = PrepareRequest(new BudgetCategoryRequest());
            request.LoadOptions = new[] { "BudgetCategories", "IsActive", "ForComboTree" };
            request.BudgetCategoryId = budgetCategoryId;

            var response = BudgetCategoryClient.GetBudgetCategories(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.BudgetCategories);
        }

        /// <summary>
        /// Gets the budget categories active.
        /// </summary>
        /// <returns>
        /// IList{BudgetCategoryModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<BudgetCategoryModel> GetBudgetCategoriesActive()
        {
            var request = PrepareRequest(new BudgetCategoryRequest());
            request.LoadOptions = new[] { "BudgetCategories", "IsActive" };

            var response = BudgetCategoryClient.GetBudgetCategories(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.BudgetCategories);
        }

        /// <summary>
        /// Gets the budget category.
        /// </summary>
        /// <param name="budgetCategoryId">The budget category identifier.</param>
        /// <returns>
        /// BudgetCategoryModel.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public BudgetCategoryModel GetBudgetCategory(int budgetCategoryId)
        {
            var request = PrepareRequest(new BudgetCategoryRequest());
            request.LoadOptions = new[] { "BudgetCategory" };
            request.BudgetCategoryId = budgetCategoryId;

            var response = BudgetCategoryClient.GetBudgetCategories(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObject(response.BudgetCategory);
        }

        /// <summary>
        /// Adds the budget category.
        /// </summary>
        /// <param name="budgetCategory">The budget category.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int AddBudgetCategory(BudgetCategoryModel budgetCategory)
        {
            var request = PrepareRequest(new BudgetCategoryRequest());
            request.Action = PersistType.Insert;
            request.BudgetCategory = Mapper.ToDataTransferObject(budgetCategory);

            var response = BudgetCategoryClient.SetBudgetCategories(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.BudgetCategoryId;
        }

        /// <summary>
        /// Updates the budget category.
        /// </summary>
        /// <param name="budgetCategory">The budget category.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int UpdateBudgetCategory(BudgetCategoryModel budgetCategory)
        {
            var request = PrepareRequest(new BudgetCategoryRequest());
            request.Action = PersistType.Update;
            request.BudgetCategory = Mapper.ToDataTransferObject(budgetCategory);

            var response = BudgetCategoryClient.SetBudgetCategories(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.BudgetCategoryId;
        }

        /// <summary>
        /// Deletes the budget category.
        /// </summary>
        /// <param name="budgetCategoryId">The budget category identifier.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int DeleteBudgetCategory(int budgetCategoryId)
        {
            var request = PrepareRequest(new BudgetCategoryRequest());
            request.Action = PersistType.Delete;
            request.BudgetCategoryId = budgetCategoryId;

            var response = BudgetCategoryClient.SetBudgetCategories(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RowsAffected;
        }

        #endregion

        #region MergerFund

        /// <summary>
        /// Gets the merger funds.
        /// </summary>
        /// <returns>
        /// IList{MergerFundModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<MergerFundModel> GetMergerFunds()
        {
            var request = PrepareRequest(new MergerFundRequest());
            request.LoadOptions = new[] { "MergerFunds" };

            var response = MergerFundClient.GetMergerFunds(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.MergerFunds);
        }

        /// <summary>
        /// Gets the merger funds for combo tree.
        /// </summary>
        /// <param name="mergerFundId">The merger fund identifier.</param>
        /// <returns>
        /// IList{MergerFundModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<MergerFundModel> GetMergerFundsForComboTree(int mergerFundId)
        {
            var request = PrepareRequest(new MergerFundRequest());
            request.LoadOptions = new[] { "MergerFunds", "IsActive", "ForComboTree" };
            request.MergerFundId = mergerFundId;

            var response = MergerFundClient.GetMergerFunds(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.MergerFunds);
        }

        /// <summary>
        /// Gets the merger funds active.
        /// </summary>
        /// <returns>
        /// IList{MergerFundModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<MergerFundModel> GetMergerFundsActive()
        {
            var request = PrepareRequest(new MergerFundRequest());
            request.LoadOptions = new[] { "MergerFunds", "IsActive" };

            var response = MergerFundClient.GetMergerFunds(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.MergerFunds);
        }

        /// <summary>
        /// Gets the merger fund.
        /// </summary>
        /// <param name="mergerFundId">The merger fund identifier.</param>
        /// <returns>
        /// MergerFundModel.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public MergerFundModel GetMergerFund(int mergerFundId)
        {
            var request = PrepareRequest(new MergerFundRequest());
            request.LoadOptions = new[] { "MergerFund" };
            request.MergerFundId = mergerFundId;

            var response = MergerFundClient.GetMergerFunds(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObject(response.MergerFund);
        }

        /// <summary>
        /// Adds the merger fund.
        /// </summary>
        /// <param name="mergerFund">The merger fund.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int AddMergerFund(MergerFundModel mergerFund)
        {
            var request = PrepareRequest(new MergerFundRequest());
            request.Action = PersistType.Insert;
            request.MergerFund = Mapper.ToDataTransferObject(mergerFund);

            var response = MergerFundClient.SetMergerFunds(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.MergerFundId;
        }

        /// <summary>
        /// Updates the merger fund.
        /// </summary>
        /// <param name="mergerFund">The merger fund.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int UpdateMergerFund(MergerFundModel mergerFund)
        {
            var request = PrepareRequest(new MergerFundRequest());
            request.Action = PersistType.Update;
            request.MergerFund = Mapper.ToDataTransferObject(mergerFund);

            var response = MergerFundClient.SetMergerFunds(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.MergerFundId;
        }

        /// <summary>
        /// Deletes the merger fund.
        /// </summary>
        /// <param name="mergerFundId">The merger fund identifier.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int DeleteMergerFund(int mergerFundId)
        {
            var request = PrepareRequest(new MergerFundRequest());
            request.Action = PersistType.Delete;
            request.MergerFundId = mergerFundId;

            var response = MergerFundClient.SetMergerFunds(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RowsAffected;
        }

        #endregion

        #region Account

        /// <summary>
        /// Gets the accounts.
        /// </summary>
        /// <returns>
        /// IList{AccountModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<AccountModel> GetAccounts()
        {
            var request = PrepareRequest(new AccountRequest());
            request.LoadOptions = new[] { "Accounts" };

            var response = AccountClient.GetAccounts(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.Accounts);
        }

        /// <summary>
        /// Gets the accounts.
        /// </summary>
        /// <param name="isDetail">if set to <c>true</c> [is detail].</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<AccountModel> GetAccounts(bool isDetail)
        {
            var request = PrepareRequest(new AccountRequest());
            request.LoadOptions = new[] { "Accounts", "IsDetail" };
            request.IsDetail = isDetail;

            var response = AccountClient.GetAccounts(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.Accounts);
        }

        /// <summary>
        /// Gets the accounts for combo tree.
        /// </summary>
        /// <param name="accountId">The account identifier.</param>
        /// <returns>
        /// IList{AccountModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<AccountModel> GetAccountsForComboTree(int accountId)
        {
            var request = PrepareRequest(new AccountRequest());
            request.LoadOptions = new[] { "Accounts", "IsActive", "ForComboTree" };
            request.AccountId = accountId;

            var response = AccountClient.GetAccounts(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.Accounts);
        }

        /// <summary>
        /// Gets the accounts active.
        /// </summary>
        /// <returns>
        /// IList{AccountModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<AccountModel> GetAccountsActive()
        {
            var request = PrepareRequest(new AccountRequest());
            request.LoadOptions = new[] { "Accounts", "IsActive" };

            var response = AccountClient.GetAccounts(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.Accounts);
        }

        /// <summary>
        /// Gets the account.
        /// </summary>
        /// <param name="accountId">The account identifier.</param>
        /// <returns>
        /// AccountModel.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public AccountModel GetAccount(int accountId)
        {
            var request = PrepareRequest(new AccountRequest());
            request.LoadOptions = new[] { "Account" };
            request.AccountId = accountId;

            var response = AccountClient.GetAccounts(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObject(response.Account);
        }

        /// <summary>
        /// Gets the account.
        /// </summary>
        /// <param name="accountCode">The account code.</param>
        /// <returns>
        /// AccountModel.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public AccountModel GetAccountByCode(string accountCode)
        {
            var request = PrepareRequest(new AccountRequest());
            request.LoadOptions = new[] { "AccountCode" };
            request.AccountCode = accountCode;

            var response = AccountClient.GetAccounts(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObject(response.Account);
        }

        /// <summary>
        /// Gets the accounts inventory item.
        /// </summary>
        /// <returns>
        /// IList{AccountModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<AccountModel> GetAccountsInventoryItem()
        {
            var request = PrepareRequest(new AccountRequest());
            request.LoadOptions = new[] { "InventoryItem" };
            var response = AccountClient.GetAccounts(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.Accounts);

        }

        /// <summary>
        /// Adds the account.
        /// </summary>
        /// <param name="account">The account.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int AddAccount(AccountModel account)
        {
            var request = PrepareRequest(new AccountRequest());
            request.Action = PersistType.Insert;
            request.Account = Mapper.ToDataTransferObject(account);

            var response = AccountClient.SetAccounts(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.AccountId;
        }

        /// <summary>
        /// Updates the account.
        /// </summary>
        /// <param name="account">The account.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int UpdateAccount(AccountModel account)
        {
            var request = PrepareRequest(new AccountRequest());
            request.Action = PersistType.Update;
            request.Account = Mapper.ToDataTransferObject(account);

            var response = AccountClient.SetAccounts(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.AccountId;
        }

        /// <summary>
        /// Deletes the account.
        /// </summary>
        /// <param name="accountId">The account identifier.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int DeleteAccount(int accountId)
        {
            var request = PrepareRequest(new AccountRequest());
            request.Action = PersistType.Delete;
            request.AccountId = accountId;

            var response = AccountClient.SetAccounts(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RowsAffected;
        }

        #endregion

        #region AccountCategory

        /// <summary>
        /// Gets the account categories.
        /// </summary>
        /// <returns>
        /// IList{AccountCategoryModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<AccountCategoryModel> GetAccountCategories()
        {
            var request = PrepareRequest(new AccountCategoryRequest());
            request.LoadOptions = new[] { "AccountCategories" };

            var response = AccountCategoryClient.GetAccountCategories(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.AccountCategories);
        }

        /// <summary>
        /// Gets the account categories for combo tree.
        /// </summary>
        /// <param name="accountCategoryId">The account category identifier.</param>
        /// <returns>
        /// IList{AccountCategoryModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<AccountCategoryModel> GetAccountCategoriesForComboTree(int accountCategoryId)
        {
            var request = PrepareRequest(new AccountCategoryRequest());
            request.LoadOptions = new[] { "AccountCategories", "IsActive", "ForComboTree" };
            request.AccountCategoryId = accountCategoryId;

            var response = AccountCategoryClient.GetAccountCategories(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.AccountCategories);
        }

        /// <summary>
        /// Gets the account categories active.
        /// </summary>
        /// <returns>
        /// IList{AccountCategoryModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<AccountCategoryModel> GetAccountCategoriesActive()
        {
            var request = PrepareRequest(new AccountCategoryRequest());
            request.LoadOptions = new[] { "AccountCategories", "IsActive" };

            var response = AccountCategoryClient.GetAccountCategories(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.AccountCategories);
        }

        /// <summary>
        /// Gets the account category.
        /// </summary>
        /// <param name="accountCategoryId">The account category identifier.</param>
        /// <returns>
        /// AccountCategoryModel.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public AccountCategoryModel GetAccountCategory(int accountCategoryId)
        {
            var request = PrepareRequest(new AccountCategoryRequest());
            request.LoadOptions = new[] { "AccountCategory" };
            request.AccountCategoryId = accountCategoryId;

            var response = AccountCategoryClient.GetAccountCategories(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObject(response.AccountCategory);
        }

        /// <summary>
        /// Adds the account category.
        /// </summary>
        /// <param name="accountCategory">The account category.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int AddAccountCategory(AccountCategoryModel accountCategory)
        {
            var request = PrepareRequest(new AccountCategoryRequest());
            request.Action = PersistType.Insert;
            request.AccountCategory = Mapper.ToDataTransferObject(accountCategory);

            var response = AccountCategoryClient.SetAccountCategories(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.AccountCategoryId;
        }

        /// <summary>
        /// Updates the account category.
        /// </summary>
        /// <param name="accountCategory">The account category.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int UpdateAccountCategory(AccountCategoryModel accountCategory)
        {
            var request = PrepareRequest(new AccountCategoryRequest());
            request.Action = PersistType.Update;
            request.AccountCategory = Mapper.ToDataTransferObject(accountCategory);

            var response = AccountCategoryClient.SetAccountCategories(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.AccountCategoryId;
        }

        /// <summary>
        /// Deletes the account category.
        /// </summary>
        /// <param name="accountCategoryId">The account category identifier.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int DeleteAccountCategory(int accountCategoryId)
        {
            var request = PrepareRequest(new AccountCategoryRequest());
            request.Action = PersistType.Delete;
            request.AccountCategoryId = accountCategoryId;

            var response = AccountCategoryClient.SetAccountCategories(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RowsAffected;
        }




        #endregion

        #region AutoNumber

        /// <summary>
        /// Gets the type of the automatic number by reference.
        /// </summary>
        /// <param name="refType">Type of the reference.</param>
        /// <returns></returns>
        public AutoNumberModel GetAutoNumberByRefType(int refType)
        {
            var request = PrepareRequest(new AutoNumberRequest());
            request.LoadOptions = new[] { "AutoNumber", "RefType" };
            request.RefTypeId = refType;

            var response = AutoNumberClient.GetAutoNumbers(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObject(response.AutoNumber);
        }

        /// <summary>
        /// Gets the automatic numbers.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<AutoNumberModel> GetAutoNumbers()
        {
            var request = PrepareRequest(new AutoNumberRequest());
            request.LoadOptions = new[] { "AutoNumbers" };

            var response = AutoNumberClient.GetAutoNumbers(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.AutoNumbers);
        }

        /// <summary>
        /// Updates the automatic numbers.
        /// </summary>
        /// <param name="autoNumbers">The automatic numbers.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string UpdateAutoNumbers(List<AutoNumberModel> autoNumbers)
        {
            var request = PrepareRequest(new AutoNumberRequest());
            request.Action = PersistType.Update;
            request.AutoNumbers = Mapper.ToDataTransferObjects(autoNumbers.ToList());

            var response = AutoNumberClient.SetAutoNumbers(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.Message;
        }

        #endregion

        #region Department

        /// <summary>
        /// Gets the departments.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<DepartmentModel> GetDepartments()
        {
            var request = PrepareRequest(new DepartmentRequest());
            request.LoadOptions = new[] { "Departments" };

            var response = DepartmentClient.GetDepartments(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.Departments);
        }

        /// <summary>
        /// Gets the departments active.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<DepartmentModel> GetDepartmentsActive()
        {
            var request = PrepareRequest(new DepartmentRequest());
            request.LoadOptions = new[] { "Departments", "IsActive" };

            var response = DepartmentClient.GetDepartments(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.Departments);
        }

        /// <summary>
        /// Gets the departments non active.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<DepartmentModel> GetDepartmentsNonActive()
        {
            var request = PrepareRequest(new DepartmentRequest());
            request.LoadOptions = new[] { "Departments", "NonActive" };

            var response = DepartmentClient.GetDepartments(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.Departments);
        }

        /// <summary>
        /// Gets the department.
        /// </summary>
        /// <param name="departmentId">The department identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public DepartmentModel GetDepartment(int departmentId)
        {
            var request = PrepareRequest(new DepartmentRequest());
            request.LoadOptions = new[] { "Department" };
            request.DepartmentId = departmentId;

            var response = DepartmentClient.GetDepartments(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObject(response.Department);
        }

        /// <summary>
        /// Adds the department.
        /// </summary>
        /// <param name="department">The department.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int AddDepartment(DepartmentModel department)
        {
            var request = PrepareRequest(new DepartmentRequest());
            request.Action = PersistType.Insert;
            request.Department = Mapper.ToDataTransferObject(department);

            var response = DepartmentClient.SetDepartments(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.DepartmentId;
        }

        /// <summary>
        /// Updates the department.
        /// </summary>
        /// <param name="department">The department.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int UpdateDepartment(DepartmentModel department)
        {
            var request = PrepareRequest(new DepartmentRequest());
            request.Action = PersistType.Update;
            request.Department = Mapper.ToDataTransferObject(department);

            var response = DepartmentClient.SetDepartments(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RowsAffected;
        }

        /// <summary>
        /// Deletes the department.
        /// </summary>
        /// <param name="departmentId">The department identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int DeleteDepartment(int departmentId)
        {
            var request = PrepareRequest(new DepartmentRequest());
            request.Action = PersistType.Delete;
            request.DepartmentId = departmentId;

            var response = DepartmentClient.SetDepartments(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RowsAffected;
        }

        #endregion

        #region BudgetItem
        /// <summary>
        /// Gets the budget items.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<BudgetItemModel> GetBudgetItems()
        {
            var request = PrepareRequest(new BudgetItemRequest());
            request.LoadOptions = new[] { "BudgetItems", "Item" };
            request.BudgetItemType = 3;

            var response = BudgetItemClient.GetBudgetItems(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return DictionaryMapper.FromDataTransferObjects(response.BudgetItems);
        }

        /// <summary>
        /// Gets the bud
        /// get items by group.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<BudgetItemModel> GetBudgetItemsByGroup()
        {
            var request = PrepareRequest(new BudgetItemRequest());
            request.LoadOptions = new[] { "BudgetItems", "Detail" };
            request.BudgetItemType = 1;

            var response = BudgetItemClient.GetBudgetItems(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return DictionaryMapper.FromDataTransferObjects(response.BudgetItems);
        }

        /// <summary>
        /// Gets the budget items by group item.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<BudgetItemModel> GetBudgetItemsByGroupItem()
        {
            var request = PrepareRequest(new BudgetItemRequest());
            request.LoadOptions = new[] { "BudgetItems", "Detail" };
            request.BudgetItemType = 2;

            var response = BudgetItemClient.GetBudgetItems(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return DictionaryMapper.FromDataTransferObjects(response.BudgetItems);
        }

        /// <summary>
        /// Gets the budget items by kind item.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<BudgetItemModel> GetBudgetItemsByKindItem()
        {
            var request = PrepareRequest(new BudgetItemRequest());
            request.LoadOptions = new[] { "BudgetItems", "Detail" };
            request.BudgetItemType = 3;

            var response = BudgetItemClient.GetBudgetItems(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return DictionaryMapper.FromDataTransferObjects(response.BudgetItems);
        }

        /// <summary>
        /// Gets the budget items by item.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<BudgetItemModel> GetBudgetItemsByItem()
        {
            var request = PrepareRequest(new BudgetItemRequest());
            request.LoadOptions = new[] { "BudgetItems", "Detail" };
            request.BudgetItemType = 4;

            var response = BudgetItemClient.GetBudgetItems(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return DictionaryMapper.FromDataTransferObjects(response.BudgetItems);
        }

        /// <summary>
        /// Gets the budget items by budget item receipt.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<BudgetItemModel> GetBudgetItemsByReceipt()
        {
            var request = PrepareRequest(new BudgetItemRequest());
            request.LoadOptions = new[] { "BudgetItems", "Receipt" };
            request.IsReceipt = true; //Thu

            var response = BudgetItemClient.GetBudgetItems(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return DictionaryMapper.FromDataTransferObjects(response.BudgetItems);
        }

        public IList<BudgetItemModel> GetBudgetItemsCapitalAllocate()
        {
            var request = PrepareRequest(new BudgetItemRequest());
            request.LoadOptions = new[] { "BudgetItems", "CapitalAllocate" };
            var response = BudgetItemClient.GetBudgetItems(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return DictionaryMapper.FromDataTransferObjects(response.BudgetItems);
        }

        public IList<BudgetItemModel> GetBudgetItemsPayVoucher()
        {
            var request = PrepareRequest(new BudgetItemRequest());
            request.LoadOptions = new[] { "BudgetItems", "PayVoucher" };

            var response = BudgetItemClient.GetBudgetItems(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return DictionaryMapper.FromDataTransferObjects(response.BudgetItems);
        }

        /// <summary>
        /// Gets the budget items by receipt for estimate.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<BudgetItemModel> GetBudgetItemsByReceiptForEstimate()
        {
            var request = PrepareRequest(new BudgetItemRequest());
            request.LoadOptions = new[] { "BudgetItems", "ReceiptForEstimate" };
            request.IsReceipt = true; //Thu

            var response = BudgetItemClient.GetBudgetItems(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return DictionaryMapper.FromDataTransferObjects(response.BudgetItems);
        }

        /// <summary>
        /// Gets the budget items by budget item payment.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<BudgetItemModel> GetBudgetItemsByPayment()
        {
            var request = PrepareRequest(new BudgetItemRequest());
            request.LoadOptions = new[] { "BudgetItems", "Receipt" };
            request.IsReceipt = false; //Chi

            var response = BudgetItemClient.GetBudgetItems(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return DictionaryMapper.FromDataTransferObjects(response.BudgetItems);
        }

        /// <summary>
        /// Gets the budget items by budget item payment.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<BudgetItemModel> GetBudgetItemsByPaymentForEstimate()
        {
            var request = PrepareRequest(new BudgetItemRequest());
            request.LoadOptions = new[] { "BudgetItems", "ReceiptForEstimate" };
            request.IsReceipt = false; //Chi

            var response = BudgetItemClient.GetBudgetItems(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return DictionaryMapper.FromDataTransferObjects(response.BudgetItems);
        }

        /// <summary>
        /// Gets the budget items by payment.
        /// </summary>
        /// <returns>
        /// IList{BudgetItemModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<BudgetItemModel> GetBudgetItemAndSubItem(int budgetItemType, bool isActive)
        {
            var request = PrepareRequest(new BudgetItemRequest());
            request.LoadOptions = new[] { "BudgetItems", "IsActive", "ItemAndSubItem" };
            request.IsActive = isActive;
            request.BudgetItemType = budgetItemType;

            var response = BudgetItemClient.GetBudgetItems(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return DictionaryMapper.FromDataTransferObjects(response.BudgetItems);
        }

        /// <summary>
        /// Gets the budget item.
        /// </summary>
        /// <param name="budgetItemId">The budget item identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public BudgetItemModel GetBudgetItem(int budgetItemId)
        {
            var request = PrepareRequest(new BudgetItemRequest());
            request.LoadOptions = new[] { "BudgetItem" };
            request.BudgetItemId = budgetItemId;

            var response = BudgetItemClient.GetBudgetItems(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return DictionaryMapper.FromDataTransferObject(response.BudgetItem);
        }

        /// <summary>
        /// Adds the budget item.
        /// </summary>
        /// <param name="budgetItem">The budget item.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int AddBudgetItem(BudgetItemModel budgetItem)
        {
            var request = PrepareRequest(new BudgetItemRequest());
            request.Action = PersistType.Insert;
            request.BudgetItem = DictionaryMapper.ToDataTransferObject(budgetItem);

            var response = BudgetItemClient.SetBudgetItems(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.BudgetItemId;
        }

        /// <summary>
        /// Updates the budget item.
        /// </summary>
        /// <param name="budgetItem">The budget item.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int UpdateBudgetItem(BudgetItemModel budgetItem)
        {
            var request = PrepareRequest(new BudgetItemRequest());
            request.Action = PersistType.Update;
            request.BudgetItem = DictionaryMapper.ToDataTransferObject(budgetItem);

            var response = BudgetItemClient.SetBudgetItems(request);

            if (response.Acknowledge != AcknowledgeType.Success)
            {
                if (response.Message.StartsWith("The UPDATE statement conflicted with the REFERENCE constraint"))
                    throw new ApplicationException("Mục này đã phát sinh chứng từ liên quan");
                else
                    throw new ApplicationException(response.Message);
            }

            return response.BudgetItemId;
        }

        /// <summary>
        /// Deletes the budget item.
        /// </summary>
        /// <param name="budgetItemId">The budget item identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int DeleteBudgetItem(int budgetItemId)
        {
            var request = PrepareRequest(new BudgetItemRequest());
            request.Action = PersistType.Delete;
            request.BudgetItemId = budgetItemId;

            var response = BudgetItemClient.SetBudgetItems(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RowsAffected;
        }


        #endregion

        #region FixedAssetCategory

        /// <summary>
        /// Gets the fixed asset category.
        /// </summary>
        /// <returns>
        /// IList{FixedAssetCategoryModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<FixedAssetCategoryModel> GetFixedAssetCategories()
        {
            var request = PrepareRequest(new FixedAssetCategoryRequest());
            request.LoadOptions = new[] { "FixedAssetCategorys" };

            var response = FixedAssetCategoryClient.GetFixedAssetCategories(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return DictionaryMapper.FromDataTransferObjects(response.FixedAssetCategories);
        }

        public IList<FixedAssetCategoryModel> GetFixedAssetCategoriesComboCheck()
        {
            var request = PrepareRequest(new FixedAssetCategoryRequest());
            request.LoadOptions = new[] { "FixedAssetCategorys", "ForComboCheck" };
            var response = FixedAssetCategoryClient.GetFixedAssetCategories(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return DictionaryMapper.FromDataTransferObjects(response.FixedAssetCategories);
        }

        /// <summary>
        /// Gets the fixed asset categorys for combo tree.
        /// </summary>
        /// <param name="fixedAssetCategoryId">The fixed asset category identifier.</param>
        /// <returns>
        /// IList{FixedAssetCategoryModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<FixedAssetCategoryModel> GetFixedAssetCategoriesForComboTree(int fixedAssetCategoryId)
        {
            var request = PrepareRequest(new FixedAssetCategoryRequest());
            request.LoadOptions = new[] { "FixedAssetCategorys", "IsActive", "ForComboTree" };
            request.FixedAssetCategoryId = fixedAssetCategoryId;

            var response = FixedAssetCategoryClient.GetFixedAssetCategories(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return DictionaryMapper.FromDataTransferObjects(response.FixedAssetCategories);
        }

        /// <summary>
        /// Gets the fixed asset categorys active.
        /// </summary>
        /// <returns>
        /// IList{FixedAssetCategoryModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<FixedAssetCategoryModel> GetFixedAssetCategoriesActive()
        {
            var request = PrepareRequest(new FixedAssetCategoryRequest());
            request.LoadOptions = new[] { "FixedAssetCategorys", "IsActive" };

            var response = FixedAssetCategoryClient.GetFixedAssetCategories(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return DictionaryMapper.FromDataTransferObjects(response.FixedAssetCategories);
        }

        /// <summary>
        /// Gets the fixed asset category by identifier.
        /// </summary>
        /// <param name="fixedAssetCategoryId">The fixed asset category identifier.</param>
        /// <returns>
        /// FixedAssetCategoryModel.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public FixedAssetCategoryModel GetFixedAssetCategoryById(int fixedAssetCategoryId)
        {
            var request = PrepareRequest(new FixedAssetCategoryRequest());
            request.LoadOptions = new[] { "FixedAssetCategory" };
            request.FixedAssetCategoryId = fixedAssetCategoryId;

            var response = FixedAssetCategoryClient.GetFixedAssetCategories(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return DictionaryMapper.FromDataTransferObject(response.FixedAssetCategory);
        }

        /// <summary>
        /// Adds the fixed asset category.
        /// </summary>
        /// <param name="fixedAssetCategory">The fixed asset category.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int AddFixedAssetCategory(FixedAssetCategoryModel fixedAssetCategory)
        {
            var request = PrepareRequest(new FixedAssetCategoryRequest());
            request.Action = PersistType.Insert;
            request.FixedAssetCategory = DictionaryMapper.ToDataTransferObject(fixedAssetCategory);

            var response = FixedAssetCategoryClient.SetFixedAssetCategories(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.FixedAssetCategoryId;
        }

        /// <summary>
        /// Updates the fixed asset category.
        /// </summary>
        /// <param name="fixedAssetCategory">The fixed asset category.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int UpdateFixedAssetCategory(FixedAssetCategoryModel fixedAssetCategory)
        {
            var request = PrepareRequest(new FixedAssetCategoryRequest());
            request.Action = PersistType.Update;
            request.FixedAssetCategory = DictionaryMapper.ToDataTransferObject(fixedAssetCategory);

            var response = FixedAssetCategoryClient.SetFixedAssetCategories(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.FixedAssetCategoryId;
        }

        /// <summary>
        /// Deletes the fixed asset category.
        /// </summary>
        /// <param name="fixedAssetCategoryId">The fixed asset category identifier.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int DeleteFixedAssetCategory(int fixedAssetCategoryId)
        {
            var request = PrepareRequest(new FixedAssetCategoryRequest());
            request.Action = PersistType.Delete;
            request.FixedAssetCategoryId = fixedAssetCategoryId;

            var response = FixedAssetCategoryClient.SetFixedAssetCategories(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RowsAffected;
        }

        #endregion

        #region FixedAsset

        /// <summary>
        /// Gets the fixed asset.
        /// </summary>
        /// <returns>
        /// IList{FixedAssetModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<FixedAssetModel> GetFixedAsset()
        {
            var request = PrepareRequest(new FixedAssetRequest());
            request.LoadOptions = new[] { "FixedAssets" };

            var response = FixedAssetClient.GetFixedAssets(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return DictionaryMapper.FromDataTransferObjects(response.FixedAssets);
        }

        /// <summary>
        /// Gets the fixed assets active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>
        /// IList{FixedAssetModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<FixedAssetModel> GetFixedAssetsActive(bool isActive)
        {
            var request = PrepareRequest(new FixedAssetRequest());
            request.LoadOptions = new[] { "FixedAssets", "IsActive" };
            request.IsActive = isActive;
            var response = FixedAssetClient.GetFixedAssets(request);
            if (response.Acknowledge != AcknowledgeType.Success) return null;

            return DictionaryMapper.FromDataTransferObjects(response.FixedAssets);
        }

        /// <summary>
        /// Gets the fixed assets active with fixed asset currency.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IList<FixedAssetModel> GetFixedAssetsActiveWithFixedAssetCurrency(bool isActive)
        {
            var request = PrepareRequest(new FixedAssetRequest());
            request.LoadOptions = new[] { "FixedAssets", "IsActive", "IncludingFixedAssetCurrency" };
            request.IsActive = isActive;
            var response = FixedAssetClient.GetFixedAssets(request);
            if (response.Acknowledge != AcknowledgeType.Success) return null;

            return DictionaryMapper.FromDataTransferObjects(response.FixedAssets);
        }

        /// <summary>
        /// Gets the fixed assets by code.
        /// </summary>
        /// <param name="fixedAssetCode">The fixed asset code.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public FixedAssetModel GetFixedAssetsByCode(string fixedAssetCode)
        {
            var request = PrepareRequest(new FixedAssetRequest());
            request.LoadOptions = new[] { "FixedAsset", "FixedAssetCode" };
            request.FixedAssetCode = fixedAssetCode;

            var response = FixedAssetClient.GetFixedAssets(request);
            if (response.Acknowledge != AcknowledgeType.Success) return null;

            return DictionaryMapper.FromDataTransferObject(response.FixedAsset);
        }

        /// <summary>
        /// Gets all fixed assets with store produre.
        /// </summary>
        /// <param name="storeProdure">The store produre.</param>
        /// <returns>
        /// IList{FixedAssetModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<FixedAssetModel> GetAllFixedAssetsWithStoreProdure(string storeProdure)
        {
            var request = PrepareRequest(new FixedAssetRequest());
            request.LoadOptions = new[] { "FixedAssets", "IsActive", "StoreProdure" };
            request.StoreProdure = storeProdure;
            var response = FixedAssetClient.GetFixedAssets(request);
            if (response.Acknowledge != AcknowledgeType.Success) return null;

            return DictionaryMapper.FromDataTransferObjects(response.FixedAssets);
        }

        /// <summary>
        /// Gets the fixed asset by identifier.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <returns>
        /// FixedAssetModel.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public FixedAssetModel GetFixedAssetById(int fixedAssetId)
        {
            var request = PrepareRequest(new FixedAssetRequest());
            request.LoadOptions = new[] { "FixedAsset", "IncludeFixedAssetCurrency" };
            request.FixedAssetId = fixedAssetId;

            var response = FixedAssetClient.GetFixedAssets(request);
            if (response.Acknowledge != AcknowledgeType.Success) return null;

            return DictionaryMapper.FromDataTransferObject(response.FixedAsset);
        }

        /// <summary>
        /// Gets the fixed asset by identifier.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <returns>
        /// FixedAssetModel.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public FixedAssetModel GetFixedAssetRemainingQuantity(int fixedAssetId)
        {
            var request = PrepareRequest(new FixedAssetRequest());
            request.LoadOptions = new[] { "FixedAsset", "RemainingQuantity" };
            request.FixedAssetId = fixedAssetId;

            var response = FixedAssetClient.GetFixedAssets(request);
            if (response.Acknowledge != AcknowledgeType.Success) return null;

            return DictionaryMapper.FromDataTransferObject(response.FixedAsset);
        }

        /// <summary>
        /// Gets the fixed asset by identifier.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <returns>
        /// FixedAssetModel.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public FixedAssetModel GetFixedAssetByFaIncrement(int fixedAssetId)
        {
            var request = PrepareRequest(new FixedAssetRequest());
            request.LoadOptions = new[] { "FixedAsset", "CheckFAFixedAssetIncrement" };
            request.FixedAssetId = fixedAssetId;
            var response = FixedAssetClient.GetFixedAssets(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return DictionaryMapper.FromDataTransferObject(response.FixedAsset);
        }

        public FixedAssetModel GetFixedAssetByFaDecrement(int fixedAssetId, string currencyCode, string postedDate)
        {
            var request = PrepareRequest(new FixedAssetRequest());
            request.LoadOptions = new[] { "FixedAsset", "GetFADecrement" };
            request.FixedAssetId = fixedAssetId;
            request.CurrencyCode = currencyCode;
            request.PostedDate = DateTime.Parse(postedDate);

            var response = FixedAssetClient.GetFixedAssets(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return DictionaryMapper.FromDataTransferObject(response.FixedAsset);
        }

        /// <summary>
        /// Gets the fixed asset by fa decrement.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public FixedAssetModel GetFixedAssetByFaDecrement(int fixedAssetId, int refTypeId)
        {
            var request = PrepareRequest(new FixedAssetRequest());
            request.LoadOptions = new[] { "FixedAsset", "CheckFADecrement" };
            request.FixedAssetId = fixedAssetId;
            request.RefTypeId = refTypeId;

            var response = FixedAssetClient.GetFixedAssets(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return DictionaryMapper.FromDataTransferObject(response.FixedAsset);
        }

        /// <summary>
        /// Gets the fixed asset by fa decrement.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public FixedAssetModel GetFixedAssetByFaOpening(int fixedAssetId)
        {
            var request = PrepareRequest(new FixedAssetRequest());
            request.LoadOptions = new[] { "FixedAsset", "CheckOpening" };
            request.FixedAssetId = fixedAssetId;

            var response = FixedAssetClient.GetFixedAssets(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return DictionaryMapper.FromDataTransferObject(response.FixedAsset);
        }

        /// <summary>
        /// Gets the fixed asset by fa decrement quantity.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public FixedAssetModel GetFixedAssetByFaDecrement(int fixedAssetId, string currencyCode, int refTypeId)
        {
            var request = PrepareRequest(new FixedAssetRequest());
            request.LoadOptions = new[] { "FixedAsset", "GetFADecrementQuantity" };
            request.FixedAssetId = fixedAssetId;
            request.CurrencyCode = currencyCode;
            request.RefTypeId = refTypeId;

            var response = FixedAssetClient.GetFixedAssets(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return DictionaryMapper.FromDataTransferObject(response.FixedAsset);
        }

        /// <summary>
        /// Updates the fixed asset.
        /// </summary>
        /// <param name="fixedAsset">The fixed asset.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int CheckFixedAssetIncrement(FixedAssetModel fixedAsset)
        {
            var request = PrepareRequest(new FixedAssetRequest());
            request.Action = PersistType.Update;
            request.FixedAsset = DictionaryMapper.ToDataTransferObject(fixedAsset);

            var response = FixedAssetClient.SetFixedAssets(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.FixedAssetId;
        }

        /// <summary>
        /// Adds the fixed asset.
        /// </summary>
        /// <param name="fixedAsset">The fixed asset.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int AddFixedAsset(FixedAssetModel fixedAsset)
        {
            var request = PrepareRequest(new FixedAssetRequest());
            request.Action = PersistType.Insert;
            request.FixedAsset = DictionaryMapper.ToDataTransferObject(fixedAsset);
            var response = FixedAssetClient.SetFixedAssets(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.FixedAssetId;
        }

        public int UpdateFixedAsset(FixedAssetModel fixedAsset)
        {
            var request = PrepareRequest(new FixedAssetRequest());
            request.Action = PersistType.Update;
            request.FixedAsset = DictionaryMapper.ToDataTransferObject(fixedAsset);
            var response = FixedAssetClient.SetFixedAssets(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.FixedAssetId;
        }

        /// <summary>
        /// Adds the fixed asset.
        /// </summary>
        /// <param name="fixedAsset">The fixed asset.</param>
        /// <param name="replication"></param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int AddFixedAssetReplication(FixedAssetModel fixedAsset, int replication)
        {
            var request = PrepareRequest(new FixedAssetRequest());
            request.Action = PersistType.Insert;
            request.FixedAsset = DictionaryMapper.ToDataTransferObject(fixedAsset);
            request.Replication = replication;
            var response = FixedAssetClient.SetFixedAssets(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.FixedAssetId;
        }

        /// <summary>
        /// Updates the fixed asset.
        /// </summary>
        /// <param name="fixedAsset">The fixed asset.</param>
        /// <param name="replication"></param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int UpdateFixedAssetReplication(FixedAssetModel fixedAsset, int replication)
        {
            var request = PrepareRequest(new FixedAssetRequest());
            request.Action = PersistType.Update;
            request.FixedAsset = DictionaryMapper.ToDataTransferObject(fixedAsset);
            request.Replication = replication;
            var response = FixedAssetClient.SetFixedAssets(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.FixedAssetId;
        }
        /// <summary>
        /// Deletes the fixed asset.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int DeleteFixedAsset(int fixedAssetId)
        {
            var request = PrepareRequest(new FixedAssetRequest());
            request.Action = PersistType.Delete;
            request.FixedAssetId = fixedAssetId;

            var response = FixedAssetClient.SetFixedAssets(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RowsAffected;
        }

        #endregion

        #region PayItem

        /// <summary>
        /// Gets the pay items.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<PayItemModel> GetPayItems()
        {
            var request = PrepareRequest(new PayItemRequest());
            request.LoadOptions = new[] { "PayItems" };

            var response = PayItemClient.GetPayItems(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.PayItems);
        }

        /// <summary>
        /// Gets the pay items active.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<PayItemModel> GetPayItemsActive()
        {
            var request = PrepareRequest(new PayItemRequest());
            request.LoadOptions = new[] { "PayItems", "IsActive" };

            var response = PayItemClient.GetPayItems(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.PayItems);
        }

        /// <summary>
        /// Gets the pay item.
        /// </summary>
        /// <param name="payItemId">The pay item identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public PayItemModel GetPayItem(int payItemId)
        {
            var request = PrepareRequest(new PayItemRequest());
            request.LoadOptions = new[] { "PayItem" };
            request.PayItemId = payItemId;

            var response = PayItemClient.GetPayItems(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObject(response.PayItem);
        }

        /// <summary>
        /// Adds the pay item.
        /// </summary>
        /// <param name="payItem">The pay item.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int AddPayItem(PayItemModel payItem)
        {
            var request = PrepareRequest(new PayItemRequest());
            request.Action = PersistType.Insert;
            request.PayItem = Mapper.ToDataTransferObject(payItem);

            var response = PayItemClient.SetPayItems(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.PayItemId;
        }

        /// <summary>
        /// Updates the pay item.
        /// </summary>
        /// <param name="payItem">The pay item.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int UpdatePayItem(PayItemModel payItem)
        {
            var request = PrepareRequest(new PayItemRequest());
            request.Action = PersistType.Update;
            request.PayItem = Mapper.ToDataTransferObject(payItem);

            var response = PayItemClient.SetPayItems(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RowsAffected;
        }

        /// <summary>
        /// Deletes the pay item.
        /// </summary>
        /// <param name="payItemId">The pay item identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int DeletePayItem(int payItemId)
        {
            var request = PrepareRequest(new PayItemRequest());
            request.Action = PersistType.Delete;
            request.PayItemId = payItemId;

            var response = PayItemClient.SetPayItems(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RowsAffected;
        }

        #endregion

        #region Customer

        /// <summary>
        /// Gets the customer.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns>
        /// CustomerModel.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public CustomerModel GetCustomer(int customerId)
        {
            var request = PrepareRequest(new CustomerRequest());
            request.LoadOptions = new[] { "Customer" };
            request.CustomerId = customerId;

            var response = CustomerClient.GetCustomers(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return Mapper.FromDataTransferObject(response.Customer);
        }

        /// <summary>
        /// Getses this instance.
        /// </summary>
        /// <returns>
        /// List{CustomerModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public List<CustomerModel> GetCustomers()
        {
            var request = PrepareRequest(new CustomerRequest());
            request.LoadOptions = new[] { "Customers" };
            var response = CustomerClient.GetCustomers(request);

            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return Mapper.FromDataTransferObjects(response.Customers);
        }

        /// <summary>
        /// Gets the customers by active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public List<CustomerModel> GetCustomersByActive(bool isActive)
        {
            var request = PrepareRequest(new CustomerRequest());
            request.LoadOptions = new[] { "Customers", "IsActive" };
            request.IsActive = isActive;
            var response = CustomerClient.GetCustomers(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return Mapper.FromDataTransferObjects(response.Customers);
        }

        /// <summary>
        /// Inserts the specified customer.
        /// </summary>
        /// <param name="customer">The customer.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int InsertCustomer(CustomerModel customer)
        {
            var request = PrepareRequest(new CustomerRequest());
            request.Action = PersistType.Insert;
            request.Customer = Mapper.ToDataTransferObject(customer);

            var response = CustomerClient.SetCustomers(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.CustomerId;
        }

        /// <summary>
        /// Updates the specified customer.
        /// </summary>
        /// <param name="customer">The customer.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int UpdateCustomer(CustomerModel customer)
        {
            var request = PrepareRequest(new CustomerRequest());
            request.Action = PersistType.Update;
            request.Customer = Mapper.ToDataTransferObject(customer);

            var response = CustomerClient.SetCustomers(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.CustomerId;
        }

        /// <summary>
        /// Deletes the customer.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int DeleteCustomer(int customerId)
        {
            var request = PrepareRequest(new CustomerRequest());
            request.Action = PersistType.Delete;
            request.CustomerId = customerId;

            var response = CustomerClient.SetCustomers(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RowsAffected;
        }

        #endregion

        #region Vendor

        /// <summary>
        /// Gets the vendor.
        /// </summary>
        /// <param name="vendorId">The vendor identifier.</param>
        /// <returns>
        /// VendorModel.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public VendorModel GetVendor(int vendorId)
        {
            var request = PrepareRequest(new VendorRequest());
            request.LoadOptions = new[] { "Vendor" };
            request.VendorId = vendorId;
            var response = VendorClient.GetVendors(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return Mapper.FromDataTransferObject(response.Vendor);
        }

        /// <summary>
        /// Getses this instance.
        /// </summary>
        /// <returns>
        /// List{VendorModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public List<VendorModel> GetVendors()
        {
            var request = PrepareRequest(new VendorRequest());
            request.LoadOptions = new[] { "Vendors" };
            var response = VendorClient.GetVendors(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return Mapper.FromDataTransferObjects(response.Vendors);
        }

        public List<VendorModel> GetVendorsByActive(bool isActive)
        {
            var request = PrepareRequest(new VendorRequest());
            request.LoadOptions = new[] { "Vendors", "IsActive" };
            request.IsActive = isActive;
            var response = VendorClient.GetVendors(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return Mapper.FromDataTransferObjects(response.Vendors);
        }

        /// <summary>
        /// Inserts the specified vendor.
        /// </summary>
        /// <param name="vendor">The vendor.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int InsertVendor(VendorModel vendor)
        {
            var request = PrepareRequest(new VendorRequest());
            request.Action = PersistType.Insert;
            request.Vendor = Mapper.ToDataTransferObject(vendor);
            var response = VendorClient.SetVendors(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.VendorId;
        }

        /// <summary>
        /// Updates the specified vendor.
        /// </summary>
        /// <param name="vendor">The vendor.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int UpdateVendor(VendorModel vendor)
        {
            var request = PrepareRequest(new VendorRequest());
            request.Action = PersistType.Update;
            request.Vendor = Mapper.ToDataTransferObject(vendor);

            var response = VendorClient.SetVendors(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.VendorId;
        }

        /// <summary>
        /// Deletes the specified object.
        /// </summary>
        /// <param name="vendorId">The vendor identifier.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int DeleteVendor(int vendorId)
        {
            var request = PrepareRequest(new VendorRequest());
            request.Action = PersistType.Delete;
            request.VendorId = vendorId;

            var response = VendorClient.SetVendors(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.VendorId;
        }

        #endregion

        #region AccountingObject

        public AccountingObjectModel GetAccountingObject(int accountingObjectId)
        {
            var request = PrepareRequest(new AccountingObjectRequest());
            request.LoadOptions = new[] { "AccountingObject" };
            request.AccountingObjectId = accountingObjectId;
            var response = AccountingObjectClient.GetAccountingObjects(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return DictionaryMapper.FromDataTransferObject(response.AccountingObject);
        }

        public IList<AccountingObjectModel> GetAccountingObjects()
        {
            var request = PrepareRequest(new AccountingObjectRequest());
            request.LoadOptions = new[] { "AccountingObjects" };
            var response = AccountingObjectClient.GetAccountingObjects(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return DictionaryMapper.FromDataTransferObjects(response.AccountingObjects);
        }

        public IList<AccountingObjectModel> GetAccountingObjectsForList()
        {
            var request = PrepareRequest(new AccountingObjectRequest());
            request.LoadOptions = new[] { "AccountingObjects", "ForList" };
            var response = AccountingObjectClient.GetAccountingObjects(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return DictionaryMapper.FromDataTransferObjects(response.AccountingObjects);
        }

        public IList<AccountingObjectModel> GetAccountingObjectsByActive(bool isActive)
        {
            var request = PrepareRequest(new AccountingObjectRequest());
            request.LoadOptions = new[] { "AccountingObjects", "IsActive" };
            request.IsActive = isActive;
            var response = AccountingObjectClient.GetAccountingObjects(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return DictionaryMapper.FromDataTransferObjects(response.AccountingObjects);
        }

        public int InsertAccountingObject(AccountingObjectModel accountingObject)
        {
            var request = PrepareRequest(new AccountingObjectRequest());
            request.Action = PersistType.Insert;
            request.AccountingObject = DictionaryMapper.ToDataTransferObject(accountingObject);
            var response = AccountingObjectClient.SetAccountingObjects(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.AccountingObjectId;
        }

        public int UpdateAccountingObject(AccountingObjectModel accountingObject)
        {
            var request = PrepareRequest(new AccountingObjectRequest());
            request.Action = PersistType.Update;
            request.AccountingObject = DictionaryMapper.ToDataTransferObject(accountingObject);
            var response = AccountingObjectClient.SetAccountingObjects(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.AccountingObjectId;
        }

        public int DeleteAccountingObject(int accountingObjectId)
        {
            var request = PrepareRequest(new AccountingObjectRequest());
            request.Action = PersistType.Delete;
            request.AccountingObjectId = accountingObjectId;
            var response = AccountingObjectClient.SetAccountingObjects(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.AccountingObjectId;
        }

        #endregion

        #region VoucherList

        /// <summary>
        /// Gets the voucher list.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public VoucherListModel GetVoucherList(int id)
        {
            var request = PrepareRequest(new VoucherListRequest());
            request.LoadOptions = new[] { "VoucherList" };
            request.VoucherListId = id;
            var response = VoucherListClient.GetVoucherLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return Mapper.FromDataTransferObject(response.VoucherList);
        }

        /// <summary>
        /// Gets the voucher lists.
        /// </summary>
        /// <returns>
        /// IList{VoucherListModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<VoucherListModel> GetVoucherLists()
        {
            var request = PrepareRequest(new VoucherListRequest());
            request.LoadOptions = new[] { "VoucherLists" };
            var response = VoucherListClient.GetVoucherLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return Mapper.FromDataTransferObjects(response.VoucherLists);
        }

        /// <summary>
        /// Inserts the specified voucher list.
        /// </summary>
        /// <param name="voucherList">The voucher list.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int InsertVoucherList(VoucherListModel voucherList)
        {
            var request = PrepareRequest(new VoucherListRequest());
            request.Action = PersistType.Insert;
            request.VoucherList = Mapper.ToDataTransferObject(voucherList);
            var response = VoucherListClient.SetVoucherLists(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.VoucherListId;
        }

        /// <summary>
        /// Updates the specified voucher list.
        /// </summary>
        /// <param name="voucherList">The voucher list.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int UpdateVoucherList(VoucherListModel voucherList)
        {
            var request = PrepareRequest(new VoucherListRequest());
            request.Action = PersistType.Update;
            request.VoucherList = Mapper.ToDataTransferObject(voucherList);
            var response = VoucherListClient.SetVoucherLists(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.VoucherListId;
        }

        /// <summary>
        /// Deletes the voucher list.
        /// </summary>
        /// <param name="voucherListId">The voucher list identifier.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int DeleteVoucherList(int voucherListId)
        {
            var request = PrepareRequest(new VoucherListRequest());
            request.Action = PersistType.Delete;
            request.VoucherListId = voucherListId;
            var response = VoucherListClient.SetVoucherLists(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.VoucherListId;
        }

        #endregion

        #region ReceiptVoucher

        public IList<ReceiptVoucherModel> GetReceiptVoucherByRefTypeId(int refTypeId)
        {
            var request = PrepareRequest(new CashRequest());
            request.LoadOptions = new[] { "Cashes", "RefType" };
            request.RefTypeId = refTypeId;
            var response = CashClient.GetCashes(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromReceiptDataTransferObjects(response.Cashes);
        }

        /// <summary>
        /// Gets the receipt voucher.
        /// </summary>
        /// <param name="receiptVoucherId">The receipt voucher identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public ReceiptVoucherModel GetReceiptVoucher(long receiptVoucherId)
        {
            var request = PrepareRequest(new CashRequest());
            request.LoadOptions = new[] { "Cash", "IncludeDetail" };
            request.RefId = receiptVoucherId;
            var response = CashClient.GetCashes(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return Mapper.FromReceiptDataTransferObject(response.Cash);
        }

        /// <summary>
        /// Adds the receipt voucher.
        /// </summary>
        /// <param name="receiptVoucher">The receipt voucher.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public long AddReceiptVoucher(ReceiptVoucherModel receiptVoucher, bool isAutoGenerateParallel)
        {
            var request = PrepareRequest(new CashRequest());
            request.Action = PersistType.Insert;
            request.IsConvertData = IsConvertData;
            request.isAutoGenerateParallel = isAutoGenerateParallel;
            request.CashEntity = Mapper.ToReceiptDataTransferObject(receiptVoucher);
            var response = CashClient.SetCashes(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        /// <summary>
        /// Updates the receipt voucher.
        /// </summary>
        /// <param name="receiptVoucher">The receipt voucher.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public long UpdateReceiptVoucher(ReceiptVoucherModel receiptVoucher, bool isAutoGenerateParallel)
        {
            var request = PrepareRequest(new CashRequest());
            request.Action = PersistType.Update;
            request.IsConvertData = IsConvertData;
            request.isAutoGenerateParallel = isAutoGenerateParallel;
            request.CashEntity = Mapper.ToReceiptDataTransferObject(receiptVoucher);
            var response = CashClient.SetCashes(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        /// <summary>
        /// Deletes the receipt voucher.
        /// </summary>
        /// <param name="receiptVoucherId">The receipt voucher identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public long DeleteReceiptVoucher(long receiptVoucherId)
        {
            var request = PrepareRequest(new CashRequest());
            request.Action = PersistType.Delete;
            request.RefId = receiptVoucherId;

            var response = CashClient.SetCashes(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RefId;
        }

        #endregion

        #region PaymentVoucher

        public CashModel GetPaymentVoucher(string refNo)
        {
            var request = PrepareRequest(new CashRequest());
            request.LoadOptions = new[] { "Cash", "IncludeDetail", "RefNo" };
            request.RefNo = refNo;

            var response = CashClient.GetCashes(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObject(response.Cash);
        }


        public CashModel GetCashForSalary(DateTime dateMonth)
        {
            var request = PrepareRequest(new CashRequest());
            request.LoadOptions = new[] { "Cash", "IncludeDetail", "DateMonth" };
            request.DateMonth = dateMonth;
            var response = CashClient.GetCashes(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObject(response.Cash);
        }

        /// <summary>
        /// Gets the receipt voucher by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<CashModel> GetPaymentVoucherByRefTypeId(int refTypeId)
        {
            var request = PrepareRequest(new CashRequest());
            request.LoadOptions = new[] { "Cashes", "RefType" };
            request.RefTypeId = refTypeId;

            var response = CashClient.GetCashes(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.Cashes);
        }

        /// <summary>
        /// Gets the receipt voucher.
        /// </summary>
        /// <param name="paymentVoucherId">The payment voucher identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public CashModel GetPaymentVoucher(long paymentVoucherId)
        {
            var request = PrepareRequest(new CashRequest());
            request.LoadOptions = new[] { "Cash", "IncludeDetail" };
            request.RefId = paymentVoucherId;
            var response = CashClient.GetCashes(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return Mapper.FromDataTransferObject(response.Cash);
        }

        /// <summary>
        /// Adds the receipt voucher.
        /// </summary>
        /// <param name="paymentVoucher">The payment voucher.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public long AddPaymentVoucher(CashModel paymentVoucher, bool isGennerateParalell)
        {
            var request = PrepareRequest(new CashRequest());
            request.Action = PersistType.Insert;
            request.IsConvertData = IsConvertData;
            request.CashEntity = Mapper.ToDataTransferObject(paymentVoucher);
            request.isAutoGenerateParallel = isGennerateParalell;
            var response = CashClient.SetCashes(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        /// <summary>
        /// Updates the receipt voucher.
        /// </summary>
        /// <param name="paymentVoucher">The payment voucher.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public long UpdatePaymentVoucher(CashModel paymentVoucher, bool isGennerateParalell)
        {
            var request = PrepareRequest(new CashRequest());
            request.Action = PersistType.Update;
            request.IsConvertData = IsConvertData;
            request.CashEntity = Mapper.ToDataTransferObject(paymentVoucher);
            request.isAutoGenerateParallel = isGennerateParalell;
            var response = CashClient.SetCashes(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        /// <summary>
        /// Deletes the receipt voucher.
        /// </summary>
        /// <param name="paymentVoucherId">The payment voucher identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public long DeletePaymentVoucher(long paymentVoucherId)
        {
            var request = PrepareRequest(new CashRequest());
            request.Action = PersistType.Delete;
            request.RefId = paymentVoucherId;

            var response = CashClient.SetCashes(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RefId;
        }

        #endregion

        #region Employee

        public IList<EmployeeModel> GetEmployeesByMonthDateAndRefNo(string strDate, string refNo)
        {
            var request = PrepareRequest(new EmployeeRequest());
            request.LoadOptions = new[] { "Employees", "RefNoAndMonthDate" };
            request.MonthDate = strDate;
            request.RefNo = refNo;
            var response = EmployeeClient.GetEmployees(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return Mapper.FromDataTransferObjects(response.Employees);
        }

        public IList<EmployeeModel> GetEmployeesByRefdateSalary(DateTime refdate)
        {
            var request = PrepareRequest(new EmployeeRequest());
            request.LoadOptions = new[] { "Employees", "RefdateSalary" };
            request.RefdateSalary = refdate;

            var response = EmployeeClient.GetEmployees(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.Employees);
        }




        /// <summary>
        /// Gets the employees.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<EmployeeModel> GetEmployees()
        {
            var request = PrepareRequest(new EmployeeRequest());
            request.LoadOptions = new[] { "Employees" };

            var response = EmployeeClient.GetEmployees(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.Employees);
        }

        /// <summary>
        /// Gets the employees by department identifier.
        /// </summary>
        /// <param name="departmentId">The department identifier.</param>
        /// <returns>
        /// IList{EmployeeModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<EmployeeModel> GetEmployeesByDepartmentId(int departmentId)
        {
            var request = PrepareRequest(new EmployeeRequest());
            request.LoadOptions = new[] { "Employees", "Department" };
            request.DepartmentId = departmentId;

            var response = EmployeeClient.GetEmployees(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.Employees);
        }
        /// <summary>
        /// Gets the employees by department identifier.
        /// </summary>
        /// <param name="departmentId">The department identifier.</param>
        /// <returns>
        /// IList{EmployeeModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<EmployeeModel> GetActiveEmployeesByDepartmentId(int departmentId)
        {
            var request = PrepareRequest(new EmployeeRequest());
            request.LoadOptions = new[] { "Employees", "Department", "IsActive" };
            request.DepartmentId = departmentId;

            var response = EmployeeClient.GetEmployees(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.Employees);
        }

        /// <summary>
        /// Gets the employees by department identifier.
        /// </summary>
        /// <param name="isListDepartment">if set to <c>true</c> [is list department].</param>
        /// <param name="departmentId">The department identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<EmployeeModel> GetEmployeesByDepartmentId(bool isListDepartment, string departmentId)
        {
            var request = PrepareRequest(new EmployeeRequest());
            request.LoadOptions = new[] { "Employees", "Department", "ListId" };
            request.ListDepartmentId = departmentId;

            var response = EmployeeClient.GetEmployees(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.Employees);
        }


        public IList<EmployeeModel> GetEmployeesByDepartmentIdAndMonth(bool isListDepartment, string departmentId, string strDate, int salaryOptionType, int salaryCalcType)
        {
            var request = PrepareRequest(new EmployeeRequest());
            request.LoadOptions = new[] { "Employees", "Department", "ListId", "MonthDate" };
            request.ListDepartmentId = departmentId;
            request.MonthDate = strDate;
            request.OptionType = salaryOptionType;
            request.CalceType = salaryCalcType;
            var response = EmployeeClient.GetEmployees(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return Mapper.FromDataTransferObjects(response.Employees);
        }


        public IList<EmployeeModel> GetEmployeesIsRetail(string monthDate, bool isRetail)
        {
            var request = PrepareRequest(new EmployeeRequest());
            request.LoadOptions = new[] { "Employees", "IsRetailEmployeePayroll" };
            request.MonthDate = monthDate;
            request.IsRetail = isRetail;
            var response = EmployeeClient.GetEmployees(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return Mapper.FromDataTransferObjects(response.Employees);
        }








        /// <summary>
        /// Gets the employees active.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<EmployeeModel> GetEmployeesActive()
        {
            var request = PrepareRequest(new EmployeeRequest());
            request.LoadOptions = new[] { "Employees", "IsActive" };

            var response = EmployeeClient.GetEmployees(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.Employees);
        }

        /// <summary>
        /// Gets the employee.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public EmployeeModel GetEmployee(int employeeId)
        {
            var request = PrepareRequest(new EmployeeRequest());
            request.LoadOptions = new[] { "Employee", "EmployeePayItem" };
            request.EmployeeId = employeeId;

            var response = EmployeeClient.GetEmployees(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObject(response.Employee);
        }

        public EmployeeModel GetEmployeeForEdit(int employeeId)
        {

            var request = PrepareRequest(new EmployeeRequest());
            request.LoadOptions = new[] { "Employee", "EmployeeForEditPayItem" };
            request.EmployeeId = employeeId;

            var response = EmployeeClient.GetEmployees(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObject(response.Employee);
        }

        /// <summary>
        ///  xem các khoản lương trên sinh hoạt phí
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="refDate"></param>
        /// <returns></returns>

        public EmployeeModel GetEmployeeForViewSalary(int employeeId, DateTime refDate, decimal exchangeRate)
        {
            var request = PrepareRequest(new EmployeeRequest());
            request.LoadOptions = new[] { "Employee", "ViewSalaryEmployeePayItem" };
            request.EmployeeId = employeeId;
            request.RefdateSalary = refDate;
            request.ExchangeRate = exchangeRate;

            var response = EmployeeClient.GetEmployees(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObject(response.Employee);
        }


        /// <summary>
        /// Adds the employee.
        /// </summary>
        /// <param name="employee">The employee.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int AddEmployee(EmployeeModel employee)
        {
            var request = PrepareRequest(new EmployeeRequest());
            request.Action = PersistType.Insert;
            request.Employee = Mapper.ToDataTransferObject(employee);

            var response = EmployeeClient.SetEmployees(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.EmployeeId;
        }

        /// <summary>
        /// Updates the employee.
        /// </summary>
        /// <param name="employee">The employee.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int UpdateEmployee(EmployeeModel employee)
        {
            var request = PrepareRequest(new EmployeeRequest());
            request.Action = PersistType.Update;
            request.Employee = Mapper.ToDataTransferObject(employee);

            var response = EmployeeClient.SetEmployees(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.EmployeeId;
        }

        /// <summary>
        /// Deletes the employee.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int DeleteEmployee(int employeeId)
        {
            var request = PrepareRequest(new EmployeeRequest());
            request.Action = PersistType.Delete;
            request.EmployeeId = employeeId;

            var response = EmployeeClient.SetEmployees(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RowsAffected;
        }

        #endregion

        #region Currency

        /// <summary>
        /// Gets the GetCurrenciesIsMain. 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<CurrencyModel> GetCurrenciesIsMain()
        {
            var request = PrepareRequest(new CurrencyRequest());
            request.LoadOptions = new[] { "Currencies", "CurrenciesIsMain" };

            var response = CurrencyClient.GetCurrencies(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.Currencies);
        }

        /// <summary>
        /// Gets the currencys.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<CurrencyModel> GetCurrencies()
        {
            var request = PrepareRequest(new CurrencyRequest());
            request.LoadOptions = new[] { "Currencies" };

            var response = CurrencyClient.GetCurrencies(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.Currencies);
        }

        /// <summary>
        /// Gets the currencys active.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IList<CurrencyModel> GetCurrenciesActive()
        {
            var request = PrepareRequest(new CurrencyRequest());
            request.LoadOptions = new[] { "Currencies", "IsActive" };

            var response = CurrencyClient.GetCurrencies(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.Currencies);
        }

        /// <summary>
        /// Gets the currency.
        /// </summary>
        /// <param name="currencyId">The currency identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public CurrencyModel GetCurrency(int currencyId)
        {
            var request = PrepareRequest(new CurrencyRequest());
            request.LoadOptions = new[] { "Currency" };
            request.CurrencyId = currencyId;

            var response = CurrencyClient.GetCurrencies(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObject(response.Currency);
        }

        /// <summary>
        /// Gets the currency by currency code.
        /// </summary>
        /// <param name="currencyCode">The currency code.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public CurrencyModel GetCurrencyByCurrencyCode(string currencyCode)
        {
            var request = PrepareRequest(new CurrencyRequest());
            request.LoadOptions = new[] { "Currency", "CurrencyCode" };
            request.CurrencyCode = currencyCode;

            var response = CurrencyClient.GetCurrencies(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObject(response.Currency);
        }

        /// <summary>
        /// Adds the currency.
        /// </summary>
        /// <param name="currency">The currency.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int AddCurrency(CurrencyModel currency)
        {
            var request = PrepareRequest(new CurrencyRequest());
            request.Action = PersistType.Insert;
            request.Currency = Mapper.ToDataTransferObject(currency);

            var response = CurrencyClient.SetCurrencies(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.CurrencyId;
        }

        /// <summary>
        /// Updates the currency.
        /// </summary>
        /// <param name="currency">The currency.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int UpdateCurrency(CurrencyModel currency)
        {
            var request = PrepareRequest(new CurrencyRequest());
            request.Action = PersistType.Update;
            request.Currency = Mapper.ToDataTransferObject(currency);

            var response = CurrencyClient.SetCurrencies(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.CurrencyId;
        }

        /// <summary>
        /// Deletes the currency.
        /// </summary>
        /// <param name="currencyId">The currency identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int DeleteCurrency(int currencyId)
        {
            var request = PrepareRequest(new CurrencyRequest());
            request.Action = PersistType.Delete;
            request.CurrencyId = currencyId;

            var response = CurrencyClient.SetCurrencies(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RowsAffected;
        }

        #endregion

        #region PlanTemplateList

        /// <summary>
        /// Gets the plan template lists.
        /// </summary>
        /// <returns>IList{PlanTemplateListModel}.</returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<PlanTemplateListModel> GetPlanTemplateLists()
        {
            var request = PrepareRequest(new PlanTemplateListRequest());
            request.LoadOptions = new[] { "PlanTemplateLists" };

            var response = PlanTemplateListClient.GetPlanTemplateLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.PlanTemplateLists);
        }

        /// <summary>
        /// Gets the plan template lists by receipt.
        /// </summary>
        /// <returns>IList{PlanTemplateListModel}.</returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<PlanTemplateListModel> GetPlanTemplateListsByReceipt()
        {
            var request = PrepareRequest(new PlanTemplateListRequest());
            request.LoadOptions = new[] { "PlanTemplateLists", "IsReceipt" };
            request.IsReceipt = 0;
            var response = PlanTemplateListClient.GetPlanTemplateLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.PlanTemplateLists);
        }

        /// <summary>
        /// Gets the plan template lists by payment.
        /// </summary>
        /// <returns>IList{PlanTemplateListModel}.</returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<PlanTemplateListModel> GetPlanTemplateListsByPayment()
        {
            var request = PrepareRequest(new PlanTemplateListRequest());
            request.LoadOptions = new[] { "PlanTemplateLists", "IsPayment" };
            request.IsReceipt = 1;
            var response = PlanTemplateListClient.GetPlanTemplateLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.PlanTemplateLists);
        }

        /// <summary>
        /// Gets the plan template list.
        /// </summary>
        /// <param name="planTemplateListId">The plan template list identifier.</param>
        /// <returns>PlanTemplateListModel.</returns>
        /// <exception cref="System.ApplicationException"></exception>
        public PlanTemplateListModel GetPlanTemplateList(int planTemplateListId)
        {
            var request = PrepareRequest(new PlanTemplateListRequest());
            request.LoadOptions = new[] { "PlanTemplateList", "PlanTemplateItems" };
            request.PlanTemplateListId = planTemplateListId;

            var response = PlanTemplateListClient.GetPlanTemplateLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObject(response.PlanTemplateList);
        }

        /// <summary>
        /// LinhMC add
        /// Checks the constraint plan template list.
        /// </summary>
        /// <param name="planTemplateListId">The plan template list identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public bool CheckConstraintPlanTemplateList(int planTemplateListId)
        {
            var request = PrepareRequest(new PlanTemplateListRequest());
            request.LoadOptions = new[] { "PlanTemplateList", "Constraint" };
            request.PlanTemplateListId = planTemplateListId;

            var response = PlanTemplateListClient.GetPlanTemplateLists(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.PlanTemplateListId > 0;
        }

        /// <summary>
        /// Adds the plan template list.
        /// </summary>
        /// <param name="planTemplateList">The plan template list.</param>
        /// <returns>System.Int32.</returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int AddPlanTemplateList(PlanTemplateListModel planTemplateList)
        {
            var request = PrepareRequest(new PlanTemplateListRequest());
            request.Action = PersistType.Insert;
            request.PlanTemplateList = Mapper.ToDataTransferObject(planTemplateList);

            var response = PlanTemplateListClient.SetPlanTemplateLists(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.PlanTemplateListId;
        }

        /// <summary>
        /// Updates the plan template list.
        /// </summary>
        /// <param name="planTemplateList">The plan template list.</param>
        /// <returns>System.Int32.</returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int UpdatePlanTemplateList(PlanTemplateListModel planTemplateList)
        {
            var request = PrepareRequest(new PlanTemplateListRequest());
            request.Action = PersistType.Update;
            request.PlanTemplateList = Mapper.ToDataTransferObject(planTemplateList);

            var response = PlanTemplateListClient.SetPlanTemplateLists(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.PlanTemplateListId;
        }

        /// <summary>
        /// Deletes the plan template list.
        /// </summary>
        /// <param name="planTemplateListId">The plan template list identifier.</param>
        /// <returns>System.Int32.</returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int DeletePlanTemplateList(int planTemplateListId)
        {
            var request = PrepareRequest(new PlanTemplateListRequest());
            request.Action = PersistType.Delete;
            request.PlanTemplateListId = planTemplateListId;

            var response = PlanTemplateListClient.SetPlanTemplateLists(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RowsAffected;
        }

        #endregion

        #region CapitalAllocate


        /// <summary>
        /// Gets the capitalAllocates.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<CapitalAllocateModel> GetCapitalAllocates()
        {
            var request = PrepareRequest(new CapitalAllocateRequest());
            request.LoadOptions = new[] { "CapitalAllocates" };

            var response = CapitalAllocateClient.GetCapitalAllocates(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.CapitalAllocates);
        }

        /// <summary>
        /// Gets the capitalAllocates active.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IList<CapitalAllocateModel> GetCapitalAllocatesActive()
        {
            var request = PrepareRequest(new CapitalAllocateRequest());
            request.LoadOptions = new[] { "CapitalAllocates", "IsActive" };

            var response = CapitalAllocateClient.GetCapitalAllocates(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.CapitalAllocates);
        }

        /// <summary>
        /// Gets the capitalAllocate.
        /// </summary>
        /// <param name="capitalAllocateId">The capitalAllocate identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public CapitalAllocateModel GetCapitalAllocate(int capitalAllocateId)
        {
            var request = PrepareRequest(new CapitalAllocateRequest());
            request.LoadOptions = new[] { "CapitalAllocate" };
            request.CapitalAllocateId = capitalAllocateId;

            var response = CapitalAllocateClient.GetCapitalAllocates(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObject(response.CapitalAllocate);
        }

        /// <summary>
        /// Adds the capitalAllocate.
        /// </summary>
        /// <param name="capitalAllocate">The capitalAllocate.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int AddCapitalAllocate(CapitalAllocateModel capitalAllocate)
        {
            var request = PrepareRequest(new CapitalAllocateRequest());
            request.Action = PersistType.Insert;
            request.CapitalAllocate = Mapper.ToDataTransferObject(capitalAllocate);

            var response = CapitalAllocateClient.SetCapitalAllocates(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.CapitalAllocateId;
        }

        /// <summary>
        /// Updates the capitalAllocate.
        /// </summary>
        /// <param name="capitalAllocate">The capitalAllocate.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int UpdateCapitalAllocate(CapitalAllocateModel capitalAllocate)
        {
            var request = PrepareRequest(new CapitalAllocateRequest());
            request.Action = PersistType.Update;
            request.CapitalAllocate = Mapper.ToDataTransferObject(capitalAllocate);

            var response = CapitalAllocateClient.SetCapitalAllocates(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.CapitalAllocateId;
        }

        /// <summary>
        /// Deletes the capitalAllocate.
        /// </summary>
        /// <param name="capitalAllocateId">The capitalAllocate identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int DeleteCapitalAllocate(int capitalAllocateId)
        {
            var request = PrepareRequest(new CapitalAllocateRequest());
            request.Action = PersistType.Delete;
            request.CapitalAllocateId = capitalAllocateId;

            var response = CapitalAllocateClient.SetCapitalAllocates(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RowsAffected;
        }

        #endregion

        #region PlanTemplateItems

        /// <summary>
        /// Gets the plan template items.
        /// </summary>
        /// <returns>IList{PlanTemplateItemModel}.</returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<PlanTemplateItemModel> GetPlanTemplateItems()
        {
            var request = PrepareRequest(new PlanTemplateItemRequest());
            request.LoadOptions = new[] { "PlanTemplateItems" };

            var response = PlanTemplateItemClient.GetPlanTemplateItems(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.PlanTemplateItems);
        }

        /// <summary>
        /// Gets the plan template items.
        /// </summary>
        /// <returns>IList{PlanTemplateItemModel}.</returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<PlanTemplateItemModel> GetPlanTemplateItemsByPlanTemplateListId(int planTemplateListId)
        {
            var request = PrepareRequest(new PlanTemplateItemRequest());
            request.LoadOptions = new[] { "PlanTemplateItems", "PlanTemplateListId" };
            request.PlanTemplateListId = planTemplateListId;
            var response = PlanTemplateItemClient.GetPlanTemplateItems(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.PlanTemplateItems);
        }

        /// <summary>
        /// Gets the plan template items.
        /// </summary>
        /// <returns>IList{PlanTemplateItemModel}.</returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<PlanTemplateItemModel> GetPlanTemplateItemsForEstimate(int planTemplateListId, short planYear, int budgetSourceCategoryId)
        {
            var request = PrepareRequest(new PlanTemplateItemRequest());
            request.LoadOptions = new[] { "PlanTemplateItems", "Estimate" };
            request.PlanTemplateListId = planTemplateListId;
            request.PlanYear = planYear;
            request.BudgetSourceCategoryId = budgetSourceCategoryId;

            var response = PlanTemplateItemClient.GetPlanTemplateItems(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.PlanTemplateItems);
        }

        #endregion

        #region Stock

        /// <summary>
        /// Gets the specified stock identifier.
        /// </summary>
        /// <param name="stockId">The stock identifier.</param>
        /// <returns>
        /// StockModel.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public StockModel GetStock(int stockId)
        {

            var request = PrepareRequest(new StockRequest());
            request.LoadOptions = new[] { "Stock" };
            request.StockId = stockId;
            var response = StockClient.Gets(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return Mapper.FromDataTransferObject(response.Stock);
        }

        /// <summary>
        /// Getses this instance.
        /// </summary>
        /// <returns>
        /// IList{StockModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<StockModel> GetStocks()
        {
            var request = PrepareRequest(new StockRequest());
            request.LoadOptions = new[] { "Stocks" };

            var response = StockClient.Gets(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return Mapper.FromDataTransferObjects(response.Stocks);
        }

        /// <summary>
        /// Gets the stock by actives.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>
        /// IList{StockModel}.
        /// </returns>
        public IList<StockModel> GetStockByActives(bool isActive)
        {
            var request = PrepareRequest(new StockRequest());
            request.LoadOptions = new[] { "Stocks", "IsActive" };

            var response = StockClient.Gets(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return Mapper.FromDataTransferObjects(response.Stocks);
        }

        /// <summary>
        /// Inserts the specified stock.
        /// </summary>
        /// <param name="stock">The stock.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int InsertStock(StockModel stock)
        {
            var request = PrepareRequest(new StockRequest());
            request.Action = PersistType.Insert;
            request.Stock = Mapper.ToDataTransferObject(stock);

            var response = StockClient.Sets(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.StockId;

        }

        /// <summary>
        /// Updates the specified stock.
        /// </summary>
        /// <param name="stock">The stock.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int UpdateStock(StockModel stock)
        {

            var request = PrepareRequest(new StockRequest());
            request.Action = PersistType.Update;
            request.Stock = Mapper.ToDataTransferObject(stock);
            var response = StockClient.Sets(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.StockId;


        }

        /// <summary>
        /// Deletes the stock.
        /// </summary>
        /// <param name="stockId">The stock identifier.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int DeleteStock(int stockId)
        {
            var request = PrepareRequest(new StockRequest());
            request.Action = PersistType.Delete;
            request.StockId = stockId;

            var response = StockClient.Sets(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RowsAffected;
        }

        #endregion

        #region InventoryItem

        /// <summary>
        /// Gets the inventory item.
        /// </summary>
        /// <param name="inventoryItemId">The inventory item identifier.</param>
        /// <returns>
        /// InventoryItemModel.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public InventoryItemModel GetInventoryItem(int inventoryItemId)
        {
            var request = PrepareRequest(new InventoryItemRequest());
            request.LoadOptions = new[] { "InventoryItem" };
            request.InventoryItemId = inventoryItemId;

            var response = InventoryItemClient.GetInventoryItems(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return DictionaryMapper.FromDataTransferObject(response.InventoryItem);
        }

        /// <summary>
        /// Gets the inventory items.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<InventoryItemModel> GetInventoryItems()
        {
            var request = PrepareRequest(new InventoryItemRequest());
            request.LoadOptions = new[] { "InventoryItems" };

            var response = InventoryItemClient.GetInventoryItems(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return DictionaryMapper.FromDataTransferObjects(response.InventoryItems);
        }
        //public IList<InventoryItemModel> GetInventoryItemsByStock(int itemStock)
        //{
        //    throw new NotImplementedException();
        //}
        /// <summary>
        /// Gets the inventory items by stock.
        /// BangNC
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<InventoryItemModel> GetInventoryItemsByStock(int itemStockId)
        {
            var request = PrepareRequest(new InventoryItemRequest());
            request.LoadOptions = new[] { "ItemStockInput" };
            request.ItemStockId = itemStockId;
            var response = InventoryItemClient.GetInventoryItems(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return DictionaryMapper.FromDataTransferObjects(response.InventoryItems);
        }
        /// <summary>
        /// Gets the inventory items by stock.
        /// BangNC
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<InventoryItemModel> GetInventoryItemsByStock(int itemStockId, long refId, DateTime postDate, string currencyCode)
        {
            var request = PrepareRequest(new InventoryItemRequest());
            request.LoadOptions = new[] { "ItemStock" };
            request.ItemStockId = itemStockId;
            request.RefId = refId;
            request.PostDate = postDate;
            request.CurrencyCode = currencyCode;
            var response = InventoryItemClient.GetInventoryItems(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return DictionaryMapper.FromDataTransferObjects(response.InventoryItems);
        }

        /// <summary>
        /// Gets the inventory items by is stock and is active and category code.
        /// </summary>
        /// <param name="isStock">if set to <c>true</c> [is stock].</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <param name="inventoryCategoryCode">The inventory category code.</param>
        /// <returns></returns>
        public IList<InventoryItemModel> GetInventoryItemsByIsStockAndIsActiveAndCategoryCode(bool isStock,
            bool isActive, string inventoryCategoryCode)
        {
            var inventoryItems =
                InventoryItemClient.GetInventoryItemsByIsStockAndIsActiveAndCategoryCode(isStock, isActive,
                    inventoryCategoryCode);
            return Mapper.FromDataTransferObjects(inventoryItems);
        }

        /// <summary>
        /// Inserts the specified inventory item.
        /// </summary>
        /// <param name="inventoryItem">The inventory item.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int InsertInventoryItem(InventoryItemModel inventoryItem)
        {
            var request = PrepareRequest(new InventoryItemRequest());
            request.Action = PersistType.Insert;
            request.InventoryItem = DictionaryMapper.ToDataTransferObject(inventoryItem);

            var response = InventoryItemClient.SetInventoryItems(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.InventoryItemId;
        }

        /// <summary>
        /// Updates the specified inventory item.
        /// </summary>
        /// <param name="inventoryItem">The inventory item.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int UpdateInventoryItem(InventoryItemModel inventoryItem)
        {
            var request = PrepareRequest(new InventoryItemRequest());
            request.Action = PersistType.Update;
            request.InventoryItem = DictionaryMapper.ToDataTransferObject(inventoryItem);
            request.LoadOptions = new[] { "" };
            var response = InventoryItemClient.SetInventoryItems(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.InventoryItemId;
        }

        /// <summary>
        /// Deletes the specified inventory item identifier.
        /// </summary>
        /// <param name="inventoryItemId">The inventory item identifier.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int Delete(int inventoryItemId)
        {
            var request = PrepareRequest(new InventoryItemRequest());
            request.Action = PersistType.Delete;
            request.InventoryItemId = inventoryItemId;
            var response = InventoryItemClient.SetInventoryItems(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RowsAffected;
        }

        /// <summary>
        ///     Gets the bu plan receipt.
        /// </summary>
        /// <returns>List&lt;OpeningSupplyEntryModel&gt;.</returns>
        public IList<OpeningSupplyEntryModel> GetOpeningSupplyEntry()
        {
            var openningEntry = OpeningSupplyEntryClient.GetOpeningSupplyEntry();
            return Mapper.FromDataTransferObjects(openningEntry);
        }

        public OpeningSupplyEntryModel GetOpeningSupplyEntryVoucher(long refId, bool isIncludedDetail)
        {
            var bUCommitmentRequest =
                OpeningSupplyEntryClient.GetOpeningSupplyEntryVoucherByRefId(refId, isIncludedDetail);
            return Mapper.FromDataTransferObject(bUCommitmentRequest);
        }

        public string UpdateOpeningSupplyEntry(IList<OpeningSupplyEntryModel> openingCommitment)
        {
            var openingCommitmentEntity = Mapper.ToDataTransferObjects(openingCommitment);

            var response = OpeningSupplyEntryClient.UpdateOpeningSupplyEntry(openingCommitmentEntity);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.Message;
        }

        /// <summary>
        ///     Deletes the bu plan receipt.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string DeleteOpeningSupplyEntry(long refId)
        {
            var response = OpeningSupplyEntryClient.DeleteOpeningSupplyEntry(refId);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.Message;
        }

        #endregion


        #region AccountTranfer

        /// <summary>
        /// Gets the account tranfers.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<AccountTranferModel> GetAccountTranfers()
        {
            var request = PrepareRequest(new AccountTranferRequest());
            request.LoadOptions = new[] { "AccountTranfers" };

            var response = AccountTranferClient.GetAccountTranfers(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return DictionaryMapper.FromDataTransferObjects(response.AccountTranfers);
        }

        /// <summary>
        /// Gets the account tranfers active.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<AccountTranferModel> GetAccountTranfersActive()
        {
            var request = PrepareRequest(new AccountTranferRequest());
            request.LoadOptions = new[] { "AccountTranfers", "IsActive" };

            var response = AccountTranferClient.GetAccountTranfers(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return DictionaryMapper.FromDataTransferObjects(response.AccountTranfers);
        }

        /// <summary>
        /// Gets the account tranfers non active.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<AccountTranferModel> GetAccountTranfersNonActive()
        {
            var request = PrepareRequest(new AccountTranferRequest());
            request.LoadOptions = new[] { "AccountTranfers", "NonActive" };

            var response = AccountTranferClient.GetAccountTranfers(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return DictionaryMapper.FromDataTransferObjects(response.AccountTranfers);
        }

        /// <summary>
        /// Gets the account tranfer.
        /// </summary>
        /// <param name="accountTranferId">The account tranfer identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public AccountTranferModel GetAccountTranfer(int accountTranferId)
        {
            var request = PrepareRequest(new AccountTranferRequest());
            request.LoadOptions = new[] { "AccountTranfer" };
            request.AccountTranferId = accountTranferId;

            var response = AccountTranferClient.GetAccountTranfers(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return DictionaryMapper.FromDataTransferObject(response.AccountTranfer);
        }

        /// <summary>
        /// Adds the account tranfer.
        /// </summary>
        /// <param name="accountTranfer">The account tranfer.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int AddAccountTranfer(AccountTranferModel accountTranfer)
        {
            var request = PrepareRequest(new AccountTranferRequest());
            request.Action = PersistType.Insert;
            request.AccountTranfer = DictionaryMapper.ToDataTransferObject(accountTranfer);

            var response = AccountTranferClient.SetAccountTranfers(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.AccountTranferId;
        }

        /// <summary>
        /// Updates the account tranfer.
        /// </summary>
        /// <param name="accountTranfer">The account tranfer.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int UpdateAccountTranfer(AccountTranferModel accountTranfer)
        {
            var request = PrepareRequest(new AccountTranferRequest());
            request.Action = PersistType.Update;
            request.AccountTranfer = DictionaryMapper.ToDataTransferObject(accountTranfer);

            var response = AccountTranferClient.SetAccountTranfers(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RowsAffected;
        }

        /// <summary>
        /// Deletes the account tranfer.
        /// </summary>
        /// <param name="accountTranferId">The account tranfer identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int DeleteAccountTranfer(int accountTranferId)
        {
            var request = PrepareRequest(new AccountTranferRequest());
            request.Action = PersistType.Delete;
            request.AccountTranferId = accountTranferId;

            var response = AccountTranferClient.SetAccountTranfers(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RowsAffected;
        }

        #endregion

        #region DBOption

        /// <summary>
        /// Gets the database option.
        /// </summary>
        /// <param name="optionId">The option identifier.</param>
        /// <returns></returns>
        public DBOptionModel GetDBOption(string optionId)
        {
            var request = PrepareRequest(new DBOptionRequest());
            request.LoadOptions = new[] { "DBOption" };
            request.DBOptionId = optionId;

            var response = DBOptionClient.GetDBOptions(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObject(response.DBOption);
        }

        /// <summary>
        /// Gets the database options.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<DBOptionModel> GetDBOptions()
        {
            var request = PrepareRequest(new DBOptionRequest());
            request.LoadOptions = new[] { "DBOptions" };

            var response = DBOptionClient.GetDBOptions(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.DBOptions);
        }

        /// <summary>
        /// Gets the database options system.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<DBOptionModel> GetDBOptionsSystem()
        {
            var request = PrepareRequest(new DBOptionRequest());
            request.LoadOptions = new[] { "DBOptions", "IsSystem" };

            var response = DBOptionClient.GetDBOptions(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.DBOptions);
        }

        /// <summary>
        /// Gets the database options is string.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<DBOptionModel> GetDBOptionsIsString()
        {
            var request = PrepareRequest(new DBOptionRequest());
            request.LoadOptions = new[] { "DBOptions", "ValueType" };
            request.ValueType = 1;

            var response = DBOptionClient.GetDBOptions(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.DBOptions);
        }

        /// <summary>
        /// Gets the database options is numeric.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<DBOptionModel> GetDBOptionsIsNumeric()
        {
            var request = PrepareRequest(new DBOptionRequest());
            request.LoadOptions = new[] { "DBOptions", "ValueType" };
            request.ValueType = 0;

            var response = DBOptionClient.GetDBOptions(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.DBOptions);
        }

        /// <summary>
        /// Gets the database options is boolean.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<DBOptionModel> GetDBOptionsIsBoolean()
        {
            var request = PrepareRequest(new DBOptionRequest());
            request.LoadOptions = new[] { "DBOptions", "ValueType" };
            request.ValueType = 3;

            var response = DBOptionClient.GetDBOptions(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.DBOptions);
        }

        /// <summary>
        /// Updates the database option.
        /// </summary>
        /// <param name="isListDbOption">if set to <c>true</c> [is list database option].</param>
        /// <param name="dbOption">The database option.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string UpdateDBOption(bool isListDbOption, DBOptionModel dbOption)
        {
            var request = PrepareRequest(new DBOptionRequest());
            request.Action = PersistType.Update;
            request.DBOption = Mapper.ToDataTransferObject(dbOption);

            var response = DBOptionClient.SetDBOptions(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.Message;
        }

        /// <summary>
        /// Updates the database option.
        /// </summary>
        /// <param name="dbOptions">The database options.</param>
        /// <returns></returns>
        public string UpdateDBOption(List<DBOptionModel> dbOptions)
        {
            var request = PrepareRequest(new DBOptionRequest());
            request.Action = PersistType.Update;
            request.DBOptions = Mapper.ToDataTransferObjects(dbOptions);

            var response = DBOptionClient.SetDBOptions(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.Message;
        }

        #endregion

        #region ReportList

        /// <summary>
        /// Gets the report lists.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public List<ReportListModel> GetReportLists()
        {
            var request = PrepareRequest(new ReportListRequest());
            request.LoadOptions = new[] { "ReportLists" };

            var response = ReportListClient.GetReportLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.ReportLists);
        }

        /// <summary>
        /// Gets the report lists by report group.
        /// </summary>
        /// <param name="reportGroupId">The report group identifier.</param>
        /// <returns>
        /// List{ReportListModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public List<ReportListModel> GetReportListsByReportGroup(int reportGroupId)
        {
            var request = PrepareRequest(new ReportListRequest());
            request.LoadOptions = new[] { "ReportListsByReportGroup" };
            request.ReportGroupId = reportGroupId;

            var response = ReportListClient.GetReportLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.ReportLists);
        }

        /// <summary>
        /// Gets the report list by identifier.
        /// </summary>
        /// <param name="reportListId">The report list identifier.</param>
        /// <returns>
        /// ReportListModel.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public ReportListModel GetReportListById(string reportListId)
        {
            var request = PrepareRequest(new ReportListRequest());
            request.LoadOptions = new[] { "ReportList" };
            request.ReportListId = reportListId;

            var response = ReportListClient.GetReportLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObject(response.ReportList);
        }

        /// <summary>
        /// Gets the report groups.
        /// </summary>
        /// <returns>
        /// List{ReportGroupModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public List<ReportGroupModel> GetReportGroups()
        {
            var request = PrepareRequest(new ReportGroupRequest());
            request.LoadOptions = new[] { "ReportGroups" };

            var response = ReportGroupClient.GetReportGroups(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.ReportGroups);
        }

        /// <summary>
        /// Gets the report group by identifier.
        /// </summary>
        /// <param name="reportGroupId">The report group identifier.</param>
        /// <returns>
        /// ReportGroupModel.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public ReportGroupModel GetReportGroupById(int reportGroupId)
        {
            var request = PrepareRequest(new ReportGroupRequest());
            request.LoadOptions = new[] { "ReportGroup" };
            request.ReportGroupID = reportGroupId;

            var response = ReportGroupClient.GetReportGroups(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObject(response.ReportGroup);
        }

        #endregion

        #region AudittingLog

        /// <summary>
        /// Gets the auditting logs.
        /// </summary>
        /// <returns></returns>
        public IList<AudittingLogModel> GetAudittingLogs()
        {
            var request = PrepareRequest(new AudittingLogRequest());
            request.LoadOptions = new[] { "AudittingLogs" };

            var response = AudittingLogClient.GetAudittingLogs(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.AudittingLogs);
        }

        /// <summary>
        /// Adds the auditing log.
        /// </summary>
        /// <param name="audittingLog">The auditting log.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int AddAuditingLog(AudittingLogModel audittingLog)
        {
            var request = PrepareRequest(new AudittingLogRequest());
            request.Action = PersistType.Insert;
            request.AudittingLog = Mapper.ToDataTransferObject(audittingLog);

            var response = AudittingLogClient.SetAudittingLogs(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.EventId;
        }

        /// <summary>
        /// Deletes the audittingLog.
        /// </summary>
        /// <param name="audittingLogId">The audittingLog identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int DeleteAudittingLog(int audittingLogId)
        {
            var request = PrepareRequest(new AudittingLogRequest());
            request.Action = PersistType.Delete;
            request.EventId = audittingLogId;

            var response = AudittingLogClient.SetAudittingLogs(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RowsAffected;
        }

        #endregion

        #region Estimate

        /// <summary>
        /// Gets the receipt vouchers.
        /// </summary>
        /// <returns>
        /// IList{EstimateModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<EstimateModel> GetEstimates()
        {
            var request = PrepareRequest(new EstimateRequest());
            request.LoadOptions = new[] { "Estimates" };

            var response = EstimateClient.GetEstimates(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.Estimates);
        }

        /// <summary>
        /// Gets the estimates by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<EstimateModel> GetEstimatesByRefTypeId(int refTypeId)
        {
            var request = PrepareRequest(new EstimateRequest());
            request.LoadOptions = new[] { "Estimates", "RefType" };
            request.RefType = refTypeId;

            var response = EstimateClient.GetEstimates(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.Estimates);
        }

        /// <summary>
        /// Gets the estimates by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="refDate"></param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<EstimateModel> GetEstimatesByYearOfPostDate(int refTypeId, string refDate)
        {
            var request = PrepareRequest(new EstimateRequest());
            request.LoadOptions = new[] { "Estimates", "RefDate" };
            request.RefType = refTypeId;
            request.RefDate = refDate;

            var response = EstimateClient.GetEstimates(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.Estimates);
        }

        /// <summary>
        /// Gets the estimates by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="yearOfEstimate">The year of estimate.</param>
        /// <param name="budgetSourceCategoryId">The budget source category identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<EstimateModel> GetEstimatesByYearOfEstimate(int refTypeId, short yearOfEstimate, int budgetSourceCategoryId)
        {
            var request = PrepareRequest(new EstimateRequest());
            request.LoadOptions = new[] { "Estimates", "CheckPaymentEstimate" };
            request.RefType = refTypeId;
            request.YearOfEstimate = yearOfEstimate;
            request.BudgetSourceCategoryId = budgetSourceCategoryId;

            var response = EstimateClient.GetEstimates(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.Estimates);
        }

        public IList<EstimateModel> GetEstimatesByYearOfEstimateNoBudget(int refTypeId, short yearOfEstimate)
        {
            var request = PrepareRequest(new EstimateRequest());
            request.LoadOptions = new[] { "Estimates", "CheckPaymentEstimateNoBudget" };
            request.RefType = refTypeId;
            request.YearOfEstimate = yearOfEstimate;

            var response = EstimateClient.GetEstimates(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.Estimates);
        }

        public IList<EstimateModel> GetEstimatesByYearOfEstimate(int refTypeId, short yearOfEstimate)
        {
            var request = PrepareRequest(new EstimateRequest());
            request.LoadOptions = new[] { "Estimates", "CheckReceiptEstimate" };
            request.RefType = refTypeId;
            request.YearOfEstimate = yearOfEstimate;

            var response = EstimateClient.GetEstimates(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.Estimates);
        }

        /// <summary>
        /// Gets the receipt voucher.
        /// </summary>
        /// <param name="estimateId">The receipt voucher identifier.</param>
        /// <returns>
        /// EstimateModel.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public EstimateModel GetEstimate(long estimateId)
        {
            var request = PrepareRequest(new EstimateRequest());
            request.LoadOptions = new[] { "Estimate", "IncludeDetail" };
            request.RefId = estimateId;

            var response = EstimateClient.GetEstimates(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObject(response.Estimate);
        }


        public EstimateModel GetEstimateOption(long refId, int option, int budgetSourceCategoryId, int YearOfPlaning)
        {
            var request = PrepareRequest(new EstimateRequest());
            request.LoadOptions = new[] { "Estimate", "Option" };
            request.RefId = refId;
            request.Option = option;
            request.BudgetSourceCategoryId = budgetSourceCategoryId;
            request.YearOfPlaning = YearOfPlaning;
            var response = EstimateClient.GetEstimates(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return Mapper.FromDataTransferObject(response.Estimate);
        }

        public EstimateModel GetEstimateOption(int planTemplateListId, int yearOfPlaning)
        {
            var request = PrepareRequest(new EstimateRequest());
            request.LoadOptions = new[] { "Estimate", "PlanTemplateListId" };
            request.RefId = planTemplateListId;
            request.YearOfPlaning = yearOfPlaning - 1;
            var response = EstimateClient.GetEstimates(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return Mapper.FromDataTransferObject(response.Estimate);
        }

        /// <summary>
        /// Adds the estimate.
        /// </summary>
        /// <param name="estimate">The estimate.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public long AddEstimate(EstimateModel estimate)
        {
            var request = PrepareRequest(new EstimateRequest());
            request.Action = PersistType.Insert;
            request.Estimate = Mapper.ToDataTransferObject(estimate);

            var response = EstimateClient.SetEstimates(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RefId;
        }

        /// <summary>
        /// Updates the estimate.
        /// </summary>
        /// <param name="estimate">The estimate.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public long UpdateEstimate(EstimateModel estimate)
        {
            var request = PrepareRequest(new EstimateRequest());
            request.Action = PersistType.Update;
            request.Estimate = Mapper.ToDataTransferObject(estimate);

            var response = EstimateClient.SetEstimates(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RefId;
        }

        /// <summary>
        /// Deletes the estimate.
        /// </summary>
        /// <param name="estimateId">The estimate identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public long DeleteEstimate(long estimateId)
        {
            var request = PrepareRequest(new EstimateRequest());
            request.Action = PersistType.Delete;
            request.RefId = estimateId;

            var response = EstimateClient.SetEstimates(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RefId;
        }

        #endregion

        #region Deposit

        /// <summary>
        /// Gets the receipt vouchers.
        /// </summary>
        /// <returns>
        /// IList{DepositModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<DepositModel> GetDeposits()
        {
            var request = PrepareRequest(new DepositRequest());
            request.LoadOptions = new[] { "Deposits" };
            var response = DepositClient.GetDeposits(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return VoucherMapper.FromDataTransferObjects(response.Deposits);
        }

        public IList<DepositModel> GetDepositsByYearOfPostDate(int refTypeId, string refDate)
        {
            var request = PrepareRequest(new DepositRequest());
            request.LoadOptions = new[] { "Deposits", "RefDate" };
            request.RefDate = refDate;
            request.RefType = refTypeId;
            var response = DepositClient.GetDeposits(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return VoucherMapper.FromDataTransferObjects(response.Deposits);
        }

        public IList<DepositModel> GetDepositsByRefTypeId(int refTypeId)
        {
            var request = PrepareRequest(new DepositRequest());
            request.LoadOptions = new[] { "Deposits", "RefType" };
            request.RefType = refTypeId;

            var response = DepositClient.GetDeposits(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return VoucherMapper.FromDataTransferObjects(response.Deposits);
        }

        /// <summary>
        /// Gets the receipt voucher.
        /// </summary>
        /// <param name="depositId">The receipt voucher identifier.</param>
        /// <returns>
        /// DepositModel.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public DepositModel GetDeposit(long depositId)
        {
            var request = PrepareRequest(new DepositRequest());
            request.LoadOptions = new[] { "Deposit", "IncludeDetail" };
            request.RefId = depositId;

            var response = DepositClient.GetDeposits(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return VoucherMapper.FromDataTransferObject(response.Deposit);
        }
        public DepositModel GetDeposit(string refNo)
        {
            var request = PrepareRequest(new DepositRequest());
            request.LoadOptions = new[] { "Deposit", "IncludeDetail", "RefNo" };
            request.RefNo = refNo;

            var response = DepositClient.GetDeposits(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return VoucherMapper.FromDataTransferObject(response.Deposit);
        }

        public DepositModel GetDepositForSalary(DateTime dateMonth)
        {
            var request = PrepareRequest(new DepositRequest());
            request.LoadOptions = new[] { "Deposit", "IncludeDetail", "DateMonth" };
            request.DateMonth = dateMonth;
            var response = DepositClient.GetDeposits(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return VoucherMapper.FromDataTransferObject(response.Deposit);
        }

        /// <summary>
        /// Adds the deposit.
        /// </summary>
        /// <param name="deposit">The deposit.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public long AddDeposit(DepositModel deposit)
        {
            var request = PrepareRequest(new DepositRequest());
            request.Action = PersistType.Insert;
            request.IsConvertData = IsConvertData;
            request.Deposit = VoucherMapper.ToDataTransferObject(deposit);

            var response = DepositClient.SetDeposits(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RefId;
        }

        public long AddDeposit(DepositModel deposit, bool isAutoGenerateParallel)
        {
            var request = PrepareRequest(new DepositRequest());
            request.Action = PersistType.Insert;
            request.IsConvertData = IsConvertData;
            request.Deposit = VoucherMapper.ToDataTransferObject(deposit);

            var response = DepositClient.SetDeposits(request, isAutoGenerateParallel);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RefId;
        }

        /// <summary>
        /// Updates the deposit.
        /// </summary>
        /// <param name="deposit">The deposit.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public long UpdateDeposit(DepositModel deposit)
        {
            var request = PrepareRequest(new DepositRequest());
            request.Action = PersistType.Update;
            request.IsConvertData = IsConvertData;
            request.Deposit = VoucherMapper.ToDataTransferObject(deposit);

            var response = DepositClient.SetDeposits(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RefId;
        }

        public long UpdateDeposit(DepositModel deposit, bool isAutoGenerateParallel)
        {
            var request = PrepareRequest(new DepositRequest());
            request.Action = PersistType.Update;
            request.IsConvertData = IsConvertData;
            request.Deposit = VoucherMapper.ToDataTransferObject(deposit);

            var response = DepositClient.SetDeposits(request, isAutoGenerateParallel);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RefId;
        }

        /// <summary>
        /// Deletes the deposit.
        /// </summary>
        /// <param name="depositId">The deposit identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public long DeleteDeposit(long depositId)
        {
            var request = PrepareRequest(new DepositRequest());
            request.Action = PersistType.Delete;
            request.RefId = depositId;

            var response = DepositClient.SetDeposits(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RefId;
        }
        #endregion

        #region Salary

        public string GetRefNoSalary(string currDate, string currencyCode)
        {
            var request = PrepareRequest(new SalaryRequest());
            request.LoadOptions = new[] { "GetRefNoSalary" };
            request.CurrDate = currDate;
            request.CurrencyCode = currencyCode;
            var response = SalaryFacadeClient.GetSalaries(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return response.Message;
        }

        public int SavePostedSalary(SalaryModel model)
        {
            var request = PrepareRequest(new SalaryRequest());
            request.Salary = Mapper.ToDataTransferObject(model);
            request.LoadOptions = new[] { "SavePostedSalary" };

            var response = SalaryFacadeClient.SetSalaries(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return response.SalaryId;
        }

        public int SavePostedAllSalary(SalaryModel model)
        {
            var request = PrepareRequest(new SalaryRequest());
            request.Salary = Mapper.ToDataTransferObject(model);
            request.LoadOptions = new[] { "SavePostedAllSalary" };

            var response = SalaryFacadeClient.SetSalaries(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return response.SalaryId;
        }
        /// <summary> 
        /// Gets the Salary. 
        /// </summary>
        /// <returns></returns>
        public int SaveCalSalary(SalaryModel model)
        {
            var request = PrepareRequest(new SalaryRequest());
            request.Salary = Mapper.ToDataTransferObject(model);
            request.LoadOptions = new[] { "CalSalary" };

            var response = SalaryFacadeClient.SetSalaries(request);
            if (response.Acknowledge != AcknowledgeType.Success) return -1;
            return response.SalaryId;
        }

        /// <summary>
        /// Saves the posted.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public string SavePosted(SalaryModel model)
        {
            var request = PrepareRequest(new SalaryRequest());
            request.Salary = Mapper.ToDataTransferObject(model);
            request.LoadOptions = new[] { "Posted" };

            var response = SalaryFacadeClient.SetSalaries(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return response.Message;
        }

        /// <summary>
        /// Checks the state of the cal salary.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public SalaryModel GetCalSalaryState(SalaryModel model)
        {
            var request = PrepareRequest(new SalaryRequest());
            request.Salary = Mapper.ToDataTransferObject(model);
            request.LoadOptions = new[] { "CheckCalSalaryState" };

            var response = SalaryFacadeClient.SetSalaries(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return Mapper.FromDataTransferObject(response.Salary);
        }

        /// <summary>
        /// Checks the state of the cal salary.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public bool CheckCalSalaryState(SalaryModel model)
        {
            var request = PrepareRequest(new SalaryRequest());
            request.Salary = Mapper.ToDataTransferObject(model);
            request.LoadOptions = new[] { "CheckCalSalaryState" };

            var response = SalaryFacadeClient.SetSalaries(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            if (response.Message == null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Checks the state of the cal salary.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public bool CheckCalSalaryPostedState(SalaryModel model)
        {
            var request = PrepareRequest(new SalaryRequest());
            request.Salary = Mapper.ToDataTransferObject(model);
            request.LoadOptions = new[] { "CheckCalSalaryPostedState" };

            var response = SalaryFacadeClient.SetSalaries(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            if (response.Message == null)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Saves all cal salary.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int SaveAllCalSalary(SalaryModel model)
        {
            var request = PrepareRequest(new SalaryRequest());
            request.Salary = Mapper.ToDataTransferObject(model);
            request.LoadOptions = new[] { "AllCalSalary" };
            var response = SalaryFacadeClient.SetSalaries(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return response.SalaryId;
        }

        /// <summary>
        /// Deletes the cal salary.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int DeleteCalSalary(SalaryModel model)
        {
            var request = PrepareRequest(new SalaryRequest());
            request.Salary = Mapper.ToDataTransferObject(model);
            request.LoadOptions = new[] { "DeleteCalSalary" };

            var response = SalaryFacadeClient.SetSalaries(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return response.SalaryId;
        }

        /// <summary>
        /// Deletes all cal salary.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int DeleteAllCalSalary(SalaryModel model)
        {
            var request = PrepareRequest(new SalaryRequest());
            request.Salary = Mapper.ToDataTransferObject(model);
            request.LoadOptions = new[] { "DeleteAllCalSalary" };
            var response = SalaryFacadeClient.SetSalaries(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return response.SalaryId;
        }

        /// <summary>
        /// Gets the salary by moth.
        /// </summary>
        /// <returns></returns>
        public List<SalaryModel> GetSalaryByMoth()
        {
            var request = PrepareRequest(new SalaryRequest());
            request.LoadOptions = new[] { "GetSalaryByMoth" };
            var response = SalaryFacadeClient.GetSalaries(request);
            return (List<SalaryModel>)Mapper.FromDataTransferObjects(response.Salaries);
        }
        #endregion

        #region VoucherType

        /// <summary>
        /// Gets the voucher types.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IList<VoucherTypeModel> GetVoucherTypes()
        {
            var request = PrepareRequest(new VoucherTypeRequest());
            request.LoadOptions = new[] { "VoucherTypes" };

            var response = VoucherTypeClient.GetVoucherTypes(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.VoucherTypes);
        }

        public VoucherTypeModel GetVoucherTypeByCode(string code)
        {
            var request = PrepareRequest(new VoucherTypeRequest());
            request.LoadOptions = new[] { "VoucherType", "ByCode" };
            request.Code = code;
            var response = VoucherTypeClient.GetVoucherTypes(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObject(response.VoucherType);
        }

        /// <summary>
        /// Gets the voucher types active.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<VoucherTypeModel> GetVoucherTypesActive()
        {
            var request = PrepareRequest(new VoucherTypeRequest());
            request.LoadOptions = new[] { "VoucherTypes", "IsActive" };

            var response = VoucherTypeClient.GetVoucherTypes(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.VoucherTypes);
        }

        #endregion

        #region AutoBusiness

        /// <summary>
        /// Gets the autoBusinesss.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<AutoBusinessModel> GetAutoBusinesss()
        {
            var request = PrepareRequest(new AutoBusinessRequest());
            request.LoadOptions = new[] { "AutoBusinesss" };

            var response = AutoBusinessClient.GetAutoBusinesses(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return DictionaryMapper.FromDataTransferObjects(response.AutoBusinesses);
        }

        /// <summary>
        /// Gets the autoBusinesss active.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<AutoBusinessModel> GetAutoBusinesssActive()
        {
            var request = PrepareRequest(new AutoBusinessRequest());
            request.LoadOptions = new[] { "AutoBusinesss", "IsActive" };

            var response = AutoBusinessClient.GetAutoBusinesses(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return DictionaryMapper.FromDataTransferObjects(response.AutoBusinesses);
        }

        /// <summary>
        /// Gets the autoBusinesss non active.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<AutoBusinessModel> GetAutoBusinesssNonActive()
        {
            var request = PrepareRequest(new AutoBusinessRequest());
            request.LoadOptions = new[] { "AutoBusinesss", "NonActive" };

            var response = AutoBusinessClient.GetAutoBusinesses(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return DictionaryMapper.FromDataTransferObjects(response.AutoBusinesses);
        }

        /// <summary>
        /// Gets the autoBusiness.
        /// </summary>
        /// <param name="autoBusinessId">The autoBusiness identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public AutoBusinessModel GetAutoBusiness(int autoBusinessId)
        {
            var request = PrepareRequest(new AutoBusinessRequest());
            request.LoadOptions = new[] { "AutoBusiness" };
            request.AutoBusinessId = autoBusinessId;

            var response = AutoBusinessClient.GetAutoBusinesses(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return DictionaryMapper.FromDataTransferObject(response.AutoBusiness);
        }

        /// <summary>
        /// Gets the type of the automatic business by reference.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<AutoBusinessModel> GetAutoBusinessByRefType(int refTypeId, bool isActive)
        {
            var request = PrepareRequest(new AutoBusinessRequest());
            request.LoadOptions = new[] { "AutoBusinesss", "RefType" };
            request.RefTypeId = refTypeId;
            request.IsActive = isActive;

            var response = AutoBusinessClient.GetAutoBusinesses(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return DictionaryMapper.FromDataTransferObjects(response.AutoBusinesses);
        }

        /// <summary>
        /// Adds the autoBusiness.
        /// </summary>
        /// <param name="autoBusiness">The autoBusiness.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int AddAutoBusiness(AutoBusinessModel autoBusiness)
        {
            var request = PrepareRequest(new AutoBusinessRequest());
            request.Action = PersistType.Insert;
            request.AutoBusiness = DictionaryMapper.ToDataTransferObject(autoBusiness);

            var response = AutoBusinessClient.SetAutoBusinesses(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.AutoBusinessId;
        }

        /// <summary>
        /// Updates the autoBusiness.
        /// </summary>
        /// <param name="autoBusiness">The autoBusiness.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int UpdateAutoBusiness(AutoBusinessModel autoBusiness)
        {
            var request = PrepareRequest(new AutoBusinessRequest());
            request.Action = PersistType.Update;
            request.AutoBusiness = DictionaryMapper.ToDataTransferObject(autoBusiness);

            var response = AutoBusinessClient.SetAutoBusinesses(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.AutoBusinessId;
        }

        /// <summary>
        /// Deletes the autoBusiness.
        /// </summary>
        /// <param name="autoBusinessId">The autoBusiness identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int DeleteAutoBusiness(int autoBusinessId)
        {
            var request = PrepareRequest(new AutoBusinessRequest());
            request.Action = PersistType.Delete;
            request.AutoBusinessId = autoBusinessId;

            var response = AutoBusinessClient.SetAutoBusinesses(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RowsAffected;
        }

        #endregion

        #region RefType

        /// <summary>
        /// Gets the voucher types.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IList<RefTypeModel> GetRefTypes()
        {
            var request = PrepareRequest(new RefTypeRequest());
            request.LoadOptions = new[] { "RefTypes" };

            var response = RefTypeClient.GetRefTypes(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.RefTypes);
        }

        /// <summary>
        /// Gets the voucher types search.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IList<RefTypeModel> GetRefTypesSearch()
        {
            var request = PrepareRequest(new RefTypeRequest());
            request.LoadOptions = new[] { "RefTypeSearch" };

            var response = RefTypeClient.GetRefTypes(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.RefTypes);
        }


        #endregion

        #region Project

        /// <summary>
        /// Gets the projects.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<ProjectModel> GetProjects()
        {
            var request = PrepareRequest(new ProjectRequest());
            request.LoadOptions = new[] { "Projects" };

            var response = ProjectClient.GetProjects(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.Projects);
        }

        /// <summary>
        /// Gets the projects active.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<ProjectModel> GetProjectsActive()
        {
            var request = PrepareRequest(new ProjectRequest());
            request.LoadOptions = new[] { "Projects", "IsActive" };

            var response = ProjectClient.GetProjects(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.Projects);
        }

        /// <summary>
        /// Gets the projects non active.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<ProjectModel> GetProjectsNonActive()
        {
            var request = PrepareRequest(new ProjectRequest());
            request.LoadOptions = new[] { "Projects", "NonActive" };

            var response = ProjectClient.GetProjects(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.Projects);
        }

        /// <summary>
        /// Gets the project.
        /// </summary>
        /// <param name="projectId">The project identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public ProjectModel GetProject(int projectId)
        {
            var request = PrepareRequest(new ProjectRequest());
            request.LoadOptions = new[] { "Project" };
            request.ProjectId = projectId;

            var response = ProjectClient.GetProjects(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObject(response.Project);
        }

        /// <summary>
        /// Adds the project.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int AddProject(ProjectModel project)
        {
            var request = PrepareRequest(new ProjectRequest());
            request.Action = PersistType.Insert;
            request.Project = Mapper.ToDataTransferObject(project);

            var response = ProjectClient.SetProjects(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.ProjectId;
        }

        /// <summary>
        /// Updates the project.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int UpdateProject(ProjectModel project)
        {
            var request = PrepareRequest(new ProjectRequest());
            request.Action = PersistType.Update;
            request.Project = Mapper.ToDataTransferObject(project);

            var response = ProjectClient.SetProjects(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RowsAffected;
        }

        /// <summary>
        /// Deletes the project.
        /// </summary>
        /// <param name="projectId">The project identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int DeleteProject(int projectId)
        {
            var request = PrepareRequest(new ProjectRequest());
            request.Action = PersistType.Delete;
            request.ProjectId = projectId;

            var response = ProjectClient.SetProjects(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RowsAffected;
        }

        #endregion

        #region CompanyProfile

        /// <summary>
        /// Gets the companyProfiles.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<CompanyProfileModel> GetCompanyProfiles()
        {
            var request = PrepareRequest(new CompanyProfileRequest());
            request.LoadOptions = new[] { "CompanyProfiles" };

            var response = CompanyProfileClient.GetCompanyProfiles(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.CompanyProfiles);
        }

        /// <summary>
        /// Gets the companyProfile.
        /// </summary>
        /// <param name="companyProfileId">The companyProfile identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public CompanyProfileModel GetCompanyProfile(int companyProfileId)
        {
            var request = PrepareRequest(new CompanyProfileRequest());
            request.LoadOptions = new[] { "CompanyProfile" };
            request.CompanyProfileId = companyProfileId;

            var response = CompanyProfileClient.GetCompanyProfiles(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObject(response.CompanyProfile);
        }

        /// <summary>
        /// Adds the companyProfile.
        /// </summary>
        /// <param name="companyProfile">The companyProfile.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int AddCompanyProfile(CompanyProfileModel companyProfile)
        {
            var request = PrepareRequest(new CompanyProfileRequest());
            request.Action = PersistType.Insert;
            request.CompanyProfile = Mapper.ToDataTransferObject(companyProfile);

            var response = CompanyProfileClient.SetCompanyProfiles(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.CompanyProfileId;
        }

        /// <summary>
        /// Updates the companyProfile.
        /// </summary>
        /// <param name="companyProfile">The companyProfile.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int UpdateCompanyProfile(CompanyProfileModel companyProfile)
        {
            var request = PrepareRequest(new CompanyProfileRequest());
            request.Action = PersistType.Update;
            request.CompanyProfile = Mapper.ToDataTransferObject(companyProfile);

            var response = CompanyProfileClient.SetCompanyProfiles(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.CompanyProfileId;
        }

        /// <summary>
        /// Deletes the companyProfile.
        /// </summary>
        /// <param name="companyProfileId">The companyProfile identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int DeleteCompanyProfile(int companyProfileId)
        {
            var request = PrepareRequest(new CompanyProfileRequest());
            request.Action = PersistType.Delete;
            request.CompanyProfileId = companyProfileId;

            var response = CompanyProfileClient.SetCompanyProfiles(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RowsAffected;
        }

        #endregion

        #region Report

        public ReportDataTemplateModel GetReportDataTemplate(string dataTemplateCode)
        {
            var reportDataTemplate = ReportDataTemplateClient.GetReportDataTemplate(dataTemplateCode);
            return ReportMapper.FromDataTransferObject(reportDataTemplate);
        }

        public long InsertOrUpdateReportDataTemplate(ReportDataTemplateModel reportDataTemplate)
        {
            var reportDataTemplateEntity = ReportMapper.ToDataTransferObject(reportDataTemplate);
            var response = ReportDataTemplateClient.InsertOrUpdateReportDataTemplate(reportDataTemplateEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.Index;
        }

        #region Estiamte Report //chỉ giành cho báo cáo dự toán

        /// <summary>
        /// Gets the general receipt estimate.
        /// </summary>
        /// <param name="yearOfEstimate">The year of estimate.</param>
        /// <returns></returns>
        public IList<GeneralReceiptEstimateModel> GetGeneralReceiptEstimate(short yearOfEstimate)
        {
            var request = PrepareRequest(new ReportListRequest());
            request.LoadOptions = new[] { "Reports", "GeneralReceiptEstimate" };
            request.YearOfEstimate = yearOfEstimate;

            var response = ReportListClient.GetReportLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return Mapper.FromDataTransferObjects(response.GeneralReceiptEstimates);
        }

        /// <summary>
        /// Gets the general payment estimate.
        /// </summary>
        /// <param name="yearOfEstimate">The year of estimate.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<GeneralPaymentEstimateModel> GetGeneralPaymentEstimate(short yearOfEstimate)
        {
            var request = PrepareRequest(new ReportListRequest());
            request.LoadOptions = new[] { "Reports", "GeneralPaymentEstimate" };
            request.YearOfEstimate = yearOfEstimate;

            var response = ReportListClient.GetReportLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return Mapper.FromDataTransferObjects(response.GeneralPaymentEstimates);
        }

        /// <summary>
        /// Gets the general estimate.
        /// </summary>
        /// <param name="yearOfEstimate">The year of estimate.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<GeneralEstimateModel> GetGeneralEstimate(short yearOfEstimate)
        {
            var request = PrepareRequest(new ReportListRequest());
            request.LoadOptions = new[] { "Reports", "GeneralEstimate" };
            request.YearOfEstimate = yearOfEstimate;

            var response = ReportListClient.GetReportLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return Mapper.FromDataTransferObjects(response.GeneralEstimates);
        }

        /// <summary>
        /// Gets the general payment detail estimate.
        /// </summary>
        /// <param name="yearOfEstimate">The year of estimate.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<GeneralPaymentDetailEstimateModel> GetGeneralPaymentDetailEstimate(short yearOfEstimate)
        {
            var request = PrepareRequest(new ReportListRequest());
            request.LoadOptions = new[] { "Reports", "GeneralPaymentDetailEstimate" };
            request.YearOfEstimate = yearOfEstimate;

            var response = ReportListClient.GetReportLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return Mapper.FromDataTransferObjects(response.GeneralPaymentDetailEstimates);
        }

        /// <summary>
        /// Gets the estimate detail statement.
        /// </summary>
        /// <param name="yearOfEstimate">The year of estimate.</param>
        /// <returns></returns>
        public EstimateDetailStatementModel GetEstimateDetailStatement(short yearOfEstimate, bool isCompanyProfile)
        {
            var request = PrepareRequest(new ReportListRequest());
            request.LoadOptions = new[] { "Reports", "EstimateDetailStatement" };
            request.YearOfEstimate = yearOfEstimate;
            request.IsCompanyProfile = isCompanyProfile;
            var response = ReportListClient.GetReportLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return Mapper.FromDataTransferObject(response.EstimateDetailStatement);
        }

        /// <summary>
        /// Gets the fund stuations.
        /// </summary>
        /// <param name="yearOfEstimate">The year of estimate.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<FundStuationModel> GetFundStuations(short yearOfEstimate)
        {
            var request = PrepareRequest(new ReportListRequest());
            request.LoadOptions = new[] { "Reports", "FundStuation" };
            request.YearOfEstimate = yearOfEstimate;

            var response = ReportListClient.GetReportLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return Mapper.FromDataTransferObjects(response.FundStuations);
        }

        #endregion

        #region Financial Report //chỉ giành cho báo cáo tài chính

        public IList<B03BNGModel> GetReportB03BNGs(short amountType, string currencyCode, DateTime fromDate, DateTime toDate)
        {
            var request = PrepareRequest(new ReportListRequest());
            request.LoadOptions = new[] { "Reports", "B03BNG" };
            request.AmounType = amountType;
            request.CurrencyCode = currencyCode;
            request.FromDate = fromDate.ToShortDateString();
            request.ToDate = toDate.ToShortDateString();

            var response = ReportListClient.GetReportLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return Mapper.FromDataTransferObjects(response.B03BNGs);
        }

        /// <summary>
        /// Gets the report F03 bn gs.
        /// </summary>
        /// <param name="storeProcedureName">Name of the store procedure.</param>
        /// <param name="amountType">Type of the amount.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<F03BNGModel> GetReportF03BNGs(string storeProcedureName, short amountType, string currencyCode, DateTime fromDate, DateTime toDate)
        {
            var request = PrepareRequest(new ReportListRequest());
            request.LoadOptions = new[] { "Reports", "F03BNG" };
            request.AmounType = amountType;
            request.CurrencyCode = currencyCode;
            request.FromDate = fromDate.ToShortDateString();
            request.ToDate = toDate.ToShortDateString();
            request.StoreProdure = storeProcedureName;

            var response = ReportListClient.GetReportLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return Mapper.FromDataTransferObjects(response.F03BNGs);
        }

        public IList<F331BNGModel> GetReportF331BNGs(string storeProcedureName, short amountType, string accountCode, string currencyCode, DateTime fromDate, DateTime toDate)
        {
            var request = PrepareRequest(new ReportListRequest());
            request.LoadOptions = new[] { "Reports", "F331BNG" };
            request.AmounType = amountType;
            request.AccountNumber = accountCode;
            request.CurrencyCode = currencyCode;
            request.FromDate = fromDate.ToShortDateString();
            request.ToDate = toDate.ToShortDateString();
            request.StoreProdure = storeProcedureName;

            var response = ReportListClient.GetReportLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return Mapper.FromDataTransferObjects(response.F331BNGs);
        }

        public IList<B09BNGModel> GetReportB09BNGs(string storeProcedureName, short amountType, string currencyCode, DateTime fromDate, DateTime toDate)
        {
            var request = PrepareRequest(new ReportListRequest());
            request.LoadOptions = new[] { "Reports", "B09BNG" };
            request.AmounType = amountType;
            request.CurrencyCode = currencyCode;
            request.FromDate = fromDate.ToShortDateString();
            request.ToDate = toDate.ToShortDateString();
            request.StoreProdure = storeProcedureName;

            var response = ReportListClient.GetReportLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return Mapper.FromDataTransferObjects(response.B09BNGs);
        }

        public IList<B01BCQTModel> GetReportB01BCQTs(string storeProcedureName, short amountType, string currencyCode, DateTime fromDate, DateTime toDate)
        {
            var request = PrepareRequest(new ReportListRequest());
            request.LoadOptions = new[] { "Reports", "FinacialB01BCQT" };
            request.AmounType = amountType;
            request.CurrencyCode = currencyCode;
            request.FromDate = fromDate.ToShortDateString();
            request.ToDate = toDate.ToShortDateString();
            request.StoreProdure = storeProcedureName;

            var response = ReportListClient.GetReportLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return ReportMapper.FromDataTransferObjects(response.FinacialB01BCQTs);
        }

        public IList<ReportF03BCTModel> GetReportF03_BCTs(string storeProcedureName, short amountType, string currencyCode, DateTime fromDate, DateTime toDate)
        {
            var request = PrepareRequest(new ReportListRequest());
            request.LoadOptions = new[] { "Reports", "F03BCT" };
            request.AmounType = amountType;
            request.CurrencyCode = currencyCode;
            request.FromDate = fromDate.ToShortDateString();
            request.ToDate = toDate.ToShortDateString();
            request.StoreProdure = storeProcedureName;

            var response = ReportListClient.GetReportLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return ReportMapper.FromDataTransferObjects(response.ReportF03BCT);
        }

        public IList<ReportActivityB02Model> GetReportActivityB02(string storeProcedureName, int amountType, string currencyCode, DateTime fromDate, DateTime toDate)
        {
            var request = PrepareRequest(new ReportListRequest());
            request.LoadOptions = new[] { "Reports", "ReportActivityB02" };
            request.AmounType = amountType;
            request.CurrencyCode = currencyCode;
            request.FromDate = fromDate.ToShortDateString();
            request.ToDate = toDate.ToShortDateString();
            request.StoreProdure = storeProcedureName;

            var response = ReportListClient.GetReportLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return ReportMapper.FromDataTransferObjects(response.ReportActivityB02);
        }

        #endregion

        public IList<B01HModel> GetB01HWithStoreProdure(string storeProdure, string fromDate, string toDate, string currencyCode, int amounType)
        {
            var request = PrepareRequest(new ReportListRequest());
            request.LoadOptions = new[] { "Reports", "B01H" };
            request.StoreProdure = storeProdure;
            request.FromDate = fromDate;
            request.ToDate = toDate;
            request.CurrencyCode = currencyCode;
            request.AmounType = amounType;
            var response = ReportListClient.GetReportLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return Mapper.FromDataTransferObjects(response.B01H);

        }

        public IList<ReportB01BCTCModel> GetB01BCTC(string storeProdure, string fromDate, string toDate, string currencyCode, int amounType)
        {
            var request = PrepareRequest(new ReportListRequest());
            request.LoadOptions = new[] { "Reports", "B01BCTC" };
            request.StoreProdure = storeProdure;
            request.FromDate = fromDate;
            request.ToDate = toDate;
            request.CurrencyCode = currencyCode;
            request.AmounType = amounType;
            var response = ReportListClient.GetReportLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return ReportMapper.FromDataTransferObjects(response.B01BCTC);
        }

        public IList<ReportB03bBCTCModel> GetB03bBCTC(string storeProdure, string fromDate, string toDate, string currencyCode, int amounType)
        {
            var request = PrepareRequest(new ReportListRequest());
            request.LoadOptions = new[] { "Reports", "B03bBCTC" };
            request.StoreProdure = storeProdure;
            request.FromDate = fromDate;
            request.ToDate = toDate;
            request.CurrencyCode = currencyCode;
            request.AmounType = amounType;
            var response = ReportListClient.GetReportLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return ReportMapper.FromDataTransferObjects(response.B03bBCTC);
        }

        public IList<ReportB04BCTCModel> GetB04BCTC(string storeProdure, string fromDate, string toDate, string currencyCode, int amounType)
        {
            var request = PrepareRequest(new ReportListRequest());
            request.LoadOptions = new[] { "Reports", "B04BCTC" };
            request.StoreProdure = storeProdure;
            request.FromDate = fromDate;
            request.ToDate = toDate;
            request.CurrencyCode = currencyCode;
            request.AmounType = amounType;
            var response = ReportListClient.GetReportLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return ReportMapper.FromDataTransferObjects(response.B04BCTC);
        }

        /// <summary>
        /// Gets the C22 h.
        /// </summary>
        /// <param name="storeProdure"></param>
        /// <param name="paymentVoucherIdList"></param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<C22HModel> GetC22H(string storeProdure, string paymentVoucherIdList)
        {
            var request = PrepareRequest(new ReportListRequest());
            request.LoadOptions = new[] { "Reports", "C22H" };
            request.RefIdList = paymentVoucherIdList;
            request.StoreProdure = storeProdure;
            var response = ReportListClient.GetReportLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return Mapper.FromDataTransferObjects(response.C22H);
        }

        /// <summary>
        /// Gets the C22 h.
        /// </summary>
        /// <param name="storeProdure">The store produre.</param>
        /// <param name="receiptVoucherIdList"></param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<C30BB501Model> GetC30BB501(string storeProdure, string receiptVoucherIdList)
        {
            var request = PrepareRequest(new ReportListRequest());
            request.LoadOptions = new[] { "Reports", "C30BB501" };
            request.RefIdList = receiptVoucherIdList;
            request.StoreProdure = storeProdure;
            var response = ReportListClient.GetReportLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return Mapper.FromDataTransferObjects(response.C30BB501List);
        }

        public IList<C11HModel> GetC11H(string storeProdure, string itemTransactionVoucherIdList)
        {
            var request = PrepareRequest(new ReportListRequest());
            request.LoadOptions = new[] { "Reports", "C11H" };
            request.RefIdList = itemTransactionVoucherIdList;
            request.StoreProdure = storeProdure;
            var response = ReportListClient.GetReportLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return Mapper.FromDataTransferObjects(response.C11H);
        }


        public IList<AccountingVoucherModel> AccountingVoucherModel(string storeProdure, string refIdList, int reftypeId)
        {
            var request = PrepareRequest(new ReportListRequest());
            request.LoadOptions = new[] { "Reports", "AccountingVoucher" };
            request.RefIdList = refIdList;
            request.RefTypeId = reftypeId;
            request.StoreProdure = storeProdure;
            var response = ReportListClient.GetReportLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return Mapper.FromDataTransferObjects(response.AccountingVoucher);
        }


        public IList<A02LDTLModel> Get02LdtlWithStoreProdure(string storeProdure, string fromDate, string toDate)
        {
            var request = PrepareRequest(new ReportListRequest());
            request.LoadOptions = new[] { "Reports", "A02LDTL" };
            request.StoreProdure = storeProdure;
            request.FromDate = fromDate;
            request.ToDate = toDate;
            var response = ReportListClient.GetReportLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.A02LDTL);
        }


        public IList<A02LDTLModel> Get02LdtlIsRetailWithStoreProdure(string storeProdure, string fromDate, string toDate, string whereClause)
        {
            var request = PrepareRequest(new ReportListRequest());
            request.LoadOptions = new[] { "Reports", "A02LDTLIsRetail" };
            request.StoreProdure = storeProdure;
            request.FromDate = fromDate;
            request.ToDate = toDate;
            request.WhereClause = whereClause;
            var response = ReportListClient.GetReportLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.A02LDTL);
        }

        /// <summary>
        /// Gets the S03 ah model with store produre.
        /// </summary>
        /// <param name="storeProdure">The store produre.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="amounType">Type of the amoun.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        /// <exception cref="System.NotImplementedException"></exception>
        public IList<S03AHModel> GetS03AHWithStoreProdure(string storeProdure, string fromDate, string toDate, string currencyCode, int amounType)
        {
            var request = PrepareRequest(new ReportListRequest());
            request.LoadOptions = new[] { "Reports", "S03AH" };
            request.StoreProdure = storeProdure;
            request.FromDate = fromDate;
            request.ToDate = toDate;
            request.CurrencyCode = currencyCode;
            request.AmounType = amounType;
            var response = ReportListClient.GetReportLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.S03AH);
        }

        public IList<S33HModel> GetS33HWithStoreProdure(string storeProdure, string accountNumber, string fromDate, string toDate, string currencyCode, string budgetGroupCode, string fixedAssetCode, string departmentCode, int amounType, string whereClause)
        {
            var request = PrepareRequest(new ReportListRequest());
            request.LoadOptions = new[] { "Reports", "S33H" };
            request.StoreProdure = storeProdure;
            request.FromDate = fromDate;
            request.ToDate = toDate;
            request.WhereClause = whereClause;
            request.AccountNumber = accountNumber;
            request.CurrencyCode = currencyCode;
            request.AmounType = amounType;
            request.BudgetGroupCode = budgetGroupCode;
            request.FixedAssetCode = fixedAssetCode;
            request.DepartmentCode = departmentCode;

            var response = ReportListClient.GetReportLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.S33H);
        }

        public IList<S05HModel> GetS05HWithStoreProdure(string storeProdure, string fromDate, string toDate, string currencyCode, int amounType)
        {
            var request = PrepareRequest(new ReportListRequest());
            request.LoadOptions = new[] { "Reports", "S05H" };
            //  request.RefId = paymentVoucherId;
            request.StoreProdure = storeProdure;
            request.FromDate = fromDate;
            request.ToDate = toDate;
            request.CurrencyCode = currencyCode;
            request.AmounType = amounType;
            var response = ReportListClient.GetReportLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return ReportMapper.FromDataTransferObjects(response.S05H);

        }
        public IList<AdvancePaymentModel> GetAdvancePaymentWithStoreProdure(string storeProdure, string fromDate, string toDate, string currencyCode, int amountType, int accountType)
        {
            var request = PrepareRequest(new ReportListRequest());
            request.LoadOptions = new[] { "Reports", "AdvancePayment" };
            //  request.RefId = paymentVoucherId;
            request.StoreProdure = storeProdure;
            request.FromDate = fromDate;
            request.ToDate = toDate;
            request.AmounType = amountType;
            request.CurrencyCode = currencyCode;
            request.Year = accountType;
            var response = ReportListClient.GetReportLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return ReportMapper.FromDataTransferObjects(response.AdvancePayment);

        }

        public IList<S33HModel> GetS33HWithStoreProdure(string storeProdure, string accountNumber, string fromDate, string toDate, string currencyCode, string budgetGroupCode, string fixedAssetCode, string departmentCode, int amounType, string whereClause, string selectedField, string selectedAllValueField)
        {
            var request = PrepareRequest(new ReportListRequest());
            request.LoadOptions = new[] { "Reports", "S33H" };
            request.StoreProdure = storeProdure;
            request.FromDate = fromDate;
            request.ToDate = toDate;
            request.WhereClause = whereClause;
            request.AccountNumber = accountNumber;
            request.CurrencyCode = currencyCode;
            request.AmounType = amounType;
            request.BudgetGroupCode = budgetGroupCode;
            request.FixedAssetCode = fixedAssetCode;
            request.DepartmentCode = departmentCode;
            request.SelectedField = selectedField;
            request.SelectedAllValueField = selectedAllValueField;

            var response = ReportListClient.GetReportLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.S33H);
        }

        public IList<B14QModel> GetB14QWithStoreProdure(string storeProdure, string fromDate, string toDate, string currencyCode, string accountnumber, string stockIdList, int amounType)
        {
            var request = PrepareRequest(new ReportListRequest());
            request.LoadOptions = new[] { "Reports", "B14Q" };
            request.StoreProdure = storeProdure;
            request.FromDate = fromDate;
            request.ToDate = toDate;
            request.CurrencyCode = currencyCode;
            request.AmounType = amounType;
            request.AccountNumber = accountnumber;
            request.ListStockId = stockIdList;
            var response = ReportListClient.GetReportLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.B14Q);
        }

        public IList<FixedAssetB03HModel> GetFixedAssetB03H(string fromDate, string toDate, string currencyCode)
        {
            var request = PrepareRequest(new ReportListRequest());
            request.LoadOptions = new[] { "Reports", "FixedAssetB03H" };
            request.FromDate = fromDate;
            request.ToDate = toDate;
            request.CurrencyCode = currencyCode;
            var response = ReportListClient.GetReportLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.FixedAssetB03H);
        }

        public IList<FixedAssetB03HModel> GetFixedAssetB03HAmountType(string fromDate, string toDate, int currencyDecimalDigits)
        {
            var request = PrepareRequest(new ReportListRequest());
            request.LoadOptions = new[] { "Reports", "FixedAssetB03HAmountType" };
            request.FromDate = fromDate;
            request.ToDate = toDate;
            request.CurrencyDecimalDigits = currencyDecimalDigits;
            var response = ReportListClient.GetReportLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return Mapper.FromDataTransferObjects(response.FixedAssetB03H);
        }

        public IList<FixedAssetB01Model> GetFixedAssetB01(string fromDate, string toDate, string currencyCode)
        {
            var request = PrepareRequest(new ReportListRequest());
            request.LoadOptions = new[] { "Reports", "FixedAssetB01" };
            request.FromDate = fromDate;
            request.ToDate = toDate;
            request.CurrencyCode = currencyCode;
            var response = ReportListClient.GetReportLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.FixedAssetB01);
        }

        public IList<FixedAssetB01Model> GetFixedAssetB01AmountType(string fromDate, string toDate, int currencyDecimalDigits)
        {
            var request = PrepareRequest(new ReportListRequest());
            request.LoadOptions = new[] { "Reports", "FixedAssetB01AmountType" };
            request.FromDate = fromDate;
            request.ToDate = toDate;
            request.CurrencyDecimalDigits = currencyDecimalDigits;
            var response = ReportListClient.GetReportLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return Mapper.FromDataTransferObjects(response.FixedAssetB01);
        }

        public IList<FixedAssetC55aHDModel> GetFixedAssetC55aHD(string fromDate, string toDate, string faParameter, string faCategoryCode,
                                                         string currencyCode)
        {
            var request = PrepareRequest(new ReportListRequest());
            request.LoadOptions = new[] { "Reports", "FixedAssetC55aHD" };
            request.ToDate = toDate;
            request.FromDate = fromDate;
            request.CurrencyCode = currencyCode;
            request.FaCategoryCode = faCategoryCode;
            request.FixedAssetParameter = faParameter;
            var response = ReportListClient.GetReportLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.FixedAssetC55aHD);
        }

        public IList<FixedAssetC55aHDModel> GetFixedAssetC55aHDAmountType(string fromDate, string toDate, string faParameter, string faCategoryCode, int currencyDecimalDigits)
        {
            var request = PrepareRequest(new ReportListRequest());
            request.LoadOptions = new[] { "Reports", "FixedAssetC55aHDAmountType" };
            request.ToDate = toDate;
            request.FromDate = fromDate;
            request.FaCategoryCode = faCategoryCode;
            request.FixedAssetParameter = faParameter;
            request.CurrencyDecimalDigits = currencyDecimalDigits;
            var response = ReportListClient.GetReportLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return Mapper.FromDataTransferObjects(response.FixedAssetC55aHD);
        }

        public IList<FixedAssetFAInventoryModel> GetFixedAssetFAInventory(string fromDate, string toDate, string currencyCode, int currencyDecimalDigits)
        {
            var request = PrepareRequest(new ReportListRequest());
            request.LoadOptions = new[] { "Reports", "FixedAssetFAInventory" };
            request.FromDate = fromDate;
            request.ToDate = toDate;
            request.CurrencyCode = currencyCode;
            request.CurrencyDecimalDigits = currencyDecimalDigits;
            var response = ReportListClient.GetReportLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.FixedAssetFAInventory);
        }

        public IList<FixedAssetFAInventoryModel> GetFixedAssetFAInventoryAmountType(string fromDate, string toDate, int currencyDecimalDigits)
        {
            var request = PrepareRequest(new ReportListRequest());
            request.LoadOptions = new[] { "Reports", "FixedAssetFAInventoryAmountType" };
            request.FromDate = fromDate;
            request.ToDate = toDate;
            request.CurrencyDecimalDigits = currencyDecimalDigits;
            var response = ReportListClient.GetReportLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.FixedAssetFAInventory);
        }

        public IList<FixedAssetFAInventoryHouseModel> GetFixedAssetFAInventoryHouse(string fromDate, string toDate, string currencyCode)
        {
            var request = PrepareRequest(new ReportListRequest());
            request.LoadOptions = new[] { "Reports", "FixedAssetFAInventoryHouse" };
            request.FromDate = fromDate;
            request.ToDate = toDate;
            request.CurrencyCode = currencyCode;
            var response = ReportListClient.GetReportLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.FixedAssetFAInventoryHouse);
        }

        public IList<FixedAssetFAInventoryHouseModel> GetFixedAssetFAInventoryHouseAmountType(string fromDate, string toDate, int currencyDecimalDigits)
        {
            var request = PrepareRequest(new ReportListRequest());
            request.LoadOptions = new[] { "Reports", "FixedAssetFAInventoryHouseAmountType" };
            request.FromDate = fromDate;
            request.ToDate = toDate;
            request.CurrencyDecimalDigits = currencyDecimalDigits;
            var response = ReportListClient.GetReportLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.FixedAssetFAInventoryHouse);
        }

        public IList<FixedAssetFAInventoryCarModel> GetFixedAssetFAInventoryCar(string fromDate, string toDate, string currencyCode)
        {
            var request = PrepareRequest(new ReportListRequest());
            request.LoadOptions = new[] { "Reports", "FixedAssetFAInventoryCar" };
            request.FromDate = fromDate;
            request.ToDate = toDate;
            request.CurrencyCode = currencyCode;
            var response = ReportListClient.GetReportLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.FixedAssetFAInventoryCar);
        }

        public IList<FixedAssetFAInventoryCarModel> GetFixedAssetFAInventoryCarAmountType(string fromDate, string toDate, int currencyDecimalDigits)
        {
            var request = PrepareRequest(new ReportListRequest());
            request.LoadOptions = new[] { "Reports", "FixedAssetFAInventoryCarAmountType" };
            request.FromDate = fromDate;
            request.ToDate = toDate;
            request.CurrencyDecimalDigits = currencyDecimalDigits;
            var response = ReportListClient.GetReportLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.FixedAssetFAInventoryCar);
        }
        public IList<FixedAssetFAInventoryModel> GetFixedAssetFAInventory3000(string fromDate, string toDate, string currencyCode)
        {
            var request = PrepareRequest(new ReportListRequest());
            request.LoadOptions = new[] { "Reports", "FixedAssetFAInventory3000" };
            request.FromDate = fromDate;
            request.ToDate = toDate;
            request.CurrencyCode = currencyCode;
            var response = ReportListClient.GetReportLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.FixedAssetFAInventory);
        }

        public IList<FixedAssetFAInventoryModel> GetFixedAssetFAInventoryAmountType3000(string fromDate, string toDate)
        {
            var request = PrepareRequest(new ReportListRequest());
            request.LoadOptions = new[] { "Reports", "FixedAssetFAInventoryAmountType3000" };
            request.FromDate = fromDate;
            request.ToDate = toDate;
            var response = ReportListClient.GetReportLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.FixedAssetFAInventory);
        }

        public IList<FixedAssetB02Model> GetFixedAssetB02(string fromDate, string toDate, string currencyCode)
        {
            var request = PrepareRequest(new ReportListRequest());
            request.LoadOptions = new[] { "Reports", "FixedAssetB02" };
            request.FromDate = fromDate;
            request.ToDate = toDate;
            request.CurrencyCode = currencyCode;
            var response = ReportListClient.GetReportLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.FixedAssetB02);
        }

        public IList<FixedAssetB02Model> GetFixedAssetB02AmountType(string fromDate, string toDate, int currencyDecimalDigits)
        {
            var request = PrepareRequest(new ReportListRequest());
            request.LoadOptions = new[] { "Reports", "FixedAssetB02AmountType" };
            request.FromDate = fromDate;
            request.ToDate = toDate;
            request.CurrencyDecimalDigits = currencyDecimalDigits;
            var response = ReportListClient.GetReportLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.FixedAssetB02);
        }



        public IList<FixedAssetB03H30KModel> GetFixedAssetB03H30K(string fromDate, string toDate, int currencyDecimalDigits)
        {
            var request = PrepareRequest(new ReportListRequest());
            request.LoadOptions = new[] { "Reports", "FixedAssetB03H30K" };
            request.FromDate = fromDate;
            request.ToDate = toDate;
            request.CurrencyDecimalDigits = currencyDecimalDigits;
            var response = ReportListClient.GetReportLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.FixedAssetB03H30K);
        }

        public IList<FixedAsset30KPart2Model> GetFixedAsset30KPart2(string fromDate, string toDate, int currencyDecimalDigits)
        {
            var request = PrepareRequest(new ReportListRequest());
            request.LoadOptions = new[] { "Reports", "FixedAsset30KPart2" };
            request.FromDate = fromDate;
            request.ToDate = toDate;
            request.CurrencyDecimalDigits = currencyDecimalDigits;
            var response = ReportListClient.GetReportLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.FixedAsset30KPart2);
        }

        public IList<FixedAssetCardModel> GetFixedAssetCard(string strFixedAssetId, int currencyDecimalDigits)
        {
            var request = PrepareRequest(new ReportListRequest());
            request.LoadOptions = new[] { "Reports", "FixedAssetCard" };
            request.StrFixedAssetId = strFixedAssetId;
            request.CurrencyDecimalDigits = currencyDecimalDigits;
            var response = ReportListClient.GetReportLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.FixedAssetCards);
        }

        public IList<FixedAsset30KPart2Model> GetFixedAssetFAB0130KPart2(string fromDate, string toDate, int currencyDecimalDigits)
        {
            var request = PrepareRequest(new ReportListRequest());
            request.LoadOptions = new[] { "Reports", "FixedAssetFAB0130KPart2" };
            request.FromDate = fromDate;
            request.ToDate = toDate;
            request.CurrencyDecimalDigits = currencyDecimalDigits;
            var response = ReportListClient.GetReportLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.FixedAsset30KPart2);
        }

        public IList<FixedAssetFAInventoryCarModel> GetFixedAssetFAB01Car(string fromDate, string toDate, int currencyDecimalDigits)
        {
            var request = PrepareRequest(new ReportListRequest());
            request.LoadOptions = new[] { "Reports", "FixedAssetFAB01Car" };
            request.FromDate = fromDate;
            request.ToDate = toDate;
            request.CurrencyDecimalDigits = currencyDecimalDigits;
            var response = ReportListClient.GetReportLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.FixedAssetFAInventoryCar);
        }

        public IList<FixedAssetFAInventoryHouseModel> GetFixedAssetFAB01House(string fromDate, string toDate, int currencyDecimalDigits)
        {
            var request = PrepareRequest(new ReportListRequest());
            request.LoadOptions = new[] { "Reports", "FixedAssetFAB01House" };
            request.FromDate = fromDate;
            request.ToDate = toDate;
            request.CurrencyDecimalDigits = currencyDecimalDigits;
            var response = ReportListClient.GetReportLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.FixedAssetFAInventoryHouse);
        }

        public IList<FixedAssetS31HModel> GetFixedAssetS31H(string fromDate, string toDate, string faParameter, string faCategoryCode, string currencyCode)
        {
            var request = PrepareRequest(new ReportListRequest());
            request.LoadOptions = new[] { "Reports", "FixedAssetS31H" };
            request.ToDate = toDate;
            request.FromDate = fromDate;
            request.CurrencyCode = currencyCode;
            request.FaCategoryCode = faCategoryCode;
            request.FixedAssetParameter = faParameter;
            var response = ReportListClient.GetReportLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.FixedAssetS31H);
        }

        public IList<C30BBModel> GetC30BBWithStoreProdure(int year, int refTypeId)
        {
            var request = PrepareRequest(new ReportListRequest());
            request.LoadOptions = new[] { "Reports", "C30BB"
            };
            request.Year = year;
            request.RefTypeId = refTypeId;
            var response = ReportListClient.GetReportLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.C30BBList);
        }

        public IList<C30BBModel> GetC30BBItemWithStoreProdure(int year, int refTypeId)
        {
            var request = PrepareRequest(new ReportListRequest());
            request.LoadOptions = new[] { "Reports", "C30BBItem"
            };
            request.Year = year;
            request.RefTypeId = refTypeId;
            var response = ReportListClient.GetReportLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.C30BBList);
        }

        public IList<CashReportModel> GetCashS11HWithStoreProdure(string storeProcedure, string fromDate, string toDate, int amountType, string accountNumber, string currencyCode)
        {
            var request = PrepareRequest(new ReportListRequest());
            request.LoadOptions = new[] { "Reports", "CashReportS11H" };
            request.ToDate = toDate;
            request.FromDate = fromDate;
            request.CurrencyCode = currencyCode;
            request.AccountNumber = accountNumber;
            request.AmounType = amountType;
            request.StoreProdure = storeProcedure;
            var response = ReportListClient.GetReportLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.CashReportList);
        }

        public IList<CashReportModel> GetCashS11AHWithStoreProdure(string storeProcedure, string fromDate, string toDate, int amountType, string accountNumber, string correspondingAccountNumber, string currencyCode)
        {
            var request = PrepareRequest(new ReportListRequest());
            request.LoadOptions = new[] { "Reports", "CashReportS11AH" };
            request.ToDate = toDate;
            request.FromDate = fromDate;
            request.CurrencyCode = currencyCode;
            request.AccountNumber = accountNumber;
            request.AmounType = amountType;
            request.CorrespondingAccountNumber = correspondingAccountNumber;
            request.StoreProdure = storeProcedure;
            var response = ReportListClient.GetReportLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.CashReportList);
        }

        public IList<CashReportModel> GetCashS12HWithStoreProdure(string storeProcedure, string fromDate, string toDate, int amountType, string accountNumber, string currencyCode, bool isBank, int? bankId)
        {
            var request = PrepareRequest(new ReportListRequest());
            request.LoadOptions = new[] { "Reports", "CashReportS12H" };
            request.ToDate = toDate;
            request.FromDate = fromDate;
            request.CurrencyCode = currencyCode;
            request.AccountNumber = accountNumber;
            request.AmounType = amountType;
            request.BankId = bankId;
            request.IsBank = isBank;
            request.StoreProdure = storeProcedure;
            var response = ReportListClient.GetReportLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.CashReportList);
        }

        public IList<CashReportModel> GetCashS12AHWithStoreProdure(string storeProcedure, string fromDate, string toDate, int amountType, string accountNumber, string correspondingAccountNumber, string currencyCode, bool isBank, int? bankId)
        {
            var request = PrepareRequest(new ReportListRequest());
            request.LoadOptions = new[] { "Reports", "CashReportS12AH" };
            request.ToDate = toDate;
            request.FromDate = fromDate;
            request.CurrencyCode = currencyCode;
            request.AccountNumber = accountNumber;
            request.AmounType = amountType;
            request.CorrespondingAccountNumber = correspondingAccountNumber;
            request.BankId = bankId;
            request.IsBank = isBank;
            request.StoreProdure = storeProcedure;
            var response = ReportListClient.GetReportLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.CashReportList);
        }

        public IList<FixedAssetS26HModel> GetFixedAssetS26H(string storedProcedure, string fromDate, string toDate, string currencyCode, int amountType, string departmentCode, int fixedAssetCategoryIds, int option)
        {
            var request = PrepareRequest(new ReportListRequest());
            request.LoadOptions = new[] { "Reports", "S26H" };
            request.ToDate = toDate;
            request.FromDate = fromDate;
            request.CurrencyCode = currencyCode;
            request.AmounType = amountType;
            request.StoreProdure = storedProcedure;
            request.DepartmentCode = departmentCode;
            request.WhereClause = fixedAssetCategoryIds.ToString();
            request.Option = option;

            var response = ReportListClient.GetReportLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return ReportMapper.FromDataTransferObjects(response.FixedAssetS26H);
        }

        public IList<FixedAssetS24HModel> GetFixedAssetS24H(string storedProcedure, string currencyCode, int amountType, string fromDate, string toDate, string departmentCode, string fixedAssetCategoryCode, string fixedAssetIds)
        {
            var request = PrepareRequest(new ReportListRequest());
            request.LoadOptions = new[] { "Reports", "S24H" };
            request.ToDate = toDate;
            request.FromDate = fromDate;
            request.CurrencyCode = currencyCode;
            request.AmounType = amountType;
            request.StoreProdure = storedProcedure;
            request.DepartmentCode = departmentCode;
            request.FaCategoryCode = fixedAssetCategoryCode;
            request.StrFixedAssetId = fixedAssetIds;

            var response = ReportListClient.GetReportLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return ReportMapper.FromDataTransferObjects(response.FixedAssetS24H);
        }

        /// <summary>
        /// Gets the S03 bh with store produre.
        /// </summary>
        /// <param name="storeProcedure">The store procedure.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="amountType">Type of the amount.</param>
        /// <param name="accountNumber">The account number.</param>
        /// <param name="correspondingAccountNumber">The corresponding account number.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<S03BHModel> GetS03BHWithStoreProdure(string storeProcedure, string fromDate, string toDate, int amountType, string accountNumber, string correspondingAccountNumber, string currencyCode)
        {
            var request = PrepareRequest(new ReportListRequest());
            request.LoadOptions = new[] { "Reports", "S03BH" };
            request.ToDate = toDate;
            request.FromDate = fromDate;
            request.CurrencyCode = currencyCode;
            request.AccountNumber = accountNumber;
            request.AmounType = amountType;
            request.StoreProdure = storeProcedure;
            request.CorrespondingAccountNumber = correspondingAccountNumber;
            var response = ReportListClient.GetReportLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.S03BHList);
        }

        public IList<FixedAssetCardsModel> GetFixedAssetCards(string strFixedAssetId, int currencyDecimalDigits)
        {
            var request = PrepareRequest(new ReportListRequest());
            request.LoadOptions = new[] { "Reports", "FixedAssetCards" };
            request.StrFixedAssetId = strFixedAssetId;
            request.CurrencyDecimalDigits = currencyDecimalDigits;
            var response = ReportListClient.GetReportLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return ReportMapper.FromDataTransferObjects(response.FixedAssetCard);
        }

        public IList<BusinessObjects.Report.LedgerAccounting.ReportS104HModel> LedgerAccountingS104H(string storeProdure, string fromDate, string toDate, string budgetSourceCodes, string currencyCode, int amountType)
        {
            var request = PrepareRequest(new ReportListRequest());
            request.LoadOptions = new[] { "Reports", "LedgerAccountingS104H" };
            request.StoreProdure = storeProdure;
            request.ToDate = toDate;
            request.FromDate = fromDate;
            request.CurrencyCode = currencyCode;
            request.AmounType = amountType;
            request.WhereClause = budgetSourceCodes;
            var response = ReportListClient.GetReportLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return ReportMapper.FromDataTransferObjects(response.LedgerAccountingS104H);
        }

        #endregion

        #region SettlementReport

        public IList<ReportB01CIIModel> GetB01CIIWithStoreProdure(string storeProdure, string fromDate, string toDate)
        {
            var request = PrepareRequest(new ReportListRequest());
            request.LoadOptions = new[] { "Reports", "B01CII" };
            request.StoreProdure = storeProdure;
            request.FromDate = fromDate;
            request.ToDate = toDate;

            var response = ReportListClient.GetReportLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return ReportMapper.FromDataTransferObjects(response.ReportB01CII);
        }

        public IList<ReportB01CII01Model> GetB01CII01WithStoreProdure(string storeProdure, string fromDate, string toDate)
        {
            var request = PrepareRequest(new ReportListRequest());
            request.LoadOptions = new[] { "Reports", "B01CII01" };
            request.StoreProdure = storeProdure;
            request.FromDate = fromDate;
            request.ToDate = toDate;

            var response = ReportListClient.GetReportLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return ReportMapper.FromDataTransferObjects(response.ReportB01CII01);
        }

        public IList<ReportB01CIModel> GetB01CIWithStoreProdure(string storeProdure, DateTime fromDate, DateTime toDate)
        {
            var request = PrepareRequest(new ReportListRequest());
            request.LoadOptions = new[] { "Reports", "B01CI" };
            request.StoreProdure = storeProdure;
            request.FromDate = fromDate.ToShortDateString();
            request.ToDate = toDate.ToShortDateString();

            var response = ReportListClient.GetReportLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return ReportMapper.FromDataTransferObjects(response.ReportB01CI);
        }

        public IList<ReportS104HModel> GetS104HWithStoreProdure(string storeProcedure, DateTime fromDate, DateTime toDate, string currencyCode, int amounType)
        {
            var request = PrepareRequest(new ReportListRequest());
            request.LoadOptions = new[] { "Reports", "S104H" };
            request.StoreProdure = storeProcedure;
            request.FromDate = fromDate.ToShortDateString();
            request.ToDate = toDate.ToShortDateString();
            request.CurrencyCode = currencyCode;
            request.AmounType = amounType;

            var response = ReportListClient.GetReportLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return ReportMapper.FromDataTransferObjects(response.ReportS104H);
        }

        #endregion

        #region FixedAssetHousingReport

        /// <summary>
        /// Gets the budget chapters.
        /// </summary>
        /// <returns>
        /// IList{FixedAssetHousingReportModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<FixedAssetHousingReportModel> GetFixedAssetHousingReports()
        {
            var request = PrepareRequest(new FixedAssetHousingReportRequest());
            request.LoadOptions = new[] { "FixedAssetHousingReports" };

            var response = FixedAssetHousingReportClient.GetFixedAssetHousingReports(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.FixedAssetHousingReports);
        }

        /// <summary>
        /// Gets the budget chapters active.
        /// </summary>
        /// <returns>
        /// IList{FixedAssetHousingReportModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<FixedAssetHousingReportModel> GetFixedAssetHousingReportsActive()
        {
            var request = PrepareRequest(new FixedAssetHousingReportRequest());
            request.LoadOptions = new[] { "FixedAssetHousingReports", "IsActive" };

            var response = FixedAssetHousingReportClient.GetFixedAssetHousingReports(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.FixedAssetHousingReports);
        }

        /// <summary>
        /// Gets the budget chapters non active.
        /// </summary>
        /// <returns>
        /// IList{FixedAssetHousingReportModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<FixedAssetHousingReportModel> GetFixedAssetHousingReportsNonActive()
        {
            var request = PrepareRequest(new FixedAssetHousingReportRequest());
            request.LoadOptions = new[] { "FixedAssetHousingReports", "NonActive" };

            var response = FixedAssetHousingReportClient.GetFixedAssetHousingReports(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.FixedAssetHousingReports);
        }

        /// <summary>
        /// Gets the budget chapter.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>
        /// FixedAssetHousingReportModel.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public FixedAssetHousingReportModel GetFixedAssetHousingReport(bool isActive)
        {
            var request = PrepareRequest(new FixedAssetHousingReportRequest());
            request.LoadOptions = new[] { "FixedAssetHousingReport" };
            request.IsActive = isActive;
            var response = FixedAssetHousingReportClient.GetFixedAssetHousingReports(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObject(response.FixedAssetHousingReport);
        }

        /// <summary>
        /// Adds the budget chapter.
        /// </summary>
        /// <param name="fixedAssetHousingReport">The budget chapter.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int AddFixedAssetHousingReport(FixedAssetHousingReportModel fixedAssetHousingReport)
        {
            var request = PrepareRequest(new FixedAssetHousingReportRequest());
            request.Action = PersistType.Insert;
            request.FixedAssetHousingReport = Mapper.ToDataTransferObject(fixedAssetHousingReport);

            var response = FixedAssetHousingReportClient.SetFixedAssetHousingReports(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.FixedAssetHousingReportId;
        }

        /// <summary>
        /// Updates the budget chapter.
        /// </summary>
        /// <param name="fixedAssetHousingReport">The budget chapter.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int UpdateFixedAssetHousingReport(FixedAssetHousingReportModel fixedAssetHousingReport)
        {
            var request = PrepareRequest(new FixedAssetHousingReportRequest());
            request.Action = PersistType.Update;
            request.FixedAssetHousingReport = Mapper.ToDataTransferObject(fixedAssetHousingReport);

            var response = FixedAssetHousingReportClient.SetFixedAssetHousingReports(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.FixedAssetHousingReportId;
        }

        /// <summary>
        /// Deletes the budget chapter.
        /// </summary>
        /// <param name="fixedAssetHousingReportId">The budget chapter identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int DeleteFixedAssetHousingReport(int fixedAssetHousingReportId)
        {
            var request = PrepareRequest(new FixedAssetHousingReportRequest());
            request.Action = PersistType.Delete;
            request.FixedAssetHousingReportId = fixedAssetHousingReportId;

            var response = FixedAssetHousingReportClient.SetFixedAssetHousingReports(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RowsAffected;
        }

        #endregion

        #region ItemTransaction

        public List<BusinessObjects.Inventory.ItemTransactionModel> GetOutputItemTransactionsByDate(DateTime fromDate, DateTime toDate)
        {
            var request = PrepareRequest(new ItemTransactionRequest());
            request.Action = PersistType.Update;
            request.ItemTransaction = new ItemTransactionEntity();
            request.FromDateForReCalOutputStock = fromDate;
            request.ToDateForReCalOutputStock = toDate;
            request.LoadOptions = new[] { "OutputItemTransactionByDate" };
            var response = InventoryClient.GetItemTransactions(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return VoucherMapper.FromDataTransferObjects(response.ItemTransactions).ToList();
        }

        public List<BusinessObjects.Inventory.ItemTransactionModel> GetOutputItemTransactionsByArisePeriod(DateTime fromDate, DateTime toDate, List<int> stockId, string currencyCode)
        {
            var request = PrepareRequest(new ItemTransactionRequest());
            request.Action = PersistType.Update;
            request.ItemTransaction = new ItemTransactionEntity();
            request.FromDateForReCalOutputStock = fromDate;
            request.ToDateForReCalOutputStock = toDate;
            request.StockId = stockId;
            request.CurrencyCode = currencyCode;
            request.LoadOptions = new[] { "OutputItemTransactionBArisePeriod" };
            var response = InventoryClient.GetItemTransactions(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return VoucherMapper.FromDataTransferObjects(response.ItemTransactions).ToList();
        }

        public List<BusinessObjects.Inventory.ItemTransactionModel> GetItemTransactionsByDate(DateTime fromDate, DateTime toDate)
        {
            var request = PrepareRequest(new ItemTransactionRequest());
            request.Action = PersistType.Update;
            request.ItemTransaction = new ItemTransactionEntity();
            request.FromDateForReCalOutputStock = fromDate;
            request.ToDateForReCalOutputStock = toDate;
            request.LoadOptions = new[] { "ItemTransactionByDate" };
            var response = InventoryClient.GetItemTransactions(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return VoucherMapper.FromDataTransferObjects(response.ItemTransactions).ToList();
        }

        public void ReCalOutputStock(DateTime fromDate, DateTime toDate, List<int> stockId, string currencyCode, int CurrencyDecimalDigits)
        {
            var request = PrepareRequest(new ItemTransactionRequest());
            request.Action = PersistType.Update;
            request.ItemTransaction = new ItemTransactionEntity();
            request.FromDateForReCalOutputStock = fromDate;
            request.ToDateForReCalOutputStock = toDate;
            request.StockId = stockId;
            request.CurrencyCode = currencyCode;
            request.CurrencyDecimalDigits = CurrencyDecimalDigits;
            request.LoadOptions = new[] { "ReCalOutputStock" };
            var response = InventoryClient.SetItemTransactions(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
        }

        public BusinessObjects.Inventory.ItemTransactionModel GetItemTransactionVoucher(string refNo)
        {
            throw new NotImplementedException();
        }

        public IList<BusinessObjects.Inventory.ItemTransactionModel> GetItemTransactionVoucherByRefTypeId(int refTypeId)
        {
            var request = PrepareRequest(new ItemTransactionRequest());
            request.LoadOptions = new[] { "ItemTransactions", "RefType" };
            request.RefType = refTypeId;

            var response = InventoryClient.GetItemTransactions(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return VoucherMapper.FromDataTransferObjects(response.ItemTransactions);
        }

        public BusinessObjects.Inventory.ItemTransactionModel GetItemTransactionVoucher(long itemTransactionId)
        {
            var request = PrepareRequest(new ItemTransactionRequest());
            request.LoadOptions = new[] { "ItemTransaction", "IncludeDetail" };
            request.RefId = itemTransactionId;

            var response = InventoryClient.GetItemTransactions(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return VoucherMapper.FromDataTransferObject(response.ItemTransaction);
        }

        public long AddItemTransactionVoucher(BusinessObjects.Inventory.ItemTransactionModel itemTransaction, bool isAutoGenerateParallel)
        {
            var request = PrepareRequest(new ItemTransactionRequest());
            request.Action = PersistType.Insert;
            request.ItemTransaction = VoucherMapper.ToDataTransferObject(itemTransaction);

            var response = InventoryClient.InsertItemTransactions(request, isAutoGenerateParallel);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RefId;
        }

        public long UpdateItemTransactionVoucher(BusinessObjects.Inventory.ItemTransactionModel itemTransaction, bool isAutoGenerateParallel)
        {
            var request = PrepareRequest(new ItemTransactionRequest());
            request.Action = PersistType.Update;
            request.ItemTransaction = VoucherMapper.ToDataTransferObject(itemTransaction);

            var response = InventoryClient.UpdateItemTransactions(request, isAutoGenerateParallel);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RefId;
        }

        public long DeleteItemTransactionVoucher(long itemTransactionId)
        {
            var request = PrepareRequest(new ItemTransactionRequest());
            request.Action = PersistType.Delete;
            request.RefId = itemTransactionId;

            var response = InventoryClient.DeleteItemTransactions(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RefId;
        }

        public decimal GetQuantityOfInventory(int inventoryItemId, int stockId, DateTime postDate, long refID, string currencyCode)
        {
            return InventoryClient.GetQuantityOfInventory(inventoryItemId, stockId, postDate, refID, currencyCode);
        }

        #endregion

        #region FixedAssetArmortization

        /// <summary>
        /// Gets the payment fixedAssetArmortizations.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<FixedAssetArmortizationModel> GetFixedAssetArmortizations()
        {
            var request = PrepareRequest(new FAArmortizationRequest());
            request.LoadOptions = new[] { "FixedAssetArmortizations" };

            var response = FAArmortizationClient.GetFAArmortizations(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.FAArmortizations);
        }

        /// <summary>
        /// Gets the fixed asset armortizations include detail.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<FixedAssetArmortizationModel> GetFixedAssetArmortizationsIncludeDetail()
        {
            var request = PrepareRequest(new FAArmortizationRequest());
            request.LoadOptions = new[] { "FixedAssetArmortizations", "IncludeDetail" };

            var response = FAArmortizationClient.GetFAArmortizations(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.FAArmortizations);
        }

        /// <summary>
        /// Gets the fixed asset armortizations include detail.
        /// </summary>
        /// <param name="refDate">The reference date.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<FixedAssetArmortizationModel> GetFixedAssetArmortizationsIncludeDetail(string refDate)
        {
            var request = PrepareRequest(new FAArmortizationRequest());
            request.LoadOptions = new[] { "FixedAssetArmortizations", "RefDate", "IncludeDetail" };
            request.RefDate = refDate;

            var response = FAArmortizationClient.GetFAArmortizations(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.FAArmortizations);
        }

        public IList<FixedAssetArmortizationDetailModel> GetFArmortizationByFAIncrements(long refId)
        {
            var request = PrepareRequest(new FAArmortizationRequest());
            request.LoadOptions = new[] { "FAArmortizationCheck" };
            request.RefId = refId;
            var response = FAArmortizationClient.GetFAArmortizations(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.FADecrementDetails);
        }

        /// <summary>
        /// Gets the fixed asset armortizations.
        /// </summary>
        /// <param name="refDate">The reference date.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<FixedAssetArmortizationModel> GetFixedAssetArmortizations(string refDate)
        {
            var request = PrepareRequest(new FAArmortizationRequest());
            request.LoadOptions = new[] { "FixedAssetArmortizations", "RefDate" };
            request.RefDate = refDate;

            var response = FAArmortizationClient.GetFAArmortizations(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.FAArmortizations);
        }

        /// <summary>
        /// Gets the fixed asset armortizations.
        /// </summary>
        /// <param name="refDate">The reference date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<FixedAssetArmortizationModel> GetFixedAssetArmortizations(string refDate, string currencyCode)
        {
            var request = PrepareRequest(new FAArmortizationRequest());
            request.LoadOptions = new[] { "FixedAssetArmortizations", "RefDate", "CurrencyCode" };
            request.RefDate = refDate;
            request.CurrencyCode = currencyCode;

            var response = FAArmortizationClient.GetFAArmortizations(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.FAArmortizations);
        }

        /// <summary>
        /// Gets the payment fixedAssetArmortization.
        /// </summary>
        /// <param name="fixedAssetArmortizationId">The payment fixedAssetArmortization identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public FixedAssetArmortizationModel GetFixedAssetArmortization(long fixedAssetArmortizationId)
        {
            var request = PrepareRequest(new FAArmortizationRequest());
            request.LoadOptions = new[] { "FixedAssetArmortization", "IncludeDetail" };
            request.RefId = fixedAssetArmortizationId;

            var response = FAArmortizationClient.GetFAArmortizations(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObject(response.FAArmortization);
        }

        /// <summary>
        /// Gets the fixed asset armortization.
        /// </summary>
        /// <param name="fixedAssetArmortizationId">The fixed asset armortization identifier.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="yearOfDeprecation">The year of deprecation.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public FixedAssetArmortizationModel GetFixedAssetArmortization(long fixedAssetArmortizationId, string currencyCode, int yearOfDeprecation)
        {
            var request = PrepareRequest(new FAArmortizationRequest());
            request.LoadOptions = new[] { "FixedAssetArmortization", "IncludeDetail", "AutoGenerate" };
            request.CurrencyCode = currencyCode;
            request.YearOfDeprecation = yearOfDeprecation;
            request.RefId = fixedAssetArmortizationId;

            var response = FAArmortizationClient.GetFAArmortizations(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObject(response.FAArmortization);
        }

        /// <summary>
        /// Adds the fixedAssetArmortization.
        /// </summary>
        /// <param name="fixedAssetArmortization">The fixedAssetArmortization.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public long AddFixedAssetArmortization(FixedAssetArmortizationModel fixedAssetArmortization)
        {
            var request = PrepareRequest(new FAArmortizationRequest());
            request.Action = PersistType.Insert;
            request.FAArmortization = Mapper.ToDataTransferObject(fixedAssetArmortization);

            var response = FAArmortizationClient.SetFAArmortizations(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RefId;
        }

        /// <summary>
        /// Updates the fixedAssetArmortization.
        /// </summary>
        /// <param name="fixedAssetArmortization">The fixedAssetArmortization.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public long UpdateFixedAssetArmortization(FixedAssetArmortizationModel fixedAssetArmortization)
        {
            var request = PrepareRequest(new FAArmortizationRequest());
            request.Action = PersistType.Update;
            request.FAArmortization = Mapper.ToDataTransferObject(fixedAssetArmortization);

            var response = FAArmortizationClient.SetFAArmortizations(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RefId;
        }

        /// <summary>
        /// Deletes the fixedAssetArmortization.
        /// </summary>
        /// <param name="fixedAssetArmortizationId">The fixedAssetArmortization identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public long DeleteFixedAssetArmortization(long fixedAssetArmortizationId)
        {
            var request = PrepareRequest(new FAArmortizationRequest());
            request.Action = PersistType.Delete;
            request.RefId = fixedAssetArmortizationId;

            var response = FAArmortizationClient.SetFAArmortizations(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RefId;
        }

        #endregion

        #region FixedAsset Decrement
        /// <summary>
        /// Gets the fixed asset decrements.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IList<FixedAssetDecrementModel> GetFixedAssetDecrements()
        {
            var request = PrepareRequest(new FADecrementRequest());
            request.LoadOptions = new[] { "FADecrements" };

            var response = FADecrementClient.GetFADecrements(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return VoucherMapper.FromDataTransferObjects(response.FADecrements);
        }

        public IList<FixedAssetDecrementDetailModel> GetFADecrementByFAIncrements(long refId)
        {
            var request = PrepareRequest(new FADecrementRequest());
            request.LoadOptions = new[] { "FADecrementCheck" };
            request.RefId = refId;
            var response = FADecrementClient.GetFADecrements(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return VoucherMapper.FromDataTransferObjects(response.FADecrementDetails);
        }

        /// <summary>
        /// Gets the fixed asset decrements by year of post date.
        /// </summary>
        /// <param name="refDate">The reference date.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IList<FixedAssetDecrementModel> GetFixedAssetDecrementsByYearOfPostDate(string refDate)
        {
            var request = PrepareRequest(new FADecrementRequest());
            request.LoadOptions = new[] { "FADecrements", "RefDate" };
            request.RefDate = refDate;

            var response = FADecrementClient.GetFADecrements(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return VoucherMapper.FromDataTransferObjects(response.FADecrements);
        }

        /// <summary>
        /// Gets the fixed asset decrement.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public FixedAssetDecrementModel GetFixedAssetDecrement(long refId)
        {
            var request = PrepareRequest(new FADecrementRequest());
            request.LoadOptions = new[] { "FADecrement", "IncludeDetail" };
            request.RefId = refId;

            var response = FADecrementClient.GetFADecrements(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return VoucherMapper.FromDataTransferObject(response.FADecrement);
        }

        /// <summary>
        /// Adds the fixed asset decrement.
        /// </summary>
        /// <param name="fixedAssetDecrement">The fixed asset decrement.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public long AddFixedAssetDecrement(FixedAssetDecrementModel fixedAssetDecrement, bool isAutoGenerateParallel)
        {
            var request = PrepareRequest(new FADecrementRequest());
            request.Action = PersistType.Insert;
            request.FADecrement = VoucherMapper.ToDataTransferObject(fixedAssetDecrement);

            var response = FADecrementClient.InsertFADecrement(request.FADecrement, isAutoGenerateParallel); //FADecrementClient.SetFADecrements(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RefId;
        }

        /// <summary>
        /// Adds the fixed asset decrements.
        /// </summary>
        /// <param name="fixedAssetDecrements">The fixed asset decrements.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public long AddFixedAssetDecrements(IList<FixedAssetDecrementModel> fixedAssetDecrements, bool isAutoGenerateParallel)
        {
            var request = PrepareRequest(new FADecrementRequest());
            request.Action = PersistType.Insert;
            request.FADecrements = VoucherMapper.ToDataTransferObjects(fixedAssetDecrements);

            var response = FADecrementClient.InsertFADecrement(request.FADecrements, isAutoGenerateParallel); //FADecrementClient.SetFADecrements(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RefId;
        }

        /// <summary>
        /// Updates the fixed asset decrement.
        /// </summary>
        /// <param name="fixedAssetDecrement">The fixed asset decrement.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public long UpdateFixedAssetDecrement(FixedAssetDecrementModel fixedAssetDecrement, bool isAutoGenerateParallel)
        {
            var request = PrepareRequest(new FADecrementRequest());
            request.Action = PersistType.Update;
            request.FADecrement = VoucherMapper.ToDataTransferObject(fixedAssetDecrement);

            var response = FADecrementClient.UpdateFADecrement(request.FADecrement, isAutoGenerateParallel); //FADecrementClient.SetFADecrements(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RefId;
        }

        /// <summary>
        /// Deletes the fixed asset decrement.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public long DeleteFixedAssetDecrement(long refId)
        {
            var request = PrepareRequest(new FADecrementRequest());
            request.Action = PersistType.Delete;
            request.RefId = refId;

            var response = FADecrementClient.DeleteFADecrement(refId); // FADecrementClient.SetFADecrements(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RefId;
        }
        #endregion

        #region FixedAsset Increment

        /// <summary>
        /// Gets the fixed asset decrements.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IList<FixedAssetIncrementModel> GetFixedAssetIncrements()
        {
            var request = PrepareRequest(new FAIncrementRequest());
            request.LoadOptions = new[] { "FAIncrements" };

            var response = FAIncrementClient.GetFAIncrements(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return VoucherMapper.FromDataTransferObjects(response.FAIncrements);
        }

        /// <summary>
        /// Gets the fixed asset decrements by year of post date.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="refDate">The reference date.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IList<FixedAssetIncrementModel> GetFixedAssetIncrementsByYearOfPostDate(int refTypeId, string refDate)
        {
            var request = PrepareRequest(new FAIncrementRequest());
            request.LoadOptions = new[] { "FAIncrements", "RefDate" };
            request.RefDate = refDate;
            var response = FAIncrementClient.GetFAIncrements(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return VoucherMapper.FromDataTransferObjects(response.FAIncrements);
        }

        /// <summary>
        /// Gets the fixed asset decrement.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public FixedAssetIncrementModel GetFixedAssetIncrement(long refId)
        {
            var request = PrepareRequest(new FAIncrementRequest());
            request.LoadOptions = new[] { "FAIncrement", "IncludeDetail" };
            request.RefId = refId;
            var response = FAIncrementClient.GetFAIncrements(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return VoucherMapper.FromDataTransferObject(response.FAIncrement);
        }

        public FixedAssetIncrementModel GetFixedAssetIncrementByRefNo(string refNo)
        {
            var request = PrepareRequest(new FAIncrementRequest());
            request.LoadOptions = new[] { "FAIncrement", "IncludeDetail", "RefNo" };
            request.RefNo = refNo;

            var response = FAIncrementClient.GetFAIncrements(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return VoucherMapper.FromDataTransferObject(response.FAIncrement);
        }
        /// <summary>
        /// Gets the deposits by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns>
        /// IList{DepositModel}.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IList<FixedAssetIncrementModel> GetFixedAssetIncrementsByRefTypeId(long refTypeId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds the fixed asset decrement.
        /// </summary>
        /// <param name="fixedAssetIncrement">The fixed asset decrement.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public long AddFixedAssetIncrement(FixedAssetIncrementModel fixedAssetIncrement, bool isAutoGenerateParallel)
        {
            var request = PrepareRequest(new FAIncrementRequest());
            request.Action = PersistType.Insert;
            request.FAIncrement = VoucherMapper.ToDataTransferObject(fixedAssetIncrement);

            var response = FAIncrementClient.InsertFAIncrement(request.FAIncrement, isAutoGenerateParallel); //FAIncrementClient.SetFAIncrements(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RefId;
        }

        /// <summary>
        /// Adds the fixed asset increments.
        /// </summary>
        /// <param name="fixedAssetIncrements">The fixed asset increments.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public long AddFixedAssetIncrements(IList<FixedAssetIncrementModel> fixedAssetIncrements, bool isAutoGenerateParallel)
        {
            var request = PrepareRequest(new FAIncrementRequest());
            request.Action = PersistType.Insert;
            request.FAIncrements = VoucherMapper.ToDataTransferObjects(fixedAssetIncrements);

            var response = FAIncrementClient.InsertFAIncrement(request.FAIncrements, isAutoGenerateParallel); //FAIncrementClient.SetFAIncrements(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RefId;
        }

        /// <summary>
        /// Updates the fixed asset decrement.
        /// </summary>
        /// <param name="fixedAssetIncrement">The fixed asset decrement.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public long UpdateFixedAssetIncrement(FixedAssetIncrementModel fixedAssetIncrement, bool isAutoGenerateParallel)
        {
            var request = PrepareRequest(new FAIncrementRequest());
            request.Action = PersistType.Update;
            request.FAIncrement = VoucherMapper.ToDataTransferObject(fixedAssetIncrement);

            var response = FAIncrementClient.UpdateFAIncrement(request.FAIncrement, isAutoGenerateParallel); //FAIncrementClient.SetFAIncrements(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RefId;
        }

        /// <summary>
        /// Deletes the fixed asset decrement.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public long DeleteFixedAssetIncrement(long refId)
        {
            var request = PrepareRequest(new FAIncrementRequest());
            request.Action = PersistType.Delete;
            request.RefId = refId;

            var response = FAIncrementClient.SetFAIncrements(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RefId;
        }

        #endregion

        #region FixedAsset Increment

        /// <summary>
        /// Gets the fixed asset decrements.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IList<FixedAssetLedgerModel> GetFixedAssetLedgerByFixedAssets(int fixedAssetId)
        {
            var request = PrepareRequest(new FixedAssetLedgerRequest());
            request.LoadOptions = new[] { "FixedAssetLedgers", "FixedAssetId" };
            request.FixedAssetId = fixedAssetId;
            var response = FixedAssetLedgerClient.GetFixedAssetLedgers(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.FixedAssetLedgers);
        }
        #endregion

        #region FixedAsset Increment

        /// <summary>
        /// Gets the fixed asset decrements.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IList<FixedAssetVoucherModel> GetFixedAssetVoucherByFixedAssets(int fixedAssetId)
        {
            var request = PrepareRequest(new FixedAssetVoucherRequest());
            request.LoadOptions = new[] { "FixedAssetVouchers", "FixedAssetId" };
            request.FixedAssetId = fixedAssetId;
            var response = FixedAssetVoucherClient.GetFixedAssetVouchers(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.FixedAssetVouchers);
        }
        #endregion

        #region GenneralVoucher

        public IList<GeneralVocherModel> GetGenverVoucherByRefTypeId(int refTypeId)
        {
            var request = PrepareRequest(new GeneralRequest());
            request.LoadOptions = new[] { "Generals", "RefType" };
            request.RefTypeId = refTypeId;

            var response = GeneralClient.GetGenerals(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return VoucherMapper.FromDataTransferObjects(response.Generals);

        }
        public IList<GeneralVocherModel> GetGenverVoucherByIsCapitalAllocate()
        {
            var request = PrepareRequest(new GeneralRequest());
            request.LoadOptions = new[] { "Generals", "IsCapitalAllocate" };
            var response = GeneralClient.GetGenerals(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return VoucherMapper.FromDataTransferObjects(response.Generals);

        }
        public GeneralVocherModel GetGeneralVoucher(long generalVoucherId)
        {

            var request = PrepareRequest(new GeneralRequest());
            request.LoadOptions = new[] { "General", "IncludeDetail" };
            request.RefId = generalVoucherId;
            var response = GeneralClient.GetGenerals(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return VoucherMapper.FromDataTransferObject(response.General);


        }
        public GeneralVocherModel GetGeneralVoucher(int refType, long refForeignId)
        {
            var result = GeneralClient.GetGeneralVoucher(refType, refForeignId);
            return VoucherMapper.FromDataTransferObject(result);
        }
        public long AddGeneralVoucher(GeneralVocherModel generalVoucher, bool isGenerateParelell)
        {
            var request = PrepareRequest(new GeneralRequest());
            request.Action = PersistType.Insert;
            request.IsConvertData = IsConvertData;
            request.IsGenerateParalell = isGenerateParelell;
            request.GeneralEntity = VoucherMapper.ToDataTransferObject(generalVoucher);
            var response = GeneralClient.SetGenerals(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }
        public long UpdateGeneralVoucher(GeneralVocherModel generalVoucher, bool isGenerateParelell)
        {
            var request = PrepareRequest(new GeneralRequest());
            request.Action = PersistType.Update;
            request.IsConvertData = IsConvertData;
            request.IsGenerateParalell = isGenerateParelell;
            request.GeneralEntity = VoucherMapper.ToDataTransferObject(generalVoucher);
            var response = GeneralClient.SetGenerals(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;

        }
        public long DeleteGeneralVoucher(long generalVoucherId)
        {
            var request = PrepareRequest(new GeneralRequest());
            request.Action = PersistType.Delete;
            request.RefId = generalVoucherId;

            var response = GeneralClient.SetGenerals(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RefId;


        }

        #endregion

        #region CaptitalAllocateVoucher

        /// <summary>
        /// Deletes the captital allocate voucher.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public long DeleteCaptitalAllocateVoucher(long refId)
        {
            var request = PrepareRequest(new CaptitalAllocateVoucherRequest());
            request.Action = PersistType.Delete;
            request.RefId = refId;

            var response = CaptitalAllocateVoucherClient.SetCaptitalAllocateVouchers(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;

        }

        /// <summary>
        /// Adds the g captital allocate voucher.
        /// </summary>
        /// <param name="captitalAllocateVoucher">The captital allocate voucher.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public long AddGCaptitalAllocateVoucher(CaptitalAllocateVoucherModel captitalAllocateVoucher)
        {
            var request = PrepareRequest(new CaptitalAllocateVoucherRequest());
            request.Action = PersistType.Insert;
            request.CaptitalAllocateVoucherEntity = Mapper.ToDataTransferObject(captitalAllocateVoucher);
            var response = CaptitalAllocateVoucherClient.SetCaptitalAllocateVouchers(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        /// <summary>
        /// Updates the captital allocate voucher.
        /// </summary>
        /// <param name="captitalAllocateVoucher">The captital allocate voucher.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public long UpdateCaptitalAllocateVoucher(CaptitalAllocateVoucherModel captitalAllocateVoucher)
        {
            var request = PrepareRequest(new CaptitalAllocateVoucherRequest());
            request.Action = PersistType.Update;
            request.CaptitalAllocateVoucherEntity = Mapper.ToDataTransferObject(captitalAllocateVoucher);
            var response = CaptitalAllocateVoucherClient.SetCaptitalAllocateVouchers(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }


        /// <summary>
        /// Captitals the allocate vouchers to date to from date.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="activityId">The activity identifier.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<CaptitalAllocateVoucherModel> CaptitalAllocateVouchersToDateToFromDate(DateTime fromDate, DateTime toDate, int activityId, string currencyCode)
        {
            var request = PrepareRequest(new CaptitalAllocateVoucherRequest());
            request.LoadOptions = new[] { "CaptitalAllocateVouchers" };
            request.FromDate = fromDate;
            request.ToDate = toDate;
            request.CurrencyCode = currencyCode;
            request.ActivityId = activityId;
            var response = CaptitalAllocateVoucherClient.GetCaptitalAllocateVouchersFromDateToToDate(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return Mapper.FromDataTransferObjects(response.GetCaptitalAllocateVouchers);
        }


        public IList<CaptitalAllocateVoucherModel> CaptitalAllocateVouchersToDateToFromDateForUpdate(DateTime fromDate, DateTime toDate, string currencyCode, int activityId, int refTypeId, long refId)
        {

            var request = PrepareRequest(new CaptitalAllocateVoucherRequest());
            request.LoadOptions = new[] { "CaptitalAllocateVouchers" };
            request.FromDate = fromDate;
            request.ToDate = toDate;
            request.CurrencyCode = currencyCode;
            request.RefId = refId;
            request.ActivityId = activityId;
            request.RefTypeId = refTypeId;
            var response = CaptitalAllocateVoucherClient.GetCaptitalAllocateVouchersFromDateToToDateForUpdate(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return Mapper.FromDataTransferObjects(response.GetCaptitalAllocateVouchers);

        }

        /// <summary>
        /// Captitals the allocate vouchers by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<CaptitalAllocateVoucherModel> CaptitalAllocateVouchersByRefId(long refId)
        {
            var request = PrepareRequest(new CaptitalAllocateVoucherRequest());
            request.LoadOptions = new[] { "CaptitalAllocateVouchers" };
            request.RefId = refId;
            var response = CaptitalAllocateVoucherClient.GetCaptitalAllocateVouchersByRefId(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return Mapper.FromDataTransferObjects(response.GetCaptitalAllocateVouchers);
        }


        #endregion

        #region AccountTranferVourcher
        /// <summary>
        /// Deletes the account tranfer voucher.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public long DeleteAccountTranferVoucher(long refId)
        {
            var request = PrepareRequest(new AccountTranferVourcherRequest());
            request.Action = PersistType.Delete;
            request.RefId = refId;

            var response = AccountTranferVoucherClient.SetAccountTranferVouchers(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        /// <summary>
        /// Adds the account tranfer voucher.
        /// </summary>
        /// <param name="accountTranferVourcher">The account tranfer vourcher.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public long AddAccountTranferVoucher(AccountTranferVourcherModel accountTranferVourcher)
        {
            var request = PrepareRequest(new AccountTranferVourcherRequest());
            request.Action = PersistType.Insert;
            request.AccountTranferVourcherEntity = Mapper.ToDataTransferObject(accountTranferVourcher);
            var response = AccountTranferVoucherClient.SetAccountTranferVouchers(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        /// <summary>
        /// Accounts the tranfer vouchers by posted date and currency code.
        /// </summary>
        /// <param name="postedDate">The posted date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<AccountTranferVourcherModel> AccountTranferVouchersByPostedDateAndCurrencyCode(DateTime postedDate, string currencyCode)
        {
            var request = PrepareRequest(new AccountTranferVourcherRequest());
            request.LoadOptions = new[] { "AccountTranferVourchers" };
            request.PostedDate = postedDate;
            request.CurrencyCode = currencyCode;
            var response = AccountTranferVoucherClient.GetAccountTranferVourchersByPostedDateAndCurrencyCode(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return Mapper.FromDataTransferObjects(response.GetAccountTranferVourchers);
        }

        public IList<AccountTranferVourcherModel> AccountTranferVouchersByEdit(DateTime postedDate, string currencyCode, int refTypeId)
        {
            var request = PrepareRequest(new AccountTranferVourcherRequest());
            request.LoadOptions = new[] { "AccountTranferVourchers" };
            request.PostedDate = postedDate;
            request.CurrencyCode = currencyCode;
            request.RefTypeId = refTypeId;
            var response = AccountTranferVoucherClient.GetAccountTranferVourchersByEdit(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return Mapper.FromDataTransferObjects(response.GetAccountTranferVourchers);
        }






        /// <summary>
        /// Accounts the tranfer vouchers by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<AccountTranferVourcherModel> AccountTranferVouchersByRefId(long refId)
        {
            var request = PrepareRequest(new AccountTranferVourcherRequest());
            request.LoadOptions = new[] { "AccountTranferVourchers" };
            request.RefId = refId;
            var response = AccountTranferVoucherClient.GetAccountTranferVourchersByRefId(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return Mapper.FromDataTransferObjects(response.GetAccountTranferVourchers);
        }
        #endregion

        #region OpeningAccountEntry

        /// <summary>
        /// Gets the payment fixedAssetArmortizations.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<OpeningAccountEntryModel> GetOpeningAccountEntries()
        {
            var request = PrepareRequest(new OpeningAccountEntryRequest());
            request.LoadOptions = new[] { "OpeningAccountEntries" };

            var response = OpeningAccountEntryClient.GetOpeningAccountEntries(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.OpeningAccountEntries);
        }

        /// <summary>
        /// Gets the opening account entry.
        /// </summary>
        /// <param name="accountCode">The account code.</param>
        /// <returns></returns>
        public OpeningAccountEntryModel GetOpeningAccountEntry(string accountCode)
        {
            var request = PrepareRequest(new OpeningAccountEntryRequest());
            request.LoadOptions = new[] { "OpeningAccountEntry", "IncludeDetail" };
            request.AccountCode = accountCode;

            var response = OpeningAccountEntryClient.GetOpeningAccountEntries(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObject(response.OpeningAccountEntry);
        }

        /// <summary>
        /// Updates the opening account entry.
        /// </summary>
        /// <param name="openingAccountEntry">The opening account entry.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException">
        /// </exception>
        public long UpdateOpeningAccountEntry(OpeningAccountEntryModel openingAccountEntry)
        {
            var request = PrepareRequest(new OpeningAccountEntryRequest());
            request.LoadOptions = new[] { "OpeningAccountEntryDetails" };
            request.Action = PersistType.Update;
            request.OpeningAccountEntry = Mapper.ToDataTransferObject(openingAccountEntry);

            var response = OpeningAccountEntryClient.SetOpeningAccountEntries(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RefId;
        }

        #endregion

        #region OpeningAccountEntryDetail

        /// <summary>
        /// Gets the opening account entry details.
        /// </summary>
        /// <param name="accountCode">The account code.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<OpeningAccountEntryDetailModel> GetOpeningAccountEntryDetails(string accountCode)
        {
            var request = PrepareRequest(new OpeningAccountEntryDetailRequest());
            request.LoadOptions = new[] { "OpeningAccountEntryDetails" };
            request.AccountCode = accountCode;

            var response = OpeningAccountEntryDetailClient.GetOpeningAccountEntryDetails(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.OpeningAccountEntryDetails);
        }

        /// <summary>
        /// Adds the opening account entry details.
        /// </summary>
        /// <param name="openingAccountEntryDetails">The opening account entry details.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException">
        /// </exception>
        public long AddOpeningAccountEntryDetails(IList<OpeningAccountEntryDetailModel> openingAccountEntryDetails)
        {
            var request = PrepareRequest(new OpeningAccountEntryDetailRequest());
            request.LoadOptions = new[] { "OpeningAccountEntryDetails" };
            request.Action = PersistType.Insert;
            request.OpeningAccountEntryDetails = Mapper.ToDataTransferObjects(openingAccountEntryDetails);

            var response = OpeningAccountEntryDetailClient.SetOpeningAccountEntryDetails(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RefId;
        }

        /// <summary>
        /// Updates the opening account entry details.
        /// </summary>
        /// <param name="openingAccountEntryDetails">The opening account entry details.</param>


        /// <returns></returns>
        /// <exception cref="System.ApplicationException">
        /// </exception>
        public long UpdateOpeningAccountEntryDetails(IList<OpeningAccountEntryDetailModel> openingAccountEntryDetails)
        {
            var request = PrepareRequest(new OpeningAccountEntryDetailRequest());
            request.LoadOptions = new[] { "OpeningAccountEntryDetails" };
            request.Action = PersistType.Update;
            request.OpeningAccountEntryDetails = Mapper.ToDataTransferObjects(openingAccountEntryDetails);

            var response = OpeningAccountEntryDetailClient.SetOpeningAccountEntryDetails(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RefId;
        }



        #endregion

        #region Search
        public IList<BusinessObjects.Search.SearchModel> GetSearch(string whereClause, string fromDate, string toDate, string currencyCode, string departmentCode, string fixedAssetCode, string budgetGroupCode)
        {
            var request = PrepareRequest(new SearchRequest());
            //   request.LoadOptions = new[] { "ItemTransactions", "RefType" };
            request.WhereClause = whereClause;
            request.FromDate = fromDate;
            request.ToDate = toDate;
            request.CurrencyCode = currencyCode;
            request.DepartmentCode = departmentCode;
            request.FixedAssetCode = fixedAssetCode;
            request.BudgetGroupCode = budgetGroupCode;
            var response = SearchClient.GetSearchs(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.Searchs);
        }
        #endregion

        #region Common Members


        /// <summary>
        /// Gets the identifier by code.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public int? GetIdByCode(string query)
        {
            var request = PrepareRequest(new CommonRequest());
            request.LoadOptions = new[] { "QueryString" };
            request.QueryString = query;
            var response = CommonFacadeClient.GetIdByCode(request);
            return response.Id;
        }

        /// <summary>
        /// Gets the identifier by code.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="idFieldName">Name of the identifier field.</param>
        /// <param name="codeFieldName">Name of the code field.</param>
        /// <param name="codeValueField">The code value field.</param>
        /// <returns></returns>
        public int? GetIdByCode(string tableName, string idFieldName, string codeFieldName, string codeValueField)
        {
            var request = PrepareRequest(new CommonRequest());
            request.LoadOptions = new[] { "Parameter" };
            request.TableName = tableName;
            request.IdFieldName = idFieldName;
            request.CodeFieldName = codeFieldName;
            request.CodeFieldValue = codeValueField;

            var response = CommonFacadeClient.GetIdByCode(request);
            return response.Id;
        }

        /// <summary>
        /// Resets the automatic increment.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="startIncrementNumber">The start increment number.</param>
        /// <returns></returns>
        public bool ResetAutoIncrement(string tableName, int startIncrementNumber)
        {
            var request = PrepareRequest(new CommonRequest());
            request.TableName = tableName;
            request.StartIncrementNumber = startIncrementNumber;

            var response = CommonFacadeClient.ResetAutoIncrement(request);
            return response.ResetIncrementSuccess;
        }

        /// <summary>
        /// Updates the amount exchange.
        /// </summary>
        /// <param name="exchangeRate">The exchange rate.</param>
        /// <param name="currencyDecimalDigits">The currency decimal digits.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns></returns>
        public int UpdateAmountExchange(decimal exchangeRate, short currencyDecimalDigits, DateTime fromDate,
            DateTime toDate)
        {
            var request = PrepareRequest(new CommonRequest());
            request.ExchangeRate = exchangeRate;
            request.CurrencyDecimalDigits = currencyDecimalDigits;
            request.FromDate = fromDate;
            request.ToDate = toDate;

            var response = CommonFacadeClient.UpdateAmountExchange(request);
            return response.RowsAffected;
        }

        #endregion

        #region Role

        /// <summary>
        /// Gets the roles.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<RoleModel> GetRoles()
        {
            var request = PrepareRequest(new RoleRequest());
            request.LoadOptions = new[] { "Roles" };

            var response = RoleClient.GetRoles(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.Roles);
        }

        /// <summary>
        /// Gets the roles.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<RoleModel> GetRoles(bool isActive)
        {
            var request = PrepareRequest(new RoleRequest());
            request.LoadOptions = new[] { "Roles" };
            request.IsActive = isActive;

            var response = RoleClient.GetRoles(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.Roles);
        }

        /// <summary>
        /// Gets the role.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public RoleModel GetRole(int roleId)
        {
            var request = PrepareRequest(new RoleRequest());
            request.LoadOptions = new[] { "Role", "RoleSite" };
            request.RoleId = roleId;

            var response = RoleClient.GetRoles(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObject(response.Role);
        }

        /// <summary>
        /// Adds the role.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int AddRole(RoleModel role)
        {
            var request = PrepareRequest(new RoleRequest());
            request.Action = PersistType.Insert;
            request.Role = Mapper.ToDataTransferObject(role);

            var response = RoleClient.SetRoles(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RoleId;
        }

        /// <summary>
        /// Updates the role.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int UpdateRole(RoleModel role)
        {
            var request = PrepareRequest(new RoleRequest());
            request.Action = PersistType.Update;
            request.Role = Mapper.ToDataTransferObject(role);

            var response = RoleClient.SetRoles(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RoleId;
        }

        /// <summary>
        /// Deletes the role.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int DeleteRole(int roleId)
        {
            var request = PrepareRequest(new RoleRequest());
            request.Action = PersistType.Delete;
            request.RoleId = roleId;

            var response = RoleClient.SetRoles(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RowsAffected;
        }

        #endregion

        #region Site

        /// <summary>
        /// Gets the sites.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<SiteModel> GetSites()
        {
            var request = PrepareRequest(new SiteRequest());
            request.LoadOptions = new[] { "Sites" };

            var response = SiteClient.GetSites(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.Sites);
        }

        /// <summary>
        /// Gets the sites.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<SiteModel> GetSites(bool isActive)
        {
            var request = PrepareRequest(new SiteRequest());
            request.LoadOptions = new[] { "Sites", "Active", "Permissions" };
            request.IsActive = isActive;

            var response = SiteClient.GetSites(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.Sites);
        }

        /// <summary>
        /// Gets the site.
        /// </summary>
        /// <param name="siteId">The site identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public SiteModel GetSite(int siteId)
        {
            var request = PrepareRequest(new SiteRequest());
            request.LoadOptions = new[] { "Site", "PermissionSite" };
            request.SiteId = siteId;

            var response = SiteClient.GetSites(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObject(response.Site);
        }

        /// <summary>
        /// Adds the site.
        /// </summary>
        /// <param name="site">The site.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int AddSite(SiteModel site)
        {
            var request = PrepareRequest(new SiteRequest());
            request.Action = PersistType.Insert;
            request.Site = Mapper.ToDataTransferObject(site);

            var response = SiteClient.SetSites(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.SiteId;
        }

        /// <summary>
        /// Updates the site.
        /// </summary>
        /// <param name="site">The site.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int UpdateSite(SiteModel site)
        {
            var request = PrepareRequest(new SiteRequest());
            request.Action = PersistType.Update;
            request.Site = Mapper.ToDataTransferObject(site);

            var response = SiteClient.SetSites(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.SiteId;
        }

        /// <summary>
        /// Deletes the site.
        /// </summary>
        /// <param name="siteId">The site identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int DeleteSite(int siteId)
        {
            var request = PrepareRequest(new SiteRequest());
            request.Action = PersistType.Delete;
            request.SiteId = siteId;

            var response = SiteClient.SetSites(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RowsAffected;
        }

        #endregion

        #region Permission

        /// <summary>
        /// Gets the permissions.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<PermissionModel> GetPermissions()
        {
            var request = PrepareRequest(new PermissionRequest());
            request.LoadOptions = new[] { "Permissions" };

            var response = PermissionClient.GetPermissions(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.Permissions);
        }

        /// <summary>
        /// Gets the permissions.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<PermissionModel> GetPermissions(bool isActive)
        {
            var request = PrepareRequest(new PermissionRequest());
            request.LoadOptions = new[] { "Permissions", "Active" };
            request.IsActive = isActive;

            var response = PermissionClient.GetPermissions(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.Permissions);
        }

        /// <summary>
        /// Gets the permission.
        /// </summary>
        /// <param name="permissionId">The permission identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public PermissionModel GetPermission(int permissionId)
        {
            var request = PrepareRequest(new PermissionRequest());
            request.LoadOptions = new[] { "Permission" };
            request.PermissionId = permissionId;

            var response = PermissionClient.GetPermissions(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObject(response.Permission);
        }

        /// <summary>
        /// Adds the permission.
        /// </summary>
        /// <param name="permission">The permission.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int AddPermission(PermissionModel permission)
        {
            var request = PrepareRequest(new PermissionRequest());
            request.Action = PersistType.Insert;
            request.Permission = Mapper.ToDataTransferObject(permission);

            var response = PermissionClient.SetPermissions(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.PermissionId;
        }

        /// <summary>
        /// Updates the permission.
        /// </summary>
        /// <param name="permission">The permission.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int UpdatePermission(PermissionModel permission)
        {
            var request = PrepareRequest(new PermissionRequest());
            request.Action = PersistType.Update;
            request.Permission = Mapper.ToDataTransferObject(permission);

            var response = PermissionClient.SetPermissions(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.PermissionId;
        }

        /// <summary>
        /// Deletes the permission.
        /// </summary>
        /// <param name="permissionId">The permission identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int DeletePermission(int permissionId)
        {
            var request = PrepareRequest(new PermissionRequest());
            request.Action = PersistType.Delete;
            request.PermissionId = permissionId;

            var response = PermissionClient.SetPermissions(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RowsAffected;
        }

        #endregion

        #region UserProfile

        /// <summary>
        /// Gets the userProfiles.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<UserProfileModel> GetUserProfiles()
        {
            var request = PrepareRequest(new UserProfileRequest());
            request.LoadOptions = new[] { "UserProfiles" };

            var response = UserProfileClient.GetUserProfiles(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.UserProfiles);
        }

        /// <summary>
        /// Gets the userProfiles.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<UserProfileModel> GetUserProfiles(bool isActive)
        {
            var request = PrepareRequest(new UserProfileRequest());
            request.LoadOptions = new[] { "UserProfiles" };
            request.IsActive = isActive;

            var response = UserProfileClient.GetUserProfiles(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.UserProfiles);
        }

        /// <summary>
        /// Gets the userProfile.
        /// </summary>
        /// <param name="userProfileId">The userProfile identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public UserProfileModel GetUserProfile(int userProfileId)
        {
            var request = PrepareRequest(new UserProfileRequest());
            request.LoadOptions = new[] { "UserProfile", "UserProfileSite" };
            request.UserProfileId = userProfileId;

            var response = UserProfileClient.GetUserProfiles(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObject(response.UserProfile);
        }

        /// <summary>
        /// Gets the name of the user profile by user profile.
        /// </summary>
        /// <param name="userProfileName">Name of the user profile.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public UserProfileModel GetUserProfileByUserProfileName(string userProfileName, string password)
        {
            var request = PrepareRequest(new UserProfileRequest());
            request.LoadOptions = new[] { "UserProfile", "UserProfileName" };
            request.UserProfileName = userProfileName;
            request.Password = password;

            var response = UserProfileClient.GetUserProfiles(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObject(response.UserProfile);
        }

        /// <summary>
        /// Adds the userProfile.
        /// </summary>
        /// <param name="userProfile">The userProfile.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int AddUserProfile(UserProfileModel userProfile)
        {
            var request = PrepareRequest(new UserProfileRequest());
            request.Action = PersistType.Insert;
            request.UserProfile = Mapper.ToDataTransferObject(userProfile);

            var response = UserProfileClient.SetUserProfiles(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.UserProfileId;
        }

        /// <summary>
        /// Updates the userProfile.
        /// </summary>
        /// <param name="userProfile">The userProfile.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int UpdateUserProfile(UserProfileModel userProfile)
        {
            var request = PrepareRequest(new UserProfileRequest());
            request.Action = PersistType.Update;
            request.UserProfile = Mapper.ToDataTransferObject(userProfile);

            var response = UserProfileClient.SetUserProfiles(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.UserProfileId;
        }

        /// <summary>
        /// Deletes the userProfile.
        /// </summary>
        /// <param name="userProfileId">The userProfile identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int DeleteUserProfile(int userProfileId)
        {
            var request = PrepareRequest(new UserProfileRequest());
            request.Action = PersistType.Delete;
            request.UserProfileId = userProfileId;

            var response = UserProfileClient.SetUserProfiles(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RowsAffected;
        }

        public int ChangePassword(string userProfileName, string oldPassword, string newPassword)
        {
            var request = PrepareRequest(new UserProfileRequest());
            request.Action = PersistType.Scalar;
            request.UserProfileName = userProfileName;
            request.OldPassword = oldPassword;
            request.Password = newPassword;

            var response = UserProfileClient.SetUserProfiles(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RowsAffected;
        }

        #endregion

        #region OpeningFixedAssetEntry


        /// <summary>
        /// Getses this instance.
        /// </summary>
        /// <returns>
        /// List{OpeningFixedAssetEntryModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<OpeningFixedAssetEntryModel> GetOpeningFixedAssetEntries()
        {
            var request = PrepareRequest(new OpeningFixedAssetEntryRequest());
            request.LoadOptions = new[] { "OpeningFixedAssetEntries" };
            var response = OpeningFixedAssetEntryClient.GetOpeningFixedAssetEntries(request);

            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return DictionaryMapper.FromDataTransferObjects(response.OpeningFixedAssetEntries);
        }

        public IList<OpeningFixedAssetEntryModel> GetOpeningFixedAssetEntries(string accountCode)
        {
            var request = PrepareRequest(new OpeningFixedAssetEntryRequest());
            request.LoadOptions = new[] { "OpeningFixedAssetEntry", "IncludeDetail" };
            request.AccountNumber = accountCode;
            //request.RefId = refId;
            var response = OpeningFixedAssetEntryClient.GetOpeningFixedAssetEntries(request);

            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return DictionaryMapper.FromDataTransferObjects(response.OpeningFixedAssetEntries);

        }


        /// <summary>
        /// Inserts the specified openingFixedAssetEntry.
        /// </summary>
        /// <param name="openingFixedAssetEntry">The openingFixedAssetEntry.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public long InsertOpeningFixedAssetEntry(OpeningFixedAssetEntryModel openingFixedAssetEntry)
        {
            var request = PrepareRequest(new OpeningFixedAssetEntryRequest());
            request.Action = PersistType.Insert;
            request.OpeningFixedAssetEntry = DictionaryMapper.ToDataTransferObject(openingFixedAssetEntry);

            var response = OpeningFixedAssetEntryClient.SetOpeningFixedAssetEntries(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        /// <summary>
        /// Adds the fixed asset increments.
        /// </summary>
        /// <param name="openingFixedAssetEntries">The opening fixed asset entries.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public long InsertOpeningFixedAssetEntries(IList<OpeningFixedAssetEntryModel> openingFixedAssetEntries)
        {
            var request = PrepareRequest(new OpeningFixedAssetEntryRequest());
            request.Action = PersistType.Insert;

            request.OpeningFixedAssetEntries = DictionaryMapper.ToDataTransferObjects(openingFixedAssetEntries);
            var response = OpeningFixedAssetEntryClient.SetOpeningFixedAssetEntries(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        /// <summary>
        /// Updates the specified openingFixedAssetEntry.
        /// </summary>
        /// <param name="openingAccountEntries"></param>
        /// <param name="fixedAssetId"></param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public long UpdateOpeningFixedAssetEntries(IList<OpeningFixedAssetEntryModel> openingAccountEntries, int fixedAssetId)
        {
            var request = PrepareRequest(new OpeningFixedAssetEntryRequest());
            request.Action = PersistType.Update;
            request.FixedAssetId = fixedAssetId;
            request.OpeningFixedAssetEntries = DictionaryMapper.ToDataTransferObjects(openingAccountEntries);
            var response = OpeningFixedAssetEntryClient.SetOpeningFixedAssetEntries(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        /// <summary>
        /// Updates the specified openingFixedAssetEntry.
        /// </summary>
        /// <returns>
        /// System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public long UpdateOpeningFixedAssetEntriesDetail(IList<OpeningFixedAssetEntryModel> openingAccountEntries)
        {
            var request = PrepareRequest(new OpeningFixedAssetEntryRequest());
            request.Action = PersistType.Update;
            request.OpeningFixedAssetEntries = DictionaryMapper.ToDataTransferObjects(openingAccountEntries);
            var response = OpeningFixedAssetEntryClient.SetOpeningFixedAssetEntries(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        /// <summary>
        /// Deletes the openingFixedAssetEntry.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int DeleteOpeningFixedAssetEntry(int fixedAssetId)
        {
            var request = PrepareRequest(new OpeningFixedAssetEntryRequest());
            request.Action = PersistType.Delete;
            request.FixedAssetId = fixedAssetId;

            var response = OpeningFixedAssetEntryClient.SetOpeningFixedAssetEntries(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RowsAffected;
        }



        #endregion

        #region OpeningInventoryEntry

        /// <summary>
        /// Gets the payment fixedAssetArmortizations.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<OpeningInventoryEntryModel> GetOpeningInventoryEntries()
        {
            var request = PrepareRequest(new OpeningInventoryEntryRequest());
            request.LoadOptions = new[] { "OpeningInventoryEntries" };

            var response = OpeningInventoryEntryClient.GetOpeningInventoryEntries(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.OpeningInventoryEntries);
        }

        /// <summary>
        /// Gets the opening account entry.
        /// </summary>
        /// <param name="accountCode">The account code.</param>
        /// <returns></returns>
        public IList<OpeningInventoryEntryModel> GetOpeningInventoryEntries(string accountCode)
        {
            var request = PrepareRequest(new OpeningInventoryEntryRequest());
            request.LoadOptions = new[] { "OpeningInventoryEntry", "IncludeDetail" };
            request.AccountNumber = accountCode;

            var response = OpeningInventoryEntryClient.GetOpeningInventoryEntries(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            //??? Trar veef lisst
            return Mapper.FromDataTransferObjects(response.OpeningInventoryEntries);
        }

        /// <summary>
        /// Updates the opening account entry.
        /// </summary>
        /// <param name="openingInventoryEntry">The opening account entry.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException">
        /// </exception>
        public long UpdateOpeningInventoryEntry(List<OpeningInventoryEntryModel> openingInventoryEntry)
        {
            var request = PrepareRequest(new OpeningInventoryEntryRequest());
            request.LoadOptions = new[] { "OpeningInventoryEntryDetails" };
            request.Action = PersistType.Update;
            request.OpeningInventoryEntries = Mapper.ToDataTransferObjects(openingInventoryEntry).ToList();

            var response = OpeningInventoryEntryClient.SetOpeningInventoryEntries(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RefId;
        }

        #endregion

        #region EmployeeLeasing

        /// <summary>
        /// Gets the employeeLeasings.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<EmployeeLeasingModel> GetEmployeeLeasings()
        {
            var request = PrepareRequest(new EmployeeLeasingRequest());
            request.LoadOptions = new[] { "EmployeeLeasings" };

            var response = EmployeeLeasingClient.GetEmployeeLeasings(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.EmployeeLeasings);
        }

        /// <summary>
        /// Gets the employee leasings.
        /// </summary>
        /// <param name="isLeasing">if set to <c>true</c> [is leasing].</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<EmployeeLeasingModel> GetEmployeeLeasings(bool isLeasing)
        {
            var request = PrepareRequest(new EmployeeLeasingRequest());
            request.LoadOptions = new[] { "EmployeeLeasings", "IsLeasing" };
            request.IsLeasing = isLeasing;

            var response = EmployeeLeasingClient.GetEmployeeLeasings(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.EmployeeLeasings);
        }

        /// <summary>
        /// Gets the employeeLeasings active.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<EmployeeLeasingModel> GetEmployeeLeasingsActive()
        {
            var request = PrepareRequest(new EmployeeLeasingRequest());
            request.LoadOptions = new[] { "EmployeeLeasings", "IsActive" };

            var response = EmployeeLeasingClient.GetEmployeeLeasings(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.EmployeeLeasings);
        }

        /// <summary>
        /// Gets the employeeLeasings non active.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<EmployeeLeasingModel> GetEmployeeLeasingsNonActive()
        {
            var request = PrepareRequest(new EmployeeLeasingRequest());
            request.LoadOptions = new[] { "EmployeeLeasings", "NonActive" };

            var response = EmployeeLeasingClient.GetEmployeeLeasings(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.EmployeeLeasings);
        }

        /// <summary>
        /// Gets the employeeLeasing.
        /// </summary>
        /// <param name="employeeLeasingId">The employeeLeasing identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public EmployeeLeasingModel GetEmployeeLeasing(int employeeLeasingId)
        {
            var request = PrepareRequest(new EmployeeLeasingRequest());
            request.LoadOptions = new[] { "EmployeeLeasing" };
            request.EmployeeLeasingId = employeeLeasingId;

            var response = EmployeeLeasingClient.GetEmployeeLeasings(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObject(response.EmployeeLeasing);
        }

        /// <summary>
        /// Adds the employeeLeasing.
        /// </summary>
        /// <param name="employeeLeasing">The employeeLeasing.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int AddEmployeeLeasing(EmployeeLeasingModel employeeLeasing)
        {
            var request = PrepareRequest(new EmployeeLeasingRequest());
            request.Action = PersistType.Insert;
            request.EmployeeLeasing = Mapper.ToDataTransferObject(employeeLeasing);

            var response = EmployeeLeasingClient.SetEmployeeLeasings(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.EmployeeLeasingId;
        }

        /// <summary>
        /// Updates the employeeLeasing.
        /// </summary>
        /// <param name="employeeLeasing">The employeeLeasing.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int UpdateEmployeeLeasing(EmployeeLeasingModel employeeLeasing)
        {
            var request = PrepareRequest(new EmployeeLeasingRequest());
            request.Action = PersistType.Update;
            request.EmployeeLeasing = Mapper.ToDataTransferObject(employeeLeasing);

            var response = EmployeeLeasingClient.SetEmployeeLeasings(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.EmployeeLeasingId;
        }

        /// <summary>
        /// Deletes the employeeLeasing.
        /// </summary>
        /// <param name="employeeLeasingId">The employeeLeasing identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int DeleteEmployeeLeasing(int employeeLeasingId)
        {
            var request = PrepareRequest(new EmployeeLeasingRequest());
            request.Action = PersistType.Delete;
            request.EmployeeLeasingId = employeeLeasingId;

            var response = EmployeeLeasingClient.SetEmployeeLeasings(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RowsAffected;
        }

        #endregion

        #region Building

        /// <summary>
        /// Gets the buildings.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<BuildingModel> GetBuildings()
        {
            var request = PrepareRequest(new BuildingRequest());
            request.LoadOptions = new[] { "Buildings" };

            var response = BuildingClient.GetBuildings(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.Buildings);
        }

        /// <summary>
        /// Gets the buildings active.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<BuildingModel> GetBuildingsActive()
        {
            var request = PrepareRequest(new BuildingRequest());
            request.LoadOptions = new[] { "Buildings", "IsActive" };

            var response = BuildingClient.GetBuildings(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.Buildings);
        }

        /// <summary>
        /// Gets the buildings non active.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<BuildingModel> GetBuildingsNonActive()
        {
            var request = PrepareRequest(new BuildingRequest());
            request.LoadOptions = new[] { "Buildings", "NonActive" };

            var response = BuildingClient.GetBuildings(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.Buildings);
        }

        /// <summary>
        /// Gets the building.
        /// </summary>
        /// <param name="buildingId">The building identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public BuildingModel GetBuilding(int buildingId)
        {
            var request = PrepareRequest(new BuildingRequest());
            request.LoadOptions = new[] { "Building" };
            request.BuildingId = buildingId;

            var response = BuildingClient.GetBuildings(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObject(response.Building);
        }

        /// <summary>
        /// Adds the building.
        /// </summary>
        /// <param name="building">The building.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int AddBuilding(BuildingModel building)
        {
            var request = PrepareRequest(new BuildingRequest());
            request.Action = PersistType.Insert;
            request.Building = Mapper.ToDataTransferObject(building);

            var response = BuildingClient.SetBuildings(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.BuildingId;
        }

        /// <summary>
        /// Updates the building.
        /// </summary>
        /// <param name="building">The building.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int UpdateBuilding(BuildingModel building)
        {
            var request = PrepareRequest(new BuildingRequest());
            request.Action = PersistType.Update;
            request.Building = Mapper.ToDataTransferObject(building);

            var response = BuildingClient.SetBuildings(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.BuildingId;
        }

        /// <summary>
        /// Deletes the building.
        /// </summary>
        /// <param name="buildingId">The building identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int DeleteBuilding(int buildingId)
        {
            var request = PrepareRequest(new BuildingRequest());
            request.Action = PersistType.Delete;
            request.BuildingId = buildingId;

            var response = BuildingClient.SetBuildings(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RowsAffected;
        }

        #endregion

        #region BudgetSourceCategory

        /// <summary>
        /// Gets the budget source categories.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<BudgetSourceCategoryModel> GetBudgetSourceCategories()
        {
            var request = PrepareRequest(new BudgetSourceCategoryRequest());
            request.LoadOptions = new[] { "BudgetSourceCategories" };

            var response = BudgetSourceCategoryClient.GetBudgetSourceCategories(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.BudgetSourceCategories);
        }

        /// <summary>
        /// Gets the budget source categories active.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<BudgetSourceCategoryModel> GetBudgetSourceCategoriesActive()
        {
            var request = PrepareRequest(new BudgetSourceCategoryRequest());
            request.LoadOptions = new[] { "BudgetSourceCategories", "IsActive" };

            var response = BudgetSourceCategoryClient.GetBudgetSourceCategories(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.BudgetSourceCategories);
        }

        /// <summary>
        /// Gets the budget source categories non active.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<BudgetSourceCategoryModel> GetBudgetSourceCategoriesNonActive()
        {
            var request = PrepareRequest(new BudgetSourceCategoryRequest());
            request.LoadOptions = new[] { "BudgetSourceCategories", "NonActive" };

            var response = BudgetSourceCategoryClient.GetBudgetSourceCategories(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.BudgetSourceCategories);
        }

        /// <summary>
        /// Gets the budgetSourceCategory.
        /// </summary>
        /// <param name="budgetSourceCategoryId">The budgetSourceCategory identifier.</param>
        /// <returns>
        /// BudgetSourceCategoryModel.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public BudgetSourceCategoryModel GetBudgetSourceCategory(int budgetSourceCategoryId)
        {
            var request = PrepareRequest(new BudgetSourceCategoryRequest());
            request.LoadOptions = new[] { "BudgetSourceCategory" };
            request.BudgetSourceCategoryId = budgetSourceCategoryId;

            var response = BudgetSourceCategoryClient.GetBudgetSourceCategories(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObject(response.BudgetSourceCategory);
        }

        /// <summary>
        /// Adds the budgetSourceCategory.
        /// </summary>
        /// <param name="budgetSourceCategory">The budgetSourceCategory.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int AddBudgetSourceCategory(BudgetSourceCategoryModel budgetSourceCategory)
        {
            var request = PrepareRequest(new BudgetSourceCategoryRequest());
            request.Action = PersistType.Insert;
            request.BudgetSourceCategory = Mapper.ToDataTransferObject(budgetSourceCategory);

            var response = BudgetSourceCategoryClient.SetBudgetSourceCategories(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.BudgetSourceCategoryId;
        }

        /// <summary>
        /// Updates the budgetSourceCategory.
        /// </summary>
        /// <param name="budgetSourceCategory">The budgetSourceCategory.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int UpdateBudgetSourceCategory(BudgetSourceCategoryModel budgetSourceCategory)
        {
            var request = PrepareRequest(new BudgetSourceCategoryRequest());
            request.Action = PersistType.Update;
            request.BudgetSourceCategory = Mapper.ToDataTransferObject(budgetSourceCategory);

            var response = BudgetSourceCategoryClient.SetBudgetSourceCategories(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RowsAffected;
        }

        /// <summary>
        /// Deletes the budgetSourceCategory.
        /// </summary>
        /// <param name="budgetSourceCategoryId">The budgetSourceCategory identifier.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int DeleteBudgetSourceCategory(int budgetSourceCategoryId)
        {
            var request = PrepareRequest(new BudgetSourceCategoryRequest());
            request.Action = PersistType.Delete;
            request.BudgetSourceCategoryId = budgetSourceCategoryId;

            var response = BudgetSourceCategoryClient.SetBudgetSourceCategories(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RowsAffected;
        }

        #endregion

        #region EstimateDetailStatement

        /// <summary>
        /// Gets the receipt vouchers.
        /// </summary>
        /// <returns>
        /// IList{EstimateModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<EstimateDetailStatementInfoModel> GetEstimateDetailStatementInfos()
        {
            var request = PrepareRequest(new EstimateDetailStatementRequest());
            request.LoadOptions = new[] { "EstimateDetailStatements" };

            var response = EstimateClient.GetEstimateDetailStatements(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.EstimateDetailStatements);
        }

        /// <summary>
        /// Gets the payment estimate.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public EstimateDetailStatementInfoModel GetEstimateDetailStatementInfo(bool isActive)
        {
            var request = PrepareRequest(new EstimateDetailStatementRequest());
            request.LoadOptions = new[] { "EstimateDetailStatement" };
            request.IsActive = isActive;

            var response = EstimateClient.GetEstimateDetailStatements(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObject(response.EstimateDetailStatement);
        }

        public EstimateDetailStatementInfoModel GetCompanyProfileInfo(bool isActive)
        {
            var request = PrepareRequest(new EstimateDetailStatementRequest());
            request.LoadOptions = new[] { "CompanyProfiles" };
            request.IsActive = isActive;

            var response = EstimateClient.GetEstimateDetailStatements(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObject(response.EstimateDetailStatement);
        }

        /// <summary>
        /// Adds the estimate.
        /// </summary>
        /// <param name="estimateDetailStatement">The estimate detail statement.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int AddEstimateDetailStatementInfo(EstimateDetailStatementInfoModel estimateDetailStatement)
        {
            var request = PrepareRequest(new EstimateDetailStatementRequest());
            request.Action = PersistType.Insert;
            request.EstimateDetailStatement = Mapper.ToDataTransferObject(estimateDetailStatement);

            var response = EstimateClient.SetEstimateDetailStatements(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.EstimateDetailStatementId;
        }

        /// <summary>
        /// Updates the estimate.
        /// </summary>
        /// <param name="estimateDetailStatement">The estimate detail statement.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int UpdateEstimateDetailStatementInfo(EstimateDetailStatementInfoModel estimateDetailStatement)
        {
            var request = PrepareRequest(new EstimateDetailStatementRequest());
            request.Action = PersistType.Update;
            request.EstimateDetailStatement = Mapper.ToDataTransferObject(estimateDetailStatement);

            var response = EstimateClient.SetEstimateDetailStatements(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.EstimateDetailStatementId;
        }

        /// <summary>
        /// Deletes the estimate detail statement.
        /// </summary>
        /// <param name="estimateDetailStatementId">The estimate detail statement identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public long DeleteEstimateDetailStatementInfo(int estimateDetailStatementId)
        {
            var request = PrepareRequest(new EstimateDetailStatementRequest());
            request.Action = PersistType.Delete;
            request.EstimateDetailStatementId = estimateDetailStatementId;

            var response = EstimateClient.SetEstimateDetailStatements(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.EstimateDetailStatementId;
        }

        public IList<EstimateDetailStatementPartBModel> GetEstimateDetailStatementPartBs()
        {
            var request = PrepareRequest(new EstimateDetailStatementPartBRequest());
            request.LoadOptions = new[] { "EstimateDetailStatementPartBs" };

            var response = EstimateClient.GetEstimateDetailStatementPartBs(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.EstimateDetailStatementPartBs);
        }

        public int AddEstimateDetailStatementPartB(IList<EstimateDetailStatementPartBModel> estimateDetailStatementPartB)
        {
            var request = PrepareRequest(new EstimateDetailStatementPartBRequest());
            request.Action = PersistType.Insert;
            request.EstimateDetailStatementPartBs = Mapper.ToDataTransferObjects(estimateDetailStatementPartB);

            var response = EstimateClient.SetEstimateDetailStatementPartBs(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.EstimateDetailStatementPartBId;
        }

        public int UpdateEstimateDetailStatementPartB(IList<EstimateDetailStatementPartBModel> estimateDetailStatementPartB)
        {
            var request = PrepareRequest(new EstimateDetailStatementPartBRequest());
            request.Action = PersistType.Update;
            request.EstimateDetailStatementPartBs = Mapper.ToDataTransferObjects(estimateDetailStatementPartB);

            var response = EstimateClient.SetEstimateDetailStatementPartBs(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.EstimateDetailStatementPartBId;
        }

        #endregion

        #region EstimateDetailStatementFixedAsset
        public IList<EstimateDetailStatementFixedAssetModel> GetEstimateDetailStatementFixedAssets()
        {
            var request = PrepareRequest(new EstimateDetailStatementFixedAssetRequest());
            request.LoadOptions = new[] { "EstimateDetailStatementFixedAssets" };

            var response = EstimateClient.GetEstimateDetailStatementFixedAssets(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.EstimateDetailStatementFixedAssets);
        }

        public int AddEstimateDetailStatementFixedAsset(IList<EstimateDetailStatementFixedAssetModel> estimateDetailStatementFixedAsset)
        {
            var request = PrepareRequest(new EstimateDetailStatementFixedAssetRequest());
            request.Action = PersistType.Insert;
            request.EstimateDetailStatementFixedAssets = Mapper.ToDataTransferObjects(estimateDetailStatementFixedAsset);

            var response = EstimateClient.SetEstimateDetailStatementFixedAssets(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.EstimateDetailStatementFixedAssetId;
        }

        public int UpdateEstimateDetailStatementFixedAsset(IList<EstimateDetailStatementFixedAssetModel> estimateDetailStatementFixedAsset)
        {
            var request = PrepareRequest(new EstimateDetailStatementFixedAssetRequest());
            request.Action = PersistType.Update;
            request.EstimateDetailStatementFixedAssets = Mapper.ToDataTransferObjects(estimateDetailStatementFixedAsset);

            var response = EstimateClient.SetEstimateDetailStatementFixedAssets(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.EstimateDetailStatementFixedAssetId;
        }

        #endregion

        #region ReportList

        public string UpdateReportList(ReportListModel reportList)
        {
            var request = PrepareRequest(new ReportListRequest());
            request.Action = PersistType.Update;
            request.ReportList = Mapper.ToReceiptDataTransferObject(reportList);
            var response = ReportListClient.SetReportLists(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return "Thành công";
        }

        #endregion

        #region CalculateClosing

        public CalculateClosingModel GetCalculateClosing(string paymentAccountCode, string whereClause, string currencyCode, string todate, bool isApproximate, long refId, int refTypeId)
        {
            var request = PrepareRequest(new CalculateClosingRequest());
            request.LoadOptions = new[] { "CalculateClosing" };
            request.PaymentAccountCode = paymentAccountCode;
            request.WhereClause = whereClause;
            request.IsApproximate = isApproximate;
            request.CurrencyCode = currencyCode;
            request.ToDate = todate;
            request.RefId = refId;
            request.RefTypeId = refTypeId;

            var response = CalculateClosingClient.GetCalculateClosing(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObject(response.CalculateClosing);
        }

        /// <summary>
        /// Gets the calculate closing.
        /// </summary>
        /// <param name="debitAccount">The debit account.</param>
        /// <param name="creditAccount">The credit account.</param>
        /// <param name="whereClause">The where clause.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="todate">The todate.</param>
        /// <param name="isApproximate">if set to <c>true</c> [is approximate].</param>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public CalculateClosingModel GetCalculateClosing(string debitAccount, string creditAccount, string whereClause, string currencyCode, string todate, bool isApproximate, long refId, int refTypeId)
        {
            var request = PrepareRequest(new CalculateClosingRequest());
            request.LoadOptions = new[] { "CalculateClosing", "IsPaymentNegativeBudgetSource" };
            request.PaymentAccountCode = debitAccount;
            request.CreditAccount = creditAccount;
            request.WhereClause = whereClause;
            request.IsApproximate = isApproximate;
            request.CurrencyCode = currencyCode;
            request.ToDate = todate;
            request.RefId = refId;
            request.RefTypeId = refTypeId;

            var response = CalculateClosingClient.GetCalculateClosing(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObject(response.CalculateClosing);
        }
        #endregion

        #region Mutual
        public IList<MutualModel> GetMutuals()
        {
            var request = PrepareRequest(new MutualRequest());
            request.LoadOptions = new[] { "Mutuals" };

            var response = MutualClient.GetMutuals(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.Mutuals);
        }

        public MutualModel GetMutual(int mutualId)
        {
            var request = PrepareRequest(new MutualRequest());
            request.LoadOptions = new[] { "Mutual" };
            request.MutualId = mutualId;

            var response = MutualClient.GetMutuals(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return Mapper.FromDataTransferObject(response.Mutual);
        }

        public List<MutualModel> GetMutualByIsActive(bool isActive)
        {
            var request = PrepareRequest(new MutualRequest());
            request.LoadOptions = new[] { "Mutual" };

            var response = MutualClient.GetMutuals(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return Mapper.FromDataTransferObjects(response.Mutuals);
        }

        public List<MutualModel> GetMutualByMutualCode(string mutualCode)
        {
            var request = PrepareRequest(new MutualRequest());
            request.LoadOptions = new[] { "Mutuals", "MutualCode" };
            request.MutualCode = mutualCode;
            var response = MutualClient.GetMutuals(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return Mapper.FromDataTransferObjects(response.Mutuals);
        }

        public int AddMutual(MutualModel mutual)
        {
            var request = PrepareRequest(new MutualRequest());
            request.Action = PersistType.Insert;
            request.Mutual = Mapper.ToDataTransferObject(mutual);
            var response = MutualClient.SetMutuals(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.MutualId;
        }

        public int UpdateMutual(MutualModel mutual)
        {
            var request = PrepareRequest(new MutualRequest());
            request.Action = PersistType.Update;
            request.Mutual = Mapper.ToDataTransferObject(mutual);
            var response = MutualClient.SetMutuals(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.MutualId;
        }

        public int DeleteMutual(int mutualId)
        {
            var request = PrepareRequest(new MutualRequest());
            request.Action = PersistType.Delete;
            request.MutualId = mutualId;

            var response = MutualClient.SetMutuals(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.MutualId;
        }


        #endregion

        public IList<PlanTemplateItemModel> GetPlanTemplateItemsForEstimateUpdate(int planTemplateListId, short planYear, int budgetSourceCategoryId, int option)
        {
            var request = PrepareRequest(new PlanTemplateItemRequest());
            request.LoadOptions = new[] { "PlanTemplateItems", "Option" };
            request.PlanTemplateListId = planTemplateListId;
            request.PlanYear = planYear;
            request.BudgetSourceCategoryId = budgetSourceCategoryId;
            request.Option = option;
            var response = PlanTemplateItemClient.GetPlanTemplateItems(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.PlanTemplateItems);
        }

        #region ElectricalWork

        public ElectricalWorkModel GetElectricalWork(int postedDate)
        {
            var request = PrepareRequest(new ElectrialWorkRequest());
            request.LoadOptions = new[] { "ElectricalWork" };
            request.PostedDate = postedDate;

            var response = ElectricalWorkClient.Gets(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return Mapper.FromDataTransferObject(response.ElectricalWorkEntity);
        }

        public int UpdateInsertElectricalWork(ElectricalWorkModel electricalWorkModel)
        {
            var request = PrepareRequest(new ElectrialWorkRequest());
            request.ElectricalWorkEntity = Mapper.ToDataTransferObject(electricalWorkModel);
            var response = ElectricalWorkClient.Sets(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.ElectrialWorkId;
        }

        #endregion

        #region AutoNumberList
        public IList<AutoNumberListModel> GetAutoNumberLists()
        {
            var request = PrepareRequest(new AutoNumberListRequest());
            request.LoadOptions = new[] { "AutoNumberLists" };

            var response = AutoNumberListClient.GetAutoNumberLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.AutoNumberLists);
        }

        public AutoNumberListModel GetAutoNumberList(string tableCode)
        {
            var request = PrepareRequest(new AutoNumberListRequest());
            request.LoadOptions = new[] { "AutoNumberList" };
            request.TableCode = tableCode;
            var response = AutoNumberListClient.GetAutoNumberLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return Mapper.FromDataTransferObject(response.AutoNumberList);
        }

        public string UpdateAutoNumberList(List<AutoNumberListModel> autoNumberList)
        {
            var request = PrepareRequest(new AutoNumberListRequest());
            request.Action = PersistType.Update;
            request.AutoNumberLists = Mapper.ToDataTransferObjects(autoNumberList);
            var response = AutoNumberListClient.SetAutoNumberLists(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return null;
        }


        #endregion

        #region   SalaryVoucher

        public string GetRefNoInEmployeePayroll(string currDate)
        {
            var request = PrepareRequest(new SalaryRequest());
            request.LoadOptions = new[] { "GetRefNoEmployeePayroll" };
            request.CurrDate = currDate;
            var response = SalaryFacadeClient.GetSalaries(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return response.Message;
        }

        public string SararyExistRefNoInDay(string currDate, string refNo)
        {
            var request = PrepareRequest(new SalaryRequest());
            request.LoadOptions = new[] { "SalaryExistRefNoInDay" };
            request.CurrDate = currDate;
            request.RefNo = refNo;
            var response = SalaryFacadeClient.GetSalaries(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return response.Message;
        }

        public List<SalaryVoucherModel> SalaryVoucherByMonthDate(string monthDate)
        {
            var request = PrepareRequest(new SalaryVoucherRequest());
            request.LoadOptions = new[] { "PostedDate" };
            request.PostedDate = monthDate;
            var response = SalaryVoucherFacade.GetSalaryVouchers(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return Mapper.FromDataTransferObjects(response.SalaryVouchers);

        }

        public string SaveSalaryVoucher(string postedDate, string refNo, int refTypeId)
        {
            var request = PrepareRequest(new SalaryVoucherRequest());
            request.LoadOptions = new[] { "SaveSalaryVoucher" };
            request.PostedDate = postedDate;
            request.ReftypeId = refTypeId;
            request.RefNo = refNo;
            var response = SalaryVoucherFacade.SetSalaryVouchers(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return response.Message;
        }

        public List<SalaryVoucherModel> SalaryVoucherByMonthDateIsPostedDate(string monthDate)
        {
            var request = PrepareRequest(new SalaryVoucherRequest());
            request.LoadOptions = new[] { "IsPostedDate" };
            request.PostedDate = monthDate;
            var response = SalaryVoucherFacade.GetSalaryVouchers(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return Mapper.FromDataTransferObjects(response.SalaryVouchers);
        }

        public string CancelSalaryVoucher(string postedDate, string refNo, int refTypeId)
        {
            var request = PrepareRequest(new SalaryVoucherRequest());
            request.LoadOptions = new[] { "CancelSalaryVoucher" };
            request.PostedDate = postedDate;
            request.ReftypeId = refTypeId;
            request.RefNo = refNo;
            var response = SalaryVoucherFacade.SetSalaryVouchers(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return response.Message;
        }

        public string SalaryVoucherByCash(string postedDate, string refNo, int refTypeId)
        {
            var request = PrepareRequest(new SalaryVoucherRequest());
            request.LoadOptions = new[] { "SalaryVoucherByCash" };
            request.PostedDate = postedDate;
            request.ReftypeId = refTypeId;
            request.RefNo = refNo;
            var response = SalaryVoucherFacade.GetSalaryVouchers(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return response.Message;
        }

        public string SalaryVoucherByDeposit(string postedDate, string refNo, int refTypeId)
        {
            var request = PrepareRequest(new SalaryVoucherRequest());
            request.LoadOptions = new[] { "SalaryVoucherByDeposit" };
            request.PostedDate = postedDate;
            request.ReftypeId = refTypeId;
            request.RefNo = refNo;
            var response = SalaryVoucherFacade.GetSalaryVouchers(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return response.Message;
        }

        public List<SalaryVoucherModel> SalaryVoucherByMonthDateIsRetail(string monthDate, bool isRetail, int refTypeId)
        {

            var request = PrepareRequest(new SalaryVoucherRequest());
            request.LoadOptions = new[] { "SalaryVoucherByIsRetail" };
            request.IsRetail = isRetail;
            request.PostedDate = monthDate;
            var response = SalaryVoucherFacade.GetSalaryVouchers(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return Mapper.FromDataTransferObjects(response.SalaryVouchers);
        }

        public long GetEmployeePayroll_VoucherID(string refNo, int refTypeId)
        {
            return SalaryVoucherFacade.GetEmployeePayroll_VoucherID(refNo, refTypeId);
        }

        #endregion

        #region ExchangeRate
        public ExchangeRateModel GetExchangeRate(int exchangeId)
        {
            var request = PrepareRequest(new ExchangeRateRequest());
            request.LoadOptions = new[] { "ExchangeRate", "ExchangeRateId" };
            request.ExchangeRateId = exchangeId;

            var response = ExchangeRateFacade.GetExchangeRates(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObject(response.ExchangeRate);
        }

        public ExchangeRateModel GetExchangeRatesByDateAndBudgetSource(DateTime fromdate, DateTime todate, string budgetSourceCode)
        {
            var request = PrepareRequest(new ExchangeRateRequest());
            request.LoadOptions = new[] { "ExchangeRate" };
            request.FromDate = fromdate;
            request.ToDate = todate;
            request.BudgetSourceCode = budgetSourceCode;

            var response = ExchangeRateFacade.GetExchangeRates(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObject(response.ExchangeRate);
        }

        public IList<ExchangeRateModel> GetExchangeRates()
        {
            var request = PrepareRequest(new ExchangeRateRequest());
            request.LoadOptions = new[] { "ExchangeRates" };

            var response = ExchangeRateFacade.GetExchangeRates(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.ExchangeRates);
        }

        public IList<ExchangeRateModel> GetExchangeRatesByDate(DateTime fromdate, DateTime todate)
        {
            var request = PrepareRequest(new ExchangeRateRequest());
            request.LoadOptions = new[] { "ExchangeRates", "Date" };

            var response = ExchangeRateFacade.GetExchangeRates(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.ExchangeRates);
        }

        public IList<ExchangeRateModel> GetExchangeRatesByActive(bool isActive)
        {
            var request = PrepareRequest(new ExchangeRateRequest());
            request.LoadOptions = new[] { "ExchangeRates", "IsActive" };

            var response = ExchangeRateFacade.GetExchangeRates(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.ExchangeRates);
        }

        public int AddExchangeRate(ExchangeRateModel exchangeRate)
        {
            var request = PrepareRequest(new ExchangeRateRequest());
            request.Action = PersistType.Insert;
            request.ExchangeRate = Mapper.ToDataTransferObject(exchangeRate);

            var response = ExchangeRateFacade.SetExchangeRates(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.ExchangeRateId;
        }

        public int UpdateExchangeRate(ExchangeRateModel exchangeRate)
        {
            var request = PrepareRequest(new ExchangeRateRequest());
            request.Action = PersistType.Update;
            request.ExchangeRate = Mapper.ToDataTransferObject(exchangeRate);

            var response = ExchangeRateFacade.SetExchangeRates(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.ExchangeRateId;
        }

        public int DeleteExchangeRate(int exchangeRateId)
        {
            var request = PrepareRequest(new ExchangeRateRequest());
            request.Action = PersistType.Delete;
            request.ExchangeRateId = exchangeRateId;

            var response = ExchangeRateFacade.SetExchangeRates(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RowsAffected;
        }

        #endregion

        #region SUIncrementDecrement

        /// <summary>
        ///     Gets the receipt vouchers.
        /// </summary>
        /// <returns>
        ///     IList{SUIncrementDecrementModel}.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<SUIncrementDecrementModel> GetSUIncrementDecrements()
        {
            var sUIncrementDecrements = sUIncrementDecrementFacade.GetSUIncrementDecrements();
            return sUIncrementDecrements.Any() ? VoucherMapper.FromDataTransferObjects(sUIncrementDecrements) : new List<SUIncrementDecrementModel>();
        }

        /// <summary>
        ///     Gets the sUIncrementDecrements by year of post date.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="refDate">The reference date.</param>
        /// <returns></returns>
        public IList<SUIncrementDecrementModel> GetSUIncrementDecrementsByYearOfPostDate(int refTypeId, DateTime refDate)
        {
            var sUIncrementDecrements = sUIncrementDecrementFacade.GetSUIncrementDecrementsByRefTypeId(refTypeId, refDate);
            return sUIncrementDecrements.Any() ? VoucherMapper.FromDataTransferObjects(sUIncrementDecrements) : new List<SUIncrementDecrementModel>();
        }

        /// <summary>
        ///     Gets the sUIncrementDecrements by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns>
        ///     IList{SUIncrementDecrementModel}.
        /// </returns>
        public IList<SUIncrementDecrementModel> GetSUIncrementDecrementsByRefTypeId(int refTypeId)
        {
            var sUIncrementDecrements = sUIncrementDecrementFacade.GetSUIncrementDecrementsByRefTypeId(refTypeId);
            return sUIncrementDecrements.Any() ? VoucherMapper.FromDataTransferObjects(sUIncrementDecrements) : new List<SUIncrementDecrementModel>();
        }

        /// <summary>
        ///     Gets the ba deposit.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="hasDetail">if set to <c>true</c> [has detail].</param>
        /// <returns></returns>
        public SUIncrementDecrementModel GetSUIncrementDecrement(long refId, bool hasDetail)
        {
            var sUIncrementDecrement = sUIncrementDecrementFacade.GetSUIncrementDecrementByRefId(refId, hasDetail);
            return sUIncrementDecrement != null ? VoucherMapper.FromDataTransferObject(sUIncrementDecrement) : null;
        }

        public decimal GetSUIncrementDecrementQuantity(string currencyCode, int inventoryItemId, int departmentId, long refId, DateTime postedDate)
        {
            return sUIncrementDecrementFacade.GetSUIncrementDecrementQuantity(currencyCode, inventoryItemId, departmentId, refId, postedDate);
        }

        /// <summary>
        ///     Gets the sUIncrementDecrement.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <param name="hasDetail">if set to <c>true</c> [has detail].</param>
        /// <returns></returns>
        public SUIncrementDecrementModel GetSUIncrementDecrementByRefNo(string refNo, bool hasDetail)
        {
            var sUIncrementDecrement = sUIncrementDecrementFacade.GetSUIncrementDecrementByRefNo(refNo, hasDetail);
            return sUIncrementDecrement != null ? VoucherMapper.FromDataTransferObject(sUIncrementDecrement) : null;
        }

        /// <summary>
        ///     Adds the sUIncrementDecrement.
        /// </summary>
        /// <param name="sUIncrementDecrement">The sUIncrementDecrement.</param>
        /// <returns>
        ///     System.Int64.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public long AddSUIncrementDecrement(SUIncrementDecrementModel sUIncrementDecrement)
        {
            var sUIncrementDecrementEntity = VoucherMapper.ToDataTransferObject(sUIncrementDecrement);
            var response = sUIncrementDecrementFacade.InsertSUIncrementDecrement(sUIncrementDecrementEntity, false);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        /// <summary>
        ///     Updates the sUIncrementDecrement.
        /// </summary>
        /// <param name="sUIncrementDecrement">The sUIncrementDecrement.</param>
        /// <returns>
        ///     System.Int64.
        /// </returns>
        /// <exception cref="System.ApplicationException"></exception>
        public long UpdateSUIncrementDecrement(SUIncrementDecrementModel sUIncrementDecrement)
        {
            var sUIncrementDecrementEntity = VoucherMapper.ToDataTransferObject(sUIncrementDecrement);
            var response = sUIncrementDecrementFacade.UpdateSUIncrementDecrement(sUIncrementDecrementEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        /// <summary>
        ///     Deletes the ba deposit.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public long DeleteSUIncrementDecrement(long refId)
        {
            var response = sUIncrementDecrementFacade.DeleteSUIncrementDecrement(refId);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefId;
        }

        #endregion

        public IList<A02LDTLModel> Get02LdtlIsRetailWithStoreProdure(string storeProdure, string fromDate, string toDate, string whereClause, bool isEmployee)
        {
            var request = PrepareRequest(new ReportListRequest());
            request.LoadOptions = new[] { "Reports", "A02LDTLIsRetail" };
            request.StoreProdure = storeProdure;
            request.FromDate = fromDate;
            request.ToDate = toDate;
            request.WhereClause = whereClause;
            request.IsEmployee = isEmployee;
            var response = ReportListClient.GetReportLists(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return Mapper.FromDataTransferObjects(response.A02LDTL);
        }

        public string CancelCalc(string postedDate, string refNo, int refTypeId)
        {
            var request = PrepareRequest(new SalaryVoucherRequest());
            request.LoadOptions = new[] { "CancelCalc" };
            request.PostedDate = postedDate;
            request.ReftypeId = refTypeId;
            request.RefNo = refNo;
            var response = SalaryVoucherFacade.SetSalaryVouchers(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return response.Message;
        }

        public CalculateClosingModel AmountExist(string accountCode, string currencyCode)
        {
            var request = PrepareRequest(new CalculateClosingRequest());
            request.LoadOptions = new[] { "AmountExist" };
            request.PaymentAccountCode = accountCode;
            request.CurrencyCode = currencyCode;
            var response = CalculateClosingClient.AmountExist(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return Mapper.FromDataTransferObject(response.CalculateClosing);
        }

        #region Lock book

        public LockModel GetLock()
        {
            var request = PrepareRequest(new LockRequest());
            request.LoadOptions = new[] { "Get" };
            var response = LockClient.GetLock(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return Mapper.FromDataTransferObject(response.Lock);
        }

        public string SaveLock(LockModel model)
        {
            var request = PrepareRequest(new LockRequest());
            request.LoadOptions = new[] { "ExcuteLock" };
            request.Lock = Mapper.ToDataTransferObject(model);
            var response = LockClient.SetLock(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return response.Message;
        }

        public LockModel CheckLock(int refId, int refTypeId, DateTime refDate)
        {
            var request = PrepareRequest(new LockRequest());
            request.LoadOptions = new[] { "CheckPostedDate" };
            request.RefId = refId;
            request.RefTypeId = refTypeId;
            request.RefDate = refDate;
            var response = LockClient.GetLock(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return Mapper.FromDataTransferObject(response.Lock);
        }

        public LockModel CheckLock(int refId, int refTypeId)
        {
            var request = PrepareRequest(new LockRequest());
            request.LoadOptions = new[] { "CheckRefID" };
            request.RefId = refId;
            request.RefTypeId = refTypeId;
            var response = LockClient.GetLock(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return Mapper.FromDataTransferObject(response.Lock);
        }

        #endregion

        #region JournalEntryAccount

        /// <summary>
        /// Gets the journal entry accounts.
        /// </summary>
        /// <param name="exportType">Type of the export.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<JournalEntryAccountModel> GetJournalEntryAccounts(int exportType, DateTime fromDate, DateTime toDate)
        {
            var request = PrepareRequest(new JournalEntryAccountRequest());
            request.FromDate = fromDate;
            request.ToDate = toDate;
            request.ExportType = exportType;
            var response = JournalEntryAccountFacade.GetJournalEntryAccounts(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);
            return Mapper.FromDataTransferObjects(response.JournalEntryAccounts);
        }
        #endregion

        #region RefType

        /// <summary>
        ///     Gets the voucher types.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        //public IList<RefTypeModel> GetRefTypes()
        //{
        //    var refTypes = RefTypeClient.GetRefTypes();
        //    return Mapper.FromDataTransferObjects(refTypes);
        //}

        /// <summary>
        ///     Gets the reference type model.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        public RefTypeModel GetRefTypeModel(int refTypeId)
        {
            var refType = RefTypeClient.GetRefType(refTypeId);
            return refType == null ? null : Mapper.FromDataTransferObject(refType);
        }

        /// <summary>
        ///     Updates the type of the reference.
        /// </summary>
        /// <param name="refTypeModel">The reference type model.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int UpdateRefType(RefTypeModel refTypeModel)
        {
            var refTypeEntity = Mapper.ToDataTransferObject(refTypeModel);
            var response = RefTypeClient.UpdateRefType(refTypeEntity);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);
            return response.RefTypeId;
        }

        #endregion

        #region Bank

        /// <summary>
        /// Gets the banks.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<BankModel> GetBanks()
        {
            var request = PrepareRequest(new BankRequest());
            request.LoadOptions = new[] { "Banks" };

            var response = BankClient.GetBanks(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.Banks);
        }

        /// <summary>
        /// Gets the banks active.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<BankModel> GetBanksActive()
        {
            var request = PrepareRequest(new BankRequest());
            request.LoadOptions = new[] { "Banks", "IsActive" };

            var response = BankClient.GetBanks(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.Banks);
        }

        /// <summary>
        /// Gets the banks non active.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public IList<BankModel> GetBanksNonActive()
        {
            var request = PrepareRequest(new BankRequest());
            request.LoadOptions = new[] { "Banks", "NonActive" };

            var response = BankClient.GetBanks(request);
            if (response.Acknowledge != AcknowledgeType.Success) throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObjects(response.Banks);
        }

        /// <summary>
        /// Gets the bank.
        /// </summary>
        /// <param name="bankId">The bank identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public BankModel GetBank(int bankId)
        {
            var request = PrepareRequest(new BankRequest());
            request.LoadOptions = new[] { "Bank" };
            request.BankId = bankId;

            var response = BankClient.GetBanks(request);
            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return Mapper.FromDataTransferObject(response.Bank);
        }

        /// <summary>
        /// Adds the bank.
        /// </summary>
        /// <param name="bank">The bank.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int AddBank(BankModel bank)
        {
            var request = PrepareRequest(new BankRequest());
            request.Action = PersistType.Insert;
            request.Bank = Mapper.ToDataTransferObject(bank);

            var response = BankClient.SetBanks(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.BankId;
        }

        /// <summary>
        /// Updates the bank.
        /// </summary>
        /// <param name="bank">The bank.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int UpdateBank(BankModel bank)
        {
            var request = PrepareRequest(new BankRequest());
            request.Action = PersistType.Update;
            request.Bank = Mapper.ToDataTransferObject(bank);

            var response = BankClient.SetBanks(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.BankId;
        }

        /// <summary>
        /// Deletes the bank.
        /// </summary>
        /// <param name="bankId">The bank identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException"></exception>
        public int DeleteBank(int bankId)
        {
            var request = PrepareRequest(new BankRequest());
            request.Action = PersistType.Delete;
            request.BankId = bankId;

            var response = BankClient.SetBanks(request);

            if (response.Acknowledge != AcknowledgeType.Success)
                throw new ApplicationException(response.Message);

            return response.RowsAffected;
        }

        #endregion
    }
}