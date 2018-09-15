using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        //public int Type { get; private set; }

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
        public override bool IsValid(object value)
        {
            // Automatically pass if the value is null or empty. RequiredAttribute should be used to assert a value is not empty.
            if (value == null)
            {
                return true;
            }

            int? tmp = value as int?;
            return ((tmp != null) && (tmp >= Minimum && tmp <= Maximum));
        }
    }
}
