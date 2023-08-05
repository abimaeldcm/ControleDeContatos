using ControleDeContatos.Data;
using ControleDeContatos.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace ControleDeContatos.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _bancoContext;
        public ContatoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public ContatoModel ListarPorId(int id)
        {
            return _bancoContext.Contatos.FirstOrDefault(c => c.Id == id);
        }

        public List<ContatoModel> BuscarTodos(int id)
        {
            return _bancoContext.Contatos.Where(x => x.UsuarioId == id).ToList();
            
        }

        public ContatoModel Adicionar(ContatoModel contato)
        {
            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();
            return contato;
        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contatoDB = ListarPorId(contato.Id);
            if (contatoDB == null )
            {
                throw new Exception("Houve um erro na atualização do banco");
            }
            contatoDB.Email = contato.Email;
            contatoDB.Celular = contato.Celular;
            contatoDB.Nome = contato.Nome;

            _bancoContext.Contatos.Update(contatoDB);
            _bancoContext.SaveChanges();

            return contatoDB;
        }

        public bool Apagar(int id)
        {
            ContatoModel contatoDB = ListarPorId(id);
            if (_bancoContext.Contatos == null)
            {
                throw new Exception("Houve um erro na deleção do banco");
            }
            _bancoContext.Contatos.Remove(contatoDB);
            _bancoContext.SaveChanges();
            return true;
        }
    }
}