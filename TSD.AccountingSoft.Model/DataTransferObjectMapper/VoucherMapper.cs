
using TSD.AccountingSoft.BusinessEntities.Business.Cash;
using TSD.AccountingSoft.BusinessEntities.Business.Deposit;
using TSD.AccountingSoft.BusinessEntities.Business.FixedAssetDecrement;
using TSD.AccountingSoft.BusinessEntities.Business.FixedAssetIncrement;
using TSD.AccountingSoft.BusinessEntities.Business.General;
using TSD.AccountingSoft.BusinessEntities.Business.Inventory;
using TSD.AccountingSoft.BusinessEntities.Business.Tool;
using TSD.AccountingSoft.Model.BusinessObjects.Cash;
using TSD.AccountingSoft.Model.BusinessObjects.Deposit;
using TSD.AccountingSoft.Model.BusinessObjects.FixedAsset;
using TSD.AccountingSoft.Model.BusinessObjects.General;
using TSD.AccountingSoft.Model.BusinessObjects.Inventory;
using TSD.AccountingSoft.Model.BusinessObjects.Tool;
using System;
using System.Collections.Generic;

namespace TSD.AccountingSoft.Model.DataTransferObjectMapper
{
    static class VoucherMapper
    {
        static VoucherMapper()
        {
            AutoMapper.Mapper.CreateMap<ReceiptVoucherParalellDetailModel, CashParalellDetailEntity>();
            AutoMapper.Mapper.CreateMap<CashParalellDetailEntity, ReceiptVoucherParalellDetailModel>();
            AutoMapper.Mapper.CreateMap<CashParalellDetailEntity, CashParalellDetailModel>();
            AutoMapper.Mapper.CreateMap<CashParalellDetailModel, CashParalellDetailEntity>();
            AutoMapper.Mapper.CreateMap<GeneralParalellDetailEntity, GeneralParalellDetailModel>();
            AutoMapper.Mapper.CreateMap<GeneralParalellDetailModel, GeneralParalellDetailEntity>();

            AutoMapper.Mapper.CreateMap<DepositModel, DepositEntity>();
            AutoMapper.Mapper.CreateMap<DepositEntity, DepositModel>();
            AutoMapper.Mapper.CreateMap<DepositDetailModel, DepositDetailEntity>();
            AutoMapper.Mapper.CreateMap<DepositDetailEntity, DepositDetailModel>();
            AutoMapper.Mapper.CreateMap<DepositDetailParallelModel, DepositDetailParallelEntity>();
            AutoMapper.Mapper.CreateMap<DepositDetailParallelEntity, DepositDetailParallelModel>();
            AutoMapper.Mapper.CreateMap<ItemTransactionModel, ItemTransactionEntity>();
            AutoMapper.Mapper.CreateMap<ItemTransactionEntity, ItemTransactionModel>();
            AutoMapper.Mapper.CreateMap<ItemTransactionDetailParallelEntity, ItemTransactionDetailParallelModel>();
            AutoMapper.Mapper.CreateMap<ItemTransactionDetailParallelModel, ItemTransactionDetailParallelEntity>();
            AutoMapper.Mapper.CreateMap<ItemTransactionDetailModel, ItemTransactionDetailEntity>();
            AutoMapper.Mapper.CreateMap<ItemTransactionDetailEntity, ItemTransactionDetailModel>();
            AutoMapper.Mapper.CreateMap<FixedAssetDecrementModel, FADecrementEntity>()
                .ForMember(d => d.FADecrementDetails,
                    opt => opt.MapFrom(src => src.FixedAssetDecrementDetails))
                .ForMember(d => d.FADecrementDetailParallels,
                    opt => opt.MapFrom(src => src.FixedAssetDecrementDetailParallels))
                .ForMember(d => d.RefDate,
                    opt => opt.MapFrom(src => DateTime.Parse(src.RefDate))) //  + new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
                .ForMember(d => d.PostedDate,
                    opt => opt.MapFrom(src => DateTime.Parse(src.PostedDate))); // + new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
            AutoMapper.Mapper.CreateMap<FADecrementEntity, FixedAssetDecrementModel>()
                .ForMember(d => d.FixedAssetDecrementDetails,
                    opt => opt.MapFrom(src => src.FADecrementDetails))
                .ForMember(d => d.FixedAssetDecrementDetailParallels,
                    opt => opt.MapFrom(src => src.FADecrementDetailParallels))
                .ForMember(d => d.RefDate,
                    opt => opt.MapFrom(src => src.RefDate.ToShortDateString()))
                .ForMember(d => d.PostedDate,
                    opt => opt.MapFrom(src => src.PostedDate.ToShortDateString()));
            AutoMapper.Mapper.CreateMap<FixedAssetDecrementDetailModel, FADecrementDetailEntity>();
            AutoMapper.Mapper.CreateMap<FADecrementDetailEntity, FixedAssetDecrementDetailModel>();
            AutoMapper.Mapper.CreateMap<FixedAssetDecrementDetailParallelModel, FADecrementDetailParallelEntity>();
            AutoMapper.Mapper.CreateMap<FADecrementDetailParallelEntity, FixedAssetDecrementDetailParallelModel>();
            AutoMapper.Mapper.CreateMap<FixedAssetIncrementModel, FAIncrementEntity>()
                .ForMember(d => d.FAIncrementDetails,
                    opt => opt.MapFrom(src => src.FixedAssetIncrementDetails))
                .ForMember(d => d.FAIncrementDetailParallels,
                    opt => opt.MapFrom(src => src.FixedAssetIncrementDetailParallels))
                .ForMember(d => d.RefDate,
                    opt => opt.MapFrom(src => DateTime.Parse(src.RefDate) )) // + new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
                .ForMember(d => d.PostedDate,
                    opt => opt.MapFrom(src => DateTime.Parse(src.PostedDate))); // + new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
            AutoMapper.Mapper.CreateMap<FAIncrementEntity, FixedAssetIncrementModel>()
                .ForMember(d => d.FixedAssetIncrementDetails,
                    opt => opt.MapFrom(src => src.FAIncrementDetails))
                .ForMember(d => d.FixedAssetIncrementDetailParallels,
                    opt => opt.MapFrom(src => src.FAIncrementDetailParallels))
                .ForMember(d => d.RefDate,
                    opt => opt.MapFrom(src => src.RefDate.ToShortDateString()))
                .ForMember(d => d.PostedDate,
                    opt => opt.MapFrom(src => src.PostedDate.ToShortDateString()));
            AutoMapper.Mapper.CreateMap<FixedAssetIncrementDetailModel, FAIncrementDetailEntity>();
            AutoMapper.Mapper.CreateMap<FAIncrementDetailEntity, FixedAssetIncrementDetailModel>();
            AutoMapper.Mapper.CreateMap<FixedAssetIncrementDetailParallelModel, FAIncrementDetailParallelEntity>();
            AutoMapper.Mapper.CreateMap<FAIncrementDetailParallelEntity, FixedAssetIncrementDetailParallelModel>();
            AutoMapper.Mapper.CreateMap<GeneralVocherModel, GeneralEntity>()
                .ForMember(d => d.GeneralDetails,
                    opt => opt.MapFrom(src => src.GeneralVoucherDetails));
            AutoMapper.Mapper.CreateMap<GeneralEntity, GeneralVocherModel>()
                .ForMember(d => d.GeneralVoucherDetails,
                    opt => opt.MapFrom(src => src.GeneralDetails));
            AutoMapper.Mapper.CreateMap<GeneralDetailModel, GeneralDetailEntity>();
            AutoMapper.Mapper.CreateMap<GeneralDetailEntity, GeneralDetailModel>();
            AutoMapper.Mapper.CreateMap<GeneralParalellDetailModel, GeneralParalellDetailEntity>();
            AutoMapper.Mapper.CreateMap<GeneralParalellDetailEntity, GeneralParalellDetailModel>();
            AutoMapper.Mapper.CreateMap<SUIncrementDecrementModel, SUIncrementDecrementEntity>();
            AutoMapper.Mapper.CreateMap<SUIncrementDecrementEntity, SUIncrementDecrementModel>();
            AutoMapper.Mapper.CreateMap<SUIncrementDecrementDetailModel, SUIncrementDecrementDetailEntity>();
            AutoMapper.Mapper.CreateMap<SUIncrementDecrementDetailEntity, SUIncrementDecrementDetailModel>();
        }

