using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FilmesFrontend.Pages.Error;

public class IndexModel : ErrorPageBase
{
    [FromRoute]
    public bool IsNotFoundStatus { get; set; } = false;
    public IndexModel(IWebHostEnvironment environment) : base(environment)
    {}

    public override void OnGet(string message, string details, int statusCode)
    {
        base.OnGet(message, details, statusCode);

        if(Statuscode != 0)
        {
            if(Statuscode == 404)
            {
                IsNotFoundStatus = true;
                ErrorMessage = "Nada por aqui!";
            };
        }
    }        
}
