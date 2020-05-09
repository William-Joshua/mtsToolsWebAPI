using mtsToolsWebAPI.EFCore.EntityFrameworkCore;
using mtsToolsWebAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mtsToolsWebAPI.Repositories
{
    public class UserRepository
    {
        private EFCoreContext efCoreContext = new EFCoreContext();
        /// <summary>
        /// 获得用户菜单树
        /// </summary>
        /// <param name="userAccessRequest"></param>
        /// <returns></returns>
        public List<UserMenuItem> GetUserMenuTree(UserAccessRequest userAccessRequest)
        {
            var menuInfoList = efCoreContext.MtsMenuInfos
                .Join(efCoreContext.MtsGroupPermissionMappings, mmi => mmi.InnerMenuID, mgpm => mgpm.InnerMenuID, (mmi, mgpm) => new { mmi, mgpm })
                .Where(menu => menu.mmi.IsMenuVaild == "1EN" && menu.mgpm.IsMapVaild == "1EN")
                .Join(efCoreContext.MtsPermissionGroups, mgpmMapping => mgpmMapping.mgpm.InnerGroupID, mpg => mpg.InnerGroupID, (mgpmMapping, mpg) => new { mgpmMapping, mpg })
                .Where(permission => permission.mpg.IsVaild == "1EN")
                .Join(efCoreContext.MtsUserGroupMappings, mgpMapping => mgpMapping.mgpmMapping.mgpm.InnerGroupID, mugm => mugm.GroupID, (mgpMapping, mugm) => new { mgpMapping, mugm })
                .Where(group => group.mugm.IsMapVaild == "1EN")
                .Join(efCoreContext.MtsAccountInfos, mugmMapping => mugmMapping.mugm.InnerUserID, mai => mai.InnerUserID, (mugmMapping, mai) => new { mugmMapping, mai })
                .Where(account => account.mai.IsService == "1SV").
                Select(
                menutree => new
                {
                    menutree.mai.InnerUserID,
                    menutree.mai.UserID,
                    menutree.mugmMapping.mgpMapping.mpg.InnerGroupID,
                    menutree.mugmMapping.mgpMapping.mpg.GroupName,
                    menutree.mugmMapping.mgpMapping.mpg.GroupAlias,
                    menutree.mugmMapping.mgpMapping.mgpmMapping.mmi.InnerMenuID,
                    menutree.mugmMapping.mgpMapping.mgpmMapping.mmi.MenuName,
                    menutree.mugmMapping.mgpMapping.mgpmMapping.mmi.MenuTitle,
                    menutree.mugmMapping.mgpMapping.mgpmMapping.mmi.MenuParentID,
                    menutree.mugmMapping.mgpMapping.mgpmMapping.mmi.MenuGroup,
                    menutree.mugmMapping.mgpMapping.mgpmMapping.mmi.MenuComponent,
                    menutree.mugmMapping.mgpMapping.mgpmMapping.mmi.MenuIcon,
                    menutree.mugmMapping.mgpMapping.mgpmMapping.mmi.SoftwareAlias,
                    menutree.mugmMapping.mgpMapping.mgpmMapping.mmi.MenuWeight
                }).ToList();

            var userMenuTree = menuInfoList
                .Where(menu => menu.UserID == userAccessRequest.UserID && menu.SoftwareAlias == userAccessRequest.SoftPlatform)
                .OrderBy(menu => menu.MenuGroup)
                .OrderBy(menu => menu.MenuWeight)
                .Select(tree => new
                {
                    MenuID = tree.InnerMenuID,
                    tree.MenuName,
                    tree.MenuTitle,
                    tree.MenuParentID,
                    tree.MenuGroup,
                    tree.MenuComponent,
                    tree.MenuIcon,
                    tree.MenuWeight
                }).ToList();
            List<UserMenuItem> userMenuItems = new List<UserMenuItem>();
            foreach (var menuitem in userMenuTree)
            {
                UserMenuItem userMenuItem = new UserMenuItem();
                userMenuItem.MenuID = menuitem.MenuID;
                userMenuItem.MenuName = menuitem.MenuName;
                userMenuItem.MenuTitle = menuitem.MenuTitle;
                userMenuItem.MenuParentID = menuitem.MenuParentID;
                userMenuItem.MenuGroup = menuitem.MenuGroup;
                userMenuItem.MenuComponent = menuitem.MenuComponent;
                userMenuItem.MenuIcon = menuitem.MenuIcon;
                userMenuItem.MenuWeight = menuitem.MenuWeight;
                userMenuItems.Add(userMenuItem);
            }
            return userMenuItems;

        }
    }
}
