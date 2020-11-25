using Benday.EasyAuthDemo.Api.DomainModels;
using Benday.EasyAuthDemo.Api.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Benday.EasyAuthDemo.Api.Adapters
{
    public partial class UserClaimAdapter :
        AdapterBase<
        Benday.EasyAuthDemo.Api.DomainModels.UserClaim,
        Benday.EasyAuthDemo.Api.DataAccess.Entities.UserClaimEntity>
    {
    
    
        protected override void PerformAdapt(
            Benday.EasyAuthDemo.Api.DomainModels.UserClaim fromValue,
            Benday.EasyAuthDemo.Api.DataAccess.Entities.UserClaimEntity toValue)
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
            toValue.ClaimName = fromValue.ClaimName;
            toValue.ClaimValue = fromValue.ClaimValue;
            toValue.UserId = fromValue.UserId;
            toValue.ClaimLogicType = fromValue.ClaimLogicType;
            toValue.StartDate = fromValue.StartDate;
            toValue.EndDate = fromValue.EndDate;
            toValue.Status = fromValue.Status;
            toValue.CreatedBy = fromValue.CreatedBy;
            toValue.CreatedDate = fromValue.CreatedDate;
            toValue.LastModifiedBy = fromValue.LastModifiedBy;
            toValue.LastModifiedDate = fromValue.LastModifiedDate;
            toValue.Timestamp = fromValue.Timestamp;
            
            
        }
        
        protected override void PerformAdapt(
            Benday.EasyAuthDemo.Api.DataAccess.Entities.UserClaimEntity fromValue,
            Benday.EasyAuthDemo.Api.DomainModels.UserClaim toValue
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
            toValue.ClaimName = fromValue.ClaimName;
            toValue.ClaimValue = fromValue.ClaimValue;
            toValue.UserId = fromValue.UserId;
            toValue.ClaimLogicType = fromValue.ClaimLogicType;
            toValue.StartDate = fromValue.StartDate;
            toValue.EndDate = fromValue.EndDate;
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
