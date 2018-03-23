using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Newtonsoft.Json;
using Sunc.Framework.Repository.Data.DataOperation;
using Sunc.Framework.Repository.Data.DataOperation.WebAbs;
using Sunc.Framework.Repository.Entity.Result;
using Sunc.Framework.Repository.Utility;
using Sunc.Framework.Repository.Utility.SuncLog4net;
using Sunc.Framework.Repository.Web.Mvc.OverrideExtension;

namespace Sunc.Framework.Repository.Web.Mvc
{
    public class SuncBaseController : Controller
    {
        /// <summary>
        /// 返回数据处理
        /// </summary>
        protected static ResultClass _ResultClass;
        private static JsonSerializerSettings _JsonSerializerSettings;
        protected static ValidateCode _ValidateCode;
        private const int TIMEOUT = 3600;
        static SuncBaseController()
        {
            _ResultClass = new ResultClass();
            _JsonSerializerSettings = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
            _ValidateCode = new ValidateCode();
        }


        /// <summary>
        /// 统一返回值
        /// </summary>
        protected ResultStatus resultStatus = new ResultStatus(Entity.StatusBase.NOT_FIND, AbsBase.N_FOND);
        protected object Object_Entity;


        #region Json操作


        /// <summary>
        /// json序列化
        /// </summary>
        /// <param name="data">数据源</param>
        /// <returns></returns>
        protected virtual string ToStringJson(object data)
        {
            string json = string.Empty;
            try
            {

                json = JsonConvert.SerializeObject(data, _JsonSerializerSettings);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return json;
        }

        /// <summary>
        /// 反序列化json
        /// </summary>
        /// <typeparam name="T">class</typeparam>
        /// <param name="json">json字符串</param>
        /// <returns></returns>
        protected virtual T ToEntity<T>(string json) where T : class, new()
        {
            T t = null;
            if (string.IsNullOrEmpty(json))
            {
                return t;
            }
            try
            {
                t = JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return t;
        }

        /// <summary>
        /// 解决Mvc中Entity Farmework多对多关联Json序列化问题
        /// </summary>
        /// <param name="data"></param>
        /// <param name="contentType"></param>
        /// <param name="contentEncoding"></param>
        /// <param name="behavior"></param>
        /// <returns></returns>
        protected virtual JsonResult ToJson(object data, string contentType, Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return new MyJsonResult
            {
                Data = data,
                ContentType = contentType,
                ContentEncoding = contentEncoding,
                JsonRequestBehavior = behavior
            };
        }

        protected virtual JsonResult ToJson(object data, string contentType, Encoding contentEncoding)
        {
            return this.ToJson(data, contentType, contentEncoding, JsonRequestBehavior.DenyGet);
        }
        protected virtual JsonResult ToJson(object data, string contentType, JsonRequestBehavior behavior)
        {
            return this.ToJson(data, contentType, null, behavior);
        }
        protected virtual JsonResult ToJson(object data, JsonRequestBehavior behavior)
        {
            return this.ToJson(data, null, null, behavior);
        }
        protected virtual JsonResult ToJson(object data, string contentType)
        {
            return this.ToJson(data, contentType, null, JsonRequestBehavior.DenyGet);
        }

        protected virtual JsonResult ToJson(object data)
        {
            return this.ToJson(data, null, null, JsonRequestBehavior.DenyGet);
        }



        #endregion


        #region 返回值操作

        protected virtual JsonResult GetJsonResult()
        {
            return this.ToJson(resultStatus, JsonRequestBehavior.AllowGet);
        }
        protected virtual JsonResult GetJsonResult(ResultStatus resultStatus)
        {
            return this.ToJson(resultStatus, JsonRequestBehavior.AllowGet);
        }

        protected virtual JsonResult PostJsonResult()
        {
            return this.ToJson(resultStatus);
        }
        protected virtual JsonResult PostJsonResult(ResultStatus resultStatus)
        {
            return this.ToJson(resultStatus);
        }

        protected virtual JsonResult AllJsonResult(object object_Entity = null)
        {
            if (object_Entity != null)
            {
                return this.ToJson(object_Entity);
            }
            if (Object_Entity == null)
            {
                Object_Entity = new ResultStatus(Entity.StatusBase.NOT_FIND, AbsBase.N_FOND);
            }
            return this.ToJson(Object_Entity);
        }

        #endregion

        /// <summary>
        /// 自定义异常处理
        /// </summary>
        /// <param name="filterContext"></param>
        protected virtual void OnExceptionSunc(ExceptionContext filterContext)
        {
            Log4Helper.WriteLog<SuncBaseController>(filterContext, Utility.SuncLog4net.Model.LogEnum.Error, filterContext.Exception);
        }

        /// <summary>
        /// 重写异常处理 指定OnExceptionSunc定义
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnException(ExceptionContext filterContext)
        {
            OnExceptionSunc(filterContext);
            base.OnException(filterContext);
        }


        /// <summary>
        /// 获取Cookie实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name">cookie名称</param>
        /// <returns></returns>
        protected virtual T GetCookieModel<T>(string key) where T : class
        {
            return CookieHelper.GetCookieModel<T>(key);
        }

        /// <summary>
        /// 获取cookie
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        protected virtual string GetCookieValue(string key)
        {
            return CookieHelper.GetValue(key);
        }

        /// <summary>
        /// 获取session
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        protected virtual T GetSessionModel<T>(string key)
        {
            return (T)SessionHelper.GetSession(key);
        }

        /// <summary>
        /// 设置session
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="timeOut"></param>
        protected virtual void SetSession<T>(string key,T value,int timeOut = TIMEOUT)
        {
            SessionHelper.SetSession(key, value, timeOut);
        }

        /// <summary>
        /// 设置cookie
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="timeOut"></param>
        protected virtual void SetCookie<T>(string key,T value,int timeOut = TIMEOUT)
        {
            CookieHelper.Save(key, value, timeOut);
        }
    }
}
