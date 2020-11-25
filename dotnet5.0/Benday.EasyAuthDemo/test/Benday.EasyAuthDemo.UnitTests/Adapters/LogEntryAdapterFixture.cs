using Benday.EasyAuthDemo.Api.Adapters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Benday.EasyAuthDemo.UnitTests.Utilities;

namespace Benday.EasyAuthDemo.UnitTests.Adapters
{
    [TestClass]
    public class LogEntryAdapterFixture
    {
        [TestInitialize]
        public void OnTestInitialize()
        {
            _SystemUnderTest = null;
        }
        
        private LogEntryAdapter _SystemUnderTest;
        public LogEntryAdapter SystemUnderTest
        {
            get
            {
                if (_SystemUnderTest == null)
                {
                    _SystemUnderTest = new LogEntryAdapter();
                }
                
                return _SystemUnderTest;
            }
        }
        
        [TestMethod]
        public void AdaptLogEntryFromEntityToModel()
        {
            // arrange
            var fromValue = LogEntryTestUtility.CreateEntity();
            var toValue = new Benday.EasyAuthDemo.Api.DomainModels.LogEntry();
            
            // act
            SystemUnderTest.Adapt(fromValue, toValue);
            
            // assert
            LogEntryTestUtility.AssertAreEqual(fromValue, toValue);
            Assert.IsFalse(toValue.HasChanges(), "Should not have changes after adapt.");
        }
        
        [TestMethod]
        public void AdaptLogEntryFromEntitiesToModels_ToEmpty()
        {
            // arrange
            var fromValues = LogEntryTestUtility.CreateEntities();
            var toValues = new List<Benday.EasyAuthDemo.Api.DomainModels.LogEntry>();
            
            // act
            SystemUnderTest.Adapt(fromValues, toValues);
            
            // assert
            Assert.AreNotEqual<int>(0, toValues.Count, "There should be values.");
            LogEntryTestUtility.AssertAreEqual(fromValues, toValues);
        }
        
        [TestMethod]
        public void AdaptLogEntryFromEntitiesToModels_MergesByIdForExistingValues()
        {
            // arrange
            var fromValues = LogEntryTestUtility.CreateEntities(false);
            
            foreach (var fromValue in fromValues)
            {
                Assert.AreNotEqual<int>(0, fromValue.Id, "Value wasn't 'saved' before start of test.");
            }
            
            int expectedCount = fromValues.Count;
            
            var toValues = new List<Benday.EasyAuthDemo.Api.DomainModels.LogEntry>();
            
            // adapt first time
            SystemUnderTest.Adapt(fromValues, toValues);
            
            var originalValuesById = GetOriginalValuesById(toValues);
            
            // act
            // call adapt again
            SystemUnderTest.Adapt(fromValues, toValues);
            
            // assert
            Assert.AreNotEqual<int>(0, toValues.Count, "There should be values.");
            AssertValuesStillExistAndIdDidNotChange(toValues, originalValuesById);
            LogEntryTestUtility.AssertAreEqual(fromValues, toValues);
        }
        
        private void AssertValuesStillExistAndIdDidNotChange(
            List<Benday.EasyAuthDemo.Api.DomainModels.LogEntry> actualValues,
            Dictionary<int, Benday.EasyAuthDemo.Api.DomainModels.LogEntry> expectedValuesById)
        {
            Assert.AreEqual<int>(expectedValuesById.Count, actualValues.Count, "Item count changed.");
            
            Benday.EasyAuthDemo.Api.DomainModels.LogEntry expected;
            
            foreach (var expectedId in expectedValuesById.Keys)
            {
                expected = expectedValuesById.GetValueOrDefault(expectedId);
                
                Assert.IsNotNull(expected, "Expected value should not be null.");
                
                Assert.AreEqual<int>(expectedId, expected.Id, "Id value should not have changed.");
                
                Assert.IsTrue(actualValues.Contains(expected), "Value should exist in actual values.");
            }
        }
        
        private Dictionary<int, Benday.EasyAuthDemo.Api.DomainModels.LogEntry> GetOriginalValuesById(
            List<Benday.EasyAuthDemo.Api.DomainModels.LogEntry> values)
        {
            var originalValuesById =
            new Dictionary<int, Benday.EasyAuthDemo.Api.DomainModels.LogEntry>();
            
            foreach (var item in values)
            {
                originalValuesById.Add(item.Id, item);
            }
            
            return originalValuesById;
        }
        
        [TestMethod]
        public void AdaptLogEntryFromModelToEntity()
        {
            // arrange
            var fromValue = LogEntryTestUtility.CreateModel();
            var toValue = new Benday.EasyAuthDemo.Api.DataAccess.Entities.LogEntryEntity();
            
            // act
            SystemUnderTest.Adapt(fromValue, toValue);
            
            // assert
            LogEntryTestUtility.AssertAreEqual(fromValue, toValue);
        }
        
        [TestMethod]
        public void AdaptLogEntryFromModelsToEntities_ToEmpty()
        {
            // arrange
            var fromValues = LogEntryTestUtility.CreateModels();
            var toValues = new List<Benday.EasyAuthDemo.Api.DataAccess.Entities.LogEntryEntity>();
            
            // act
            SystemUnderTest.Adapt(fromValues, toValues);
            
            // assert
            Assert.AreNotEqual<int>(0, toValues.Count, "There should be values.");
            LogEntryTestUtility.AssertAreEqual(fromValues, toValues);
        }
        
        [TestMethod]
        public void AdaptLogEntryFromModelsToEntities_MergesByIdForExistingValues()
        {
            // arrange
            var fromValues = LogEntryTestUtility.CreateModels(false);
            var toValues = new List<Benday.EasyAuthDemo.Api.DataAccess.Entities.LogEntryEntity>();
            
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
            LogEntryTestUtility.AssertAreEqual(fromValues, toValues);
        }
        
        private void AssertValuesStillExistAndIdDidNotChange(
            List<Benday.EasyAuthDemo.Api.DataAccess.Entities.LogEntryEntity> actualValues,
            Dictionary<int, Benday.EasyAuthDemo.Api.DataAccess.Entities.LogEntryEntity> expectedValuesById)
        {
            Assert.AreEqual<int>(expectedValuesById.Count, actualValues.Count, "Item count changed.");
            
            Benday.EasyAuthDemo.Api.DataAccess.Entities.LogEntryEntity expected;
            
            foreach (var expectedId in expectedValuesById.Keys)
            {
                expected = expectedValuesById.GetValueOrDefault(expectedId);
                
                Assert.IsNotNull(expected, "Expected value should not be null.");
                
                Assert.AreEqual<int>(expectedId, expected.Id, "Id value should not have changed.");
                
                Assert.IsTrue(actualValues.Contains(expected), "Value should exist in actual values.");
            }
        }
        
        private Dictionary<int, Benday.EasyAuthDemo.Api.DataAccess.Entities.LogEntryEntity> GetOriginalValuesById(
            List<Benday.EasyAuthDemo.Api.DataAccess.Entities.LogEntryEntity> values)
        {
            var originalValuesById =
            new Dictionary<int, Benday.EasyAuthDemo.Api.DataAccess.Entities.LogEntryEntity>();
            
            foreach (var item in values)
            {
                originalValuesById.Add(item.Id, item);
            }
            
            return originalValuesById;
        }
    }
}
