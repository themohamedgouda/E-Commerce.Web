using DomainLayer.Contracts;
using E_Commerce.Web.CustomMiddlewares;

namespace E_Commerce.Web.Extensions
{
    public static class WebApplicationRegisteration
    {

        public static async Task SeedDataAsync(this WebApplication app)
        {

            using var scoope = app.Services.CreateScope();

            var ObjectOfDataSeeding = scoope.ServiceProvider.GetRequiredService<IDataSeeding>();

            await ObjectOfDataSeeding.DataSeedAsync();
            await ObjectOfDataSeeding.IdentityDataAsync();
        }
        public static IApplicationBuilder UseCustomApplicationMiddleware(this IApplicationBuilder app) {

            app.UseMiddleware<CustomExceptionHandlerMiddleware>();
            return app;
        }
        public static IApplicationBuilder UseSwaggerMiddleware(this IApplicationBuilder app)
        {

            app.UseSwagger();

            app.UseSwaggerUI();

            return app;
        }
    }
}
