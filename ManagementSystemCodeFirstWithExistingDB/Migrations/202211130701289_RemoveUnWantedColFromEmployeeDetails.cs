namespace ManagementSystemCodeFirstWithExistingDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveUnWantedColFromEmployeeDetails : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.EmployeeDetails", "EmployeeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EmployeeDetails", "EmployeeId", c => c.Int(nullable: false));
        }
    }
}
