using Benday.EasyAuthDemo.Api.Adapters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Benday.EasyAuthDemo.UnitTests.Utilities;

namespace Benday.EasyAuthDemo.UnitTests.Adapters
{
    [TestClass]
    public class UserClaimAdapterFixture
    {
        [TestInitialize]
        public void OnTestInitialize()
        {
            _SystemUnderTest = null;
        }
        
        private UserClaimAdapter _SystemUnderTest;
        public UserClaimAdapter SystemUnderTest
        {
            get
            {
                if (_SystemUnderTest == null)
                {
                    _SystemUnderTest = new UserClaimAdapter();
                }
                
                return _SystemUnderTest;
            }
        }
        
        [TestMethod]
        public void AdaptUserClaimFromEntityToModel()
        {
            // arrange
            var fromValue = UserClaimTestUtility.CreateEntity();
            var toValue = new Benday.EasyAuthDemo.Api.DomainModels.UserClaim();
            
            // act
            SystemUnderTest.Adapt(fromValue, toValue);
            
            // assert
            UserClaimTestUtility.AssertAreEqual(fromValue, toValue);
            Assert.IsFalse(toValue.HasChanges(), "Should not have changes after adapt.");
        }
        
        [TestMethod]
        public void AdaptUserClaimFromEntitiesToModels_ToEmpty()
        {
            // arrange
            var fromValues = UserClaimTestUtility.CreateEntities();
            var toValues = new List<Benday.EasyAuthDemo.Api.DomainModels.UserClaim>();
            
            // act
            SystemUnderTest.Adapt(fromValues, toValues);
            
            // assert
            Assert.AreNotEqual<int>(0, toValues.Count, "There should be values.");
            UserClaimTestUtility.AssertAreEqual(fromValues, toValues);
        }
        
        [TestMethod]
        public void AdaptUserClaimFromEntitiesToModels_MergesByIdForExistingValues()
        {
            // arrange
            var fromValues = UserClaimTestUtility.CreateEntities(false);
            
            foreach (var fromValue in fromValues)
            {
                Assert.AreNotEqual<int>(0, fromValue.Id, "Value wasn't 'saved' before start of test.");
            }
            
            int expectedCount = fromValues.Count;
            
            var toValues = new List<Benday.EasyAuthDemo.Api.DomainModels.UserClaim>();
            
            // adapt first time
            SystemUnderTest.Adapt(fromValues, toValues);
            
            var originalValuesById = GetOriginalValuesById(toValues);
            
            // act
            // call adapt again
            SystemUnderTest.Adapt(fromValues, toValues);
            
            // assert
            Assert.AreNotEqual<int>(0, toValues.Count, "There should be values.");
            AssertValuesStillExistAndIdDidNotChange(toValues, originalValuesById);
            UserClaimTestUtility.AssertAreEqual(fromValues, toValues);
        }
        
        private void AssertValuesStillExistAndIdDidNotChange(
            List<Benday.EasyAuthDemo.Api.DomainModels.UserClaim> actualValues,
            Dictionary<int, Benday.EasyAuthDemo.Api.DomainModels.UserClaim> expectedValuesById)
        {
            Assert.AreEqual<int>(expectedValuesById.Count, actualValues.Count, "Item count changed.");
            
            Benday.EasyAuthDemo.Api.DomainModels.UserClaim expected;
            
            foreach (var expectedId in expectedValuesById.Keys)
            {
                expected = expectedValuesById.GetValueOrDefault(expectedId);
                
                Assert.IsNotNull(expected, "Expected value should not be null.");
                
                Assert.AreEqual<int>(expectedId, expected.Id, "Id value should not have changed.");
                
                Assert.IsTrue(actualValues.Contains(expected), "Value should exist in actual values.");
            }
        }
        
        private Dictionary<int, Benday.EasyAuthDemo.Api.DomainModels.UserClaim> GetOriginalValuesById(
            List<Benday.EasyAuthDemo.Api.DomainModels.UserClaim> values)
        {
            var originalValuesById =
            new Dictionary<int, Benday.EasyAuthDemo.Api.DomainModels.UserClaim>();
            
            foreach (var item in values)
            {
                originalValuesById.Add(item.Id, item);
            }
            
            return originalValuesById;
        }
        
        [TestMethod]
        public void AdaptUserClaimFromModelToEntity()
        {
            // arrange
            var fromValue = UserClaimTestUtility.CreateModel();
            var toValue = new Benday.EasyAuthDemo.Api.DataAccess.Entities.UserClaimEntity();
            
            // act
            SystemUnderTest.Adapt(fromValue, toValue);
            
            // assert
            UserClaimTestUtility.AssertAreEqual(fromValue, toValue);
        }
        
        [TestMethod]
        public void AdaptUserClaimFromModelsToEntities_ToEmpty()
        {
            // arrange
            var fromValues = UserClaimTestUtility.CreateModels();
            var toValues = new List<Benday.EasyAuthDemo.Api.DataAccess.Entities.UserClaimEntity>();
            
            // act
            SystemUnderTest.Adapt(fromValues, toValues);
            
            // assert
            Assert.AreNotEqual<int>(0, toValues.Count, "There should be values.");
            UserClaimTestUtility.AssertAreEqual(fromValues, toValues);
        }
        
        [TestMethod]
        public void AdaptUserClaimFromModelsToEntities_MergesByIdForExistingValues()
        {
            // arrange
            var fromValues = UserClaimTestUtility.CreateModels(false);
            var toValues = new List<Benday.EasyAuthDemo.Api.DataAccess.Entities.UserClaimEntity>();
            
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
            UserClaimTestUtility.AssertAreEqual(fromValues, toValues);
        }
        
        private void AssertValuesStillExistAndIdDidNotChange(
            List<Benday.EasyAuthDemo.Api.DataAccess.Entities.UserClaimEntity> actualValues,
            Dictionary<int, Benday.EasyAuthDemo.Api.DataAccess.Entities.UserClaimEntity> expectedValuesById)
        {
            Assert.AreEqual<int>(expectedValuesById.Count, actualValues.Count, "Item count changed.");
            
            Benday.EasyAuthDemo.Api.DataAccess.Entities.UserClaimEntity expected;
            
            foreach (var expectedId in expectedValuesById.Keys)
            {
                expected = expectedValuesById.GetValueOrDefault(expectedId);
                
                Assert.IsNotNull(expected, "Expected value should not be null.");
                
                Assert.AreEqual<int>(expectedId, expected.Id, "Id value should not have changed.");
                
                Assert.IsTrue(actualValues.Contains(expected), "Value should exist in actual values.");
            }
        }
        
        private Dictionary<int, Benday.EasyAuthDemo.Api.DataAccess.Entities.UserClaimEntity> GetOriginalValuesById(
            List<Benday.EasyAuthDemo.Api.DataAccess.Entities.UserClaimEntity> values)
        {
            var originalValuesById =
            new Dictionary<int, Benday.EasyAuthDemo.Api.DataAccess.Entities.UserClaimEntity>();
            
            foreach (var item in values)
            {
                originalValuesById.Add(item.Id, item);
            }
            
            return originalValuesById;
        }
    }
}
