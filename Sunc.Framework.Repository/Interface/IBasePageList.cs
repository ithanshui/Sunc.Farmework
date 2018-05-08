using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sunc.Framework.Repository.Interface.BaseMethod;

namespace Sunc.Framework.Repository.Interface
{
    public interface IBasePageList
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
        object ObjEntity { set; get; }

        
    }
}
