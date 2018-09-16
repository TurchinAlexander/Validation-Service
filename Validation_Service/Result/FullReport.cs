using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation_Service.Result
{
    /// <summary>
    /// Class to report results of a all validation acts.
    /// </summary>
    public class FullReport : ValidationReport
    {
        /// <summary>
        /// Represents details of validations.
        /// </summary>
        public List<string> Details;

        /// <summary>
        /// Constructor that takes result of validations.
        /// </summary>
        /// <param name="isValid">Result of validations.</param>
        /// <param name="details">Details of validations.</param>
        public FullReport(bool isValid, List<string> details = null)
        {
            this.IsValid = isValid;
            this.Details = details;
        }

        /// <summary>
        /// Overrided method that help merge two instances of <see cref="FullReport"/> 
        /// </summary>
        /// <param name="a">First report</param>
        /// <param name="b">Second report</param>
        /// <returns>
        /// <see cref="FullReport"/> which contains a logical sum of <c>IsValid</c> flags of operands
        /// and problem details of both conclusions.
        /// </returns>
        public static FullReport operator +(FullReport a, FullReport b)
        {
            bool isValid = a.IsValid && b.IsValid;

            if (a.Details == null && b.Details == null)
            {
                return new FullReport(isValid);
            }

            if(a.Details == null)
            {
                return new FullReport(isValid, b.Details);
            }
            else if (b.Details == null)
            {
                return new FullReport(isValid, a.Details);
            }
            else
            {
                return new FullReport(isValid, a.Details.Concat(b.Details).ToList());
            }
        }


        /// <summary>
        /// Overriden method that helps to merge an instance of <see cref="FullReport"/>
        /// with an instance of <see cref="SingleReport"/>
        /// </summary>
        /// <param name="a">Full report</param>
        /// <param name="b">Single report</param>
        /// <returns>
        /// <see cref="FullReport"/> which contains a logical sum of <c>IsValid</c> flags of operands
        /// and problem details of both conclusions.
        /// </returns>
        public static FullReport operator +(FullReport a, SingleReport b)
        {
            bool isValid = a.IsValid && b.IsValid;
            List<string> details = null;

            if (a.Details != null)
            {
                details = new List<string>(a.Details);
            }

            if(b.Details != null)
            {
                details = details ?? new List<string>();
                details.Add(b.Details);
            }

            return new FullReport(isValid, details);
        }
    
    }
}
