using HotChocolate;
using Microsoft.EntityFrameworkCore;
using NorthWind.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthWind.Api.Graph.Queries
{
    public class Query
    {
        public async Task<IReadOnlyList<Products>> GetProducts([Service] NorthWindContext context)
        {
            return await context.Products.OrderByDescending(p => p.ReorderLevel).ToListAsync();
        }

        public Task<Products> GetProduct([Service] NorthWindContext context, int id) => context.Products.FirstOrDefaultAsync(p => p.ProductId == id);

        public Task<Suppliers> GetSupplier([Service] NorthWindContext context, int id) => context.Suppliers.FirstOrDefaultAsync(p => p.SupplierId == id);

        public Task<Customers> GetCustomer([Service] NorthWindContext context, string id) => context.Customers.FirstOrDefaultAsync(p => p.CustomerId.Equals(id));

        public Task<Orders> GetOrder([Service] NorthWindContext context, int id) => context.Orders.FirstOrDefaultAsync(p => p.OrderId == id);

    }
}
