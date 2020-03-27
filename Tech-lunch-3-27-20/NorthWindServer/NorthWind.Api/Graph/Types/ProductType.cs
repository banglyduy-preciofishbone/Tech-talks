using GreenDonut;
using HotChocolate;
using HotChocolate.Resolvers;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using NorthWind.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthWind.Api.Graph.Types
{
    public class ProductType : ObjectType<Products>
    {
        protected override void Configure(IObjectTypeDescriptor<Products> descriptor)
        {
            base.Configure(descriptor);

            descriptor.Field(a => a.ProductId)
                .Description("Id of the product")
                .Type<NonNullType<IdType>>();

            descriptor.Field(a => a.ProductName)
                .Type<NonNullType<StringType>>();

            descriptor.Field(a => a.CategoryId).Ignore();

            descriptor.Field(a => a.SupplierId).Ignore();

            descriptor.Field("stockstatus")

                .Type<StringType>()
                .Resolver(ctx => ctx.Parent<Products>().UnitsInStock > 0 ? "available" : "out of stock");

            descriptor.Field<ProductType>(p => ResolveSupplier(default, default, default))
                .Name("supplier")
                .Type<SupplierType>();

        }

        public Task<Suppliers> ResolveSupplier(IResolverContext context,[Parent] Products product,[Service] NorthWindContext dbContext)
        {
            var key = product.SupplierId.Value;
            return context.BatchDataLoader<int, Suppliers>(nameof(ResolveSupplier),
                async keys =>
                {
                    return await dbContext.Suppliers
                        .Where(a => keys.Contains(a.SupplierId))
                        .ToDictionaryAsync(a => a.SupplierId, a => a);
                }).LoadAsync(key);
        }
    }
}
