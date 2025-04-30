using AutoMapper;
using DomainLayer.Contracts;
using E_Commerce.Web.CustomMiddlewares;
using E_Commerce.Web.Factories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrecedencesLayer;
using PrecedencesLayer.Data;
using PrecedencesLayer.Repositories;
using ServicesAbstractionLayer;
using ServicesImplementationLayer;
using ServicesImplementationLayer.MappingProfiles;
using Shared.ErrorMoldels;
using System.Net;

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
            builder.Services.AddScoped<IServicesManager, ServicesManager>();
            builder.Services.Configure<ApiBehaviorOptions>((options) =>
            {
                #region Refactor
                //{
                //    var errors = context.ModelState
                //        .Where(e => e.Value.Errors.Count > 0)
                //        .Select(e => new ValidationError
                //        {
                //            Field = e.Key,                        
                //            Errors = e.Value.Errors.Select(x => x.ErrorMessage)
                //        }).ToList();
                //    var validationToReturn = new ValidationToReturn
                //    {
                //        //StatusCode = (int)HttpStatusCode.BadRequest,
                //        //ErrorMessage = "Validation Errors",
                //        ValidationErrors = errors
                //    };
                //    return new BadRequestObjectResult(validationToReturn);
                //}; 
                #endregion
                options.InvalidModelStateResponseFactory = ApiResponseFactory.GenerateApiValidationErrorResponse;
            });
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
            app.UseMiddleware<CustomExceptionHandlerMiddleware>();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger(); 

                app.UseSwaggerUI();
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
