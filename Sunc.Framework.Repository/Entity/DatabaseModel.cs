using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunc.Framework.Repository.Entity
{
    public class DatabaseModel : ModelBase
    {
        /// <summary>
        /// Initial + 17位字符
        /// </summary>
        /// <param name="Initial"></param>
        /// <returns></returns>
        public static string GenerateId(string Initial = null)
        {
            return Initial + DateTime.Now.ToString("yyyyMMddHHmmssfff");
        }

    }
}
