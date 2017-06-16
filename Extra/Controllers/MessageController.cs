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
        public ArrayList Get()
        {
            MessagePer mp = new MessagePer();
            return mp.getMessages();

        }

        // GET: api/Message/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Message
        public void Post(MessageClass value)
        {
            MessagePer mp = new MessagePer();
            long id;
            id = mp.saveMessage(value);
        }

        // PUT: api/Message/5
        public HttpResponseMessage Put(int id, [FromBody]MessageClass value)
        {
            MessagePer mp = new MessagePer();
            bool messageExists = false;
            messageExists = mp.SawMessage(id, value);

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
