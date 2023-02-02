namespace WebApplication2Crud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dt : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Credentials", "RoleManager_MyProperty", "dbo.RoleManagers");
            DropIndex("dbo.Credentials", new[] { "RoleManager_MyProperty" });
            DropColumn("dbo.Credentials", "RoleManager_MyProperty");
            DropTable("dbo.RoleManagers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RoleManagers",
                c => new
                    {
                        MyProperty = c.Int(nullable: false, identity: true),
                        role = c.String(),
                    })
                .PrimaryKey(t => t.MyProperty);
            
            AddColumn("dbo.Credentials", "RoleManager_MyProperty", c => c.Int());
            CreateIndex("dbo.Credentials", "RoleManager_MyProperty");
            AddForeignKey("dbo.Credentials", "RoleManager_MyProperty", "dbo.RoleManagers", "MyProperty");
        }
    }
}
