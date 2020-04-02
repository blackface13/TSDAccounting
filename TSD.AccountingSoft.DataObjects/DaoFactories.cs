/***********************************************************************
 * <copyright file="DaoFactories.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 07 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

namespace TSD.AccountingSoft.DataAccess
{
    /// <summary>
    ///  class DaoFactories
    /// </summary>
    public class DaoFactories
    {
        /// <summary>
        /// Gets the factory.
        /// </summary>
        /// <param name="dataProvider">The data provider.</param>
        /// <returns></returns>
        public static IDaoFactory GetFactory(string dataProvider)
        {
            switch (dataProvider)
            {
                case "ADO.NET.SqlServer": return new SqlServer.SqlServerDaoFactory();
                default: return new SqlServer.SqlServerDaoFactory();
            }
        }
    }
}