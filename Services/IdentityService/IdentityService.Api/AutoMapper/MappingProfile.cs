using System;
using AutoMapper;
using IdentityService.Api.Dtos;
using IdentityService.Api.Models;
using CoreUser = K123ShopApp.Core.Entities.Concrete;

namespace IdentityService.Api.AutoMapper
{
	public class MappingProfile : Profile
    {
		public MappingProfile()
		{
			CreateMap<User, UserInfoDto>().ReverseMap();
			CreateMap<User, UserLoginDto>().ReverseMap();
			CreateMap<User, UserRegisterDto>().ReverseMap();
			CreateMap<User, CoreUser.User>().ReverseMap();

        }
	}
}

