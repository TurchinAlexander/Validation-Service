using System;
using System.Collections.Generic;
using Validation_Service.Attributes;
using Validation_Service.Result;
using Validation_Service.Service;
using Validation_Service.Logger;

namespace Validation_Service
{
    class Test
    {
        [Range(1, 4)]
        public int IntValue { get; set; }

        [MinLength(2)]
        public string StringValue { get; set; }

        public Test(int value1, string value2)
        {
            this.IntValue = value1;
            this.StringValue = value2;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var test = new Test(5, "H");
            ValidationLogger logger = new ValidationLogger();
            ValidationService validator = new ValidationService(logger);

            validator.Validate(test);

        }
    }
}
