using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Benday.EasyAuthDemo.Api;
using Benday.EasyAuthDemo.UnitTests.Utilities;

namespace Benday.EasyAuthDemo.UnitTests.ViewModels
{
    public static class ConfigurationItemViewModelTestUtility
    {
        public static List<Benday.EasyAuthDemo.WebUi.Models.ConfigurationItemEditorViewModel> CreateEditorViewModels(
            bool createAsUnsaved = true)
        {
            var returnValues = new List<Benday.EasyAuthDemo.WebUi.Models.ConfigurationItemEditorViewModel>();
            
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
        
        public static Benday.EasyAuthDemo.WebUi.Models.ConfigurationItemEditorViewModel CreateEditorViewModel(
            bool createAsUnsaved = true)
        {
            var fromValue = new Benday.EasyAuthDemo.WebUi.Models.ConfigurationItemEditorViewModel();
            
            fromValue.Id = UnitTestUtility.GetFakeValueForInt("Id");
            fromValue.Category = UnitTestUtility.GetFakeValueForString("Category");
            fromValue.ConfigurationKey = UnitTestUtility.GetFakeValueForString("ConfigurationKey");
            fromValue.Description = UnitTestUtility.GetFakeValueForString("Description");
            fromValue.ConfigurationValue = UnitTestUtility.GetFakeValueForString("ConfigurationValue");
            fromValue.Status = UnitTestUtility.GetFakeValueForString("Status");
            fromValue.CreatedBy = UnitTestUtility.GetFakeValueForString("CreatedBy");
            fromValue.CreatedDate = UnitTestUtility.GetFakeValueForDateTime("CreatedDate");
            fromValue.LastModifiedBy = UnitTestUtility.GetFakeValueForString("LastModifiedBy");
            fromValue.LastModifiedDate = UnitTestUtility.GetFakeValueForDateTime("LastModifiedDate");
            fromValue.Timestamp = UnitTestUtility.GetFakeValueForByteArray("Timestamp");
            
            
            
            if (createAsUnsaved == true)
            {
                fromValue.Id = 0;
                fromValue.CreatedDate = default(DateTime);
                fromValue.LastModifiedDate = default(DateTime);
                fromValue.CreatedBy = null;
                fromValue.LastModifiedBy = null;
            }
            
            return fromValue;
        }
        
        public static void AssertAreEqual(
            IList<Benday.EasyAuthDemo.Api.DomainModels.ConfigurationItem> expected,
            IList<Benday.EasyAuthDemo.WebUi.Models.ConfigurationItemEditorViewModel> actual)
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
            Benday.EasyAuthDemo.Api.DomainModels.ConfigurationItem expected,
            Benday.EasyAuthDemo.WebUi.Models.ConfigurationItemEditorViewModel actual)
        {
            Assert.AreEqual<int>(expected.Id, actual.Id, "Id");
            Assert.AreEqual<string>(expected.Category, actual.Category, "Category");
            Assert.AreEqual<string>(expected.ConfigurationKey, actual.ConfigurationKey, "ConfigurationKey");
            Assert.AreEqual<string>(expected.Description, actual.Description, "Description");
            Assert.AreEqual<string>(expected.ConfigurationValue, actual.ConfigurationValue, "ConfigurationValue");
            Assert.AreEqual<string>(expected.Status, actual.Status, "Status");
            Assert.AreEqual<string>(expected.CreatedBy, actual.CreatedBy, "CreatedBy");
            Assert.AreEqual<DateTime>(expected.CreatedDate, actual.CreatedDate, "CreatedDate");
            Assert.AreEqual<string>(expected.LastModifiedBy, actual.LastModifiedBy, "LastModifiedBy");
            Assert.AreEqual<DateTime>(expected.LastModifiedDate, actual.LastModifiedDate, "LastModifiedDate");
            Assert.AreEqual<byte[]>(expected.Timestamp, actual.Timestamp, "Timestamp");
            
        }
        
        public static void AssertAreEqual(
            IList<Benday.EasyAuthDemo.WebUi.Models.ConfigurationItemEditorViewModel> expected,
            IList<Benday.EasyAuthDemo.Api.DomainModels.ConfigurationItem> actual)
        {
            Assert.IsNotNull(expected, "Expected was null.");
            Assert.IsNotNull(actual, "Actual was null.");
            Assert.AreEqual<int>(expected.Count, actual.Count,
            "{0}.AssertAreEqual(): Item count should match.",
            nameof(ConfigurationItemViewModelTestUtility));
            
            for (int i = 0; i < expected.Count; i++)
            {
                AssertAreEqual(expected[i], actual[i]);
            }
        }
        
        public static void AssertAreNotEqual(
            Benday.EasyAuthDemo.WebUi.Models.ConfigurationItemEditorViewModel expected,
            Benday.EasyAuthDemo.Api.DomainModels.ConfigurationItem actual)
        {
            Assert.AreNotEqual<int>(expected.Id, actual.Id,
            "{0}.AssertAreNotEqual(): Id should not match.",
            nameof(ConfigurationItemViewModelTestUtility));
        }
        
        public static void AssertAreEqual(
            Benday.EasyAuthDemo.WebUi.Models.ConfigurationItemEditorViewModel expected,
            Benday.EasyAuthDemo.Api.DomainModels.ConfigurationItem actual)
        {
            Assert.AreEqual<int>(expected.Id, actual.Id, "Id");
            Assert.AreEqual<string>(expected.Category, actual.Category, "Category");
            Assert.AreEqual<string>(expected.ConfigurationKey, actual.ConfigurationKey, "ConfigurationKey");
            Assert.AreEqual<string>(expected.Description, actual.Description, "Description");
            Assert.AreEqual<string>(expected.ConfigurationValue, actual.ConfigurationValue, "ConfigurationValue");
            Assert.AreEqual<string>(expected.Status, actual.Status, "Status");
            Assert.AreEqual<string>(expected.CreatedBy, actual.CreatedBy, "CreatedBy");
            Assert.AreEqual<DateTime>(expected.CreatedDate, actual.CreatedDate, "CreatedDate");
            Assert.AreEqual<string>(expected.LastModifiedBy, actual.LastModifiedBy, "LastModifiedBy");
            Assert.AreEqual<DateTime>(expected.LastModifiedDate, actual.LastModifiedDate, "LastModifiedDate");
            Assert.AreEqual<byte[]>(expected.Timestamp, actual.Timestamp, "Timestamp");
            
        }
    }
}

