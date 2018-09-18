using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Validation_Service.Attributes;
using Validation_Service.Result;

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
            SingleReport result = attr.Validate(value);

            // assert
            Assert.AreEqual(false, result.IsValid);
        }

        [TestMethod]
        public void EmptyStringWithOutAllow()
        {
            // arrange
            string value = "";

            // act
            var attr = new RequiredAttribute();
            SingleReport result = attr.Validate(value);

            // assert
            Assert.AreEqual(false, result.IsValid);
        }

        [TestMethod]
        public void EmptyStringWithAllow()
        {
            // arrange
            string value = "";

            // act
            var attr = new RequiredAttribute();
            attr.AllowEmptyString = true;
            SingleReport result = attr.Validate(value);

            // assert
            Assert.AreEqual(true, result.IsValid);
        }

        [TestMethod]
        public void StringWithSpaces()
        {
            // arrange
            string value = "    ";

            // act
            var attr = new RequiredAttribute();
            SingleReport result = attr.Validate(value);

            // assert
            Assert.AreEqual(false, result.IsValid);
        }

        [TestMethod]
        public void NotEmptyString()
        {
            // arrange
            string value = "123";

            // act
            var attr = new RequiredAttribute();
            SingleReport result = attr.Validate(value);

            // assert
            Assert.AreEqual(true, result.IsValid);
        }
    }
}
