using Microsoft.EntityFrameworkCore;
using SisteminhaBancario.Data;
using SisteminhaBancario.Repositories;
using SisteminhaBancario.Repositories.Interfaces;
using System;

namespace SisteminhaBancario
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // builder.Services.AddEntityFrameworkSqlServer()
            //   .AddDbContext<SistemaBancarioDBContex>(
            // options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
            //);

            string sqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<SistemaBancarioDBContex>(options => options.UseSqlServer(sqlConnection));
            builder.Services.AddScoped<IPessoaRepositorio, PessoaRepositorio>();
            builder.Services.AddScoped<IcartaoRepositorio, cartaoRepositorio>();





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
        }
    }
}