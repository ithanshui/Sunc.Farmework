using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Sunc.Framework.Repository.Entity.Extension
{
    public static class ExtensionIQueryable
    {
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="list"> 数据源 </param>
        /// <param name="order"> 排序表达式 </param>
        /// <param name="page"> 第几页 </param>
        /// <param name="size"> 每页记录数 </param>
        /// <param name="count"> 记录总数 </param>
        /// <returns></returns>
        public static IQueryable<T> Pagination<T, TKey>(this IQueryable<T> list, Expression<Func<T, bool>> predicate, Expression<Func<T, TKey>> order, int page, int size, out int count)
        {
            var source = list.Where(predicate.Compile()).AsQueryable();
            count = source.Count();
            return source.OrderBy(order).Skip((page - 1) * size).Take(size);
        }

        public static V ToModel<T, V>(this T t) where T : ModelBase, V where V : ModelBase
        {
            return t;
        }
        public static string ToJson(this IQueryable<DatabaseModel> models)
        {
            return EntityBase.ToJson(models);
        }

    }
}