        #region Unknow

        internal static ReceiptVoucherParalellDetailModel FromDataTransferObject(CashParalellDetailEntity entity)
        {
            return entity == null ? null : AutoMapper.Mapper.Map<CashParalellDetailEntity, ReceiptVoucherParalellDetailModel>(entity);
        }

        internal static CashParalellDetailEntity ToDataTransferObject(ReceiptVoucherParalellDetailModel model)
        {
            return model == null ? null : AutoMapper.Mapper.Map<ReceiptVoucherParalellDetailModel, CashParalellDetailEntity>(model);
        }
        internal static List<ReceiptVoucherParalellDetailModel> FromDataTransferObjects(List<CashParalellDetailEntity> entities)
        {
            return entities == null ? null : AutoMapper.Mapper.Map<List<CashParalellDetailEntity>, List<ReceiptVoucherParalellDetailModel>>(entities);
        }

        internal static List<CashParalellDetailEntity> ToDataTransferObjects(List<ReceiptVoucherParalellDetailModel> models)
        {
            return models == null ? null : AutoMapper.Mapper.Map<List<ReceiptVoucherParalellDetailModel>, List<CashParalellDetailEntity>>(models);
        }

        internal static List<CashParalellDetailModel> CashFromDataTransferObjects(List<CashParalellDetailEntity> entities)
        {
            return entities == null ? null : AutoMapper.Mapper.Map<List<CashParalellDetailEntity>, List<CashParalellDetailModel>>(entities);
        }

