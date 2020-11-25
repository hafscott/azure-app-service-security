using Benday.EasyAuthDemo.Api.DomainModels;
using Benday.EasyAuthDemo.UnitTests.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Benday.EasyAuthDemo.UnitTests.DomainModels
{
    [TestClass]
    public partial class LogEntryFixture
    {
        [TestInitialize]
        public void OnTestInitialize()
        {
            _SystemUnderTest = null;
        }
        
        private LogEntry _SystemUnderTest;
        public LogEntry SystemUnderTest
        {
            get
            {
                if (_SystemUnderTest == null)
                {
                    _SystemUnderTest = new LogEntry();
                }
                
                return _SystemUnderTest;
            }
        }
        
        [TestMethod]
        public void LogEntry_VerifyDomainModelBaseOperations()
        {
            var instance = LogEntryTestUtility.CreateModel(false);
            
            instance.AcceptChanges();
            
            var tester = new DomainModelFieldTester<LogEntry>(instance);
            
            tester.RunChangeTrackingTestsForValueTypeProperties();
        }
        
        
    }
}
