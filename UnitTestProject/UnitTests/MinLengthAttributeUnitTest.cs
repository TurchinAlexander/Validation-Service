using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Validation_Service.Attributes;

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
            bool result = attr.IsValid(value);

            // assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void LowerThanMinTest()
        {
            // arrange
            string value = "1";

            // act
            var attr = new MinLengthAttribute(2);
            bool result = attr.IsValid(value);

            // assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void GreaterThanMinTest()
        {
            // arrange
            string value = "Hello";

            // act
            var attr = new MinLengthAttribute(2);
            bool result = attr.IsValid(value);

            // assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void EqualMinTest()
        {
            // arrange
            string value = "15";

            // act
            var attr = new MinLengthAttribute(2);
            bool result = attr.IsValid(value);

            // assert
            Assert.AreEqual(true, result);
        }

        /*
        [TestMethod]
        public void NegativeMinTest()
        {
            // arrange
            string value = "Test";

            // act
            var attr = new MinLengthAttribute(-1);
            bool result = attr.IsValid(value);

            // assert
            Assert.AreEqual(false, result);
        }
        */
    }
}
