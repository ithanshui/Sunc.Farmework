using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunc.Framework.Repository.Interface.BaseMethod
{
    public interface IBaseEntityPageList<Entity>
    {
        int Count
        {
            get;
        }

        int PageIndex
        {
            get;
        }

        int PageSize
        {
            get;
        }

        int PageCount
        {
            get;
        }

        bool Next
        {
            get;
        }

        bool Previous
        {
            get;
        }

        List<Entity> Source
        {
            get;
        }
        void AddRange(IEnumerable<Entity> collections, int pageIndex = 1, int pageSize = 10, int count = 0);
    }
}
