using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Sunc.Framework.Repository.Utility.SuncLog4net;
using Sunc.Framework.Repository.Utility.SuncLog4net.Model;

namespace Sunc.Framework.Repository.Entity
{
    [Serializable]
    public class EntityBase
    {
        public string ToJson()
        {
            string json = string.Empty;
            try
            {
                json = JsonConvert.SerializeObject(this);
            }
            catch (JsonException ex)
            {
                Log4Helper.WriteLog<EntityBase>(new Log4Extension { action_log = LogEnum.None, log_enum = LogEnum.Error, itemObject = ex.Message }, LogEnum.Error, ex);
            }
            catch (Exception ex)
            {
                Log4Helper.WriteLog<EntityBase>(new Log4Extension { action_log = LogEnum.None, log_enum = LogEnum.Error, itemObject = ex.Message }, LogEnum.Error, ex);
            }
            return json;


        }
    }
}
