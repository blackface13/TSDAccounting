using System;
using System.Collections.Generic;
using TSD.AccountingSoft.BusinessEntities.Salary;

namespace TSD.AccountingSoft.DataAccess.IEntitiesDao.Salary
{
    public interface ISalaryDao
    {
        List<SalaryEntity> GetSalaryPostedByRefDateAndEmployId(DateTime refDate, int employId);
        /// <summary>
        /// Gets the salary by reference date and employ identifier.
        /// </summary>
        /// <param name="refDate">The reference date.</param>
        /// <param name="employId">The employ identifier.</param>
        /// <returns>List{SalaryEntity}.</returns>
        List<SalaryEntity> GetSalaryByRefDateAndEmployId(DateTime refDate,int employId);

        /// <summary>
        /// Gets the salary.
        /// </summary>
        /// <returns></returns>
        List<SalaryEntity> GetSalaryByMoth();

        /// <summary>
        /// Gets the salary.
        /// </summary>
        /// <returns></returns>
        List<SalaryEntity> GetSalaryByRefNo(string refNo);

        List<SalaryEntity> GetSalaryByDayDate(string daydate);

        List<SalaryEntity> GetSalaryExistRefNoInDay(string daydate,string refNo);


        /// <summary>
        /// Gets the salary.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
    //    SalaryEntity GetSalary(long refId);

        /// <summary>
        /// Inserts the salary.
        /// </summary>
        /// <param name="salary">The salary.</param>
        /// <returns></returns>
        int CalSalary(SalaryEntity salary);

        /// <summary>
        /// Inserts the salary.
        /// </summary>
        /// <param name="salary">The salary.</param>
        /// <returns></returns>
    //    int CalAllSalary(SalaryEntity salary);

        /// <summary>
        /// Inserts the salary.
        /// </summary>
        /// <param name="salary">The salary.</param>
        /// <returns></returns>
        int DeleteCalSalary(SalaryEntity salary);

        /// <summary>
        /// Inserts the salary.
        /// </summary>
        /// <param name="salary">The salary.</param>
        /// <returns></returns>
    //    int DeleteCalAllSalary(SalaryEntity salary);   

        /// <summary>
        /// Updates the salary.
        /// </summary>
        /// <param name="salary">The salary.</param>
        /// <returns></returns>
   //     int SavePosted(SalaryEntity salary);

        /// <summary>
        /// Updates the salary.
        /// </summary>
        /// <param name="salary">The salary.</param>
        /// <returns></returns>
     //   int SavePostedAll(SalaryEntity salary);  
    }
}
