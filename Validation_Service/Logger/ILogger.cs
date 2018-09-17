using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation_Service.Logger
{
    /// <summary>
    /// Interface for interaction with Logger.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Logging information.
        /// </summary>
        /// <param name="message">The message to write.</param>
        void Log(string message);
    }
}
