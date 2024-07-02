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
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.Property(x => x.ContactName)
                 .HasMaxLength(20)
                 .IsRequired();


            builder.HasOne(x => x.Company)
                .WithMany(x => x.CompanyContacts)
                .HasForeignKey(x => x.CompanyId);

            builder.HasOne(x=>x.Country)
                .WithMany(x=>x.CountryContacts)
                .HasForeignKey(x=>x.CountryId);


            builder.HasData(new Contact
            {
                Id = 1,
                ContactName = "Sime",
                CompanyId = 1,
                CountryId = 1,
            });
        }
    }
}
