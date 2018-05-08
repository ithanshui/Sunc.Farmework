using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sunc.Framework.Repository.Interface.BaseMethod;

namespace Sunc.Framework.Repository.Entity
{

    [Serializable]
    public class PageListBase<Entity> : IBaseEntityPageList<Entity>
    {
        private List<Entity> _Source = new List<Entity>();
        private int count;
        private int pageIndex;
        private int pageSize;
        private int pageCount;
        private bool next;
        private bool previous;

        public int Count
        {
            get
            {
                return count;
            }

            set
            {
                count = value;
            }
        }

        public int PageIndex
        {
            get
            {
                return pageIndex;
            }

            set
            {
                pageIndex = value;
            }
        }

        public int PageSize
        {
            get
            {
                return pageSize;
            }

            set
            {
                pageSize = value;
            }
        }

        public int PageCount
        {
            get
            {
                return pageCount;
            }

            set
            {
                pageCount = value;
            }
        }

        public bool Next
        {
            get
            {
                return next;
            }

            set
            {
                next = value;
            }
        }

        public bool Previous
        {
            get
            {
                return previous;
            }

            set
            {
                previous = value;
            }
        }

        public List<Entity> Source
        {
            get
            {
                return _Source;
            }

            set
            {
                _Source = value;
            }
        }
        private object _objEntity;
        public object ObjEntity
        {
            get
            {
                return _objEntity;
            }

            set
            {
                _objEntity = value;
            }
        }
        public PageListBase(){}
        public PageListBase(IEnumerable<Entity> collections, int pageIndex = 1, int pageSize = 10, int count = 0)
        {
            AddRange(collections, pageIndex, pageSize, count);
        }
        public void AddRange(IEnumerable<Entity> collections, int pageIndex = 1, int pageSize = 10, int count = 0)
        {
            if (collections == null && collections.Count() == 0)
                return;
            if (pageIndex < 1) pageIndex = 1;
            if (pageSize < 1) pageSize = 10;
            this.count = count;
            this.pageIndex = pageIndex;
            this.pageSize = pageSize;
            this.pageCount = (count / PageSize) + (count % PageSize > 0 ? 1 : 0);
            this.next = (pageIndex + 1 <= pageCount);
            this.previous = (pageIndex - 1 >= 1);
            Source.AddRange(collections);

        }


    }
}
