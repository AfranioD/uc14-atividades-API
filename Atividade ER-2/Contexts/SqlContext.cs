using Microsoft.EntityFrameworkCore;
using Uc14ER1.Models;

namespace Uc14ER1.Contexts
{
    public class SqlContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public SqlContext(){}

        public SqlContext(DbContextOptions<SqlContext> options) : base(options) {}

        // vamos utilizar esse método para configurar o banco de dados
        protected override void
        OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // cada provedor tem sua sintaxe para specificação
                optionsBuilder.UseSqlServer("Data Source = DESKTOP-6L5SU7Q\\SQLEXPRESS; initial catalog = Chapter; Integrated Security = true");
            }
        }
        // dbset representa as entidades que serão utilizadas nas operações de leitura, criação, atualização e deleção
        public DbSet<Livro> Livros { get; set; }
    }
}
