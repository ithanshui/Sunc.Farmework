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
    public abstract class EntityBase
    {
        public EntityBase()
        {

        }
        private static JsonSerializerSettings _setting;

        /// <summary>
        /// 序列化设置
        /// </summary>
        public static JsonSerializerSettings Setting
        {
            set
            {
                if (value == null)
                {
                    _setting = new JsonSerializerSettings();
                    _setting.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                }
                else
                {
                    _setting = value;
                }
            }
            get
            {
                return _setting;
            }
        }

        
        /// <summary>
        /// 序列化
        /// </summary>
        /// <returns></returns>
        public static string ToJson(object model, JsonSerializerSettings setting = null)
        {
            if (model == null)
                return null;
            string json = string.Empty;
            try
            {
                json = JsonConvert.SerializeObject(model, setting ?? _setting);
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

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonStr"></param>
        /// <returns></returns>
        public static object ConvertToEntity<T>(string jsonStr, JsonSerializerSettings setting = null)
        {
            if (string.IsNullOrEmpty(jsonStr))
                return null;
            try
            {
                return JsonConvert.DeserializeObject<T>(jsonStr, setting ?? _setting);
            }
            catch (Exception err)
            {
                Log4Helper.WriteLog<EntityBase>(new Log4Extension { action_log = LogEnum.None, log_enum = LogEnum.Error, itemObject = err.Message }, LogEnum.Error, err);
            }
            return null;
        }


        /// <summary>
        /// 序列化
        /// </summary>
        /// <returns></returns>
        public virtual string ToJson()
        {
            string json = string.Empty;
            try
            {
                json = JsonConvert.SerializeObject(this, _setting);
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
