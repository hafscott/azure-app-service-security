using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace Benday.EasyAuthDemo.UnitTests.Fakes
{
    public class MockAuthorizationHandler : AuthorizationHandler<MockAuthorizationRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
            MockAuthorizationRequirement requirement)
        {
            if (requirement.IsAuthorizedReturnValue == true)
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }
            
            return Task.CompletedTask;
        }
    }
}
