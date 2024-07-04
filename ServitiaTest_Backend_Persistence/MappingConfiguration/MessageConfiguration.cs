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
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.ToTable("message");
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Recipient)
                .IsRequired()
                .HasMaxLength(80);

            builder.Property(m => m.Sender)
                .IsRequired()
                .HasMaxLength(80);

            builder.Property(m => m.Read)
                .IsRequired()
                .HasDefaultValue(false);

            builder.HasIndex(m => new { m.Recipient, m.Read })
                .HasDatabaseName("unread_message");

            builder.HasIndex(m => new { m.Sender, m.Recipient })
                .HasDatabaseName("message_channel");

            builder.Property(m => m.CreationDate)
              .HasColumnName("creation_date");
            builder.Property(m => m.LastModification)
                .HasColumnName("last_modification");

            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(m => m.Recipient)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(m => m.Sender)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
