using System;
using Moq;
using UnitTestProject.Entitites;
using Validation_Service.Logger;
using Validation_Service.Service;
using Validation_Service.Result;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject.UnitTests
{
    [TestClass]
    public class LoggerTest
    {
        [TestMethod]
        public void CheckIfLoggerIsWorking()
        {
            Mock<ILogger> loggerMock = new Mock<ILogger>();

            ValidationService valService = new ValidationService(loggerMock.Object);

            ValidationServiceTestEntity invalidObject = new ValidationServiceTestEntity(
                digit: -1, negativeInteger: 5, moreOneCharString: "",
                requiredObject: null, notEmptyString: "");

            FullReport result = valService.Validate(invalidObject);

            loggerMock.Verify(validator => validator.Log(It.IsAny<string>()), 
                Times.Exactly(result.Details.Count));
        }
    }
}
