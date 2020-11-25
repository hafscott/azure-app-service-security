using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Benday.EasyAuthDemo.Api.DataAccess.Entities;
using Benday.EfCore.SqlServer;
using Benday.EasyAuthDemo.Api;
using Benday.Common;
using System.Linq.Expressions;

namespace Benday.EasyAuthDemo.Api.DataAccess.SqlServer
{
    public partial interface IUserRepository :
        ISearchableRepository<UserEntity>
    {
}
}

