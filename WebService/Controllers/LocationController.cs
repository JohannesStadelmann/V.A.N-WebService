using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebService.DatabaseContext;
using WebService.Models;

namespace WebService.Controllers
{
    public class LocationController : ApiController {

        [HttpGet]
        public IEnumerable<Location> GetAll() {
            using (var ctx = new VANContext()) {
                return ctx.Locations
                    .Include("Address")
                    .Include("MusicGenres")
                    .Include("Ratings")
                    .Include("FrequentlyOpens")
                    .Include("OpenHoursExceptions")
                    .ToList();
            }
        }

        
        [HttpGet]
        public Location GetById(int id) {
            using(var ctx = new VANContext()) {
                return ctx.Locations
                    .Include("Address")
                    .Include("MusicGenres")
                    .Include("Ratings")
                    .Include("FrequentlyOpens")
                    .Include("OpenHoursExceptions")
                    .SingleOrDefault(x => x.LocationID == id);
            }
        }

        [HttpGet]
        public string GetTestString()
        {
            return "It works";
        }
        
    }
}
