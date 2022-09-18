using Microsoft.Data.SqlClient.Server;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agenda.Models
{ 
    public class Contato
    {

        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Nome { get; set; } 
        [Required(ErrorMessage = "Email é obrigatório")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Telefone é obrigatório")]
        [Display(Name = "Telefone")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(15)]
        [DisplayFormat(DataFormatString = "{0:(##) #####-####}", ApplyFormatInEditMode = true)]
        public string Telefone { get; set; }
    }

}
