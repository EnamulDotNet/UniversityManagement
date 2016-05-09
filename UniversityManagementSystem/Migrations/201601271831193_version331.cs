namespace UniversityManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version331 : DbMigration
    {
        public override void Up()
        {
             
              
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseAssigns", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.CourseAssigns", new[] { "DepartmentId" });
            DropColumn("dbo.CourseAssigns", "DepartmentId");
        }
    }
}
