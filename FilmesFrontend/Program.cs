using FilmesFrontend.Middleware;
using FilmesFrontend.Services;

const string BACKEND_COMPOSE = "http://filmes-backend:81"; /*Backend running docker*/
const string BACKEND_LOCAL = "https://localhost:7037"; /*Backend running localhost*/

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
 /*Add HttpClient to dependencies, creating and injecting a configured instance of HttpClient into ApiService*/
builder.Services.AddHttpClient<ApiService>(client =>
{
    client.BaseAddress = new Uri(BACKEND_LOCAL);
});

var app = builder.Build();


app.UseMiddleware<CustomExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error/Index");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


// Configure pages for different status codes
app.UseStatusCodePagesWithReExecute("/erro", "?message={0}");
app.UseStatusCodePagesWithReExecute("/acesso-negado", "?message={0}");
app.UseStatusCodePagesWithReExecute("/servico-indisponivel", "?message={0}&details={1}");
app.UseStatusCodePagesWithReExecute("/erro", "?statusCode={0}"); /*to pass status code (404)*/


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();
app.Run();
