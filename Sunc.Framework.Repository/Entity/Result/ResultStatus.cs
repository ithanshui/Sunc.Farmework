using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sunc.Framework.Repository.Entity.Extension;

namespace Sunc.Framework.Repository.Entity.Result
{
    public class ResultStatus : ResultBase
    {
        public ResultStatus()
        {
            this.SetStatus();
        }

        public ResultStatus(StatusBase statusBase, string msg = "", object obj = null)
        {

            this.SetStatus(statusBase);
            if (!string.IsNullOrEmpty(msg))
            {
                this.Msg = msg;
            }
            this.ObjectEntity = obj;
        }

        /// <summary>
        /// 任意类
        /// </summary>
        public object ObjectEntity { set; get; }

        /// <summary>
        /// 设置状态
        /// </summary>
        /// <param name="statusBase">基础状态</param>
        public void SetStatus(StatusBase statusBase = StatusBase.NOT_FIND, string msg = "")
        {
            switch (statusBase)
            {
                case StatusBase.SUCCESS:
                    base.SetProprty(statusBase.ToStatusCode(), true, statusBase.Todescription());
                    break;
                default:
                    base.SetProprty(statusBase.ToStatusCode(), false, statusBase.Todescription());
                    break;
            }
            if (!string.IsNullOrEmpty(msg))
                base.Msg = msg;
        }

        public override void SetProprty(int status, bool assertion, string msg)
        {
            base.SetProprty(status, assertion, msg);
        }

        public static ResultStatus CreateResultStatus(StatusBase statusBase = StatusBase.NOT_FIND, string msg = "", object obj = null)
        {
            return new ResultStatus(statusBase, msg,obj);
        }
    }
}
