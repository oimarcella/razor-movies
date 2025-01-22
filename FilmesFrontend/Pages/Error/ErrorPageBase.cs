using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FilmesFrontend.Pages.Error
{
    public abstract class ErrorPageBase: PageModel /* class only for heritage*/
    {
        private readonly IWebHostEnvironment _environment;
        public bool IsDevelopment { get; private set; }
        public string ErrorMessage { get; set; }
        [TempData]
        public string ErrorDetails { get; set; } = "";
        public int Statuscode { get; set; }

        public ErrorPageBase(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public virtual void OnGet(string message, string details, int statusCode) /* virtual because can be overrided by child class */
        {
            Statuscode = statusCode;
            IsDevelopment = _environment.EnvironmentName == "Development";
            ErrorMessage = message?? "Algo deu errado";
            ErrorDetails = details?? "Não se preocupe, jé estamos verificando." ;
        }
    }
}
