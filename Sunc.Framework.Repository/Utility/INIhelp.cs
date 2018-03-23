﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Sunc.Framework.Repository.Utility
{
    public   class INIhelp
    {
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filepath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retval, int size, string filePath);

        //ini文件名称
        private static string inifilename = "Config.ini";
        //获取ini文件路径
        private static string inifilepath = Directory.GetCurrentDirectory() + "\\conf\\" + inifilename;

        public static void SetIniFilePath(string path)
        {
            inifilepath = path;
        }
        public static void SetIniFileName(string name)
        {
            inifilename = name;
        }
        public static string GetValue(string section,string key)
        {
            StringBuilder s = new StringBuilder(1024);
            GetPrivateProfileString(section, key, "", s, 1024, inifilepath);
            return s.ToString();
        }


        public static void SetValue(string section ,string key, string value)
        {
            try
            {
                WritePrivateProfileString(section, key, value, inifilepath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
