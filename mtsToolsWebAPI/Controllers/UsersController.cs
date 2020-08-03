using mtsToolsWebAPI.ActionFilters;
using mtsToolsWebAPI.Common;
using mtsToolsWebAPI.EFCore.EntityFrameworkCore;
using mtsToolsWebAPI.Model;
using mtsToolsWebAPI.Repositories;
using mtsToolsWebAPI.Services;
using mtsToolsWebAPI.IServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace mtsToolsWebAPI.Controllers
{
    /// <summary>
    /// 用户管理中心
    /// </summary>
    public class UsersController : ApiController
    {
        private readonly IUsersService _usersService;
        /// <summary>
        /// 用户管理 --- 构造
        /// </summary>
        /// <param name="usersService"></param>
        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="userAccount">用户账号</param>
        /// <returns></returns>
        [HttpPost]
        public WebAPIReponse SignIn([FromBody] UserAccountRequest userAccount )
        {
            try
            {
                AccountInfo mtsAccountInfo = new AccountInfo();
                mtsAccountInfo.UserID = userAccount.LoginAccount;
                PassWordHelper passWordHelper = new PassWordHelper(userAccount.LoginPassword);
                mtsAccountInfo.PassWord = passWordHelper.CrtPassWord();
                var userInfo = _usersService.Login(mtsAccountInfo);
                if (userInfo != null)
                {
                    // 校验密码，生成 Token
                    JwtAuthUtil jwtAuthUtil = new JwtAuthUtil();
                    JwtAuthObject jwtAuthInfo = new JwtAuthObject
                    {
                        UserName  = userInfo.UserID,
                    };
                    switch (userAccount.LoginPlatform)
                    {
                        case SoftPlatform.mtsToolCaliburn:
                            jwtAuthInfo.ExpiryDateTime = DateTime.Now.AddHours(12).ToString(); break;
                        case SoftPlatform.mtsToolLoggerCenter:
                            jwtAuthInfo.ExpiryDateTime = DateTime.Now.AddHours(4).ToString(); break;
                        case SoftPlatform.mtsToolsSchedule:
                            jwtAuthInfo.ExpiryDateTime = DateTime.Now.AddMinutes(15).ToString(); break;
                        case SoftPlatform.mtsToolsStudio:
                            jwtAuthInfo.ExpiryDateTime = DateTime.Now.AddHours(4).ToString(); break;
                        default: jwtAuthInfo.ExpiryDateTime = DateTime.Now.AddMinutes(5).ToString(); break;
                    }
                    string jwtToken = jwtAuthUtil.GenerateToken(jwtAuthInfo);
                    return new WebAPIReponse(HttpStatusCode.OK, "OK", jwtToken);
                }
                return new WebAPIReponse(HttpStatusCode.NonAuthoritativeInformation, "Access Denied");

            }
            catch (Exception exception)
            {
                return new WebAPIReponse(HttpStatusCode.PreconditionFailed, "Precondition Failed", exception.ToString());
            }
        }
    }
}