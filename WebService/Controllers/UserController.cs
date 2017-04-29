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

namespace WebService.Controllers
{
    public class UserController : ApiController
    {
        [HttpPost]
        public User Login(UserVM user)
        {
            using (var ctx = new VANContext())
            {
                return ctx.Users.SingleOrDefault(x => x.Username == user.Username && x.Password == user.Password);
            }
        }

        [HttpPost]
        public UserVM Register(UserVM user) {
            using(var ctx = new VANContext()) {
                User u = ctx.Users.SingleOrDefault(x => x.Username == user.Username);
                if(u == null)
                {
                    User newUser = Mapper.Map<User>(user);
                    ctx.Users.Add(newUser);
                    ctx.SaveChanges();
                    return Mapper.Map<UserVM>(newUser);
                }
                return null;
            }
        }
    }
}
