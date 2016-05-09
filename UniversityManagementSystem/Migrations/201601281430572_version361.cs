namespace UniversityManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version361 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AllocateClassRooms", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.AllocateClassRooms", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.AllocateClassRooms", "DayId", "dbo.Days");
            DropForeignKey("dbo.AllocateClassRooms", "RoomId", "dbo.Rooms");
            DropIndex("dbo.AllocateClassRooms", new[] { "CourseId" });
            DropIndex("dbo.AllocateClassRooms", new[] { "DepartmentId" });
            DropIndex("dbo.AllocateClassRooms", new[] { "DayId" });
            DropIndex("dbo.AllocateClassRooms", new[] { "RoomId" });
            AddColumn("dbo.Tests", "Age", c => c.String());
            DropTable("dbo.AllocateClassRooms");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AllocateClassRooms",
                c => new
                    {
                        RoomAllocationId = c.Int(nullable: false, identity: true),
                        DepartmentId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        RoomId = c.Int(nullable: false),
                        DayId = c.Int(nullable: false),
                        StartTime = c.String(nullable: false),
                        EndTime = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.RoomAllocationId);
            
            DropColumn("dbo.Tests", "Age");
            CreateIndex("dbo.AllocateClassRooms", "RoomId");
            CreateIndex("dbo.AllocateClassRooms", "DayId");
            CreateIndex("dbo.AllocateClassRooms", "DepartmentId");
            CreateIndex("dbo.AllocateClassRooms", "CourseId");
            AddForeignKey("dbo.AllocateClassRooms", "RoomId", "dbo.Rooms", "RoomId");
            AddForeignKey("dbo.AllocateClassRooms", "DayId", "dbo.Days", "DayId");
            AddForeignKey("dbo.AllocateClassRooms", "DepartmentId", "dbo.Departments", "DepartmentId");
            AddForeignKey("dbo.AllocateClassRooms", "CourseId", "dbo.Courses", "CourseId");
        }
    }
}
