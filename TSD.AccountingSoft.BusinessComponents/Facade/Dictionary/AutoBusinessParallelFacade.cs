using TSD.AccountingSoft.BusinessComponents.Messages.Dictionary;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.Dictionary;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.BusinessComponents.Facade.Dictionary
{
    public class AutoBusinessParallelFacade
    {
        private static readonly IAutoBusinessParallelDao AutoBusinessParallelDao = DataAccess.DataAccess.AutoBusinessParallelDao;

        public List<AutoBusinessParallelEntity> GetAutoBusinessParallels()
        {
            return AutoBusinessParallelDao.GetAutoBusinessParallels();
        }

        public List<AutoBusinessParallelEntity> GetAutoBusinessParallelsByActive(bool isActive)
        {
            return AutoBusinessParallelDao.GetAutoBusinessParallelsByActive(isActive);
        }

        public AutoBusinessParallelEntity GetAutoBusinessParallel(int autoBusinessId)
        {
            return AutoBusinessParallelDao.GetAutoBusinessParallel(autoBusinessId);
        }

        public AutoBusinessParallelResponse InsertAutoBusinessParallel(AutoBusinessParallelEntity autoBusinessEntity)
        {
            var response = new AutoBusinessParallelResponse { Acknowledge = AcknowledgeType.Failure };
            try
            {
                if (!autoBusinessEntity.Validate())
                {
                    foreach (string error in autoBusinessEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    return response;
                }

                var lstAutoBusinessParallels = AutoBusinessParallelDao.GetAutoBusinessParallels(autoBusinessEntity.AutoBusinessCode);
                if(lstAutoBusinessParallels != null  && lstAutoBusinessParallels.Count > 0)
                {
                    response.Message = "Mã định khoản đồng thời '" + autoBusinessEntity.AutoBusinessCode + "' đã được sử dụng.";
                    return response;
                }

                response.AutoBusinessParallelId = AutoBusinessParallelDao.InsertAutoBusinessParallel(autoBusinessEntity);
                if (response.AutoBusinessParallelId == 0)
                {
                    return response;
                }
                response.Acknowledge = AcknowledgeType.Success;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }

        public AutoBusinessParallelResponse UpdateAutoBusinessParallel(AutoBusinessParallelEntity autoBusinessEntity)
        {
            var response = new AutoBusinessParallelResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!autoBusinessEntity.Validate())
                {
                    foreach (string error in autoBusinessEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }

                var lstAutoBusinessParallels = AutoBusinessParallelDao.GetAutoBusinessParallels(autoBusinessEntity.AutoBusinessCode);
                if (lstAutoBusinessParallels != null && lstAutoBusinessParallels.Where(w=>w.AutoBusinessParallelId != autoBusinessEntity.AutoBusinessParallelId).Count() > 0)
                {
                    response.Message = "Mã định khoản đồng thời '" + autoBusinessEntity.AutoBusinessCode + "' đã được sử dụng.";
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }

                response.Message = AutoBusinessParallelDao.UpdateAutoBusinessParallel(autoBusinessEntity);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.AutoBusinessParallelId = autoBusinessEntity.AutoBusinessParallelId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }

        public AutoBusinessParallelResponse DeleteAutoBusinessParallel(int autoBusinessParallelId)
        {
            var response = new AutoBusinessParallelResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                var autoBusinessParallelEntity = AutoBusinessParallelDao.GetAutoBusinessParallel(autoBusinessParallelId);
                response.Message = AutoBusinessParallelDao.DeleteAutoBusinessParallel(autoBusinessParallelEntity);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.AutoBusinessParallelId = autoBusinessParallelEntity.AutoBusinessParallelId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }

        }
    }
}
