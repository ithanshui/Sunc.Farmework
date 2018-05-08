using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Sunc.Framework.Repository.Entity;
using Sunc.Framework.Repository.Entity.Result;

namespace Sunc.Framework.Repository.Data.DataOperation
{
    public abstract class AbsDataLayerBase : AbsBase
    {
        public delegate int DataBaseOperation<T>(T entity) where T : DatabaseModel;

        /// <summary>
        /// 不存在
        /// </summary>
        /// <returns></returns>
        protected virtual ResultStatus CreateErrorNotFond()
        {
            return new ResultStatus(Entity.StatusBase.NOT_FIND, N_FOND);
        }

        /// <summary>
        /// 已存在
        /// </summary>
        /// <returns></returns>
        protected virtual ResultStatus CreateErrorAlreadyExisting()
        {
            return new ResultStatus(Entity.StatusBase.ALREADY_EXISTING, Y_EXISTENCE);
        }


        public ResultStatus DatabaseModelOperation<T>(DataBaseOperation<T> dbContextMethod, T entity) where T : DatabaseModel
        {
            try
            {
                return GetResult(dbContextMethod(entity));
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                System.Diagnostics.Debug.WriteLine(err.Message);
                return new ResultStatus(StatusBase.ERROR, err.Message);
            }
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public abstract ResultStatus RemoveEntityAbs<T>(T entity) where T : DatabaseModel;
        /// <summary>
        /// 更新
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public abstract ResultStatus UpdateEntityAbs<T>(T entity) where T : DatabaseModel;

        /// <summary>
        /// 添加
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public abstract ResultStatus InsertEntityAbs<T>(T entity) where T : DatabaseModel;
    }
}
