using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "O 'E-mail' deve ser preenchido.")]
        [MinLength(10, ErrorMessage = "O 'E-mail' deve ter no mínimo 10 caracteres.")]
        [MaxLength(100, ErrorMessage = "O 'E-mail' deve ter no máximo 100 caracteres.")]
        [EmailAddress(ErrorMessage = "O 'E-mail' deve ser válido")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A 'Senha' deve ser preenchida.")]
        [MinLength(6, ErrorMessage = "A 'Senha' deve ter no mínimo 6 caracteres.")]
        [MaxLength(20, ErrorMessage = "A 'Senha' deve ter no máximo 20 caracteres.")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Required(ErrorMessage = "A 'Confirmação da senha' deve ser preenchida.")]
        [MinLength(6, ErrorMessage = "A 'Confirmação da senha' deve ter no mínimo 6 caracteres")]
        [MaxLength(20, ErrorMessage = "A 'Confirmação da senha' deve ter no máximo 20 caracteres")]
        [Compare("Password", ErrorMessage = "A 'Confirmação da senha' deve ser igual a 'Senha'")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmação de senha")]
        public string ConfirmPassword { get; set; }
    }
}