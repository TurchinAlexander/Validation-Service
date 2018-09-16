using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validation_Service.Result;

namespace Validation_Service.Service
{
    /// <summary>
    /// Base class for object validation service.
    /// </summary>
    public abstract class BaseValidationService
    {
        /// <summary>
        /// Gets the object indicating whether or not the specified <paramref name="obj"/> is valid
        /// </summary>
        /// <param name="obj">The object to validate.</param>
        /// <param name="objName">The object name. Used to print full qualified property name to <see cref="FullReport.Details"/></param>
        /// <returns>
        /// <see cref="FullReport"/> with <c>IsValid</c> flag set to <c>true</c>
        /// if the <paramref name="obj"/> is acceptable. Otherwise, the flag is set to <c>false</c> and
        /// <see cref="FullReport.Details"/> contains a report on problems.
        /// </returns>
        public abstract FullReport Validate(object obj, string objName = "");
    }
}
