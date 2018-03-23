using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunc.Framework.Repository.Utility
{
    public class PathHelper
    {
        public static string AbsoluteCoventRelactive(string path)
        {
            return path.Replace('\\', '/');
        }
    }
}
