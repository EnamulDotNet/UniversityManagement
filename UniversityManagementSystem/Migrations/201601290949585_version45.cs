namespace UniversityManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version45 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Days", "Name", c => c.String(nullable: false, maxLength: 8000, unicode: false));
            AlterColumn("dbo.Rooms", "RoomNo", c => c.String(nullable: false, maxLength: 8000, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Rooms", "RoomNo", c => c.String(maxLength: 8000, unicode: false));
            AlterColumn("dbo.Days", "Name", c => c.String(maxLength: 8000, unicode: false));
        }
    }
}
