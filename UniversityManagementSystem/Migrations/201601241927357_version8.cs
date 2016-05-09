namespace UniversityManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version8 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Teachers", "Email", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.Teachers", "CreditToBeTaken", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Teachers", "CreditToBeTaken", c => c.Double(nullable: false));
            AlterColumn("dbo.Teachers", "Email", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
