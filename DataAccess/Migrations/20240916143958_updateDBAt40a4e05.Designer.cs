﻿// <auto-generated />
using System;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240916143958_updateDBAt40a4e05")]
    partial class updateDBAt40a4e05
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataObject.FormOfWork", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Form")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("FormOfWorks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Form = "Offline"
                        },
                        new
                        {
                            Id = 2,
                            Form = "Online"
                        });
                });

            modelBuilder.Entity("DataObject.MainSubject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("MainSubjects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Mathematics"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Physics"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Chemistry"
                        });
                });

            modelBuilder.Entity("DataObject.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("DataObject.TeachingTopic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Topic")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("TeachingTopics");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Topic = "Calculus"
                        },
                        new
                        {
                            Id = 2,
                            Topic = "Electromagnetism"
                        },
                        new
                        {
                            Id = 3,
                            Topic = "Organic Chemistry"
                        });
                });

            modelBuilder.Entity("DataObject.Tutor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Achievement")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("CurrentStatus")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Education")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Experience")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Hometown")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LivingAt")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeachingArea")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("TuitionFee")
                        .HasColumnType("int");

                    b.Property<int>("YearOfBirth")
                        .HasColumnType("int");

                    b.Property<string>("avatarURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tutors");

                    b.HasData(
                        new
                        {
                            Id = 100001,
                            Achievement = "Published 3 research papers in reputed journals",
                            CurrentStatus = "Currently a professor at XYZ University",
                            Education = "PhD in Mathematics",
                            Email = "1@gmail.com",
                            Experience = "5 years of teaching experience",
                            FullName = "John Doe",
                            Gender = 1,
                            Hometown = "California",
                            LivingAt = "New York",
                            PhoneNumber = "123456789",
                            TeachingArea = "New York City",
                            TuitionFee = 3000,
                            YearOfBirth = 1985,
                            avatarURL = "https://randomuser.me/api/port"
                        },
                        new
                        {
                            Id = 100002,
                            Achievement = "Top teacher award in 2023",
                            CurrentStatus = "Currently an online tutor",
                            Education = "MSc in Physics",
                            Email = "2@gmail.com",
                            Experience = "3 years of teaching experience",
                            FullName = "Jane Smith",
                            Gender = 2,
                            Hometown = "Texas",
                            LivingAt = "Los Angeles",
                            PhoneNumber = "987654321",
                            TeachingArea = "Los Angeles",
                            TuitionFee = 2500,
                            YearOfBirth = 1990,
                            avatarURL = "https://randomuser.me/api/port"
                        });
                });

            modelBuilder.Entity("FormOfWorkTutor", b =>
                {
                    b.Property<int>("FormOfWorksId")
                        .HasColumnType("int");

                    b.Property<int>("TutorsId")
                        .HasColumnType("int");

                    b.HasKey("FormOfWorksId", "TutorsId");

                    b.HasIndex("TutorsId");

                    b.ToTable("FormOfWorkTutor");
                });

            modelBuilder.Entity("MainSubjectTutor", b =>
                {
                    b.Property<int>("MainSubjectsId")
                        .HasColumnType("int");

                    b.Property<int>("TutorsId")
                        .HasColumnType("int");

                    b.HasKey("MainSubjectsId", "TutorsId");

                    b.HasIndex("TutorsId");

                    b.ToTable("MainSubjectTutor");
                });

            modelBuilder.Entity("TeachingTopicTutor", b =>
                {
                    b.Property<int>("TeachingTopicsId")
                        .HasColumnType("int");

                    b.Property<int>("TutorsId")
                        .HasColumnType("int");

                    b.HasKey("TeachingTopicsId", "TutorsId");

                    b.HasIndex("TutorsId");

                    b.ToTable("TeachingTopicTutor");
                });

            modelBuilder.Entity("FormOfWorkTutor", b =>
                {
                    b.HasOne("DataObject.FormOfWork", null)
                        .WithMany()
                        .HasForeignKey("FormOfWorksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataObject.Tutor", null)
                        .WithMany()
                        .HasForeignKey("TutorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MainSubjectTutor", b =>
                {
                    b.HasOne("DataObject.MainSubject", null)
                        .WithMany()
                        .HasForeignKey("MainSubjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataObject.Tutor", null)
                        .WithMany()
                        .HasForeignKey("TutorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TeachingTopicTutor", b =>
                {
                    b.HasOne("DataObject.TeachingTopic", null)
                        .WithMany()
                        .HasForeignKey("TeachingTopicsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataObject.Tutor", null)
                        .WithMany()
                        .HasForeignKey("TutorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
