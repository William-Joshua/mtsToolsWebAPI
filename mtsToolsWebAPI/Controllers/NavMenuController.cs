using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using mtsToolsWebAPI.IServices;
using mtsToolsWebAPI.Model;

namespace mtsToolsWebAPI.Controllers
{
    /// <summary>
    /// 菜单管理
    /// </summary>
    public class NavMenuController : ApiController
    {
        private readonly INavMenuService _navMenuService;
        /// <summary>
        /// 菜单管理 --- 构造
        /// </summary>
        /// <param name="navMenuService"></param>
        public NavMenuController(INavMenuService navMenuService)
        {
            _navMenuService = navMenuService ;
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="userAccount">用户账号</param>
        /// <returns></returns>
        [HttpPost]
        public WebAPIReponse Post( UserAccountRequest userAccount)
        {
            try
            {
                return new WebAPIReponse(HttpStatusCode.OK, "OK", "");

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
