using Infrastructure.Repositories;
using Managers.managers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SportEventAppApi.Config;

namespace SportEventAppApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //services repo
            builder.Services.AddScoped<ISportEventsRepository,SportEventsRepository>();
            builder.Services.AddScoped<IObjectRepository,ObjectRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();

            //services mang
            builder.Services.AddScoped<ISportEventManager, SportEventManager>();

            //sql con
            builder.Services.AddDbContext<SportEventAppDbContext>();

            //identity
            builder.Services.AddAuthorization();
            builder.Services.AddIdentityApiEndpoints<IdentityUser>()
                .AddEntityFrameworkStores<SportEventAppDbContext>();

            var app = builder.Build();


            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            //identity
            app.MapIdentityApi<IdentityUser>();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
