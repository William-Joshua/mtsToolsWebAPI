using mtsToolsWebAPI.EFCore.EntityFrameworkCore;
using mtsToolsWebAPI.IRepositories;
using mtsToolsWebAPI.IServices;
using mtsToolsWebAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mtsToolsWebAPI.Services
{
    public class UsersService : GenericService<AccountInfo>, IUsersService
    {
        public UsersService(ITransactionWork transactionWork, IGenericRepository<AccountInfo> genericRepository) : base(transactionWork, genericRepository)
        {
        }

        public AccountInfo Login(AccountInfo userAccount)
        {
            return genericRepository.GetEntityByWhere(x => x.UserID.Equals(userAccount.UserID) && x.PassWord.Equals(userAccount.PassWord));
        }
    }
}
