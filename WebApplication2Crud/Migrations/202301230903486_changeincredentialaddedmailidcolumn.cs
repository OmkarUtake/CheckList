namespace WebApplication2Crud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeincredentialaddedmailidcolumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Credentials", "EmailId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Credentials", "EmailId");
        }
    }
}
