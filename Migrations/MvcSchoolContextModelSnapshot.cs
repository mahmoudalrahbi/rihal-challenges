﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace School.Migrations
{
    [DbContext(typeof(MvcSchoolContext))]
    partial class MvcSchoolContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.1");

            modelBuilder.Entity("School.Models.Classes", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("class_name")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("created_date")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("modified_date")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("School.Models.Countries", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("created_date")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("modified_date")
                        .HasColumnType("TEXT");

                    b.Property<string>("name")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("School.Models.Students", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClassesId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("class_id");

                    b.Property<int>("CountriesId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("country_id");

                    b.Property<DateTime>("created_date")
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("date_of_birth")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("modified_date")
                        .HasColumnType("TEXT");

                    b.Property<string>("name")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.HasIndex("ClassesId");

                    b.HasIndex("CountriesId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("School.Models.Students", b =>
                {
                    b.HasOne("School.Models.Classes", "Classes")
                        .WithMany()
                        .HasForeignKey("ClassesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("School.Models.Countries", "Countries")
                        .WithMany()
                        .HasForeignKey("CountriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Classes");

                    b.Navigation("Countries");
                });
#pragma warning restore 612, 618
        }
    }
}
