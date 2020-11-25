using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Benday.EasyAuthDemo.Api;
using Benday.EasyAuthDemo.UnitTests.Utilities;

namespace Benday.EasyAuthDemo.UnitTests.ViewModels
{
    public static class UserClaimViewModelTestUtility
    {
        public static List<Benday.EasyAuthDemo.WebUi.Models.UserClaimEditorViewModel> CreateEditorViewModels(
            bool createAsUnsaved = true)
        {
            var returnValues = new List<Benday.EasyAuthDemo.WebUi.Models.UserClaimEditorViewModel>();
            
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
        
        public static Benday.EasyAuthDemo.WebUi.Models.UserClaimEditorViewModel CreateEditorViewModel(
            bool createAsUnsaved = true)
        {
            var fromValue = new Benday.EasyAuthDemo.WebUi.Models.UserClaimEditorViewModel();
            
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
        
        public static void AssertAreEqual(
            IList<Benday.EasyAuthDemo.Api.DomainModels.UserClaim> expected,
            IList<Benday.EasyAuthDemo.WebUi.Models.UserClaimEditorViewModel> actual)
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
            Benday.EasyAuthDemo.WebUi.Models.UserClaimEditorViewModel actual)
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
            IList<Benday.EasyAuthDemo.WebUi.Models.UserClaimEditorViewModel> expected,
            IList<Benday.EasyAuthDemo.Api.DomainModels.UserClaim> actual)
        {
            Assert.IsNotNull(expected, "Expected was null.");
            Assert.IsNotNull(actual, "Actual was null.");
            Assert.AreEqual<int>(expected.Count, actual.Count,
            "{0}.AssertAreEqual(): Item count should match.",
            nameof(UserClaimViewModelTestUtility));
            
            for (int i = 0; i < expected.Count; i++)
            {
                AssertAreEqual(expected[i], actual[i]);
            }
        }
        
        public static void AssertAreNotEqual(
            Benday.EasyAuthDemo.WebUi.Models.UserClaimEditorViewModel expected,
            Benday.EasyAuthDemo.Api.DomainModels.UserClaim actual)
        {
            Assert.AreNotEqual<int>(expected.Id, actual.Id,
            "{0}.AssertAreNotEqual(): Id should not match.",
            nameof(UserClaimViewModelTestUtility));
        }
        
        public static void AssertAreEqual(
            Benday.EasyAuthDemo.WebUi.Models.UserClaimEditorViewModel expected,
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

