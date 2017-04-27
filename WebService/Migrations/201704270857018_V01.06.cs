namespace WebService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V0106 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        DisplayName = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            AddColumn("dbo.Ratings", "User_UserId", c => c.Int());
            CreateIndex("dbo.Ratings", "User_UserId");
            AddForeignKey("dbo.Ratings", "User_UserId", "dbo.Users", "UserId");
            DropColumn("dbo.Ratings", "GoogleID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ratings", "GoogleID", c => c.String());
            DropForeignKey("dbo.Ratings", "User_UserId", "dbo.Users");
            DropIndex("dbo.Ratings", new[] { "User_UserId" });
            DropColumn("dbo.Ratings", "User_UserId");
            DropTable("dbo.Users");
        }
    }
}
