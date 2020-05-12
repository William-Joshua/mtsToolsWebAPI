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
    /// 软件基本信息 -- 标志菜单分属哪个应用
    /// </summary>
    [Table("MtsSoftwareInfo")]
    public class SoftwareInfo : GenericModel
    {
        [Key]
        [StringLength(64)]
        public string SoftwareID { get; set; } // 软件ID
        [StringLength(64)]
        public string SoftwareName { get; set; } // 软件名称
        [StringLength(8)]
        public string SoftwareAlias { get; set; } // 软件别名，程序内部信息交换时使用，最长不超过8位
        [StringLength(64)]
        public string SoftwareVersionGUID { get; set; } // 软件内部版本号 -- GUID
        [StringLength(32)]
        public string SoftwareVersion { get; set; } // 通用版本号，格式 Vxxxx.xxxx.xxxx 分3段，以大写 V 开头，每段最长4位（数字前不补0）
        [StringLength(1024)]
        public string SoftWareAddress { get; set; } // 软件地址, web 为 URL， 安装包为更新路径
        [StringLength(2048)]
        public string SoftWareDescription { get; set; }// 软件简述
    }

    public class SoftwareInfoMap : EntityTypeConfiguration<SoftwareInfo>
    {
        public SoftwareInfoMap()
        {
            ToTable("MtsSoftwareInfo");
            Property(m => m.SoftwareID)
                .IsRequired();
        }
    }
}
