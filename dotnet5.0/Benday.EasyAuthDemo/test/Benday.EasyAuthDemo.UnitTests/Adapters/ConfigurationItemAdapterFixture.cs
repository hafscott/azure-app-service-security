using Benday.EasyAuthDemo.Api.Adapters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Benday.EasyAuthDemo.UnitTests.Utilities;

namespace Benday.EasyAuthDemo.UnitTests.Adapters
{
    [TestClass]
    public class ConfigurationItemAdapterFixture
    {
        [TestInitialize]
        public void OnTestInitialize()
        {
            _SystemUnderTest = null;
        }
        
        private ConfigurationItemAdapter _SystemUnderTest;
        public ConfigurationItemAdapter SystemUnderTest
        {
            get
            {
                if (_SystemUnderTest == null)
                {
                    _SystemUnderTest = new ConfigurationItemAdapter();
                }
                
                return _SystemUnderTest;
            }
        }
        
        [TestMethod]
        public void AdaptConfigurationItemFromEntityToModel()
        {
            // arrange
            var fromValue = ConfigurationItemTestUtility.CreateEntity();
            var toValue = new Benday.EasyAuthDemo.Api.DomainModels.ConfigurationItem();
            
            // act
            SystemUnderTest.Adapt(fromValue, toValue);
            
            // assert
            ConfigurationItemTestUtility.AssertAreEqual(fromValue, toValue);
            Assert.IsFalse(toValue.HasChanges(), "Should not have changes after adapt.");
        }
        
        [TestMethod]
        public void AdaptConfigurationItemFromEntitiesToModels_ToEmpty()
        {
            // arrange
            var fromValues = ConfigurationItemTestUtility.CreateEntities();
            var toValues = new List<Benday.EasyAuthDemo.Api.DomainModels.ConfigurationItem>();
            
            // act
            SystemUnderTest.Adapt(fromValues, toValues);
            
            // assert
            Assert.AreNotEqual<int>(0, toValues.Count, "There should be values.");
            ConfigurationItemTestUtility.AssertAreEqual(fromValues, toValues);
        }
        
        [TestMethod]
        public void AdaptConfigurationItemFromEntitiesToModels_MergesByIdForExistingValues()
        {
            // arrange
            var fromValues = ConfigurationItemTestUtility.CreateEntities(false);
            
            foreach (var fromValue in fromValues)
            {
                Assert.AreNotEqual<int>(0, fromValue.Id, "Value wasn't 'saved' before start of test.");
            }
            
            int expectedCount = fromValues.Count;
            
            var toValues = new List<Benday.EasyAuthDemo.Api.DomainModels.ConfigurationItem>();
            
            // adapt first time
            SystemUnderTest.Adapt(fromValues, toValues);
            
            var originalValuesById = GetOriginalValuesById(toValues);
            
            // act
            // call adapt again
            SystemUnderTest.Adapt(fromValues, toValues);
            
            // assert
            Assert.AreNotEqual<int>(0, toValues.Count, "There should be values.");
            AssertValuesStillExistAndIdDidNotChange(toValues, originalValuesById);
            ConfigurationItemTestUtility.AssertAreEqual(fromValues, toValues);
        }
        
        private void AssertValuesStillExistAndIdDidNotChange(
            List<Benday.EasyAuthDemo.Api.DomainModels.ConfigurationItem> actualValues,
            Dictionary<int, Benday.EasyAuthDemo.Api.DomainModels.ConfigurationItem> expectedValuesById)
        {
            Assert.AreEqual<int>(expectedValuesById.Count, actualValues.Count, "Item count changed.");
            
            Benday.EasyAuthDemo.Api.DomainModels.ConfigurationItem expected;
            
            foreach (var expectedId in expectedValuesById.Keys)
            {
                expected = expectedValuesById.GetValueOrDefault(expectedId);
                
                Assert.IsNotNull(expected, "Expected value should not be null.");
                
                Assert.AreEqual<int>(expectedId, expected.Id, "Id value should not have changed.");
                
                Assert.IsTrue(actualValues.Contains(expected), "Value should exist in actual values.");
            }
        }
        
