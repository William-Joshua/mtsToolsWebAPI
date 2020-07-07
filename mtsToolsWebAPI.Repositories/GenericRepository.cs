using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using mtsToolsWebAPI.Common;
using mtsToolsWebAPI.EFCore;
using mtsToolsWebAPI.EFCore.EntityFrameworkCore;
using mtsToolsWebAPI.IRepositories;
using Z.EntityFramework.Plus;

namespace mtsToolsWebAPI.Repositories
{
    /// <summary>
    /// 数据操作通用方法
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericRepository<T>  : IGenericRepository<T> where T : GenericModel
    {
        protected EFCoreContext _efCoreContext;

        public GenericRepository(EFCoreContext efCoreContext)
        {
            _efCoreContext = efCoreContext;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Add(T entity)
        {
            try
            {
                _efCoreContext.Entry(entity).State = EntityState.Added;
                int rowsAffected = _efCoreContext.SaveChanges();
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
        public bool BatchAdd(T[] entities)
        {
            try
            {
                _efCoreContext.Set<T>().AddRange(entities);
                int rowsAffected = _efCoreContext.SaveChanges();
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
        public bool Update(T entity)
        {
            try
            {
                _efCoreContext.Set<T>().Attach(entity);
                _efCoreContext.Entry(entity).State = EntityState.Modified;
                int rowsAffected = _efCoreContext.SaveChanges();
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
        public bool Update(Expression<Func<T, bool>> where, Expression<Func<T, T>> entity)
        {
            try
            {
                _efCoreContext.Set<T>().Where<T>(where).Update(entity);
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
        public T GetEntiyByID(Guid id)
        {
            try
            {
                Expression<Func<T, bool>> where = x => x.GenericModifyID.Equals(id);
                var modelList = _efCoreContext.Set<T>().Where<T>(where).AsQueryable().ToList();
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
        public T GetEntityByWhere(Expression<Func<T, bool>> expression)
        {
            return _efCoreContext.Set<T>().FirstOrDefault(expression);
        }
        /// <summary>
        /// 根据ID删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(Guid id)
        {
            var model = GetEntiyByID(id);
            if (model != null)
            {
                try
                {
                    _efCoreContext.Set<T>().Attach(model);
                    _efCoreContext.Entry(model).State = EntityState.Deleted;
                    int rowsAffected = _efCoreContext.SaveChanges();
                    return rowsAffected > 0 ? true : false;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Delete(T entity)
        {
            try
            {
                _efCoreContext.Set<T>().Remove(entity);
                int rowsAffected = _efCoreContext.SaveChanges();
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
        public bool Delete(Expression<Func<T, bool>> expression)
        {
            try
            {
                _efCoreContext.Set<T>().Where<T>(expression).Delete();
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
        public bool IsExist(Expression<Func<T, bool>> expression)
        {
            return _efCoreContext.Set<T>().Any(expression);
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="orderColumn">排序字段</param>
        /// <param name="expression">查询条件</param>
        /// <param name="orderBy">排序方式</param>
        /// <returns></returns>
        public List<T> GetList(string orderColumn, Expression<Func<T, bool>> expression = null, OrderBySort orderBySort = OrderBySort.Desc)
        {
            try
            {
                IQueryable<T> quary;
                if (expression == null)
                {
                    quary = _efCoreContext.Set<T>().AsNoTracking().AsQueryable();
                }
                else
                {
                    quary = _efCoreContext.Set<T>().AsNoTracking().AsQueryable().Where(expression);
                }
                return orderBySort == OrderBySort.Desc ? quary.OrderByDescending(orderColumn).ToList() : quary.OrderBy(orderColumn).ToList();
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
        public List<T> GetPageList(Expression<Func<T, bool>> expression, int pageSize, int pageIndex, out int totalCount, string orderColumn, OrderBySort orderBySort = OrderBySort.Desc)
        {
            try
            {
                if (pageIndex < 1)
                {
                    pageIndex = 1;
                }
                int skipCount = (pageIndex - 1) * pageSize;
                totalCount = _efCoreContext.Set<T>().Where<T>(expression).Count();
                IQueryable<T> quary = _efCoreContext.Set<T>().AsNoTracking().AsQueryable().Where(expression);
                return orderBySort == OrderBySort.Desc ? quary.OrderByDescending(orderColumn).Skip(skipCount).Take(pageSize).ToList() : quary.OrderBy(orderColumn).Skip(skipCount).Take(pageSize).ToList();
            }
            catch (Exception ex)
            {
                totalCount = 0;
                return null;
            }
        }
    }
}
