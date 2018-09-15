using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validation_Service.Attributes;


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
            var validator = new Validator();

            validator.Validate(test);

        }
    }
}
