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
        public string InnerScheduleID { get; set; }
        [Required]
        [StringLength(32)]
        public string ScheduleWorkOrderID { get; set; }
        [Required]
        [StringLength(32)]
        public string DeviceModelInnerID { get; set; }
        [Required]
        [StringLength(16)]
        public string ProductDeviceVersion { get; set; }
        [Required]
        public Decimal WorkOrderAmount { get; set; }
        [Required]
        [StringLength(64)]
        public string InnerUserID { get; set; }
        [Required]
        public DateTime? CrtWordOrderDate { get; set; } 

        [MaxLength]
        public string WorkOrderRemark { get; set; }
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
