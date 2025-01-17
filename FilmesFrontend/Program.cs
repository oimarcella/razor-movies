using FilmesFrontend.Middleware;
using FilmesFrontend.Services;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Net.Sockets;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
 /*Add HttpClient to dependencies, creating and injecting a configured instance of HttpClient into ApiService*/
builder.Services.AddHttpClient<ApiService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7037");
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


// Configura as p�ginas de erro para diferentes status
app.UseStatusCodePagesWithReExecute("/erro", "?message={0}");
app.UseStatusCodePagesWithReExecute("/acesso-negado", "?message={0}");
app.UseStatusCodePagesWithReExecute("/servico-indisponivel", "?message={0}&details={1}");

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();
app.Run();
