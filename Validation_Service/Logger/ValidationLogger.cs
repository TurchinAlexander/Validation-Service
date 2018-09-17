using System;
using System.Collections.Generic;
using System.IO;

namespace Validation_Service.Logger
{
    /// <summary>
    /// Class to write validation report to file.
    /// </summary>
    public class ValidationLogger : ILogger
    {
        private const string _extension = "txt";

        /// <summary>
        /// Name of log file.
        /// </summary>
        public string LogName { get; set; } = "log";

        public ValidationLogger(string logName = null)
        {
            if (logName != null)
            {
                this.LogName = logName;
            }
        }

        /// <summary>
        /// Write message to the file.
        /// </summary>
        /// <param name="message">The message</param>
        public void Log(string message)
        {
            using (StreamWriter streamWriter = new StreamWriter($"{LogName}.{_extension}", append: true))
            {
                streamWriter.WriteLine($"{DateTime.Now.ToString("G")} : {message}");
                streamWriter.Close();
            }
        }

    }
}
