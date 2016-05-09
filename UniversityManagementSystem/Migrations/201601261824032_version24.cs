namespace UniversityManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version24 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseAssigns",
                c => new
                    {
                        CourseAssignId = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        TeacherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseAssignId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.CourseId)
                .Index(t => t.TeacherId);
            
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
