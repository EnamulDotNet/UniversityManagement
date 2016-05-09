namespace UniversityManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version18 : DbMigration
    {
        public override void Up()
        {
             
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseAssigns", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.CourseAssigns", "CourseId", "dbo.Courses");
            DropIndex("dbo.CourseAssigns", new[] { "TeacherId" });
            DropIndex("dbo.CourseAssigns", new[] { "CourseId" });
            DropTable("dbo.CourseAssigns");
        }
    }
}
