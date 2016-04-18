using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using TeamDay.Components;

namespace TeamDay.WebSite.Infrastructure
{
    public class WebConfig
    {
        private static string privateKey = "";
        private static string sIV = "";
        private static string redisCstr = "";
        public static string PrivateKey
        {
            get
            {
                if (string.IsNullOrEmpty(privateKey))
                {
                    privateKey = WebConfigurationManager.AppSettings.Get("_privateKey");
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

        public static string RedisConnectString
        {
            get
            {
                if (string.IsNullOrEmpty(redisCstr))
                {
                    redisCstr = WebConfigurationManager.AppSettings.Get("RedisConnectString");
                }
                if (string.IsNullOrEmpty(redisCstr))
                    throw new NoConfigFoundException("RedisConnectString", AppDomain.CurrentDomain.FriendlyName);
                return redisCstr;
            }
        }
    }
}