using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamDay.Components
{
    public class Log
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        public static void WriteLog(LogLevel level, Exception ex, string message)
        {
            LogEventInfo info = new LogEventInfo
            {
                Level = level,
                Exception = ex,
                Message = message,
                TimeStamp = DateTime.Now
            };
            logger.Log(info);
        }
        public static void WriteLog(LogLevel level, Exception ex, string messageFormat, params object[] args)
        {
            StringBuilder sb = new StringBuilder();
            string message = sb.AppendFormat(messageFormat, args).ToString();
            WriteLog(level, ex, message);
        }
        public static void WriteLogExt(LogLevel level, Exception ex, Dictionary<string, string> extension, string message)
        {
            LogEventInfo info = new LogEventInfo
            {
                Level = level,
                Exception = ex,
                Message = message,
                TimeStamp = DateTime.Now
            };
            foreach (var item in extension)
            {
                info.Properties[item.Key] = item.Value;
            }
            logger.Log(info);
        }
        public static void WriteLogExt(LogLevel level, Exception ex, Dictionary<string, string> extension, string messageFormat,params object[] args)
        {
            StringBuilder sb = new StringBuilder();
            string message = sb.AppendFormat(messageFormat, args).ToString();
            WriteLogExt(level, ex, extension, message);
        }
    }
}
