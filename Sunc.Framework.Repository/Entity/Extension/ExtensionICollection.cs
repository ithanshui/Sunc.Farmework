using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Sunc.Framework.Repository.Entity.Extension
{
    public static class ExtensionICollection
    {
        public static string ToJson(this ICollection<DatabaseModel> models)
        {
            return EntityBase.ToJson(models);
        }
    }
}
