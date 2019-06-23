using Blazor.FlexGrid.Permission;

namespace Show_SimpleDreamer_API_Servers.Client.GridConfigurations
{
    public class TestAuthorizationService : IAuthorizationService
    {
        public string UserToken => "Token";
    }
}
