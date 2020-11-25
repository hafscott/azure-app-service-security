using Benday.EasyAuthDemo.Api.DomainModels;
using Benday.EasyAuthDemo.Api.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Benday.EasyAuthDemo.Api.Adapters
{
    public partial class LogEntryAdapter :
        AdapterBase<
        Benday.EasyAuthDemo.Api.DomainModels.LogEntry,
        Benday.EasyAuthDemo.Api.DataAccess.Entities.LogEntryEntity>
    {
    
    
        protected override void PerformAdapt(
            Benday.EasyAuthDemo.Api.DomainModels.LogEntry fromValue,
            Benday.EasyAuthDemo.Api.DataAccess.Entities.LogEntryEntity toValue)
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
            toValue.LogLevel = fromValue.LogLevel;
            toValue.LogText = fromValue.LogText;
            toValue.ExceptionText = fromValue.ExceptionText;
            toValue.EventId = fromValue.EventId;
            toValue.State = fromValue.State;
            toValue.LogDate = fromValue.LogDate;
            
            
        }
        
        protected override void PerformAdapt(
            Benday.EasyAuthDemo.Api.DataAccess.Entities.LogEntryEntity fromValue,
            Benday.EasyAuthDemo.Api.DomainModels.LogEntry toValue
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
            toValue.LogLevel = fromValue.LogLevel;
            toValue.LogText = fromValue.LogText;
            toValue.ExceptionText = fromValue.ExceptionText;
            toValue.EventId = fromValue.EventId;
            toValue.State = fromValue.State;
            toValue.LogDate = fromValue.LogDate;
            
            toValue.AcceptChanges();
            
        }
    }
}
