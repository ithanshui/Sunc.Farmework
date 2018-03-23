using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sunc.Framework.Repository.Entity.Result;
using Sunc.Framework.Repository.Utility;

namespace Sunc.Framework.Repository.Entity.Result
{
    public class ResultFile : ResultStatus
    {
        /// <summary>
        /// 项目基础路径
        /// </summary>
        public static string BaseDirectory { get { return AppDomain.CurrentDomain.BaseDirectory; } }

        internal ResultFile() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path">保存路径 如：upload/file</param>
        public ResultFile(string path) : this()
        {
            physicalPath = Path.Combine(BaseDirectory, path);
            //physicalPath = BaseDirectory + path;
            if (!Directory.Exists(physicalPath))
                Directory.CreateDirectory(physicalPath);
        }
        /// <summary>
        /// 原始文件名
        /// </summary>
        public string FileName { set; get; }

        private string storageFileName;
        /// <summary>
        /// 存储文件名
        /// </summary>
        public string StorageFileName
        {
            set
            {
                storageFileName = value;
            }
            get
            {
                if (string.IsNullOrEmpty(storageFileName))
                    storageFileName = GuidFileName();
                return storageFileName;
            }
        }
        /// <summary>
        /// 相对路径
        /// </summary>
        public string RelativePath { set; get; }
        private string physicalPath;
        /// <summary>
        /// 物理路径
        /// </summary>
        public string PhysicalPath
        {
            set
            {
                physicalPath = value;
            }
            get
            {
                //if (string.IsNullOrEmpty(physicalPath))
                //    return physicalPath;
                //if (!IsStrEnd(physicalPath, "\\"))
                //{
                //    physicalPath += "\\";
                //}
                return physicalPath;
            }
        }

        private int maxLength = 0;
        /// <summary>
        /// 最大长度 默认 int.MaxValue
        /// </summary>
        public int MaxLength { set { maxLength = value; } get { if (maxLength < 10240) { maxLength = int.MaxValue; } return maxLength; } }

        /// <summary>
        /// 是否检测长度限制
        /// </summary>
        public bool IsMaxLength { set; get; }

        /// <summary>
        /// 支持的扩展名 （null = 全部）
        /// </summary>
        public string[] Extension { set; get; }

        /// <summary>
        /// 文件扩展名
        /// </summary>
        public string FileExtension { set; get; }

        /// <summary>
        /// 是否检测扩展名
        /// </summary>
        public bool IsExtension { set; get; }

        /// <summary>
        /// 是否支持超过最大长度缩略（满足IsImage属性，则有效）
        /// </summary>
        public bool IsThumbnail { set; get; }

        /// <summary>
        /// 是否为图片文件
        /// </summary>
        public bool IsImage { set; get; }

        /// <summary>
        /// 保存文件全路径+文件名+扩展名
        /// </summary>
        public string SavePhysicalPath
        {
            get
            {
                if (string.IsNullOrEmpty(physicalPath))
                    return physicalPath;
                //if (!IsStrEnd(physicalPath, "\\"))
                //{
                //    physicalPath += "\\";
                //}
                return Path.Combine(physicalPath, StorageFileName, FileExtension);
                //return physicalPath + StorageFileName + FileExtension;
            }
        }
        /// <summary>
        /// 生成文件名
        /// </summary>
        /// <param name="type">"","N","D","B","P","X"</param>
        /// <returns></returns>
        public static string GuidFileName(string type = "N")
        {
            return RandomHelper.RandomGuid(type);
        }

        public bool IsStrEnd(string allStr, string endStr)
        {
            return allStr.Substring(allStr.Length - 1) == endStr;
        }
    }
}
