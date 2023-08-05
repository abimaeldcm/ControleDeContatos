using ControleDeContatos.Enums;
using ControleDeContatos.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Runtime.Intrinsics.X86;

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
        public void SetSenhaHash() //Criptografar a minha senha.
        {
            Senha = Senha.GerarHash();
        }

        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualização { get; set; }
        public string GerarNovaSenha()
        {
            string novaSenha = Guid.NewGuid().ToString().Substring(0,8);
            //Guid.NewGuid(): A função Guid.NewGuid() gera um identificador único global (GUID), que é um valor
            //aleatório e único.
            //.ToString(): Converte o valor GUID gerado em uma representação de string.
            //.Substring(0, 8): Isso extrai os primeiros 8 caracteres da string gerada pelo GUID.
            //Isso significa que a senha será composta pelos primeiros 8 caracteres do valor GUID,
            //tornando-a uma senha aleatória de 8 caracteres.

            Senha = novaSenha.GerarHash();
            return novaSenha;
        }
    }
}
