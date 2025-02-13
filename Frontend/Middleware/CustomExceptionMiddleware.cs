using System.Net.Sockets;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace FilmesFrontend.Middleware;
public class CustomExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public CustomExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            // Continua para o próximo middleware
            await _next(context);
        }
        catch (Exception ex) when (ex is UnauthorizedAccessException)
        {
            var statusCode = Uri.EscapeDataString(context.Response.StatusCode.ToString());
            context.Response.StatusCode = 403;

            var mensagemErro = Uri.EscapeDataString("Recurso restrito.");
            context.Response.Redirect($"/acesso-negado?message={mensagemErro}");
        }
        catch (Exception ex) when (ex is SocketException || ex is HttpRequestException)
        {
            var statusCode = Uri.EscapeDataString(context.Response.StatusCode.ToString());
            // Define status 503 para erro de conexão
            context.Response.StatusCode = 503;

            // Codifica a mensagem e detalhes da exceção para a `query string`
            var errorMessageException = Uri.EscapeDataString(ex.Message);
            var detailsErrorException = Uri.EscapeDataString(ex.ToString());

            // Redireciona para a página /erro-interno com os detalhes da exceção
            context.Response.Redirect($"/servico-indisponivel?message={errorMessageException}&details={detailsErrorException}&status={statusCode}");
        }
        catch (Exception ex)
        {
            var statusCode = Uri.EscapeDataString(context.Response.StatusCode.ToString());
            // Define o status como 500 para outras exceções genéricas
            context.Response.StatusCode = 500;

            // Codifica a mensagem e detalhes da exceção
            var errorMessageException = Uri.EscapeDataString(ex.Message);
            var detailsErrorException = Uri.EscapeDataString(ex.ToString());

            // Redireciona para a página de erro genérica
            context.Response.Redirect($"/erro?message={errorMessageException}&details={detailsErrorException}&status={statusCode}");
        }
    }
}
