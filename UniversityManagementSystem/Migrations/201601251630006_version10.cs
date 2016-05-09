namespace UniversityManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Semesters", "Department_DepartmentId", c => c.Int());
            CreateIndex("dbo.Semesters", "Department_DepartmentId");
            AddForeignKey("dbo.Semesters", "Department_DepartmentId", "dbo.Departments", "DepartmentId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Semesters", "Department_DepartmentId", "dbo.Departments");
            DropIndex("dbo.Semesters", new[] { "Department_DepartmentId" });
            DropColumn("dbo.Semesters", "Department_DepartmentId");
        }
    }
}
