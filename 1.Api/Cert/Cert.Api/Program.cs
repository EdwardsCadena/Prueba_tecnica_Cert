using Cert.Core.Interfaces;
using Cert.Infrastructure.Data;
using Cert.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//Mapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Add services to the container.
builder.Services.AddDbContext<CertContext>(options =>
                                           options.UseNpgsql(builder.Configuration.GetConnectionString("Connection")));
builder.Services.AddControllers();

//Injeccion de dependendecias
builder.Services.AddTransient<IProductoRepository, ProductoRepository>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
