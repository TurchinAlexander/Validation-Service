using System;
using Validation_Service.Result;

namespace Validation_Service.Attributes
{
    /// <summary>
    /// Validation attribute to indicate that a property field or parameter is required.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class RequiredAttribute : ValidationAttribute
    {
        /// <summary>
        /// Gets or sets a flag indicating whether the attribute should allow empty strings.
        /// </summary>
        public bool AllowEmptyString { get; set; } = false;

        /// <summary>
        /// Gets or sets a message that will be returned by <see cref="RequiredAttribute.Validate(object)"/>
        /// in <see cref="SingleReport.Details"/>
        /// </summary>
        public string ErrorMessage { get; set; } = "The value is not determined!";

        /// <summary>
        /// Override of <see cref="ValidationAttribute.Validate(object)"/>
        /// </summary>
        /// <param name="value">The value to test.</param>
        /// <returns><c>false</c> if the value is null or an empty string. If <see cref="RequiredAttribute.AllowEmptyString"/>
        /// then <c>false</c> is returned only if <paramref name="value"/> is null.</returns>
        public override SingleReport Validate(object value)
        {
            if (value == null)
            {
                return new SingleReport(isValid: false, this.ErrorMessage);
            }

            var stringValue = value as string;
            if (stringValue != null)
            {
                if(!AllowEmptyString && stringValue.Trim().Length == 0)
                {
                    return new SingleReport(isValid: false, this.ErrorMessage);
                }
            }
            else
            {
                return new SingleReport(isValid: false, this.ErrorMessage);
            }

            return new SingleReport(isValid: true);
        }
    }
}
