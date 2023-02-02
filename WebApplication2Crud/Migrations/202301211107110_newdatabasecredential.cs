namespace WebApplication2Crud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class newdatabasecredential : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Credentials",
                c => new
                {
                    id = c.Int(nullable: false, identity: true),
                    user_name = c.String(nullable: false),
                    password = c.String(nullable: false),
                })
                .PrimaryKey(t => t.id);

        }

        public override void Down()
        {
            DropTable("dbo.Credentials");
        }
    }
}
