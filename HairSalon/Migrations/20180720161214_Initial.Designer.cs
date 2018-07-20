using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using HairSalon.Models;

namespace HairSalon.Migrations
{
    [DbContext(typeof(HairSalonContext))]
    [Migration("20180720161214_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1");

            modelBuilder.Entity("HairSalon.Models.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClientFirstName");

                    b.Property<string>("ClientLastName");

                    b.HasKey("ClientId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("HairSalon.Models.Specialty", b =>
                {
                    b.Property<int>("SpecialtyId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.HasKey("SpecialtyId");

                    b.ToTable("Specialties");
                });

            modelBuilder.Entity("HairSalon.Models.Stylist", b =>
                {
                    b.Property<int>("StylistId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("StylistFirstName");

                    b.Property<string>("StylistLastName");

                    b.HasKey("StylistId");

                    b.ToTable("Stylists");
                });

            modelBuilder.Entity("HairSalon.Models.StylistClient", b =>
                {
                    b.Property<int>("StylistClientId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClientId");

                    b.Property<int>("StylistId");

                    b.HasKey("StylistClientId");

                    b.HasIndex("ClientId");

                    b.HasIndex("StylistId");

                    b.ToTable("StylistClients");
                });

            modelBuilder.Entity("HairSalon.Models.StylistSpecialty", b =>
                {
                    b.Property<int>("StylistSpecialtyId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("SpecialtyId");

                    b.Property<int>("StylistId");

                    b.HasKey("StylistSpecialtyId");

                    b.HasIndex("SpecialtyId");

                    b.HasIndex("StylistId");

                    b.ToTable("StylistSpecialties");
                });

            modelBuilder.Entity("HairSalon.Models.StylistClient", b =>
                {
                    b.HasOne("HairSalon.Models.Client", "Client")
                        .WithMany("StylistClients")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HairSalon.Models.Stylist", "Stylist")
                        .WithMany("StylistClients")
                        .HasForeignKey("StylistId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HairSalon.Models.StylistSpecialty", b =>
                {
                    b.HasOne("HairSalon.Models.Specialty", "Specialty")
                        .WithMany("StylistSpecialties")
                        .HasForeignKey("SpecialtyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HairSalon.Models.Stylist", "Stylist")
                        .WithMany("StylistSpecialties")
                        .HasForeignKey("StylistId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
