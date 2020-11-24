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
    public partial class SqlEntityFrameworkPersonRepository : 
		SqlEntityFrameworkSearchableRepositoryBase<PersonEntity, EasyAuthDemoDbContext>, 
		ISearchableRepository<PersonEntity>
    {
		public SqlEntityFrameworkPersonRepository(
            EasyAuthDemoDbContext context) : base(context)
        {

        }

        private List<string> _Includes;

        protected override List<string> Includes
        {
            get
            {
                if (_Includes == null)
                {
                    _Includes = new List<string>();

                    
                }

                return _Includes;
            }
        }

		
        protected override DbSet<PersonEntity> EntityDbSet => Context.PersonEntities;

		protected override Expression<Func<PersonEntity, bool>> GetPredicateForContains(
            SearchArgument arg)
        {
			if (arg is null)
            {
                throw new ArgumentNullException(nameof(arg));
            }
            else
            {
                if (arg.PropertyName == "Thingy")
    {
		// TODO: search logic goes here 
		return null;
    }

				if (arg.PropertyName == nameof(PersonEntity.FirstName))
    {
        return q => q.FirstName.Contains(arg.SearchValue);
    }
else if (arg.PropertyName == nameof(PersonEntity.LastName))
    {
        return q => q.LastName.Contains(arg.SearchValue);
    }
else if (arg.PropertyName == nameof(PersonEntity.PhoneNumber))
    {
        return q => q.PhoneNumber.Contains(arg.SearchValue);
    }
else if (arg.PropertyName == nameof(PersonEntity.EmailAddress))
    {
        return q => q.EmailAddress.Contains(arg.SearchValue);
    }
else if (arg.PropertyName == nameof(PersonEntity.Status))
    {
        return q => q.Status.Contains(arg.SearchValue);
    }
else if (arg.PropertyName == nameof(PersonEntity.CreatedBy))
    {
        return q => q.CreatedBy.Contains(arg.SearchValue);
    }
else if (arg.PropertyName == nameof(PersonEntity.LastModifiedBy))
    {
        return q => q.LastModifiedBy.Contains(arg.SearchValue);
    }

				else
                {
                    throw new InvalidOperationException(
                        String.Format("Unknown argument '{0}'.", arg.PropertyName));
                }
			}
        }

		protected override Expression<Func<PersonEntity, bool>> GetPredicateForDoesNotContain(
            SearchArgument arg)
        {
            if (arg is null)
            {
                throw new ArgumentNullException(nameof(arg));
            }
            else
            {
                if (arg.PropertyName == nameof(PersonEntity.FirstName))
    {
        return q => q.FirstName.Contains(arg.SearchValue) == false;
    }
else if (arg.PropertyName == nameof(PersonEntity.LastName))
    {
        return q => q.LastName.Contains(arg.SearchValue) == false;
    }
else if (arg.PropertyName == nameof(PersonEntity.PhoneNumber))
    {
        return q => q.PhoneNumber.Contains(arg.SearchValue) == false;
    }
else if (arg.PropertyName == nameof(PersonEntity.EmailAddress))
    {
        return q => q.EmailAddress.Contains(arg.SearchValue) == false;
    }
else if (arg.PropertyName == nameof(PersonEntity.Status))
    {
        return q => q.Status.Contains(arg.SearchValue) == false;
    }
else if (arg.PropertyName == nameof(PersonEntity.CreatedBy))
    {
        return q => q.CreatedBy.Contains(arg.SearchValue) == false;
    }
else if (arg.PropertyName == nameof(PersonEntity.LastModifiedBy))
    {
        return q => q.LastModifiedBy.Contains(arg.SearchValue) == false;
    }

				else
                {
                    throw new InvalidOperationException(
                        String.Format("Unknown argument '{0}'.", arg.PropertyName));
                }
			}
        }

		protected override Expression<Func<PersonEntity, bool>> GetPredicateForStartsWith(
            SearchArgument arg)
        {
            if (arg is null)
            {
                throw new ArgumentNullException(nameof(arg));
            }
            else
            {
                if (arg.PropertyName == nameof(PersonEntity.FirstName))
    {
        return q => q.FirstName.StartsWith(arg.SearchValue);
    }
else if (arg.PropertyName == nameof(PersonEntity.LastName))
    {
        return q => q.LastName.StartsWith(arg.SearchValue);
    }
else if (arg.PropertyName == nameof(PersonEntity.PhoneNumber))
    {
        return q => q.PhoneNumber.StartsWith(arg.SearchValue);
    }
else if (arg.PropertyName == nameof(PersonEntity.EmailAddress))
    {
        return q => q.EmailAddress.StartsWith(arg.SearchValue);
    }
else if (arg.PropertyName == nameof(PersonEntity.Status))
    {
        return q => q.Status.StartsWith(arg.SearchValue);
    }
else if (arg.PropertyName == nameof(PersonEntity.CreatedBy))
    {
        return q => q.CreatedBy.StartsWith(arg.SearchValue);
    }
else if (arg.PropertyName == nameof(PersonEntity.LastModifiedBy))
    {
        return q => q.LastModifiedBy.StartsWith(arg.SearchValue);
    }

				else
                {
                    throw new InvalidOperationException(
                        String.Format("Unknown argument '{0}'.", arg.PropertyName));
                }
			}
        }

		protected override Expression<Func<PersonEntity, bool>> GetPredicateForEndsWith(
            SearchArgument arg)
        {
            if (arg is null)
            {
                throw new ArgumentNullException(nameof(arg));
            }
            else
            {
                if (arg.PropertyName == nameof(PersonEntity.FirstName))
    {
        return q => 
            q.FirstName.EndsWith(arg.SearchValue);
    }
else if (arg.PropertyName == nameof(PersonEntity.LastName))
    {
        return q => 
            q.LastName.EndsWith(arg.SearchValue);
    }
else if (arg.PropertyName == nameof(PersonEntity.PhoneNumber))
    {
        return q => 
            q.PhoneNumber.EndsWith(arg.SearchValue);
    }
else if (arg.PropertyName == nameof(PersonEntity.EmailAddress))
    {
        return q => 
            q.EmailAddress.EndsWith(arg.SearchValue);
    }
else if (arg.PropertyName == nameof(PersonEntity.Status))
    {
        return q => 
            q.Status.EndsWith(arg.SearchValue);
    }
else if (arg.PropertyName == nameof(PersonEntity.CreatedBy))
    {
        return q => 
            q.CreatedBy.EndsWith(arg.SearchValue);
    }
else if (arg.PropertyName == nameof(PersonEntity.LastModifiedBy))
    {
        return q => 
            q.LastModifiedBy.EndsWith(arg.SearchValue);
    }

				else
                {
                    throw new InvalidOperationException(
                        String.Format("Unknown argument '{0}'.", arg.PropertyName));
                }
			}
        }

		protected override Expression<Func<PersonEntity, bool>> GetPredicateForEquals(
            SearchArgument arg)
        {
            if (arg is null)
            {
                throw new ArgumentNullException(nameof(arg));
            }
            else
            {
                if (arg.PropertyName == "Thingy")
    {
		// TODO: search logic goes here  
		return null;
    }

				if (arg.PropertyName == nameof(PersonEntity.FirstName))
    {
        return q => q.FirstName == arg.SearchValue;
    }
else if (arg.PropertyName == nameof(PersonEntity.LastName))
    {
        return q => q.LastName == arg.SearchValue;
    }
else if (arg.PropertyName == nameof(PersonEntity.PhoneNumber))
    {
        return q => q.PhoneNumber == arg.SearchValue;
    }
else if (arg.PropertyName == nameof(PersonEntity.EmailAddress))
    {
        return q => q.EmailAddress == arg.SearchValue;
    }
else if (arg.PropertyName == nameof(PersonEntity.Status))
    {
        return q => q.Status == arg.SearchValue;
    }
else if (arg.PropertyName == nameof(PersonEntity.CreatedBy))
    {
        return q => q.CreatedBy == arg.SearchValue;
    }
else if (arg.PropertyName == nameof(PersonEntity.LastModifiedBy))
    {
        return q => q.LastModifiedBy == arg.SearchValue;
    }

				else
                {
                    throw new InvalidOperationException(
                        String.Format("Unknown argument '{0}'.", arg.PropertyName));
                }
			}
        }

		protected override Expression<Func<PersonEntity, bool>> GetPredicateForIsNotEqualTo(
            SearchArgument arg)
        {
            if (arg is null)
            {
                throw new ArgumentNullException(nameof(arg));
            }
            else
            {
                if (arg.PropertyName == nameof(PersonEntity.FirstName))
    {
        return q => q.FirstName == arg.SearchValue;
    }
else if (arg.PropertyName == nameof(PersonEntity.LastName))
    {
        return q => q.LastName == arg.SearchValue;
    }
else if (arg.PropertyName == nameof(PersonEntity.PhoneNumber))
    {
        return q => q.PhoneNumber == arg.SearchValue;
    }
else if (arg.PropertyName == nameof(PersonEntity.EmailAddress))
    {
        return q => q.EmailAddress == arg.SearchValue;
    }
else if (arg.PropertyName == nameof(PersonEntity.Status))
    {
        return q => q.Status == arg.SearchValue;
    }
else if (arg.PropertyName == nameof(PersonEntity.CreatedBy))
    {
        return q => q.CreatedBy == arg.SearchValue;
    }
else if (arg.PropertyName == nameof(PersonEntity.LastModifiedBy))
    {
        return q => q.LastModifiedBy == arg.SearchValue;
    }

				else
                {
                    throw new InvalidOperationException(
                        String.Format("Unknown argument '{0}'.", arg.PropertyName));
                }
			}
        }

		protected override IOrderedQueryable<PersonEntity> AddSortAscending(IOrderedQueryable<PersonEntity> query, string propertyName, bool isFirstSort)
    {
if (String.Compare(propertyName, "Id", true) == 0)
    {
		if (isFirstSort == true)
        {
            return query.OrderBy(x => x.Id);
        }
        else
        {
            return query.ThenBy(x => x.Id);
        }
    }
else if (String.Compare(propertyName, "FirstName", true) == 0)
    {
		if (isFirstSort == true)
        {
            return query.OrderBy(x => x.FirstName);
        }
        else
        {
            return query.ThenBy(x => x.FirstName);
        }
    }
else if (String.Compare(propertyName, "LastName", true) == 0)
    {
		if (isFirstSort == true)
        {
            return query.OrderBy(x => x.LastName);
        }
        else
        {
            return query.ThenBy(x => x.LastName);
        }
    }
else if (String.Compare(propertyName, "PhoneNumber", true) == 0)
    {
		if (isFirstSort == true)
        {
            return query.OrderBy(x => x.PhoneNumber);
        }
        else
        {
            return query.ThenBy(x => x.PhoneNumber);
        }
    }
else if (String.Compare(propertyName, "EmailAddress", true) == 0)
    {
		if (isFirstSort == true)
        {
            return query.OrderBy(x => x.EmailAddress);
        }
        else
        {
            return query.ThenBy(x => x.EmailAddress);
        }
    }
else if (String.Compare(propertyName, "Status", true) == 0)
    {
		if (isFirstSort == true)
        {
            return query.OrderBy(x => x.Status);
        }
        else
        {
            return query.ThenBy(x => x.Status);
        }
    }
else if (String.Compare(propertyName, "CreatedBy", true) == 0)
    {
		if (isFirstSort == true)
        {
            return query.OrderBy(x => x.CreatedBy);
        }
        else
        {
            return query.ThenBy(x => x.CreatedBy);
        }
    }
else if (String.Compare(propertyName, "CreatedDate", true) == 0)
    {
		if (isFirstSort == true)
        {
            return query.OrderBy(x => x.CreatedDate);
        }
        else
        {
            return query.ThenBy(x => x.CreatedDate);
        }
    }
else if (String.Compare(propertyName, "LastModifiedBy", true) == 0)
    {
		if (isFirstSort == true)
        {
            return query.OrderBy(x => x.LastModifiedBy);
        }
        else
        {
            return query.ThenBy(x => x.LastModifiedBy);
        }
    }
else if (String.Compare(propertyName, "LastModifiedDate", true) == 0)
    {
		if (isFirstSort == true)
        {
            return query.OrderBy(x => x.LastModifiedDate);
        }
        else
        {
            return query.ThenBy(x => x.LastModifiedDate);
        }
    }
else if (String.Compare(propertyName, "Timestamp", true) == 0)
    {
		if (isFirstSort == true)
        {
            return query.OrderBy(x => x.Timestamp);
        }
        else
        {
            return query.ThenBy(x => x.Timestamp);
        }
    }
else
        {		
            throw new InvalidOperationException(
                String.Format("Unknown sort argument '{0}'.", propertyName));
		}
	}

		protected override IOrderedQueryable<PersonEntity> AddSortDescending(IOrderedQueryable<PersonEntity> query, string propertyName, bool isFirstSort)
    {
if (String.Compare(propertyName, "Id", true) == 0)
    {
		if (isFirstSort == true)
        {
            return query.OrderByDescending(x => x.Id);
        }
        else
        {
            return query.ThenByDescending(x => x.Id);
        }
    }
else if (String.Compare(propertyName, "FirstName", true) == 0)
    {
		if (isFirstSort == true)
        {
            return query.OrderByDescending(x => x.FirstName);
        }
        else
        {
            return query.ThenByDescending(x => x.FirstName);
        }
    }
else if (String.Compare(propertyName, "LastName", true) == 0)
    {
		if (isFirstSort == true)
        {
            return query.OrderByDescending(x => x.LastName);
        }
        else
        {
            return query.ThenByDescending(x => x.LastName);
        }
    }
else if (String.Compare(propertyName, "PhoneNumber", true) == 0)
    {
		if (isFirstSort == true)
        {
            return query.OrderByDescending(x => x.PhoneNumber);
        }
        else
        {
            return query.ThenByDescending(x => x.PhoneNumber);
        }
    }
else if (String.Compare(propertyName, "EmailAddress", true) == 0)
    {
		if (isFirstSort == true)
        {
            return query.OrderByDescending(x => x.EmailAddress);
        }
        else
        {
            return query.ThenByDescending(x => x.EmailAddress);
        }
    }
else if (String.Compare(propertyName, "Status", true) == 0)
    {
		if (isFirstSort == true)
        {
            return query.OrderByDescending(x => x.Status);
        }
        else
        {
            return query.ThenByDescending(x => x.Status);
        }
    }
else if (String.Compare(propertyName, "CreatedBy", true) == 0)
    {
		if (isFirstSort == true)
        {
            return query.OrderByDescending(x => x.CreatedBy);
        }
        else
        {
            return query.ThenByDescending(x => x.CreatedBy);
        }
    }
else if (String.Compare(propertyName, "CreatedDate", true) == 0)
    {
		if (isFirstSort == true)
        {
            return query.OrderByDescending(x => x.CreatedDate);
        }
        else
        {
            return query.ThenByDescending(x => x.CreatedDate);
        }
    }
else if (String.Compare(propertyName, "LastModifiedBy", true) == 0)
    {
		if (isFirstSort == true)
        {
            return query.OrderByDescending(x => x.LastModifiedBy);
        }
        else
        {
            return query.ThenByDescending(x => x.LastModifiedBy);
        }
    }
else if (String.Compare(propertyName, "LastModifiedDate", true) == 0)
    {
		if (isFirstSort == true)
        {
            return query.OrderByDescending(x => x.LastModifiedDate);
        }
        else
        {
            return query.ThenByDescending(x => x.LastModifiedDate);
        }
    }
else if (String.Compare(propertyName, "Timestamp", true) == 0)
    {
		if (isFirstSort == true)
        {
            return query.OrderByDescending(x => x.Timestamp);
        }
        else
        {
            return query.ThenByDescending(x => x.Timestamp);
        }
    }
else
        {		
            throw new InvalidOperationException(
                String.Format("Unknown sort argument '{0}'.", propertyName));
		}
	}

	}
}
