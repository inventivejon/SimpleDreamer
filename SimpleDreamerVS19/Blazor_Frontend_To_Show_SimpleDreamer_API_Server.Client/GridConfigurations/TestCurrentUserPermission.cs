using Blazor.FlexGrid.Permission;

namespace Blazor_Frontend_To_Show_SimpleDreamer_API_Server.Client.GridConfigurations
{
    public class TestCurrentUserPermission : ICurrentUserPermission
    {
        public bool HasClaim(string claimName)
        {
            if (claimName == "Test")
            {
                return true;
            }

            return false;
        }

        public bool IsInRole(string roleName)
        {
            if (roleName == "TestRole")
            {
                return true;
            }

            return false;
        }
    }
}
