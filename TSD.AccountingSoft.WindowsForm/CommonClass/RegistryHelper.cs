/***********************************************************************
 * <copyright file="RegistryHelper.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 03 June 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Configuration;
using System.Reflection;
using System.Xml;
using TSD.Option;
using Microsoft.Win32;


namespace TSD.AccountingSoft.WindowsForm.CommonClass
{
    /// <summary>
    /// RegistryHelper
    /// </summary>
    public static class RegistryHelper
    {
        /// <summary>
        /// The sub key
        /// </summary>
        private const string SubKey = @"TSDSoft\AccountingSoft";
        private static readonly Crypto Crypto = new Crypto(Crypto.SymmProvEnum.Rijndael);

        /// <summary>
        /// Gets the value by registry key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public static string GetValueByRegistryKey(string key)
        {
            var winLogonKey = Registry.CurrentUser.OpenSubKey(SubKey);
            if (winLogonKey != null)
            {
                //xu ly rieng cho truong hop pwd
                if (!key.ToLower().Contains("password")) return winLogonKey.GetValue(key) == null ? null : (string)winLogonKey.GetValue(key);

                var password = winLogonKey.GetValue(key) == null ? null : (string)winLogonKey.GetValue(key);
                //if (!string.IsNullOrEmpty(password) && (password.Contains("buca") || password.Contains("abigtime"))) //pwd chua dc ma hoa
                //    SetValueForRegistry(key, password);

                try
                {
                    var a = Convert.FromBase64String(password);
                }
                catch
                {
                    SetValueForRegistry(key, password);
                }

                return winLogonKey.GetValue(key) == null ? null : (string)winLogonKey.GetValue(key);
            }
            return null;
        }

        /// <summary>
        /// Sets the value for registry.
        /// </summary>
        /// <param name="keyValue">The key value.</param>
        /// <param name="value">The value.</param>
        public static void SetValueForRegistry(string keyValue, string value)
        {
            var winLogonKey = Registry.CurrentUser.OpenSubKey(SubKey, true);
            if (winLogonKey == null) return;
            if (keyValue.ToLower().Contains("password"))
            {
                var passwordEncrypted = Crypto.Encrypting(value, "@bgt1me");
                winLogonKey.SetValue(keyValue, passwordEncrypted, RegistryValueKind.String);
            }
            else
            {
                winLogonKey.SetValue(keyValue, value, RegistryValueKind.String);
            }
        }

        /// <summary>
        /// Saves the configuration file.
        /// </summary>
        public static void SaveConfigFile()
        {
            var str = Crypto.Encrypting("buCa@12345678", "@bgt1me");
            var dataProvider = ConfigurationManager.AppSettings.Get("ConnectionStringName");
            var appConfig = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
            //xu ly password
            var password = GetValueByRegistryKey("Password");
            if (!string.IsNullOrEmpty(password))
            {
                try
                {
                    password = Crypto.Decrypting(password, "@bgt1me");
                }
                catch
                {
                }
            }
            //add new connection string
            var connectionString = string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}",
                              GetValueByRegistryKey("InstanceName"),
                              GetValueByRegistryKey("DatabaseName"),
                              GetValueByRegistryKey("UserName"),
                              password);
            appConfig.ConnectionStrings.ConnectionStrings.Add(new ConnectionStringSettings(dataProvider, connectionString));
            appConfig.Save(ConfigurationSaveMode.Full);
            ConfigurationManager.RefreshSection("connectionStrings");
        }

        /// <summary>
        /// Removes the connection string.
        /// </summary>
        public static void RemoveConnectionString()
        {
            var dataProvider = ConfigurationManager.AppSettings.Get("ConnectionStringName");
            var appConfig = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
            //remove old connection string
            appConfig.ConnectionStrings.ConnectionStrings.Remove(dataProvider);
            appConfig.Save(ConfigurationSaveMode.Full);
            ConfigurationManager.RefreshSection("connectionStrings");
        }

        /// <summary>
        /// Saves the configuration file XML.
        /// </summary>
        public static void SaveConfigFileXml()
        {
            var appConfig = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(appConfig.FilePath);
            if (xmlDocument.DocumentElement != null)
                foreach (XmlElement xmlElement in xmlDocument.DocumentElement)
                {
                    if (xmlElement.Name == "connectionStrings")
                        if (xmlElement.FirstChild.Attributes != null)
                            xmlElement.FirstChild.Attributes[1].Value = string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}",
                                GetValueByRegistryKey("InstanceName"),
                                GetValueByRegistryKey("DatabaseName"),
                                GetValueByRegistryKey("UserName"),
                                GetValueByRegistryKey("Password"));
                }
            xmlDocument.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
        }
    }
}