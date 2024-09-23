using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MeetingOrganizer.Client
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });




            var app = builder.Build();

            // CORS'u kullan
            app.UseCors("AllowSpecificOrigin");

            // Statik dosyalarý wwwroot klasöründen sunabilmek için bu satýrý ekle
            app.UseStaticFiles();

            // Tarayýcýda root URL'ye gidildiðinde, index.html'yi aç
            app.MapFallbackToFile("index.html");

            app.Run();
        }
    }
}
