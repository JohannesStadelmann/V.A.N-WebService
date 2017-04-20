namespace WebService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V0103 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Locations", "PictureURL", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Locations", "PictureURL");
        }
    }
}
