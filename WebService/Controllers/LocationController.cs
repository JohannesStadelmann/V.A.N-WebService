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

        [HttpGet]
        public IEnumerable<LocationVM> FindByParameters(LocationSearchVM locationSearch)
        {
            using(var ctx = new VANContext())
            {
                locationSearch.Location = locationSearch.Location == null ? "*" : locationSearch.Location;
                locationSearch.City = locationSearch.City == null ? "*" : locationSearch.City;
                locationSearch.MusicGenre = locationSearch.MusicGenre == null ? "*" : locationSearch.MusicGenre;
                locationSearch.Typ = locationSearch.Typ == null ? "*" : locationSearch.Typ;


                return Mapper.Map<IEnumerable<LocationVM>>(ctx.Locations.Include("Address").Include("Typ").Where(x =>
                            x.Name == locationSearch.Location && 
                            x.Address.City == locationSearch.City &&
                            x.Typ.Name == locationSearch.Typ).ToList());
            }
        }
    }
}
