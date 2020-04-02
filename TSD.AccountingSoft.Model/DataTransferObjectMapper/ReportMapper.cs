using TSD.AccountingSoft.BusinessEntities.Report;
using TSD.AccountingSoft.BusinessEntities.Report.Finacial;
using TSD.AccountingSoft.BusinessEntities.Report.FixedAsset;
using TSD.AccountingSoft.Model.BusinessObjects.Report;
using TSD.AccountingSoft.Model.BusinessObjects.Report.Finacial;
using TSD.AccountingSoft.Model.BusinessObjects.Report.FixedAsset;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.Model.DataTransferObjectMapper
{
    static class ReportMapper
    {
        static ReportMapper()
        {
            AutoMapper.Mapper.CreateMap<S05HModel, S05HEntity>();
            AutoMapper.Mapper.CreateMap<S05HEntity, S05HModel>();
            AutoMapper.Mapper.CreateMap<B01BCQTModel, B01BCQTEntity>();
            AutoMapper.Mapper.CreateMap<B01BCQTEntity, B01BCQTModel>();
            AutoMapper.Mapper.CreateMap<AdvancePaymentEntity, AdvancePaymentModel>();
            AutoMapper.Mapper.CreateMap<AdvancePaymentModel, AdvancePaymentEntity>();
            AutoMapper.Mapper.CreateMap<ReportF03BCTEntity, ReportF03BCTModel>();
            AutoMapper.Mapper.CreateMap<ReportF03BCTModel, ReportF03BCTEntity>();
            AutoMapper.Mapper.CreateMap<ReportF03BCTDetailEntity, ReportF03BCTDetailModel>();
            AutoMapper.Mapper.CreateMap<ReportF03BCTDetailModel, ReportF03BCTDetailEntity>();
            AutoMapper.Mapper.CreateMap<ReportB01CIIEntity, ReportB01CIIModel>();
            AutoMapper.Mapper.CreateMap<ReportB01CIIModel, ReportB01CIIEntity>();
            AutoMapper.Mapper.CreateMap<ReportB01CIEntity, ReportB01CIModel>();
            AutoMapper.Mapper.CreateMap<ReportB01CIModel, ReportB01CIEntity>();
            AutoMapper.Mapper.CreateMap<FixedAssetS26HEntity, FixedAssetS26HModel>();
            AutoMapper.Mapper.CreateMap<FixedAssetS26HModel, FixedAssetS26HEntity>();
            AutoMapper.Mapper.CreateMap<ReportS104HEntity, ReportS104HModel>();
            AutoMapper.Mapper.CreateMap<ReportS104HModel, ReportS104HEntity>();
            AutoMapper.Mapper.CreateMap<ReportB01CII01Entity, ReportB01CII01Model>();
            AutoMapper.Mapper.CreateMap<ReportB01CII01Model, ReportB01CII01Entity>();
            AutoMapper.Mapper.CreateMap<ReportB01CII01ExchangeRateEntity, ReportB01CII01ExchangeRateModel>();
            AutoMapper.Mapper.CreateMap<ReportB01CII01ExchangeRateModel, ReportB01CII01ExchangeRateEntity>();
            AutoMapper.Mapper.CreateMap<ReportB01CII01ReportEntity, ReportB01CII01ReportModel>();
            AutoMapper.Mapper.CreateMap<ReportB01CII01ReportModel, ReportB01CII01ReportEntity>();
            AutoMapper.Mapper.CreateMap<ReportB01BCTCEntity, ReportB01BCTCModel>();
            AutoMapper.Mapper.CreateMap<ReportB01BCTCModel, ReportB01BCTCEntity>();
            AutoMapper.Mapper.CreateMap<ReportActivityB02Model, ReportActivityB02Entity>();
            AutoMapper.Mapper.CreateMap<ReportActivityB02Entity, ReportActivityB02Model>();
            AutoMapper.Mapper.CreateMap<FixedAssetCardsModel, FixedAssetCardsEntity>();
            AutoMapper.Mapper.CreateMap<FixedAssetCardsEntity, FixedAssetCardsModel>();
            AutoMapper.Mapper.CreateMap<FixedAssetDetailCards01Model, FixedAssetDetailCards01Entity>();
            AutoMapper.Mapper.CreateMap<FixedAssetDetailCards01Entity, FixedAssetDetailCards01Model>();
            AutoMapper.Mapper.CreateMap<FixedAssetDetailCards02Model, FixedAssetDetailCards02Entity>();
            AutoMapper.Mapper.CreateMap<FixedAssetDetailCards02Entity, FixedAssetDetailCards02Model>();
            AutoMapper.Mapper.CreateMap<FixedAssetS24HModel, FixedAssetS24HEntity>();
            AutoMapper.Mapper.CreateMap<FixedAssetS24HEntity, FixedAssetS24HModel>();
            AutoMapper.Mapper.CreateMap<ReportB03bBCTCModel, ReportB03bBCTCEntity>();
            AutoMapper.Mapper.CreateMap<ReportB03bBCTCEntity, ReportB03bBCTCModel>();
            AutoMapper.Mapper.CreateMap<ReportB04BCTCModel, ReportB04BCTCEntity>();
            AutoMapper.Mapper.CreateMap<ReportB04BCTCEntity, ReportB04BCTCModel>();
            AutoMapper.Mapper.CreateMap<ReportB04BCTCDetail01Model, ReportB04BCTCDetail01Entity>();
            AutoMapper.Mapper.CreateMap<ReportB04BCTCDetail01Entity, ReportB04BCTCDetail01Model>();
            AutoMapper.Mapper.CreateMap<ReportB04BCTCDetail02Model, ReportB04BCTCDetail02Entity>();
            AutoMapper.Mapper.CreateMap<ReportB04BCTCDetail02Entity, ReportB04BCTCDetail02Model>();
            AutoMapper.Mapper.CreateMap<ReportB04BCTCDetail03Model, ReportB04BCTCDetail03Entity>();
            AutoMapper.Mapper.CreateMap<ReportB04BCTCDetail03Entity, ReportB04BCTCDetail03Model>();
            AutoMapper.Mapper.CreateMap<ReportDataTemplateModel, ReportDataTemplateEntity>();
            AutoMapper.Mapper.CreateMap<ReportDataTemplateEntity, ReportDataTemplateModel>();
            AutoMapper.Mapper.CreateMap<BusinessObjects.Report.LedgerAccounting.ReportS104HModel, BusinessEntities.Report.LedgerAccounting.ReportS104HEntity>();
            AutoMapper.Mapper.CreateMap<BusinessEntities.Report.LedgerAccounting.ReportS104HEntity, BusinessObjects.Report.LedgerAccounting.ReportS104HModel>();
        }

        #region Deposit

        internal static S05HModel FromDataTransferObject(S05HEntity entity)
        {
            return entity == null ? null : AutoMapper.Mapper.Map<S05HEntity, S05HModel>(entity);
        }

        internal static S05HEntity ToDataTransferObject(S05HModel model)
        {
            return model == null ? null : AutoMapper.Mapper.Map<S05HModel, S05HEntity>(model);
        }

        internal static IList<S05HModel> FromDataTransferObjects(IList<S05HEntity> entities)
        {
            return entities == null ? null : AutoMapper.Mapper.Map<IList<S05HEntity>, IList<S05HModel>>(entities);
        }

        internal static IList<S05HEntity> ToDataTransferObjects(IList<S05HModel> models)
        {
            return models == null ? null : AutoMapper.Mapper.Map<IList<S05HModel>, IList<S05HEntity>>(models);
        }
        internal static IList<AdvancePaymentModel> FromDataTransferObjects(IList<AdvancePaymentEntity> entities)
        {
            return entities == null ? null : AutoMapper.Mapper.Map<IList<AdvancePaymentEntity>, IList<AdvancePaymentModel>>(entities);
        }
        #endregion

        #region Finacial

        #region Finacial Report B01/BCQT

        internal static B01BCQTModel FromDataTransferObject(B01BCQTEntity entity)
        {
            return entity == null ? null : AutoMapper.Mapper.Map<B01BCQTEntity, B01BCQTModel>(entity);
        }

        internal static B01BCQTEntity ToDataTransferObject(B01BCQTModel model)
        {
            return model == null ? null : AutoMapper.Mapper.Map<B01BCQTModel, B01BCQTEntity>(model);
        }

        internal static IList<B01BCQTModel> FromDataTransferObjects(IList<B01BCQTEntity> entities)
        {
            return entities == null ? null : AutoMapper.Mapper.Map<IList<B01BCQTEntity>, IList<B01BCQTModel>>(entities);
        }

        internal static IList<B01BCQTEntity> ToDataTransferObjects(IList<B01BCQTModel> models)
        {
            return models == null ? null : AutoMapper.Mapper.Map<IList<B01BCQTModel>, IList<B01BCQTEntity>>(models);
        }

        #endregion

        #region Finacial Report F03BCT

        internal static ReportF03BCTModel FromDataTransferObject(ReportF03BCTEntity entity)
        {
            return entity == null ? null : AutoMapper.Mapper.Map<ReportF03BCTEntity, ReportF03BCTModel>(entity);
        }

        internal static ReportF03BCTEntity ToDataTransferObject(ReportF03BCTModel model)
        {
            return model == null ? null : AutoMapper.Mapper.Map<ReportF03BCTModel, ReportF03BCTEntity>(model);
        }

        internal static IList<ReportF03BCTModel> FromDataTransferObjects(IList<ReportF03BCTEntity> entities)
        {
            return entities == null ? null : AutoMapper.Mapper.Map<IList<ReportF03BCTEntity>, IList<ReportF03BCTModel>>(entities);
        }

        internal static IList<ReportF03BCTEntity> ToDataTransferObjects(IList<ReportF03BCTModel> models)
        {
            return models == null ? null : AutoMapper.Mapper.Map<IList<ReportF03BCTModel>, IList<ReportF03BCTEntity>>(models);
        }
        internal static ReportF03BCTDetailModel FromDataTransferObject(ReportF03BCTDetailEntity entity)
        {
            return entity == null ? null : AutoMapper.Mapper.Map<ReportF03BCTDetailEntity, ReportF03BCTDetailModel>(entity);
        }

        internal static ReportF03BCTDetailEntity ToDataTransferObject(ReportF03BCTDetailModel model)
        {
            return model == null ? null : AutoMapper.Mapper.Map<ReportF03BCTDetailModel, ReportF03BCTDetailEntity>(model);
        }

        internal static IList<ReportF03BCTDetailModel> FromDataTransferObjects(IList<ReportF03BCTDetailEntity> entities)
        {
            return entities == null ? null : AutoMapper.Mapper.Map<IList<ReportF03BCTDetailEntity>, IList<ReportF03BCTDetailModel>>(entities);
        }

        internal static IList<ReportF03BCTDetailEntity> ToDataTransferObjects(IList<ReportF03BCTDetailModel> models)
        {
            return models == null ? null : AutoMapper.Mapper.Map<IList<ReportF03BCTDetailModel>, IList<ReportF03BCTDetailEntity>>(models);
        }

        #endregion

        #region Finacial Report B01BCTC

        internal static ReportB01BCTCModel FromDataTransferObject(ReportB01BCTCEntity entity)
        {
            return entity == null ? null : AutoMapper.Mapper.Map<ReportB01BCTCEntity, ReportB01BCTCModel>(entity);
        }

        internal static ReportB01BCTCEntity ToDataTransferObject(ReportB01BCTCModel model)
        {
            return model == null ? null : AutoMapper.Mapper.Map<ReportB01BCTCModel, ReportB01BCTCEntity>(model);
        }

        internal static IList<ReportB01BCTCModel> FromDataTransferObjects(IList<ReportB01BCTCEntity> entities)
        {
            return entities == null ? null : AutoMapper.Mapper.Map<IList<ReportB01BCTCEntity>, IList<ReportB01BCTCModel>>(entities);
        }

        internal static IList<ReportB01BCTCEntity> ToDataTransferObjects(IList<ReportB01BCTCModel> models)
        {
            return models == null ? null : AutoMapper.Mapper.Map<IList<ReportB01BCTCModel>, IList<ReportB01BCTCEntity>>(models);
        }

        #endregion

        #region Finacial Report B03bBCTC

        internal static ReportB03bBCTCModel FromDataTransferObject(ReportB03bBCTCEntity entity)
        {
            return entity == null ? null : AutoMapper.Mapper.Map<ReportB03bBCTCEntity, ReportB03bBCTCModel>(entity);
        }

        internal static ReportB03bBCTCEntity ToDataTransferObject(ReportB03bBCTCModel model)
        {
            return model == null ? null : AutoMapper.Mapper.Map<ReportB03bBCTCModel, ReportB03bBCTCEntity>(model);
        }

        internal static IList<ReportB03bBCTCModel> FromDataTransferObjects(IList<ReportB03bBCTCEntity> entities)
        {
            return entities == null ? null : AutoMapper.Mapper.Map<IList<ReportB03bBCTCEntity>, IList<ReportB03bBCTCModel>>(entities);
        }

        internal static IList<ReportB03bBCTCEntity> ToDataTransferObjects(IList<ReportB03bBCTCModel> models)
        {
            return models == null ? null : AutoMapper.Mapper.Map<IList<ReportB03bBCTCModel>, IList<ReportB03bBCTCEntity>>(models);
        }

        #endregion

        #region GetReportActivityB02

        internal static IList<ReportActivityB02Model> FromDataTransferObjects(IList<ReportActivityB02Entity> entities)
        {
            return entities == null ? null : AutoMapper.Mapper.Map<IList<ReportActivityB02Entity>, IList<ReportActivityB02Model>>(entities);
        }

        #endregion

        #region ReportB04BCTC

        internal static IList<ReportB04BCTCModel> FromDataTransferObjects(IList<ReportB04BCTCEntity> entities)
        {
            return entities == null ? null : AutoMapper.Mapper.Map<IList<ReportB04BCTCEntity>, IList<ReportB04BCTCModel>>(entities);
        }

        #endregion

        #endregion

        #region Settlement

        #region Settlement Report B01CII

        internal static ReportB01CIIModel FromDataTransferObject(ReportB01CIIEntity entity)
        {
            return entity == null ? null : AutoMapper.Mapper.Map<ReportB01CIIEntity, ReportB01CIIModel>(entity);
        }

        internal static ReportB01CIIEntity ToDataTransferObject(ReportB01CIIModel model)
        {
            return model == null ? null : AutoMapper.Mapper.Map<ReportB01CIIModel, ReportB01CIIEntity>(model);
        }

        internal static IList<ReportB01CIIModel> FromDataTransferObjects(IList<ReportB01CIIEntity> entities)
        {
            return entities == null ? null : AutoMapper.Mapper.Map<IList<ReportB01CIIEntity>, IList<ReportB01CIIModel>>(entities);
        }

        internal static IList<ReportB01CIIEntity> ToDataTransferObjects(IList<ReportB01CIIModel> models)
        {
            return models == null ? null : AutoMapper.Mapper.Map<IList<ReportB01CIIModel>, IList<ReportB01CIIEntity>>(models);
        }

        #endregion

        #region Settlement Report B01CI

        internal static ReportB01CIModel FromDataTransferObject(ReportB01CIEntity entity)
        {
            return entity == null ? null : AutoMapper.Mapper.Map<ReportB01CIEntity, ReportB01CIModel>(entity);
        }

        internal static ReportB01CIEntity ToDataTransferObject(ReportB01CIModel model)
        {
            return model == null ? null : AutoMapper.Mapper.Map<ReportB01CIModel, ReportB01CIEntity>(model);
        }

        internal static IList<ReportB01CIModel> FromDataTransferObjects(IList<ReportB01CIEntity> entities)
        {
            return entities == null ? null : AutoMapper.Mapper.Map<IList<ReportB01CIEntity>, IList<ReportB01CIModel>>(entities);
        }

        internal static IList<ReportB01CIEntity> ToDataTransferObjects(IList<ReportB01CIModel> models)
        {
            return models == null ? null : AutoMapper.Mapper.Map<IList<ReportB01CIModel>, IList<ReportB01CIEntity>>(models);
        }

        #endregion

        #region Settlement Report S104-H

        internal static ReportS104HModel FromDataTransferObject(ReportS104HEntity entity)
        {
            return entity == null ? null : AutoMapper.Mapper.Map<ReportS104HEntity, ReportS104HModel>(entity);
        }

        internal static ReportS104HEntity ToDataTransferObject(ReportS104HModel model)
        {
            return model == null ? null : AutoMapper.Mapper.Map<ReportS104HModel, ReportS104HEntity>(model);
        }

        internal static IList<ReportS104HModel> FromDataTransferObjects(IList<ReportS104HEntity> entities)
        {
            return entities == null ? null : AutoMapper.Mapper.Map<IList<ReportS104HEntity>, IList<ReportS104HModel>>(entities);
        }

        internal static IList<ReportS104HEntity> ToDataTransferObjects(IList<ReportS104HModel> models)
        {
            return models == null ? null : AutoMapper.Mapper.Map<IList<ReportS104HModel>, IList<ReportS104HEntity>>(models);
        }

        #endregion

        #region Settlement Report B01CII

        internal static ReportB01CII01Model FromDataTransferObject(ReportB01CII01Entity entity)
        {
            return entity == null ? null : AutoMapper.Mapper.Map<ReportB01CII01Entity, ReportB01CII01Model>(entity);
        }

        internal static ReportB01CII01Entity ToDataTransferObject(ReportB01CII01Model model)
        {
            return model == null ? null : AutoMapper.Mapper.Map<ReportB01CII01Model, ReportB01CII01Entity>(model);
        }

        internal static IList<ReportB01CII01Model> FromDataTransferObjects(IList<ReportB01CII01Entity> entities)
        {
            return entities == null ? null : AutoMapper.Mapper.Map<IList<ReportB01CII01Entity>, IList<ReportB01CII01Model>>(entities);
        }

        internal static IList<ReportB01CII01Entity> ToDataTransferObjects(IList<ReportB01CII01Model> models)
        {
            return models == null ? null : AutoMapper.Mapper.Map<IList<ReportB01CII01Model>, IList<ReportB01CII01Entity>>(models);
        }

        internal static ReportB01CII01ExchangeRateModel FromDataTransferObject(ReportB01CII01ExchangeRateEntity entity)
        {
            return entity == null ? null : AutoMapper.Mapper.Map<ReportB01CII01ExchangeRateEntity, ReportB01CII01ExchangeRateModel>(entity);
        }

        internal static ReportB01CII01ExchangeRateEntity ToDataTransferObject(ReportB01CII01ExchangeRateModel model)
        {
            return model == null ? null : AutoMapper.Mapper.Map<ReportB01CII01ExchangeRateModel, ReportB01CII01ExchangeRateEntity>(model);
        }

        internal static IList<ReportB01CII01ExchangeRateModel> FromDataTransferObjects(IList<ReportB01CII01ExchangeRateEntity> entities)
        {
            return entities == null ? null : AutoMapper.Mapper.Map<IList<ReportB01CII01ExchangeRateEntity>, IList<ReportB01CII01ExchangeRateModel>>(entities);
        }

        internal static IList<ReportB01CII01ExchangeRateEntity> ToDataTransferObjects(IList<ReportB01CII01ExchangeRateModel> models)
        {
            return models == null ? null : AutoMapper.Mapper.Map<IList<ReportB01CII01ExchangeRateModel>, IList<ReportB01CII01ExchangeRateEntity>>(models);
        }

        internal static ReportB01CII01ReportModel FromDataTransferObject(ReportB01CII01ReportEntity entity)
        {
            return entity == null ? null : AutoMapper.Mapper.Map<ReportB01CII01ReportEntity, ReportB01CII01ReportModel>(entity);
        }

        internal static ReportB01CII01ReportEntity ToDataTransferObject(ReportB01CII01ReportModel model)
        {
            return model == null ? null : AutoMapper.Mapper.Map<ReportB01CII01ReportModel, ReportB01CII01ReportEntity>(model);
        }

        internal static IList<ReportB01CII01ReportModel> FromDataTransferObjects(IList<ReportB01CII01ReportEntity> entities)
        {
            return entities == null ? null : AutoMapper.Mapper.Map<IList<ReportB01CII01ReportEntity>, IList<ReportB01CII01ReportModel>>(entities);
        }

        internal static IList<ReportB01CII01ReportEntity> ToDataTransferObjects(IList<ReportB01CII01ReportModel> models)
        {
            return models == null ? null : AutoMapper.Mapper.Map<IList<ReportB01CII01ReportModel>, IList<ReportB01CII01ReportEntity>>(models);
        }

        #endregion

        #endregion

        #region FixedAsset

        #region FixedAsset Report S26H

        internal static FixedAssetS26HModel FromDataTransferObject(FixedAssetS26HEntity entity)
        {
            return entity == null ? null : AutoMapper.Mapper.Map<FixedAssetS26HEntity, FixedAssetS26HModel>(entity);
        }

        internal static FixedAssetS26HEntity ToDataTransferObject(FixedAssetS26HModel model)
        {
            return model == null ? null : AutoMapper.Mapper.Map<FixedAssetS26HModel, FixedAssetS26HEntity>(model);
        }

        internal static IList<FixedAssetS26HModel> FromDataTransferObjects(IList<FixedAssetS26HEntity> entities)
        {
            return entities == null ? null : AutoMapper.Mapper.Map<IList<FixedAssetS26HEntity>, IList<FixedAssetS26HModel>>(entities);
        }

        internal static IList<FixedAssetS26HEntity> ToDataTransferObjects(IList<FixedAssetS26HModel> models)
        {
            return models == null ? null : AutoMapper.Mapper.Map<IList<FixedAssetS26HModel>, IList<FixedAssetS26HEntity>>(models);
        }

        #endregion

        #region FixedAssetCard

        //internal static FixedAssetMasterCardsModel FromDataTransferObject(FixedAssetMasterCardsEntity entity)
        //{
        //    return entity == null ? null : AutoMapper.Mapper.Map<FixedAssetMasterCardsEntity, FixedAssetMasterCardsModel>(entity);
        //}

        //internal static FixedAssetMasterCardsEntity ToDataTransferObject(FixedAssetMasterCardsModel model)
        //{
        //    return model == null ? null : AutoMapper.Mapper.Map<FixedAssetMasterCardsModel, FixedAssetMasterCardsEntity>(model);
        //}

        //internal static IList<FixedAssetMasterCardsModel> FromDataTransferObjects(IList<FixedAssetMasterCardsEntity> entities)
        //{
        //    return entities == null ? null : AutoMapper.Mapper.Map<IList<FixedAssetMasterCardsEntity>, IList<FixedAssetMasterCardsModel>>(entities);
        //}

        //internal static IList<FixedAssetMasterCardsEntity> ToDataTransferObjects(IList<FixedAssetMasterCardsModel> models)
        //{
        //    return models == null ? null : AutoMapper.Mapper.Map<IList<FixedAssetMasterCardsModel>, IList<FixedAssetMasterCardsEntity>>(models);
        //}

        internal static FixedAssetDetailCards01Model FromDataTransferObject(FixedAssetDetailCards01Entity entity)
        {
            return entity == null ? null : AutoMapper.Mapper.Map<FixedAssetDetailCards01Entity, FixedAssetDetailCards01Model>(entity);
        }

        internal static FixedAssetDetailCards01Entity ToDataTransferObject(FixedAssetDetailCards01Model model)
        {
            return model == null ? null : AutoMapper.Mapper.Map<FixedAssetDetailCards01Model, FixedAssetDetailCards01Entity>(model);
        }

        internal static IList<FixedAssetDetailCards01Model> FromDataTransferObjects(IList<FixedAssetDetailCards01Entity> entities)
        {
            return entities == null ? null : AutoMapper.Mapper.Map<IList<FixedAssetDetailCards01Entity>, IList<FixedAssetDetailCards01Model>>(entities);
        }

        internal static IList<FixedAssetDetailCards01Entity> ToDataTransferObjects(IList<FixedAssetDetailCards01Model> models)
        {
            return models == null ? null : AutoMapper.Mapper.Map<IList<FixedAssetDetailCards01Model>, IList<FixedAssetDetailCards01Entity>>(models);
        }

        internal static FixedAssetDetailCards02Model FromDataTransferObject(FixedAssetDetailCards02Entity entity)
        {
            return entity == null ? null : AutoMapper.Mapper.Map<FixedAssetDetailCards02Entity, FixedAssetDetailCards02Model>(entity);
        }

        internal static FixedAssetDetailCards02Entity ToDataTransferObject(FixedAssetDetailCards02Model model)
        {
            return model == null ? null : AutoMapper.Mapper.Map<FixedAssetDetailCards02Model, FixedAssetDetailCards02Entity>(model);
        }

        internal static IList<FixedAssetDetailCards02Model> FromDataTransferObjects(IList<FixedAssetDetailCards02Entity> entities)
        {
            return entities == null ? null : AutoMapper.Mapper.Map<IList<FixedAssetDetailCards02Entity>, IList<FixedAssetDetailCards02Model>>(entities);
        }

        internal static IList<FixedAssetDetailCards02Entity> ToDataTransferObjects(IList<FixedAssetDetailCards02Model> models)
        {
            return models == null ? null : AutoMapper.Mapper.Map<IList<FixedAssetDetailCards02Model>, IList<FixedAssetDetailCards02Entity>>(models);
        }

        internal static FixedAssetCardsModel FromDataTransferObject(FixedAssetCardsEntity entity)
        {
            return entity == null ? null : AutoMapper.Mapper.Map<FixedAssetCardsEntity, FixedAssetCardsModel>(entity);
        }

        internal static FixedAssetCardsEntity ToDataTransferObject(FixedAssetCardsModel model)
        {
            return model == null ? null : AutoMapper.Mapper.Map<FixedAssetCardsModel, FixedAssetCardsEntity>(model);
        }

        internal static IList<FixedAssetCardsModel> FromDataTransferObjects(IList<FixedAssetCardsEntity> entities)
        {
            return entities == null ? null : AutoMapper.Mapper.Map<IList<FixedAssetCardsEntity>, IList<FixedAssetCardsModel>>(entities);
        }

        internal static IList<FixedAssetCardsEntity> ToDataTransferObjects(IList<FixedAssetCardsModel> models)
        {
            return models == null ? null : AutoMapper.Mapper.Map<IList<FixedAssetCardsModel>, IList<FixedAssetCardsEntity>>(models);
        }

        #endregion

        #region FixedAsset Report S24H

        internal static FixedAssetS24HModel FromDataTransferObject(FixedAssetS24HEntity entity)
        {
            return entity == null ? null : AutoMapper.Mapper.Map<FixedAssetS24HEntity, FixedAssetS24HModel>(entity);
        }

        internal static FixedAssetS24HEntity ToDataTransferObject(FixedAssetS24HModel model)
        {
            return model == null ? null : AutoMapper.Mapper.Map<FixedAssetS24HModel, FixedAssetS24HEntity>(model);
        }

        internal static IList<FixedAssetS24HModel> FromDataTransferObjects(IList<FixedAssetS24HEntity> entities)
        {
            return entities == null ? null : AutoMapper.Mapper.Map<IList<FixedAssetS24HEntity>, IList<FixedAssetS24HModel>>(entities);
        }

        internal static IList<FixedAssetS24HEntity> ToDataTransferObjects(IList<FixedAssetS24HModel> models)
        {
            return models == null ? null : AutoMapper.Mapper.Map<IList<FixedAssetS24HModel>, IList<FixedAssetS24HEntity>>(models);
        }

        #endregion

        #endregion

        #region ReportDataTemplate

        internal static ReportDataTemplateModel FromDataTransferObject(ReportDataTemplateEntity entity)
        {
            return entity == null ? null : AutoMapper.Mapper.Map<ReportDataTemplateEntity, ReportDataTemplateModel>(entity);
        }

        internal static ReportDataTemplateEntity ToDataTransferObject(ReportDataTemplateModel model)
        {
            return model == null ? null : AutoMapper.Mapper.Map<ReportDataTemplateModel, ReportDataTemplateEntity>(model);
        }

        internal static IList<ReportDataTemplateModel> FromDataTransferObjects(IList<ReportDataTemplateEntity> entities)
        {
            return entities == null ? null : AutoMapper.Mapper.Map<IList<ReportDataTemplateEntity>, IList<ReportDataTemplateModel>>(entities);
        }

        internal static IList<ReportDataTemplateEntity> ToDataTransferObjects(IList<ReportDataTemplateModel> models)
        {
            return models == null ? null : AutoMapper.Mapper.Map<IList<ReportDataTemplateModel>, IList<ReportDataTemplateEntity>>(models);
        }

        #endregion

        #region LedgerAccounting

        #region ReportS104HModel
        internal static BusinessObjects.Report.LedgerAccounting.ReportS104HModel FromDataTransferObject(BusinessEntities.Report.LedgerAccounting.ReportS104HEntity entity)
        {
            return entity == null ? null : AutoMapper.Mapper.Map<BusinessEntities.Report.LedgerAccounting.ReportS104HEntity, BusinessObjects.Report.LedgerAccounting.ReportS104HModel>(entity);
        }

        internal static BusinessEntities.Report.LedgerAccounting.ReportS104HEntity ToDataTransferObject(BusinessObjects.Report.LedgerAccounting.ReportS104HModel model)
        {
            return model == null ? null : AutoMapper.Mapper.Map<BusinessObjects.Report.LedgerAccounting.ReportS104HModel, BusinessEntities.Report.LedgerAccounting.ReportS104HEntity>(model);
        }

        internal static IList<BusinessObjects.Report.LedgerAccounting.ReportS104HModel> FromDataTransferObjects(IList<BusinessEntities.Report.LedgerAccounting.ReportS104HEntity> entities)
        {
            return entities == null ? null : AutoMapper.Mapper.Map<IList<BusinessEntities.Report.LedgerAccounting.ReportS104HEntity>, IList<BusinessObjects.Report.LedgerAccounting.ReportS104HModel>>(entities);
        }

        internal static IList<BusinessEntities.Report.LedgerAccounting.ReportS104HEntity> ToDataTransferObjects(IList<BusinessObjects.Report.LedgerAccounting.ReportS104HModel> models)
        {
            return models == null ? null : AutoMapper.Mapper.Map<IList<BusinessObjects.Report.LedgerAccounting.ReportS104HModel>, IList<BusinessEntities.Report.LedgerAccounting.ReportS104HEntity>>(models);
        }
        #endregion

        #endregion
    }
}
