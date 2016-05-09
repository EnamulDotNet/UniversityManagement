namespace UniversityManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version35 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AllocateClassRooms",
                c => new
                    {
                        AllocateClassRoomId = c.Int(nullable: false, identity: true),
                        DepartmentId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        RoomId = c.Int(nullable: false),
                        DayId = c.Int(nullable: false),
                        From = c.DateTime(nullable: false),
                        To = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AllocateClassRoomId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: false)
                .ForeignKey("dbo.Days", t => t.DayId, cascadeDelete: false)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: false)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: false)
                .Index(t => t.CourseId)
                .Index(t => t.DayId)
                .Index(t => t.DepartmentId)
                .Index(t => t.RoomId);
            
            CreateTable(
                "dbo.Days",
                c => new
                    {
                        DayId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.DayId);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        RoomId = c.Int(nullable: false, identity: true),
                        RoomNo = c.String(maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.RoomId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AllocateClassRooms", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.AllocateClassRooms", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.AllocateClassRooms", "DayId", "dbo.Days");
            DropForeignKey("dbo.AllocateClassRooms", "CourseId", "dbo.Courses");
            DropIndex("dbo.AllocateClassRooms", new[] { "RoomId" });
            DropIndex("dbo.AllocateClassRooms", new[] { "DepartmentId" });
            DropIndex("dbo.AllocateClassRooms", new[] { "DayId" });
            DropIndex("dbo.AllocateClassRooms", new[] { "CourseId" });
            DropTable("dbo.Rooms");
            DropTable("dbo.Days");
            DropTable("dbo.AllocateClassRooms");
        }
    }
}
