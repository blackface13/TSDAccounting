using TSD.AccountingSoft.BusinessEntities.Business.FixedAsset;
using TSD.AccountingSoft.BusinessEntities.Business.Opening;
using TSD.AccountingSoft.BusinessEntities.Dictionary;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Model.BusinessObjects.FixedAsset;
using TSD.AccountingSoft.Model.BusinessObjects.Opening;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.Model.DataTransferObjectMapper
{
    static class DictionaryMapper
    {
        static DictionaryMapper()
        {
            AutoMapper.Mapper.CreateMap<AccountModel, AccountEntity>();
            AutoMapper.Mapper.CreateMap<AccountEntity, AccountModel>();
            AutoMapper.Mapper.CreateMap<AutoBusinessParallelModel, AutoBusinessParallelEntity>();
            AutoMapper.Mapper.CreateMap<AutoBusinessParallelEntity, AutoBusinessParallelModel>();
            AutoMapper.Mapper.CreateMap<ActivityModel, ActivityEntity>();
            AutoMapper.Mapper.CreateMap<ActivityEntity, ActivityModel>();
            AutoMapper.Mapper.CreateMap<AccountingObjectCategoryModel, AccountingObjectCategoryEntity>();
            AutoMapper.Mapper.CreateMap<AccountingObjectCategoryEntity, AccountingObjectCategoryModel>();
            AutoMapper.Mapper.CreateMap<AccountingObjectModel, AccountingObjectEntity>();
            AutoMapper.Mapper.CreateMap<AccountingObjectEntity, AccountingObjectModel>();
            AutoMapper.Mapper.CreateMap<AutoBusinessModel, AutoBusinessEntity>();
            AutoMapper.Mapper.CreateMap<AutoBusinessEntity, AutoBusinessModel>();
            AutoMapper.Mapper.CreateMap<AccountTranferEntity, AccountTranferModel>();
            AutoMapper.Mapper.CreateMap<AccountTranferModel, AccountTranferEntity>();
            AutoMapper.Mapper.CreateMap<InventoryItemEntity, InventoryItemModel>();
            AutoMapper.Mapper.CreateMap<InventoryItemModel, InventoryItemEntity>();
            AutoMapper.Mapper.CreateMap<BudgetItemModel, BudgetItemEntity>();
            AutoMapper.Mapper.CreateMap<BudgetItemEntity, BudgetItemModel>();
            AutoMapper.Mapper.CreateMap<BudgetSourceModel, BudgetSourceEntity>();
            AutoMapper.Mapper.CreateMap<BudgetSourceEntity, BudgetSourceModel>();
            AutoMapper.Mapper.CreateMap<FixedAssetCategoryModel, FixedAssetCategoryEntity>();
            AutoMapper.Mapper.CreateMap<FixedAssetCategoryEntity, FixedAssetCategoryModel>();
            AutoMapper.Mapper.CreateMap<OpeningFixedAssetEntryModel, OpeningFixedAssetEntryEntity>();
            AutoMapper.Mapper.CreateMap<OpeningFixedAssetEntryEntity, OpeningFixedAssetEntryModel>();

            AutoMapper.Mapper.CreateMap<FixedAssetModel, FixedAssetEntity>();
            AutoMapper.Mapper.CreateMap<FixedAssetEntity, FixedAssetModel>();
            AutoMapper.Mapper.CreateMap<FixedAssetCurrencyModel, FixedAssetCurrencyEntity>();
            AutoMapper.Mapper.CreateMap<FixedAssetCurrencyEntity, FixedAssetCurrencyModel>();
            AutoMapper.Mapper.CreateMap<FixedAssetAccessaryModel, FixedAssetAccessaryEntity>();
            AutoMapper.Mapper.CreateMap<FixedAssetAccessaryEntity, FixedAssetAccessaryModel>();
            AutoMapper.Mapper.CreateMap<FixedAssetVoucherModel, FixedAssetVoucherEntity>();
            AutoMapper.Mapper.CreateMap<FixedAssetVoucherEntity, FixedAssetVoucherModel>();
        }

        #region Account

        internal static AccountModel FromDataTransferObject(AccountEntity entity)
        {
            return entity == null ? null : AutoMapper.Mapper.Map<AccountEntity, AccountModel>(entity);
        }

        internal static AccountEntity ToDataTransferObject(AccountModel model)
        {

            return model == null ? null : AutoMapper.Mapper.Map<AccountModel, AccountEntity>(model);
        }

        internal static IList<AccountModel> FromDataTransferObjects(IList<AccountEntity> entities)
        {
            return entities == null ? null : AutoMapper.Mapper.Map<IList<AccountEntity>, IList<AccountModel>>(entities);
        }

        internal static IList<AccountEntity> ToDataTransferObjects(IList<AccountModel> models)
        {
            return models == null ? null : AutoMapper.Mapper.Map<IList<AccountModel>, IList<AccountEntity>>(models);
        }

        #endregion

        #region AutoBusinessParallel

        internal static AutoBusinessParallelModel FromDataTransferObject(AutoBusinessParallelEntity entity)
        {
            return entity == null ? null : AutoMapper.Mapper.Map<AutoBusinessParallelEntity, AutoBusinessParallelModel>(entity);
        }

        internal static AutoBusinessParallelEntity ToDataTransferObject(AutoBusinessParallelModel model)
        {

            return model == null ? null : AutoMapper.Mapper.Map<AutoBusinessParallelModel, AutoBusinessParallelEntity>(model);
        }

        internal static IList<AutoBusinessParallelModel> FromDataTransferObjects(IList<AutoBusinessParallelEntity> entities)
        {
            return entities == null ? null : AutoMapper.Mapper.Map<IList<AutoBusinessParallelEntity>, IList<AutoBusinessParallelModel>>(entities);
        }

        internal static IList<AutoBusinessParallelEntity> ToDataTransferObjects(IList<AutoBusinessParallelModel> models)
        {
            return models == null ? null : AutoMapper.Mapper.Map<IList<AutoBusinessParallelModel>, IList<AutoBusinessParallelEntity>>(models);
        }

        #endregion

        #region AccountingObject

        internal static AccountingObjectModel FromDataTransferObject(AccountingObjectEntity entity)
        {
            return entity == null ? null : AutoMapper.Mapper.Map<AccountingObjectEntity, AccountingObjectModel>(entity);
        }

        internal static AccountingObjectEntity ToDataTransferObject(AccountingObjectModel model)
        {

            return model == null ? null : AutoMapper.Mapper.Map<AccountingObjectModel, AccountingObjectEntity>(model);
        }

        internal static IList<AccountingObjectModel> FromDataTransferObjects(IList<AccountingObjectEntity> entities)
        {
            return entities == null ? null : AutoMapper.Mapper.Map<IList<AccountingObjectEntity>, IList<AccountingObjectModel>>(entities);
        }

        internal static IList<AccountingObjectEntity> ToDataTransferObjects(IList<AccountingObjectModel> models)
        {
            return models == null ? null : AutoMapper.Mapper.Map<IList<AccountingObjectModel>, IList<AccountingObjectEntity>>(models);
        }

        #endregion

        #region AccountingObjectCategory

        internal static AccountingObjectCategoryModel FromDataTransferObject(AccountingObjectCategoryEntity entity)
        {
            return entity == null ? null : AutoMapper.Mapper.Map<AccountingObjectCategoryEntity, AccountingObjectCategoryModel>(entity);
        }

        internal static AccountingObjectCategoryEntity ToDataTransferObject(AccountingObjectCategoryModel model)
        {

            return model == null ? null : AutoMapper.Mapper.Map<AccountingObjectCategoryModel, AccountingObjectCategoryEntity>(model);
        }

        internal static IList<AccountingObjectCategoryModel> FromDataTransferObjects(IList<AccountingObjectCategoryEntity> entities)
        {
            return entities == null ? null : AutoMapper.Mapper.Map<IList<AccountingObjectCategoryEntity>, IList<AccountingObjectCategoryModel>>(entities);
        }

        internal static IList<AccountingObjectCategoryEntity> ToDataTransferObjects(IList<AccountingObjectCategoryModel> models)
        {
            return models == null ? null : AutoMapper.Mapper.Map<IList<AccountingObjectCategoryModel>, IList<AccountingObjectCategoryEntity>>(models);
        }

        #endregion

        #region AccountingObjectCategory

        internal static AccountTranferModel FromDataTransferObject(AccountTranferEntity entity)
        {
            return entity == null ? null : AutoMapper.Mapper.Map<AccountTranferEntity, AccountTranferModel>(entity);
        }

        internal static AccountTranferEntity ToDataTransferObject(AccountTranferModel model)
        {

            return model == null ? null : AutoMapper.Mapper.Map<AccountTranferModel, AccountTranferEntity>(model);
        }

        internal static IList<AccountTranferModel> FromDataTransferObjects(IList<AccountTranferEntity> entities)
        {
            return entities == null ? null : AutoMapper.Mapper.Map<IList<AccountTranferEntity>, IList<AccountTranferModel>>(entities);
        }

        internal static IList<AccountTranferEntity> ToDataTransferObjects(IList<AccountTranferModel> models)
        {
            return models == null ? null : AutoMapper.Mapper.Map<IList<AccountTranferModel>, IList<AccountTranferEntity>>(models);
        }

        #endregion

        #region Activity

        internal static ActivityModel FromDataTransferObject(ActivityEntity entity)
        {
            return entity == null ? null : AutoMapper.Mapper.Map<ActivityEntity, ActivityModel>(entity);
        }

        internal static ActivityEntity ToDataTransferObject(ActivityModel model)
        {

            return model == null ? null : AutoMapper.Mapper.Map<ActivityModel, ActivityEntity>(model);
        }

        internal static IList<ActivityModel> FromDataTransferObjects(IList<ActivityEntity> entities)
        {
            return entities == null ? null : AutoMapper.Mapper.Map<IList<ActivityEntity>, IList<ActivityModel>>(entities);
        }

        internal static IList<ActivityEntity> ToDataTransferObjects(IList<ActivityModel> models)
        {
            return models == null ? null : AutoMapper.Mapper.Map<IList<ActivityModel>, IList<ActivityEntity>>(models);
        }

        #endregion

        #region AutoBusiness

        internal static AutoBusinessModel FromDataTransferObject(AutoBusinessEntity entity)
        {
            return entity == null ? null : AutoMapper.Mapper.Map<AutoBusinessEntity, AutoBusinessModel>(entity);
        }

        internal static AutoBusinessEntity ToDataTransferObject(AutoBusinessModel model)
        {
            return model == null ? null : AutoMapper.Mapper.Map<AutoBusinessModel, AutoBusinessEntity>(model);
        }

        internal static IList<AutoBusinessModel> FromDataTransferObjects(IList<AutoBusinessEntity> entities)
        {
            return entities == null ? null : AutoMapper.Mapper.Map<IList<AutoBusinessEntity>, IList<AutoBusinessModel>>(entities);
        }

        internal static IList<AutoBusinessEntity> ToDataTransferObjects(IList<AutoBusinessModel> models)
        {
            return models == null ? null : AutoMapper.Mapper.Map<IList<AutoBusinessModel>, IList<AutoBusinessEntity>>(models);
        }

        #endregion

        #region BudgetItem

        internal static BudgetItemModel FromDataTransferObject(BudgetItemEntity entity)
        {
            return entity == null ? null : AutoMapper.Mapper.Map<BudgetItemEntity, BudgetItemModel>(entity);
        }

        internal static BudgetItemEntity ToDataTransferObject(BudgetItemModel model)
        {

            return model == null ? null : AutoMapper.Mapper.Map<BudgetItemModel, BudgetItemEntity>(model);
        }

        internal static IList<BudgetItemModel> FromDataTransferObjects(IList<BudgetItemEntity> entities)
        {
            return entities == null ? null : AutoMapper.Mapper.Map<IList<BudgetItemEntity>, IList<BudgetItemModel>>(entities);
        }

        internal static IList<BudgetItemEntity> ToDataTransferObjects(IList<BudgetItemModel> models)
        {
            return models == null ? null : AutoMapper.Mapper.Map<IList<BudgetItemModel>, IList<BudgetItemEntity>>(models);
        }

        #endregion

        #region BudgetSource

        internal static BudgetSourceModel FromDataTransferObject(BudgetSourceEntity entity)
        {
            return entity == null ? null : AutoMapper.Mapper.Map<BudgetSourceEntity, BudgetSourceModel>(entity);
        }

        internal static BudgetSourceEntity ToDataTransferObject(BudgetSourceModel model)
        {

            return model == null ? null : AutoMapper.Mapper.Map<BudgetSourceModel, BudgetSourceEntity>(model);
        }

        internal static IList<BudgetSourceModel> FromDataTransferObjects(IList<BudgetSourceEntity> entities)
        {
            return entities == null ? null : AutoMapper.Mapper.Map<IList<BudgetSourceEntity>, IList<BudgetSourceModel>>(entities);
        }

        internal static IList<BudgetSourceEntity> ToDataTransferObjects(IList<BudgetSourceModel> models)
        {
            return models == null ? null : AutoMapper.Mapper.Map<IList<BudgetSourceModel>, IList<BudgetSourceEntity>>(models);
        }

        #endregion

        #region InventoryItem

        internal static InventoryItemModel FromDataTransferObject(InventoryItemEntity entity)
        {
            return entity == null ? null : AutoMapper.Mapper.Map<InventoryItemEntity, InventoryItemModel>(entity);
        }

        internal static InventoryItemEntity ToDataTransferObject(InventoryItemModel model)
        {

            return model == null ? null : AutoMapper.Mapper.Map<InventoryItemModel, InventoryItemEntity>(model);
        }

        internal static IList<InventoryItemModel> FromDataTransferObjects(IList<InventoryItemEntity> entities)
        {
            return entities == null ? null : AutoMapper.Mapper.Map<IList<InventoryItemEntity>, IList<InventoryItemModel>>(entities);
        }

        internal static IList<InventoryItemEntity> ToDataTransferObjects(IList<InventoryItemModel> models)
        {
            return models == null ? null : AutoMapper.Mapper.Map<IList<InventoryItemModel>, IList<InventoryItemEntity>>(models);
        }

        #endregion

        #region FixedAsset

        internal static FixedAssetModel FromDataTransferObject(FixedAssetEntity entity)
        {
            return entity == null ? null : AutoMapper.Mapper.Map<FixedAssetEntity, FixedAssetModel>(entity);
        }

        internal static FixedAssetEntity ToDataTransferObject(FixedAssetModel model)
        {

            return model == null ? null : AutoMapper.Mapper.Map<FixedAssetModel, FixedAssetEntity>(model);
        }

        internal static IList<FixedAssetModel> FromDataTransferObjects(IList<FixedAssetEntity> entities)
        {
            return entities == null ? null : AutoMapper.Mapper.Map<IList<FixedAssetEntity>, IList<FixedAssetModel>>(entities);
        }

        internal static IList<FixedAssetEntity> ToDataTransferObjects(IList<FixedAssetModel> models)
        {
            return models == null ? null : AutoMapper.Mapper.Map<IList<FixedAssetModel>, IList<FixedAssetEntity>>(models);
        }
        
        internal static FixedAssetCurrencyModel FromDataTransferObject(FixedAssetCurrencyEntity entity)
        {
            return entity == null ? null : AutoMapper.Mapper.Map<FixedAssetCurrencyEntity, FixedAssetCurrencyModel>(entity);
        }

        internal static FixedAssetCurrencyEntity ToDataTransferObject(FixedAssetCurrencyModel model)
        {

            return model == null ? null : AutoMapper.Mapper.Map<FixedAssetCurrencyModel, FixedAssetCurrencyEntity>(model);
        }

        internal static IList<FixedAssetCurrencyModel> FromDataTransferObjects(IList<FixedAssetCurrencyEntity> entities)
        {
            return entities == null ? null : AutoMapper.Mapper.Map<IList<FixedAssetCurrencyEntity>, IList<FixedAssetCurrencyModel>>(entities);
        }

        internal static IList<FixedAssetCurrencyEntity> ToDataTransferObjects(IList<FixedAssetCurrencyModel> models)
        {
            return models == null ? null : AutoMapper.Mapper.Map<IList<FixedAssetCurrencyModel>, IList<FixedAssetCurrencyEntity>>(models);
        }

        internal static FixedAssetAccessaryModel FromDataTransferObject(FixedAssetAccessaryEntity entity)
        {
            return entity == null ? null : AutoMapper.Mapper.Map<FixedAssetAccessaryEntity, FixedAssetAccessaryModel>(entity);
        }

        internal static FixedAssetAccessaryEntity ToDataTransferObject(FixedAssetAccessaryModel model)
        {
            return model == null ? null : AutoMapper.Mapper.Map<FixedAssetAccessaryModel, FixedAssetAccessaryEntity>(model);
        }

        internal static IList<FixedAssetAccessaryModel> FromDataTransferObjects(IList<FixedAssetAccessaryEntity> entities)
        {
            return entities == null ? null : AutoMapper.Mapper.Map<IList<FixedAssetAccessaryEntity>, IList<FixedAssetAccessaryModel>>(entities);
        }

        internal static IList<FixedAssetAccessaryEntity> ToDataTransferObjects(IList<FixedAssetAccessaryModel> models)
        {
            return models == null ? null : AutoMapper.Mapper.Map<IList<FixedAssetAccessaryModel>, IList<FixedAssetAccessaryEntity>>(models);
        }

        internal static FixedAssetVoucherModel FromDataTransferObject(FixedAssetVoucherEntity entity)
        {
            return entity == null ? null : AutoMapper.Mapper.Map<FixedAssetVoucherEntity, FixedAssetVoucherModel>(entity);
        }

        internal static FixedAssetVoucherEntity ToDataTransferObject(FixedAssetVoucherModel model)
        {
            return model == null ? null : AutoMapper.Mapper.Map<FixedAssetVoucherModel, FixedAssetVoucherEntity>(model);
        }

        internal static IList<FixedAssetVoucherModel> FromDataTransferObjects(IList<FixedAssetVoucherEntity> entities)
        {
            return entities == null ? null : AutoMapper.Mapper.Map<IList<FixedAssetVoucherEntity>, IList<FixedAssetVoucherModel>>(entities);
        }

        internal static IList<FixedAssetVoucherEntity> ToDataTransferObjects(IList<FixedAssetVoucherModel> models)
        {
            return models == null ? null : AutoMapper.Mapper.Map<IList<FixedAssetVoucherModel>, IList<FixedAssetVoucherEntity>>(models);
        }

        #endregion

        #region FixedAssetCategory

        internal static FixedAssetCategoryModel FromDataTransferObject(FixedAssetCategoryEntity entity)
        {
            return entity == null ? null : AutoMapper.Mapper.Map<FixedAssetCategoryEntity, FixedAssetCategoryModel>(entity);
        }

        internal static FixedAssetCategoryEntity ToDataTransferObject(FixedAssetCategoryModel model)
        {

            return model == null ? null : AutoMapper.Mapper.Map<FixedAssetCategoryModel, FixedAssetCategoryEntity>(model);
        }

        internal static IList<FixedAssetCategoryModel> FromDataTransferObjects(IList<FixedAssetCategoryEntity> entities)
        {
            return entities == null ? null : AutoMapper.Mapper.Map<IList<FixedAssetCategoryEntity>, IList<FixedAssetCategoryModel>>(entities);
        }

        internal static IList<FixedAssetCategoryEntity> ToDataTransferObjects(IList<FixedAssetCategoryModel> models)
        {
            return models == null ? null : AutoMapper.Mapper.Map<IList<FixedAssetCategoryModel>, IList<FixedAssetCategoryEntity>>(models);
        }

        #endregion

        #region OpeningAccountEntry

        internal static OpeningFixedAssetEntryModel FromDataTransferObject(OpeningFixedAssetEntryEntity entity)
        {
            return entity == null ? null : AutoMapper.Mapper.Map<OpeningFixedAssetEntryEntity, OpeningFixedAssetEntryModel>(entity);
        }

        internal static OpeningFixedAssetEntryEntity ToDataTransferObject(OpeningFixedAssetEntryModel model)
        {

            return model == null ? null : AutoMapper.Mapper.Map<OpeningFixedAssetEntryModel, OpeningFixedAssetEntryEntity>(model);
        }

        internal static IList<OpeningFixedAssetEntryModel> FromDataTransferObjects(IList<OpeningFixedAssetEntryEntity> entities)
        {
            return entities == null ? null : AutoMapper.Mapper.Map<IList<OpeningFixedAssetEntryEntity>, IList<OpeningFixedAssetEntryModel>>(entities);
        }

        internal static IList<OpeningFixedAssetEntryEntity> ToDataTransferObjects(IList<OpeningFixedAssetEntryModel> models)
        {
            return models == null ? null : AutoMapper.Mapper.Map<IList<OpeningFixedAssetEntryModel>, IList<OpeningFixedAssetEntryEntity>>(models);
        }

        #endregion
    }
}
