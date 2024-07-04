using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServitiaTest_Backend_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServitiaTest_Backend_Persistence.MappingConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");
            builder.HasKey(m => m.Email);

            builder.Property(m => m.Email)
                .IsRequired()  
                .HasMaxLength(255); 

            builder.HasIndex(m => m.Email)
                .IsUnique(); 




            builder.Property(m => m.Password)
                .IsRequired();

            builder.Property(m => m.Username)
                .IsRequired();
            builder.Property(m => m.DateCreation)
                .HasColumnName("creation_date");
            builder.Property(m => m.DateModification)
                .HasColumnName("last_modification");
                
        }
    }
}
