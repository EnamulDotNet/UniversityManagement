namespace UniversityManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version291 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CourseEnrolls", "RegNo", c => c.Int(nullable: false));
            DropColumn("dbo.CourseEnrolls", "StudentRegNo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CourseEnrolls", "StudentRegNo", c => c.Int(nullable: false));
            DropColumn("dbo.CourseEnrolls", "RegNo");
        }
    }
}
