namespace ManagementSystemCodeFirstWithExistingDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAnnotationsToEmployeeTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "Role_Id", "dbo.Roles");
            DropIndex("dbo.Employees", new[] { "Role_Id" });
            RenameColumn(table: "dbo.Employees", name: "Role_Id", newName: "RoleId");
            AlterColumn("dbo.Employees", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Employees", "RoleId", c => c.Int(nullable: false));
            CreateIndex("dbo.Employees", "RoleId");
            AddForeignKey("dbo.Employees", "RoleId", "dbo.Roles", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "RoleId", "dbo.Roles");
            DropIndex("dbo.Employees", new[] { "RoleId" });
            AlterColumn("dbo.Employees", "RoleId", c => c.Int());
            AlterColumn("dbo.Employees", "Name", c => c.String());
            RenameColumn(table: "dbo.Employees", name: "RoleId", newName: "Role_Id");
            CreateIndex("dbo.Employees", "Role_Id");
            AddForeignKey("dbo.Employees", "Role_Id", "dbo.Roles", "Id");
        }
    }
}
