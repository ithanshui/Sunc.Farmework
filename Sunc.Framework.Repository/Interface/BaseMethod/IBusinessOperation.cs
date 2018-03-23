using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sunc.Framework.Repository.Entity;
using Sunc.Framework.Repository.Entity.Result;

namespace Sunc.Framework.Repository.Interface.BaseMethod
{
    /// <summary>
    /// 底层数据操作
    /// </summary>
    /// <typeparam name="Entity"></typeparam>
    /// <typeparam name="Key"></typeparam>
   public interface IBusinessOperation<Entity,Key> where Entity :ModelBase //,IBaseOperation<Entity>
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        ResultStatus AddEntity(Entity entity);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        ResultStatus RemoveEntity(Entity entity);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        ResultStatus RemoveEntityByKey(Key key);

        /// <summary>
        /// 获取全部
        /// </summary>
        /// <returns></returns>
        IQueryable<Entity> GetEntityList();

        /// <summary>
        /// 获取单个
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Entity GetOnlyEntityByKey(Key key);

        /// <summary>
        /// 获取多个
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        IQueryable<Entity> GetMoreEntityByKey(Key key);

        /// <summary>
        /// 判断是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool IsHave(Key key);
    }
}
