namespace ManagementSystemCodeFirstWithExistingDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRequiredToEmailColumnInEmployeeDetails : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmployeeDetails", "EmployeeId", c => c.Int(nullable: false));
            AlterColumn("dbo.EmployeeDetails", "Email", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EmployeeDetails", "Email", c => c.String());
            DropColumn("dbo.EmployeeDetails", "EmployeeId");
        }
    }
}
