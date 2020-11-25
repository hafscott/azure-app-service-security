using Benday.EasyAuthDemo.Api.DomainModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Benday.EasyAuthDemo.UnitTests.DomainModels
{
    [TestClass]
    public class DomainModelBaseFixture
    {
        public class TestDomainModelBase : CoreFieldsDomainModelBase
        {
            
        }
        
        [TestInitialize]
        public void OnTestInitialize()
        {
            _SystemUnderTest = null;
        }
        
        private TestDomainModelBase _SystemUnderTest;
        
        private TestDomainModelBase SystemUnderTest
        {
            get
            {
                if (_SystemUnderTest == null)
                {
                    _SystemUnderTest = new TestDomainModelBase();
                }
                
                return _SystemUnderTest;
            }
        }
        
        [TestMethod]
        public void HasChanges_ForNewInstanceIsFalse()
        {
            // arrange
            bool expected = false;
            
            // act
            bool actual = SystemUnderTest.HasChanges();
            
            // assert
            Assert.AreEqual<bool>(expected, actual, "HasChanges() was wrong");
        }
        
        [TestMethod]
        public void HasChanges_WhenFieldHasBeenModified_IsTrue_Id()
        {
            // arrange
            bool expected = true;
            SystemUnderTest.Id = 1234;
            
            // act
            bool actual = SystemUnderTest.HasChanges();
            
            // assert
            Assert.AreEqual<bool>(expected, actual, "HasChanges() was wrong");
        }
        
        [TestMethod]
        public void CallToAcceptChangesOnModifiedClassSetsHasChangesToFalse_Id()
        {
            // arrange
            bool expected = false;
            SystemUnderTest.Id = 1234;
            
            // act
            SystemUnderTest.AcceptChanges();
            
            // assert
            bool actual = SystemUnderTest.HasChanges();
            Assert.AreEqual<bool>(expected, actual, "HasChanges() was wrong");
        }
        
        [TestMethod]
        public void CallToUndoChangesOnModifiedClassRevertsValueToOriginal_Id()
        {
            // arrange
            var expected = SystemUnderTest.Id;
            SystemUnderTest.Id = 1234;
            
            // act
            SystemUnderTest.UndoChanges();
            
            // assert
            var actual = SystemUnderTest.Id;
            Assert.AreEqual<int>(expected, actual, "Value didn't revert");
            Assert.AreEqual<bool>(false, SystemUnderTest.HasChanges(), "HasChanges() was wrong");
        }
        
        [TestMethod]
        public void HasChanges_WhenFieldHasBeenModified_IsTrue_Status()
        {
            // arrange
            bool expected = true;
            SystemUnderTest.Status = "BINGBONG";
            
            // act
            bool actual = SystemUnderTest.HasChanges();
            
            // assert
            Assert.AreEqual<bool>(expected, actual, "HasChanges() was wrong");
        }
        
        [TestMethod]
        public void CallToUndoChangesOnModifiedClassRevertsValueToOriginal_Status()
        {
            // arrange
            var expected = SystemUnderTest.Status;
            SystemUnderTest.Status = "BINGBONG";
            
            // act
            SystemUnderTest.UndoChanges();
            
            // assert
            var actual = SystemUnderTest.Status;
            Assert.AreEqual<string>(expected, actual, "Value didn't revert");
            Assert.AreEqual<bool>(false, SystemUnderTest.HasChanges(), "HasChanges() was wrong");
        }
        
        [TestMethod]
        public void CallToUndoChangesOnModifiedClassRevertsValueToValueAfterAcceptChanges_Status()
        {
            // arrange
            SystemUnderTest.Status = "BINGBONG";
            var expected = SystemUnderTest.Status;
            SystemUnderTest.AcceptChanges();
            SystemUnderTest.Status = "ASDF";
            
            // act
            SystemUnderTest.UndoChanges();
            
            // assert
            var actual = SystemUnderTest.Status;
            Assert.AreEqual<string>(expected, actual, "Value didn't revert");
            Assert.AreEqual<bool>(false, SystemUnderTest.HasChanges(), "HasChanges() was wrong");
        }
        
        [TestMethod]
        public void CallToAcceptChangesOnModifiedClassSetsHasChangesToFalse_Status()
        {
            // arrange
            bool expected = false;
            SystemUnderTest.Status = "BINGBONG";
            
            // act
            SystemUnderTest.AcceptChanges();
            
            // assert
            bool actual = SystemUnderTest.HasChanges();
            Assert.AreEqual<bool>(expected, actual, "HasChanges() was wrong");
        }
        
        [TestMethod]
        public void HasChanges_WhenFieldHasBeenModified_IsTrue_CreatedBy()
        {
            // arrange
            bool expected = true;
            SystemUnderTest.CreatedBy = "BINGBONG";
            
            // act
            bool actual = SystemUnderTest.HasChanges();
            
            // assert
            Assert.AreEqual<bool>(expected, actual, "HasChanges() was wrong");
        }
        
        [TestMethod]
        public void CallToUndoChangesOnModifiedClassRevertsValueToValueAfterAcceptChanges_CreatedBy()
        {
            // arrange
            SystemUnderTest.CreatedBy = "BINGBONG";
            var expected = SystemUnderTest.CreatedBy;
            SystemUnderTest.AcceptChanges();
            SystemUnderTest.CreatedBy = "ASDF";
            
            // act
            SystemUnderTest.UndoChanges();
            
            // assert
            var actual = SystemUnderTest.CreatedBy;
            Assert.AreEqual<string>(expected, actual, "Value didn't revert");
            Assert.AreEqual<bool>(false, SystemUnderTest.HasChanges(), "HasChanges() was wrong");
        }
        
        [TestMethod]
        public void CallToUndoChangesOnModifiedClassRevertsValueToOriginal_CreatedBy()
        {
            // arrange
            var expected = SystemUnderTest.CreatedBy;
            SystemUnderTest.CreatedBy = "BINGBONG";
            
            // act
            SystemUnderTest.UndoChanges();
            
            // assert
            var actual = SystemUnderTest.CreatedBy;
            Assert.AreEqual<string>(expected, actual, "Value didn't revert");
            Assert.AreEqual<bool>(false, SystemUnderTest.HasChanges(), "HasChanges() was wrong");
        }
        
        [TestMethod]
        public void CallToAcceptChangesOnModifiedClassSetsHasChangesToFalse_CreatedBy()
        {
            // arrange
            bool expected = false;
            SystemUnderTest.CreatedBy = "BINGBONG";
            
            // act
            SystemUnderTest.AcceptChanges();
            
            // assert
            bool actual = SystemUnderTest.HasChanges();
            Assert.AreEqual<bool>(expected, actual, "HasChanges() was wrong");
        }
        
        [TestMethod]
        public void HasChanges_WhenFieldHasBeenModified_IsTrue_LastModifiedBy()
        {
            // arrange
            bool expected = true;
            SystemUnderTest.LastModifiedBy = "BINGBONG";
            
            // act
            bool actual = SystemUnderTest.HasChanges();
            
            // assert
            Assert.AreEqual<bool>(expected, actual, "HasChanges() was wrong");
        }
        
        [TestMethod]
        public void CallToUndoChangesOnModifiedClassRevertsValueToValueAfterAcceptChanges_LastModifiedBy()
        {
            // arrange
            SystemUnderTest.LastModifiedBy = "BINGBONG";
            var expected = SystemUnderTest.LastModifiedBy;
            SystemUnderTest.AcceptChanges();
            SystemUnderTest.LastModifiedBy = "ASDF";
            
            // act
            SystemUnderTest.UndoChanges();
            
            // assert
            var actual = SystemUnderTest.LastModifiedBy;
            Assert.AreEqual<string>(expected, actual, "Value didn't revert");
            Assert.AreEqual<bool>(false, SystemUnderTest.HasChanges(), "HasChanges() was wrong");
        }
        
        [TestMethod]
        public void CallToUndoChangesOnModifiedClassRevertsValueToOriginal_LastModifiedBy()
        {
            // arrange
            var expected = SystemUnderTest.LastModifiedBy;
            SystemUnderTest.LastModifiedBy = "BINGBONG";
            
            // act
            SystemUnderTest.UndoChanges();
            
            // assert
            var actual = SystemUnderTest.LastModifiedBy;
            Assert.AreEqual<string>(expected, actual, "Value didn't revert");
            Assert.AreEqual<bool>(false, SystemUnderTest.HasChanges(), "HasChanges() was wrong");
        }
        
        [TestMethod]
        public void CallToAcceptChangesOnModifiedClassSetsHasChangesToFalse_LastModifiedBy()
        {
            // arrange
            bool expected = false;
            SystemUnderTest.LastModifiedBy = "BINGBONG";
            
            // act
            SystemUnderTest.AcceptChanges();
            
            // assert
            bool actual = SystemUnderTest.HasChanges();
            Assert.AreEqual<bool>(expected, actual, "HasChanges() was wrong");
        }
        
        [TestMethod]
        public void HasChanges_WhenFieldHasBeenModified_IsTrue_CreatedDate()
        {
            // arrange
            bool expected = true;
            SystemUnderTest.CreatedDate = DateTime.Now.AddYears(1);
            
            // act
            bool actual = SystemUnderTest.HasChanges();
            
            // assert
            Assert.AreEqual<bool>(expected, actual, "HasChanges() was wrong");
        }
        
        [TestMethod]
        public void CallToUndoChangesOnModifiedClassRevertsValueToValueAfterAcceptChanges_CreatedDate()
        {
            // arrange
            SystemUnderTest.CreatedDate = DateTime.Now.AddDays(1);
            var expected = SystemUnderTest.CreatedDate;
            SystemUnderTest.AcceptChanges();
            SystemUnderTest.CreatedDate = DateTime.Now.AddDays(2);
            
            // act
            SystemUnderTest.UndoChanges();
            
            // assert
            var actual = SystemUnderTest.CreatedDate;
            Assert.AreEqual<DateTime>(expected, actual, "Value didn't revert");
            Assert.AreEqual<bool>(false, SystemUnderTest.HasChanges(), "HasChanges() was wrong");
        }
        
        [TestMethod]
        public void CallToUndoChangesOnModifiedClassRevertsValueToOriginal_CreatedDate()
        {
            // arrange
            var expected = SystemUnderTest.CreatedDate;
            SystemUnderTest.CreatedDate = DateTime.Now.AddDays(1);
            
            // act
            SystemUnderTest.UndoChanges();
            
            // assert
            var actual = SystemUnderTest.CreatedDate;
            Assert.AreEqual<DateTime>(expected, actual, "Value didn't revert");
            Assert.AreEqual<bool>(false, SystemUnderTest.HasChanges(), "HasChanges() was wrong");
        }
        
        [TestMethod]
        public void CallToAcceptChangesOnModifiedClassSetsHasChangesToFalse_CreatedDate()
        {
            // arrange
            bool expected = false;
            SystemUnderTest.CreatedDate = DateTime.Now.AddYears(1);
            
            // act
            SystemUnderTest.AcceptChanges();
            
            // assert
            bool actual = SystemUnderTest.HasChanges();
            Assert.AreEqual<bool>(expected, actual, "HasChanges() was wrong");
        }
        
        [TestMethod]
        public void HasChanges_WhenFieldHasBeenModified_IsTrue_LastModifiedDate()
        {
            // arrange
            bool expected = true;
            SystemUnderTest.LastModifiedDate = DateTime.Now.AddYears(1);
            
            // act
            bool actual = SystemUnderTest.HasChanges();
            
            // assert
            Assert.AreEqual<bool>(expected, actual, "HasChanges() was wrong");
        }
        
        [TestMethod]
        public void CallToUndoChangesOnModifiedClassRevertsValueToValueAfterAcceptChanges_LastModifiedDate()
        {
            // arrange
            SystemUnderTest.LastModifiedDate = DateTime.Now.AddDays(1);
            var expected = SystemUnderTest.LastModifiedDate;
            SystemUnderTest.AcceptChanges();
            SystemUnderTest.LastModifiedDate = DateTime.Now.AddDays(2);
            
            // act
            SystemUnderTest.UndoChanges();
            
            // assert
            var actual = SystemUnderTest.LastModifiedDate;
            Assert.AreEqual<DateTime>(expected, actual, "Value didn't revert");
            Assert.AreEqual<bool>(false, SystemUnderTest.HasChanges(), "HasChanges() was wrong");
        }
        
        [TestMethod]
        public void CallToUndoChangesOnModifiedClassRevertsValueToOriginal_LastModifiedDate()
        {
            // arrange
            var expected = SystemUnderTest.LastModifiedDate;
            SystemUnderTest.LastModifiedDate = DateTime.Now.AddDays(1);
            
            // act
            SystemUnderTest.UndoChanges();
            
            // assert
            var actual = SystemUnderTest.LastModifiedDate;
            Assert.AreEqual<DateTime>(expected, actual, "Value didn't revert");
            Assert.AreEqual<bool>(false, SystemUnderTest.HasChanges(), "HasChanges() was wrong");
        }
        
        [TestMethod]
        public void CallToAcceptChangesOnModifiedClassSetsHasChangesToFalse_LastModifiedDate()
        {
            // arrange
            bool expected = false;
            SystemUnderTest.LastModifiedDate = DateTime.Now.AddYears(1);
            
            // act
            SystemUnderTest.AcceptChanges();
            
            // assert
            bool actual = SystemUnderTest.HasChanges();
            Assert.AreEqual<bool>(expected, actual, "HasChanges() was wrong");
        }
    }
}
