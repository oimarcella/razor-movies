namespace FilmesFrontend.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient) => _httpClient = httpClient;

        public async Task<T> RequestApiAsync<T> (string endpoint){
            var result = await _httpClient.GetFromJsonAsync<T>(endpoint);
            return result ?? default!; /*return default according type, int - 0, object {} , reference value null*/
        }
    }
}
