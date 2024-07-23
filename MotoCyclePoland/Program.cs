using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MotoCyclePoland.Database;
using System.Configuration;
using System.Globalization;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
});

builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

builder.Services.AddSwaggerGen(d =>
{
    d.SwaggerDoc("v1", new OpenApiInfo { Title = "Moto", Version = "v1" });
});

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddDbContext<motoDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("MotoCyclePolandContext")));

builder.Services.AddScoped<motoDbContext>();


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Moto");
        c.RoutePrefix = string.Empty;
    });
}
app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();


app.Run();

public record Todo(int Id, string? Title, DateOnly? DueBy = null, bool IsComplete = false);

[JsonSerializable(typeof(Todo[]))]
internal partial class AppJsonSerializerContext : JsonSerializerContext
{

}
