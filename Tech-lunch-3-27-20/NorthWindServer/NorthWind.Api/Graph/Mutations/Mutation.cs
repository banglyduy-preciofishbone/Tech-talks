using HotChocolate;
using NorthWind.Api.Models;
using NorthWind.Api.Models.Mutations;
using System.Threading.Tasks;

namespace NorthWind.Api.Graph.Mutations
{
    public class Mutation
    {
        public async Task<Products> SubmitProducts([Service] NorthWindContext dbContext, SubmitProduct submitProduct ) {
            var product = new Products
            {
                ProductName = submitProduct.ProductName,
                SupplierId = submitProduct.SupplierId,
                CategoryId = submitProduct.CategoryId,
                QuantityPerUnit = submitProduct.QuantityPerUnit,
                UnitPrice = submitProduct.UnitPrice,
                UnitsInStock = submitProduct.UnitsInStock,
                UnitsOnOrder = submitProduct.UnitsOnOrder,
                ReorderLevel = submitProduct.ReorderLevel,
                Discontinued = submitProduct.Discontinued,
            };
            dbContext.Products.Add(product);
            await dbContext.SaveChangesAsync();
            return product;
        }

        public async Task<Suppliers> SubmitSuppliers([Service] NorthWindContext dbContext, Suppliers submitSupplier)
        {
            var result = dbContext.Suppliers.Add(submitSupplier);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

    }
}