        internal static List<CashParalellDetailEntity> CashToDataTransferObjects(IList<CashParalellDetailModel> models)
        {
            return models == null ? null : AutoMapper.Mapper.Map<IList<CashParalellDetailModel>, List<CashParalellDetailEntity>>(models);
        }

        internal static List<GeneralParalellDetailModel> GeneralFromDataTransferObjects(List<GeneralParalellDetailEntity> entities)
        {
            return entities == null ? null : AutoMapper.Mapper.Map<List<GeneralParalellDetailEntity>, List<GeneralParalellDetailModel>>(entities);
        }

        internal static List<GeneralParalellDetailEntity> GeneralToDataTransferObjects(IList<GeneralParalellDetailModel> models)
        {
            return models == null ? null : AutoMapper.Mapper.Map<IList<GeneralParalellDetailModel>, List<GeneralParalellDetailEntity>>(models);
        }

        #endregion

        #region Deposit

        internal static DepositModel FromDataTransferObject(DepositEntity entity)
        {
            return entity == null ? null : AutoMapper.Mapper.Map<DepositEntity, DepositModel>(entity);
        }

        internal static DepositEntity ToDataTransferObject(DepositModel model)
        {
            return model == null ? null : AutoMapper.Mapper.Map<DepositModel, DepositEntity>(model);
        }

        internal static IList<DepositModel> FromDataTransferObjects(IList<DepositEntity> entities)
        {
            return entities == null ? null : AutoMapper.Mapper.Map<IList<DepositEntity>, IList<DepositModel>>(entities);
        }

        internal static IList<DepositEntity> ToDataTransferObjects(IList<DepositModel> models)
        {
            return models == null ? null : AutoMapper.Mapper.Map<IList<DepositModel>, IList<DepositEntity>>(models);
        }

        #endregion

        #region DepositDetailModel

        internal static DepositDetailModel FromDataTransferObject(DepositDetailEntity entity)
        {
            return entity == null ? null : AutoMapper.Mapper.Map<DepositDetailEntity, DepositDetailModel>(entity);
        }

        internal static DepositDetailEntity ToDataTransferObject(DepositDetailModel model)
        {
            return model == null ? null : AutoMapper.Mapper.Map<DepositDetailModel, DepositDetailEntity>(model);
        }

        internal static IList<DepositDetailModel> FromDataTransferObjects(IList<DepositDetailEntity> entities)
        {
            return entities == null ? null : AutoMapper.Mapper.Map<IList<DepositDetailEntity>, IList<DepositDetailModel>>(entities);
        }

        internal static IList<DepositDetailEntity> ToDataTransferObjects(IList<DepositDetailModel> models)
        {
            return models == null ? null : AutoMapper.Mapper.Map<IList<DepositDetailModel>, IList<DepositDetailEntity>>(models);
        }

        #endregion

        #region DepositDetailModel

        internal static DepositDetailParallelModel FromDataTransferObject(DepositDetailParallelEntity entity)
        {
            return entity == null ? null : AutoMapper.Mapper.Map<DepositDetailParallelEntity, DepositDetailParallelModel>(entity);
        }

