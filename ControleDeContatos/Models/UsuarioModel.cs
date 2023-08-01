using ControleDeContatos.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome do usuário")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o login do usuário")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Digite o e-mail do contato")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Escolha o perfil do usuário")]
        public PerfilEnum? Perfil { get; set; }

        [Required(ErrorMessage = "Digite o senha do usuário")]
        public string Senha { get; set; }

        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualização { get; set; }
    }
}
