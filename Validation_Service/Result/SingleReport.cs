using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation_Service.Result
{
    /// <summary>
    /// Class to report results of a single validation act.
    /// </summary>
    public class SingleReport : ValidationReport
    {
        /// <summary>
        /// Represent details of a validation. 
        /// </summary>
        public string Details { get; private set; }

        /// <summary>
        /// Constructor that takes a result of validation.
        /// </summary>
        /// <param name="isValid">The result of validation.</param>
        /// <param name="errorMsg">Details of validation.</param>
        public SingleReport(bool isValid, string details = null)
        {
            this.IsValid = IsValid;
            this.Details = details;
        }
    }
}
