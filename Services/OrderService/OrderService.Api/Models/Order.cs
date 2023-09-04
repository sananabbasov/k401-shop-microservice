using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OrderService.Api.Models
{
	public class Order
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }
		public string UserId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
        public string OrderNumber { get; set; }
        public List<OrderItem> OrderItems { get; set; }
	}
}

