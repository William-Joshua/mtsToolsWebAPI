namespace mtsToolsWebAPI.EFCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MtsAccountInfo", "UserID", c => c.String(maxLength: 16));
            AlterColumn("dbo.MtsAccountInfo", "UserName", c => c.String(maxLength: 32));
            AlterColumn("dbo.MtsAccountInfo", "Birthday", c => c.DateTime());
            AlterColumn("dbo.MtsAccountInfo", "Telephone", c => c.String(maxLength: 20));
            AlterColumn("dbo.MtsAccountInfo", "Email", c => c.String(maxLength: 32));
            AlterColumn("dbo.MtsAccountInfo", "EntryTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MtsAccountInfo", "EntryTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.MtsAccountInfo", "Email", c => c.String());
            AlterColumn("dbo.MtsAccountInfo", "Telephone", c => c.String());
            AlterColumn("dbo.MtsAccountInfo", "Birthday", c => c.DateTime(nullable: false));
            AlterColumn("dbo.MtsAccountInfo", "UserName", c => c.String());
            AlterColumn("dbo.MtsAccountInfo", "UserID", c => c.String());
        }
    }
}
