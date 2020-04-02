/***********************************************************************
 * <copyright file="ReportListResponse.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Wednesday, March 05, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.Report;
using TSD.AccountingSoft.BusinessEntities.Report.Estimate;
using TSD.AccountingSoft.BusinessEntities.Report.Finacial;
using TSD.AccountingSoft.BusinessEntities.Report.FixedAsset;
using TSD.AccountingSoft.BusinessEntities.Report.Voucher;


namespace TSD.AccountingSoft.BusinessComponents.Messages.Report
{
    /// <summary>
    /// class ReportListResponse
    /// </summary>
    public class ReportListResponse : ResponseBase
    {
        /// <summary>
        /// The report lists
        /// </summary>
        public List<ReportListEntity> ReportLists;

        /// <summary>
        /// The report list
        /// </summary>
        public ReportListEntity ReportList;

        /// <summary>
        /// The C22 h
        /// </summary>
        public IList<AccountingVoucherEntity> AccountingVoucher;

        /// <summary>
        /// The C22 h
        /// </summary>
        public IList<C22HEntity> C22H;

        /// <summary>
        /// The C22 h
        /// </summary>
        public IList<C11HEntity> C11H;

        /// <summary>
        /// The a02 LDTL
        /// </summary>
        public List<A02LDTLEntity> A02LDTL;

        /// <summary>
        /// The S03 ah
        /// </summary>
        public List<S03AHEntity> S03AH;

        /// <summary>
        /// The B14 q
        /// </summary>
        public List<B14QEntity> B14Q;

        /// <summary>
        /// The B14 q
        /// </summary>
        public List<B01HEntity> B01H;

        public List<ReportB01BCTCEntity> B01BCTC;

        public List<ReportB03bBCTCEntity> B03bBCTC;

        /// <summary>
        /// The S03 ah
        /// </summary>
        public List<S33HEntity> S33H;

        public List<S05HEntity> S05H;
        public List<AdvancePaymentEntity> AdvancePayment;

        #region Estimate Report //phần này chỉ của báo cáo dự toán

        /// <summary>
        /// The general receipt estimates
        /// </summary>
        public List<GeneralReceiptEstimateEntity> GeneralReceiptEstimates;

        /// <summary>
        /// The general payment estimates
        /// </summary>
        public List<GeneralPaymentEstimateEntity> GeneralPaymentEstimates;

        /// <summary>
        /// The general estimates
        /// </summary>
        public List<GeneralEstimateEntity> GeneralEstimates;

        /// <summary>
        /// The general payment detail estimates
        /// </summary>
        public List<GeneralPaymentDetailEstimateEntity> GeneralPaymentDetailEstimates;

        /// <summary>
        /// The estimate detail statement
        /// </summary>
        public EstimateDetailStatementEntity EstimateDetailStatement;

        /// <summary>
        /// The fund stuations
        /// </summary>
        public List<FundStuationEntity> FundStuations;

        #endregion 

        #region Financial Report //phần này chỉ của báo cáo tài chính

        /// <summary>
        /// The B03 bn gs
        /// </summary>
        public List<B03BNGEntity> B03BNGs;

        /// <summary>
        /// The F03 bn gs
        /// </summary>
        public IList<F03BNGEntity> F03BNGs;

        /// <summary>
        /// The F331 bn gs
        /// </summary>
        public IList<F331BNGEntity> F331BNGs;

        /// <summary>
        /// The B09 bn gs
        /// </summary>
        public IList<B09BNGEntity> B09BNGs;

        public IList<B01BCQTEntity> FinacialB01BCQTs;

        #endregion

        /// <summary>
        /// The fixed asset B03 h
        /// </summary>
        public List<FixedAssetB03HEntity> FixedAssetB03H;

        /// <summary>
        /// The fixed asset B03 h
        /// </summary>
        public List<FixedAssetB01Entity> FixedAssetB01;

        /// <summary>
        /// The fixed asset c55a hd
        /// </summary>
        public List<FixedAssetC55aHDEntity> FixedAssetC55aHD;

        /// <summary>
        /// The fixed asset fa inventory
        /// </summary>
        public List<FixedAssetFAInventoryEntity> FixedAssetFAInventory;

        public List<FixedAssetFAInventoryHouseEntity> FixedAssetFAInventoryHouse;

        public List<FixedAssetFAInventoryCarEntity> FixedAssetFAInventoryCar;

        /// <summary>
        /// The fixed asset S31 h
        /// </summary>
        public List<FixedAssetS31HEntity> FixedAssetS31H;

        /// <summary>
        /// The fixed asset B02
        /// </summary>
        public List<FixedAssetB02Entity> FixedAssetB02;

        public List<FixedAssetB03H30KEntity> FixedAssetB03H30K;

        public List<FixedAsset30KPart2Entity> FixedAsset30KPart2;

        public IList<FixedAssetCardEntity> FixedAssetCards;

        /// <summary>
        /// The cash report list
        /// </summary>
        public List<CashReportEntity> CashReportList;

        /// <summary>
        /// The S03 bh list
        /// </summary>
        public List<S03BHEntity> S03BHList;

        /// <summary>
        /// The C30 bb list
        /// </summary>
        public List<C30BBEntity> C30BBList;

        /// <summary>
        /// The C30 b B501 list
        /// </summary>
        public IList<C30BB501Entity> C30BB501List;

        public IList<ReportF03BCTEntity> ReportF03BCT;

        public IList<ReportB01CIIEntity> ReportB01CII;

        public IList<ReportB01CII01Entity> ReportB01CII01;

        public IList<ReportB01CIEntity> ReportB01CI;

        public IList<ReportS104HEntity> ReportS104H;

        public IList<FixedAssetS26HEntity> FixedAssetS26H;

        public IList<FixedAssetS24HEntity> FixedAssetS24H;

        public IList<ReportActivityB02Entity> ReportActivityB02;

        public IList<FixedAssetCardsEntity> FixedAssetCard;

        public IList<ReportB04BCTCEntity> B04BCTC;

        public IList<BusinessEntities.Report.LedgerAccounting.ReportS104HEntity> LedgerAccountingS104H;
    }
}
