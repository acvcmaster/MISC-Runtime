using Microsoft.OpenApi.Models;
using MISCRuntime.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Injects services
DependencyResolver.ResolveDependencies(builder);


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "MISCRuntime", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// Always use swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MISC_Runtime v1");
    c.RoutePrefix = string.Empty;
});

app.MapControllers();

app.Run();
