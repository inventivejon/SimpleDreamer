﻿using Blazor.FlexGrid.Components.Configuration;
using Blazor.FlexGrid.Components.Configuration.Builders;
using Blazor_Frontend_To_Show_SimpleDreamer_API_Server.Shared;

namespace Blazor_Frontend_To_Show_SimpleDreamer_API_Server.Client.GridConfigurations
{
    public class CustomerGridConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.IsMasterTable();
            builder.HasDetailRelationship<Order>(c => c.Id, o => o.CustomerId)
               .HasLazyLoadingUrl("api/Order/Orders")
               .HasUpdateUrl("api/Order/UpdateOrder")
               .HasCaption("Orders")
               .HasPageSize(10);

            builder.HasDetailRelationship<CustomerAddress>(c => c.Id, o => o.CustomerId)
                .HasCaption("Customer addresses");


            /* RenderFragment<Customer> customerEmailComponent = (Customer customer) => delegate (RenderTreeBuilder rendererTreeBuilder)
             {
                 var internalBuilder = new BlazorRendererTreeBuilder(rendererTreeBuilder);
                 internalBuilder
                     .OpenElement(HtmlTagNames.H4)
                     .AddContent(customer.Email)
                     .CloseElement();
             };

             builder.Property(c => c.Email)
                 .HasBlazorComponentValueRender(customerEmailComponent);
                 */
        }
    }
}