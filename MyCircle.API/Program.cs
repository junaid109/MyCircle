using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MyCircle.API.Contracts;
using MyCircle.API.Data;
using MyCircle.API.Data.Repository;
using MyCircle.API.Extensions;
using MyCircle.API.Profiles;
using MyCircle.API.Services;
using Serilog;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddCors();
builder.Services.AddApplicationServices((IConfiguration)builder.Services);
builder.Services.AddIdentityServices(builder.Services, builder.Configuration);

builder.Services.AddTransient<IEmailService, EmailService>();

// add serilog as default logger and override built in logger
builder.Services.AddLogging(loggingBuilder =>
{
	loggingBuilder.AddSerilog(dispose: true);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// configure cors
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthentication();	

app.UseAuthorization();

app.MapControllers();

app.Run();
