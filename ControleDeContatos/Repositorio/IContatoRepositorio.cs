using ControleDeContatos.Models;
using System.Collections.Generic;

namespace ControleDeContatos.Repositorio
{
    public interface IContatoRepositorio
    {
        ContatoModel Atualizar(ContatoModel contato);
        ContatoModel ListarPorId(int id);
        List<ContatoModel> BuscarTodos(int id);
        ContatoModel Adicionar(ContatoModel contato);
        bool Apagar(int id);
    }
}
