using ControleDeContatos.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleDeContatos.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext( DbContextOptions<BancoContext> options) : base(options) //uma injeção diferente: options é um tipode DbContextOptions<BancoContext> e vai ser passado através do base para o banco de dados
        {
        }

        public DbSet<ContatoModel> Contatos { get; set; } //Quais as tabelas do be banco de dados

    }
}
