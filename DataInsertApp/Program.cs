using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebService.DatabaseContext;
using WebService.Models;

namespace DataInsertApp {
    class Program {
        static void Main(string[] args)
        {
            using (var ctx = new VANContext())
            {
                Location location = new Location() {
                    Description = "",
                    Name = "",
                    PictureURL = "",
                    Typ = new Typ() { Name = "" },
                    Address = new Address() {
                        City = "",
                        Country = "",
                        Street = "",
                        StreetNo = "",
                        GPSLongitude = 0,
                        GPSLatitude = 0
                    },
                    MusicGenres = new List<MusicGenre>()
                    {
                        new MusicGenre() { Name = ""},
                        new MusicGenre() { Name = ""}
                    },
                    FrequentlyOpens = new List<FrequentlyOpen>() {
                        new FrequentlyOpen() {DayOfWeek = DayOfWeek.Monday, OpeningTime = 1400, CloseTime = 2400 },
                        new FrequentlyOpen() {DayOfWeek = DayOfWeek.Tuesday, OpeningTime = 1400, CloseTime = 2400 },
                        new FrequentlyOpen() {DayOfWeek = DayOfWeek.Wednesday, OpeningTime = 1400, CloseTime = 2400 },
                        new FrequentlyOpen() {DayOfWeek = DayOfWeek.Thursday, OpeningTime = 1400, CloseTime = 2400 },
                        new FrequentlyOpen() {DayOfWeek = DayOfWeek.Friday, OpeningTime = 1400, CloseTime = 2400 },
                        new FrequentlyOpen() {DayOfWeek = DayOfWeek.Saturday, OpeningTime = 1400, CloseTime = 2400 },
                        new FrequentlyOpen() {DayOfWeek = DayOfWeek.Sunday, OpeningTime = 1400, CloseTime = 2400 }
                    },
                    OpenHoursExceptions = new List<OpenHoursException>()
                    {
                        // new DateTime (year,month,day,hour,min,sec)
                        new OpenHoursException() { IsOpen = true, OpeningTime = new DateTime(2017,10,25,14,0,0), CloseTime = new DateTime(2017,10,25,22,0,0) },
                        new OpenHoursException() { IsOpen = true, OpeningTime = new DateTime(2017,10,25,14,0,0), CloseTime = new DateTime(2017,10,25,22,0,0) },
                        new OpenHoursException() { IsOpen = true, OpeningTime = new DateTime(2017,10,25,14,0,0), CloseTime = new DateTime(2017,10,25,22,0,0) }
                    } 
                };
                ctx.Locations.Add(location);
                ctx.SaveChanges();
            }
        }
    }
}
