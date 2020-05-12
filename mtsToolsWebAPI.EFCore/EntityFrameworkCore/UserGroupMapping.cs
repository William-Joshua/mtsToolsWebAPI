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
    /// 用户与用户组映射关系
    /// </summary>
    [Table("MtsUserGroupMapping")]
    public class UserGroupMapping : GenericModel
    {
        [Key]
        [StringLength(64)]
        public string InnerUniqueID { get; set; }// 唯一
        [StringLength(64)]
        public string InnerUserID { get; set; } // GUID
        [StringLength(64)]
        public string GroupID { get; set; } // 组名
        [Required]
        [StringLength(5)]
        public string IsMapVaild { get; set; } // 是否有效 0NU // 1EN
    }

    public class UserGroupMappingMap : EntityTypeConfiguration<UserGroupMapping>
    {
        public UserGroupMappingMap()
        {
            ToTable("MtsUserGroupMapping");
            Property(m => m.InnerUniqueID)
                .IsRequired();
        }
    }
}
