using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FilmesFrontend.Pages.Error;

public class IndexModel : ErrorPageBase
{
    [FromRoute]
    public int? StatusCode { get; set; }

    public IndexModel(IWebHostEnvironment environment) : base(environment)
    {}

    public override void OnGet(string message, string details)
    {
        base.OnGet(message, details);
        if(StatusCode != null)
        {
            ErrorMessage = StatusCode switch
            {
                404 => "Nada por aqui!",
                _ => ErrorMessage
            };
        }
    }        
}
