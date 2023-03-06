namespace WebApplication2Crud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createbyDrop : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Credentials", "CreateBy");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Credentials", "CreateBy", c => c.String());
        }
    }
}
