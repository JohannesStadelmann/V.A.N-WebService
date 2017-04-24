using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using WebService.DatabaseContext;
using WebService.Models;
using WebService.ViewModels;

namespace WebService.Controllers
{
    public class LocationController : ApiController {

        [HttpGet]
        public IEnumerable<LocationVM> GetAll() {
            using (var ctx = new VANContext()) {
                return Mapper.Map<IEnumerable<LocationVM>>(ctx.Locations.Include("Address").Include("Typ").ToList());
            }
        }

        [HttpGet]
        public LocationDetailedVM GetById(int id) {
            using(var ctx = new VANContext()) {
                return Mapper.Map<LocationDetailedVM>(ctx.Locations
                    .Include("Address")
                    .Include("Typ")
                    .Include("MusicGenres")
                    .Include("Ratings")
                    .Include("FrequentlyOpens")
                    .Include("OpenHoursExceptions")
                    .SingleOrDefault(x => x.LocationID == id));
            }
        }

        [HttpPost]
        public IEnumerable<LocationVM> FindByParameters(LocationSearchVM locationSearch)
        {
            using(var ctx = new VANContext())
            {
                IEnumerable<Location> locations =
                    ctx.Locations.Include("Address").Include("Typ").Include("MusicGenres").Include("FrequentlyOpens").ToList();

                if (locationSearch.Location != "")
                {
                    locations = locations.Where(x => x.Name.Contains(locationSearch.Location));
                }
                if (locationSearch.City != "")
                {
                    locations = locations.Where(x => x.Address.City.Contains(locationSearch.City));
                }
                if(locationSearch.MusicGenre != "") {
                    locations = locations.Where(x => FindMusicGenre(x.MusicGenres, locationSearch.MusicGenre));
                }
                if(locationSearch.Typ != "") {
                    locations = locations.Where(x => x.Typ.Name.Contains(locationSearch.Typ));
                }

                // Filter open locations if needed
                List<Location> filteredLocations = locations.ToList();
                if (locationSearch.IsOpen) {
                    DateTime currDateTime = DateTime.Now;
                   
                    foreach (Location location in locations)
                    {
                        FrequentlyOpen open = location.FrequentlyOpens.SingleOrDefault(x => x.DayOfWeek == currDateTime.DayOfWeek);
                        if (open != null) {
                            // check if open today (= both > 0)
                            if (open.OpeningTime > 0 && open.CloseTime > 0) {
                                int time = (currDateTime.Hour * 100) + currDateTime.Minute;
                                int closingTime = open.CloseTime <= 400 ? open.CloseTime + 3000 : open.CloseTime;
                                if (time < open.OpeningTime || time > closingTime) {
                                    filteredLocations.Remove(location);
                                }
                            } else {
                                filteredLocations.Remove(location);
                            }
                        }
                    }
                }

                return Mapper.Map<IEnumerable<LocationVM>>(filteredLocations);
            }
        }

        private bool FindMusicGenre(IEnumerable<MusicGenre> musicGenres, string searchString)
        {
            foreach (MusicGenre musicGenre in musicGenres) {
                if (musicGenre.Name.Contains(searchString)) {
                    return true;
                }
            }
            return false;
        }
    }
}
