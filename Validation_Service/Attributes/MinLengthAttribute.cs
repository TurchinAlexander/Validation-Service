using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Validation_Service.Attributes
{
    /// <summary>
    /// Specifies the minimum length of array|string data allowed in a property.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class MinLengthAttribute : BaseAttribute
    {
        /// <summary>
        /// Gets the minimum allowable length of the array or string data.
        /// </summary>
        public int Length { get; private set; }

        /// <summary>
        /// Initialize a new instance of the
        /// </summary>
        /// <param name="length"></param>
        public MinLengthAttribute(int length)
        {
            Length = length;
        }

        /// <summary>
        /// Determines whether a specified object is valid. (Overrides <see cref="BaseAttribute.IsValid(object)"/>)
        /// </summary>
        /// <remarks>
        /// This method return <c>true</c> if the <paramref name="value"/> is null.
        /// It is assumed the <see cref="RequiedAttribute"/> is used if the value may not be null.
        /// </remarks>
        /// <param name="value">The object to validate.</param>
        /// <returns><c>true</c> if the value is null or greater than or equal to the specified minimum length, otherwise <c>false</c></returns>
        /// <exception cref="InvalidOperationException">Length is less than zero.</exception>
        public override bool IsValid(object value)
        {
            // Check the length for the legality.
            EnsureLegalLength();

            var length = 0;
            // Automatically pass if the value is null. RequiredAttribute should be used to assert the value is not null.
            if(value == null)
            {
                return true;
            }
            else
            {
                var str = value as string;
                if (str != null)
                {
                    length = str.Length;
                }
                else
                {
                    // We expect a cast exception if a non-{string|array} property was passed in.
                    length = ((Array)value).Length;
                }
            }

            return length >= Length;
        }

        /// <summary>
        /// Check that Length has a legal value.
        /// </summary>
        private void EnsureLegalLength()
        {
            if(Length < 0)
            {
                throw new InvalidOperationException(String.Format(CultureInfo.CurrentCulture, "MinLengthAttribute_InvalidLength"));
            }
        }
    }
}
