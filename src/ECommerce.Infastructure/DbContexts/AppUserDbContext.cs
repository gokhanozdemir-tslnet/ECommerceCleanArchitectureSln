

using ECommerce.Core.Domain.IdentityEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infastructure.DbContexts
{
    public class AppUserDbContext: IdentityDbContext<AppUser,AppRole,Guid>
    {
        public AppUserDbContext(DbContextOptions<AppUserDbContext> options): base(options) { }


    }
}
