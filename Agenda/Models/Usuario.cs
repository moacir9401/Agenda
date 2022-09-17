using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agenda.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("Email")]
        [Required(ErrorMessage = "Email é obrigatório")]
        public string Email { get; set; }
        [Column("Nome")]
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Nome { get; set; }
        [Column("Senha")]
        [Required(ErrorMessage = "Senha é obrigatório")]
        public string Senha { get; set; }
    }
}
