using Blazor.FlexGrid.Components.Configuration;
using Blazor.FlexGrid.Components.Configuration.Builders;
using Show_SimpleDreamer_API_Servers.Shared;

namespace Show_SimpleDreamer_API_Servers.Client.GridConfigurations
{
    public class BasicBackendInformationGridConfiguration : IEntityTypeConfiguration<BasicBackendInformation>
    {
        public void Configure(EntityTypeBuilder<BasicBackendInformation> builder)
        {
            builder.IsMasterTable();

            /*
            IpAddress = "192.168.10.65",
            Port = "80" + index.ToString("{XX}"),
            Name = "Default server",
            Description = "Default server description",
            Tags = "RandomPics",
            Country = "Germany"
             */

            /*
            builder.HasDetailRelationship<Order>(c => c.Id, o => o.CustomerId)
               .HasLazyLoadingUrl("api/Order/Orders")
               .HasUpdateUrl("api/Order/UpdateOrder")
               .HasCaption("Orders")
               .HasPageSize(10);

            builder.HasDetailRelationship<CustomerAddress>(c => c.Id, o => o.CustomerId)
                .HasCaption("Customer addresses");
            */


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
