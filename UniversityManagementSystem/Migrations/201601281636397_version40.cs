namespace UniversityManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version40 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CourseEnrolls", "GradeName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CourseEnrolls", "GradeName");
        }
    }
}
