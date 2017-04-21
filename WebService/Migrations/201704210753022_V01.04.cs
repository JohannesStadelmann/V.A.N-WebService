namespace WebService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V0104 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OpenHoursExceptions", "OpeningTime", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.OpenHoursExceptions", "CloseTime", c => c.Time(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OpenHoursExceptions", "CloseTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.OpenHoursExceptions", "OpeningTime", c => c.DateTime(nullable: false));
        }
    }
}
