using TSD.AccountingSoft.BusinessEntities.Dictionary;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary;
using TSD.AccountingSoft.DataHelpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.DataAccess.SqlServer.Dictionary
{
    public class SqlServerAutoBusinessParallelDao : IAutoBusinessParallelDao
    {
        public AutoBusinessParallelEntity GetAutoBusinessParallel(int autoBusinessParallelId)
        {
            const string sql = @"uspGet_AutoBusinessParallel_ByID";

            object[] parms = { "@AutoBusinessParallelID", autoBusinessParallelId };
            return Db.Read(sql, true, Make, parms);
        }

        public AutoBusinessParallelEntity GetAutoBusinessParallelsByAutoBussinessInformation(string debitAccount, string creditAccount, int budgetSourceId, int budgetItemId, int budgetSubItemId, int voucherTypeId)
        {
            const string sql = @"uspGet_AutoBusinessParallel_ByAutoBussinessInformation";

            object[] parms =
            {
                "@DebitAccount", debitAccount,
                "@CreditAccount", creditAccount,
                "@BudgetSourceID", budgetSourceId,
                "@BudgetItemID", budgetItemId,
                "@BudgetSubItemID", budgetSubItemId,
                "@VoucherTypeID", voucherTypeId
            };
            return Db.Read(sql, true, Make, parms);
        }

        public List<AutoBusinessParallelEntity> GetAutoBusinessParallelsByAutoBussinessInformations(string debitAccount, string creditAccount, int budgetSourceId, int budgetItemId, int budgetSubItemId, int voucherTypeId)
        {
            const string sql = @"uspGet_AutoBusinessParallel_ByAutoBussinessInformation";

            object[] parms =
            {
                "@DebitAccount", debitAccount,
                "@CreditAccount", creditAccount,
                "@BudgetSourceID", budgetSourceId,
                "@BudgetItemID", budgetItemId,
                "@BudgetSubItemID", budgetSubItemId,
                "@VoucherTypeID", voucherTypeId
            };
            return Db.ReadList(sql, true, Make, parms);
        }

        public List<AutoBusinessParallelEntity> GetAutoBusinessParallels()
        {
            const string procedures = @"uspGet_All_AutoBusinessParallel";
            return Db.ReadList(procedures, true, Make);
        }

        public List<AutoBusinessParallelEntity> GetAutoBusinessParallels(string autoBusinessParallelCode)
        {
            const string sql = @"uspGet_AutoBusinessParallel_AutoBusinessParallelCode";

            object[] parms = { "@AutoBusinessParallelCode", autoBusinessParallelCode };
            return Db.ReadList(sql, true, Make, parms);
        }

        public List<AutoBusinessParallelEntity> GetAutoBusinessParallelsByActive(bool isActive)
        {
            const string sql = @"uspGet_AutoBusinessParallel_IsActive";

            object[] parms = { "@IsActive", isActive };
            return Db.ReadList(sql, true, Make, parms);
        }

        public int InsertAutoBusinessParallel(AutoBusinessParallelEntity autoBusinessParallel)
        {
            const string sql = @"uspInsert_AutoBusinessParallel";
            return Db.Insert(sql, true, Take(autoBusinessParallel));
        }

        public string UpdateAutoBusinessParallel(AutoBusinessParallelEntity autoBusinessParallel)
        {
            const string sql = @"uspUpdate_AutoBusinessParallel";
            return Db.Update(sql, true, Take(autoBusinessParallel));
        }

        public string DeleteAutoBusinessParallel(AutoBusinessParallelEntity autoBusinessParallel)
        {
            const string sql = @"uspDelete_AutoBusinessParallel";

            object[] parms = { "@AutoBusinessParallelID", autoBusinessParallel.AutoBusinessParallelId };
            return Db.Delete(sql, true, parms);
        }

        public string DeleteAutoBusinessParallelConvert()
        {
            const string sql = @"usp_ConvertAutoBusinessParallel";

            object[] parms = { };
            return Db.Delete(sql, true, parms);
        }

        private static object[] Take(AutoBusinessParallelEntity autoBusinessParallelEntity)
        {
            return new object[]
            {
                "@AutoBusinessParallelID",autoBusinessParallelEntity.AutoBusinessParallelId,
                "@AutoBusinessCode",autoBusinessParallelEntity.AutoBusinessCode,
                "@AutoBusinessName",autoBusinessParallelEntity.AutoBusinessName,
                "@Description",autoBusinessParallelEntity.Description,
                "@IsActive",autoBusinessParallelEntity.IsActive,
                "@DebitAccount",autoBusinessParallelEntity.DebitAccount,
                "@CreditAccount",autoBusinessParallelEntity.CreditAccount,
                "@BudgetSourceID",autoBusinessParallelEntity.BudgetSourceId,
                "@BudgetItemID",autoBusinessParallelEntity.BudgetItemId,
                "@BudgetSubItemID",autoBusinessParallelEntity.BudgetSubItemId,
                "@VoucherTypeID",autoBusinessParallelEntity.VoucherTypeId,
                "@DebitAccountParallel",autoBusinessParallelEntity.DebitAccountParallel,
                "@CreditAccountParallel",autoBusinessParallelEntity.CreditAccountParallel,
                "@BudgetSourceIDParallel",autoBusinessParallelEntity.BudgetSourceIdParallel,
                "@BudgetItemIDParallel",autoBusinessParallelEntity.BudgetItemIdParallel,
                "@BudgetSubItemIDParallel",autoBusinessParallelEntity.BudgetSubItemIdParallel,
                "@VoucherTypeIDParallel",autoBusinessParallelEntity.VoucherTypeIdParallel,
                "@SortOrder",autoBusinessParallelEntity.SortOrder,
                "@IsNegative",autoBusinessParallelEntity.IsNegative
            };
        }

        private static readonly Func<IDataReader, AutoBusinessParallelEntity> Make = reader => new AutoBusinessParallelEntity
        {
            AutoBusinessParallelId = reader["AutoBusinessParallelID"].AsInt(),
            AutoBusinessCode = reader["AutoBusinessCode"].AsString(),
            AutoBusinessName = reader["AutoBusinessName"].AsString(),
            Description = reader["Description"].AsString(),
            IsActive = reader["IsActive"].AsBool(),
            DebitAccount = reader["DebitAccount"].AsString(),
            CreditAccount = reader["CreditAccount"].AsString(),
            BudgetSourceId = reader["BudgetSourceID"].AsInt(),
            BudgetItemId = reader["BudgetItemID"].AsInt(),
            BudgetSubItemId = reader["BudgetSubItemID"].AsInt(),
            VoucherTypeId = reader["VoucherTypeID"].AsInt(),
            DebitAccountParallel = reader["DebitAccountParallel"].AsString(),
            CreditAccountParallel = reader["CreditAccountParallel"].AsString(),
            BudgetSourceIdParallel = reader["BudgetSourceIDParallel"].AsInt(),
            BudgetItemIdParallel = reader["BudgetItemIDParallel"].AsInt(),
            BudgetSubItemIdParallel = reader["BudgetSubItemIDParallel"].AsInt(),
            VoucherTypeIdParallel = reader["VoucherTypeIDParallel"].AsInt(),
            SortOrder = reader["SortOrder"].AsInt(),
            IsNegative = reader["IsNegative"].AsBool()
        };
    }
}
