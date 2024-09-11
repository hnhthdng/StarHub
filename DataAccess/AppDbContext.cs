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
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}
