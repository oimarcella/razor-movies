using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FilmesFrontend.Pages.Error
{
    public class UnauthorizedModel : ErrorPageBase
    {
        public UnauthorizedModel(IWebHostEnvironment environment) : base(environment)
        {}
    }
}
