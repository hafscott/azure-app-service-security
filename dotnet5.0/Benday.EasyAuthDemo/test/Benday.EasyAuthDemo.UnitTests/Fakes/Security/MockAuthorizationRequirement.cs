using Microsoft.AspNetCore.Authorization;

namespace Benday.EasyAuthDemo.UnitTests.Fakes
{
    public class MockAuthorizationRequirement : IAuthorizationRequirement
    {
        public MockAuthorizationRequirement(bool isAuthorizedReturnValue)
        {
            IsAuthorizedReturnValue = isAuthorizedReturnValue;
        }
        
        public bool IsAuthorizedReturnValue { get; set; }
    }
}
