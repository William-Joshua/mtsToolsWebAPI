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
    public class MtsMenuInfo
    {
        [Key]
        [StringLength(8)]
        public string MenuID { get; set; }
        [Required]
        [StringLength(32)]
        public string MenuName { get; set; }
        [StringLength(64)]
        public string MenuTitle { get; set; }
        [StringLength(8)]
        public string MenuParentID { get; set; }
        [StringLength(32)]
        public string MenuGroup { get; set; }
        [Required]
        [StringLength(1024)]
        public string MenuComponent { get; set; }
        [StringLength(64)]
        public string MenuIcon { get; set; }
    }

    public class MtsMenuInfoMap : EntityTypeConfiguration<MtsMenuInfo>
    {
        public MtsMenuInfoMap()
        {
            ToTable("MtsMenuInfo");
            Property(m => m.MenuID)
                .IsRequired();
        }
    }
}
