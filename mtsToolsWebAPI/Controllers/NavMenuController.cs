using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using mtsToolsWebAPI.ActionFilters;
using mtsToolsWebAPI.EFCore.EntityFrameworkCore;
using mtsToolsWebAPI.IServices;
using mtsToolsWebAPI.Model;
using Newtonsoft.Json;

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
        [JwtAuthFilter]
        public WebAPIReponse GenNavMenuTree(UserNavMenuRequest userNavMenu)
        {
            try
            {
                MenuInfo mtsMenuInfo = new MenuInfo();

                var userNavMenuInfo = _navMenuService.GetUserPermissionMenus(userNavMenu);
                if (userNavMenuInfo != null)
                {
                    NavMenuBar currNavMenuBar = _navMenuService.GenerateNavMenuTree(userNavMenuInfo);
                    return new WebAPIReponse(HttpStatusCode.OK, "Success", currNavMenuBar);
                }
                return new WebAPIReponse(HttpStatusCode.InternalServerError, "Menu Not Found");
            }
            catch (Exception exception)
            {

                return new WebAPIReponse(HttpStatusCode.PreconditionFailed, "Precondition Failed", exception.ToString());
            }
        }
    }
}
