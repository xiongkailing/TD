using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace TeamDay.WebSite.Infrastructure
{
    public class WebConfig
    {
        private static string privateKey = "";
        private static string sIV = "";
        public static string PrivateKey
        {
            get
            {
                if (string.IsNullOrEmpty(privateKey))
                {
                    privateKey = WebConfigurationManager.AppSettings.Get("_priavteKey");
                }
                return privateKey;
            }
        }

        public static string SIV
        {
            get
            {
                if (string.IsNullOrEmpty(sIV))
                {
                    sIV = WebConfigurationManager.AppSettings.Get("_iV");
                }
                return sIV;
            }
        }

    }
}