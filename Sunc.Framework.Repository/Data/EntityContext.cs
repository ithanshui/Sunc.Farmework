using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sunc.Framework.Repository.Entity;

namespace Sunc.Framework.Repository.Data
{
    /// <summary>
    /// DbContext 默认机制
    /// </summary>
    public class EntityContext : CreateEntityContext
    {
        static EntityContext()
        {
            //默认方式 第一次创建            
            Database.SetInitializer<EntityContext>(new CreateDatabaseIfNotExists<EntityContext>());
        }
        public EntityContext() : base() { }
        public EntityContext(string configurationStr) : base(configurationStr) {}
    }
}
