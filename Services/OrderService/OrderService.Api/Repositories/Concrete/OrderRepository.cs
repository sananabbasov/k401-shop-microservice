using System;
using System.Linq.Expressions;
using MongoDB.Driver;
using OrderService.Api.Models;
using OrderService.Api.Repositories.Abstract;

namespace OrderService.Api.Repositories.Concrete
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IMongoCollection<Order> _collection;

        public OrderRepository()
        {
            var database = new MongoClient("mongodb://localhost:27917").GetDatabase("K401OrderService");
            _collection = database.GetCollection<Order>("orders");
        }

        public void Add(Order entity)
        {
            _collection.InsertOne(entity);
        }

        public void Delete(Order entity)
        {
            throw new NotImplementedException();
        }

        public Order Get(Expression<Func<Order, bool>> filter)
        {
            var result = _collection.Find<Order>(filter).FirstOrDefault();
            return result;
        }

        public List<Order> GetAll(Expression<Func<Order, bool>>? filter = null)
        {
            return filter == null
               ? _collection.Find(x => true).ToList()
               : _collection.Find(filter).ToList();
        }

        public void Update(Order entity)
        {
            throw new NotImplementedException();
        }

        public async void UpdateById(Expression<Func<Order, bool>> filter, Order entity)
        {
            await _collection.FindOneAndReplaceAsync(filter, entity);
        }
        public async void UpdateRangeById(Expression<Func<Order, bool>> filter, Order entity)
        {
            var updateDefinition = Builders<Order>.Update
        .Set("FirstName", entity.FirstName) // Replace "Field1" with the first field you want to update
        .Set("LastName", entity.LastName); // Replace "Field2" with the second field you want to update

            await _collection.UpdateManyAsync(filter, updateDefinition);
        }
    }
}

