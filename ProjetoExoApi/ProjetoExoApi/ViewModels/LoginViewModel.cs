using System.ComponentModel.DataAnnotations;

namespace ProjetoExoApi.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe e-mail do usuário")]
        public string email { get; set; }

        [Required(ErrorMessage = "Informe e-mail do usuário")]
        public string senha { get; set; }
    }
}
