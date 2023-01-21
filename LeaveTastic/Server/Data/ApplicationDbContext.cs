using Duende.IdentityServer.EntityFramework.Options;
using LeaveTastic.Server.Models;
using LeaveTastic.Shared.Models;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

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
        DbSet<User> _users;
        DbSet<Role> _roles;
        DbSet<UserRole> _rolesForUser;

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
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
        }
    }
}