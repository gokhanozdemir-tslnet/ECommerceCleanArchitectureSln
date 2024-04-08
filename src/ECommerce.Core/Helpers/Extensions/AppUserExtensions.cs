

using ECommerce.Core.Domain.Entities;
using ECommerce.Core.Domain.IdentityEntities;
using ECommerce.Core.DTOs.Request;
using ECommerce.Core.DTOs.Request.AppUser;
using ECommerce.Core.Helpers.Mapper;

namespace ECommerce.Core.Helpers.Extensions
{
    public static class AppUserExtensions
    {
        public static AppUser ToAppUser(this RegisterRequest reqUser) => AppMapperBase.Mapper.Map<AppUser>(reqUser);
        
    }
}
