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
                    ctx.Locations.Include("Address").Include("Typ").Include("MusicGenres").ToList();

                if (locationSearch.Location != "")
                {
                    locations = locations.Where(x => x.Name == locationSearch.Location);
                }
                if (locationSearch.City != "")
                {
                    locations = locations.Where(x => x.Address.City == locationSearch.City);
                }
                /*
                if(locationSearch.MusicGenre != "") {
                    locations = locations.Where(x => x.MusicGenres.Where(y => y.Name == locationSearch.MusicGenre) != null);
                }
                */
                if(locationSearch.Typ != "") {
                    locations = locations.Where(x => x.Typ.Name == locationSearch.Typ);
                }

                return Mapper.Map<IEnumerable<LocationVM>>(locations);
            }
        }
    }
}
