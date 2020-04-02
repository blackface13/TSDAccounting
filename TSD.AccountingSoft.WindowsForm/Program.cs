/***********************************************************************
 * <copyright file="Program.cs" company="BUCA JSC">
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

using System.Globalization;
using TSD.AccountingSoft.WindowsForm.CommonClass;
using System;
using TSD.AccountingSoft.WindowsForm.Resources;


namespace TSD.AccountingSoft.WindowsForm
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.UserSkins.BonusSkins.Register();
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            ResourceHelper.ResourceLanguage = "vi-VN";
            System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(ResourceHelper.ResourceLanguage);
            ResourceHelper.InitResource();
            RegistryHelper.RemoveConnectionString();
            try
            {
                if (!RegistryHelper.GetValueByRegistryKey("DatabaseName").Equals("master") && !string.IsNullOrEmpty(RegistryHelper.GetValueByRegistryKey("DatabasePath")))
                    RegistryHelper.SaveConfigFile();
            }
            catch(Exception ex)
            {
            }
            System.Windows.Forms.Application.Run(new MainRibbonForm());
        }
    }
}