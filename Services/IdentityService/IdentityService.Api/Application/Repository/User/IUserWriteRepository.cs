using System;
using Model = IdentityService.Api.Models;
namespace IdentityService.Api.Application.Repository.User
{
	public interface IUserWriteRepository : IWriteRepository<Model.User>
	{
	}
}

