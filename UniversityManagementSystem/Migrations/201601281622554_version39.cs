namespace UniversityManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version39 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ResultEntries",
                c => new
                    {
                        ResultEntryId = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        GradeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ResultEntryId)
                .ForeignKey("dbo.Courses", t => t.CourseId)
                .ForeignKey("dbo.Grades", t => t.GradeId)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .Index(t => t.CourseId)
                .Index(t => t.GradeId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        GradeId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.GradeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ResultEntries", "StudentId", "dbo.Students");
            DropForeignKey("dbo.ResultEntries", "GradeId", "dbo.Grades");
            DropForeignKey("dbo.ResultEntries", "CourseId", "dbo.Courses");
            DropIndex("dbo.ResultEntries", new[] { "StudentId" });
            DropIndex("dbo.ResultEntries", new[] { "GradeId" });
            DropIndex("dbo.ResultEntries", new[] { "CourseId" });
            DropTable("dbo.Grades");
            DropTable("dbo.ResultEntries");
        }
    }
}
