using HotChocolate.Types;
using NorthWind.Api.Graph.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthWind.Api.Graph.Queries
{
    public class QueryType : ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            base.Configure(descriptor);

            descriptor.Field(q => q.GetProducts(default))
                .Type<NonNullType<ListType<NonNullType<ProductType>>>>();

            descriptor.Field(q => q.GetProduct(default, default))
                .Argument("id", a => a.Type<NonNullType<IdType>>());

            descriptor.Field(q => q.GetCustomer(default, default))
                .Argument("id", a => a.Type<NonNullType<IdType>>());

            descriptor.Field(q => q.GetOrder(default, default))
                .Argument("id", a => a.Type<NonNullType<IdType>>());

            descriptor.Field(q => q.GetSupplier(default, default))
                .Argument("id", a => a.Type<NonNullType<IdType>>());
        }
    }
}
