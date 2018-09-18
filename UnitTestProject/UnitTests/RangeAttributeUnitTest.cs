using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Validation_Service.Attributes;
using Validation_Service.Result;

namespace UnitTestProject
{
    [TestClass]
    public class RangeAttributeUnitTest
    {
        [TestMethod]
        public void NullTest()
        {
            // arrange
            object value = null;

            // act
            var attr = new RangeAttribute(1, 7);
            SingleReport result = attr.Validate(value);

            // assert
            Assert.AreEqual(true, result.IsValid);
        }

        [TestMethod]
        public void InRangeTest()
        {
            // arrange
            object value = 5;

            // act
            var attr = new RangeAttribute(1, 7);
            SingleReport result = attr.Validate(value);

            // assert
            Assert.AreEqual(true, result.IsValid);
        }

        [TestMethod]
        public void OutOfRangeTest()
        {
            // arrange
            object value = 10;

            // act
            var attr = new RangeAttribute(1, 7);
            SingleReport result = attr.Validate(value);

            // assert
            Assert.AreEqual(false, result.IsValid);
        }

        [TestMethod]
        public void CornerDigitTest()
        {
            // arrange
            object value = 7;

            // act
            var attr = new RangeAttribute(1, 7);
            SingleReport result = attr.Validate(value);

            // assert
            Assert.AreEqual(true, result.IsValid);
        }

        [TestMethod]
        public void MinGreaterMaxTest()
        {
            // arrange
            object value = 7;

            // act
            var attr = new RangeAttribute(2, 1);
            SingleReport result = attr.Validate(value);

            // assert
            Assert.AreEqual(false, result.IsValid);
        }
    }
}
