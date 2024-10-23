using ApplicationCore.Exceptions;
using Infrastructure.Repositories;
using Managers.managers;
using SportEventAppApi.Config;
using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace SportEventAppApi.DIConfig
{
    public static class DiConfig
    {
        public static WebApplicationBuilder RegisterDi(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers().AddJsonOptions(o =>
            {
                o.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //exception handler
            builder.Services.AddExceptionHandler<AppExceptionHandler>();

            //services repo
            builder.Services.AddScoped<ISportEventsRepository, SportEventsRepository>();
            builder.Services.AddScoped<IObjectRepository, ObjectRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();

            //services mang
            builder.Services.AddScoped<ISportEventManager, SportEventManager>();
            builder.Services.AddScoped<IObjectManager, ObjectManager>();

            //sql con
            builder.Services.AddDbContext<SportEventAppDbContext>();

            //identity
            builder.Services.AddAuthorization();
            builder.Services.AddIdentityApiEndpoints<IdentityUser>()
                .AddEntityFrameworkStores<SportEventAppDbContext>();

            //swagger comments documentation
            builder.Services.AddSwaggerGen(c =>
            {
                var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            return builder;
        }
    }
}
