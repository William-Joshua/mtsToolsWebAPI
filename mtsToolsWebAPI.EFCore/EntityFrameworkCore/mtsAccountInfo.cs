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
        public string UserID { get; set; } // 账号，工号
        [StringLength(256)]
        public string PassWord { get; set; } //密码
        [StringLength(2048)]
        public string Fingerprint { get; set; } //指纹密码，预留
        [StringLength(32)]
        public string UserName { get; set; } // 姓名
        public System.DateTime? Birthday { get; set; } // 生日
        [StringLength(20)]
        public string Telephone { get; set; } // 联系电话
        [StringLength(32)]
        public string Email { get; set; } // 邮箱，用于部分模块的通知功能
        public System.DateTime? EntryTime { get; set; } // 入职时间
        [Required]
        [StringLength(5)]
        public string IsService { get; set; } // 是否在职 0NU // 1SV
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
