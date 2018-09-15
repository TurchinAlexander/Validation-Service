using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation_Service
{
    public abstract class ValidationAttribute : Attribute
    {
        //private string _errorMessage;

        public abstract bool IsValid(object value);
    }
}
