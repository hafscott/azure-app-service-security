using Benday.EasyAuthDemo.Api.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Benday.EasyAuthDemo.Api;
using Benday.EasyAuthDemo.Api.Adapters;
using Benday.EasyAuthDemo.WebUi.Models;

namespace Benday.EasyAuthDemo.WebUi.Models.Adapters
{
    public partial class UserEditorViewModelAdapter :
        AdapterBase<
        Benday.EasyAuthDemo.Api.DomainModels.User,
        Benday.EasyAuthDemo.WebUi.Models.UserEditorViewModel>
    {
        protected override void PerformAdapt(
            Benday.EasyAuthDemo.Api.DomainModels.User fromValue,
            Benday.EasyAuthDemo.WebUi.Models.UserEditorViewModel toValue)
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
            new UserClaimEditorViewModelAdapter().Adapt(
            fromValue.Claims,
            toValue.Claims);
            toValue.Status = fromValue.Status;
            toValue.CreatedBy = fromValue.CreatedBy;
            toValue.CreatedDate = fromValue.CreatedDate;
            toValue.LastModifiedBy = fromValue.LastModifiedBy;
            toValue.LastModifiedDate = fromValue.LastModifiedDate;
            toValue.Timestamp = fromValue.Timestamp;
            
        }
        
        protected override AdapterActions BeforeAdapt(
            Benday.EasyAuthDemo.WebUi.Models.UserEditorViewModel fromValue,
            Benday.EasyAuthDemo.Api.DomainModels.User toValue)
        {
            if (fromValue == null)
            {
                return AdapterActions.Skip;
            }
            else if (fromValue.Id != ApiConstants.UnsavedId && fromValue.IsMarkedForDelete == true)
            {
                return AdapterActions.Delete;
            }
            else
            {
                return AdapterActions.Adapt;
            }
        }
        
        protected override void PerformAdapt(
            Benday.EasyAuthDemo.WebUi.Models.UserEditorViewModel fromValue,
            Benday.EasyAuthDemo.Api.DomainModels.User toValue)
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
            new UserClaimEditorViewModelAdapter().Adapt(
            fromValue.Claims,
            toValue.Claims);
            toValue.Status = fromValue.Status;
            toValue.CreatedBy = fromValue.CreatedBy;
            toValue.CreatedDate = fromValue.CreatedDate;
            toValue.LastModifiedBy = fromValue.LastModifiedBy;
            toValue.LastModifiedDate = fromValue.LastModifiedDate;
            toValue.Timestamp = fromValue.Timestamp;
            
        }
    }
}

