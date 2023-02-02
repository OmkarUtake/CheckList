namespace WebApplication2Crud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class credchange : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Credentials");
            AlterColumn("dbo.Credentials", "CreateBy", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Credentials", "CreateBy");
            DropColumn("dbo.Credentials", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Credentials", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Credentials");
            AlterColumn("dbo.Credentials", "CreateBy", c => c.String(nullable: false));
            AddPrimaryKey("dbo.Credentials", "Id");
        }
    }
}
