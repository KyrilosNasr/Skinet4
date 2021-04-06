using System.Linq;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace API.Errors
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));

            services.Configure<ApiBehaviorOptions>(options =>
          {
              options.InvalidModelStateResponseFactory = ActionContext =>
              {
                  var errors = ActionContext.ModelState
                  .Where(e => e.Value.Errors.Count > 0)
                  .SelectMany(x => x.Value.Errors)
                  .Select(x => x.ErrorMessage).ToArray();

                  var errorResponse = new ApiValidationErrorResponse
                  {
                      Errors = errors
                  };

                  return new BadRequestObjectResult(errorResponse);
              };
          });

            return services;
        }
    }
}