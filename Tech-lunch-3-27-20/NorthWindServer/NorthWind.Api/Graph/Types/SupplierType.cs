using HotChocolate.Types;
using NorthWind.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthWind.Api.Graph.Types
{
    public class SupplierType : ObjectType<Suppliers>
    {
        protected override void Configure(IObjectTypeDescriptor<Suppliers> descriptor)
        {
            base.Configure(descriptor);

            descriptor.Field(a => a.SupplierId)
            .Description("Id of the Supplier")
            .Type<NonNullType<IdType>>();
        }
    }
}
