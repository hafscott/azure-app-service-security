using Benday.EasyAuthDemo.Api.DomainModels;
using System.Collections.Generic;

namespace Benday.EasyAuthDemo.Api
{
    public interface IDomainModelAttribute
    {
        string AttributeKey { get; set; }
        string AttributeValue { get; set; }
    }
}
