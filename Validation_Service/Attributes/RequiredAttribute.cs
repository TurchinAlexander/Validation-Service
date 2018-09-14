using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation_Service.Attributes
{
    /// <summary>
    /// Validation attribute to indicate that a property field or parameter is required.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    class RequiredAttribute : BaseAttribute
    {
        /// <summary>
        /// Gets or sets a flag indicating whether the attribute
        /// </summary>
        public bool AllowEmptyString { get; set; }

        /// <summary>
        /// Override of <see cref="BaseAttribute.IsValid(object)"/>
        /// </summary>
        /// <param name="value">The value to test.</param>
        /// <returns><c>false</c> if the value is null or an empty string. If <see cref="RequiredAttribute.AllowEmptyString"/>
        /// then <c>false</c> is returned only if <paramref name="value"/> is null.</returns>
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }

            // Only check string length if empty string are not allowed.
            var stringValue = value as string;
            if (stringValue != null && !AllowEmptyString)
            {
                return stringValue.Trim().Length != 0;
            }

            return true;
        }
    }
}
