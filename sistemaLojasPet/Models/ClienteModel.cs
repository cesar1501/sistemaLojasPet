using System.ComponentModel.DataAnnotations;

namespace sistemaLojasPet.Models
{
    public class ClienteModel
    {
        public static string CurrentUserName { get; }
        [Required]
        public string Nome { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }

        [Compare("Senha")]
        public string ConfirmacaoSenha { get; set; }
    }
}