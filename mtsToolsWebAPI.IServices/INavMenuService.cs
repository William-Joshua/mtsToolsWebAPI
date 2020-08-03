using mtsToolsWebAPI.EFCore.EntityFrameworkCore;
using mtsToolsWebAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mtsToolsWebAPI.IServices
{
    public interface INavMenuService
    {
        List<MenuInfo> GetUserPermissionMenus(UserNavMenuRequest userNavMenu);

        NavMenuBar GenerateNavMenuTree(List<MenuInfo> menuInfos);
    }
}
