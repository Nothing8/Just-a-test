using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.Models;
using System.Collections;


namespace API.Controllers
{
    public class MessageController : ApiController
    {
        // GET: api/Message
        [Route("api/Message/{UserSID}/{user}/{user2}/{zero}")]
        public ArrayList Get(string userSID, string user, string user2, int zero) // Mit csinaál a "zero"?
        {
            //a userSID ellenőrzését valójában itt a controllerben kellene elvégzni.
            MessagePer mp = new MessagePer();
            return mp.getMessages(userSID,user,user2);

        }
       
        //Kikommentezett függvényeket ne hagyj a kódban!

        // GET: api/Message/5
        //public MessageClass Get(int id)
        //{
        //    MessagePer mp = new MessagePer();
        //    MessageClass message = mp.getMessage(id);
        //    return message;
        //}

        // POST: api/Message
        [Route("api/Message/{userSID}/")]
        public void Post(String userSID, [FromBody]MessageClass value)
        {
            MessagePer mp = new MessagePer();
            long id;
            id = mp.saveMessage(userSID,value);
        }

        // PUT: api/Message/5
        public HttpResponseMessage Put(int id, string userSID, [FromBody]MessageClass value)
        {
            MessagePer mp = new MessagePer();
            bool messageExists = false;
            messageExists = mp.SawMessage(id,userSID, value);

            HttpResponseMessage response;
            if (messageExists)
            {
                response = Request.CreateResponse(HttpStatusCode.NoContent);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return response;
        }

        // DELETE: api/Message/5
        public void Delete(int id)
        {
        }
    }
}
