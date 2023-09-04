using System;
using IdentityService.Api.Application.Repository.User;
using IdentityService.Api.Data;
using CoreData = IdentityService.Api.Models;
namespace IdentityService.Api.Persistence.Repository.User
{
    public class UserWriteRepository : WriteRepository<CoreData.User>, IUserWriteRepository
    {
        public UserWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}

