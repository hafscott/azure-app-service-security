using Benday.EasyAuthDemo.Api.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Benday.EasyAuthDemo.IntegrationTests.MvcControllers
{
    [TestClass]
    public class UserClaimMvcControllerFixture : WebUiIntegrationTestFixtureBase
    {
        [TestMethod]
        [Timeout(10000)]
        public async Task IndexReturnsWithoutError()
        {
            // arrange
            string url = "/userclaim";
            
            InitializeSecurityWithMock(
            SecurityConstants.Policy_IsAdministrator, true);
            // act
            var response = await Client.GetAsync(url);
            
            // assert
            await CheckForDependencyInjectionError(response);
            
            Assert.IsTrue(response.IsSuccessStatusCode,
            "Call to '{0}' failed with '{1} - '{2}'.",
            url, response.StatusCode, response.ReasonPhrase);
        }
    }
}

