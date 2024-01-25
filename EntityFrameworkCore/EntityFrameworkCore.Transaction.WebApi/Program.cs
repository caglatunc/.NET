using EntityFrameworkCore.Transaction.WebApi.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetSection("SqlServer").Value);
    options.LogTo(Console.WriteLine, LogLevel.Information);
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope= app.Services.CreateScope())
{
    var context =scope.ServiceProvider.GetRequiredService<AppDbContext>();//Buras� Middleware de DbContext'i constructorda �nject etm�s gibi elde edilmesini sa�lar.
    context.Database.Migrate();//Migrate metodu, update-database komutunun �al��t�r�lmas�n� sa�lar.
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
