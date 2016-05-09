namespace UniversityManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version181 : DbMigration
    {
        public override void Up()
        {
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.CourseAssigns", "DepartmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.CourseAssigns", "DepartmentId");
            AddForeignKey("dbo.CourseAssigns", "DepartmentId", "dbo.Departments", "DepartmentId", cascadeDelete: true);
        }
    }
}
