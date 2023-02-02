namespace WebApplication2Crud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReportAddwithtable : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Credentials");
            AddColumn("dbo.Categories", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Categories", "userkey", c => c.Int(nullable: false));
            AddColumn("dbo.Credentials", "id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Credentials", "CreateBy", c => c.String(nullable: false));
            AddPrimaryKey("dbo.Credentials", "id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Credentials");
            AlterColumn("dbo.Credentials", "CreateBy", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Credentials", "id");
            DropColumn("dbo.Categories", "userkey");
            DropColumn("dbo.Categories", "UserId");
            AddPrimaryKey("dbo.Credentials", "CreateBy");
        }
    }
}
