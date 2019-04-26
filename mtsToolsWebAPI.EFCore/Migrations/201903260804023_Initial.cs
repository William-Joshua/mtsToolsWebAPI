namespace mtsToolsWebAPI.EFCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MtsAccountInfo",
                c => new
                    {
                        InnerUserID = c.String(nullable: false, maxLength: 64),
                        UserID = c.String(),
                        UserName = c.String(),
                        Birthday = c.DateTime(nullable: false),
                        Telephone = c.String(),
                        Email = c.String(),
                        EntryTime = c.DateTime(nullable: false),
                        IsService = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InnerUserID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MtsAccountInfo");
        }
    }
}
