using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBook.Domain.Core.Phones;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Infrastructures.DataAccess.Phones
{
    internal class PhoneConfig : IEntityTypeConfiguration<Phone>
    {
        public void Configure(EntityTypeBuilder<Phone> builder)
        {
            builder.Property(c => c.PhoneNumber).HasMaxLength(20);
        }
    }
}
