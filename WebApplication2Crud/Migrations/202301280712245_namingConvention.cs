namespace WebApplication2Crud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class namingConvention : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "Icategory", c => c.String(nullable: false));
            DropColumn("dbo.Categories", "category");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "category", c => c.String(nullable: false));
            DropColumn("dbo.Categories", "Icategory");
        }
    }
}
