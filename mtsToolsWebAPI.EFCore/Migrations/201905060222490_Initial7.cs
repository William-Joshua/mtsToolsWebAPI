namespace mtsToolsWebAPI.EFCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial7 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MtsPermissionGroup",
                c => new
                    {
                        GroupID = c.String(nullable: false, maxLength: 64),
                        GroupName = c.String(nullable: false, maxLength: 32),
                        GroupAlias = c.String(nullable: false, maxLength: 8),
                        IsVaild = c.String(nullable: false, maxLength: 5),
                    })
                .PrimaryKey(t => t.GroupID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MtsPermissionGroup");
        }
    }
}
