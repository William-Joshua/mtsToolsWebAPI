using mtsToolsWebAPI.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace mtsToolsWebAPI.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Add(T entity);
        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        bool BatchAdd(T[] entities);
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Update(T entity);
        /// <summary>
        /// 根据条件更新
        /// </summary>
        /// <param name="where"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Update(Expression<Func<T, bool>> where, Expression<Func<T, T>> entity);
        /// <summary>
        /// 根据ID获取单个数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetEntiyByID(Guid id);
        /// <summary>
        /// 根据查询条件获取单个数据
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        T GetEntityByWhere(Expression<Func<T, bool>> expression);
        /// <summary>
        /// 根据ID删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(Guid id);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Delete(T entity);
        /// <summary>
        /// 根据条件删除数据
        /// </summary>
        /// <param name="expression"></param>
        bool Delete(Expression<Func<T, bool>> expression);
        /// <summary>
        /// 判断数据是否存在
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        bool IsExist(Expression<Func<T, bool>> expression);
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="orderColumn">排序字段</param>
        /// <param name="expression">查询条件</param>
        /// <param name="orderBy">排序方式</param>
        /// <returns></returns>
        List<T> GetList(string orderColumn, Expression<Func<T, bool>> expression = null, OrderBySort orderBySort = OrderBySort.Desc);
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
        List<T> GetPageList(Expression<Func<T, bool>> expression, int pageSize, int pageIndex, out int totalCount, string orderColumn, OrderBySort orderBySort = OrderBySort.Desc);
    }
}
