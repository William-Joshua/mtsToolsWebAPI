using mtsToolsWebAPI.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mtsToolsWebAPI.EFCore.EntityFrameworkCore
{
    /// <summary>
    /// 功能菜单信息
    /// </summary>
    [Table("MtsMenuInfo")]
    public class MenuInfo : GenericModel
    {
        [Key]
        [StringLength(64)]
        public string InnerMenuID { get; set; } // 菜单ID
        [Required]
        [StringLength(32)]
        public string MenuName { get; set; } // 显示菜单名 -- EN
        [Required]
        [StringLength(8)]
        public string SoftwareAlias { get; set; } // 所属软件
        [StringLength(64)]
        public string MenuTitle { get; set; } // 默认显示菜单名称 通常保存中文
        [StringLength(64)]
        public string MenuParentID { get; set; } // 菜单父级ID
        [StringLength(32)]
        public string MenuGroup { get; set; } // 菜单组别
        public int? MenuWeight { get; set; } // 菜单权重，用于排序，父类标签权重默认为0 最高，其他无权重，则按时间排序
        [StringLength(1024)]
        public string MenuComponent { get; set; } // 菜单对应成员, web -> URL /  winform -> componentID
        public bool EnableMasterTemplate { get; set; } // 菜单启用主模板
        public bool SubItemContainer { get; set; } // 包含子菜单
        [StringLength(200)]
        public string MenuIcon { get; set; } // 图标名称
        public DateTime? MenuCreateDate { get; set; } // 菜单创建时间
        [Required]
        [StringLength(5)]
        public string IsMenuVaild { get; set; } // 是否有效 0NU // 1EN
    }

    public class MenuInfoMap : EntityTypeConfiguration<MenuInfo>
    {
        public MenuInfoMap()
        {
            ToTable("MtsMenuInfo");
            Property(m => m.InnerMenuID)
                .IsRequired();
        }
    }
}
