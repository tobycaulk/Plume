using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plume.Models.Error
{
    public class PlumeException : Exception
    {
        public static readonly PlumeException InvalidRequest = new PlumeException("Invalid request", 1);
        public static readonly PlumeException InvalidResponse = new PlumeException("Invalid response", 2);
        public static readonly PlumeException UnhandledError = new PlumeException("Unhandled exception", 3);

        public int Code { get; set; }
        public string ExceptionMessage { get; set; }

        public PlumeException(string message, int code) : base(message)
        {
            Code = code;
            ExceptionMessage = message;
        }

        public PlumeException(string message, int code, Exception inner) : base(message, inner)
        {
            Code = code;
            ExceptionMessage = message;
        }
    }
}
