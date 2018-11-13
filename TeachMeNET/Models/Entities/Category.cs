using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeachMeNET.Models.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string NameSpa { get; set; }
        public string NameEng { get; set; }
        public int Popularity { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Updated { get; set; }
        public string UpdatedBy { get; set; }
    }
}
