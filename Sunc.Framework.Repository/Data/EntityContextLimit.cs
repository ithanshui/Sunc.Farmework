using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sunc.Framework.Repository.Entity;
using Sunc.Framework.Repository.Interface.BaseMethod;
using Sunc.Framework.Repository.Utility.SuncLog4net;
using Sunc.Framework.Repository.Utility.SuncLog4net.Model;

namespace Sunc.Framework.Repository.Data
{
    /// <summary>
    /// DbContext 限制机制
    /// </summary>
    public class EntityContextLimit : CreateEntityContext
    {

         static EntityContextLimit()
        {
            Database.SetInitializer<EntityContextLimit>(null);
        }
        public EntityContextLimit() : base() { }
        public EntityContextLimit(string configurationStr) : base(configurationStr) { }
    }
}
