using FilmesFrontend.Middleware;
using FilmesFrontend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
 /*Add HttpClient to dependencies, creating and injecting a configured instance of HttpClient into ApiService*/
builder.Services.AddHttpClient<ApiService>(client =>
{
    client.BaseAddress = new Uri("http://filmes-backend:81"); /*Conectando ao container do backend*/
    /*client.BaseAddress = new Uri("http://localhost:7037");*/ /*Backend running localhost (no container)*/
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


// Configura as páginas de erro para diferentes status
app.UseStatusCodePagesWithReExecute("/erro", "?message={0}");
app.UseStatusCodePagesWithReExecute("/acesso-negado", "?message={0}");
app.UseStatusCodePagesWithReExecute("/servico-indisponivel", "?message={0}&details={1}");

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();
app.Run();
