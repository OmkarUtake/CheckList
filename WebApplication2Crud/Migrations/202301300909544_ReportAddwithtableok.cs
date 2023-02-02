namespace WebApplication2Crud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReportAddwithtableok : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Categories", "userkey");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "userkey", c => c.Int(nullable: false));
        }
    }
}
