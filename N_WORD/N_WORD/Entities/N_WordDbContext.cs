using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace N_WORD.Entities
{
    public class N_WordDbContext : DbContext 
    {
        public N_WordDbContext(DbContextOptions<N_WordDbContext> options) : base(options)
        {
        }
        public DbSet<Word> Words { get; set;}
        public DbSet<Category> Categories { get; set;}
        public DbSet<User> Users { get; set;}
        public DbSet<Role> Roles { get; set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.Username)
                .IsRequired();

            modelBuilder.Entity<Word>()
                .Property(w => w.PlMeaning)
                .IsRequired()
                .HasMaxLength(20);

            modelBuilder.Entity<Word>()
                .Property(w => w.EnMeaning)
                .IsRequired()
                .HasMaxLength(20);

            modelBuilder.Entity<Category>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(25);
        }
        
    }
}
