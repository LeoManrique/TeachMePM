using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeachMeNET.Models.Entities
{
    public class Teacher
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Age { get; set; }
        public string Degree { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int ToHouse { get; set; }
        public int MyHouse { get; set; }
        public int PublicSpace { get; set; }
        public int Online { get; set; }

        public string LinkedIn { get; set; }
        public string AboutMe { get; set; }

        public string Topic1 { get; set; }
        public int Price1 { get; set; }
        public string Topic2 { get; set; }
        public int Price2 { get; set; }
        public string Topic3 { get; set; }
        public int Price3 { get; set; }
        public string Topic4 { get; set; }
        public int Price4 { get; set; }

    }
}
