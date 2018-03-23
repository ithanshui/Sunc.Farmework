
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Sunc.Framework.Repository.Utility
{
    public class CookieHelper
    {
        /// <summary>
        /// 取Cookie
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static HttpCookie Get(string name)
        {
            return HttpContext.Current.Request.Cookies[name];
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public static T GetCookieModel<T>(string name) where T : class
        {
            string value = GetValue(name);
            if (!string.IsNullOrEmpty(value))
            {
                return JsonConvert.DeserializeObject<T>(value);
            }
            return null;
        }


        /// <summary>
        /// 取Cookie值
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetValue(string name)
        {
            var httpCookie = Get(name);
            if (httpCookie != null)
                return HttpUtility.UrlDecode(httpCookie.Value);
            else
                return string.Empty;
        }

        /// <summary>
        /// 移除Cookie
        /// </summary>
        /// <param name="name"></param>
        public static void Remove(string name)
        {
            CookieHelper.Remove(CookieHelper.Get(name));
        }

        public static void Remove(HttpCookie cookie)
        {
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now;
                CookieHelper.Save(cookie);
            }
        }

        /// <summary>
        /// 保存Cookie
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="expiresHours"></param>
        public static void Save(string name, string value, int expiresHours = 0)
        {
            var httpCookie = Get(name);
            if (httpCookie == null)
                httpCookie = Set(name);

            httpCookie.Value = HttpUtility.UrlEncode(value);
            CookieHelper.Save(httpCookie, expiresHours);
        }
        public static void Save<T>(string name, T value, int expiresHours = 0)
        {
            var httpCookie = Get(name);
            if (httpCookie == null)
                httpCookie = Set(name);

            httpCookie.Value = HttpUtility.UrlEncode(JsonConvert.SerializeObject(value));
            CookieHelper.Save(httpCookie, expiresHours);
        }
        public static void Save<T>(string name, IEnumerable<T> value, int expiresHours = 0)
        {
            var httpCookie = Get(name);
            if (httpCookie == null)
                httpCookie = Set(name);

            httpCookie.Value = HttpUtility.UrlEncode(JsonConvert.SerializeObject(value));
            CookieHelper.Save(httpCookie, expiresHours);
        }
        public static void Save(HttpCookie cookie, int expiresHours = 0)
        {
            string domain = Fetch.ServerDomain;
            string urlHost = HttpContext.Current.Request.Url.Host.ToLower();
            if (domain != urlHost)
                cookie.Domain = domain;

            if (expiresHours > 0)
                cookie.Expires = DateTime.Now.AddHours(expiresHours);

            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public static HttpCookie Set(string name)
        {
            return new HttpCookie(name);
        }

    }
}
