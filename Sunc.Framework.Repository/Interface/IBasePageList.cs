using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sunc.Framework.Repository.Interface.BaseMethod;

namespace Sunc.Framework.Repository.Interface
{
    public interface IBasePageList<T>
    {
      
        IBaseEntityPageList<T> GetPageList(int pageIndex = 1, int pageSize = 10);
    }
}
