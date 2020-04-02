/***********************************************************************
 * <copyright file="FrmXtraFixedAssetCategoryTreeDetail.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   THODD
 * Email:    thodd@buca.vn
 * Website:
 * Create Date: Wednesday, February 26, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Model.BusinessObjects.Report.FixedAsset;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.View.Report;


namespace TSD.AccountingSoft.Presenter.Report
{
    /// <summary>
    /// Class FixedAssetHousingReportPresenter.
    /// </summary>
    public class FixedAssetHousingReportPresenter : Presenter<IFixedAssetHousingReportView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FixedAssetHousingReportPresenter" /> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public FixedAssetHousingReportPresenter(IFixedAssetHousingReportView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays the specified budget chapter identifier.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        public void Display(bool isActive)
        {

            var fixedAssetHousingReport = Model.GetFixedAssetHousingReport(isActive);
            View.FixedAssetHousingReportId = fixedAssetHousingReport.FixedAssetHousingReportId;
            View.AreaOfBuilding = fixedAssetHousingReport.AreaOfBuilding;
            View.WorkingArea = fixedAssetHousingReport.WorkingArea;
            View.HousingArea = fixedAssetHousingReport.HousingArea;
            View.GuestHouseArea = fixedAssetHousingReport.GuestHouseArea;
            View.OccupiedArea = fixedAssetHousingReport.OccupiedArea;
            View.OtherArea = fixedAssetHousingReport.OtherArea;
            View.AccountingValue = fixedAssetHousingReport.AccountingValue;
            View.Attachments = fixedAssetHousingReport.Attachments;
        }

        /// <summary>
        /// Deletes the specified budget chapter identifier.
        /// </summary>
        /// <param name="fixedAssetHousingReportId">The budget chapter identifier.</param>
        /// <returns>System.Int32.</returns>
        public int Delete(int fixedAssetHousingReportId)
        {
            return Model.DeleteFixedAssetHousingReport(fixedAssetHousingReportId);
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int Save()
        {
            var fixedAssetHousingReport = new FixedAssetHousingReportModel
            {
                FixedAssetHousingReportId = View.FixedAssetHousingReportId,
                AreaOfBuilding = View.AreaOfBuilding,
                WorkingArea = View.WorkingArea,
                HousingArea = View.HousingArea,
                GuestHouseArea = View.GuestHouseArea,
                OccupiedArea = View.OccupiedArea,
                OtherArea = View.OtherArea,
                AccountingValue = View.AccountingValue,
                Attachments = View.Attachments
            };
            if (View.FixedAssetHousingReportId == 0)
                return Model.AddFixedAssetHousingReport(fixedAssetHousingReport);
            return Model.UpdateFixedAssetHousingReport(fixedAssetHousingReport);
        }
    }
}
