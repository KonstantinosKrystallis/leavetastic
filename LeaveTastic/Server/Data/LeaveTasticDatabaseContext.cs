using System;
using System.Collections.Generic;
using LeaveTastic.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace LeaveTastic.Server.Data;

public partial class LeaveTasticDatabaseContext : DbContext
{
    public LeaveTasticDatabaseContext()
    {
    }

    public LeaveTasticDatabaseContext(DbContextOptions<LeaveTasticDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Leave> Leaves { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=localhost;Database=LeaveTastic.Database;User=sa;Password=S3cur3P@ssW0rd!;MultipleActiveResultSets=true;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("Employee");

            entity.Property(e => e.RoleId).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.Role).WithMany(p => p.Employees)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_Employee_RoleId");
        });

        modelBuilder.Entity<Leave>(entity =>
        {
            entity.ToTable("Leave");

            entity.Property(e => e.IsApproved)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))");
            entity.Property(e => e.IsDeleted)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))");

            entity.HasOne(d => d.Employee).WithMany(p => p.Leaves)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Leave_EmployeeId");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");
        });

        modelBuilder.Entity<Role>().HasData(
          new Role
          {
              Id = 1,
              Name = "Employ",
          }, new Role
          {
              Id = 2,
              Name = "Department Manager",
          }, new Role
          {
              Id = 3,
              Name = "Human Resources Manager",
          }
      );

        modelBuilder.Entity<Employee>().HasData(
               new Employee
               {
                   Id = 1,
                   Name = "Employ 1",
                   RoleId = 1,
                   ManagerId = 6,

               }, new Employee
               {
                   Id = 2,
                   Name = "Employ 2",
                   RoleId = 1,
                   ManagerId = 6,

               }, new Employee
               {
                   Id = 3,
                   Name = "Employ 3",
                   RoleId = 1,
                   ManagerId = 6,

               }, new Employee
               {
                   Id = 4,
                   Name = "Employ 4",
                   RoleId = 1,
                   ManagerId = 7

               }, new Employee
               {
                   Id = 5,
                   Name = "Employ 5",
                   RoleId = 1,
                   ManagerId = 8,

               }, new Employee
               {
                   Id = 6,
                   Name = "Department Manager 1",
                   RoleId = 2,
               }, new Employee
               {
                   Id = 7,
                   Name = "Department Manager 2",
                   RoleId = 2,
               }, new Employee
               {
                   Id = 8,
                   Name = "Human Resources Manager",
                   RoleId = 3,
               }
           );

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
