using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class Contato
    {
        public int Id { get; set; }

        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Display(Name = "Sobrenome")]
        public string Sobrenome { get; set; }

        [Display(Name = "E-mail")]
        public string Email { get; set; }
    }
}