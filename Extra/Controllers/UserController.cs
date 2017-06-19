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
        [Route("api/User/{UserSID}/{zero}")]
        public List<string> Get(string UserSID, int zero) // Mit csinál a "zero"?
        {
            UserPer user = new UserPer();
            return user.getUsers(UserSID);          
        }
        [Route("api/User/{UserSID}/{zero}/{one}")]
        // GET: api/Default/5
        public string Get(string UserSID, int zero, int one) // Mit csinál a "zero" és a "one"?
        {
            UserPer up = new UserPer();
            return up.getUser(UserSID);
        }

        // POST: api/Default
        [Route("api/User/{userName}/{password}")]
        public string Post(string userName, string password)
        {
            UserPer up = new UserPer();
            string sessionID = up.postSID(userName, password);
            return sessionID;
        }

        //Ez a függvény fölösleges.
        // PUT: api/Default/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Default/5
        [Route("api/User/{SID}/{zero}")]
        public void Delete(string SID, int zero, [FromBody]int value) // Mit csinál a "zero"?
        {
            UserPer u = new UserPer();
            u.DeleteSID(SID);
        }
    }
}
