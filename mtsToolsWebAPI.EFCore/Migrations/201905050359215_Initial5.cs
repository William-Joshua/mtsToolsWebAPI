namespace mtsToolsWebAPI.EFCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MtsSoftwareInfo",
                c => new
                    {
                        SoftwareID = c.String(nullable: false, maxLength: 64),
                        SoftwareName = c.String(maxLength: 64),
                        SoftwareAlias = c.String(maxLength: 8),
                        SoftwareVersionGUID = c.String(maxLength: 64),
                        SoftwareVersion = c.String(maxLength: 32),
                        SoftWareAddress = c.String(maxLength: 1024),
                        SoftWareDescription = c.String(maxLength: 2048),
                    })
                .PrimaryKey(t => t.SoftwareID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MtsSoftwareInfo");
        }
    }
}
