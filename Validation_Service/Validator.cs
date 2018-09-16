using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Validation_Service
{
    public class Validator : IValidator
    {
        public bool Validate(object obj)
        {
            foreach(PropertyInfo prop in obj.GetType().GetProperties())
            {
                object value = prop.GetValue(obj);
                foreach(ValidationAttribute attr in prop.GetCustomAttributes<ValidationAttribute>())
                {
                    bool result = attr.Validate(value);
                    Console.WriteLine($"{ attr.ToString() } result is { result }");
                }
            }


            return false;
        }
    }
}
