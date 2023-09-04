using System;
namespace IdentityService.Api.Dtos
{
    public class UserRegisterDto
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string CompanyName { get; set; }
    }
}

