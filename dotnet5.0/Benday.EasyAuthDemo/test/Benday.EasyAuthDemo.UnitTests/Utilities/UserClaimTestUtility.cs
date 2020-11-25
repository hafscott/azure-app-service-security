using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Benday.EasyAuthDemo.Api;

namespace Benday.EasyAuthDemo.UnitTests.Utilities
{
    public static class UserClaimTestUtility
    {
        public static List<Benday.EasyAuthDemo.Api.DataAccess.Entities.UserClaimEntity> CreateEntities(
            bool createAsUnsaved = true)
        {
            var returnValues = new List<Benday.EasyAuthDemo.Api.DataAccess.Entities.UserClaimEntity>();
            
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
        
        public static Benday.EasyAuthDemo.Api.DataAccess.Entities.UserClaimEntity CreateEntity()
        {
            var fromValue = new Benday.EasyAuthDemo.Api.DataAccess.Entities.UserClaimEntity();
            
            fromValue.Id = UnitTestUtility.GetFakeValueForInt("Id");
            fromValue.Username = UnitTestUtility.GetFakeValueForString("Username");
            fromValue.ClaimName = UnitTestUtility.GetFakeValueForString("ClaimName");
            fromValue.ClaimValue = UnitTestUtility.GetFakeValueForString("ClaimValue");
            fromValue.UserId = UnitTestUtility.GetFakeValueForInt("UserId");
            fromValue.ClaimLogicType = UnitTestUtility.GetFakeValueForString("ClaimLogicType");
            fromValue.StartDate = UnitTestUtility.GetFakeValueForDateTime("StartDate");
            fromValue.EndDate = UnitTestUtility.GetFakeValueForDateTime("EndDate");
            fromValue.Status = UnitTestUtility.GetFakeValueForString("Status");
            fromValue.CreatedBy = UnitTestUtility.GetFakeValueForString("CreatedBy");
            fromValue.CreatedDate = UnitTestUtility.GetFakeValueForDateTime("CreatedDate");
            fromValue.LastModifiedBy = UnitTestUtility.GetFakeValueForString("LastModifiedBy");
            fromValue.LastModifiedDate = UnitTestUtility.GetFakeValueForDateTime("LastModifiedDate");
            fromValue.Timestamp = UnitTestUtility.GetFakeValueForByteArray("Timestamp");
            
            
            
            return fromValue;
        }
        
        public static Benday.EasyAuthDemo.Api.DomainModels.UserClaim CreateModel(
            bool createAsUnsaved = true)
        {
            var fromValue = new Benday.EasyAuthDemo.Api.DomainModels.UserClaim();
            
            fromValue.Id = UnitTestUtility.GetFakeValueForInt("Id");
            fromValue.Username = UnitTestUtility.GetFakeValueForString("Username");
            fromValue.ClaimName = UnitTestUtility.GetFakeValueForString("ClaimName");
            fromValue.ClaimValue = UnitTestUtility.GetFakeValueForString("ClaimValue");
            fromValue.UserId = UnitTestUtility.GetFakeValueForInt("UserId");
            fromValue.ClaimLogicType = UnitTestUtility.GetFakeValueForString("ClaimLogicType");
            fromValue.StartDate = UnitTestUtility.GetFakeValueForDateTime("StartDate");
            fromValue.EndDate = UnitTestUtility.GetFakeValueForDateTime("EndDate");
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
        
        public static List<Benday.EasyAuthDemo.Api.DomainModels.UserClaim> CreateModels(
            bool createAsUnsaved = true, int numberOfRecords = 10)
        {
            var returnValues = new List<Benday.EasyAuthDemo.Api.DomainModels.UserClaim>();
            
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
            Benday.EasyAuthDemo.Api.DomainModels.UserClaim fromValue)
        {
            if (fromValue == null)
            {
                throw new ArgumentNullException(nameof(fromValue), $"{nameof(fromValue)} is null.");
            }
            
            fromValue.Username = UnitTestUtility.GetFakeValueForString("Modified Username");
            fromValue.ClaimName = UnitTestUtility.GetFakeValueForString("Modified ClaimName");
            fromValue.ClaimValue = UnitTestUtility.GetFakeValueForString("Modified ClaimValue");
            fromValue.UserId = UnitTestUtility.GetFakeValueForInt("Modified UserId");
            fromValue.ClaimLogicType = UnitTestUtility.GetFakeValueForString("Modified ClaimLogicType");
            fromValue.StartDate = UnitTestUtility.GetFakeValueForDateTime("Modified StartDate");
            fromValue.EndDate = UnitTestUtility.GetFakeValueForDateTime("Modified EndDate");
            fromValue.Status = UnitTestUtility.GetFakeValueForString("Modified Status");
            fromValue.CreatedBy = UnitTestUtility.GetFakeValueForString("Modified CreatedBy");
            fromValue.CreatedDate = UnitTestUtility.GetFakeValueForDateTime("Modified CreatedDate");
            fromValue.LastModifiedBy = UnitTestUtility.GetFakeValueForString("Modified LastModifiedBy");
            fromValue.LastModifiedDate = UnitTestUtility.GetFakeValueForDateTime("Modified LastModifiedDate");
            fromValue.Timestamp = UnitTestUtility.GetFakeValueForByteArray("Modified Timestamp");
            
        }
        
        public static void AssertAreEqual(
            IList<Benday.EasyAuthDemo.Api.DomainModels.UserClaim> expected,
            IList<Benday.EasyAuthDemo.Api.DataAccess.Entities.UserClaimEntity> actual)
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
            Benday.EasyAuthDemo.Api.DomainModels.UserClaim expected,
            Benday.EasyAuthDemo.Api.DataAccess.Entities.UserClaimEntity actual)
        {
            Assert.AreEqual<int>(expected.Id, actual.Id, "Id");
            Assert.AreEqual<string>(expected.Username, actual.Username, "Username");
            Assert.AreEqual<string>(expected.ClaimName, actual.ClaimName, "ClaimName");
            Assert.AreEqual<string>(expected.ClaimValue, actual.ClaimValue, "ClaimValue");
            Assert.AreEqual<int>(expected.UserId, actual.UserId, "UserId");
            Assert.AreEqual<string>(expected.ClaimLogicType, actual.ClaimLogicType, "ClaimLogicType");
            Assert.AreEqual<DateTime>(expected.StartDate, actual.StartDate, "StartDate");
            Assert.AreEqual<DateTime>(expected.EndDate, actual.EndDate, "EndDate");
            Assert.AreEqual<string>(expected.Status, actual.Status, "Status");
            Assert.AreEqual<string>(expected.CreatedBy, actual.CreatedBy, "CreatedBy");
            Assert.AreEqual<DateTime>(expected.CreatedDate, actual.CreatedDate, "CreatedDate");
            Assert.AreEqual<string>(expected.LastModifiedBy, actual.LastModifiedBy, "LastModifiedBy");
            Assert.AreEqual<DateTime>(expected.LastModifiedDate, actual.LastModifiedDate, "LastModifiedDate");
            Assert.AreEqual<byte[]>(expected.Timestamp, actual.Timestamp, "Timestamp");
            
        }
        
        public static void AssertAreEqual(
            IList<Benday.EasyAuthDemo.Api.DataAccess.Entities.UserClaimEntity> expected,
            IList<Benday.EasyAuthDemo.Api.DomainModels.UserClaim> actual)
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
            Benday.EasyAuthDemo.Api.DataAccess.Entities.UserClaimEntity expected,
            Benday.EasyAuthDemo.Api.DomainModels.UserClaim actual)
        {
            Assert.AreEqual<int>(expected.Id, actual.Id, "Id");
            Assert.AreEqual<string>(expected.Username, actual.Username, "Username");
            Assert.AreEqual<string>(expected.ClaimName, actual.ClaimName, "ClaimName");
            Assert.AreEqual<string>(expected.ClaimValue, actual.ClaimValue, "ClaimValue");
            Assert.AreEqual<int>(expected.UserId, actual.UserId, "UserId");
            Assert.AreEqual<string>(expected.ClaimLogicType, actual.ClaimLogicType, "ClaimLogicType");
            Assert.AreEqual<DateTime>(expected.StartDate, actual.StartDate, "StartDate");
            Assert.AreEqual<DateTime>(expected.EndDate, actual.EndDate, "EndDate");
            Assert.AreEqual<string>(expected.Status, actual.Status, "Status");
            Assert.AreEqual<string>(expected.CreatedBy, actual.CreatedBy, "CreatedBy");
            Assert.AreEqual<DateTime>(expected.CreatedDate, actual.CreatedDate, "CreatedDate");
            Assert.AreEqual<string>(expected.LastModifiedBy, actual.LastModifiedBy, "LastModifiedBy");
            Assert.AreEqual<DateTime>(expected.LastModifiedDate, actual.LastModifiedDate, "LastModifiedDate");
            Assert.AreEqual<byte[]>(expected.Timestamp, actual.Timestamp, "Timestamp");
            
        }
    }
}

