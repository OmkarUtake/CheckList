namespace WebApplication2Crud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reportAddes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserReports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Categories", "UserReport_Id", c => c.Int());
            CreateIndex("dbo.Categories", "UserReport_Id");
            AddForeignKey("dbo.Categories", "UserReport_Id", "dbo.UserReports", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categories", "UserReport_Id", "dbo.UserReports");
            DropIndex("dbo.Categories", new[] { "UserReport_Id" });
            DropColumn("dbo.Categories", "UserReport_Id");
            DropTable("dbo.UserReports");
        }
    }
}
