using Employee.Logic;
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddSwaggerGen(o =>
{
    o.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme()
            {
                Reference=new OpenApiReference()
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                },
                Name="Bearer",
                In=ParameterLocation.Header,
            },
            new List<string>()
        }
    });
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200/", "http://localhost:4200")
                   .AllowAnyHeader()
                   .AllowAnyMethod()
                   .AllowCredentials();
        });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseStaticFiles();
app.UseAuthorization();
app.MapControllers();

app.Run();
