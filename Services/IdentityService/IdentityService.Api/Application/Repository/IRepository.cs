using System;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.Api.Application.Repository
{
	public interface IRepository<T> where T : class
    {
        DbSet<T> Table { get; }
    }
}

