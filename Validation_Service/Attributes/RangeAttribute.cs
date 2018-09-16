using System;
using Validation_Service.Result;

namespace Validation_Service.Attributes
{
    /// <summary>
    /// Used for specifying a range constraint.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class RangeAttribute : ValidationAttribute
    {
        /// <summary>
        /// Gets the minimum value for the range.
        /// </summary>
        public int Minimum { get; private set; }

        /// <summary>
        /// Gets the maximum value for the range.
        /// </summary>
        public int Maximum { get; private set; }

        /// <summary>
        /// Gets or sets a message that will be returned by <see cref="RangeAttribute.Validate(object)"/>
        /// in <see cref="SingleReport.Details"/>
        /// </summary>
        public string ErrorMessage { get; set; } = "The value doen't located between min and max ones!";

        /// <summary>
        /// Constructor that takes integer minimum and maximum values.
        /// </summary>
        /// <param name="minimum">The minimum value, inclusive</param>
        /// <param name="maximum">The maximum value, inclusive</param>
        public RangeAttribute(int minimum, int maximum)
        {
            this.Minimum = minimum;
            this.Maximum = maximum;
        }

        /// <summary>
        /// Returns <c>true</c> if the value between minimum and maximum, enclusive.
        /// </summary>
        /// <param name="value">The object to validate.</param>
        /// <returns><c>true</c> means the <paramref name="value"/> is valid.</returns>
        public override SingleReport Validate(object value)
        {
            // Automatically pass if the value is null or empty. RequiredAttribute should be used to assert a value is not empty.
            if (value == null)
            {
                return new SingleReport(isValid: true);
            }

            int tmp = (int)value;
            bool isValid = (tmp >= Minimum && tmp <= Maximum);

            return (isValid) ? new SingleReport(isValid: true)
                : new SingleReport(isValid: false, this.ErrorMessage);
        }
    }
}
