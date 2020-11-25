using Benday.EasyAuthDemo.Api.DomainModels;
using Benday.EasyAuthDemo.UnitTests.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Benday.EasyAuthDemo.UnitTests.DomainModels
{
    [TestClass]
    public partial class PersonFixture
    {
        [TestInitialize]
        public void OnTestInitialize()
        {
            _SystemUnderTest = null;
        }
        
        private Person _SystemUnderTest;
        public Person SystemUnderTest
        {
            get
            {
                if (_SystemUnderTest == null)
                {
                    _SystemUnderTest = new Person();
                }
                
                return _SystemUnderTest;
            }
        }
        
        [TestMethod]
        public void Person_VerifyDomainModelBaseOperations()
        {
            var instance = PersonTestUtility.CreateModel(false);
            
            instance.AcceptChanges();
            
            var tester = new DomainModelFieldTester<Person>(instance);
            
            tester.RunChangeTrackingTestsForValueTypeProperties();
        }
        
        
    }
}
