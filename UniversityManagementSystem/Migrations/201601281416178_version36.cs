namespace UniversityManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version36 : DbMigration
    {
        public override void Up()
        {
            ////AddColumn("dbo.AllocateClassRooms", "AllocateClassRoomId", c => c.Int(nullable: false, identity: true));
            //AddColumn("dbo.AllocateClassRooms", "StartTime", c => c.String(nullable: false));
            //AddColumn("dbo.AllocateClassRooms", "EndTime", c => c.String(nullable: false));
            //AddColumn("dbo.Semesters", "Department_DepartmentId", c => c.Int());
            //DropPrimaryKey("dbo.AllocateClassRooms");
            //AddPrimaryKey("dbo.AllocateClassRooms", "AllocateClassRoomId");
            //CreateIndex("dbo.Semesters", "Department_DepartmentId");
            //AddForeignKey("dbo.Semesters", "Department_DepartmentId", "dbo.Departments", "DepartmentId");
            //DropColumn("dbo.AllocateClassRooms", "AllocateClassRoomId");
            //DropColumn("dbo.AllocateClassRooms", "From");
            //DropColumn("dbo.AllocateClassRooms", "To");
            //DropColumn("dbo.AllocateClassRooms", "Status");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.AllocateClassRooms", "Status", c => c.Boolean(nullable: false));
            //AddColumn("dbo.AllocateClassRooms", "To", c => c.DateTime(nullable: false));
            //AddColumn("dbo.AllocateClassRooms", "From", c => c.DateTime(nullable: false));
            //AddColumn("dbo.AllocateClassRooms", "AllocateClassRoomId", c => c.Int(nullable: false, identity: true));
            //DropForeignKey("dbo.Semesters", "Department_DepartmentId", "dbo.Departments");
            //DropIndex("dbo.Semesters", new[] { "Department_DepartmentId" });
            //DropPrimaryKey("dbo.AllocateClassRooms");
            //AddPrimaryKey("dbo.AllocateClassRooms", "AllocateClassRoomId");
            //DropColumn("dbo.Semesters", "Department_DepartmentId");
            //DropColumn("dbo.AllocateClassRooms", "EndTime");
            //DropColumn("dbo.AllocateClassRooms", "StartTime");
            //DropColumn("dbo.AllocateClassRooms", "RoomAllocationId");
        }
    }
}
