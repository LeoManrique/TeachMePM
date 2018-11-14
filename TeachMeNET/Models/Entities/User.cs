using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using TeachMeNET.Models.Entities;

namespace TeachMeNET.Models
{
    public class User
    {
		[BindProperty]
		public InicioSesionModel Input { get; set; }
        public int InicioSesionId { get; set; }

		public int Id { get; set; }
        //public String Email { get; set; }
        public String UserName { get; set; }
        //public String Password { get; set; }
        [Required]
        public String Name1 { get; set; }
        public String Name2 { get; set; }
        public String Name3 { get; set; }
        public String PrefName { get; set; }
        [Required]
        public String LastName1 { get; set; }
        public String LastName2 { get; set; }
        public String Confirmed { get; set; }
        public String StudentFlag { get; set; }
        public String TeacherFlag { get; set; }
        public DateTime LastLogin { get; set; }
        public DateTime Created { get; set; }
        public String CreatedBy { get; set; }
        public DateTime Updated { get; set; }
        public String UpdatedBy { get; set; }

    }
}