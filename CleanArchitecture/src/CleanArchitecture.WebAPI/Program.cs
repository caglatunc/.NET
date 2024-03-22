using CleanArchitecture.Application;
using CleanArchitecture.Application.Options;
using CleanArchitecture.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<EmailOptions>(builder.Configuration.GetSection("Email"));

builder.Services.AddApplication();  
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddAuthorization();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
