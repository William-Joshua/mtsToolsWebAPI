using mtsToolsWebAPI.Common;
using mtsToolsWebAPI.EFCore.EntityFrameworkCore;
using mtsToolsWebAPI.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Z.EntityFramework.Plus;

namespace mtsToolsWebAPI.Repositories
{
    /// <summary>
    /// 数据库事务操作方法
    /// </summary>
    public class TransactionWork : ITransactionWork
    {
        protected EFCoreContext efCoreContext;

        public TransactionWork(EFCoreContext _efCoreContext)
        {
            efCoreContext = _efCoreContext;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Add<T>(T entity) where T : GenericModel
        {
            try
            {
                efCoreContext.Entry(entity).State = EntityState.Added;
                int rowsAffected = efCoreContext.SaveChanges();
                return rowsAffected > 0 ? true : false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public bool BatchAdd<T>(T[] entities) where T : GenericModel
        {
            try
            {
                efCoreContext.Set<T>().AddRange(entities);
                int rowsAffected = efCoreContext.SaveChanges();
                return rowsAffected == entities.Length ? true : false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Update<T>(T entity) where T : class
        {
            try
            {
                efCoreContext.Set<T>().Attach(entity);
                efCoreContext.Entry(entity).State = EntityState.Modified;
                int rowsAffected = efCoreContext.SaveChanges();
                return rowsAffected > 0 ? true : false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// 根据条件更新数据
        /// <para>如：Update(u =>u.Id==1,u =>new User{Name="ok"});</para>
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="entity">The entity.</param>
        public bool Update<T>(Expression<Func<T, bool>> where, Expression<Func<T, T>> entity) where T : class
        {
            try
            {
                efCoreContext.Set<T>().Where<T>(where).Update(entity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// 根据ID获取单个数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetEntiyByID<T>(Guid id) where T : GenericModel
        {
            try
            {
                Expression<Func<T, bool>> where = x => x.ID.Equals(id);
                var modelList = efCoreContext.Set<T>().Where<T>(where).AsQueryable().ToList();
                return modelList.Any() ? modelList.FirstOrDefault() : null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// 根据查询条件获取单个数据
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public T GetEntityByWhere<T>(Expression<Func<T, bool>> expression) where T : class
        {
            return efCoreContext.Set<T>().FirstOrDefault(expression);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Delete<T>(T entity) where T : class
        {
            try
            {
                efCoreContext.Set<T>().Remove(entity);
                int rowsAffected = efCoreContext.SaveChanges();
                return rowsAffected > 0 ? true : false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// 根据条件删除数据
        /// </summary>
        /// <param name="expression"></param>
        public bool Delete<T>(Expression<Func<T, bool>> expression) where T : class
        {
            try
            {
                efCoreContext.Set<T>().Where<T>(expression).Delete();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 判断数据是否存在
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public bool IsExist<T>(Expression<Func<T, bool>> expression) where T : class
        {
            return efCoreContext.Set<T>().Any(expression);
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="orderColumn">排序字段</param>
        /// <param name="expression">查询条件</param>
        /// <param name="orderBy">排序方式</param>
        /// <returns></returns>
        public List<T> GetList<T>(string orderColumn, Expression<Func<T, bool>> expression = null, string orderBy = "desc") where T : class
        {
            try
            {
                IQueryable<T> quary;
                if (expression != null)
                {
                    quary = efCoreContext.Set<T>().AsNoTracking().AsQueryable();
                }
                else
                {
                    quary = efCoreContext.Set<T>().AsNoTracking().AsQueryable().Where(expression);
                }
                return orderBy == "desc" ? quary.OrderByDescending(orderColumn).ToList() : quary.OrderBy(orderColumn).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// 获取分页数据列表
        /// </summary>
        /// <param name="expression">查询条件</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="orderColumn">排序字段</param>
        /// <param name="orderBy">排序方式</param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<T> GetPageList<T>(Expression<Func<T, bool>> expression, int pageSize, int pageIndex, out int totalCount, string orderColumn, string orderBy = "desc") where T : class
        {
            try
            {
                if (pageIndex < 1)
                {
                    pageIndex = 1;
                }
                int skipCount = (pageIndex - 1) * pageSize;
                totalCount = efCoreContext.Set<T>().Where<T>(expression).Count();
                IQueryable<T> quary = efCoreContext.Set<T>().AsNoTracking().AsQueryable().Where(expression);
                return orderBy == "desc" ? quary.OrderByDescending(orderColumn).Skip(skipCount).Take(pageSize).ToList() : quary.OrderBy(orderColumn).Skip(skipCount).Take(pageSize).ToList();
            }
            catch (Exception ex)
            {
                totalCount = 0;
                return null;
            }
        }
    }
}
