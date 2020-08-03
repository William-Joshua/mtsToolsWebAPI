namespace mtsToolsWebAPI.EFCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatemenuweightdatatype : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MtsMenuInfo", "MenuWeight", c => c.String(maxLength: 16));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MtsMenuInfo", "MenuWeight", c => c.Int());
        }
    }
}
