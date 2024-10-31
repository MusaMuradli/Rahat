using Microsoft.Extensions.DependencyInjection;
using Rahat.Application.Services.CategoryService;
using Rahat.Application.Services.ProductService;
using System.Reflection;

namespace Rahat.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddScoped<IProductService, ProductManager>();
        services.AddScoped<ICategoryService, CategoryManager>();

        return services;
    }
}
