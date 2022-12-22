using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    internal class PostalCodeException : Exception
    {
        public PostalCodeException()
        {
        }

        public PostalCodeException(string? message) : base(message)
        {
        }

        public PostalCodeException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected PostalCodeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
