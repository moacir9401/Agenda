using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Agenda.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> option) : base(option)
        {
            CarregarUsuarios();
        }

        public DbSet<Usuario> Usuarios { get; set; }


        private void CarregarUsuarios()
        {
            if (!Usuarios.Any())
            {
                Usuarios.Add(new Usuario() { Id = 1, Email = "moacir@gmail.com", Nome = "moacir", Senha = "1234" });
                Usuarios.Add(new Usuario() { Id = 2, Email = "dayane@gmail.com", Nome = "dayane", Senha = "15984" });
                Usuarios.Add(new Usuario() { Id = 3, Email = "ewerton@gmail.com", Nome = "ewerton", Senha = "4321" });
                Usuarios.Add(new Usuario() { Id = 4, Email = "maria@gmail.com", Nome = "mario", Senha = "asde32" });


                SaveChanges();
            }

        }
    }
}
