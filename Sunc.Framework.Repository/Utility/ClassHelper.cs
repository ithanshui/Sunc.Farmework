using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunc.Framework.Repository.Utility
{
    public class ClassHelper
    {
        public static T CreateClass<T>(bool isCache = false) where T : class, new()
        {
            if (isCache)
            {
                Type type = typeof(T);
                T t = (T)CacheHelper.GetCache(type.Name);
                if(t  != null)
                {
                    return t;
                }
            }
            return new T();
        }
    }
}
