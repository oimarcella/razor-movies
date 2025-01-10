using FilmesFrontend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;

namespace FilmesFrontend.Pages.Filmes
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient _httpClient;
        public List<Filme> Filmes { get; set; } = new List<Filme>();
        public string ErrorMessage { get; private set; } = "";

        public IndexModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task OnGetAsync()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<List<Filme>>("https://localhost:7037/filme");

                if (response != null)
                {
                    Filmes = response;
                }
                ErrorMessage = "";

            }
            catch (HttpRequestException) {
                ErrorMessage = "Não foi possível se conectar aos serviços.";
            }
        }
    }
}
