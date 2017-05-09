using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using WebService.DatabaseContext;
using WebService.Models;
using WebService.ViewModels;

namespace WebService.Controllers {
    public class RatingController: ApiController {
        [HttpPost]
        public String RateLocation(int id, RatingVM rating) {
            Rating r = Mapper.Map<Rating>(rating);
            using(var ctx = new VANContext()) {
                Location location = ctx.Locations.Include("Ratings").Include("Ratings.User").SingleOrDefault(x => x.LocationID == id);
                if(location != null) {
                    Rating existingRating = location.Ratings.SingleOrDefault(x => x.User.UserId == rating.User.UserId);
                    if(existingRating != null) {
                        existingRating.UserRating = rating.UserRating;
                        existingRating.Comment = rating.Comment;
                        existingRating.Date = DateTime.Now;
                        ctx.SaveChanges();
                        return "Changed";
                    } else {
                        r.Date = DateTime.Now;
                        ctx.Entry(r.User).State = EntityState.Unchanged;
                        location.Ratings.Add(r);
                        ctx.SaveChanges();
                        return "Created";
                    }
                }
                return "Error";
            }
        }

        [HttpGet]
        public IEnumerable<RatingVM> GetAllByLocation(int id) {
            using(var ctx = new VANContext()) {
                Location location = ctx.Locations.Include("Ratings").SingleOrDefault(x => x.LocationID == id);
                if(location != null) {
                    List<Rating> ratings = new List<Rating>();
                    foreach(Rating rating in location.Ratings) {
                        ratings.Add(ctx.Ratings.Include("User").SingleOrDefault(x => x.RatingID == rating.RatingID));
                    }

                    return Mapper.Map<IEnumerable<RatingVM>>(ratings);
                }
                return null;
            }
        }

        [HttpGet]
        public IEnumerable<RatingVM> GetTop3ByLocation(int id) {
            using(var ctx = new VANContext()) {
                Location location = ctx.Locations.Include("Ratings").SingleOrDefault(x => x.LocationID == id);
                if(location != null) {
                    List<Rating> ratings = new List<Rating>();
                    foreach(Rating rating in location.Ratings) {
                        ratings.Add(ctx.Ratings.Include("User").SingleOrDefault(x => x.RatingID == rating.RatingID));
                    }
                    List<Rating> sortedList = ratings.OrderByDescending(x => x.Date).Take(3).ToList();
                    return Mapper.Map<IEnumerable<RatingVM>>(sortedList);
                }
                return null;
            }
        }
    }
}
