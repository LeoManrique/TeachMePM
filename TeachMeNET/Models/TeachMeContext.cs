using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeachMeNET.Models.Entities;
using static Microsoft.AspNetCore.Identity.UI.Pages.Account.Internal.ExternalLoginModel;

namespace TeachMeNET.Models
{
    public class TeachMeContext : DbContext
    {
        public TeachMeContext(DbContextOptions<TeachMeContext> options)
        : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                /*new Banda
                {
                    Id = 1,
                    Nombre = "Link in Park",
                    Foto = "https://i.kym-cdn.com/photos/images/newsfeed/000/937/730/e9a.jpg"
                },
                new Banda
                {
                    Id = 2,
                    Nombre = "BTS",
                    Foto = "https://multimedia.larepublica.pe/720x405/larepublica/imagen/2018/10/16/noticia-peli-bts-burn-stage.jpg"
                }*/
            );
        }

        public DbSet<User> Users { get; set; }
        public DbSet<InicioSesionModel> InicioSesiones { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
    }
}