﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShareCatalogService.Data;

namespace ShareCatalogService.Migrations
{
    [DbContext(typeof(ShareCatalogContext))]
    [Migration("20210520155716_moreShares")]
    partial class moreShares
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ShareCatalogService.Models.ShareCatalog", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("ForSale")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Tax")
                        .HasColumnType("real");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Value")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Shares");

                    b.HasData(
                        new
                        {
                            Id = "123456",
                            ForSale = false,
                            Name = "AP. Møller",
                            Tax = 0f,
                            UserId = "Mads Mikkelsen",
                            Value = 1000f
                        },
                        new
                        {
                            Id = "123457",
                            ForSale = true,
                            Name = "Carlsberg",
                            Tax = 1f,
                            UserId = "Mads Mikkelsen",
                            Value = 100f
                        },
                        new
                        {
                            Id = "123357",
                            ForSale = true,
                            Name = "AP. Møller",
                            Tax = 10f,
                            UserId = "Randi",
                            Value = 1000f
                        },
                        new
                        {
                            Id = "122257",
                            ForSale = true,
                            Name = "AP. Møller",
                            Tax = 10f,
                            UserId = "Trang",
                            Value = 1000f
                        },
                        new
                        {
                            Id = "123227",
                            ForSale = false,
                            Name = "Carlsberg",
                            Tax = 0f,
                            UserId = "Trang",
                            Value = 100f
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
