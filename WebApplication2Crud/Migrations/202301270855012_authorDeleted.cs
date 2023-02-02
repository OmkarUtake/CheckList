namespace WebApplication2Crud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class authorDeleted : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Categories", "author");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "author", c => c.String());
        }
    }
}
