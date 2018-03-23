using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunc.Framework.Repository.Utility.SuncLog4net.Model
{
    [Serializable]
    public class Log4Extension
    {
        public Log4Extension()
        {
            this.create_time = DateTime.Now;
            this.log_enum = LogEnum.Debug;
            this.action_log = LogEnum.None;
        }
        public LogEnum log_enum { set; get; }
        public DateTime create_time { set; get; }
        public LogEnum action_log { set; get; }
        public object itemObject { set; get; }
    }
}
