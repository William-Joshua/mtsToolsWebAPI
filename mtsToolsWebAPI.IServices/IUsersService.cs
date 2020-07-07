using mtsToolsWebAPI.EFCore.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mtsToolsWebAPI.IServices
{
    public interface IUsersService
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="loginAccount">登录名</param>
        /// <param name="password">登录密码</param>
        /// <returns></returns>
        AccountInfo Login(string loginAccount, string password);
    }
}
