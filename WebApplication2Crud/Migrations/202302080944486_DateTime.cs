namespace WebApplication2Crud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "Date");
        }
    }
}
