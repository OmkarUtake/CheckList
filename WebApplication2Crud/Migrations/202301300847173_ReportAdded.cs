namespace WebApplication2Crud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class ReportAdded : DbMigration
    {
        public override void Up()
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

        public override void Down()
        {
            DropTable("dbo.Reports");
        }
    }
}
