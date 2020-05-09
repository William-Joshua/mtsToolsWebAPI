using mtsToolsWebAPI.Common;
using mtsToolsWebAPI.Repositories;
using mtsToolsWebAPI.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mtsToolsWebAPI.Services
{
    public class GenericService<T> where T : GenericModel
    {
        protected ITransactionWork transactionWork;
        protected IGenericRepository<T> genericRepository;

        public GenericService(ITransactionWork _transactionWork, IGenericRepository<T> _genericRepository)
        {
            transactionWork = _transactionWork;
            genericRepository = _genericRepository;
        }
    }
}
