using HotChocolate.Types;
using NorthWind.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthWind.Api.Graph.Types
{
    public class OrdersType : ObjectType<Orders>
    {
        protected override void Configure(IObjectTypeDescriptor<Orders> descriptor)
        {
            base.Configure(descriptor);

            descriptor.Field(a => a.OrderId)
            .Description("Id of the Orders")
            .Type<NonNullType<IdType>>();
        }
    }
}
