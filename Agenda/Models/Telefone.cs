using System.ComponentModel.DataAnnotations.Schema;

namespace Agenda.Models
{
    [Table("Usuario")]
    public class Contato
    {

        [Column("Id")]
        public int Id { get; set; }
        [Column("Email")]
        public string Nome { get; set; } 
        [Column("Telefone")]
        public string Email { get; set; }
        [Column("Nome")]
        public string Telefone { get; set; }
    }

}
