namespace mtsToolsWebAPI.EFCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class menuinfonotnull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MtsMenuInfo", "MenuTitle", c => c.String(nullable: false, maxLength: 64));
            AlterColumn("dbo.MtsMenuInfo", "MenuParentID", c => c.String(nullable: false, maxLength: 64));
            AlterColumn("dbo.MtsMenuInfo", "MenuGroup", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("dbo.MtsMenuInfo", "MenuWeight", c => c.String(nullable: false, maxLength: 16));
            AlterColumn("dbo.MtsMenuInfo", "MenuComponent", c => c.String(nullable: false, maxLength: 1024));
            AlterColumn("dbo.MtsMenuInfo", "MenuIcon", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.MtsMenuInfo", "MenuCreateDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MtsMenuInfo", "MenuCreateDate", c => c.DateTime());
            AlterColumn("dbo.MtsMenuInfo", "MenuIcon", c => c.String(maxLength: 200));
            AlterColumn("dbo.MtsMenuInfo", "MenuComponent", c => c.String(maxLength: 1024));
            AlterColumn("dbo.MtsMenuInfo", "MenuWeight", c => c.String(maxLength: 16));
            AlterColumn("dbo.MtsMenuInfo", "MenuGroup", c => c.String(maxLength: 32));
            AlterColumn("dbo.MtsMenuInfo", "MenuParentID", c => c.String(maxLength: 64));
            AlterColumn("dbo.MtsMenuInfo", "MenuTitle", c => c.String(maxLength: 64));
        }
    }
}