        internal static DepositDetailParallelEntity ToDataTransferObject(DepositDetailParallelModel model)
        {
            return model == null ? null : AutoMapper.Mapper.Map<DepositDetailParallelModel, DepositDetailParallelEntity>(model);
        }

        internal static IList<DepositDetailParallelModel> FromDataTransferObjects(IList<DepositDetailParallelEntity> entities)
        {
            return entities == null ? null : AutoMapper.Mapper.Map<IList<DepositDetailParallelEntity>, IList<DepositDetailParallelModel>>(entities);
        }

        internal static IList<DepositDetailParallelEntity> ToDataTransferObjects(IList<DepositDetailParallelModel> models)
        {
            return models == null ? null : AutoMapper.Mapper.Map<IList<DepositDetailParallelModel>, IList<DepositDetailParallelEntity>>(models);
        }

        #endregion

        #region ItemTransaction

        internal static ItemTransactionModel FromDataTransferObject(ItemTransactionEntity entity)
        {
            return entity == null ? null : AutoMapper.Mapper.Map<ItemTransactionEntity, ItemTransactionModel>(entity);
        }

        internal static ItemTransactionEntity ToDataTransferObject(ItemTransactionModel model)
        {
            return model == null ? null : AutoMapper.Mapper.Map<ItemTransactionModel, ItemTransactionEntity>(model);
        }

        internal static IList<ItemTransactionModel> FromDataTransferObjects(IList<ItemTransactionEntity> entities)
        {
            return entities == null ? null : AutoMapper.Mapper.Map<IList<ItemTransactionEntity>, IList<ItemTransactionModel>>(entities);
        }

        internal static IList<ItemTransactionEntity> ToDataTransferObjects(IList<ItemTransactionModel> models)
        {
            return models == null ? null : AutoMapper.Mapper.Map<IList<ItemTransactionModel>, IList<ItemTransactionEntity>>(models);
        }

        #endregion

        #region ItemTransactionDetail

        internal static ItemTransactionDetailModel FromDataTransferObject(ItemTransactionDetailEntity entity)
        {
            return entity == null ? null : AutoMapper.Mapper.Map<ItemTransactionDetailEntity, ItemTransactionDetailModel>(entity);
        }

        internal static ItemTransactionDetailEntity ToDataTransferObject(ItemTransactionDetailModel model)
        {
            return model == null ? null : AutoMapper.Mapper.Map<ItemTransactionDetailModel, ItemTransactionDetailEntity>(model);
        }

        internal static IList<ItemTransactionDetailModel> FromDataTransferObjects(IList<ItemTransactionDetailEntity> entities)
        {
            return entities == null ? null : AutoMapper.Mapper.Map<IList<ItemTransactionDetailEntity>, IList<ItemTransactionDetailModel>>(entities);
        }

        internal static IList<ItemTransactionDetailEntity> ToDataTransferObjects(IList<ItemTransactionDetailModel> models)
        {
            return models == null ? null : AutoMapper.Mapper.Map<IList<ItemTransactionDetailModel>, IList<ItemTransactionDetailEntity>>(models);
        }

        #endregion

        #region ItemTransactionDetailParalell

        internal static ItemTransactionDetailParallelModel FromDataTransferObject(ItemTransactionDetailParallelEntity entity)
        {
            return entity == null ? null : AutoMapper.Mapper.Map<ItemTransactionDetailParallelEntity, ItemTransactionDetailParallelModel>(entity);
        }

        internal static ItemTransactionDetailParallelEntity ToDataTransferObject(ItemTransactionDetailParallelModel model)
        {
            return model == null ? null : AutoMapper.Mapper.Map<ItemTransactionDetailParallelModel, ItemTransactionDetailParallelEntity>(model);
        }

        internal static IList<ItemTransactionDetailParallelModel> FromDataTransferObjects(IList<ItemTransactionDetailParallelEntity> entities)
        {
            return entities == null ? null : AutoMapper.Mapper.Map<IList<ItemTransactionDetailParallelEntity>, IList<ItemTransactionDetailParallelModel>>(entities);
        }

        internal static IList<ItemTransactionDetailParallelEntity> ToDataTransferObjects(IList<ItemTransactionDetailParallelModel> models)
        {
            return models == null ? null : AutoMapper.Mapper.Map<IList<ItemTransactionDetailParallelModel>, IList<ItemTransactionDetailParallelEntity>>(models);
        }

        #endregion

