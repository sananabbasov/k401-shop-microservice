using System;
using Model = IdentityService.Api.Models;
namespace IdentityService.Api.Application.Repository.User
{
	public interface IUserReadRepository : IReadRepository<Model.User>
	{
	}
}

