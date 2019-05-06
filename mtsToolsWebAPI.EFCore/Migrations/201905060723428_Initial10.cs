namespace mtsToolsWebAPI.EFCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial10 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MtsMenuInfo", "MenuParentID", c => c.String(maxLength: 64));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MtsMenuInfo", "MenuParentID", c => c.String(maxLength: 8));
        }
    }
}
