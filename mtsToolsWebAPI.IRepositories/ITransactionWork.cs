using mtsToolsWebAPI.Common;
using mtsToolsWebAPI.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace mtsToolsWebAPI.IRepositories
{    /// <summary>
     /// 数据库事务操作方法
     /// </summary>
    public interface ITransactionWork
    {/// <summary>
     /// 新增
     /// </summary>
     /// <param name="entity"></param>
     /// <returns></returns>
        bool Add<T>(T entity) where T : GenericModel;
        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        bool BatchAdd<T>(T[] entities) where T : GenericModel;
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Update<T>(T entity) where T : class;
        /// <summary>
        /// 根据条件更新数据
        /// <para>如：Update(u =>u.Id==1,u =>new User{Name="ok"});</para>
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="entity">The entity.</param>
        bool Update<T>(Expression<Func<T, bool>> where, Expression<Func<T, T>> entity) where T : class;
        /// <summary>
        /// 根据ID获取单个数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetEntiyByID<T>(Guid id) where T : GenericModel;
        /// <summary>
        /// 根据查询条件获取单个数据
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        T GetEntityByWhere<T>(Expression<Func<T, bool>> expression) where T : class;
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Delete<T>(T entity) where T : class;
        /// <summary>
        /// 根据条件删除数据
        /// </summary>
        /// <param name="expression"></param>
        bool Delete<T>(Expression<Func<T, bool>> expression) where T : class;
        /// <summary>
        /// 判断数据是否存在
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        bool IsExist<T>(Expression<Func<T, bool>> expression) where T : class;
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="orderColumn">排序字段</param>
        /// <param name="expression">查询条件</param>
        /// <param name="orderBy">排序方式</param>
        /// <returns></returns>
        List<T> GetList<T>(string orderColumn, Expression<Func<T, bool>> expression = null, OrderBySort orderBySort = OrderBySort.Desc) where T : class;
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
        List<T> GetPageList<T>(Expression<Func<T, bool>> expression, int pageSize, int pageIndex, out int totalCount, string orderColumn, OrderBySort orderBySort = OrderBySort.Desc) where T : class;
    }
}
