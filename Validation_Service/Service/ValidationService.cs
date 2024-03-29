﻿using System;
using Validation_Service.Attributes;
using Validation_Service.Result;
using Validation_Service.Logger;
using System.Reflection;

namespace Validation_Service.Service
{
    /// <summary>
    /// Attribute based service of object validation.
    /// </summary>
    public class ValidationService : BaseValidationService
    {
        /// <summary>
        /// Utility to log validation details.
        /// </summary>
        private readonly ILogger logger;


        /// <param name="logger">The utility to log validation details.</param>
        public ValidationService(ILogger logger)
        {
            this.logger = logger;
        }

        /// <summary>
        /// Internal logic of object validation.
        /// </summary>
        /// <param name="obj">The object to validate.</param>
        /// <param name="fullPath">The full object path in its structure.</param>
        /// <returns>
        /// <see cref="FullReport"/> with <c>IsValid</c> flag is set to <c>true</c>
        /// if the <paramref name="obj"/> is acceptable. Otherwise, the flag is set to <c>false</c>
        /// and <see cref="FullReport"/> contains a report of all problems.
        /// </returns>
        public override FullReport Validate(object obj, string fullPath = "")
        {
            FullReport fullReport = new FullReport(isValid: true);

            if(obj == null)
            {
                return fullReport;
            }

            foreach(PropertyInfo prop in obj.GetType().GetProperties())
            {
                object value = prop.GetValue(obj);

                foreach(ValidationAttribute attr in prop.GetCustomAttributes<ValidationAttribute>())
                {
                    // SingleReport singleReport = attr.Validate(value);
                    var singleReport = attr.Validate(value);
                    fullReport += new SingleReport(singleReport.IsValid,
                        singleReport.Details != null ? $"{fullPath}.{prop.Name} : {singleReport.Details}" : null);
                }
            }

            WriteReport(fullReport);

            return fullReport;
        }

        private void WriteReport(FullReport fullReport)
        {
            if (fullReport != null)
            {
                foreach(string msg in fullReport.Details)
                {
                    logger.Log(msg);
                }
            }
        }
    }
}


