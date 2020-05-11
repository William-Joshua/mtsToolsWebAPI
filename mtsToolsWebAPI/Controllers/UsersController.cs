using mtsToolsWebAPI.Common;
using mtsToolsWebAPI.EFCore.EntityFrameworkCore;
using mtsToolsWebAPI.Model;
using mtsToolsWebAPI.Repositories;
using mtsToolsWebAPI.Services;
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
        private readonly IGenericRepository<AccountInfo> _userDetailRepository;
        /// <summary>
        /// 用户管理 --- 构造
        /// </summary>
        /// <param name="userDetailRepository"></param>
        public UsersController(IGenericRepository<AccountInfo> userDetailRepository)
        {
            _userDetailRepository = userDetailRepository;
        }
       
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="userAccount">用户账号</param>
        /// <returns></returns>
        [HttpPost]
        public bool VerifyUserAccount([FromBody] UserAccount userAccount )
        {
            try
            {
                AccountInfo mtsAccountInfo = new AccountInfo();
                mtsAccountInfo.UserID = userAccount.Account;
                PassWordHelper passWordHelper = new PassWordHelper(userAccount.PassWord);
                mtsAccountInfo.PassWord = passWordHelper.CrtPassWord();
                ServiceResponse serviceResponse =null;
                List<AccountInfo> mtsAccountInfos = serviceResponse.Results as List<AccountInfo>;
                bool isVaildUser = mtsAccountInfos.Where(user => user.UserID == mtsAccountInfo.UserID && user.PassWord == mtsAccountInfo.PassWord&& user.IsService == "1SV").Count() == 1 ? true : false;
                return isVaildUser;
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
        public WebAPIReponseResult GetUserDetailByUserID([FromBody] UserAccount userAccount)
        {
            try
            {
                AccountInfo mtsAccountInfo = new AccountInfo
                {
                    UserID = userAccount.Account
                };
                ServiceResponse serviceResponse = null;
                List<AccountInfo> mtsAccountInfos = serviceResponse.Results as List<AccountInfo>;

                mtsAccountInfo =mtsAccountInfos.Where(user => user.UserID == mtsAccountInfo.UserID).FirstOrDefault();
                return new WebAPIReponseResult(HttpStatusCode.OK,"OK",JsonConvert.DeserializeObject<Dictionary<string,dynamic>>(JsonConvert.SerializeObject(mtsAccountInfo))) ;
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
        /// <summary>
        /// 根据用户与平台获取菜单
        /// </summary>
        /// <param name="userAccessRequest">用户与平台</param>
        /// <returns></returns>
        [HttpPost]
        public List<UserMenuItem> GetUserMenuTree([FromBody] UserAccessRequest userAccessRequest)
        {
            List<UserMenuItem> userMenuTree = new List<UserMenuItem>();
            UserService userService = new UserService();
            userMenuTree = userService.GetUserMenuTree(userAccessRequest);
            return userMenuTree;
        }

    }
}