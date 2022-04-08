using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebApplication1.Entities;

namespace WebApplication1.Data
{
    public partial class ProiectContext : DbContext
    {
        public ProiectContext()
        {
        }

        public ProiectContext(DbContextOptions<ProiectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<DepartmentGame> DepartmentGames { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<EmployeeGame> EmployeeGames { get; set; } = null!;
        public virtual DbSet<Game> Games { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LENOVO;Initial Catalog=Proiect;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Adress).HasMaxLength(255);

                entity.Property(e => e.City).HasMaxLength(255);

                entity.Property(e => e.Country).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<DepartmentGame>(entity =>
            {
                entity.HasKey(e => new { e.DepartmentId, e.GameId })
                    .HasName("PK__Departme__E585C429E93D1A7E");

                entity.ToTable("Department_Game");

                entity.Property(e => e.DepartmentId).HasColumnName("Department_ID");

                entity.Property(e => e.GameId).HasColumnName("Game_ID");

                entity.Property(e => e.AvailableNumber).HasColumnName("Available_number");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.DepartmentGames)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK__DepartmentID__Game__30F848ED");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.DepartmentGames)
                    .HasForeignKey(d => d.GameId)
                    .HasConstraintName("FK__Department__GameID__30F848ED");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.FirstName).HasMaxLength(255);

                entity.Property(e => e.LastName).HasMaxLength(255);

                entity.HasOne(d => d.DepartmentNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.Department)
                    .HasConstraintName("FK__Employee__DepartmentId__30F848ED");
            });

            modelBuilder.Entity<EmployeeGame>(entity =>
            {
                entity.HasKey(e => new { e.EmployeeId, e.GameId })
                    .HasName("PK__Employee__88828579F70D3ACE");

                entity.ToTable("Employee_Game");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_ID");

                entity.Property(e => e.GameId).HasColumnName("Game_ID");

                entity.Property(e => e.BorrowDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Borrow_Date");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeGames)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__EmployeeID__Game__30F848ED");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.EmployeeGames)
                    .HasForeignKey(d => d.GameId)
                    .HasConstraintName("FK__Employee__GameID__30F848ED");
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.ToTable("Game");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.ReleaseDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Release_Date");

                entity.Property(e => e.Series).HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
