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
            builder.EnableSortingForAllProperties();
        }
    }
}
