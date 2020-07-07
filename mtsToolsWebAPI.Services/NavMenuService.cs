using mtsToolsWebAPI.EFCore.EntityFrameworkCore;
using mtsToolsWebAPI.IRepositories;
using mtsToolsWebAPI.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mtsToolsWebAPI.Services
{
    public class NavMenuService : GenericService<AccountInfo>, INavMenuService
    {
        public NavMenuService(ITransactionWork transactionWork, IGenericRepository<AccountInfo> genericRepository) : base(transactionWork, genericRepository)
        {
        }
    }
}
