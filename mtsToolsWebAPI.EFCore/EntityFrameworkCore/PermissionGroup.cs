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
    /// 组权限登记表
    /// </summary>
    [Table("MtsPermissionGroup")]
    public class PermissionGroup
    {
        [Key]
        [StringLength(64)]
        public string InnerGroupID { get; set; } // GUID 组号
        [Required]
        [StringLength(32)]
        public string GroupName { get; set; } // 组名
        [Required]
        [StringLength(8)]
        public string GroupAlias { get; set; } // EN
        [Required]
        [StringLength(5)]
        public string IsVaild { get; set; } // 是否有效 0NU // 1EN
    }
    public class PermissionGroupMap : EntityTypeConfiguration<PermissionGroup>
    {
        public PermissionGroupMap()
        {
            ToTable("MtsPermissionGroup");
            Property(m => m.InnerGroupID)
                .IsRequired();
        }
    }
}
