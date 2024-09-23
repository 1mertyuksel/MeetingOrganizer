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

            // Statik dosyalar� wwwroot klas�r�nden sunabilmek i�in bu sat�r� ekle
            app.UseStaticFiles();

            // Taray�c�da root URL'ye gidildi�inde, index.html'yi a�
            app.MapFallbackToFile("index.html");

            app.Run();
        }
    }
}
