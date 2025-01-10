namespace FilmesFrontend.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient) => _httpClient = httpClient;

        public async Task<T> RequestApiAsync<T> (string endpoint){
            return await _httpClient.GetFromJsonAsync<T>(endpoint);
        }
    }
}
