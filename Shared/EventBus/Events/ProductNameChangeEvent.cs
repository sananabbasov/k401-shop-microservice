using System;
namespace EventBus.Events
{
	public class ProductNameChangeEvent
	{
		public int Id { get; set; }
		public string ProductName { get; set; }
	}
}

