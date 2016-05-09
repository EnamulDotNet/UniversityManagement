namespace UniversityManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version12 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "ContactNo", c => c.String(nullable: false, maxLength: 8000, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "ContactNo", c => c.String(nullable: false, maxLength: 8000, unicode: false));
        }
    }
}