        #region FixedAssetDecrement

        internal static FixedAssetDecrementModel FromDataTransferObject(FADecrementEntity entity)
        {
            return entity == null ? null : AutoMapper.Mapper.Map<FADecrementEntity, FixedAssetDecrementModel>(entity);
        }

        internal static FADecrementEntity ToDataTransferObject(FixedAssetDecrementModel model)
        {
            return model == null ? null : AutoMapper.Mapper.Map<FixedAssetDecrementModel, FADecrementEntity>(model);
        }

        internal static IList<FixedAssetDecrementModel> FromDataTransferObjects(IList<FADecrementEntity> entities)
        {
            return entities == null ? null : AutoMapper.Mapper.Map<IList<FADecrementEntity>, IList<FixedAssetDecrementModel>>(entities);
        }

        internal static IList<FADecrementEntity> ToDataTransferObjects(IList<FixedAssetDecrementModel> models)
        {
            return models == null ? null : AutoMapper.Mapper.Map<IList<FixedAssetDecrementModel>, IList<FADecrementEntity>>(models);
        }

        #endregion

        #region FixedAssetDecrementDetail

        internal static FixedAssetDecrementDetailModel FromDataTransferObject(FADecrementDetailEntity entity)
        {
            return entity == null ? null : AutoMapper.Mapper.Map<FADecrementDetailEntity, FixedAssetDecrementDetailModel>(entity);
        }

        internal static FADecrementDetailEntity ToDataTransferObject(FixedAssetDecrementDetailModel model)
        {
            return model == null ? null : AutoMapper.Mapper.Map<FixedAssetDecrementDetailModel, FADecrementDetailEntity>(model);
        }

        internal static IList<FixedAssetDecrementDetailModel> FromDataTransferObjects(IList<FADecrementDetailEntity> entities)
        {
            return entities == null ? null : AutoMapper.Mapper.Map<IList<FADecrementDetailEntity>, IList<FixedAssetDecrementDetailModel>>(entities);
        }

        internal static IList<FADecrementDetailEntity> ToDataTransferObjects(IList<FixedAssetDecrementDetailModel> models)
        {
            return models == null ? null : AutoMapper.Mapper.Map<IList<FixedAssetDecrementDetailModel>, IList<FADecrementDetailEntity>>(models);
        }

        #endregion

        #region FixedAssetDecrementDetailParallel

        internal static FixedAssetDecrementDetailParallelModel FromDataTransferObject(FADecrementDetailParallelEntity entity)
        {
            return entity == null ? null : AutoMapper.Mapper.Map<FADecrementDetailParallelEntity, FixedAssetDecrementDetailParallelModel>(entity);
        }

        internal static FADecrementDetailParallelEntity ToDataTransferObject(FixedAssetDecrementDetailParallelModel model)
        {
            return model == null ? null : AutoMapper.Mapper.Map<FixedAssetDecrementDetailParallelModel, FADecrementDetailParallelEntity>(model);
        }

        internal static IList<FixedAssetDecrementDetailParallelModel> FromDataTransferObjects(IList<FADecrementDetailParallelEntity> entities)
        {
            return entities == null ? null : AutoMapper.Mapper.Map<IList<FADecrementDetailParallelEntity>, IList<FixedAssetDecrementDetailParallelModel>>(entities);
        }

        internal static IList<FADecrementDetailParallelEntity> ToDataTransferObjects(IList<FixedAssetDecrementDetailParallelModel> models)
        {
            return models == null ? null : AutoMapper.Mapper.Map<IList<FixedAssetDecrementDetailParallelModel>, IList<FADecrementDetailParallelEntity>>(models);
        }

        #endregion

        #region FixedAssetIncrement

        internal static FixedAssetIncrementModel FromDataTransferObject(FAIncrementEntity entity)
        {
            return entity == null ? null : AutoMapper.Mapper.Map<FAIncrementEntity, FixedAssetIncrementModel>(entity);
        }

        internal static FAIncrementEntity ToDataTransferObject(FixedAssetIncrementModel model)
        {
            return model == null ? null : AutoMapper.Mapper.Map<FixedAssetIncrementModel, FAIncrementEntity>(model);
        }

        internal static IList<FixedAssetIncrementModel> FromDataTransferObjects(IList<FAIncrementEntity> entities)
        {
            return entities == null ? null : AutoMapper.Mapper.Map<IList<FAIncrementEntity>, IList<FixedAssetIncrementModel>>(entities);
        }

