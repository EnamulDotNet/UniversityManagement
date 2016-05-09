namespace UniversityManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version43 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Teachers", "CreditToBeTaken", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Teachers", "CreditToBeTaken", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
