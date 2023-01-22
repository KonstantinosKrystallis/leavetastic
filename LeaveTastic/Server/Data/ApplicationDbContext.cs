using LeaveTastic.Shared.Models.Old;
using Microsoft.EntityFrameworkCore;

namespace LeaveTastic.Server.Data
{
    //public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    //{
    //    public ApplicationDbContext(
    //        DbContextOptions options,
    //        IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
    //    {
    //    }
    //}

    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Leave> Leaves { get; set; }
        public DbSet<UserLeave> UserLeaves { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Roles
            modelBuilder.Entity<Role>().HasKey(c => c.Id);
            modelBuilder.Entity<Role>().HasMany(c => c.Users).WithOne(c => c.Role).HasForeignKey(c => c.RoleId);
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = 1,
                    Name = "Employ",
                },
                new Role
                {
                    Id = 2,
                    Name = "Department Manager",
                },
                new Role
                {
                    Id = 3,
                    Name = "Human Resources Manager",
                }
            );
            #endregion

            #region Users
            modelBuilder.Entity<User>().HasKey(c => c.Id);
            modelBuilder.Entity<User>().HasOne(c => c.Role).WithOne(c => c.User);
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "Employ 1",
                    ManagerId = 6,

                }, new User
                {
                    Id = 2,
                    Name = "Employ 2",
                    ManagerId = 6,

                }, new User
                {
                    Id = 3,
                    Name = "Employ 3",
                    ManagerId = 6,

                }, new User
                {
                    Id = 4,
                    Name = "Employ 4",
                    ManagerId = 7

                }, new User
                {
                    Id = 5,
                    Name = "Employ 5",
                    ManagerId = 8,

                }, new User
                {
                    Id = 6,
                    Name = "Department Manager 1",
                }, new User
                {
                    Id = 7,
                    Name = "Department Manager 2",
                }, new User
                {
                    Id = 8,
                    Name = "Human Resources Manager",
                }
            );
            #endregion

            #region UserRole
            modelBuilder.Entity<UserRole>().HasKey(c => new { c.UserId, c.RoleId });
            modelBuilder.Entity<UserRole>().HasOne(c => c.Role).WithMany(c => c.Users).HasForeignKey(c => c.RoleId);
            modelBuilder.Entity<UserRole>().HasData(
                new UserRole
                {
                    RoleId = 1,
                    UserId = 1,
                }, new UserRole
                {
                    RoleId = 1,
                    UserId = 2,
                }, new UserRole
                {
                    RoleId = 1,
                    UserId = 3,
                }, new UserRole
                {
                    RoleId = 1,
                    UserId = 4,
                }, new UserRole
                {
                    RoleId = 1,
                    UserId = 5,
                }, new UserRole
                {
                    RoleId = 2,
                    UserId = 6,
                }, new UserRole
                {
                    RoleId = 2,
                    UserId = 7,
                }, new UserRole
                {
                    RoleId = 3,
                    UserId = 8,
                }
            );
            #endregion

            #region Leaves
            modelBuilder.Entity<Shared.Models.Leave>().HasKey(c => c.Id);
            //modelBuilder.Entity<Leave>().HasOne(c => c.User).WithMany(c => c.Leaves).OnDelete(DeleteBehavior.ClientCascade);
            #endregion

            #region UserLeave
            modelBuilder.Entity<UserLeave>().HasKey(c => new { c.UserId, c.LeaveId });
            //modelBuilder.Entity<UserLeave>().HasOne(c => c.User).WithMany(c => c.Leaves).HasForeignKey(c => c.UserId);
            modelBuilder.Entity<UserLeave>().HasOne(c => c.User).WithMany(c => c.Leaves).OnDelete(DeleteBehavior.ClientCascade);
            #endregion
        }
    }
}