        internal static IList<FAIncrementEntity> ToDataTransferObjects(IList<FixedAssetIncrementModel> models)
        {
            return models == null ? null : AutoMapper.Mapper.Map<IList<FixedAssetIncrementModel>, IList<FAIncrementEntity>>(models);
        }

        #endregion

        #region FixedAssetIncrementDetail

        internal static FixedAssetIncrementDetailModel FromDataTransferObject(FAIncrementDetailEntity entity)
        {
            return entity == null ? null : AutoMapper.Mapper.Map<FAIncrementDetailEntity, FixedAssetIncrementDetailModel>(entity);
        }

        internal static FAIncrementDetailEntity ToDataTransferObject(FixedAssetIncrementDetailModel model)
        {
            return model == null ? null : AutoMapper.Mapper.Map<FixedAssetIncrementDetailModel, FAIncrementDetailEntity>(model);
        }

        internal static IList<FixedAssetIncrementDetailModel> FromDataTransferObjects(IList<FAIncrementDetailEntity> entities)
        {
            return entities == null ? null : AutoMapper.Mapper.Map<IList<FAIncrementDetailEntity>, IList<FixedAssetIncrementDetailModel>>(entities);
        }

        internal static IList<FAIncrementDetailEntity> ToDataTransferObjects(IList<FixedAssetIncrementDetailModel> models)
        {
            return models == null ? null : AutoMapper.Mapper.Map<IList<FixedAssetIncrementDetailModel>, IList<FAIncrementDetailEntity>>(models);
        }

        #endregion

        #region FixedAssetIncrementDetailParallel

        internal static FixedAssetIncrementDetailParallelModel FromDataTransferObject(FAIncrementDetailParallelEntity entity)
        {
            return entity == null ? null : AutoMapper.Mapper.Map<FAIncrementDetailParallelEntity, FixedAssetIncrementDetailParallelModel>(entity);
        }

        internal static FAIncrementDetailParallelEntity ToDataTransferObject(FixedAssetIncrementDetailParallelModel model)
        {
            return model == null ? null : AutoMapper.Mapper.Map<FixedAssetIncrementDetailParallelModel, FAIncrementDetailParallelEntity>(model);
        }

        internal static IList<FixedAssetIncrementDetailParallelModel> FromDataTransferObjects(IList<FAIncrementDetailParallelEntity> entities)
        {
            return entities == null ? null : AutoMapper.Mapper.Map<IList<FAIncrementDetailParallelEntity>, IList<FixedAssetIncrementDetailParallelModel>>(entities);
        }

        internal static IList<FAIncrementDetailParallelEntity> ToDataTransferObjects(IList<FixedAssetIncrementDetailParallelModel> models)
        {
            return models == null ? null : AutoMapper.Mapper.Map<IList<FixedAssetIncrementDetailParallelModel>, IList<FAIncrementDetailParallelEntity>>(models);
        }

        #endregion

        #region GeneralVoucher

        internal static GeneralVocherModel FromDataTransferObject(GeneralEntity entity)
        {
            return entity == null ? null : AutoMapper.Mapper.Map<GeneralEntity, GeneralVocherModel>(entity);
        }

        internal static GeneralEntity ToDataTransferObject(GeneralVocherModel model)
        {
            return model == null ? null : AutoMapper.Mapper.Map<GeneralVocherModel, GeneralEntity>(model);
        }

        internal static IList<GeneralVocherModel> FromDataTransferObjects(IList<GeneralEntity> entities)
        {
            return entities == null ? null : AutoMapper.Mapper.Map<IList<GeneralEntity>, IList<GeneralVocherModel>>(entities);
        }

        internal static IList<GeneralEntity> ToDataTransferObjects(IList<GeneralVocherModel> models)
        {
            return models == null ? null : AutoMapper.Mapper.Map<IList<GeneralVocherModel>, IList<GeneralEntity>>(models);
        }

        #endregion

        #region GeneralVoucherDetail

        internal static GeneralDetailModel FromDataTransferObject(GeneralDetailEntity entity)
        {
            return entity == null ? null : AutoMapper.Mapper.Map<GeneralDetailEntity, GeneralDetailModel>(entity);
        }

        internal static GeneralDetailEntity ToDataTransferObject(GeneralDetailModel model)
        {
            return model == null ? null : AutoMapper.Mapper.Map<GeneralDetailModel, GeneralDetailEntity>(model);
        }

