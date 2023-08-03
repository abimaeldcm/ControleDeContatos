using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class AlterarSenhaModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public string SenhaAtual { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public string NovaSenha { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        [Compare("NovaSenha", ErrorMessage ="As senhas são divergentes")]
        public string ConfirmarNovaSenha { get; set; }
        
    }
}
