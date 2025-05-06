using E_Commerce.Web.Factories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace E_Commerce.Web.Extensions
{
    public static class ServicesRegisteration
    {
        public static IServiceCollection AddSwaggerServices(this IServiceCollection Services)
        {
            
            Services.AddEndpointsApiExplorer();
            Services.AddSwaggerGen();
            return Services;
        }
        public static IServiceCollection AddWebApplicationServices(this IServiceCollection Services)
        {
            Services.Configure<ApiBehaviorOptions>((options) =>
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
            return Services;

        }
        public static IServiceCollection AddJWTServices(this IServiceCollection Services , IConfiguration Configuration)
        {
            Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = Configuration["JwdOptions:Issuer"],
                    ValidateAudience = true,
                    ValidAudience = Configuration["JwdOptions:Audience"],
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwdOptions:SecretKey"]!))
                };
            });
            return Services;

        }

    }
}
