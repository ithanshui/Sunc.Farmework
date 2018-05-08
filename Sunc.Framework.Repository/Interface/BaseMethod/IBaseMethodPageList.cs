using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Sunc.Framework.Repository.Entity;

namespace Sunc.Framework.Repository.Interface.BaseMethod
{
    public interface IBaseMethodPageList<Entity>
    {
        IBaseEntityPageList<Entity> GetPageList(int pageIndex, int pageSize);


        IBaseEntityPageList<Entity> GetPageList<TKey>(Expression<Func<Entity, bool>> predicate, Expression<Func<Entity, TKey>> order, int pageIndex, int pageSize, bool isOrder = true);
    }
}
