using System;
using Validation_Service.Attributes;
using Validation_Service.Result;
using Validation_Service.Service;

namespace Validation_Service
{
    class Test
    {
        [Range(1, 4)]
        public int Value1 { get; set; }

        [MinLength(5)]
        public string Value2 { get; set; }

        public Test(int value1, string value2)
        {
            this.Value1 = value1;
            this.Value2 = value2;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var test = new Test(2, "Heeeeeeey");
            ValidationService validator = new ValidationService();

            FullReport fullReport =  validator.Validate(test);
            foreach(string temp in fullReport.Details)
            {
                Console.WriteLine(temp);
            }
        }
    }
}
