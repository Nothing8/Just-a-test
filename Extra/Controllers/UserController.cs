using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Collections;
using API.Models;

namespace API.Controllers
{
    public class UserController : ApiController
    {
        // GET: api/Default
        public ArrayList Get()
        {
            UserPer up = new UserPer();
            return up.getUsers();
        }

        // GET: api/Default/5
        public UserClass Get(long id)
        {
            UserPer up = new UserPer();
            UserClass user = up.getUser(id);
            return user;
        }

        // POST: api/Default
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Default/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Default/5
        public void Delete(int id)
        {
        }
    }
}
