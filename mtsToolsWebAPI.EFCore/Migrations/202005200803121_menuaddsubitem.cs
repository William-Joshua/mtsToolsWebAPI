namespace mtsToolsWebAPI.EFCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class menuaddsubitem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MtsMenuInfo", "EnableMasterTemplate", c => c.Boolean(nullable: false));
            AddColumn("dbo.MtsMenuInfo", "SubItemContainer", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MtsMenuInfo", "SubItemContainer");
            DropColumn("dbo.MtsMenuInfo", "EnableMasterTemplate");
        }
    }
}
