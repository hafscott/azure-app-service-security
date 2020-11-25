using System;

namespace Benday.EasyAuthDemo.Api
{
    public interface IUsernameProvider
    {
        string Username { get; }
    }
}
