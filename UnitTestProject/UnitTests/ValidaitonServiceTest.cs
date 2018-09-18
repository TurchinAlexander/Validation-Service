using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestProject.Entitites;
using Validation_Service.Result;
using Validation_Service.Service;
using Validation_Service.Logger;

namespace UnitTestProject.UnitTests
{
    [TestClass]
    public class ValidaitonServiceTest
    {
        [TestMethod]
        public void AllPropertiesAreRight()
        {
            var logger = new ValidationLogger();
            var valService = new ValidationService(logger);

            ValidationServiceTestEntity obj = new ValidationServiceTestEntity(
                digit: 1, negativeInteger: -5, moreOneCharString: "a",
                requiredObject: new List<int>(), notEmptyString: "string");

            Assert.IsTrue(valService.Validate(obj).IsValid);
        }

        [TestMethod]
        public void AllPropertiesAreWrong()
        {
            const int MSG_COUNT = 5;

            var logger = new ValidationLogger();
            var valService = new ValidationService(logger);

            ValidationServiceTestEntity obj = new ValidationServiceTestEntity(
                digit: -1, negativeInteger: 5, moreOneCharString: "",
                requiredObject: null, notEmptyString: "");

            FullReport result = valService.Validate(obj);

            Assert.AreEqual(MSG_COUNT, result.Details.Count);
        }
    }
}
