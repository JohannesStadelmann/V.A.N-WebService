using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebService.DatabaseContext;
using WebService.Models;
using WebService.ViewModels;

namespace WebService.Controllers
{
    public class UserController : ApiController
    {
        [HttpPost]
        public bool Login(UserVM user)
        {
            using (var ctx = new VANContext())
            {
                User u = ctx.Users.SingleOrDefault(x => x.Username == user.Username && x.Password == user.Password);
                if (u != null)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
