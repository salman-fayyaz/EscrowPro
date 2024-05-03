using EscrowPro.Core.Dtos;
using EscrowPro.Core.Profiles;
using EscrowPro.Core.Repositories.DbInterfaces;
using EscrowPro.Core.ServicesInterfaces;
using EscrowPro.Infrastructure.Data;
using EscrowPro.Infrastructure.Repositories;
using EscrowPro.Service.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<EscrowProContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection"));
});
builder.Services.AddDbContext<EscrowProContext>(options => options.UseInMemoryDatabase("Test_Database"));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddTransient<IBuyerService,BuyerService>();
builder.Services.AddTransient<IBuyerRepository, BuyerRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(configuration => configuration
    .AddProfile<BuyerProfile>(), typeof(Program));

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
