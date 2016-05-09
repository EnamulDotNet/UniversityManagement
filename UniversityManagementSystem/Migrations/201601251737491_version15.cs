namespace UniversityManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version15 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "ContactNO", c => c.String(nullable: false, maxLength: 14, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "ContactNO", c => c.String(nullable: false, maxLength: 14, unicode: false));
        }
    }
}
