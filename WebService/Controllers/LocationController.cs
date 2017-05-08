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

namespace WebService.Controllers {
    public class LocationController: ApiController {

        [HttpGet]
        public IEnumerable<LocationVM> GetAll() {
            using(var ctx = new VANContext()) {
                DateTime currDateTime = DateTime.Now;
                List<Location> locations = ctx.Locations.Include("Address").Include("Typ").Include("FrequentlyOpens").Include("Ratings").ToList();
                List<LocationVM> vmLocations = new List<LocationVM>();
                foreach(Location location in locations) {
                    LocationVM vm = Mapper.Map<LocationVM>(location);
                    vm = SetOpeningHours(vm, location);
                    vm = SetRating(vm, location);
                    vmLocations.Add(vm);
                }

                return vmLocations;
            }
        }

        [HttpGet]
        public IEnumerable<LocationVM> GetTop10() {
            using(var ctx = new VANContext()) {
                List<Location> locations = ctx.Locations.Include("Address").Include("Typ").Include("FrequentlyOpens").Include("Ratings").ToList();
                List<LocationVM> vmLocations = new List<LocationVM>();
                foreach(Location location in locations) {
                    if(location.Ratings.Count > 5) {
                        LocationVM vm = Mapper.Map<LocationVM>(location);
                        vm = SetOpeningHours(vm, location);
                        vm = SetRating(vm, location);
                        vmLocations.Add(vm);
                    }
                }
                return vmLocations.OrderBy(x => x.OverAllRating).Take(10);
            }
        }

        [HttpGet]
        public LocationDetailedVM GetById(int id) {
            using(var ctx = new VANContext())
            {
                Location location = ctx.Locations.Include("Address")
                    .Include("Typ")
                    .Include("MusicGenres")
                    .Include("Ratings")
                    .Include("Ratings.User")
                    .Include("FrequentlyOpens")
                    .SingleOrDefault(x => x.LocationID == id);

                LocationDetailedVM vm = Mapper.Map<LocationDetailedVM>(location);
                vm = SetRating(vm, location);

                return vm;
            }
        }

        private LocationVM SetRating(LocationVM vm, Location location) {
            if(location.Ratings != null) {
                double overall = 0;
                foreach(Rating rating in location.Ratings) {
                    overall += rating.UserRating;
                }
                overall = Math.Round((overall / location.Ratings.Count), 2);
                if(overall > 0 && overall <= 5) {
                    vm.OverAllRating = overall;
                }
            }
            return vm;
        }

        private LocationDetailedVM SetRating(LocationDetailedVM vm, Location location) {
            if(location.Ratings != null) {
                double overall = 0;
                foreach(Rating rating in location.Ratings) {
                    overall += rating.UserRating;
                }
                overall = Math.Round((overall / location.Ratings.Count), 2);
                if(overall > 0 && overall <= 5) {
                    vm.OverAllRating = overall;
                }
            }
            return vm;
        }

        private LocationVM SetOpeningHours(LocationVM vm, Location location) {
            DateTime currDateTime = DateTime.Now;
            FrequentlyOpen open = location.FrequentlyOpens.SingleOrDefault(x => x.DayOfWeek == currDateTime.DayOfWeek);
            if(open != null) {
                // check if open today (= both > 0)
                if(open.OpeningTime > 0 && open.CloseTime > 0) {
                    vm.OpenHours = GetFormatedTime(open.OpeningTime) + " - " + GetFormatedTime(open.CloseTime);
                } else {
                    vm.OpenHours = "";
                }
            }
            return vm;
        }

        [HttpPost]
        public IEnumerable<LocationVM> FindByParameters(LocationSearchVM locationSearch) {
            using(var ctx = new VANContext()) {
                IEnumerable<Location> locations =
                    ctx.Locations.Include("Address").Include("Typ").Include("MusicGenres").Include("FrequentlyOpens").ToList();

                if(locationSearch.Location != "") {
                    locations = locations.Where(x => x.Name.ToLower().Contains(locationSearch.Location.ToLower()));
                }
                if(locationSearch.City != "") {
                    locations = locations.Where(x => x.Address.City.ToLower().Contains(locationSearch.City.ToLower()));
                }
                if(locationSearch.MusicGenre != "") {
                    locations = locations.Where(x => FindMusicGenre(x.MusicGenres, locationSearch.MusicGenre));
                }
                if(locationSearch.Typ != "") {
                    locations = locations.Where(x => x.Typ.Name.Contains(locationSearch.Typ));
                }

                // Filter open locations if needed
                List<Location> filteredLocations = locations.ToList();
                if(locationSearch.IsOpen) {
                    DateTime currDateTime = DateTime.Now;

                    foreach(Location location in locations) {
                        FrequentlyOpen open = location.FrequentlyOpens.SingleOrDefault(x => x.DayOfWeek == currDateTime.DayOfWeek);
                        if(open != null) {
                            // check if open today (= both > 0)
                            if(open.OpeningTime > 0 && open.CloseTime > 0) {
                                int time = (currDateTime.Hour * 100) + currDateTime.Minute;
                                int closingTime = open.CloseTime <= 400 ? open.CloseTime + 3000 : open.CloseTime;
                                if(time < open.OpeningTime || time > closingTime) {
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

        private bool FindMusicGenre(IEnumerable<MusicGenre> musicGenres, string searchString) {
            foreach(MusicGenre musicGenre in musicGenres) {
                if(musicGenre.Name.Contains(searchString)) {
                    return true;
                }
            }
            return false;
        }

        private string GetFormatedTime(int time) {
            return "" + time / 100 + ":" + (time % 100 == 0 ? "00" : "" + time % 100);
        }
    }
}
