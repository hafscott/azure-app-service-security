using Benday.EasyAuthDemo.Api.DomainModels;
using Benday.EasyAuthDemo.UnitTests.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Benday.EasyAuthDemo.UnitTests.DomainModels
{
    [TestClass]
    public partial class ConfigurationItemFixture
    {
        [TestInitialize]
        public void OnTestInitialize()
        {
            _SystemUnderTest = null;
        }
        
        private ConfigurationItem _SystemUnderTest;
        public ConfigurationItem SystemUnderTest
        {
            get
            {
                if (_SystemUnderTest == null)
                {
                    _SystemUnderTest = new ConfigurationItem();
                }
                
                return _SystemUnderTest;
            }
        }
        
        [TestMethod]
        public void ConfigurationItem_VerifyDomainModelBaseOperations()
        {
            var instance = ConfigurationItemTestUtility.CreateModel(false);
            
            instance.AcceptChanges();
            
            var tester = new DomainModelFieldTester<ConfigurationItem>(instance);
            
            tester.RunChangeTrackingTestsForValueTypeProperties();
        }
        
        
    }
}
