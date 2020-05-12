namespace mtsToolsWebAPI.EFCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addGenericModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MtsAccountInfo", "GenericModifyID", c => c.String());
            AddColumn("dbo.MtsAccountInfo", "GenericModifyUser", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.MtsAccountInfo", "GenericModifyTimestamp", c => c.DateTime(nullable: false));
            AddColumn("dbo.MtsGroupPermissionMapping", "GenericModifyID", c => c.String());
            AddColumn("dbo.MtsGroupPermissionMapping", "GenericModifyUser", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.MtsGroupPermissionMapping", "GenericModifyTimestamp", c => c.DateTime(nullable: false));
            AddColumn("dbo.MtsMenuInfo", "GenericModifyID", c => c.String());
            AddColumn("dbo.MtsMenuInfo", "GenericModifyUser", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.MtsMenuInfo", "GenericModifyTimestamp", c => c.DateTime(nullable: false));
            AddColumn("dbo.MtsPermissionGroup", "GenericModifyID", c => c.String());
            AddColumn("dbo.MtsPermissionGroup", "GenericModifyUser", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.MtsPermissionGroup", "GenericModifyTimestamp", c => c.DateTime(nullable: false));
            AddColumn("dbo.MtsScheduleWorkOrder", "GenericModifyID", c => c.String());
            AddColumn("dbo.MtsScheduleWorkOrder", "GenericModifyUser", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.MtsScheduleWorkOrder", "GenericModifyTimestamp", c => c.DateTime(nullable: false));
            AddColumn("dbo.MtsSoftwareInfo", "GenericModifyID", c => c.String());
            AddColumn("dbo.MtsSoftwareInfo", "GenericModifyUser", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.MtsSoftwareInfo", "GenericModifyTimestamp", c => c.DateTime(nullable: false));
            AddColumn("dbo.MtsUserGroupMapping", "GenericModifyID", c => c.String());
            AddColumn("dbo.MtsUserGroupMapping", "GenericModifyUser", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.MtsUserGroupMapping", "GenericModifyTimestamp", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MtsUserGroupMapping", "GenericModifyTimestamp");
            DropColumn("dbo.MtsUserGroupMapping", "GenericModifyUser");
            DropColumn("dbo.MtsUserGroupMapping", "GenericModifyID");
            DropColumn("dbo.MtsSoftwareInfo", "GenericModifyTimestamp");
            DropColumn("dbo.MtsSoftwareInfo", "GenericModifyUser");
            DropColumn("dbo.MtsSoftwareInfo", "GenericModifyID");
            DropColumn("dbo.MtsScheduleWorkOrder", "GenericModifyTimestamp");
            DropColumn("dbo.MtsScheduleWorkOrder", "GenericModifyUser");
            DropColumn("dbo.MtsScheduleWorkOrder", "GenericModifyID");
            DropColumn("dbo.MtsPermissionGroup", "GenericModifyTimestamp");
            DropColumn("dbo.MtsPermissionGroup", "GenericModifyUser");
            DropColumn("dbo.MtsPermissionGroup", "GenericModifyID");
            DropColumn("dbo.MtsMenuInfo", "GenericModifyTimestamp");
            DropColumn("dbo.MtsMenuInfo", "GenericModifyUser");
            DropColumn("dbo.MtsMenuInfo", "GenericModifyID");
            DropColumn("dbo.MtsGroupPermissionMapping", "GenericModifyTimestamp");
            DropColumn("dbo.MtsGroupPermissionMapping", "GenericModifyUser");
            DropColumn("dbo.MtsGroupPermissionMapping", "GenericModifyID");
            DropColumn("dbo.MtsAccountInfo", "GenericModifyTimestamp");
            DropColumn("dbo.MtsAccountInfo", "GenericModifyUser");
            DropColumn("dbo.MtsAccountInfo", "GenericModifyID");
        }
    }
}
