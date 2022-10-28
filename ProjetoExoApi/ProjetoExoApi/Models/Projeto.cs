namespace ProjetoExoApi.Models
{
    public class Projeto
    {
            public int Id { get; set; }

            public string? Titulo { get; set; }

            public int QuantidadePaginas { get; set; }

            public bool Disponivel { get; set; }
        
    }
}
