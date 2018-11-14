using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public Boolean ToHouse { get; set; }
        public Boolean MyHouse { get; set; }
        public Boolean PublicSpace { get; set; }
        public Boolean Online { get; set; }

        public string LinkedIn { get; set; }
        [MaxLength(200)]
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
