namespace WebService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V0105 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FrequentlyOpens", "OpeningTime", c => c.String(nullable: false));
            AlterColumn("dbo.FrequentlyOpens", "CloseTime", c => c.String(nullable: false));
            AlterColumn("dbo.FrequentlyOpens", "OpeningTime", c => c.Int(nullable: false));
            AlterColumn("dbo.FrequentlyOpens", "CloseTime", c => c.Int(nullable: false));
            AlterColumn("dbo.OpenHoursExceptions", "OpeningTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.OpenHoursExceptions", "CloseTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OpenHoursExceptions", "CloseTime", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.OpenHoursExceptions", "OpeningTime", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.FrequentlyOpens", "CloseTime", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.FrequentlyOpens", "OpeningTime", c => c.Time(nullable: false, precision: 7));
        }
    }
}
