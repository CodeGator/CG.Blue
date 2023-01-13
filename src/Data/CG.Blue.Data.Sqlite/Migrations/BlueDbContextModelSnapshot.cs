﻿// <auto-generated />
using System;
using CG.Blue.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CG.Blue.Data.Sqlite.Migrations
{
    [DbContext(typeof(BlueDbContext))]
    partial class BlueDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("CG.Blue.Data.Entities.FileTypeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedOnUtc")
                        .HasColumnType("TEXT");

                    b.Property<string>("Extension")
                        .IsRequired()
                        .HasMaxLength(260)
                        .IsUnicode(false)
                        .HasColumnType("TEXT");

                    b.Property<string>("LastUpdatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LastUpdatedOnUtc")
                        .HasColumnType("TEXT");

                    b.Property<int?>("MimeTypeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("MimeTypeId");

                    b.HasIndex(new[] { "Extension" }, "IX_FileTypes");

                    b.ToTable("FileTypes", "Blue");
                });

            modelBuilder.Entity("CG.Blue.Data.Entities.MimeTypeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedOnUtc")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastUpdatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LastUpdatedOnUtc")
                        .HasColumnType("TEXT");

                    b.Property<string>("SubType")
                        .IsRequired()
                        .HasMaxLength(127)
                        .IsUnicode(false)
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(127)
                        .IsUnicode(false)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Type", "SubType" }, "IX_MimeTypes")
                        .IsUnique();

                    b.ToTable("MimeTypes", "Blue");
                });

            modelBuilder.Entity("CG.Blue.Data.Entities.FileTypeEntity", b =>
                {
                    b.HasOne("CG.Blue.Data.Entities.MimeTypeEntity", "MimeType")
                        .WithMany("FileTypes")
                        .HasForeignKey("MimeTypeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("MimeType");
                });

            modelBuilder.Entity("CG.Blue.Data.Entities.MimeTypeEntity", b =>
                {
                    b.Navigation("FileTypes");
                });
#pragma warning restore 612, 618
        }
    }
}
