using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Benday.EasyAuthDemo.Api;
using Benday.EasyAuthDemo.UnitTests.Utilities;

namespace Benday.EasyAuthDemo.UnitTests.ViewModels
{
    public static class UserViewModelTestUtility
    {
        public static List<Benday.EasyAuthDemo.WebUi.Models.UserEditorViewModel> CreateEditorViewModels(
            bool createAsUnsaved = true)
        {
            var returnValues = new List<Benday.EasyAuthDemo.WebUi.Models.UserEditorViewModel>();
            
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
        
        public static Benday.EasyAuthDemo.WebUi.Models.UserEditorViewModel CreateEditorViewModel(
            bool createAsUnsaved = true)
        {
            var fromValue = new Benday.EasyAuthDemo.WebUi.Models.UserEditorViewModel();
            
            fromValue.Id = UnitTestUtility.GetFakeValueForInt("Id");
            fromValue.Username = UnitTestUtility.GetFakeValueForString("Username");
            fromValue.Source = UnitTestUtility.GetFakeValueForString("Source");
            fromValue.EmailAddress = UnitTestUtility.GetFakeValueForString("EmailAddress");
            fromValue.FirstName = UnitTestUtility.GetFakeValueForString("FirstName");
            fromValue.LastName = UnitTestUtility.GetFakeValueForString("LastName");
            fromValue.PhoneNumber = UnitTestUtility.GetFakeValueForString("PhoneNumber");
            // fromValue.Claims = UnitTestUtility.GetFakeValueForUserClaim("Claims");
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
            IList<Benday.EasyAuthDemo.Api.DomainModels.User> expected,
            IList<Benday.EasyAuthDemo.WebUi.Models.UserEditorViewModel> actual)
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
            Benday.EasyAuthDemo.Api.DomainModels.User expected,
            Benday.EasyAuthDemo.WebUi.Models.UserEditorViewModel actual)
        {
            Assert.AreEqual<int>(expected.Id, actual.Id, "Id");
            Assert.AreEqual<string>(expected.Username, actual.Username, "Username");
            Assert.AreEqual<string>(expected.Source, actual.Source, "Source");
            Assert.AreEqual<string>(expected.EmailAddress, actual.EmailAddress, "EmailAddress");
            Assert.AreEqual<string>(expected.FirstName, actual.FirstName, "FirstName");
            Assert.AreEqual<string>(expected.LastName, actual.LastName, "LastName");
            Assert.AreEqual<string>(expected.PhoneNumber, actual.PhoneNumber, "PhoneNumber");
            // Assert.AreEqual<UserClaim>(expected.Claims, actual.Claims, "Claims");
            Assert.AreEqual<string>(expected.Status, actual.Status, "Status");
            Assert.AreEqual<string>(expected.CreatedBy, actual.CreatedBy, "CreatedBy");
            Assert.AreEqual<DateTime>(expected.CreatedDate, actual.CreatedDate, "CreatedDate");
            Assert.AreEqual<string>(expected.LastModifiedBy, actual.LastModifiedBy, "LastModifiedBy");
            Assert.AreEqual<DateTime>(expected.LastModifiedDate, actual.LastModifiedDate, "LastModifiedDate");
            Assert.AreEqual<byte[]>(expected.Timestamp, actual.Timestamp, "Timestamp");
            
        }
        
        public static void AssertAreEqual(
            IList<Benday.EasyAuthDemo.WebUi.Models.UserEditorViewModel> expected,
            IList<Benday.EasyAuthDemo.Api.DomainModels.User> actual)
        {
            Assert.IsNotNull(expected, "Expected was null.");
            Assert.IsNotNull(actual, "Actual was null.");
            Assert.AreEqual<int>(expected.Count, actual.Count,
            "{0}.AssertAreEqual(): Item count should match.",
            nameof(UserViewModelTestUtility));
            
            for (int i = 0; i < expected.Count; i++)
            {
                AssertAreEqual(expected[i], actual[i]);
            }
        }
        
        public static void AssertAreNotEqual(
            Benday.EasyAuthDemo.WebUi.Models.UserEditorViewModel expected,
            Benday.EasyAuthDemo.Api.DomainModels.User actual)
        {
            Assert.AreNotEqual<int>(expected.Id, actual.Id,
            "{0}.AssertAreNotEqual(): Id should not match.",
            nameof(UserViewModelTestUtility));
        }
        
        public static void AssertAreEqual(
            Benday.EasyAuthDemo.WebUi.Models.UserEditorViewModel expected,
            Benday.EasyAuthDemo.Api.DomainModels.User actual)
        {
            Assert.AreEqual<int>(expected.Id, actual.Id, "Id");
            Assert.AreEqual<string>(expected.Username, actual.Username, "Username");
            Assert.AreEqual<string>(expected.Source, actual.Source, "Source");
            Assert.AreEqual<string>(expected.EmailAddress, actual.EmailAddress, "EmailAddress");
            Assert.AreEqual<string>(expected.FirstName, actual.FirstName, "FirstName");
            Assert.AreEqual<string>(expected.LastName, actual.LastName, "LastName");
            Assert.AreEqual<string>(expected.PhoneNumber, actual.PhoneNumber, "PhoneNumber");
            // Assert.AreEqual<UserClaim>(expected.Claims, actual.Claims, "Claims");
            Assert.AreEqual<string>(expected.Status, actual.Status, "Status");
            Assert.AreEqual<string>(expected.CreatedBy, actual.CreatedBy, "CreatedBy");
            Assert.AreEqual<DateTime>(expected.CreatedDate, actual.CreatedDate, "CreatedDate");
            Assert.AreEqual<string>(expected.LastModifiedBy, actual.LastModifiedBy, "LastModifiedBy");
            Assert.AreEqual<DateTime>(expected.LastModifiedDate, actual.LastModifiedDate, "LastModifiedDate");
            Assert.AreEqual<byte[]>(expected.Timestamp, actual.Timestamp, "Timestamp");
            
        }
    }
}

