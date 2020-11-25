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
    public partial class LogEntryEditorViewModelAdapter :
        AdapterBase<
        Benday.EasyAuthDemo.Api.DomainModels.LogEntry,
        Benday.EasyAuthDemo.WebUi.Models.LogEntryEditorViewModel>
    {
        protected override void PerformAdapt(
            Benday.EasyAuthDemo.Api.DomainModels.LogEntry fromValue,
            Benday.EasyAuthDemo.WebUi.Models.LogEntryEditorViewModel toValue)
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
        
        protected override AdapterActions BeforeAdapt(
            Benday.EasyAuthDemo.WebUi.Models.LogEntryEditorViewModel fromValue,
            Benday.EasyAuthDemo.Api.DomainModels.LogEntry toValue)
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
            Benday.EasyAuthDemo.WebUi.Models.LogEntryEditorViewModel fromValue,
            Benday.EasyAuthDemo.Api.DomainModels.LogEntry toValue)
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
    }
}

