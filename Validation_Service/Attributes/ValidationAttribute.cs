using System;
using Validation_Service.Result;

namespace Validation_Service
{
    /// <summary>
    /// Base class to all validation attributes
    /// </summary>
    public abstract class ValidationAttribute : Attribute
    {
        /// <summary>
        /// Gets the object indicating whether or not the specified <paramref name="obj"/> is valid
        /// with respect to the current validation attribute.
        /// </summary>
        /// <param name="value">The object to validate</param>
        /// <returns>
        /// <see cref="SingleReport"/> with <c>IsValid</c> flag set to <c>true</c> 
        /// if the <paramref name="obj"/> is acceptable. Otherwise, the flag is set to <c>false</c> and
        /// <see cref="SingleReport.Details"/> contains a problem report. 
        /// </returns>
        public abstract SingleReport Validate(object value);
    }
}
