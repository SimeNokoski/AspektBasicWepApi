using BasicWepAPI.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BasicWepAPI.Data.Configuration
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.Property(x => x.CompanyName)
                .HasMaxLength(20)
                .IsRequired();

            builder.HasMany(x => x.CompanyContacts)
                .WithOne(x => x.Company)
                .HasForeignKey(x => x.CompanyId);

            builder.HasData(new Company
            {
                Id = 1,
                CompanyName = "Aspect"
            });
        }
    }
}
