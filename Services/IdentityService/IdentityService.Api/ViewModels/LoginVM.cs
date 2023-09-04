using System;
namespace IdentityService.Api.ViewModels
{
	public class LoginVM
	{
		public int Status { get;  }
		public string Token { get; }
		public List<string> Errors { get; }

        public LoginVM(int status, string token, List<string> errors)
        {
            Status = status;
            Token = token;
            Errors = errors;
        }
    }
}

