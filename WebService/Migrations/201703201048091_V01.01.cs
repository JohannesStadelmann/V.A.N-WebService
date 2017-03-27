namespace WebService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V0101 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressID = c.Int(nullable: false, identity: true),
                        Country = c.String(),
                        City = c.String(),
                        Street = c.String(),
                        StreetNo = c.String(),
                        GPSLatitude = c.Long(nullable: false),
                        GPSLongitude = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.AddressID);
            
            CreateTable(
                "dbo.FrequentlyOpens",
                c => new
                    {
                        FrequentlyOpenID = c.Int(nullable: false, identity: true),
                        DayOfWeek = c.Int(nullable: false),
                        OpeningTime = c.Time(nullable: false, precision: 7),
                        CloseTime = c.Time(nullable: false, precision: 7),
                        Location_LocationID = c.Int(),
                    })
                .PrimaryKey(t => t.FrequentlyOpenID)
                .ForeignKey("dbo.Locations", t => t.Location_LocationID)
                .Index(t => t.Location_LocationID);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        LocationID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Address_AddressID = c.Int(),
                        Typ_TypID = c.Int(),
                    })
                .PrimaryKey(t => t.LocationID)
                .ForeignKey("dbo.Addresses", t => t.Address_AddressID)
                .ForeignKey("dbo.Typs", t => t.Typ_TypID)
                .Index(t => t.Address_AddressID)
                .Index(t => t.Typ_TypID);
            
            CreateTable(
                "dbo.MusicGenres",
                c => new
                    {
                        MusicGenreID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Location_LocationID = c.Int(),
                    })
                .PrimaryKey(t => t.MusicGenreID)
                .ForeignKey("dbo.Locations", t => t.Location_LocationID)
                .Index(t => t.Location_LocationID);
            
            CreateTable(
                "dbo.OpenHoursExceptions",
                c => new
                    {
                        OpenHoursExceptionID = c.Int(nullable: false, identity: true),
                        IsOpen = c.Boolean(nullable: false),
                        OpeningTime = c.DateTime(nullable: false),
                        CloseTime = c.DateTime(nullable: false),
                        Location_LocationID = c.Int(),
                    })
                .PrimaryKey(t => t.OpenHoursExceptionID)
                .ForeignKey("dbo.Locations", t => t.Location_LocationID)
                .Index(t => t.Location_LocationID);
            
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        RatingID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        GoogleID = c.String(),
                        Date = c.DateTime(nullable: false),
                        UserRating = c.Int(nullable: false),
                        Comment = c.String(),
                        Location_LocationID = c.Int(),
                    })
                .PrimaryKey(t => t.RatingID)
                .ForeignKey("dbo.Locations", t => t.Location_LocationID)
                .Index(t => t.Location_LocationID);
            
            CreateTable(
                "dbo.Typs",
                c => new
                    {
                        TypID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.TypID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Locations", "Typ_TypID", "dbo.Typs");
            DropForeignKey("dbo.Ratings", "Location_LocationID", "dbo.Locations");
            DropForeignKey("dbo.OpenHoursExceptions", "Location_LocationID", "dbo.Locations");
            DropForeignKey("dbo.MusicGenres", "Location_LocationID", "dbo.Locations");
            DropForeignKey("dbo.FrequentlyOpens", "Location_LocationID", "dbo.Locations");
            DropForeignKey("dbo.Locations", "Address_AddressID", "dbo.Addresses");
            DropIndex("dbo.Ratings", new[] { "Location_LocationID" });
            DropIndex("dbo.OpenHoursExceptions", new[] { "Location_LocationID" });
            DropIndex("dbo.MusicGenres", new[] { "Location_LocationID" });
            DropIndex("dbo.Locations", new[] { "Typ_TypID" });
            DropIndex("dbo.Locations", new[] { "Address_AddressID" });
            DropIndex("dbo.FrequentlyOpens", new[] { "Location_LocationID" });
            DropTable("dbo.Typs");
            DropTable("dbo.Ratings");
            DropTable("dbo.OpenHoursExceptions");
            DropTable("dbo.MusicGenres");
            DropTable("dbo.Locations");
            DropTable("dbo.FrequentlyOpens");
            DropTable("dbo.Addresses");
        }
    }
}
