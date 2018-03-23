using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Sunc.Framework.Repository.Utility
{
    public class SessionHelper
    {
        /// <summary>
        /// 根据session名获取session对象
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static object GetSession(string name)
        {
            return HttpContext.Current.Session[name];
        }

        public static bool GetSessionFlag(string name)
        {
            return SessionHelper.GetSession(name) != null ? true : false;
        }

        public static void Remove(string name)
        {
            if (GetSessionFlag(name))
            {
                HttpContext.Current.Session[name] = null;
            }
        }
        /// <summary>
        /// 设置session,sharejs.com
        /// </summary>
        /// <param name="name">session 名</param>
        /// <param name="val">session 值</param>
        public static void SetSession(string name, object val, int times = 30)
        {
            HttpContext.Current.Session.Remove(name);
            HttpContext.Current.Session.Add(name, val);
            HttpContext.Current.Session.Timeout = times;
        }

    }
}
