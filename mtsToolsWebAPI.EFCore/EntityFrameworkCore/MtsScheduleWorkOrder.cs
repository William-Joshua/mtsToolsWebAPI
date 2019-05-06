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
    /// 排产计划工单
    /// </summary>
    [Table("MtsScheduleWorkOrder")]
    public class MtsScheduleWorkOrder
    {
        [Key]
        [StringLength(64)]
        public string InnerScheduleID { get; set; } // 内部计划单编号， GUID
        [Required]
        [StringLength(32)]
        public string ScheduleWorkOrderID { get; set; } // 计划单号
        [Required]
        [StringLength(32)]
        public string DeviceModelInnerID { get; set; } // 产品型号内部编码
        [Required]
        [StringLength(16)]
        public string ProductDeviceVersion { get; set; } // 生产设备版本
        [Required]
        public Decimal WorkOrderAmount { get; set; } // 工单数量
        [Required]
        [StringLength(64)]
        public string InnerUserID { get; set; } // 计划排产员内部员工编码
        [Required]
        public DateTime? CrtWorkOrderDate { get; set; } // 计划工单创建日期

        [MaxLength]
        public string WorkOrderRemark { get; set; } // 计划工单备注

        [Required]
        [StringLength(5)]
        public string IsScheduleVaild { get; set; } // 是否有效 0NU // 1EN
    }

    public class MtsScheduleWorkOrderMap : EntityTypeConfiguration<MtsScheduleWorkOrder>
    {
        public MtsScheduleWorkOrderMap()
        {
            ToTable("MtsScheduleWorkOrder");
            Property(m => m.InnerScheduleID)
                .IsRequired();
        }
    }
}
