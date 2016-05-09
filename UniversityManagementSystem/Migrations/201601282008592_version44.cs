namespace UniversityManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version44 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Semesters", "SemesterName", c => c.String(nullable: false, maxLength: 8000, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Semesters", "SemesterName", c => c.String(maxLength: 8000, unicode: false));
        }
    }
}
