using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EventBus.Events;
using IdentityService.Api.Application.Repository.User;
using IdentityService.Api.Data;
using IdentityService.Api.Dtos;
using IdentityService.Api.Models;
using IdentityService.Api.ViewModels;
using K123ShopApp.Core.Utilities.Results.Concrete.ErrorResults;
using K123ShopApp.Core.Utilities.Security.Hashing;
using K123ShopApp.Core.Utilities.Security.Jwt;
using MassTransit;
using MassTransit.Transports;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using CoreUser = K123ShopApp.Core.Entities.Concrete;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IdentityService.Api.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserReadRepository _userReadRepository;
        private readonly IUserWriteRepository _userWriteRepository;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;
        public UserController(IUserReadRepository userReadRepository, IUserWriteRepository userWriteRepository, IMapper mapper, IPublishEndpoint publishEndpoint)
        {
            _userReadRepository = userReadRepository;
            _userWriteRepository = userWriteRepository;
            _mapper = mapper;
            _publishEndpoint = publishEndpoint;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]UserRegisterDto userRegister)
        {
            var map = _mapper.Map<User>(userRegister);
            byte[] passwordHash, passordSalt;
            PasswordHashing.HashPassword(userRegister.Password, out passwordHash, out passordSalt);
            map.PasswordHash = passwordHash;
            map.PasswordSalt = passordSalt;
            map.ConfirmationToken = Guid.NewGuid().ToString();
            await _userWriteRepository.AddAsync(map);
            await _userWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userLogin)
        {
            var user =await _userReadRepository.GetSingleAsync(x => x.Email == userLogin.Email);
            CoreUser.User changeWrong = new()
            {
                Id = 1,
                Email = user.Email
            };
            var token = Token.CreateToken(changeWrong, "User");
            LoginVM login = new(200,token,null);
            return Ok(login);
        }

        [Authorize("Admin")]
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var users = _userReadRepository.GetAll();
            var map = _mapper.Map<List<UserInfoDto>>(users);
            return Ok(map);
        }



        [Authorize]
        [HttpPost("update")]
        public async Task<IActionResult> Update(string companyName)
        {
            var _bearer_token = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(_bearer_token);
            var userId = jwtSecurityToken.Claims.FirstOrDefault(x => x.Type == "nameid").Value;

            var user = await _userReadRepository.GetByIdAsync(userId);
            user.CompanyName = companyName;
            await _userWriteRepository.SaveAsync();
            return Ok();
        }

        [Authorize]
        [HttpPost("updateinfo")]
        public async Task<IActionResult> UpdateUserInfo([FromBody]UserUpdateDto userInfo)
        {
            var _bearer_token = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(_bearer_token);
            var userId = jwtSecurityToken.Claims.FirstOrDefault(x => x.Type == "nameid").Value;

            var user = await _userReadRepository.GetByIdAsync(userId);
            user.Name = userInfo.FirstName;
            user.Surname = userInfo.LastName;
            await _userWriteRepository.SaveAsync();
            UserInfoChangeEvent userData = new()
            {
                UserId = userId,
                FirstName = userInfo.FirstName,
                LastName = userInfo.LastName
            };
            await _publishEndpoint.Publish<UserInfoChangeEvent>(userData);

            return Ok();
        }
    }
}

