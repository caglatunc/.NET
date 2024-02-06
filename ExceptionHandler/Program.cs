using ExceptionHandler.Middlewares;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ExceptionMiddleware>();

//.NET 8 de kullan�lan hali.
//builder.Services.AddExceptionHandler<Net8ExceptionMiddleware
//builder.Services.AddProblemDetails(); 

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseExceptionHandler(); .NET 8 de kullan�lan hali.

app.UseException();//Bu extension method ile ExceptionMiddleware s�n�f�n� kullan�ma a�t�k.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
