using ProjetoExoApi.Contexts;
using ProjetoExoApi.Models;

namespace ProjetoExoApi.Repositories
{
    public class ProjetoRepository
    {
            private readonly SqlContext _context;

            public ProjetoRepository(SqlContext context)
            {
                _context = context;
            }

            public List<Projeto> Listar()
            {
                return _context.Projetos.ToList();
            }

            public Projeto BuscarPorId(int id)
            {
                return _context.Projetos.Find(id);
            }


            public void Cadastrar(Projeto l)
            {
                _context.Projetos.Add(l);

                _context.SaveChanges();
            }


            public void Deletar(int id)
            {
                Projeto l = _context.Projetos.Find(id);

                _context.Projetos.Remove(l);

                _context.SaveChanges();
            }



            public void Alterar(int id, Projeto l)
            {
                Projeto projetoBuscado = _context.Projetos.Find(id);

                if (projetoBuscado != null)
                {
                    projetoBuscado.Titulo = l.Titulo;
                    projetoBuscado.QuantidadePaginas = l.QuantidadePaginas;
                    projetoBuscado.Disponivel = l.Disponivel;

                    _context.Projetos.Update(projetoBuscado);

                    _context.SaveChanges();
                }

            }
     
    }

}
