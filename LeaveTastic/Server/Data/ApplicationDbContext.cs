using Duende.IdentityServer.EntityFramework.Options;
using LeaveTastic.Server.Models;
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
        public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
        {
        }
    }
}