using System;
using IdentityService.Api.Application.Repository.User;
using IdentityService.Api.Data;
using CoreData = IdentityService.Api.Models;

namespace IdentityService.Api.Persistence.Repository.User
{
    public class UserReadRepository : ReadRepository<CoreData.User>, IUserReadRepository
    {
        public UserReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}

