/***********************************************************************
 * <copyright file="AssemblyInfomation.cs" company="Linh Khang">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Author:   LinhMC
 * Email:    linhmc.vn@gmail.com
 * Website:
 * Create Date: Thursday, August 29, 2013
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Diagnostics;
using System.Reflection;

namespace TSD.AccountingSoft.Report.MainReport
{
    /// <summary>
    /// Assembly Infomation
    /// </summary>
    public static class AssemblyInfomation
    {
        /// <summary>
        /// Gets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public static string Title
        {
            get
            {
                string result = string.Empty;
                Assembly assembly = Assembly.GetExecutingAssembly();
                object[] customAttributes = assembly.GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if ((customAttributes.Length > 0))
                    result = ((AssemblyTitleAttribute)customAttributes[0]).Title;

                return result;
            }
        }
        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public static string Description
        {
            get
            {
                string result = string.Empty;
                Assembly assembly = Assembly.GetExecutingAssembly();

                object[] customAttributes = assembly.GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if ((customAttributes.Length > 0))
                    result = ((AssemblyDescriptionAttribute)customAttributes[0]).Description;

                return result;
            }
        }
        /// <summary>
        /// Gets the company.
        /// </summary>
        /// <value>
        /// The company.
        /// </value>
        public static string Company
        {
            get
            {
                string result = string.Empty;
                Assembly assembly = Assembly.GetExecutingAssembly();

                object[] customAttributes = assembly.GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if ((customAttributes.Length > 0))
                    result = ((AssemblyCompanyAttribute)customAttributes[0]).Company;

                return result;
            }
        }
        /// <summary>
        /// Gets the product.
        /// </summary>
        /// <value>
        /// The product.
        /// </value>
        public static string Product
        {
            get
            {
                string result = string.Empty;
                Assembly assembly = Assembly.GetExecutingAssembly();

                object[] customAttributes = assembly.GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if ((customAttributes.Length > 0))
                    result = ((AssemblyProductAttribute)customAttributes[0]).Product;
                return result;
            }
        }
        /// <summary>
        /// Gets the copyright.
        /// </summary>
        /// <value>
        /// The copyright.
        /// </value>
        public static string Copyright
        {
            get
            {
                string result = string.Empty;
                Assembly assembly = Assembly.GetExecutingAssembly();

                object[] customAttributes = assembly.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if ((customAttributes.Length > 0))
                    result = ((AssemblyCopyrightAttribute)customAttributes[0]).Copyright;
                return result;
            }
        }
        /// <summary>
        /// Gets the trademark.
        /// </summary>
        /// <value>
        /// The trademark.
        /// </value>
        public static string Trademark
        {
            get
            {
                string result = string.Empty;
                Assembly assembly = Assembly.GetExecutingAssembly();

                object[] customAttributes = assembly.GetCustomAttributes(typeof(AssemblyTrademarkAttribute), false);
                if ((customAttributes.Length > 0))
                    result = ((AssemblyTrademarkAttribute)customAttributes[0]).Trademark;
                return result;
            }
        }
        /// <summary>
        /// Gets the assembly version.
        /// </summary>
        /// <value>
        /// The assembly version.
        /// </value>
        public static string AssemblyVersion
        {
            get
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                return assembly.GetName().Version.ToString();
            }
        }
        /// <summary>
        /// Gets the file version.
        /// </summary>
        /// <value>
        /// The file version.
        /// </value>
        public static string FileVersion
        {
            get
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
                return fvi.FileVersion;
            }
        }
        /// <summary>
        /// Gets the unique identifier.
        /// </summary>
        /// <value>
        /// The unique identifier.
        /// </value>
        public static string Guid
        {
            get
            {
                string result = string.Empty;
                Assembly assembly = Assembly.GetExecutingAssembly();

                object[] customAttributes = assembly.GetCustomAttributes(typeof(System.Runtime.InteropServices.GuidAttribute), false);
                if ((customAttributes.Length > 0))
                    result = ((System.Runtime.InteropServices.GuidAttribute)customAttributes[0]).Value;
                return result;
            }
        }
        /// <summary>
        /// Gets the name of the file.
        /// </summary>
        /// <value>
        /// The name of the file.
        /// </value>
        public static string FileName
        {
            get
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
                return fvi.OriginalFilename;
            }
        }
        /// <summary>
        /// Gets the file path.
        /// </summary>
        /// <value>
        /// The file path.
        /// </value>
        public static string FilePath
        {
            get
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
                return fvi.FileName;
            }
        }
    }
}
