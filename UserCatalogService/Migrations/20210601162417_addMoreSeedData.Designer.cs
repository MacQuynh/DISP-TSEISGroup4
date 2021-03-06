// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UserCatalogService.Data;

namespace UserCatalogService.Migrations
{
    [DbContext(typeof(UserCatalogContext))]
    [Migration("20210601162417_addMoreSeedData")]
    partial class addMoreSeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
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
                            Id = "12224",
                            UserCatalogId = "20"
                        },
                        new
                        {
                            Id = "12226",
                            UserCatalogId = "20"
                        },
                        new
                        {
                            Id = "12227",
                            UserCatalogId = "1"
                        },
                        new
                        {
                            Id = "12228",
                            UserCatalogId = "2"
                        },
                        new
                        {
                            Id = "12229",
                            UserCatalogId = "3"
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
                        },
                        new
                        {
                            Id = "1",
                            Capital = 200.09999999999999,
                            Name = "Trang"
                        },
                        new
                        {
                            Id = "2",
                            Capital = 300.10000000000002,
                            Name = "Mads"
                        },
                        new
                        {
                            Id = "3",
                            Capital = 400.10000000000002,
                            Name = "Randi"
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
