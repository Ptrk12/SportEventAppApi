using Infrastructure.Entities;
using SportEventAppApi.DIConfig;
using Serilog;

namespace SportEventAppApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.RegisterDi();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration).CreateLogger();
        

            var app = builder.Build();


            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            builder.Services.AddCors();
            app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000"));

            //identity
            app.MapIdentityApi<UserEntity>();

            //exception handler
            app.UseExceptionHandler(_ => { });
            

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
