using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation_Service.Result
{
    /// <summary>
    /// Class to report status of validation object.
    /// </summary>
    /// <para>Should be override to provide more information about validation report.</para>
    public abstract class ValidationReport
    {
        /// <summary>
        /// Get a validation object status.
        /// </summary>
        public bool IsValid { get; protected set; }
    }
}
