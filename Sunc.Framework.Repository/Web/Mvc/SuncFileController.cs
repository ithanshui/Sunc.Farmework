using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Sunc.Framework.Repository.Data.DataOperation;
using Sunc.Framework.Repository.Entity;
using Sunc.Framework.Repository.Entity.Result;
using Sunc.Framework.Repository.Entity.Extension;
using Sunc.Framework.Repository.Utility;
using System.IO;
using Sunc.Framework.Repository.Utility.SuncLog4net;

namespace Sunc.Framework.Repository.Web.Mvc
{
    public class SuncFileController : SuncJavaScriptController
    {
        /// <summary>
        /// 单文件上传
        /// </summary>
        /// <param name="file">文件</param>
        /// <param name="resultFile">返回值</param>
        protected virtual void SuncUpLoadFile(HttpPostedFileBase file, ref ResultFile resultFile)
        {
            try
            {
                //检测是否存在文件
                if (file == null)
                {
                    resultFile.SetStatus(StatusBase.NOT_FIND);
                    return;
                }
                //文件名
                resultFile.FileName = file.FileName.Substring(0, file.FileName.LastIndexOf('.') - 1);
                //提取扩展名
                resultFile.FileExtension = file.FileName.Substring(file.FileName.IndexOf('.')).ToLower();
                //扩展名检测
                if (resultFile.IsExtension)
                {
                    if (resultFile.Extension != null)
                    {
                        if (!resultFile.Extension.Contains(resultFile.FileExtension))
                        {
                            resultFile.SetProprty(StatusBase.ERROR.ToStatusCode(), false, "不允许的扩展名！");
                            return;
                        }
                    }
                }
                //图片缩略
                //if (resultFile.IsImage && resultFile.IsThumbnail)
                //{

                //}

                //限制长度
                if (resultFile.IsMaxLength)
                {
                    if (resultFile.MaxLength < file.ContentLength)
                    {
                        resultFile.SetStatus(StatusBase.ERROR, "超过最大长度！");
                        return;
                    }
                }

                resultFile.StorageFileName = ResultFile.GuidFileName();

                file.SaveAs(resultFile.SavePhysicalPath);
                resultFile.SetStatus(StatusBase.SUCCESS);
                return;
            }
            catch (Exception ex)
            {
                resultFile.SetStatus(StatusBase.ERROR, ex.Message);
                return;
            }
        }

        /// <summary>
        /// 文件下载
        /// </summary>
        /// <param name="physicalPath">物理路径</param>
        /// <param name="fileName">下载后的文件名</param>
        /// <returns></returns>
        protected virtual bool DownLoad(string physicalPath, string fileName = "")
        {
            try
            {
                FileInfo file = new FileInfo(physicalPath);
                if (file.Exists)
                {

                    if (string.IsNullOrEmpty(fileName))
                        fileName = Path.GetFileName(physicalPath);
                    Response.Clear();
                    Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
                    Response.AddHeader("Content-Length", file.Length.ToString());
                    Response.ContentType = "application/octet-stream;charset=UTF-8";
                    Response.WriteFile(file.FullName);
                    Response.Flush();
                    Response.Close();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Log4Helper.WriteLog<SuncFileController>(ex, Utility.SuncLog4net.Model.LogEnum.Error, ex);
                return false;
            }
        }

        /// <summary>
        /// 是否为Url
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        protected virtual bool IsUrl(string url)
        {
            return RegExp.IsUrl(url);
        }
    }
}
