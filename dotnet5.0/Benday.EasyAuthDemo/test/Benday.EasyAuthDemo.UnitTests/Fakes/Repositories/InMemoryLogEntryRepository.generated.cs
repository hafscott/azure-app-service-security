using Benday.EasyAuthDemo.Api;
using Benday.EasyAuthDemo.Api.DataAccess.Entities;
using Benday.EfCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using Benday.Common;
using Benday.EasyAuthDemo.Api.DataAccess.SqlServer;

namespace Benday.EasyAuthDemo.UnitTests.Fakes.Repositories
{
    public partial class InMemoryLogEntryRepository :
        InMemoryRepository<LogEntryEntity>, ILogEntryRepository
    {
}
}
