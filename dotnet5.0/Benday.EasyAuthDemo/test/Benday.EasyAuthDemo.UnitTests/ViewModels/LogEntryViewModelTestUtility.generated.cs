using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Benday.EasyAuthDemo.Api;
using Benday.EasyAuthDemo.UnitTests.Utilities;

namespace Benday.EasyAuthDemo.UnitTests.ViewModels
{
    public static class LogEntryViewModelTestUtility
    {
        public static List<Benday.EasyAuthDemo.WebUi.Models.LogEntryEditorViewModel> CreateEditorViewModels(
            bool createAsUnsaved = true)
        {
            var returnValues = new List<Benday.EasyAuthDemo.WebUi.Models.LogEntryEditorViewModel>();
            
            for (int i = 0; i < 10; i++)
            {
                var temp = CreateEditorViewModel();
                
                returnValues.Add(temp);
                
                if (createAsUnsaved == false)
                {
                    temp.Id = i + 1;
                }
            }
            
            return returnValues;
        }
        
        public static Benday.EasyAuthDemo.WebUi.Models.LogEntryEditorViewModel CreateEditorViewModel(
            bool createAsUnsaved = true)
        {
            var fromValue = new Benday.EasyAuthDemo.WebUi.Models.LogEntryEditorViewModel();
            
            fromValue.Id = UnitTestUtility.GetFakeValueForInt("Id");
            fromValue.Category = UnitTestUtility.GetFakeValueForString("Category");
            fromValue.LogLevel = UnitTestUtility.GetFakeValueForString("LogLevel");
            fromValue.LogText = UnitTestUtility.GetFakeValueForString("LogText");
            fromValue.ExceptionText = UnitTestUtility.GetFakeValueForString("ExceptionText");
            fromValue.EventId = UnitTestUtility.GetFakeValueForString("EventId");
            fromValue.State = UnitTestUtility.GetFakeValueForString("State");
            fromValue.LogDate = UnitTestUtility.GetFakeValueForDateTime("LogDate");
            
            
            
            if (createAsUnsaved == true)
            {
                fromValue.Id = 0;
            }
            
            return fromValue;
        }
        
        public static void AssertAreEqual(
            IList<Benday.EasyAuthDemo.Api.DomainModels.LogEntry> expected,
            IList<Benday.EasyAuthDemo.WebUi.Models.LogEntryEditorViewModel> actual)
        {
            Assert.IsNotNull(expected, "Expected was null.");
            Assert.IsNotNull(actual, "Actual was null.");
            Assert.AreEqual<int>(expected.Count, actual.Count, "Item count should match.");
            
            for (int i = 0; i < expected.Count; i++)
            {
                AssertAreEqual(expected[i], actual[i]);
            }
        }
        
        public static void AssertAreEqual(
            Benday.EasyAuthDemo.Api.DomainModels.LogEntry expected,
            Benday.EasyAuthDemo.WebUi.Models.LogEntryEditorViewModel actual)
        {
            Assert.AreEqual<int>(expected.Id, actual.Id, "Id");
            Assert.AreEqual<string>(expected.Category, actual.Category, "Category");
            Assert.AreEqual<string>(expected.LogLevel, actual.LogLevel, "LogLevel");
            Assert.AreEqual<string>(expected.LogText, actual.LogText, "LogText");
            Assert.AreEqual<string>(expected.ExceptionText, actual.ExceptionText, "ExceptionText");
            Assert.AreEqual<string>(expected.EventId, actual.EventId, "EventId");
            Assert.AreEqual<string>(expected.State, actual.State, "State");
            Assert.AreEqual<DateTime>(expected.LogDate, actual.LogDate, "LogDate");
            
        }
        
        public static void AssertAreEqual(
            IList<Benday.EasyAuthDemo.WebUi.Models.LogEntryEditorViewModel> expected,
            IList<Benday.EasyAuthDemo.Api.DomainModels.LogEntry> actual)
        {
            Assert.IsNotNull(expected, "Expected was null.");
            Assert.IsNotNull(actual, "Actual was null.");
            Assert.AreEqual<int>(expected.Count, actual.Count,
            "{0}.AssertAreEqual(): Item count should match.",
            nameof(LogEntryViewModelTestUtility));
            
            for (int i = 0; i < expected.Count; i++)
            {
                AssertAreEqual(expected[i], actual[i]);
            }
        }
        
        public static void AssertAreNotEqual(
            Benday.EasyAuthDemo.WebUi.Models.LogEntryEditorViewModel expected,
            Benday.EasyAuthDemo.Api.DomainModels.LogEntry actual)
        {
            Assert.AreNotEqual<int>(expected.Id, actual.Id,
            "{0}.AssertAreNotEqual(): Id should not match.",
            nameof(LogEntryViewModelTestUtility));
        }
        
        public static void AssertAreEqual(
            Benday.EasyAuthDemo.WebUi.Models.LogEntryEditorViewModel expected,
            Benday.EasyAuthDemo.Api.DomainModels.LogEntry actual)
        {
            Assert.AreEqual<int>(expected.Id, actual.Id, "Id");
            Assert.AreEqual<string>(expected.Category, actual.Category, "Category");
            Assert.AreEqual<string>(expected.LogLevel, actual.LogLevel, "LogLevel");
            Assert.AreEqual<string>(expected.LogText, actual.LogText, "LogText");
            Assert.AreEqual<string>(expected.ExceptionText, actual.ExceptionText, "ExceptionText");
            Assert.AreEqual<string>(expected.EventId, actual.EventId, "EventId");
            Assert.AreEqual<string>(expected.State, actual.State, "State");
            Assert.AreEqual<DateTime>(expected.LogDate, actual.LogDate, "LogDate");
            
        }
    }
}

