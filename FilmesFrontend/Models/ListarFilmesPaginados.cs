namespace FilmesFrontend.Models
{
    public class ListarFilmesPaginados
    {
        public List<Filme> Filmes { get; set; }
        public int TotalPaginas { get; set; }
        public int PaginaAtual { get; set; }
    }
}
