using Benday.EasyAuthDemo.Api;
using Benday.EasyAuthDemo.Api.DomainModels;
using Benday.EasyAuthDemo.Api.ServiceLayers;
using Benday.EasyAuthDemo.WebUi;
using Benday.EasyAuthDemo.UnitTests.Fakes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Benday.EasyAuthDemo.IntegrationTests
{
    public abstract class AspNetIntegrationTestFixtureBase<TEntryPoint> where TEntryPoint : class
    {
        [TestCleanup]
        public void OnTestCleanup()
        {
            Console.WriteLine("Calling OnTestCleanup()...");
            if (_WebApplicationInstance != null)
            {
                _WebApplicationInstance.Dispose();
            }
            
            Reset();
        }
        
        protected void Reset()
        {
            _WebApplicationInstance = null;
            _Client = null;
            _Scope = null;
            _HostServices = null;
        }
        
        protected WebApplicationFactory<TEntryPoint> _WebApplicationInstance;
        protected WebApplicationFactory<TEntryPoint> WebApplicationInstance
        {
            get
            {
                if (_WebApplicationInstance == null)
                {
                    try
                    {
                        _WebApplicationInstance =
                        CreateWebApplicationFactory();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error while creating instance of web application factory.  {0}", ex);
                        throw;
                    }
                }
                
                return _WebApplicationInstance;
            }
        }
        
        protected virtual WebApplicationFactory<TEntryPoint> CreateWebApplicationFactory()
        {
            return new WebApplicationFactory<TEntryPoint>();
        }
        
        protected void InitializeSecurityWithMock(
            string policyName, bool isAuthorizedReturnValue)
        {
            Reset();
            
            _WebApplicationInstance =
            new WebApplicationFactory<TEntryPoint>().WithWebHostBuilder(
            builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.AddAuthorization(options =>
                    {
                        options.AddPolicy(policyName,
                        policy => policy.Requirements.Add(
                        new MockAuthorizationRequirement(isAuthorizedReturnValue)));
                    });
                    
                    services.AddSingleton<IAuthorizationHandler, MockAuthorizationHandler>();
                });
            });
        }
        
        protected T CreateInstance<T>()
        {
            var provider = Scope.ServiceProvider;
            
            var returnValue = provider.GetService<T>();
            
            return returnValue;
        }
        
        protected HttpClient _Client;
        protected HttpClient Client
        {
            get
            {
                if (_Client == null)
                {
                    var webAppInstance = WebApplicationInstance;
                    
                    
                    try
                    {
                        _Client = webAppInstance.CreateDefaultClient();
                    }
                    catch (AggregateException ex)
                    {
                        CheckForDependencyInjectionError(ex);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error while creating instance of default client.  {0}", ex);
                        throw;
                    }
                }
                
                return _Client;
            }
        }
        
        private void EnsureClientIsInitialized()
        {
            if (Client == null)
            {
                Assert.Fail("Client could not be initialized.");
            }
        }
        
        protected IServiceProvider _HostServices;
        protected IServiceProvider HostServices
        {
            get
            {
                if (_HostServices == null)
                {
                    _HostServices = WebApplicationInstance.Services;
                }
                
                return _HostServices;
            }
        }
        
        protected IServiceScope _Scope;
        protected IServiceScope Scope
        {
            get
            {
                if (_Scope == null)
                {
                    EnsureClientIsInitialized();
                    
                    var scopeFactory = HostServices.GetService(
                    typeof(IServiceScopeFactory)) as IServiceScopeFactory;
                    
                    _Scope = scopeFactory.CreateScope();
                }
                
                return _Scope;
            }
        }
        
        private readonly string START_OF_DI_ERROR_MSG_FULL = "System.InvalidOperationException: Unable to resolve service for type ";
        private readonly string START_OF_DI_ERROR_MSG_VARIATION_2 = "System.InvalidOperationException: No service for type '";
        private readonly string END_OF_DI_ERROR_MSG_VARIATION_2 = "' has been registered.";
        private readonly string START_OF_DI_ERROR_MSG = ": Unable to resolve service for type ";
        private readonly string MIDDLE_OF_DI_ERROR_MSG = "while attempting to activate ";
        protected string IsDependencyInjectionError(string content)
        {
            if (content.StartsWith(START_OF_DI_ERROR_MSG_FULL) == true)
            {
                return "variation1";
            }
            if (content.StartsWith(START_OF_DI_ERROR_MSG_VARIATION_2) == true &&
            content.Contains(END_OF_DI_ERROR_MSG_VARIATION_2) == true)
            {
                return "variation2";
            }
            else
            {
                return null;
            }
        }
        
        protected string GetDependencyInjectionErrorInfo(string content, string errorVariation)
        {
            if (errorVariation == "variation1")
            {
                return GetDependencyInjectionErrorInfoVariation1(content);
            }
            else
            {
                return GetDependencyInjectionErrorInfoVariation2(content);
            }
        }
        
        
        protected string GetDependencyInjectionErrorInfoVariation1(string content)
        {
            int indexOfStartOfMessage = content.IndexOf(START_OF_DI_ERROR_MSG);
            int indexOfFailedInterface = indexOfStartOfMessage + START_OF_DI_ERROR_MSG.Length;
            int indexOfFailedClassMessage = content.IndexOf(MIDDLE_OF_DI_ERROR_MSG);
            int indexOfFailedClass = indexOfFailedClassMessage + MIDDLE_OF_DI_ERROR_MSG.Length;
            int indexOfEndOfError = content.IndexOf("'.", indexOfFailedClass);
            
            if (indexOfStartOfMessage == -1 || indexOfFailedClassMessage == -1)
            {
                return null;
            }
            else
            {
                var failedInterface =
                content.Substring(indexOfFailedInterface,
                (indexOfFailedClassMessage - indexOfFailedInterface));
                
                var failedClass =
                content.Substring(indexOfFailedClass,
                indexOfEndOfError - indexOfFailedClass);
                
                return String.Format("Tried to create {0} for {1}'.  Check type registrations in Startup.cs.",
                failedInterface.Trim(), failedClass.Trim());
            }
        }
        
        protected string GetDependencyInjectionErrorInfoVariation2(string content)
        {
            content = content.Replace(START_OF_DI_ERROR_MSG_VARIATION_2, String.Empty);
            content = content.Replace(END_OF_DI_ERROR_MSG_VARIATION_2, Environment.NewLine);
            
            var reader = new StringReader(content);
            
            var line = reader.ReadLine();
            
            if (String.IsNullOrWhiteSpace(line) == true)
            {
                return null;
            }
            else
            {
                line = line.Trim();
                
                return String.Format(
                "Tried to create instance of {0}.  Check type registrations in Startup.cs.",
                line);
            }
        }
        
        protected async Task CheckForDependencyInjectionError(
            HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode == false)
            {
                var content = await response.Content.ReadAsStringAsync();
                
                Console.WriteLine("Content from server: {0}", content);
                
                var errorVariationInfo = IsDependencyInjectionError(content);
                if (errorVariationInfo != null)
                {
                    Assert.Fail(GetDependencyInjectionErrorInfo(content, errorVariationInfo));
                }
            }
        }
        
        protected void CheckForDependencyInjectionError(
            AggregateException ex)
        {
            if (ex.InnerException == null)
            {
                return;
            }
            
            if (ex.InnerException.Source == "Microsoft.Extensions.DependencyInjection")
            {
                var message = GetDependencyInjectionErrorInfoVariation1(ex.InnerException.Message);
                
                Assert.Fail(message);
            }
            else
            {
                return;
            }
        }
    }
}
