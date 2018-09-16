using System;
using System.Globalization;
using Validation_Service.Result;

namespace Validation_Service.Attributes
{
    /// <summary>
    /// Specifies the minimum length of array|string data allowed in a property.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class MinLengthAttribute : ValidationAttribute
    {
        /// <summary>
        /// Gets the minimum allowable length of the array or string data.
        /// </summary>
        public int Length { get; private set; }

        /// <summary>
        /// Gets or sets a message that will be returned by <see cref="MinLengthAttribute.Validate(object)"/>
        /// in <see cref="SingleReport.Details"/>
        /// </summary>
        public string ErrorMessage { get; set; } = "The length of value is below the minumum!";

        /// <summary>
        /// Initialize a new instance of the
        /// </summary>
        /// <param name="length">Set minimum length of value</param>
        public MinLengthAttribute(int length)
        {
            Length = length;
        }

        /// <summary>
        /// Determines whether a specified object is valid. (Overrides <see cref="ValidationAttribute.Validate(object)"/>)
        /// </summary>
        /// <remarks>
        /// This method return <c>true</c> if the <paramref name="value"/> is null.
        /// It is assumed the <see cref="RequiedAttribute"/> is used if the value may not be null.
        /// </remarks>
        /// <param name="value">The object to validate.</param>
        /// <returns><c>true</c> if the value is null or greater than or equal to the specified minimum length, otherwise <c>false</c></returns>
        /// <exception cref="InvalidOperationException">Length is less than zero.</exception>
        public override SingleReport Validate(object value)
        {
            EnsureLegalLength();

            bool isValid = true;

            if(value == null)
            {
                return new SingleReport(isValid: false, this.ErrorMessage);
            }
            else
            {
                var str = value as string;
                if (str != null)
                {
                    isValid = (str.Length >= this.Length);
                }
                else
                {
                    isValid = false;
                }
            }

            return (isValid) ? new SingleReport(isValid: true)
                : new SingleReport(isValid: false, this.ErrorMessage);
        }

        /// <summary>
        /// Check that Length has a legal value.
        /// </summary>
        private void EnsureLegalLength()
        {
            if (Length < 0)
            {
                throw new InvalidOperationException(String.Format(CultureInfo.CurrentCulture, "MinLengthAttribute_InvalidLength"));
            }
        }
    }
}
