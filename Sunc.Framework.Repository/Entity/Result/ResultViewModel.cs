using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sunc.Framework.Repository.Interface;

namespace Sunc.Framework.Repository.Entity.Result
{
    public class ResultViewModel : IBasePageList
    {
        private int _count;
        public int Count
        {
            get
            {
                return _count;
            }
            set
            {
                _count = value;
            }
        }

        private bool _next;
        public bool Next
        {
            get
            {
                return _next;
            }
            set
            {
                _next = value;
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
        private int _pageCount;
        public int PageCount
        {
            get
            {
                return _pageCount;
            }
            set
            {
                _pageCount = value;
            }
        }
        private int _pageIndex;
        public int PageIndex
        {
            get
            {
                if (_pageIndex < 1)
                    return 1;
                return _pageIndex;
            }
            set
            {
               
                _pageIndex = value;
            }
        }
        private int _pageSize;
        public int PageSize
        {
            get
            {
                if (_pageSize < 1)
                    return 10;
                return _pageSize;
            }
            set
            {
                _pageSize = value;
            }
        }
        private bool _previous;
        public bool Previous
        {
            get
            {
                return _previous;
            }
            set
            {
                _previous = value;
            }
        }

        private string _keyword;
        public string Keyword
        {
            set
            {
                _keyword = value;
            }
            get
            {
                if (string.IsNullOrEmpty(_keyword))
                    return "";
                return _keyword;
            }
        }
    }
}
