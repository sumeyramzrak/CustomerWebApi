using Data.Context;
using HW_CreateCustomerApi_Common;
using HW_CreateCustomerApi_Services.Extensions;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
var settings = builder.Configuration.GetSection("Settings").Get<Settings>();


// Add services to the container.

builder.Services.AddDbContext<NorthwindDbContext>
(options => { options.UseSqlServer(settings.Database.ConnectionString); });

builder.Services.AddCors(option => { option.AddPolicy("all", p => { p.AllowAnyOrigin().AllowAnyHeader(); }); }); //Cors policy tanýmlladýk,aþaðýda eklenecek.

builder.Services.AddDataServices();

builder.Services.AddControllers();
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

app.UseCors("all"); //Tanýmlanan cors policyi ekledik.

app.UseAuthorization();

app.MapControllers();

app.Run();