        internal static IList<GeneralDetailModel> FromDataTransferObjects(IList<GeneralDetailEntity> entities)
        {
            return entities == null ? null : AutoMapper.Mapper.Map<IList<GeneralDetailEntity>, IList<GeneralDetailModel>>(entities);
        }

        internal static IList<GeneralDetailEntity> ToDataTransferObjects(IList<GeneralDetailModel> models)
        {
            return models == null ? null : AutoMapper.Mapper.Map<IList<GeneralDetailModel>, IList<GeneralDetailEntity>>(models);
        }

        #endregion

        #region GeneralParalellDetailEntity

        internal static GeneralParalellDetailModel FromDataTransferObject(GeneralParalellDetailEntity entity)
        {
            return entity == null ? null : AutoMapper.Mapper.Map<GeneralParalellDetailEntity, GeneralParalellDetailModel>(entity);
        }

        internal static GeneralParalellDetailEntity ToDataTransferObject(GeneralParalellDetailModel model)
        {
            return model == null ? null : AutoMapper.Mapper.Map<GeneralParalellDetailModel, GeneralParalellDetailEntity>(model);
        }

        internal static IList<GeneralParalellDetailModel> FromDataTransferObjects(IList<GeneralParalellDetailEntity> entities)
        {
            return entities == null ? null : AutoMapper.Mapper.Map<IList<GeneralParalellDetailEntity>, IList<GeneralParalellDetailModel>>(entities);
        }

        internal static IList<GeneralParalellDetailEntity> ToDataTransferObjects(IList<GeneralParalellDetailModel> models)
        {
            return models == null ? null : AutoMapper.Mapper.Map<IList<GeneralParalellDetailModel>, IList<GeneralParalellDetailEntity>>(models);
        }

        #endregion

        #region SUIncrementDecrement

        internal static SUIncrementDecrementModel FromDataTransferObject(SUIncrementDecrementEntity entity)
        {
            return entity == null ? null : AutoMapper.Mapper.Map<SUIncrementDecrementEntity, SUIncrementDecrementModel>(entity);
        }

        internal static SUIncrementDecrementEntity ToDataTransferObject(SUIncrementDecrementModel model)
        {
            return model == null ? null : AutoMapper.Mapper.Map<SUIncrementDecrementModel, SUIncrementDecrementEntity>(model);
        }

        internal static IList<SUIncrementDecrementModel> FromDataTransferObjects(IList<SUIncrementDecrementEntity> entities)
        {
            return entities == null ? null : AutoMapper.Mapper.Map<IList<SUIncrementDecrementEntity>, IList<SUIncrementDecrementModel>>(entities);
        }

        internal static IList<SUIncrementDecrementEntity> ToDataTransferObjects(IList<SUIncrementDecrementModel> models)
        {
            return models == null ? null : AutoMapper.Mapper.Map<IList<SUIncrementDecrementModel>, IList<SUIncrementDecrementEntity>>(models);
        }

        #endregion

        #region SUIncrementDecrementDetail

        internal static SUIncrementDecrementDetailModel FromDataTransferObject(SUIncrementDecrementDetailEntity entity)
        {
            return entity == null ? null : AutoMapper.Mapper.Map<SUIncrementDecrementDetailEntity, SUIncrementDecrementDetailModel>(entity);
        }

        internal static SUIncrementDecrementDetailEntity ToDataTransferObject(SUIncrementDecrementDetailModel model)
        {
            return model == null ? null : AutoMapper.Mapper.Map<SUIncrementDecrementDetailModel, SUIncrementDecrementDetailEntity>(model);
        }

        internal static IList<SUIncrementDecrementDetailModel> FromDataTransferObjects(IList<SUIncrementDecrementDetailEntity> entities)
        {
            return entities == null ? null : AutoMapper.Mapper.Map<IList<SUIncrementDecrementDetailEntity>, IList<SUIncrementDecrementDetailModel>>(entities);
        }

        internal static IList<SUIncrementDecrementDetailEntity> ToDataTransferObjects(IList<SUIncrementDecrementDetailModel> models)
        {
            return models == null ? null : AutoMapper.Mapper.Map<IList<SUIncrementDecrementDetailModel>, IList<SUIncrementDecrementDetailEntity>>(models);
        }

        #endregion
    }
}
