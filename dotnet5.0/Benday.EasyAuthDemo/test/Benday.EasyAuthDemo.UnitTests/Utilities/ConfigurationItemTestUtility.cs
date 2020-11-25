using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Benday.EasyAuthDemo.Api;

namespace Benday.EasyAuthDemo.UnitTests.Utilities
{
    public static class ConfigurationItemTestUtility
    {
        public static List<Benday.EasyAuthDemo.Api.DataAccess.Entities.ConfigurationItemEntity> CreateEntities(
            bool createAsUnsaved = true)
        {
            var returnValues = new List<Benday.EasyAuthDemo.Api.DataAccess.Entities.ConfigurationItemEntity>();
            
            for (int i = 0; i < 10; i++)
            {
                var temp = CreateEntity();
                
                returnValues.Add(temp);
                
                if (createAsUnsaved == false)
                {
                    temp.Id = i + 1;
                }
            }
            
            return returnValues;
        }
        
        public static Benday.EasyAuthDemo.Api.DataAccess.Entities.ConfigurationItemEntity CreateEntity()
        {
            var fromValue = new Benday.EasyAuthDemo.Api.DataAccess.Entities.ConfigurationItemEntity();
            
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
            
            
            
            return fromValue;
        }
        
        public static Benday.EasyAuthDemo.Api.DomainModels.ConfigurationItem CreateModel(
            bool createAsUnsaved = true)
        {
            var fromValue = new Benday.EasyAuthDemo.Api.DomainModels.ConfigurationItem();
            
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
        
        public static List<Benday.EasyAuthDemo.Api.DomainModels.ConfigurationItem> CreateModels(
            bool createAsUnsaved = true, int numberOfRecords = 10)
        {
            var returnValues = new List<Benday.EasyAuthDemo.Api.DomainModels.ConfigurationItem>();
            
            for (int i = 0; i < numberOfRecords; i++)
            {
                var temp = CreateModel(createAsUnsaved);
                
                returnValues.Add(temp);
                
                if (createAsUnsaved == false)
                {
                    temp.Id = i + 1;
                }
                else
                {
                    temp.Id = ApiConstants.UnsavedId;
                    temp.CreatedDate = default(DateTime);
                    temp.LastModifiedDate = default(DateTime);
                    temp.CreatedBy = null;
                    temp.LastModifiedBy = null;
                }
            }
            
            return returnValues;
        }
        
        public static void ModifyModel(
            Benday.EasyAuthDemo.Api.DomainModels.ConfigurationItem fromValue)
        {
            if (fromValue == null)
            {
                throw new ArgumentNullException(nameof(fromValue), $"{nameof(fromValue)} is null.");
            }
            
            fromValue.Category = UnitTestUtility.GetFakeValueForString("Modified Category");
            fromValue.ConfigurationKey = UnitTestUtility.GetFakeValueForString("Modified ConfigurationKey");
            fromValue.Description = UnitTestUtility.GetFakeValueForString("Modified Description");
            fromValue.ConfigurationValue = UnitTestUtility.GetFakeValueForString("Modified ConfigurationValue");
            fromValue.Status = UnitTestUtility.GetFakeValueForString("Modified Status");
            fromValue.CreatedBy = UnitTestUtility.GetFakeValueForString("Modified CreatedBy");
            fromValue.CreatedDate = UnitTestUtility.GetFakeValueForDateTime("Modified CreatedDate");
            fromValue.LastModifiedBy = UnitTestUtility.GetFakeValueForString("Modified LastModifiedBy");
            fromValue.LastModifiedDate = UnitTestUtility.GetFakeValueForDateTime("Modified LastModifiedDate");
            fromValue.Timestamp = UnitTestUtility.GetFakeValueForByteArray("Modified Timestamp");
            
        }
        
        public static void AssertAreEqual(
            IList<Benday.EasyAuthDemo.Api.DomainModels.ConfigurationItem> expected,
            IList<Benday.EasyAuthDemo.Api.DataAccess.Entities.ConfigurationItemEntity> actual)
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
            Benday.EasyAuthDemo.Api.DataAccess.Entities.ConfigurationItemEntity actual)
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
            IList<Benday.EasyAuthDemo.Api.DataAccess.Entities.ConfigurationItemEntity> expected,
            IList<Benday.EasyAuthDemo.Api.DomainModels.ConfigurationItem> actual)
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
            Benday.EasyAuthDemo.Api.DataAccess.Entities.ConfigurationItemEntity expected,
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

