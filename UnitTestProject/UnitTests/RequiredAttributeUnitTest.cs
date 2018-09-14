using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Validation_Service.Attributes;

namespace UnitTestProject
{
    [TestClass]
    public class RequiredAttributeUnitTest
    {
        [TestMethod]
        public void NullObjectTest()
        {
            // arrange
            object value = null;

            // act
            var attr = new RequiredAttribute();
            bool result = attr.IsValid(value);

            // assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void EmptyStringWithOutAllow()
        {
            // arrange
            string value = "";

            // act
            var attr = new RequiredAttribute();
            bool result = attr.IsValid(value);

            // assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void EmptyStringWithAllow()
        {
            // arrange
            string value = "";

            // act
            var attr = new RequiredAttribute();
            attr.AllowEmptyString = true;
            bool result = attr.IsValid(value);

            // assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void StringWithSpaces()
        {
            // arrange
            string value = "    ";

            // act
            var attr = new RequiredAttribute();
            bool result = attr.IsValid(value);

            // assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void NotEmptyString()
        {
            // arrange
            string value = "123";

            // act
            var attr = new RequiredAttribute();
            bool result = attr.IsValid(value);

            // assert
            Assert.AreEqual(true, result);
        }
    }
}
