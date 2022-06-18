using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Model
{
    public class Customer
    {
        [Key]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string StateOfResident { get; set; }
        public string LGA { get; set; }
    }
}
