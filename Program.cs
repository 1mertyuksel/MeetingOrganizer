using BusinessLogic_BL_.Abstract;
using BusinessLogic_BL_.Concrete;
using DataAccessLayer_DAL_.EntityLayer.DbContexts;
using DataAccessLayer_DAL_.EntityLayer.Models.Concrete;
using MeetingOrganizerWebAPI.Profiles;
using Microsoft.EntityFrameworkCore;

namespace MeetingOrganizer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<AppDbContexts>(options =>
                options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<ParticipantService<Participant>>();
            builder.Services.AddScoped<MeetingService<Meeting>>();
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            builder.Services.AddControllers();

            // CORS ayarlarý
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });

            // Swagger/OpenAPI ayarlarý
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Middleware ayarlarý
            app.UseCors("AllowAll"); // CORS politikasý
            app.UseHttpsRedirection();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
