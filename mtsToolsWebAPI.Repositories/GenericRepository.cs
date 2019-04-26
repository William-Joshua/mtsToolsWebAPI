using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using mtsToolsWebAPI.Common;
using mtsToolsWebAPI.EFCore.EntityFrameworkCore;
using mtsToolsWebAPI.Factories;

namespace mtsToolsWebAPI.Repositories
{
    public class GenericRepository<T>  : IGenericRepository<T> where T :class,new()
    {
        private EFCoreContext efCoreContext;

        protected IDbFactory DbFactory
        {
            get;
            private set;
        }

        protected EFCoreContext DbContext
        {
            get { return efCoreContext ?? (efCoreContext = DbFactory.Init()); }
        }

        public GenericRepository(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
        }

        public IQueryable<T> GetAll()
        {
            return DbContext.Set<T>();
        }

        public ServiceResponse GetModelQuery(T queryCondition)
        {
            try
            {
                Expression<Func<T, bool>> whereQueryCondition = EFExpressionHelper.GenerateQueryExpression<T>(queryCondition);
                var queryRecords = DbContext.Set<T>().Where<T>(whereQueryCondition).ToList();

                return new ServiceResponse() { Success = true, Results = queryRecords };
            }
            catch (Exception exception)
            {
                return new ServiceResponse() { Success = false, ErrorCode = exception.Message };
            }
           
        }
        public async Task<ServiceResponse> DeleteEntity(T entity)
        {
            try
            {
                DbContext.Entry<T>(entity).State = EntityState.Deleted;
                var task = await DbContext.SaveChangesAsync();
                bool result = task > 0 ? true : false;
                return new ServiceResponse() { Success = result };
            }
            catch (Exception exception)
            {
                return new ServiceResponse() { Success = false, ErrorCode = exception.Message };
            }
        }

        public async Task<ServiceResponse> UpdateEntity(T entity)
        {
            try
            {
                DbEntityEntry entry = DbContext.Entry<T>(entity);
                entry.State = EntityState.Modified;
                var task = await DbContext.SaveChangesAsync();
                bool result = task > 0 ? true : false;
                return new ServiceResponse() { Success = result };
            }
            catch (Exception exception)
            {
                return new ServiceResponse() { Success = false, ErrorCode = exception.Message };
            }
        }

        public async Task<ServiceResponse> AddEntity(T entity)
        {
            try
            {
                DbContext.Set<T>().Add(entity);
                var task = await DbContext.SaveChangesAsync();
                bool result = task > 0 ? true : false;
                return new ServiceResponse() { Success = result };
            }
            catch (Exception exception)
            {
                return new ServiceResponse() { Success = false, ErrorCode = exception.Message };
            }
        }

        public async Task<ServiceResponse> ExistEntity(T queryCondition)
        {
            try
            {
                Expression<Func<T, bool>> whereQueryCondition = EFExpressionHelper.GenerateQueryExpression<T>(queryCondition);
                var task = await DbContext.Set<T>().Where<T>(whereQueryCondition).CountAsync();
                bool result = task > 0 ? true : false;
                return new ServiceResponse() { Success = result };
            }
            catch (Exception exception)
            {
                return new ServiceResponse() { Success = false, ErrorCode = exception.Message };
            }
        }
    }
}
