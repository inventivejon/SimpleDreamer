using Blazor.FlexGrid.Components.Configuration;
using Blazor.FlexGrid.Components.Configuration.Builders;
using Show_SimpleDreamer_API_Servers.Shared;

namespace Show_SimpleDreamer_API_Servers.Client.GridConfigurations
{
    public class OrderGridConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.AllowInlineEdit();

            builder.IsMasterTable();
            builder.HasDetailRelationship(o => o.OrderItems)
                .HasCaption("Order products");
        }
    }
}
