using Microsoft.VisualStudio.TestTools.UnitTesting;
using Benday.EasyAuthDemo.Api.AzureStorage;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Options;
using System;
using Benday.EasyAuthDemo.UnitTests.Fakes;

namespace Benday.EasyAuthDemo.UnitTests.AzureStorage
{
    [TestClass()]
    public class AzureBlobImageStorageHelperFixture
    {
        [TestInitialize]
        public void OnTestInitialize()
        {
            _SystemUnderTest = null;
        }
        
        private AzureBlobImageStorageHelper _SystemUnderTest;
        public AzureBlobImageStorageHelper SystemUnderTest
        {
            get
            {
                if (_SystemUnderTest == null)
                {
                    _SystemUnderTest =
                    new AzureBlobImageStorageHelper(GetOptionsConfiguration());
                }
                
                return _SystemUnderTest;
            }
        }
        
        private IOptionsMonitor<AzureBlobImageStorageOptions> GetOptionsConfiguration()
        {
            var config = new AzureBlobImageStorageOptions();
            
            config.UseDevelopmentStorage = true;
            config.ContainerName = "course-assets";
            
            var returnValue = new OptionsMonitorMock<AzureBlobImageStorageOptions>();
            
            returnValue.CurrentValue = config;
            
            return returnValue;
        }
        
        [TestMethod()]
        public void GetTokenAndAppendToUri_RelativeUrl_ForDevelopmentStorage()
        {
            // arrange
            var container = "course-assets";
            
            var expectedStartOfUrl = "http://127.0.0.1:10000/devstoreaccount1/course-assets/azure-devops-getting-started/m02/azure-devops-getting-started-m2-01.mp4";
            
            var relativeUrl = "azure-devops-getting-started/m02/azure-devops-getting-started-m2-01.mp4";
            
            // act
            var actual = SystemUnderTest.GetBlobUriWithSasToken(container, relativeUrl);
            
            // assert
            Console.WriteLine(actual);
            StringAssert.StartsWith(actual.ToString(), expectedStartOfUrl);
        }
    }
}
