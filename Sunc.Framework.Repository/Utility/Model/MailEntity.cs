using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunc.Framework.Repository.Utility.Model
{
    public class MailEntity
    {
        /// <summary>
        /// 主题
        /// </summary>
        public string Subject { set; get; }

        /// <summary>
        /// 内容
        /// </summary>
        public string HTMLBody { set; get; }

        /// <summary>
        /// 是否拥有附件
        /// </summary>
        public bool isHaveAttachment { set; get; } = false;

        /// <summary>
        /// 附件路径
        /// </summary>
        public string Attachment { set; get; } = @"E:\\hello.txt";

        /// <summary>
        /// 接收人
        /// </summary>
        public string ToAccount { set; get; }
    }
}
