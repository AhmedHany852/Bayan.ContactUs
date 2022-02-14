using System;
using System.Collections.Generic;
using System.Text;

namespace Bayan.ContactUs.Data.Entity
{
    public class Contactus
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
