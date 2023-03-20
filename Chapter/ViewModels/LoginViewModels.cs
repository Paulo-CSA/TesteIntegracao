using System.ComponentModel.DataAnnotations;

namespace Chapter.ViewModels
{
    public class LoginViewModels
    {
        [Required(ErrorMessage = "O e-mail é Obrigatorio")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A Senha é Obrigatoria")]
        public string Senha { get; set; }
    }
}
