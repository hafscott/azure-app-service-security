using Benday.EasyAuthDemo.Api.DomainModels;
using Benday.EasyAuthDemo.UnitTests.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Benday.EasyAuthDemo.UnitTests.DomainModels
{
    [TestClass]
    public partial class LookupFixture
    {
        [TestInitialize]
        public void OnTestInitialize()
        {
            _SystemUnderTest = null;
        }
        
        private Lookup _SystemUnderTest;
        public Lookup SystemUnderTest
        {
            get
            {
                if (_SystemUnderTest == null)
                {
                    _SystemUnderTest = new Lookup();
                }
                
                return _SystemUnderTest;
            }
        }
        
        [TestMethod]
        public void Lookup_VerifyDomainModelBaseOperations()
        {
            var instance = LookupTestUtility.CreateModel(false);
            
            instance.AcceptChanges();
            
            var tester = new DomainModelFieldTester<Lookup>(instance);
            
            tester.RunChangeTrackingTestsForValueTypeProperties();
        }
        
        
    }
}
