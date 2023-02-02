namespace WebApplication2Crud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newmig : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Credentials", "EmailId", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Credentials", "EmailId", c => c.String());
        }
    }
}
