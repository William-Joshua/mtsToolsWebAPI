namespace mtsToolsWebAPI.EFCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MtsAccountInfo", "PassWord", c => c.String(maxLength: 256));
            AddColumn("dbo.MtsAccountInfo", "Fingerprint", c => c.String(maxLength: 2048));
            AddColumn("dbo.MtsMenuInfo", "IsMenuVaild", c => c.String(nullable: false, maxLength: 5));
            AddColumn("dbo.MtsScheduleWorkOrder", "CrtWorkOrderDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.MtsScheduleWorkOrder", "IsScheduleVaild", c => c.String(nullable: false, maxLength: 5));
            AlterColumn("dbo.MtsAccountInfo", "IsService", c => c.String(nullable: false, maxLength: 5));
            DropColumn("dbo.MtsScheduleWorkOrder", "CrtWordOrderDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MtsScheduleWorkOrder", "CrtWordOrderDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.MtsAccountInfo", "IsService", c => c.Int(nullable: false));
            DropColumn("dbo.MtsScheduleWorkOrder", "IsScheduleVaild");
            DropColumn("dbo.MtsScheduleWorkOrder", "CrtWorkOrderDate");
            DropColumn("dbo.MtsMenuInfo", "IsMenuVaild");
            DropColumn("dbo.MtsAccountInfo", "Fingerprint");
            DropColumn("dbo.MtsAccountInfo", "PassWord");
        }
    }
}
