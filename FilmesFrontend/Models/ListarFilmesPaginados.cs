namespace FilmesFrontend.Models
{
    public class ListarFilmesPaginados
    {
        public List<Filme> Filmes { get; set; } = new List<Filme>();
        public int TotalPaginas { get; set; } = 0;
        public int PaginaAtual { get; set; } = 1;
    }
}
