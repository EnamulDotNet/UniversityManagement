namespace UniversityManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version34 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CourseAssigns", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.CourseAssigns", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.CourseAssigns", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Courses", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Courses", "SemesterId", "dbo.Semesters");
            DropForeignKey("dbo.Students", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Teachers", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Teachers", "DesignationId", "dbo.Designations");
            DropForeignKey("dbo.CourseEnrolls", "CourseId", "dbo.Courses");
            DropIndex("dbo.CourseAssigns", new[] { "CourseId" });
            DropIndex("dbo.CourseAssigns", new[] { "DepartmentId" });
            DropIndex("dbo.CourseAssigns", new[] { "TeacherId" });
            DropIndex("dbo.Courses", new[] { "DepartmentId" });
            DropIndex("dbo.Courses", new[] { "SemesterId" });
            DropIndex("dbo.Students", new[] { "DepartmentId" });
            DropIndex("dbo.Teachers", new[] { "DepartmentId" });
            DropIndex("dbo.Teachers", new[] { "DesignationId" });
            DropIndex("dbo.CourseEnrolls", new[] { "CourseId" });
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Courses", "DepartmentId");
            CreateIndex("dbo.Courses", "SemesterId");
            CreateIndex("dbo.Students", "DepartmentId");
            CreateIndex("dbo.Teachers", "DepartmentId");
            CreateIndex("dbo.Teachers", "DesignationId");
            CreateIndex("dbo.CourseEnrolls", "CourseId");
            AddForeignKey("dbo.Courses", "DepartmentId", "dbo.Departments", "DepartmentId", cascadeDelete: true);
            AddForeignKey("dbo.Courses", "SemesterId", "dbo.Semesters", "SemesterId", cascadeDelete: true);
            AddForeignKey("dbo.Students", "DepartmentId", "dbo.Departments", "DepartmentId", cascadeDelete: true);
            AddForeignKey("dbo.Teachers", "DepartmentId", "dbo.Departments", "DepartmentId", cascadeDelete: true);
            AddForeignKey("dbo.Teachers", "DesignationId", "dbo.Designations", "DesignationId", cascadeDelete: true);
            AddForeignKey("dbo.CourseEnrolls", "CourseId", "dbo.Courses", "CourseId", cascadeDelete: true);
           // DropTable("dbo.CourseAssignRecords");
          //  DropTable("dbo.CourseAssigns");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CourseAssigns",
                c => new
                    {
                        CourseAssignId = c.Int(nullable: false, identity: true),
                        DepartmentId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        TeacherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseAssignId);
            
            CreateTable(
                "dbo.CourseAssignRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseAssignId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        TeacherId = c.Int(nullable: false),
                        AssignDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.CourseEnrolls", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Teachers", "DesignationId", "dbo.Designations");
            DropForeignKey("dbo.Teachers", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Students", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Courses", "SemesterId", "dbo.Semesters");
            DropForeignKey("dbo.Courses", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.CourseEnrolls", new[] { "CourseId" });
            DropIndex("dbo.Teachers", new[] { "DesignationId" });
            DropIndex("dbo.Teachers", new[] { "DepartmentId" });
            DropIndex("dbo.Students", new[] { "DepartmentId" });
            DropIndex("dbo.Courses", new[] { "SemesterId" });
            DropIndex("dbo.Courses", new[] { "DepartmentId" });
            DropTable("dbo.Tests");
            CreateIndex("dbo.CourseEnrolls", "CourseId");
            CreateIndex("dbo.Teachers", "DesignationId");
            CreateIndex("dbo.Teachers", "DepartmentId");
            CreateIndex("dbo.Students", "DepartmentId");
            CreateIndex("dbo.Courses", "SemesterId");
            CreateIndex("dbo.Courses", "DepartmentId");
            CreateIndex("dbo.CourseAssigns", "TeacherId");
            CreateIndex("dbo.CourseAssigns", "DepartmentId");
            CreateIndex("dbo.CourseAssigns", "CourseId");
            AddForeignKey("dbo.CourseEnrolls", "CourseId", "dbo.Courses", "CourseId");
            AddForeignKey("dbo.Teachers", "DesignationId", "dbo.Designations", "DesignationId");
            AddForeignKey("dbo.Teachers", "DepartmentId", "dbo.Departments", "DepartmentId");
            AddForeignKey("dbo.Students", "DepartmentId", "dbo.Departments", "DepartmentId");
            AddForeignKey("dbo.Courses", "SemesterId", "dbo.Semesters", "SemesterId");
            AddForeignKey("dbo.Courses", "DepartmentId", "dbo.Departments", "DepartmentId");
            AddForeignKey("dbo.CourseAssigns", "TeacherId", "dbo.Teachers", "TeacherId");
            AddForeignKey("dbo.CourseAssigns", "DepartmentId", "dbo.Departments", "DepartmentId");
            AddForeignKey("dbo.CourseAssigns", "CourseId", "dbo.Courses", "CourseId");
        }
    }
}
