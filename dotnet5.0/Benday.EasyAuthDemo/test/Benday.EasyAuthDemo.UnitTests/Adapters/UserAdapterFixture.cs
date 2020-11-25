using Benday.EasyAuthDemo.Api.Adapters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Benday.EasyAuthDemo.UnitTests.Utilities;

namespace Benday.EasyAuthDemo.UnitTests.Adapters
{
    [TestClass]
    public class UserAdapterFixture
    {
        [TestInitialize]
        public void OnTestInitialize()
        {
            _SystemUnderTest = null;
        }
        
        private UserAdapter _SystemUnderTest;
        public UserAdapter SystemUnderTest
        {
            get
            {
                if (_SystemUnderTest == null)
                {
                    _SystemUnderTest = new UserAdapter();
                }
                
                return _SystemUnderTest;
            }
        }
        
        [TestMethod]
        public void AdaptUserFromEntityToModel()
        {
            // arrange
            var fromValue = UserTestUtility.CreateEntity();
            var toValue = new Benday.EasyAuthDemo.Api.DomainModels.User();
            
            // act
            SystemUnderTest.Adapt(fromValue, toValue);
            
            // assert
            UserTestUtility.AssertAreEqual(fromValue, toValue);
            Assert.IsFalse(toValue.HasChanges(), "Should not have changes after adapt.");
        }
        
        [TestMethod]
        public void AdaptUserFromEntitiesToModels_ToEmpty()
        {
            // arrange
            var fromValues = UserTestUtility.CreateEntities();
            var toValues = new List<Benday.EasyAuthDemo.Api.DomainModels.User>();
            
            // act
            SystemUnderTest.Adapt(fromValues, toValues);
            
            // assert
            Assert.AreNotEqual<int>(0, toValues.Count, "There should be values.");
            UserTestUtility.AssertAreEqual(fromValues, toValues);
        }
        
        [TestMethod]
        public void AdaptUserFromEntitiesToModels_MergesByIdForExistingValues()
        {
            // arrange
            var fromValues = UserTestUtility.CreateEntities(false);
            
            foreach (var fromValue in fromValues)
            {
                Assert.AreNotEqual<int>(0, fromValue.Id, "Value wasn't 'saved' before start of test.");
            }
            
            int expectedCount = fromValues.Count;
            
            var toValues = new List<Benday.EasyAuthDemo.Api.DomainModels.User>();
            
            // adapt first time
            SystemUnderTest.Adapt(fromValues, toValues);
            
            var originalValuesById = GetOriginalValuesById(toValues);
            
            // act
            // call adapt again
            SystemUnderTest.Adapt(fromValues, toValues);
            
            // assert
            Assert.AreNotEqual<int>(0, toValues.Count, "There should be values.");
            AssertValuesStillExistAndIdDidNotChange(toValues, originalValuesById);
            UserTestUtility.AssertAreEqual(fromValues, toValues);
        }
        
        private void AssertValuesStillExistAndIdDidNotChange(
            List<Benday.EasyAuthDemo.Api.DomainModels.User> actualValues,
            Dictionary<int, Benday.EasyAuthDemo.Api.DomainModels.User> expectedValuesById)
        {
            Assert.AreEqual<int>(expectedValuesById.Count, actualValues.Count, "Item count changed.");
            
            Benday.EasyAuthDemo.Api.DomainModels.User expected;
            
            foreach (var expectedId in expectedValuesById.Keys)
            {
                expected = expectedValuesById.GetValueOrDefault(expectedId);
                
                Assert.IsNotNull(expected, "Expected value should not be null.");
                
                Assert.AreEqual<int>(expectedId, expected.Id, "Id value should not have changed.");
                
                Assert.IsTrue(actualValues.Contains(expected), "Value should exist in actual values.");
            }
        }
        
        private Dictionary<int, Benday.EasyAuthDemo.Api.DomainModels.User> GetOriginalValuesById(
            List<Benday.EasyAuthDemo.Api.DomainModels.User> values)
        {
            var originalValuesById =
            new Dictionary<int, Benday.EasyAuthDemo.Api.DomainModels.User>();
            
            foreach (var item in values)
            {
                originalValuesById.Add(item.Id, item);
            }
            
            return originalValuesById;
        }
        
        [TestMethod]
        public void AdaptUserFromModelToEntity()
        {
            // arrange
            var fromValue = UserTestUtility.CreateModel();
            var toValue = new Benday.EasyAuthDemo.Api.DataAccess.Entities.UserEntity();
            
            // act
            SystemUnderTest.Adapt(fromValue, toValue);
            
            // assert
            UserTestUtility.AssertAreEqual(fromValue, toValue);
        }
        
        [TestMethod]
        public void AdaptUserFromModelsToEntities_ToEmpty()
        {
            // arrange
            var fromValues = UserTestUtility.CreateModels();
            var toValues = new List<Benday.EasyAuthDemo.Api.DataAccess.Entities.UserEntity>();
            
            // act
            SystemUnderTest.Adapt(fromValues, toValues);
            
            // assert
            Assert.AreNotEqual<int>(0, toValues.Count, "There should be values.");
            UserTestUtility.AssertAreEqual(fromValues, toValues);
        }
        
        [TestMethod]
        public void AdaptUserFromModelsToEntities_MergesByIdForExistingValues()
        {
            // arrange
            var fromValues = UserTestUtility.CreateModels(false);
            var toValues = new List<Benday.EasyAuthDemo.Api.DataAccess.Entities.UserEntity>();
            
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
            UserTestUtility.AssertAreEqual(fromValues, toValues);
        }
        
        private void AssertValuesStillExistAndIdDidNotChange(
            List<Benday.EasyAuthDemo.Api.DataAccess.Entities.UserEntity> actualValues,
            Dictionary<int, Benday.EasyAuthDemo.Api.DataAccess.Entities.UserEntity> expectedValuesById)
        {
            Assert.AreEqual<int>(expectedValuesById.Count, actualValues.Count, "Item count changed.");
            
            Benday.EasyAuthDemo.Api.DataAccess.Entities.UserEntity expected;
            
            foreach (var expectedId in expectedValuesById.Keys)
            {
                expected = expectedValuesById.GetValueOrDefault(expectedId);
                
                Assert.IsNotNull(expected, "Expected value should not be null.");
                
                Assert.AreEqual<int>(expectedId, expected.Id, "Id value should not have changed.");
                
                Assert.IsTrue(actualValues.Contains(expected), "Value should exist in actual values.");
            }
        }
        
        private Dictionary<int, Benday.EasyAuthDemo.Api.DataAccess.Entities.UserEntity> GetOriginalValuesById(
            List<Benday.EasyAuthDemo.Api.DataAccess.Entities.UserEntity> values)
        {
            var originalValuesById =
            new Dictionary<int, Benday.EasyAuthDemo.Api.DataAccess.Entities.UserEntity>();
            
            foreach (var item in values)
            {
                originalValuesById.Add(item.Id, item);
            }
            
            return originalValuesById;
        }
    }
}
