namespace WebApplication2Crud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class recordtabledeleted : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Reports");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        userid = c.Int(nullable: false, identity: true),
                        User = c.String(),
                    })
                .PrimaryKey(t => t.userid);
            
        }
    }
}
