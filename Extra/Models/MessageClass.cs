using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class MessageClass
    {
        public long ID { get; set; }
        public String Message { get; set; }
        public String Sender { get; set; }
        public String Receiver { get; set; }
        public Boolean Seen { get; set; }



    }
}