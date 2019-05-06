using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mtsToolsWebAPI.EFCore.EntityFrameworkCore
{
    public class EFCoreContext: DbContext
    {
        public EFCoreContext()
            : base("name=MtsToolsWebConnection")
        {
        }

        public virtual DbSet<MtsAccountInfo> MtsAccountInfos { get; set; }
        public virtual DbSet<MtsMenuInfo> MtsMenuInfos { get; set; }
        public virtual DbSet<MtsScheduleWorkOrder> MtsScheduleWorkOrders { get; set; }
        public virtual DbSet<MtsSoftwareInfo> MtsSoftwareInfos { get; set; }
        public virtual DbSet<MtsPermissionGroup> MtsPermissionGroups { get; set; }
        public virtual DbSet<MtsUserGroupMapping> MtsUserGroupMappings { get; set; }
        public virtual DbSet<MtsGroupPermissionMapping> MtsGroupPermissionMappings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MtsAccountInfoMap());
            modelBuilder.Configurations.Add(new MtsMenuInfoMap());
            modelBuilder.Configurations.Add(new MtsScheduleWorkOrderMap());
            modelBuilder.Configurations.Add(new MtsSoftwareInfoMap());
            modelBuilder.Configurations.Add(new MtsPermissionGroupMap());
            modelBuilder.Configurations.Add(new MtsUserGroupMappingMap());
            modelBuilder.Configurations.Add(new MtsGroupPermissionMappingMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
