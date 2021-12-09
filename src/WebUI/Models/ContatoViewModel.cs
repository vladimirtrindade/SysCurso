using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class ContatoViewModel
    {
        public List<TelefoneViewModel> LstTelefoneViewModel { get; } = new List<TelefoneViewModel>();
        public int Id { get; set; }

        [Required(ErrorMessage = "Insira o Nome")]
        [MinLength(3, ErrorMessage = "O Nome deve ter pelo menos 3 caracteres")]
        [MaxLength(100, ErrorMessage = "O Nome deve ter no máximo 100 caracteres")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Insira o Sobrenome")]
        [MinLength(3, ErrorMessage = "O Sobrenome deve ter pelo menos 3 caracteres")]
        [MaxLength(100, ErrorMessage = "O Sobrenome deve ter no máximo 100 caracteres")]
        [Display(Name = "Sobrenome")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "Insira o E-mail")]
        [MinLength(10, ErrorMessage = "O E-mail deve ter pelo menos 3 caracteres")]
        [MaxLength(100, ErrorMessage = "O E-mail deve ter no máximo 100 caracteres")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
    }
}