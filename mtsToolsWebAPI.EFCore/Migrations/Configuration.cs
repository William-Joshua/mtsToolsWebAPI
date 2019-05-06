namespace mtsToolsWebAPI.EFCore.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<mtsToolsWebAPI.EFCore.EntityFrameworkCore.EFCoreContext>
    {
        // 0 Enable-Migrations -ContextTypeName mtsToolsWebAPI.EFCore
        // 1 Add-Migration Initial
        // 2 Update-Database
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(mtsToolsWebAPI.EFCore.EntityFrameworkCore.EFCoreContext context)
        {
            //  This method will be called after migrating to the latest version.
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
