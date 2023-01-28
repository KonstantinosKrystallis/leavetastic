This code includes a dependency on Duende IdentityServer.
This is an open source product with a reciprocal license agreement. If you plan to use Duende IdentityServer in production this may require a license fee.
To see how to use Azure Active Directory for your identity please see https://aka.ms/aspnetidentityserver
To see if you require a commercial license for Duende IdentityServer please see https://aka.ms/identityserverlicense


For database first with Entity Framework use the following command in the Packet Manager Console, to create all the required models:

Scaffold-DbContext "Server=(localdb)\mssqllocaldb;Database=aspnet-LeaveTastic;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir ../Shared/Models -ContextDir Data -NoOnConfiguring -Context ApplicationDbContext -Force -Namespace LeaveTastic.Shared.Models -ContextNamespace LeaveTastic.Server.Data