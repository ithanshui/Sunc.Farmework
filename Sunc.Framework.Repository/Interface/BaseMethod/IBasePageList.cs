using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunc.Framework.Repository.Interface.BaseMethod
{
    public interface IBasePageList<Entity>
    {
        void AddRange(IEnumerable<Entity> collections);
    }
}
