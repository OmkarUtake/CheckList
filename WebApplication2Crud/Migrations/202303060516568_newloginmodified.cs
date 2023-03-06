namespace WebApplication2Crud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newloginmodified : DbMigration
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
