using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Uc14ER1.Contexts;
using Uc14ER1.Models;

namespace Uc14ER1.Repositories
{
    public class LivroRepository
    {
        private readonly SqlContext _context;
        public LivroRepository(SqlContext context)
        {
           _context = context;
        }

        public List<Livro>Listar()
        {
            return _context.Livros.ToList();
        }
            
    }
}
