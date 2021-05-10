﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UserCatalogService.Data;

namespace UserCatalogService.Migrations
{
    [DbContext(typeof(UserCatalogContext))]
    partial class UserCatalogContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("UserCatalogService.Model.Share", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserCatalogId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserCatalogId");

                    b.ToTable("Share");

                    b.HasData(
                        new
                        {
                            Id = "AAPL",
                            UserCatalogId = "20"
                        });
                });

            modelBuilder.Entity("UserCatalogService.Model.UserCatalog", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Capital")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserCatalog");

                    b.HasData(
                        new
                        {
                            Id = "20",
                            Capital = 100.09999999999999,
                            Name = "Ida Hansen"
                        });
                });

            modelBuilder.Entity("UserCatalogService.Model.Share", b =>
                {
                    b.HasOne("UserCatalogService.Model.UserCatalog", "UserCatalog")
                        .WithMany("Shares")
                        .HasForeignKey("UserCatalogId");

                    b.Navigation("UserCatalog");
                });

            modelBuilder.Entity("UserCatalogService.Model.UserCatalog", b =>
                {
                    b.Navigation("Shares");
                });
#pragma warning restore 612, 618
        }
    }
}
