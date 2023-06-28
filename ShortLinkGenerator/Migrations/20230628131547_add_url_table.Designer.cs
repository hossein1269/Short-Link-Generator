﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShortLinkGenerator.Database;

#nullable disable

namespace ShortLinkGenerator.Migrations
{
    [DbContext(typeof(ShortLinkContext))]
    [Migration("20230628131547_add_url_table")]
    partial class add_url_table
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.8");

            modelBuilder.Entity("ShortLinkGenerator.Database.Models.ShortUrl", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("ShortUrlCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.ToTable("Urls");
                });
#pragma warning restore 612, 618
        }
    }
}