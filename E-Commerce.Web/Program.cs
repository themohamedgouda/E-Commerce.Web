using AutoMapper;
using DomainLayer.Contracts;
using Microsoft.EntityFrameworkCore;
using PrecedencesLayer;
using PrecedencesLayer.Data;
using PrecedencesLayer.Repositories;
using ServicesImplementationLayer.MappingProfiles;

namespace E_Commerce.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Add services to the container

            //Add services to the container

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<StoredDbContext>(Options =>
            {
                Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddScoped<IDataSeeding, DataSeeding>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();  
            builder.Services.AddAutoMapper(typeof(ServicesImplementationLayer.AssemblyReference).Assembly);
            #endregion

            var app = builder.Build();

            #region DataSeeding

            //Data Seeding

            using var scoope = app.Services.CreateScope();

            var ObjectOfDataSeeding = scoope.ServiceProvider.GetRequiredService<IDataSeeding>();

            ObjectOfDataSeeding.DataSeedAsync();
            #endregion

            #region Configure the HTTP request pipeline.

            //Pipeline | Middleware

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger(); 

                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            #endregion

            app.Run();
        }
    }
}
