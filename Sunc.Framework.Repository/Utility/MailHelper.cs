using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Sunc.Framework.Repository.Utility.Model;

namespace Sunc.Framework.Repository.Utility
{
    /// <summary>
    /// 邮件发送帮助类
    /// </summary>
    public sealed class MailHelper
    {
        private MailHelper() { }
        public static void SendOutlookService(MailEntity mailEntity)
        {
            var app = new Microsoft.Office.Interop.Outlook.Application();

            var mail = app.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);
            mail.HTMLBody = mailEntity.HTMLBody;
           
            if (mailEntity.isHaveAttachment)
            {
                //Add an attachment.
                string attachName = "attachName";
                int attachPos = (int)mail.Body.Length + 1;
                int attachType = (int)Microsoft.Office.Interop.Outlook.OlAttachmentType.olByValue;
                //now attached the file
                mail.Attachments.Add(mailEntity.Attachment, attachType, attachPos, attachName);
            }
            //Subject line
            mail.Subject = mailEntity.Subject;
            // Add a recipient.
            var oRecip = mail.Recipients.Add(mailEntity.ToAccount);//fengshanling
            oRecip.Resolve();
            // Send.
            mail.Send();
        }
    }
}
