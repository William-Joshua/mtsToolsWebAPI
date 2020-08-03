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
    public class NavMenuService : GenericService<MenuInfo>, INavMenuService
    {
        public NavMenuService(ITransactionWork transactionWork, IGenericRepository<MenuInfo> genericRepository) : base(transactionWork, genericRepository)
        {
        }
        /// <summary>
        /// 获取用户权限菜单目录
        /// </summary>
        /// <param name="userNavMenu"></param>
        /// <returns></returns>
        public List<MenuInfo> GetUserPermissionMenus(UserNavMenuRequest userNavMenu)
        {
            try
            {
                return genericRepository.GetList("MenuWeight", x => x.IsMenuVaild.Equals("1EN"));
            }
            catch (Exception exception)
            {

                throw exception;
            }
        }
        #region 转换并生成菜单树
        /// <summary>
        /// 生成导航菜单树状结构，转换菜单为导航菜单元素
        /// </summary>
        /// <param name="menuInfos"></param>
        /// <returns></returns>
        public NavMenuBar GenerateNavMenuTree(List<MenuInfo> menuInfos)
        {
           
            try
            {
                NavMenuBar navMenuBar = new NavMenuBar();
                // 抓取root 节点
                foreach (MenuInfo menuInfo in menuInfos.Where(menu => menu.MenuParentID.ToLower().Equals("root")).OrderBy(menu => menu.MenuWeight))
                {
                    bool parentMenuExpand = false;
                    NavMenuItem navMenuItem = new NavMenuItem
                    {
                        Name = menuInfo.MenuName,
                        Title = menuInfo.MenuTitle,
                        IconType = menuInfo.MenuIcon,
                        Url = menuInfo.MenuComponent,
                        Master = menuInfo.EnableMasterTemplate,
                        Submenu = GenerateSubNavMenus(menuInfo, menuInfos, out parentMenuExpand),
                        SubArrow = parentMenuExpand
                    };
                    navMenuBar.Menu.Add(navMenuItem);
                }
                return navMenuBar;
            }
            catch (Exception exception)
            {

                throw exception; 
            }
           
        }
        /// <summary>
        /// 转换菜单为导航菜单子菜单成员
        /// </summary>
        /// <param name="parentMenuInfo"></param>
        /// <param name="menuInfos"></param>
        /// <param name="parentMenuExpand"></param>
        /// <returns></returns>
        private List<NavSubMenuItem> GenerateSubNavMenus(MenuInfo parentMenuInfo, List<MenuInfo> menuInfos, out bool parentMenuExpand)
        {
            try
            {
                // 判断是否还有子节点
                var subMenuCounter = menuInfos.Where(menu => menu.MenuParentID.Equals(parentMenuInfo.InnerMenuID)).FirstOrDefault();
                if (subMenuCounter != null)
                {
                    List<NavSubMenuItem> navSubMenuItems = new List<NavSubMenuItem>();
                    foreach (MenuInfo menuInfo in menuInfos.Where(menu => menu.MenuParentID.Equals(parentMenuInfo.InnerMenuID)).OrderBy(menu => menu.MenuWeight))
                    {
                        NavSubMenuItem navSubMenuItem = new NavSubMenuItem
                        {
                            Name = menuInfo.MenuName,
                            Title = menuInfo.MenuTitle,
                            Master = menuInfo.EnableMasterTemplate,
                            Url = menuInfo.MenuComponent
                        };
                        navSubMenuItems.Add(navSubMenuItem);
                    }

                    parentMenuExpand = true;
                    return navSubMenuItems;
                }

                parentMenuExpand = false;
                return null;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            
        }
        #endregion

    }
}
