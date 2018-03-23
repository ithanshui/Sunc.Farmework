
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net.Config;

namespace Sunc.Framework.Repository.Utility.SuncLog4net
{
    public abstract class Log4Config
    {
        public static void LoadLog4netConfig(string path = "Sunc\\LogConfig\\log4net.config")
        {
            string filePath = AppDomain.CurrentDomain.BaseDirectory +path ;
            FileInfo fileInfo = new FileInfo(filePath);
            XmlConfigurator.ConfigureAndWatch(fileInfo);
        } 
    }
}
