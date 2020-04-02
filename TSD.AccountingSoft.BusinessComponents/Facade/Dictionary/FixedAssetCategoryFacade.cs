/***********************************************************************
 * <copyright file="FixedAssetCategoryFacade.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Thursday, February 27, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/
using System;
using System.Linq;
using System.Windows.Forms;
using TSD.AccountingSoft.BusinessComponents.Messages.Dictionary;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary;


namespace TSD.AccountingSoft.BusinessComponents.Facade.Dictionary
{
    public class FixedAssetCategoryFacade
    {
        /// <summary>
        /// The fixed asset category DAO
        /// </summary>
        private static readonly IFixedAssetCategoryDao FixedAssetCategoryDao = DataAccess.DataAccess.FixedAssetCategoryDao;

        /// <summary>
        /// Gets the fixed assets.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public FixedAssetCategoryResponse GetFixedAssetCategories(FixedAssetCategoryRequest request)
        {
            var response = new FixedAssetCategoryResponse();

            if (request.LoadOptions.Contains("FixedAssetCategorys"))
            {
                if (request.LoadOptions.Contains("IsActive"))
                {
                    response.FixedAssetCategories = request.LoadOptions.Contains("ForComboTree") ? FixedAssetCategoryDao.GetFixedAssetCategoriesForComboTree(request.FixedAssetCategoryId) : FixedAssetCategoryDao.GetFixedAssetCategoriesActive();
                }
                else if (request.LoadOptions.Contains("ForComboCheck"))
                {
                    response.FixedAssetCategories = FixedAssetCategoryDao.GetFixedAssetCategoriesComboCheck();
                }
                else response.FixedAssetCategories = FixedAssetCategoryDao.GetFixedAssetCategories();
            }
            if (request.LoadOptions.Contains("FixedAssetCategory")) response.FixedAssetCategory = FixedAssetCategoryDao.GetFixedAssetCategory(request.FixedAssetCategoryId);

            return response;
        }

        /// <summary>
        /// Sets the fixed assets.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public FixedAssetCategoryResponse SetFixedAssetCategories(FixedAssetCategoryRequest request)
        {
            var response = new FixedAssetCategoryResponse();

            var fixedAssetCategoryEntity = request.FixedAssetCategory;
            if (request.Action != PersistType.Delete)
            {
                if (!fixedAssetCategoryEntity.Validate())
                {
                    foreach (string error in fixedAssetCategoryEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
            }

            try
            {

                switch (request.Action)
                {
                    case PersistType.Insert:
                        var fixedAssetCategoryInsert = FixedAssetCategoryDao.GetFixedAssetCategoriesForComboTree(fixedAssetCategoryEntity.FixedAssetCategoryCode);
                        if (fixedAssetCategoryInsert != null)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            response.Message = @"Mã nhóm TSCĐ " + fixedAssetCategoryEntity.FixedAssetCategoryCode + @" đã tồn tại !";
                            return response;
                        }
                        fixedAssetCategoryEntity.FixedAssetCategoryId = FixedAssetCategoryDao.InsertFixedAssetCategory(fixedAssetCategoryEntity);

                        response.Message = null;
                        break;
                    case PersistType.Update:
                        var fixedAssetCategoryUpdate = FixedAssetCategoryDao.GetFixedAssetCategoriesForComboTree(fixedAssetCategoryEntity.FixedAssetCategoryCode);
                        if (fixedAssetCategoryUpdate != null)
                        {
                            if (fixedAssetCategoryUpdate.FixedAssetCategoryId != fixedAssetCategoryEntity.FixedAssetCategoryId)
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                response.Message = @"Mã nhóm TSCĐ " + fixedAssetCategoryEntity.FixedAssetCategoryCode + @" đã tồn tại !";
                                return response;
                            }
                        }
                        response.Message = FixedAssetCategoryDao.UpdateFixedAssetCategory(fixedAssetCategoryEntity);
                        break;
                    default:
                        {
                            var accountEntityForDelete = FixedAssetCategoryDao.GetFixedAssetCategory(request.FixedAssetCategoryId);
                            response.Message = FixedAssetCategoryDao.DeleteFixedAssetCategory(accountEntityForDelete);
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }

            response.FixedAssetCategoryId = fixedAssetCategoryEntity != null ? fixedAssetCategoryEntity.FixedAssetCategoryId : 0;
            response.Acknowledge = response.Message != null ? AcknowledgeType.Failure : AcknowledgeType.Success;
            return response;
        }
    }
}
