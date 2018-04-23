using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Sunc.Framework.Repository.Entity;
using Sunc.Framework.Repository.Interface.BaseMethod;
using Sunc.Framework.Repository.Utility.SuncLog4net;
using Sunc.Framework.Repository.Utility.SuncLog4net.Model;

namespace Sunc.Framework.Repository.Data
{
    /// <summary>
    /// 基础(Base)DbContext
    /// </summary>
    public class CreateEntityContext: DbContext,IDisposable, IDataBaseRepository
    {
        public CreateEntityContext() : base() { }
        public CreateEntityContext(string configurationStr) : base(configurationStr) { }
        public int Delete<T>(T entity) where T : DatabaseModel
        {
            this.Entry<T>(entity).State = EntityState.Deleted;
            return SaveChanges();
        }

        public int Insert<T>(T entity) where T : DatabaseModel
        {
            this.Set<T>().Add(entity);
            return SaveChanges();
        }

        public T InsertModel<T>(T entity) where T : DatabaseModel
        {
            this.Set<T>().Add(entity);
            SaveChanges();
            return entity;
        }

        public int Update<T>(T entity) where T : DatabaseModel
        {
            try
            {
                var set = this.Set<T>();
                set.Attach(entity);
                this.Entry<T>(entity).State = EntityState.Modified;
                return SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                Log4Helper.WriteLog<EntityContext>(new Log4Extension { action_log = LogEnum.None, log_enum = LogEnum.Error, itemObject = ex.EntityValidationErrors }, LogEnum.Error, ex);
            }
            catch (Exception ex)
            {
                Log4Helper.WriteLog<EntityContext>(new Log4Extension { action_log = LogEnum.None, log_enum = LogEnum.Error }, LogEnum.Error, ex);
            }
            return 0;
        }

        public T UpdateModel<T>(T entity) where T : DatabaseModel
        {
            var set = this.Set<T>();
            set.Attach(entity);
            this.Entry<T>(entity).State = EntityState.Modified;
            SaveChanges();
            return entity;
        }
        public override int SaveChanges()
        {
            int count = 0;
            try
            {
                count = base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                Log4Helper.WriteLog<EntityContext>(new Log4Extension { action_log = LogEnum.None, log_enum = LogEnum.Error, itemObject = ex.EntityValidationErrors }, LogEnum.Error, ex);
            }
            catch (Exception ex)
            {
                Log4Helper.WriteLog<EntityContext>(new Log4Extension { action_log = LogEnum.None, log_enum = LogEnum.Error }, LogEnum.Error, ex);
            }
            return count;
        }

    }
}
