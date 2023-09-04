using System;
namespace EventBus.Events
{
	public class CompanyNameChangedEvent
	{
		public int UserId { get; set; }
		public string ChangedName { get; set; }
	}
}

