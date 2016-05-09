namespace UniversityManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version241 : DbMigration
    {
        public override void Up()
        {
            
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.PersonId);
            
            CreateTable(
                "dbo.CourseAssigns",
                c => new
                    {
                        CourseAssignId = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        TeacherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseAssignId);
            
            CreateIndex("dbo.CourseAssigns", "TeacherId");
            CreateIndex("dbo.CourseAssigns", "CourseId");
            AddForeignKey("dbo.CourseAssigns", "TeacherId", "dbo.Teachers", "TeacherId", cascadeDelete: true);
            AddForeignKey("dbo.CourseAssigns", "CourseId", "dbo.Courses", "CourseId", cascadeDelete: true);
        }
    }
}
