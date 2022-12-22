using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    internal class StreetException :Exception
    {
        public StreetException()
        {
        }

        public StreetException(string? message) : base(message)
        {
        }

        public StreetException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected StreetException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
