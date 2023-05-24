using CQRS.Mediator.RepositoryLayer;
using CQRS.Mediator.RepositoryLayer.Data;
using CQRS.Mediator.ServiceLayer;
using CQRS.MediatR.API.Middleware;
using MediatR;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Net;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var ConnectionString = builder.Configuration.GetConnectionString("SqlServerConnectionStrings");
builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(ConnectionString));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICrudRL, CrudRL>();
builder.Services.AddScoped<ICrudSL, CrudSL>();

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.ConfigureExceptionHandler(app.Environment);
/*
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseSwagger();
    app?.UseSwaggerUI();
    app.UseExceptionHandler(options =>
    {
        options.Run(
            async context =>
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var ex = context.Features.Get<IExceptionHandlerFeature>();
                if(ex != null)
                {
                    await context.Response.WriteAsync(ex.Error.Message);
                }
            });
    });
}
*/
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
