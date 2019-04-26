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
    /// 员工基本信息登记表
    /// </summary>
    [Table("MtsAccountInfo")]
    public class MtsAccountInfo
    {
        [Key]
        [StringLength(64)]
        public string InnerUserID { get; set; } // GUID
        [StringLength(16)]
        public string UserID { get; set; }
        [StringLength(32)]
        public string UserName { get; set; }
        public System.DateTime? Birthday { get; set; }
        [StringLength(20)]
        public string Telephone { get; set; }
        [StringLength(32)]
        public string Email { get; set; }
        public System.DateTime? EntryTime { get; set; }
        [Required]
        public int IsService { get; set; }
    }

    public class MtsAccountInfoMap: EntityTypeConfiguration<MtsAccountInfo>
    {
        public MtsAccountInfoMap()
        {
            ToTable("MtsAccountInfo");
            Property(m => m.InnerUserID)
                .IsRequired();
        }
    }
}
