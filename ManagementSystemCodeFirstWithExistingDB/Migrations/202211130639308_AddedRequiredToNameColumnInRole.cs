namespace ManagementSystemCodeFirstWithExistingDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRequiredToNameColumnInRole : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Roles", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Roles", "Name", c => c.String());
        }
    }
}
