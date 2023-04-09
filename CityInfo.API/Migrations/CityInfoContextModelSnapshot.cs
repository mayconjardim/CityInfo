﻿// <auto-generated />
using CityInfo.API.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CityInfo.API.Migrations
{
    [DbContext(typeof(CityInfoContext))]
    partial class CityInfoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.4");

            modelBuilder.Entity("CityInfo.API.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "A cidade maravilhosa.",
                            Name = "Rio de Janeiro"
                        },
                        new
                        {
                            Id = 2,
                            Description = "A cidade tropical",
                            Name = "Niteroi"
                        },
                        new
                        {
                            Id = 3,
                            Description = "A cidade que nunca para.",
                            Name = "São Paulo"
                        });
                });

            modelBuilder.Entity("CityInfo.API.Entities.PointOfInterest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CityId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("PointOfInterests");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CityId = 1,
                            Description = "Uma das sete maravilhas do mundo.",
                            Name = "Cristo Redentor"
                        },
                        new
                        {
                            Id = 2,
                            CityId = 1,
                            Description = "Onde você encontra todas as tribos.",
                            Name = "Lapa"
                        },
                        new
                        {
                            Id = 3,
                            CityId = 2,
                            Description = "Praia para Surfistas",
                            Name = "Praia de Itacoatiara."
                        },
                        new
                        {
                            Id = 4,
                            CityId = 2,
                            Description = "Pra quem gosta de trilhas.",
                            Name = "Pedra do Elefante"
                        },
                        new
                        {
                            Id = 5,
                            CityId = 3,
                            Description = "Uma grande praça aberta",
                            Name = "Praça da Sé."
                        },
                        new
                        {
                            Id = 6,
                            CityId = 3,
                            Description = "Onde você pode comprar tudo.",
                            Name = "Rua 15 de Março"
                        });
                });

            modelBuilder.Entity("CityInfo.API.Entities.PointOfInterest", b =>
                {
                    b.HasOne("CityInfo.API.Entities.City", "City")
                        .WithMany("PointsOfInterest")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("CityInfo.API.Entities.City", b =>
                {
                    b.Navigation("PointsOfInterest");
                });
#pragma warning restore 612, 618
        }
    }
}
