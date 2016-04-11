using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Reflection;
using System.Security.Cryptography;

namespace TeamDay.WebSite.Infrastructure
{
    public class SecruityConfiguration
    {
        public static void SetDESKeyAndIV()
        {
            Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
            AppSettingsSection appSetting = (AppSettingsSection)config.GetSection("appSettings");
            if (appSetting.Settings["_privateKey"] == null || appSetting.Settings["_iV"] == null ||
                string.IsNullOrEmpty(appSetting.Settings["_privateKey"].Value) || string.IsNullOrEmpty(appSetting.Settings["_iV"].Value))
            {
                SymmetricAlgorithm mCSP = new TripleDESCryptoServiceProvider(); ;
                mCSP.GenerateIV();
                mCSP.GenerateKey();
                string iv = Convert.ToBase64String(mCSP.IV);
                string privateKey = Convert.ToBase64String(mCSP.Key);
                appSetting.Settings.Add("_privateKey", privateKey);
                appSetting.Settings.Add("_iV", iv);
                config.Save();
            }
        }
    }
}