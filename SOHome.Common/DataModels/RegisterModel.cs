using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SOHome.Common.DataModels
{
    public class RegisterModel
    {
        public int Code { get; set; }
        [DisplayName("Nome completo")]
        [Required]
        public string Name { get; set; }
        [DisplayName("CPF / CNPJ")]
        [Required]
        public string Document { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        [Required]
        [StringLength(12, ErrorMessage = "O campo {0} precisa ter pelo menos {2} e no máximo {1} caracteres.",
            MinimumLength = 4)]
        [Display(Name = "Nome de usuário")]
        public string Username { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "A {0} precisa ter pelo menos {2} e no máximo {1} caracteres.",
            MinimumLength = 4)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirmação de senha")]
        [Compare("Password", ErrorMessage = "As senhas não coincidem.")]
        public string ConfirmPassword { get; set; }
    }
}
