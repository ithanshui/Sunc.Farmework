using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Sunc.Framework.Repository.Web.Mvc.OverrideExtension
{
    public class MyJsonResult: JsonResult
    {
        //public Encoding ContentEncoding { get; set; }
        //public string ContentType { get; set; }
        //public object Data { get; set; }
        //public JsonRequestBehavior JsonRequestBehavior { get; set; }
        //public int? MaxJsonLength { get; set; }
        //public int? RecursionLimit { get; set; }
        public MyJsonResult() { }
        public MyJsonResult(object Data) {
            this.Data = Data;
        }
        public MyJsonResult(object Data, JsonRequestBehavior JsonRequestBehavior = JsonRequestBehavior.DenyGet) :this(Data){
            this.JsonRequestBehavior = JsonRequestBehavior;
        }
        public MyJsonResult(object Data, string ContentType,Encoding ContentEncoding = null, JsonRequestBehavior JsonRequestBehavior = JsonRequestBehavior.DenyGet) :this(Data,JsonRequestBehavior) {
            this.ContentType = ContentType;
            if(ContentEncoding != null)
            {
                this.ContentEncoding = ContentEncoding;
            }
        }
        public override void ExecuteResult(ControllerContext context)
        {
            if(this.JsonRequestBehavior == JsonRequestBehavior.DenyGet
                && string.Compare(context.HttpContext.Request.HttpMethod,"Get",true) == 0)
            {
                throw new InvalidOperationException();
            }
            HttpResponseBase response = context.HttpContext.Response;
            response.ContentType = string.IsNullOrEmpty(this.ContentType) ?
                "application/json" : this.ContentType;
            if(this.ContentEncoding != null)
            {
                response.ContentEncoding = this.ContentEncoding;
            }
            if(null != this.Data)
            {
                JsonSerializerSettings set = new JsonSerializerSettings();
                set.Formatting = Formatting.Indented;
                //set.MaxDepth = 10;
                set.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                response.Write(JsonConvert.SerializeObject(this.Data,set));
            }
        }
    }
}
