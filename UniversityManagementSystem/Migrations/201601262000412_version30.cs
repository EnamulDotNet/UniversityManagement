namespace UniversityManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version30 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CourseEnrolls", "StudentRegNo", c => c.Int(nullable: false));
            DropColumn("dbo.CourseEnrolls", "RegNo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CourseEnrolls", "RegNo", c => c.Int(nullable: false));
            DropColumn("dbo.CourseEnrolls", "StudentRegNo");
        }
    }
}
