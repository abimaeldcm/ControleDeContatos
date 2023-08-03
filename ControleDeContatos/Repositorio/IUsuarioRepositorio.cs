using ControleDeContatos.Models;
using System.Collections.Generic;

namespace ControleDeContatos.Repositorio
{
    public interface IUsuarioRepositorio
    {
        bool BuscarUsuario(UsuarioModel login);
        UsuarioModel BuscarUsuarioEmailLogin(string email, string Login);
        List<UsuarioModel> BuscarTodos();
        UsuarioModel ListarPorId(int id);

        UsuarioModel BuscarUsuarioo(UsuarioModel login);
        UsuarioModel Adicionar(UsuarioModel usuario);
        UsuarioModel Atualizar(UsuarioModel usuario);
        UsuarioModel AlterarSenha(AlterarSenhaModel alterarSenhaModel);
        bool Apagar(int id);
    }
}
