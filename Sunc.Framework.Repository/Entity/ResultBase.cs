using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Sunc.Framework.Repository.Entity
{
    [Serializable]
    public abstract class ResultBase:EntityBase
    {
      
        /// <summary>
        /// 状态
        /// </summary>
        public int Status { set; get; }
        /// <summary>
        /// 断言
        /// </summary>
        public bool Assertion { set; get; }

        /// <summary>
        /// 消息
        /// </summary>
        public string Msg { set; get; }

        /// <summary>
        /// 实现设置基本信息
        /// </summary>
        /// <param name="assertion">断言</param>
        public void SetAssertion(bool assertion)
        {
            if (assertion)
            {
                this.Status = 200;
                this.Assertion = assertion;
                this.Msg = "成功！";
            }
        }

        /// <summary>
        /// 基础设置
        /// </summary>
        /// <param name="status"></param>
        /// <param name="assertion"></param>
        /// <param name="msg"></param>
        public virtual void SetProprty(int status, bool assertion, string msg)
        {
            this.Status = status;
            this.Assertion = assertion;
            this.Msg = msg;
        }

        //public string ToJson()
        //{
        //    JsonSerializerSettings st = new JsonSerializerSettings();
        //    st.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        //   return  JsonConvert.SerializeObject(this, st);
        //}

    }
}
