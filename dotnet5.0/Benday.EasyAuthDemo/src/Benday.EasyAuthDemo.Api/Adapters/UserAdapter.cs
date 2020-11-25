using Benday.EasyAuthDemo.Api.DomainModels;
using Benday.EasyAuthDemo.Api.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Benday.EasyAuthDemo.Api.Adapters
{
    public partial class UserAdapter :
        AdapterBase<
        Benday.EasyAuthDemo.Api.DomainModels.User,
        Benday.EasyAuthDemo.Api.DataAccess.Entities.UserEntity>
    {
    
    
        protected override void PerformAdapt(
            Benday.EasyAuthDemo.Api.DomainModels.User fromValue,
            Benday.EasyAuthDemo.Api.DataAccess.Entities.UserEntity toValue)
        {
            if (fromValue == null)
            {
                throw new ArgumentNullException(nameof(fromValue));
            }
            
            if (toValue == null)
            {
                throw new ArgumentNullException(nameof(toValue));
            }
            
            toValue.Id = fromValue.Id;
            toValue.Username = fromValue.Username;
            toValue.Source = fromValue.Source;
            toValue.EmailAddress = fromValue.EmailAddress;
            toValue.FirstName = fromValue.FirstName;
            toValue.LastName = fromValue.LastName;
            toValue.PhoneNumber = fromValue.PhoneNumber;
            new UserClaimAdapter().Adapt(
            fromValue.Claims,
            toValue.Claims);
            toValue.Status = fromValue.Status;
            toValue.CreatedBy = fromValue.CreatedBy;
            toValue.CreatedDate = fromValue.CreatedDate;
            toValue.LastModifiedBy = fromValue.LastModifiedBy;
            toValue.LastModifiedDate = fromValue.LastModifiedDate;
            toValue.Timestamp = fromValue.Timestamp;
            
            
        }
        
        protected override void PerformAdapt(
            Benday.EasyAuthDemo.Api.DataAccess.Entities.UserEntity fromValue,
            Benday.EasyAuthDemo.Api.DomainModels.User toValue
            )
        {
            if (fromValue == null)
            {
                throw new ArgumentNullException(nameof(fromValue));
            }
            
            if (toValue == null)
            {
                throw new ArgumentNullException(nameof(toValue));
            }
            
            toValue.Id = fromValue.Id;
            toValue.Username = fromValue.Username;
            toValue.Source = fromValue.Source;
            toValue.EmailAddress = fromValue.EmailAddress;
            toValue.FirstName = fromValue.FirstName;
            toValue.LastName = fromValue.LastName;
            toValue.PhoneNumber = fromValue.PhoneNumber;
            new UserClaimAdapter().Adapt(
            fromValue.Claims,
            toValue.Claims);
            toValue.Status = fromValue.Status;
            toValue.CreatedBy = fromValue.CreatedBy;
            toValue.CreatedDate = fromValue.CreatedDate;
            toValue.LastModifiedBy = fromValue.LastModifiedBy;
            toValue.LastModifiedDate = fromValue.LastModifiedDate;
            toValue.Timestamp = fromValue.Timestamp;
            
            toValue.AcceptChanges();
            
        }
    }
}
