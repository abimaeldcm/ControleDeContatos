using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace ControleDeContatos.Data
{
    public class Seeding
    {
        private readonly BancoContext _bancoContext;
        public Seeding(BancoContext context)
        {
            _bancoContext = context;
        }

        public void Seend()
        {
            if (!_bancoContext.Contatos.Any())
            {
                var semear = new List<ContatoModel>
                {
                    new ContatoModel { Nome="Abimael Mendes", Email="abimael@gmail.com", Celular="86995287888"},
                    new ContatoModel { Nome="João da Silva", Email="joao.silva@example.com", Celular="5551234567"},
                    new ContatoModel { Nome="Maria Souza", Email="maria.souza@example.com", Celular="9999876543"},
                    new ContatoModel { Nome="Carla Santos", Email="carla.santos@example.com", Celular="4445556666"},
                    new ContatoModel { Nome="Pedro Almeida", Email="pedro.almeida@example.com", Celular="5555555555"},
                    new ContatoModel { Nome="Fernanda Rodrigues", Email="fernanda.rodrigues@example.com", Celular="3333333333"},
                    new ContatoModel { Nome="Ricardo Pereira", Email="ricardo.pereira@example.com", Celular="7777777777"},
                    new ContatoModel { Nome="Juliana Oliveira", Email="juliana.oliveira@example.com", Celular="1111111111"},
                    new ContatoModel { Nome="Lucas Costa", Email="lucas.costa@example.com", Celular="6666666666"},
                    new ContatoModel { Nome="Sandra Lima", Email="sandra.lima@example.com", Celular="2222222222"},
                    new ContatoModel { Nome="Mariana Castro", Email="mariana.castro@example.com", Celular="8888888888"},
                    new ContatoModel { Nome="Roberto Ferreira", Email="roberto.ferreira@example.com", Celular="4444444444"},
                    new ContatoModel { Nome="Gustavo Almeida", Email="gustavo.almeida@example.com", Celular="1212121212"},
                    new ContatoModel { Nome="Carolina Fernandes", Email="carolina.fernandes@example.com", Celular="7897897890"},
                    new ContatoModel { Nome="Henrique Castro", Email="henrique.castro@example.com", Celular="9876543210"},
                    new ContatoModel { Nome="Patrícia Martins", Email="patricia.martins@example.com", Celular="1231231234"},
                    new ContatoModel { Nome="Diego Lima", Email="diego.lima@example.com", Celular="4564564567"},
                    new ContatoModel { Nome="Larissa Souza", Email="larissa.souza@example.com", Celular="8899001122"},
                    new ContatoModel { Nome="Thiago Fernandes", Email="thiago.fernandes@example.com", Celular="0123456789"},
                    new ContatoModel { Nome="Ana Fernandes", Email="ana.fernandes@example.com", Celular="3456789012"}


                };

                _bancoContext.AddRange(semear);
                _bancoContext.SaveChanges();
            }
        }
    }
}
