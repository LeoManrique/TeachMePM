using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeachMeNET.Models.Entities
{
    public class Student
    {

        public int Id { get; set; }
        public int UserId { get; set; }
        public int Age { get; set; }
        public string SchoolType { get; set; }

        public string Interest1 { get; set; }
        public string Interest2 { get; set; }
        public string Interest3 { get; set; }

    }
}
