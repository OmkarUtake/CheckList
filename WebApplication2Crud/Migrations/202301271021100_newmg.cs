namespace WebApplication2Crud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newmg : DbMigration
    {
        public override void Up()
        {

        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserReports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
