using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

namespace Sunc.Framework.Repository.Utility.Excel
{
    public class NPOIExcel<T> where T : class
    {
        private string[] _headTitle;
        private IList<T> _source = new List<T>();

        private HSSFWorkbook _workBook;
        private IList<ISheet> _sheetList = new List<ISheet>();
        public NPOIExcel()
        {
            _workBook = new HSSFWorkbook();
        }
        public NPOIExcel(params string[] headTitleParams):this()
        {
            if (headTitleParams.Length > 0)
            {
                _headTitle = headTitleParams;
            }
        }
        public NPOIExcel(List<T> source, params string[] headTitleParams) : this(headTitleParams)
        {
            _source = source ?? new List<T>();

        }


        public ISheet CreateSheet(string sheetName = null)
        {
            ISheet sheet;
            if (string.IsNullOrEmpty(sheetName))
            {
                sheet = _workBook.CreateSheet();
            }
            else
            {
                sheet = _workBook.CreateSheet(sheetName);
            }
            _sheetList.Add(sheet);
            return sheet;
        }
        private string[] GetPropetyFeild()
        {
            Type type = typeof(T);
            var propertiesInfo = type.GetProperties();
            string[] fields = new string[propertiesInfo.Length];
            for (int i = 0; i < propertiesInfo.Length; i++)
            {
                fields[i] = propertiesInfo[i].Name;
            }
            return fields;
        }
        public HSSFWorkbook GenerateExcel()
        {
           
            foreach (var sheet in _sheetList)
            {
                int rowNumber = 0;
                if (_headTitle != null && _headTitle.Length > 0)
                {
                    IRow row = sheet.CreateRow(rowNumber);
                    for (var i = 0; i < _headTitle.Length; i++)
                    {
                        row.CreateCell(i).SetCellValue(_headTitle[i]);
                    }
                    rowNumber++;
                }
                if (_source != null)
                {
                   
                    for (int i = 0; i < _source.Count; i++)
                    {
                        IRow row = sheet.CreateRow(rowNumber);
                        var propertieInfo = _source[i].GetType().GetProperties();
                        for (var j = 0; j < propertieInfo.Length; j++)
                        {
                            row.CreateCell(j).SetCellValue(propertieInfo[j].GetValue(_source[i])+"");
                        }

                        rowNumber++;
                    }
                }
                
            }
            return _workBook;
            //MemoryStream memoryStream = new MemoryStream();
            //_workBook.Write(memoryStream);
            //Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}.xls", DateTime.Now.ToString("yyyyMMddHHmmssfff")));
            //Response.BinaryWrite(ms.ToArray());
            //book = null;
            //ms.Close();
            //ms.Dispose();
        }



    }
}
