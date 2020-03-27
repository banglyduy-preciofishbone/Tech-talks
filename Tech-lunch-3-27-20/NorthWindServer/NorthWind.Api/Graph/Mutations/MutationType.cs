using HotChocolate.Types;
using NorthWind.Api.Graph.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthWind.Api.Graph.Mutations
{
    public class MutationType : ObjectType<Mutation>
    {
        protected override void Configure(IObjectTypeDescriptor<Mutation> descriptor)
        {
            base.Configure(descriptor);

            descriptor.Field(m => m.SubmitProducts(default, default))
              .Type<ProductType>()
              .Argument("submitProduct", a => a.Type<NonNullType<SubmitProductType>>());
        }
    }
}
