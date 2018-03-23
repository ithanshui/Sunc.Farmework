
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using Newtonsoft.Json;
using Sunc.Framework.Repository.Utility.SuncLog4net.Model;

namespace Sunc.Framework.Repository.Utility.SuncLog4net
{
    public abstract class Log4Helper
    {
        Log4Helper() { }

        public static void WriteLog<T>(object mess, LogEnum log_enum, Exception ex = null) where T : class
        {
            WriteSwitch(LogManager.GetLogger(typeof(T)), log_enum, mess, ex);
        }
        public static void WriteLogOther(string name, object mess, LogEnum log_enum, Exception ex = null)
        {
            WriteSwitch(LogManager.GetLogger(name), log_enum, mess, ex);
        }
        protected static void WriteSwitch(ILog log, LogEnum log_enum, object mess, Exception ex)
        {
            string jsonStr = JsonConvert.SerializeObject(mess);
            switch (log_enum)
            {
                case LogEnum.Debug:
                    log.Debug(jsonStr, ex);
                    break;
                case LogEnum.Info:
                    log.Info(jsonStr, ex);
                    break;
                case LogEnum.Error:
                    log.Error(jsonStr, ex);
                    break;
                case LogEnum.Warn:
                    log.Warn(jsonStr, ex);
                    break;
                case LogEnum.Fatal:
                    log.Fatal(jsonStr, ex);
                    break;
                default:
                    log.Debug(jsonStr, ex);
                    break;
            }
        }
    }
}
