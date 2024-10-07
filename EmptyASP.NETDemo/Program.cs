using EmptyASP.NETDemo.Models;
using EmptyASP.NETDemo.ServiceLayer;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddScoped<BookService>();
builder.Services.AddScoped<BooksModel>();
builder.Services.AddScoped<AuthorService>();
builder.Services.AddScoped<AuthorsModel>();

var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    _ = endpoints.MapControllers();
});

app.Run();
