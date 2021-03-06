// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PhoneBook.Infrastructures.DataAccess.Common;

namespace PhoneBook.Infrastructures.DataAccess.Migrations
{
    [DbContext(typeof(PhoneBookContext))]
    [Migration("20210924122253_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PhoneBook.Domain.Core.People.PersonTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PersonId");

                    b.Property<int>("TagId");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.HasIndex("TagId");

                    b.ToTable("PersonTag");
                });

            modelBuilder.Entity("PhoneBook.Domain.Core.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(500);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Image")
                        .IsUnicode(false);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("People");
                });

            modelBuilder.Entity("PhoneBook.Domain.Core.Phones.Phone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("PersonId");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(20);

                    b.Property<int>("PhoneType");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Phone");
                });

            modelBuilder.Entity("PhoneBook.Domain.Core.Tags.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("PhoneBook.Domain.Core.People.PersonTag", b =>
                {
                    b.HasOne("PhoneBook.Domain.Core.Person", "Person")
                        .WithMany("Tags")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PhoneBook.Domain.Core.Tags.Tag", "Tag")
                        .WithMany("PersonTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PhoneBook.Domain.Core.Phones.Phone", b =>
                {
                    b.HasOne("PhoneBook.Domain.Core.Person", "Person")
                        .WithMany("Phones")
                        .HasForeignKey("PersonId");
                });
#pragma warning restore 612, 618
        }
    }
}
