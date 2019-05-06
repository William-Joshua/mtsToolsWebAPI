namespace mtsToolsWebAPI.EFCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial9 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MtsMenuInfo", "MenuComponent", c => c.String(maxLength: 1024));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MtsMenuInfo", "MenuComponent", c => c.String(nullable: false, maxLength: 1024));
        }
    }
}
