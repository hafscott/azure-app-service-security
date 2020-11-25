using Benday.EasyAuthDemo.Api.DomainModels;
using Benday.EasyAuthDemo.Api.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Benday.EasyAuthDemo.Api.Adapters
{
    public partial class ConfigurationItemAdapter :
        AdapterBase<
        Benday.EasyAuthDemo.Api.DomainModels.ConfigurationItem,
        Benday.EasyAuthDemo.Api.DataAccess.Entities.ConfigurationItemEntity>
    {
    
    
        protected override void PerformAdapt(
            Benday.EasyAuthDemo.Api.DomainModels.ConfigurationItem fromValue,
            Benday.EasyAuthDemo.Api.DataAccess.Entities.ConfigurationItemEntity toValue)
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
            toValue.Category = fromValue.Category;
            toValue.ConfigurationKey = fromValue.ConfigurationKey;
            toValue.Description = fromValue.Description;
            toValue.ConfigurationValue = fromValue.ConfigurationValue;
            toValue.Status = fromValue.Status;
            toValue.CreatedBy = fromValue.CreatedBy;
            toValue.CreatedDate = fromValue.CreatedDate;
            toValue.LastModifiedBy = fromValue.LastModifiedBy;
            toValue.LastModifiedDate = fromValue.LastModifiedDate;
            toValue.Timestamp = fromValue.Timestamp;
            
            
        }
        
        protected override void PerformAdapt(
            Benday.EasyAuthDemo.Api.DataAccess.Entities.ConfigurationItemEntity fromValue,
            Benday.EasyAuthDemo.Api.DomainModels.ConfigurationItem toValue
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
            toValue.Category = fromValue.Category;
            toValue.ConfigurationKey = fromValue.ConfigurationKey;
            toValue.Description = fromValue.Description;
            toValue.ConfigurationValue = fromValue.ConfigurationValue;
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
