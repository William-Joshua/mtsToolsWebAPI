namespace mtsToolsWebAPI.EFCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MtsScheduleWorkOrder",
                c => new
                    {
                        InnerScheduleID = c.String(nullable: false, maxLength: 64),
                        ScheduleWorkOrderID = c.String(nullable: false, maxLength: 32),
                        DeviceModelInnerID = c.String(nullable: false, maxLength: 32),
                        ProductDeviceVersion = c.String(nullable: false, maxLength: 16),
                        WorkOrderAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InnerUserID = c.String(nullable: false, maxLength: 64),
                        CrtWordOrderDate = c.DateTime(nullable: false),
                        WorkOrderRemark = c.String(),
                    })
                .PrimaryKey(t => t.InnerScheduleID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MtsScheduleWorkOrder");
        }
    }
}
