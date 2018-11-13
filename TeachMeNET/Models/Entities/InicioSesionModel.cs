using System.ComponentModel.DataAnnotations;

namespace TeachMeNET.Models.Entities
{
    public class InicioSesionModel
    {
        public int Id { get; set; }//me salia error sin un id,  solo lo puse para que no salga el error 

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }
    }
}