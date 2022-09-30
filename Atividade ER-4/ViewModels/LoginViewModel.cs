using System.ComponentModel.DataAnnotations;

namespace Uc14ER1.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe o e-mail do usuario")]
        public string email { get; set; }

        [Required(ErrorMessage = "Informe a senha do usurario")]

        public string senha { get; set; }
    }
}
