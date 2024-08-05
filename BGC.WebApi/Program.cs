using BGC.Common.Catalog;
using BGC.Server.Catalog;
using BGC.Server.DataLayer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ICatalogRepository, CatalogRepository>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContextFactory<BgcDbContext>(options =>
{
    options.UseNpgsql(Environment.GetEnvironmentVariable("PGSQLCNNSTR"));
});
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();

app.MapControllers();

app.Run();
