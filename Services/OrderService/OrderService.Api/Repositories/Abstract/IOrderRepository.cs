using System;
using System.Linq.Expressions;
using OrderService.Api.Models;

namespace OrderService.Api.Repositories.Abstract
{
	public interface IOrderRepository
    {
        void Add(Order entity);
        void Update(Order entity);
        void Delete(Order entity);
        void UpdateById(Expression<Func<Order, bool>> filter, Order entity);
        void UpdateRangeById(Expression<Func<Order, bool>> filter, Order entity);
        Order Get(Expression<Func<Order, bool>> filter);
        List<Order> GetAll(Expression<Func<Order, bool>>? filter = null);
    }
}

