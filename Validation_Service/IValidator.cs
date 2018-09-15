using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation_Service
{
    /// <summary>
    /// Interface to validator.
    /// </summary>
    public interface IValidator
    {
        /// <summary>
        /// Verify the object for the correctness.
        /// </summary>
        /// <param name="obj">The object to validate</param>
        /// <returns><c>true</c> if object is null or valiated. Otherwise <c>false</c></returns>
        bool Validate(object obj);
    }
}
