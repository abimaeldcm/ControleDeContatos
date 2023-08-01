using ControleDeContatos.Models;
using System.Collections.Generic;

namespace ControleDeContatos.Repositorio
{
    public interface IUsuarioRepositorio
    {
        bool BuscarUsuario(UsuarioModel login);
        List<UsuarioModel> BuscarTodos();
        UsuarioModel ListarPorId(int id);

        UsuarioModel BuscarUsuarioo(UsuarioModel login);
        UsuarioModel Adicionar(UsuarioModel usuario);
        UsuarioModel Atualizar(UsuarioModel usuario);   
        bool Apagar(int id);
    }
}
