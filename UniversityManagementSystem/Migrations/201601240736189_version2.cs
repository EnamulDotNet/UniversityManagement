namespace UniversityManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Departments", "DepartmentCode", c => c.String(nullable: false, maxLength: 7, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Departments", "DepartmentCode", c => c.String(nullable: false, maxLength: 8000, unicode: false));
        }
    }
}
