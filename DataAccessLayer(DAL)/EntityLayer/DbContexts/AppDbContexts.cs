using DataAccessLayer_DAL_.EntityLayer.Models.Concrete;
using Entities.Config.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer_DAL_.EntityLayer.DbContexts
{
    public class AppDbContexts : DbContext
    {
        private readonly IConfiguration _configuration;

        
        public AppDbContexts()
        {
            
        }
        public AppDbContexts(DbContextOptions<AppDbContexts> options , IConfiguration configuration)  : base(options)
        {
            _configuration = configuration;
        }


        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<Participant> Participants { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySQL(@"Server=localhost;Database=MeetingOrganizer;Uid=root;password=Password187");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.ApplyConfiguration(new MeetingConfig());
            modelBuilder.ApplyConfiguration(new ParticipantConfig());

            
        }
    }
}