        private Dictionary<int, Benday.EasyAuthDemo.Api.DomainModels.ConfigurationItem> GetOriginalValuesById(
            List<Benday.EasyAuthDemo.Api.DomainModels.ConfigurationItem> values)
        {
            var originalValuesById =
            new Dictionary<int, Benday.EasyAuthDemo.Api.DomainModels.ConfigurationItem>();
            
            foreach (var item in values)
            {
                originalValuesById.Add(item.Id, item);
            }
            
            return originalValuesById;
        }
        
        [TestMethod]
        public void AdaptConfigurationItemFromModelToEntity()
        {
            // arrange
            var fromValue = ConfigurationItemTestUtility.CreateModel();
            var toValue = new Benday.EasyAuthDemo.Api.DataAccess.Entities.ConfigurationItemEntity();
            
            // act
            SystemUnderTest.Adapt(fromValue, toValue);
            
            // assert
            ConfigurationItemTestUtility.AssertAreEqual(fromValue, toValue);
        }
        
        [TestMethod]
        public void AdaptConfigurationItemFromModelsToEntities_ToEmpty()
        {
            // arrange
            var fromValues = ConfigurationItemTestUtility.CreateModels();
            var toValues = new List<Benday.EasyAuthDemo.Api.DataAccess.Entities.ConfigurationItemEntity>();
            
            // act
            SystemUnderTest.Adapt(fromValues, toValues);
            
            // assert
            Assert.AreNotEqual<int>(0, toValues.Count, "There should be values.");
            ConfigurationItemTestUtility.AssertAreEqual(fromValues, toValues);
        }
        
        [TestMethod]
        public void AdaptConfigurationItemFromModelsToEntities_MergesByIdForExistingValues()
        {
            // arrange
            var fromValues = ConfigurationItemTestUtility.CreateModels(false);
            var toValues = new List<Benday.EasyAuthDemo.Api.DataAccess.Entities.ConfigurationItemEntity>();
            
            foreach (var fromValue in fromValues)
            {
                Assert.AreNotEqual<int>(0, fromValue.Id, "Value wasn't 'saved' before start of test.");
            }
            
            int expectedCount = fromValues.Count;
            
            // adapt first time
            SystemUnderTest.Adapt(fromValues, toValues);
            
            var originalValuesById = GetOriginalValuesById(toValues);
            
            // act
            // call adapt again
            SystemUnderTest.Adapt(fromValues, toValues);
            
            // assert
            Assert.AreNotEqual<int>(0, toValues.Count, "There should be values.");
            AssertValuesStillExistAndIdDidNotChange(toValues, originalValuesById);
            ConfigurationItemTestUtility.AssertAreEqual(fromValues, toValues);
        }
        
        private void AssertValuesStillExistAndIdDidNotChange(
            List<Benday.EasyAuthDemo.Api.DataAccess.Entities.ConfigurationItemEntity> actualValues,
            Dictionary<int, Benday.EasyAuthDemo.Api.DataAccess.Entities.ConfigurationItemEntity> expectedValuesById)
        {
            Assert.AreEqual<int>(expectedValuesById.Count, actualValues.Count, "Item count changed.");
            
            Benday.EasyAuthDemo.Api.DataAccess.Entities.ConfigurationItemEntity expected;
            
            foreach (var expectedId in expectedValuesById.Keys)
            {
                expected = expectedValuesById.GetValueOrDefault(expectedId);
                
                Assert.IsNotNull(expected, "Expected value should not be null.");
                
                Assert.AreEqual<int>(expectedId, expected.Id, "Id value should not have changed.");
                
                Assert.IsTrue(actualValues.Contains(expected), "Value should exist in actual values.");
            }
        }
        
        private Dictionary<int, Benday.EasyAuthDemo.Api.DataAccess.Entities.ConfigurationItemEntity> GetOriginalValuesById(
            List<Benday.EasyAuthDemo.Api.DataAccess.Entities.ConfigurationItemEntity> values)
        {
            var originalValuesById =
            new Dictionary<int, Benday.EasyAuthDemo.Api.DataAccess.Entities.ConfigurationItemEntity>();
            
            foreach (var item in values)
            {
                originalValuesById.Add(item.Id, item);
            }
            
            return originalValuesById;
        }
    }
}
