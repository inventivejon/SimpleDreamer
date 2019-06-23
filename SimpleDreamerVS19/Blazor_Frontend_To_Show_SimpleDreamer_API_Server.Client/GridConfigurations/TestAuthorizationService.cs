using Blazor.FlexGrid.Permission;

namespace Blazor_Frontend_To_Show_SimpleDreamer_API_Server.Client.GridConfigurations
{
    public class TestAuthorizationService : IAuthorizationService
    {
        public string UserToken => "Token";
    }
}
