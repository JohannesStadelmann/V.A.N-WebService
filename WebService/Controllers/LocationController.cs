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
                    .Include("MusicGenres")
                    .Include("Ratings")
                    .Include("FrequentlyOpens")
                    .Include("OpenHoursExceptions")
                    .SingleOrDefault(x => x.LocationID == id));
            }
        }
    }
}
