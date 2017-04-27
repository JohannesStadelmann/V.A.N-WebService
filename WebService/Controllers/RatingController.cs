using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using WebService.DatabaseContext;
using WebService.Models;
using WebService.ViewModels;

namespace WebService.Controllers
{
    public class RatingController : ApiController
    {
        [HttpPost]
        public bool RateLocation(int id, RatingVM rating)
        {
            using (var ctx = new VANContext())
            {
                Location location = ctx.Locations.Include("Ratings").SingleOrDefault(x => x.LocationID == id);
                if (location != null)
                {
                    rating.Date = DateTime.Now;
                    location.Ratings.Add(Mapper.Map<Rating>(rating));
                    ctx.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        [HttpGet]
        public IEnumerable<RatingVM> GetAllByLocation(int id)
        {
            using (var ctx = new VANContext())
            {
                Location location = ctx.Locations.Include("Ratings").SingleOrDefault(x => x.LocationID == id);
                if (location != null)
                {
                    return Mapper.Map<IEnumerable<RatingVM>>(location.Ratings.ToList());
                }
                return null;
            }
        }
    }
}
