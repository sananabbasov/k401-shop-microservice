using System;
namespace EventBus.Events
{
	public class UserInfoChangeEvent
	{
		public string UserId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
	}
}

