using BasicWepAPI.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWepAPI.Data.Configuration
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.Property(x => x.CountryName)
                .HasMaxLength(20)
                .IsRequired();

            builder.HasMany(x => x.CountryContacts)
                .WithOne(x => x.Country)
                .HasForeignKey(x => x.CountryId);

            builder.HasData(new Country
            {
                Id = 1,
                CountryName = "Macedonia"
            });
        }
    }
}
