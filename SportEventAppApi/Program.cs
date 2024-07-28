using Microsoft.AspNetCore.Identity;
using SportEventAppApi.DIConfig;

namespace SportEventAppApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.RegisterDi();

            var app = builder.Build();


            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            //identity
            app.MapIdentityApi<IdentityUser>();

            //exception handler
            app.UseExceptionHandler(_ => { });

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
