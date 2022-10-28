using ProjetoExoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjetoExoApi.Contexts
{
    public class SqlContext : DbContext
    {
        public SqlContext() { }
        public SqlContext(DbContextOptions<SqlContext> options) : base(options) { }


        // vamos utilizar esse método para configurar o banco de dados
        protected override void
            OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                if (!optionsBuilder.IsConfigured)
                {
                    // cada provedor tem sua sintaxe para especificação
                    optionsBuilder.UseSqlServer("Data Source = SHEY\\SQLEXPRESS; initial catalog = Projeto; Integrated Security = true");
                    // optionsBuilder.UseSqlServer("Data Source = SHEY\\SQLEXPRESS; initial catalog = Chapter; User Id = Shey; Password = tvd4ever");
                }
            }
            // dbset representa as entidades que serão utilizadas nas operações de leitura, criação, atualização e deleção
            public DbSet<Projeto>? Projetos { get; set; }

            public DbSet<Usuario> Usuarios { get; set; }
    }
}
