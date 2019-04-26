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

        public virtual DbSet<MtsAccountInfo> mtsAccountInfos { get; set; }
        public virtual DbSet<MtsMenuInfo> MtsMenuInfos { get; set; }
        public virtual DbSet<MtsScheduleWorkOrder> MtsScheduleWorkOrders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MtsAccountInfoMap());
            modelBuilder.Configurations.Add(new MtsMenuInfoMap());
            modelBuilder.Configurations.Add(new MtsScheduleWorkOrderMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
