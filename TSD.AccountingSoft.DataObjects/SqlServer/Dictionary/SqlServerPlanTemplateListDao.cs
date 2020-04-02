/***********************************************************************
 * <copyright file="SqlServerFixedAssetDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Thursday, February 28, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  07/03/2014       Author    Tudt           Description: Coding standard
 * 
 * ************************************************************************/

using TSD.AccountingSoft.BusinessEntities.Business.Estimate;
using TSD.AccountingSoft.BusinessEntities.Dictionary;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary;
using TSD.AccountingSoft.DataHelpers;
using System;
using System.Collections.Generic;
using System.Data;


namespace TSD.AccountingSoft.DataAccess.SqlServer.Dictionary
{
    /// <summary>
    /// Class SqlServerPlanTemplateListDao.
    /// </summary>
    public class SqlServerPlanTemplateListDao : IPlanTemplateListDao
    {
        /// <summary>
        /// Gets the PlanTemplateList.
        /// </summary>
        /// <param name="planTemplateListId">The PlanTemplateList identifier.</param>
        /// <returns>PlanTemplateListEntity.</returns>
        public PlanTemplateListEntity GetPlanTemplateList(int planTemplateListId)
        {
            const string sql = @"uspGet_PlanTemplateList_ByID";
            object[] parms = { "@PlanTemplateListID", planTemplateListId };
            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the PlanTemplateLists.
        /// </summary>
        /// <returns>List{PlanTemplateListEntity}.</returns>
        public List<PlanTemplateListEntity> GetPlanTemplateLists()
        {
            const string procedures = @"uspGet_All_PlanTemplateList";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Gets the PlanTemplateLists.
        /// </summary>
        /// <param name="isReceipt">The is receipt.</param>
        /// <returns>List{PlanTemplateListEntity}.</returns>
        public List<PlanTemplateListEntity> GetPlanTemplateLists(int isReceipt)
        {
            const string procedures = @"uspGet_PlanTemplateList_By_IsReceipt";
            object[] parms = { "@IsReceipt", isReceipt };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the plan template lists by code.
        /// </summary>
        /// <param name="planTemplateCode">The plan template code.</param>
        /// <returns>List{PlanTemplateListEntity}.</returns>
        public List<PlanTemplateListEntity> GetPlanTemplateListsByCode(string planTemplateCode)
        {
            const string procedures = @"uspGet_PlanTemplateList_ByCode";
            object[] parms = { "@PlanTemplateListCode", planTemplateCode };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Inserts the PlanTemplateList.
        /// </summary>
        /// <param name="planTemplateList">The PlanTemplateList.</param>
        /// <returns>System.Int32.</returns>
        public int InsertPlanTemplateList(PlanTemplateListEntity planTemplateList)
        {
            const string sql = "uspInsert_PlanTemplateList";
            return Db.Insert(sql, true, Take(planTemplateList));
        }

        /// <summary>
        /// Updates the PlanTemplateList.
        /// </summary>
        /// <param name="planTemplateList">The PlanTemplateList.</param>
        /// <returns>System.String.</returns>
        public string UpdatePlanTemplateList(PlanTemplateListEntity planTemplateList)
        {
            const string sql = "uspUpdate_PlanTemplateList";
            return Db.Update(sql, true, Take(planTemplateList));
        }

        /// <summary>
        /// Deletes the PlanTemplateList.
        /// </summary>
        /// <param name="planTemplateList">The PlanTemplateList.</param>
        /// <returns>System.String.</returns>
        public string DeletePlanTemplateList(PlanTemplateListEntity planTemplateList)
        {
            const string sql = @"uspDelete_PlanTemplateList";
            object[] parms = { "@PlanTemplateListID", planTemplateList.PlanTemplateListId };
            return Db.Delete(sql, true, parms);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, PlanTemplateListEntity> Make = reader =>
            new PlanTemplateListEntity
            {
                PlanTemplateListId = reader["PlanTemplateListID"].AsInt(),
                PlanTemplateListCode = reader["PlanTemplateListCode"].AsString(),
                PlanTemplateListName = reader["PlanTemplateListName"].AsString(),
                PlanType = reader["PlanType"].AsShort(),
                PlanYear = reader["PlanYear"].AsShort(),
                ParentId = reader["ParentID"].AsIntForNull()
            };

        /// <summary>
        /// Takes the specified PlanTemplateList.
        /// </summary>
        /// <param name="planTemplateList">The PlanTemplateList.</param>
        /// <returns>System.Object[][].</returns>
        private static object[] Take(PlanTemplateListEntity planTemplateList)
        {
            return new object[]  
            {
                "@PlanTemplateListID", planTemplateList.PlanTemplateListId,
                "@PlanTemplateListCode", planTemplateList.PlanTemplateListCode,
                "@PlanTemplateListName", planTemplateList.PlanTemplateListName,
                "@PlanType", planTemplateList.PlanType,
                "@PlanYear", planTemplateList.PlanYear,
                "@ParentID",planTemplateList.ParentId
            };
        }
    }

}
