namespace UniversityManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version38 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "AssignTo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "AssignTo");
        }
    }
}
