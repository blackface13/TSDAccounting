/***********************************************************************
 * <copyright file="OleDbHelper.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Tuesday, May 27, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Data;
using System.Data.OleDb;

namespace TSD.AccountingSoft.WindowsForm.CommonClass
{
    /// <summary>
    /// OLEDB Helper
    /// </summary>
    public class OleDbHelper
    {
        /// <summary>
        /// Gets or sets the OLE database connection.
        /// </summary>
        /// <value>
        /// The OLE database connection.
        /// </value>
        public static OleDbConnection OleDbConn { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="OleDbHelper"/> class.
        /// </summary>
        /// <param name="dbcontainfile">The dbcontainfile.</param>
        public OleDbHelper(string dbcontainfile)
        {
            OleDbConn = new OleDbConnection("Provider=VFPOLEDB.1;" + "Data Source=" + dbcontainfile + ";");
        }

        /// <summary>
        /// Gets all column data table DBF.
        /// </summary>
        /// <param name="dataTableName">Name of the data table.</param>
        /// <returns></returns>
        public DataTable GetAllColumnDataTableDBF(string dataTableName)
        {
            if (OleDbConn != null)
            {
                OleDbConn.Open();
                string strQuery = "SELECT * FROM [" + dataTableName + "]";
                var adapter = new OleDbDataAdapter(strQuery, OleDbConn);
                var ds = new DataSet();
                adapter.Fill(ds);
                return ds.Tables[0];
            }
            return null;
        }

        /// <summary>
        /// Gets the data table DBF.
        /// </summary>
        /// <param name="queryString">The query string.</param>
        /// <returns></returns>
        public DataTable GetDataTableDBF(string queryString)
        {
            if (OleDbConn != null)
            {
                OleDbConn.Open();
                var adapter = new OleDbDataAdapter(queryString, OleDbConn);
                var ds = new DataSet();
                adapter.Fill(ds);
                return ds.Tables[0];
            }
            return null;
        }
    }
}
