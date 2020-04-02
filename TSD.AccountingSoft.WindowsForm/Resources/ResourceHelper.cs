/***********************************************************************
 * <copyright file="ResourceHelper.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 13 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Reflection;
using System.Resources;


namespace TSD.AccountingSoft.WindowsForm.Resources
{
    public static class ResourceHelper
    {
        /// <summary>
        /// Gets or sets the language resource.
        /// </summary>
        /// <value>
        /// The language resource.
        /// </value>
        public static string ResourceLanguage { get; set; }

        private const string ResourceNamespace = @"TSD.AccountingSoft.WindowsForm.Resources.";
        private static ResourceManager _resourceMain;

        /// <summary>
        /// Initializes the resource.
        /// </summary>
        public static void InitResource()
        {
            _resourceMain = new ResourceManager(GetResourcePath(), Assembly.GetExecutingAssembly());
        }

        /// <summary>
        /// Gets the resource path.
        /// </summary>
        /// <returns></returns>
        private static string GetResourcePath()
        {
            string path;
            switch (ResourceLanguage)
            {
                case "vi-Vn":
                    path = ResourceNamespace + ResourceLanguage;
                    break;
                case "en-Eg":
                    path = ResourceNamespace + ResourceLanguage;
                    break;
                default:
                    path = ResourceNamespace + ResourceLanguage;
                    break;
            }
            return path;
        }

        /// <summary>
        /// Gets the name of the resource value by.
        /// </summary>
        /// <param name="resourceName">Name of the resource.</param>
        /// <returns></returns>
        public static string GetResourceValueByName(string resourceName)
        {
            var resourceValue = _resourceMain.GetString(resourceName);
            return resourceValue;
        }
    }
}