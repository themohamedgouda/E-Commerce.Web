using AutoMapper;
using DomainLayer.Contracts;
using E_Commerce.Web.CustomMiddlewares;
using E_Commerce.Web.Extensions;
using E_Commerce.Web.Factories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrecedencesLayer;
using PrecedencesLayer.Data;
using PrecedencesLayer.Repositories;
using ServicesAbstractionLayer;
using ServicesImplementationLayer;
using ServicesImplementationLayer.MappingProfiles;
using ServicesImplementationLayer.Specifications;
using Shared.ErrorMoldels;
using System.Net;

namespace E_Commerce.Web
{
    public  class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Add services to the container

            //Add services to the container

            builder.Services.AddControllers();

            builder.Services.AddSwaggerServices();

            builder.Services.AddInfrastructureServices(builder.Configuration);

            builder.Services.AddApplicationServices();

            builder.Services.AddWebApplicationServices();

            #endregion

            var app = builder.Build();

            #region DataSeeding
            //Data Seeding
            await app.SeedDataAsync();

            #endregion 

            #region Configure the HTTP request pipeline.

            //Pipeline | Middleware

            app.UseCustomApplicationMiddleware();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwaggerMiddleware();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseAuthorization();

            app.MapControllers();

            #endregion

            app.Run();
        }
    }
}
