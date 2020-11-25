using Benday.EasyAuthDemo.Api.Adapters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Benday.EasyAuthDemo.UnitTests.Utilities;
using Benday.EasyAuthDemo.WebUi.Models;
using Benday.EasyAuthDemo.WebUi.Models.Adapters;

namespace Benday.EasyAuthDemo.UnitTests.ViewModels.Adapters
{
    [TestClass]
    public class ConfigurationItemAdapterFixture
    {
        [TestInitialize]
        public void OnTestInitialize()
        {
            _SystemUnderTest = null;
        }
        
        private ConfigurationItemEditorViewModelAdapter _SystemUnderTest;
        public ConfigurationItemEditorViewModelAdapter SystemUnderTest
        {
            get
            {
                if (_SystemUnderTest == null)
                {
                    _SystemUnderTest = new ConfigurationItemEditorViewModelAdapter();
                }
                
                return _SystemUnderTest;
            }
        }
        
        [TestMethod]
        public void AdaptConfigurationItemFromViewModelsToModels()
        {
            // arrange
            var fromValues = ConfigurationItemViewModelTestUtility.CreateEditorViewModels();
            
            var allValuesCount = fromValues.Count;
            
            var toValues = new List<Benday.EasyAuthDemo.Api.DomainModels.ConfigurationItem>();
            
            // act
            SystemUnderTest.Adapt(fromValues, toValues);
            
            // assert
            Assert.AreEqual<int>(allValuesCount, toValues.Count, "Count was wrong.");
        }
        
        [TestMethod]
        public void AdaptConfigurationItemFromViewModelToModel()
        {
            // arrange
            var fromValue = ConfigurationItemViewModelTestUtility.CreateEditorViewModel();
            var toValue = new Benday.EasyAuthDemo.Api.DomainModels.ConfigurationItem();
            
            // act
            SystemUnderTest.Adapt(fromValue, toValue);
            
            // assert
            ConfigurationItemViewModelTestUtility.AssertAreEqual(fromValue, toValue);
        }
        
        [TestMethod]
        public void AdaptConfigurationItemFromModelToViewModel()
        {
            // arrange
            var fromValue = ConfigurationItemTestUtility.CreateModel();
            var toValue = new Benday.EasyAuthDemo.WebUi.Models.ConfigurationItemEditorViewModel();
            
            // act
            SystemUnderTest.Adapt(fromValue, toValue);
            
            // assert
            ConfigurationItemViewModelTestUtility.AssertAreEqual(fromValue, toValue);
        }
    }
}
