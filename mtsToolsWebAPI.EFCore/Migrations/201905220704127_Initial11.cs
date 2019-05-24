namespace mtsToolsWebAPI.EFCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial11 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MtsAccountInfo", "MtsPermissionGroup_InnerGroupID", "dbo.MtsPermissionGroup");
            DropIndex("dbo.MtsAccountInfo", new[] { "MtsPermissionGroup_InnerGroupID" });
            DropColumn("dbo.MtsAccountInfo", "MtsPermissionGroup_InnerGroupID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MtsAccountInfo", "MtsPermissionGroup_InnerGroupID", c => c.String(nullable: false, maxLength: 64));
            CreateIndex("dbo.MtsAccountInfo", "MtsPermissionGroup_InnerGroupID");
            AddForeignKey("dbo.MtsAccountInfo", "MtsPermissionGroup_InnerGroupID", "dbo.MtsPermissionGroup", "InnerGroupID", cascadeDelete: true);
        }
    }
}
