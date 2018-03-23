using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sunc.Framework.Repository.Entity.Result;

namespace Sunc.Framework.Repository.Data.DataOperation
{
    public abstract class AbsBase
    {
        public const string N_FOND = "未找到相关数据！";
        public const string Y_EXISTENCE = "已存在相关数据！";

        public const string Y_INSERT = "添加成功！";
        public const string Y_UPDATE = "更新成功！";
        public const string Y_DELETE = "删除成功！";

        public const string N_INSERT = "添加失败！";
        public const string N_UPDATE = "更新失败！";
        public const string N_DELETE = "删除失败！";

        public virtual ResultStatus GetResult(int count = 0, string msg = "")
        {
            if (count > 0)
            {
                return new ResultStatus(Entity.StatusBase.SUCCESS);
            }
            return new ResultStatus(Entity.StatusBase.ERROR, msg);
        }

        public virtual ResultStatus GetResult(bool assertion , string msg = "")
        {
            if (assertion)
            {
                return new ResultStatus(Entity.StatusBase.SUCCESS);
            }
            return new ResultStatus(Entity.StatusBase.ERROR, msg);
        }
    }
}
