using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunc.Framework.Repository.Data.Configuration
{
    public class EntityTypeConfigurationSunc<T> : EntityTypeConfiguration<T> where T : class
    {
        /// <summary>
        /// 描述最大长度
        /// </summary>
        protected const int DESCRIPT_NUMBER = 500;
    }
}
