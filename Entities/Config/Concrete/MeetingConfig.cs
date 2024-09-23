
using DataAccessLayer_DAL_.EntityLayer.Models.Concrete;
using Entities.Config.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Config.Concrete
{
    public class MeetingConfig : BaseConfig<Meeting>
    {
        public override void Configure(EntityTypeBuilder<Meeting> builder)
        {
            base.Configure(builder);
            builder.Property(a => a.Topic)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(a => a.Date)
                .IsRequired();

            builder.Property(a => a.StartTime)
                .IsRequired();

            builder.Property(a => a.EndTime)
                .IsRequired();

            // Çoktan çoka ilişki için konfigürasyon
            builder.HasMany(m => m.Participants)
                .WithMany(p => p.Meetings)
                .UsingEntity(j => j.ToTable("ParticipantMeeting")); // Ara tablo burada tanımlanıyor
        }
    }
}