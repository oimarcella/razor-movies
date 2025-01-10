using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FilmesFrontend.Pages.Error
{
    public abstract class ErrorPageBase:PageModel
    {
        private readonly IWebHostEnvironment _environment;
        public bool IsDevelopment { get; private set; }
        public string ErrorMessage { get; set; }
        [TempData]
        public string ErrorDetails { get; set; } = "";

        public ErrorPageBase(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public virtual void OnGet(string message, string details)
        {
            IsDevelopment = _environment.EnvironmentName == "Development";
            ErrorMessage = message ?? "Erro inesperado";
            ErrorDetails = details ?? "Algo aconteceu, estamos trabalhando para verificar.";
        }
    }
}
