using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Benday.EasyAuthDemo.Api.Security
{
    public interface IUserInformation
    {
        List<Claim> Claims { get; }
        string EmailAddress { get; }
        string FirstName { get; }
        bool IsLoggedIn { get; }
        string LastName { get; }
        string Source { get; }
        string Username { get; }
        int UserId { get; }
    }
}
