using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace API.Models
{
    public class UserClass
    {
        public long ID { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }

        public String SessionID { get; set; }
    }
}