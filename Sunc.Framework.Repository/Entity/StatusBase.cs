using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunc.Framework.Repository.Entity
{
    /// <summary>
    /// 基础状态
    /// </summary>
    public enum StatusBase
    {
        /// <summary>
        /// 成功
        /// </summary>
        [Description("成功")]
        SUCCESS = 200,

        /// <summary>
        /// 已存在
        /// </summary>
        [Description("已存在")]
        ALREADY_EXISTING = 300,

        /// <summary>
        /// 未获取
        /// </summary>
        [Description("未获取")]
        NOT_FIND = 404,
        /// <summary>
        /// 失败
        /// </summary>
        [Description("失败")]
        ERROR = 500
    }
}
