namespace WebApplication2Crud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createby : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Credentials", "CreateBy", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Credentials", "CreateBy");
        }
    }
}
