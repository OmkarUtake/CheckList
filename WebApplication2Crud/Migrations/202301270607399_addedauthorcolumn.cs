namespace WebApplication2Crud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedauthorcolumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "author", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "author");
        }
    }
}
