namespace WebApplication2Crud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class roleaddes : DbMigration
    {
        public override void Up()
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
        
        public override void Down()
        {
            DropForeignKey("dbo.Credentials", "RoleManager_MyProperty", "dbo.RoleManagers");
            DropIndex("dbo.Credentials", new[] { "RoleManager_MyProperty" });
            DropColumn("dbo.Credentials", "RoleManager_MyProperty");
            DropTable("dbo.RoleManagers");
        }
    }
}
