﻿// <auto-generated />
using EDIFileStoreWebApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EDIFileStoreWebApp.Migrations
{
    [DbContext(typeof(watchlistContext))]
    [Migration("20220325110154_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EDIFileStoreWebApp.Models.watchlist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("B4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IEA")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISA")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ST")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Watchlist");
                });
#pragma warning restore 612, 618
        }
    }
}
