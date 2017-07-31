using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using HotelsWebApi.db;

namespace HotelsWebApi.Migrations
{
    [DbContext(typeof(HotelContext))]
    partial class HotelContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HotelsWebApi.Models.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Location");

                    b.Property<string>("Name");

                    b.Property<int>("Stars");

                    b.HasKey("Id");

                    b.ToTable("Hotels");
                });
        }
    }
}
