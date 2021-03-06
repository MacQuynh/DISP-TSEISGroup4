// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShareCatalogService.Data;

namespace ShareCatalogService.Migrations
{
    [DbContext(typeof(ShareCatalogContext))]
    partial class ShareCatalogContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                            UserId = "1",
                            Value = 1000f
                        },
                        new
                        {
                            Id = "123457",
                            ForSale = false,
                            Name = "AP. Møller",
                            Tax = 0f,
                            UserId = "2",
                            Value = 1000f
                        },
                        new
                        {
                            Id = "123458",
                            ForSale = false,
                            Name = "AP. Møller",
                            Tax = 0f,
                            UserId = "3",
                            Value = 1000f
                        },
                        new
                        {
                            Id = "123459",
                            ForSale = false,
                            Name = "AP. Møller",
                            Tax = 0f,
                            UserId = "4",
                            Value = 1000f
                        },
                        new
                        {
                            Id = "123460",
                            ForSale = false,
                            Name = "AP. Møller",
                            Tax = 0f,
                            UserId = "5",
                            Value = 1000f
                        },
                        new
                        {
                            Id = "654321",
                            ForSale = false,
                            Name = "Carlsberg",
                            Tax = 0f,
                            UserId = "6",
                            Value = 100f
                        },
                        new
                        {
                            Id = "654322",
                            ForSale = false,
                            Name = "Carlsberg",
                            Tax = 0f,
                            UserId = "7",
                            Value = 100f
                        },
                        new
                        {
                            Id = "654323",
                            ForSale = false,
                            Name = "Carlsberg",
                            Tax = 0f,
                            UserId = "8",
                            Value = 100f
                        },
                        new
                        {
                            Id = "654324",
                            ForSale = false,
                            Name = "Carlsberg",
                            Tax = 0f,
                            UserId = "9",
                            Value = 100f
                        },
                        new
                        {
                            Id = "162534",
                            ForSale = false,
                            Name = "Salling Group",
                            Tax = 0f,
                            UserId = "10",
                            Value = 340f
                        },
                        new
                        {
                            Id = "162535",
                            ForSale = false,
                            Name = "Salling Group",
                            Tax = 0f,
                            UserId = "1",
                            Value = 340f
                        },
                        new
                        {
                            Id = "162536",
                            ForSale = false,
                            Name = "Salling Group",
                            Tax = 0f,
                            UserId = "2",
                            Value = 340f
                        },
                        new
                        {
                            Id = "162537",
                            ForSale = false,
                            Name = "Salling Group",
                            Tax = 0f,
                            UserId = "3",
                            Value = 340f
                        },
                        new
                        {
                            Id = "615243",
                            ForSale = false,
                            Name = "Norwegian",
                            Tax = 0f,
                            UserId = "4",
                            Value = 7f
                        },
                        new
                        {
                            Id = "615244",
                            ForSale = false,
                            Name = "Norwegian",
                            Tax = 0f,
                            UserId = "5",
                            Value = 7f
                        },
                        new
                        {
                            Id = "615245",
                            ForSale = false,
                            Name = "Norwegian",
                            Tax = 0f,
                            UserId = "6",
                            Value = 7f
                        },
                        new
                        {
                            Id = "615246",
                            ForSale = false,
                            Name = "Norwegian",
                            Tax = 0f,
                            UserId = "7",
                            Value = 7f
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
