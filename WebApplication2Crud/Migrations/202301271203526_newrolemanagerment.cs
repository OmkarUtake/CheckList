namespace WebApplication2Crud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newrolemanagerment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Credentials", "UserRole", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Credentials", "UserRole");
        }
    }
}
