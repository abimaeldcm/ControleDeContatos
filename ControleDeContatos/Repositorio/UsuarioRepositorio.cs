using ControleDeContatos.Data;
using ControleDeContatos.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using ControleDeContatos.Enums;
using ControleDeContatos.Helper;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ControleDeContatos.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContext _bancoContext;
        public UsuarioRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public bool BuscarUsuario(UsuarioModel login)
        {
            return _bancoContext.Usuarios.Any(x => x.Login == login.Login && x.Senha == login.Senha.GerarHash());
            
        }
        
        public UsuarioModel BuscarUsuarioo(UsuarioModel login)
        {

            return _bancoContext.Usuarios.FirstOrDefault(x => x.Login == login.Login && x.Senha == login.Senha.GerarHash());
            
        }

        public UsuarioModel ListarPorId(int id)
        {
            return _bancoContext.Usuarios.FirstOrDefault(c => c.Id == id);
        }

        public List<UsuarioModel> BuscarTodos()
        {
            return _bancoContext.Usuarios.ToList();
        }

        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            usuario.DataCadastro = DateTime.Now;
            usuario.SetSenhaHash(); //Criptografar a minha senha usando Sha1
            _bancoContext.Usuarios.Add(usuario);
            _bancoContext.SaveChanges();
            return usuario;
        }

        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            UsuarioModel usuarioDB = ListarPorId(usuario.Id);
            if (usuarioDB == null )
            {
                throw new Exception("Houve um erro na atualização do usuário");
            }
            usuarioDB.Email = usuario.Email;            
            usuarioDB.Nome = usuario.Nome;
            usuarioDB.Login = usuario.Login;
            usuarioDB.DataAtualização = DateTime.Now;
            usuarioDB.Perfil = usuario.Perfil;


            _bancoContext.Usuarios.Update(usuarioDB);
            _bancoContext.SaveChanges();

            return usuarioDB;
        }

        public bool Apagar(int id)
        {
            UsuarioModel usuarioDB = ListarPorId(id);
            if (_bancoContext.Usuarios == null)
            {
                throw new Exception("Houve um erro na deleção do banco");
            }
            _bancoContext.Usuarios.Remove(usuarioDB);
            _bancoContext.SaveChanges();
            return true;
        }

        public UsuarioModel BuscarUsuarioEmailLogin(string email, string Login)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Email == email && x.Login == Login);
        }
    }
}