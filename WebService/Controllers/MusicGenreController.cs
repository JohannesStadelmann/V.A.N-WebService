using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using WebService.DatabaseContext;
using WebService.Models;
using WebService.ViewModels;

namespace WebService.Controllers {
    public class MusicGenreController: ApiController {
        [HttpGet]
        public IEnumerable<MusicGenreVM> GetAll() {
            using(var ctx = new VANContext()) {
                List<MusicGenre> list = new List<MusicGenre>();
                foreach(MusicGenre genre in ctx.MusicGenres.ToList()) {
                    if(list.FirstOrDefault(x => x.Name == genre.Name) == null) {
                        list.Add(genre);
                    }
                }
                return Mapper.Map<IEnumerable<MusicGenreVM>>(list);
            }
        }
    }
}
