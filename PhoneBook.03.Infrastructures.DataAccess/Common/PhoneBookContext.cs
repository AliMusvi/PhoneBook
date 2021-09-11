using Microsoft.EntityFrameworkCore;
using PhoneBook.Domain.Core;
using PhoneBook.Infrastructures.DataAccess.People;
using PhoneBook.Infrastructures.DataAccess.Phones;
using PhoneBook.Infrastructures.DataAccess.Tags;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Infrastructures.DataAccess.Common
{
    public class PhoneBookContext : DbContext
    {
        public DbSet<Person> People { get; set; }

        public PhoneBookContext(DbContextOptions<PhoneBookContext> Option) :base(Option)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonConfig());
            modelBuilder.ApplyConfiguration(new PersonTagConfig());
            modelBuilder.ApplyConfiguration(new PhoneConfig());
            modelBuilder.ApplyConfiguration(new TagConfig());
            base.OnModelCreating(modelBuilder);
        }
    }    
}
