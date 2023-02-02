namespace WebApplication2Crud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newrolekey : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Credentials", "role", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Credentials", "role");
        }
    }
}
