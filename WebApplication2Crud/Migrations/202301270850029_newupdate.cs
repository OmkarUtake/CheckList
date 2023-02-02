namespace WebApplication2Crud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newupdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Categories", "UserReport_Id", "dbo.UserReports");
            DropIndex("dbo.Categories", new[] { "UserReport_Id" });
            DropColumn("dbo.Categories", "UserReport_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "UserReport_Id", c => c.Int());
            CreateIndex("dbo.Categories", "UserReport_Id");
            AddForeignKey("dbo.Categories", "UserReport_Id", "dbo.UserReports", "Id");
        }
    }
}
