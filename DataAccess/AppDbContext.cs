using DataObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        { }
        public DbSet<Tutor> Tutors { get; set; }
        public DbSet<MainSubject> MainSubjects { get; set; }
        public DbSet<FormOfWork> FormOfWorks { get; set; }
        public DbSet<TeachingTopic> TeachingTopics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuring many-to-many relationships
            modelBuilder.Entity<Tutor>()
                .HasMany(t => t.MainSubjects)
                .WithMany(ms => ms.Tutors);

            modelBuilder.Entity<Tutor>()
                .HasMany(t => t.FormOfWorks)
                .WithMany(fw => fw.Tutors);

            modelBuilder.Entity<Tutor>()
                .HasMany(t => t.TeachingTopics)
                .WithMany(tt => tt.Tutors);

            // Seeding MainSubject data
            modelBuilder.Entity<MainSubject>().HasData(
                new MainSubject { Id = 1, Name = "Mathematics" },
                new MainSubject { Id = 2, Name = "Physics" },
                new MainSubject { Id = 3, Name = "Chemistry" }
            );

            // Seeding TeachingTopic data
            modelBuilder.Entity<TeachingTopic>().HasData(
                new TeachingTopic { Id = 1, Topic = "Calculus" },
                new TeachingTopic { Id = 2, Topic = "Electromagnetism" },
                new TeachingTopic { Id = 3, Topic = "Organic Chemistry" }
            );

            // Seeding FormOfWork data
            modelBuilder.Entity<FormOfWork>().HasData(
                new FormOfWork { Id = 1, Form = "Offline" },
                new FormOfWork { Id = 2, Form = "Online" }
            );

            // Seeding Tutor data
            modelBuilder.Entity<Tutor>().HasData(
                new Tutor
                {
                    Id = 100001,
                    FullName = "John Doe",
                    TuitionFee = 3000,
                    LivingAt = "New York",
                    YearOfBirth = 1985,
                    Gender = 1, // 1: Male, 2: Female
                    Hometown = "California",
                    Education = "PhD in Mathematics",
                    Experience = "5 years of teaching experience",
                    Achievement = "Published 3 research papers in reputed journals",
                    CurrentStatus = "Currently a professor at XYZ University",
                    TeachingArea = "New York City"
                },
                new Tutor
                {
                    Id = 100002,
                    FullName = "Jane Smith",
                    TuitionFee = 2500,
                    LivingAt = "Los Angeles",
                    YearOfBirth = 1990,
                    Gender = 2, // 1: Male, 2: Female
                    Hometown = "Texas",
                    Education = "MSc in Physics",
                    Experience = "3 years of teaching experience",
                    Achievement = "Top teacher award in 2023",
                    CurrentStatus = "Currently an online tutor",
                    TeachingArea = "Los Angeles"
                }
            );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}
