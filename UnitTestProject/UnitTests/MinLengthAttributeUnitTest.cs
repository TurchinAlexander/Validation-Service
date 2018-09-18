using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Validation_Service.Attributes;
using Validation_Service.Result;

namespace UnitTestProject
{
    [TestClass]
    public class MinLengthAttributeUnitTest
    {
        [TestMethod]
        public void NullTest()
        {
            // arrange
            object value = null;

            // act
            var attr = new MinLengthAttribute(2);
            SingleReport result = attr.Validate(value);

            // assert
            Assert.AreEqual(true, result.IsValid);
        }

        [TestMethod]
        public void LowerThanMinTest()
        {
            // arrange
            string value = "1";

            // act
            var attr = new MinLengthAttribute(2);
            SingleReport result = attr.Validate(value);

            // assert
            Assert.AreEqual(false, result.IsValid);
        }

        [TestMethod]
        public void GreaterThanMinTest()
        {
            // arrange
            string value = "Hello";

            // act
            var attr = new MinLengthAttribute(2);
            SingleReport result = attr.Validate(value);

            // assert
            Assert.AreEqual(true, result.IsValid);
        }

        [TestMethod]
        public void EqualMinTest()
        {
            // arrange
            string value = "15";

            // act
            var attr = new MinLengthAttribute(2);
            SingleReport result = attr.Validate(value);

            // assert
            Assert.AreEqual(true, result.IsValid);
        }
    }
}
