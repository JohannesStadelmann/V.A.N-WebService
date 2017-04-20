using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using WebService.DatabaseContext;
using WebService.ViewModels;

namespace WebService.Controllers
{
    public class LocationTypController : ApiController
    {
        [HttpGet]
        public IEnumerable<TypVM> GetAll() {
            using(var ctx = new VANContext()) {
                return Mapper.Map<IEnumerable<TypVM>>(ctx.Typs.ToList());
            }
        }
    }
}
