using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Sunc.Framework.Repository.Utility;

namespace Sunc.Framework.Repository.Entity.Extension
{
    public static class StatusBaseEnumExtension
    {
        /// <summary>
        /// 获取状态码
        /// </summary>
        /// <param name="statusBase"></param>
        /// <returns></returns>
        public static int ToStatusCode(this StatusBase statusBase)
        {
            return (int)statusBase;
        }

        public static string Todescription(this StatusBase statusBase)
        {
            return EnumUtility.GetEnumDescription(statusBase);
        }

    }
}
