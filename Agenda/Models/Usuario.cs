using System.ComponentModel.DataAnnotations.Schema;

namespace Agenda.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("Email")]
        public string Email { get; set; }
        [Column("Nome")]
        public string Nome { get; set; }
        [Column("Senha")]
        public string Senha { get; set; }
    }
}
