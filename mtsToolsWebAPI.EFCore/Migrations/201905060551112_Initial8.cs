namespace mtsToolsWebAPI.EFCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial8 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.MtsMenuInfo");
            DropPrimaryKey("dbo.MtsPermissionGroup");
            CreateTable(
                "dbo.MtsGroupPermissionMapping",
                c => new
                    {
                        InnerUniqueID = c.String(nullable: false, maxLength: 64),
                        InnerGroupID = c.String(nullable: false, maxLength: 64),
                        InnerMenuID = c.String(nullable: false, maxLength: 64),
                        IsMapVaild = c.String(nullable: false, maxLength: 5),
                    })
                .PrimaryKey(t => t.InnerUniqueID);
            
            CreateTable(
                "dbo.MtsUserGroupMapping",
                c => new
                    {
                        InnerUniqueID = c.String(nullable: false, maxLength: 64),
                        InnerUserID = c.String(maxLength: 64),
                        GroupID = c.String(maxLength: 64),
                        IsMapVaild = c.String(nullable: false, maxLength: 5),
                    })
                .PrimaryKey(t => t.InnerUniqueID);
            
            AddColumn("dbo.MtsAccountInfo", "MtsPermissionGroup_InnerGroupID", c => c.String(nullable: false, maxLength: 64));
            AddColumn("dbo.MtsMenuInfo", "InnerMenuID", c => c.String(nullable: false, maxLength: 64));
            AddColumn("dbo.MtsPermissionGroup", "InnerGroupID", c => c.String(nullable: false, maxLength: 64));
            AddPrimaryKey("dbo.MtsMenuInfo", "InnerMenuID");
            AddPrimaryKey("dbo.MtsPermissionGroup", "InnerGroupID");
            CreateIndex("dbo.MtsAccountInfo", "MtsPermissionGroup_InnerGroupID");
            AddForeignKey("dbo.MtsAccountInfo", "MtsPermissionGroup_InnerGroupID", "dbo.MtsPermissionGroup", "InnerGroupID", cascadeDelete: true);
            DropColumn("dbo.MtsMenuInfo", "MenuID");
            DropColumn("dbo.MtsPermissionGroup", "GroupID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MtsPermissionGroup", "GroupID", c => c.String(nullable: false, maxLength: 64));
            AddColumn("dbo.MtsMenuInfo", "MenuID", c => c.String(nullable: false, maxLength: 8));
            DropForeignKey("dbo.MtsAccountInfo", "MtsPermissionGroup_InnerGroupID", "dbo.MtsPermissionGroup");
            DropIndex("dbo.MtsAccountInfo", new[] { "MtsPermissionGroup_InnerGroupID" });
            DropPrimaryKey("dbo.MtsPermissionGroup");
            DropPrimaryKey("dbo.MtsMenuInfo");
            DropColumn("dbo.MtsPermissionGroup", "InnerGroupID");
            DropColumn("dbo.MtsMenuInfo", "InnerMenuID");
            DropColumn("dbo.MtsAccountInfo", "MtsPermissionGroup_InnerGroupID");
            DropTable("dbo.MtsUserGroupMapping");
            DropTable("dbo.MtsGroupPermissionMapping");
            AddPrimaryKey("dbo.MtsPermissionGroup", "GroupID");
            AddPrimaryKey("dbo.MtsMenuInfo", "MenuID");
        }
    }
}
