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
    /// 
    /// </summary>
    [Table("MtsGroupPermissionMapping")]
    public class GroupPermissionMapping : GenericModel
    {
        [Key]
        [StringLength(64)]
        public string InnerUniqueID { get; set; }// 唯一
        [Required]
        [StringLength(64)]
        public string InnerGroupID { get; set; } // 组号
        [Required]
        [StringLength(64)]
        public string InnerMenuID { get; set; } // 菜单编号
        [Required]
        [StringLength(5)]
        public string IsMapVaild { get; set; } // 是否有效 0NU // 1EN
    }
    public class MtsGroupPermissionMappingMap : EntityTypeConfiguration<GroupPermissionMapping>
    {
        public MtsGroupPermissionMappingMap()
        {
            ToTable("MtsGroupPermissionMapping");
            Property(m => m.InnerUniqueID)
                .IsRequired();
        }
    }
}
