using HotChocolate.Types;
using NorthWind.Api.Models.Mutations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthWind.Api.Graph.Types
{
    public class SubmitProductType : InputObjectType<SubmitProduct>
    {
        protected override void Configure(IInputObjectTypeDescriptor<SubmitProduct> descriptor)
        {
            base.Configure(descriptor);

            descriptor.Field(i => i.SupplierId)
                .Type<IdType>();

            descriptor.Field(i => i.CategoryId)
                .Type<IdType>();

            descriptor.Field(i => i.ProductName)
                .Type<NonNullType<StringType>>();

        }
    }
}
