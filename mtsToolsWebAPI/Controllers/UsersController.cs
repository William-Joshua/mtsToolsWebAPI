using mtsToolsWebAPI.ActionFilters;
using mtsToolsWebAPI.Common;
using mtsToolsWebAPI.Common.Security;
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
                
                // 校验密码，生成 Token
                JwtAuthUtil jwtAuthUtil = new JwtAuthUtil();
                string jwtToken = jwtAuthUtil.GenerateToken();

                return new WebAPIReponse(HttpStatusCode.OK, "OK", jwtToken);

            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 根据用户ID获取用户详细信息
        /// </summary>
        /// <param name="userAccount">用户ID</param>
        /// <returns></returns>
        [HttpPost]
        [JwtAuthFilter]
        public WebAPIReponse GetUserDetailByUserID([FromBody] UserAccountRequest userAccount)
        {
            try
            {
                AccountInfo mtsAccountInfo = new AccountInfo
                {
                    UserID = userAccount.LoginAccount
                };
                ServiceResponse serviceResponse = null;
                List<AccountInfo> mtsAccountInfos = serviceResponse.Results as List<AccountInfo>;

                mtsAccountInfo =mtsAccountInfos.Where(user => user.UserID == mtsAccountInfo.UserID).FirstOrDefault();
                return new WebAPIReponse(HttpStatusCode.OK,"OK",JsonConvert.DeserializeObject<Dictionary<string,dynamic>>(JsonConvert.SerializeObject(mtsAccountInfo))) ;
            }
            catch(HttpResponseException)
            {
                throw;
            }
            catch (Exception exception)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError) { Content = new StringContent(exception.Message) });
            }
        }

    }
}