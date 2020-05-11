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

        public virtual DbSet<AccountInfo> MtsAccountInfos { get; set; }
        public virtual DbSet<MenuInfo> MtsMenuInfos { get; set; }
        public virtual DbSet<ScheduleWorkOrderInfo> MtsScheduleWorkOrders { get; set; }
        public virtual DbSet<SoftwareInfo> MtsSoftwareInfos { get; set; }
        public virtual DbSet<PermissionGroup> MtsPermissionGroups { get; set; }
        public virtual DbSet<UserGroupMapping> MtsUserGroupMappings { get; set; }
        public virtual DbSet<GroupPermissionMapping> MtsGroupPermissionMappings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AccountInfoMap());
            modelBuilder.Configurations.Add(new MenuInfoMap());
            modelBuilder.Configurations.Add(new ScheduleWorkOrderMap());
            modelBuilder.Configurations.Add(new SoftwareInfoMap());
            modelBuilder.Configurations.Add(new PermissionGroupMap());
            modelBuilder.Configurations.Add(new UserGroupMappingMap());
            modelBuilder.Configurations.Add(new MtsGroupPermissionMappingMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
