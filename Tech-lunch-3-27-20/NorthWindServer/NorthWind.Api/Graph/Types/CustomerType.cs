using HotChocolate.Types;
using NorthWind.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthWind.Api.Graph.Types
{
    public class CustomerType : ObjectType<Customers>
    {
        protected override void Configure(IObjectTypeDescriptor<Customers> descriptor)
        {
            base.Configure(descriptor);

            descriptor.Field(a => a.CustomerId)
            .Description("Id of the Customer")
            .Type<NonNullType<IdType>>();
        }
    }
}
