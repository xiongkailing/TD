using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamDay.Components;
using TeamDay.DAL;
using System.Security.Cryptography;
using System.Configuration;
using System.Reflection;

namespace TeamDay.Testor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(AppDomain.CurrentDomain.FriendlyName);
            Console.WriteLine(Test.Liu);
            SymmetricAlgorithm mCSP = new TripleDESCryptoServiceProvider(); ;
            mCSP.GenerateIV();
            mCSP.GenerateKey();
            string iv = Convert.ToBase64String(mCSP.IV);
            Console.WriteLine(iv);
            string privateKey = Convert.ToBase64String(mCSP.Key);
            Console.WriteLine(privateKey);
            Configuration config = ConfigurationManager.OpenExeConfiguration(Assembly.GetEntryAssembly().Location);
            AppSettingsSection appSettings = (AppSettingsSection)config.GetSection("appSettings");
            appSettings.Settings.Clear();
            appSettings.Settings.Add("pk", privateKey);
            appSettings.Settings.Add("iv", iv);
            config.Save();
            ConfigurationManager.RefreshSection("appSettings");
            //Log.WriteLog(NLog.LogLevel.Trace, null, "hello world");
            //Log.WriteLog(NLog.LogLevel.Debug, null, "hello {0}", "xiaoxiong");
            //Dictionary<string,string> dict=new Dictionary<string,string>();
            //dict.Add("name","xiongkailing");
            //dict.Add("age","23");
            //Log.WriteLogExt(NLog.LogLevel.Error, new Exception("inner exception"), dict, "hello nlog");

            //using (var context = new TestDbContext())
            //{
            //    IRepository<KeyValue> repository = new EfRepository<KeyValue>(context);
            //    var entity = repository.GetByKey(2);
            //    entity.Value = "female";
            //    repository.Update(entity);
            //    repository.Dispose();
            //}
        }
    }
    enum Test
    {
        Xiong = 1,
        Li = 2,
        Liu = 4
    }
}
