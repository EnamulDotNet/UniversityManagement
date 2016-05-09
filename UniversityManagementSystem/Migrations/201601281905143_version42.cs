namespace UniversityManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version42 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "CourseCredit", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Courses", "CourseCredit", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
