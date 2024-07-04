using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ServitiaTest_Backend_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServitiaTest_Backend_Persistence.MappingConfiguration
{
    public class SessionConfiguration : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.ToTable("session");
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Email)
                .HasColumnName("user_email")
                .IsRequired();
            builder.HasOne(m => m.User)
                   .WithMany()
                   .HasForeignKey(m => m.Email)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(m => m.ConnectionTime)
                .IsRequired()
                .HasColumnName("login_time");
            builder.Property(m => m.LogoutTime)
                .HasColumnName("logout_time");
           

        }
    }
}
