using CoreUser = K123ShopApp.Core.Entities.Concrete;

namespace IdentityService.Api.Models
{
    public class User : BaseEntity
    {
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool EmailConfirmed { get; set; }
        public string ConfirmationToken { get; set; }
        public int LoginAttempt { get; set; }
        public string Name { get; set; }
		public string Surname { get; set; }
		public string CompanyName { get; set; }
	}
}

