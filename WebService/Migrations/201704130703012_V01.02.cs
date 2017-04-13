namespace WebService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V0102 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Addresses", "GPSLatitude", c => c.Double(nullable: false));
            AlterColumn("dbo.Addresses", "GPSLongitude", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Addresses", "GPSLongitude", c => c.Long(nullable: false));
            AlterColumn("dbo.Addresses", "GPSLatitude", c => c.Long(nullable: false));
        }
    }
}
