namespace mtsToolsWebAPI.EFCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MtsMenuInfo", "SoftwareAlias", c => c.String(nullable: false, maxLength: 8));
            AddColumn("dbo.MtsMenuInfo", "MenuWeight", c => c.Int());
            AddColumn("dbo.MtsMenuInfo", "MenuCreateDate", c => c.DateTime());
            AlterColumn("dbo.MtsMenuInfo", "MenuIcon", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MtsMenuInfo", "MenuIcon", c => c.String(maxLength: 64));
            DropColumn("dbo.MtsMenuInfo", "MenuCreateDate");
            DropColumn("dbo.MtsMenuInfo", "MenuWeight");
            DropColumn("dbo.MtsMenuInfo", "SoftwareAlias");
        }
    }
}
