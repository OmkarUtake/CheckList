namespace WebApplication2Crud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fieldnamechange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Credentials", "CreateBy", c => c.String(nullable: false));
            DropColumn("dbo.Credentials", "User_Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Credentials", "User_Name", c => c.String(nullable: false));
            DropColumn("dbo.Credentials", "CreateBy");
        }
    }
}
