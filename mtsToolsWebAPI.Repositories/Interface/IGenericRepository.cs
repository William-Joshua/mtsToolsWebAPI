using mtsToolsWebAPI.Common;
using mtsToolsWebAPI.EFCore.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mtsToolsWebAPI.Repositories
{
    public interface IGenericRepository<T> where T : class,new()
    {
        IQueryable<T> GetAll();

        ServiceResponse GetModelQuery(T queryCondition);

        Task<ServiceResponse> DeleteEntity(T entity);

        Task<ServiceResponse> UpdateEntity(T entity);

        Task<ServiceResponse> AddEntity(T entity);

        Task<ServiceResponse> ExistEntity(T queryCondition);
    }
}
