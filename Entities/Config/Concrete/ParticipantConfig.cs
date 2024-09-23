
using DataAccessLayer_DAL_.EntityLayer.Models.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Config.Concrete
{
    public class ParticipantConfig : IEntityTypeConfiguration<Participant>
    {
        public void Configure(EntityTypeBuilder<Participant> builder)
        {
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(255);

            // Çoktan çoka ilişki için konfigürasyon
            builder.HasMany(p => p.Meetings)
                .WithMany(m => m.Participants)
                .UsingEntity(j => j.ToTable("ParticipantMeeting")); // Ara tablo oluşturulacak ancak kullanılmayacak
        }
    }
}