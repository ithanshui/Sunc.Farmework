using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Sunc.Framework.Repository.Entity.Carrier.Extension
{
    public class KeyValueUtil
    {
        public static IEnumerable<SelectListItem> ToSelectListItem(IEnumerable<KeyValueBase<string, string>> model, string selected = "")
        {
            foreach (var item in model)
                yield return new SelectListItem { Text = item.key, Value = item.value, Selected = item.value == selected };
        }
    }
}
