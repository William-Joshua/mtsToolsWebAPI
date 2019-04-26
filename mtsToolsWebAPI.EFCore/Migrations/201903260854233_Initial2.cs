namespace mtsToolsWebAPI.EFCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MtsMenuInfo",
                c => new
                    {
                        MenuID = c.String(nullable: false, maxLength: 8),
                        MenuName = c.String(nullable: false, maxLength: 32),
                        MenuTitle = c.String(maxLength: 64),
                        MenuParentID = c.String(maxLength: 8),
                        MenuGroup = c.String(maxLength: 32),
                        MenuComponent = c.String(nullable: false, maxLength: 1024),
                        MenuIcon = c.String(maxLength: 64),
                    })
                .PrimaryKey(t => t.MenuID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MtsMenuInfo");
        }
    }
}
