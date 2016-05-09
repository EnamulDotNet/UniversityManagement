namespace UniversityManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version29 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseEnrolls",
                c => new
                    {
                        CourseEnrollId = c.Int(nullable: false, identity: true),
                        StudentRegNo = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        EnrollDate = c.DateTime(nullable: false),
                        Student_StudentId = c.Int(),
                    })
                .PrimaryKey(t => t.CourseEnrollId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.Student_StudentId)
                .Index(t => t.CourseId)
                .Index(t => t.Student_StudentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseEnrolls", "Student_StudentId", "dbo.Students");
            DropForeignKey("dbo.CourseEnrolls", "CourseId", "dbo.Courses");
            DropIndex("dbo.CourseEnrolls", new[] { "Student_StudentId" });
            DropIndex("dbo.CourseEnrolls", new[] { "CourseId" });
            DropTable("dbo.CourseEnrolls");
        }
    }
}
